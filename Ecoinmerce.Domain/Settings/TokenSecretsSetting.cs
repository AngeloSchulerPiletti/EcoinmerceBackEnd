namespace Ecoinmerce.Domain.Settings;

public record TokenSecretsSetting
{
    public TokenSecretsSettingAdmin Admin { get; set; }
    public TokenSecretsSettingManager Manager { get; set; }
    public TokenSecretsSettingEcommerce Ecommerce { get; set; }
}

public record TokenSecretsSettingAdmin 
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string ConfirmationToken { get; set; }
}

public record TokenSecretsSettingManager
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string ConfirmationToken { get; set; }
}

public record TokenSecretsSettingEcommerce
{
      public string ApiCredential { get; set; }
      public string ConfirmationToken { get; set; }
}
