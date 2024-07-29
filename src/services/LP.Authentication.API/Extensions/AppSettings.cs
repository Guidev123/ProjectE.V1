namespace LP.Authentication.API.Extensions
{
    public record AppSettings(string Secret, int ExpiresIn, string ValidIssuer, string ValidAudience);
}
