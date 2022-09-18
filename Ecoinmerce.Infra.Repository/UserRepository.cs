using AutoMapper;
using Ecoinmerce.Application.TokenService.Interface;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VO;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.GenericRepository;
using Ecoinmerce.Infra.Repository.Interfaces;
using System.Security.Claims;

namespace Ecoinmerce.Infra.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ITokenServiceUser _tokenServiceUser;
        private readonly ITokenServiceEcommerce _tokenServiceEcommerce;
        private readonly EcommerceContext _ecommerceContext;
        private readonly IMapper _mapper;
        public UserRepository(
            EcommerceContext ecommerceContext,
            ITokenServiceUser tokenServiceUser,
            ITokenServiceEcommerce tokenServiceEcommerce, 
            IMapper mapper
            ) : base(ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
            _tokenServiceUser = tokenServiceUser;
            _tokenServiceEcommerce = tokenServiceEcommerce;
            _mapper = mapper;
        }

        public User GetUser(NewUserDTO newUserDTO)
        {
            User emailUserSearch = _ecommerceContext.Users.FirstOrDefault(x => x.Email == newUserDTO.Email);
            if (emailUserSearch != null) return emailUserSearch;
            User usernameUserSearch = _ecommerceContext.Users.FirstOrDefault(x => x.UserName == newUserDTO.UserName);
            return usernameUserSearch;
        }

        public PublicUserDTO SignUpWithNewEcommerce(Ecommerce ecommerce, User user)
        {
            try
            {
                TokenVO ecommerceTokenVo = _tokenServiceEcommerce.GenerateToken(ecommerce);
                ecommerce.AccessToken = ecommerceTokenVo.Token;

                TokenVO emailConfirmationToken = _tokenServiceUser.GenerateConfirmationToken(user);
                user.TokenConfirmation = emailConfirmationToken.Token;
                //TODO: Setar email confirmed pra false... (talvez)
                user.TokenConfirmationExpiry = emailConfirmationToken.TokenData.ValidTo;

                user.Role = "manager";
                user.Ecommerce = ecommerce;

                TokenVO userTokenVo = _tokenServiceUser.GenerateAccessToken(user);
                user.AccessToken = userTokenVo.Token;
                user.AccessTokenExpiry = userTokenVo.TokenData.ValidTo;

                TokenVO userRefreshTokenVo = _tokenServiceUser.GenerateRefreshToken(user);
                user.RefreshToken = userRefreshTokenVo.Token;
                user.RefreshTokenExpiry = userRefreshTokenVo.TokenData.ValidTo;

                EcommerceManager ecommerceManager = new();
                ecommerceManager.Ecommerce = ecommerce;
                ecommerceManager.Manager = user;
                _ecommerceContext.EcommerceManagers.Add(ecommerceManager);

                _ecommerceContext.Users.Add(user);
                //_ecommerceContext.SaveChanges();

                PublicUserDTO publicUser = _mapper.Map<PublicUserDTO>(user);

                return publicUser;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PublicUserDTO VerifyEmail(string tokenConfirmation)
        {
            //TODO: depois de verificado, o corfimation token não deveria ser apagado?

            Claim email = _tokenServiceUser.GetEmailFromConfirmationToken(tokenConfirmation);
            if (email == null) return null;

            User user = _ecommerceContext.Users.FirstOrDefault(u => u.Email == email.Value);
            if (user == null) return null;

            if (user.TokenConfirmation != tokenConfirmation || user.TokenConfirmationExpiry < DateTime.Now) return null;

            user.EmailConfirmed = true;
            _ecommerceContext.SaveChanges();

            PublicUserDTO publicUser = _mapper.Map<PublicUserDTO>(user);

            return publicUser;
        }
    }
}
