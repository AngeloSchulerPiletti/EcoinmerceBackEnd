﻿using Ecoinmerce.Domain.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace Ecoinmerce.Domain.Entities
{
    public class EcommerceManager : IBaseAuthenticable, IBaseConfirmable
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string TokenConfirmation { get; set; }
        public DateTime? TokenConfirmationExpiry { get; set; }
        public string AccessToken { get; set; }
        public DateTime? AccessTokenExpiry { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public byte[] Salt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public uint EcommerceId { get; set; }
        [JsonIgnore]
        public virtual Ecommerce Ecommerce { get; set; }
    }
}