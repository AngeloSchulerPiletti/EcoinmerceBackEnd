using Ecoinmerce.Application.BusinessInterfaces.Auth;
using Ecoinmerce.Application.TokenService.Interface;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VO.Responses;
using Ecoinmerce.Domain.ValidatedMappers.Interfaces;
using Ecoinmerce.Infra.Repository.Interfaces;

namespace Ecoinmerce.Application.Business.Auth
{
    public class SignupBusiness : ISignupBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidatedMappings _mapperValidated;
        private readonly ITokenServiceUser _tokenServiceUser;

        public SignupBusiness(
                            IUserRepository userRepository,
                            IValidatedMappings mapperValidated, 
                            ITokenServiceUser tokenServiceUser)
        {
            _tokenServiceUser = tokenServiceUser;
            _mapperValidated = mapperValidated;
            _userRepository = userRepository;
        }

        public MessageBagSingleEntityVO<User> MapToEntityHashingPassword(NewUserDTO newUserDTO)
        {
            MessageBagSingleEntityVO<User> newUserMessageBag = _mapperValidated.MapUserWithValidation(newUserDTO);
            if (newUserMessageBag.IsError) return newUserMessageBag;

            User newUser = _tokenServiceUser.HashPasswordWithNewSalt(newUserMessageBag.Entity, newUserDTO.NakedPassword);
            if (newUser == null) return new MessageBagSingleEntityVO<User>("Erro ao fazer o hash da senha, tente outra senha", "Erro de senha");

            return new MessageBagSingleEntityVO<User>("Usuário mapeado e senha hasheada com sucesso", "Sucesso ao mapear e manejar senha", false, newUser);
        }

        public MessageBagSingleEntityVO<Ecommerce> MapToEntity(NewEcommerceDTO newEcommerceDTO)
        {
            return _mapperValidated.MapEcommerceWithValidation(newEcommerceDTO);
        }

        public MessageBagVO CheckIfUserNameAndEmailIsBeingUsed(NewUserDTO newUserDTO)
        {
            User user = _userRepository.GetUser(newUserDTO);
            if (user != null) return new MessageBagVO("Username e/ou email já utilizado", "Erro de cadastro");
            return new MessageBagVO("Username e email livres", "", false);
        }

        public MessageBagSingleEntityVO<PublicUserDTO> SaveConfiableNewUserAndEcommerce(User user, Ecommerce ecommerce)
        {
            PublicUserDTO savedUser = _userRepository.SignUpWithNewEcommerce(ecommerce, user);
            if (savedUser == null) return new MessageBagSingleEntityVO<PublicUserDTO>("Houve um problema ao salvar seu usuário ou empresa", "Erro ao criar usuário ou empresa");
            return new MessageBagSingleEntityVO<PublicUserDTO>("Usuário e empresa criados com sucesso!", "Sucesso", false, savedUser);
        }
    }
}
