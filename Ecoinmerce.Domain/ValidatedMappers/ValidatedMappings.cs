using AutoMapper;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.DTO.EcommerceDTO;
using Ecoinmerce.Domain.Objects.VO.Responses;
using Ecoinmerce.Domain.ValidatedMappers.Interfaces;
using Ecoinmerce.Domain.Validators.EcommerceValidators;
using FluentValidation.Results;

namespace Ecoinmerce.Domain.ValidatedMappers
{
    public class ValidatedMappings : IValidatedMappings
    {
        private readonly IMapper _mapper;

        public ValidatedMappings(IMapper mapper)
        {
            _mapper = mapper;
        }

        public MessageBagSingleEntityVO<Ecommerce> MapEcommerceWithValidation(NewEcommerceDTO newEcommerceDTO)
        {
            NewEcommerceDTOValidator ecommerceValidator = new();
            ValidationResult ecommerceResult = ecommerceValidator.Validate(newEcommerceDTO);
            if (!ecommerceResult.IsValid)
            {
                MessageBagSingleEntityVO<Ecommerce> errors = new();
                foreach (ValidationFailure failure in ecommerceResult.Errors)
                {
                    errors.Messages.Add(failure.ErrorMessage);
                }

                return errors;
            }
            Ecommerce ecommerce = _mapper.Map<Ecommerce>(newEcommerceDTO);
            return new MessageBagSingleEntityVO<Ecommerce>("Ecommerce mapeado", null, false, ecommerce);
        }

        public MessageBagSingleEntityVO<User> MapUserWithValidation(NewUserDTO newUserDTO)
        {
            NewUserDTOValidator userDTOValidator = new();
            ValidationResult userResult = userDTOValidator.Validate(newUserDTO);
            if (!userResult.IsValid)
            {
                MessageBagSingleEntityVO<User> errors = new();
                foreach (ValidationFailure failure in userResult.Errors)
                {
                    errors.Messages.Add(failure.ErrorMessage);
                }
                return errors;
            }
            User user = _mapper.Map<User>(newUserDTO);
            return new MessageBagSingleEntityVO<User>("User mapeado", null, false, user);
        }
    }
}
