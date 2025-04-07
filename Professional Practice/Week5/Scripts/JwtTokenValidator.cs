using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class JwtTokenValidator
{
    private const string SecretKey = "my_super_secret_key_which_is_at_least_32_chars_long";
    private const string Issuer = "This_would_be_my_domain";
    private const string Audience = "This_would_also_be_my_domain";

    public bool ValidateJwtToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(SecretKey);
        try
        {

            // Validate the token using the proviffded validation parameters
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out SecurityToken validatedToken);

            // If the tokken validation is sucessfull then return true
            return true;
        }
        catch
        {

            // If not - return false
            return false;
        }
    }
}
