using AutoMapper;
using BarterHash.Application.TokenService.Interface;
using BarterHash.Domain.Entities.Ecommerce;
using BarterHash.Domain.Objects.DTO.Ecommerce;
using BarterHash.Domain.Objects.VO;
using BarterHash.Infra.Repository.Database.Context;
using BarterHash.Infra.Repository.GenericRepository;
using BarterHash.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BarterHash.Infra.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly ITokenServiceUser _tokenServiceUser;
        private readonly ITokenServiceEcommerce _tokenServiceEcommerce;
        private readonly EcommerceContext _ecommerceContext;
        public UserRepository(
            EcommerceContext ecommerceContext,
            IMapper mapper,
            ITokenServiceUser tokenServiceUser,
            ITokenServiceEcommerce tokenServiceEcommerce
            ) : base(ecommerceContext)
        {
            _mapper = mapper;
            _ecommerceContext = ecommerceContext;
            _tokenServiceUser = tokenServiceUser;
            _tokenServiceEcommerce = tokenServiceEcommerce;
        }

        public User CheckPrimaryKeys(NewUserDTO newUserDTO)
        {
            return _ecommerceContext.Users.Find(newUserDTO.UserName, newUserDTO.Email);
        }

        public User SignUpWithNewEcommerce(NewUserAndEcommerceDTO newUserAndEcommerceDTO)
        {
            Ecommerce ecommerce = _mapper.Map<Ecommerce>(newUserAndEcommerceDTO.Ecommerce);
            User user = _mapper.Map<User>(newUserAndEcommerceDTO.User);

            TokenVO ecommerceTokenVo = _tokenServiceEcommerce.GenerateToken(ecommerce);
            ecommerce.AccessToken = ecommerceTokenVo.Token;

            user.Salt = RandomNumberGenerator.GetBytes(40);

            byte[] nakedPasswordBytes = Encoding.ASCII.GetBytes(newUserAndEcommerceDTO.User.NakedPassword);

            string hashedPassword = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: newUserAndEcommerceDTO.User.NakedPassword,
                    salt: user.Salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8
                    )
                );

            user.Password = hashedPassword;

            TokenVO emailConfirmationToken = _tokenServiceUser.GenerateConfirmationToken(user);
            user.TokenConfirmation = emailConfirmationToken.Token;
            user.TokenConfirmationExpiry = emailConfirmationToken.TokenData.ValidTo;

            user.Role = "manager";
            user.Ecommerce = ecommerce;

            TokenVO userTokenVo = _tokenServiceUser.GenerateAccessToken(user);
            user.AccessToken = userTokenVo.Token;
            user.AccessTokenExpiry = userTokenVo.TokenData.ValidTo;

            _ecommerceContext.Users.Add(user);
            _ecommerceContext.SaveChanges();

            return user;
        }

        public User VerifyEmail(string tokenConfirmation)
        {
            Claim email = _tokenServiceUser.GetEmailFromConfirmationToken(tokenConfirmation);
            if (email == null) return null;

            User user = _ecommerceContext.Users.FirstOrDefault(u => u.Email == email.Value);
            if(user == null) return null;

            if(user.TokenConfirmation != tokenConfirmation || user.TokenConfirmationExpiry < DateTime.Now) return null;

            user.EmailConfirmed = true;
            _ecommerceContext.SaveChanges();

            return user;
        }
    }
}
