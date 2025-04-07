using System;
using System.IdentityModel.Tokens.Jwt; 
using System.Text;
using Microsoft.IdentityModel.Tokens; 

public class JwtTokenGenerator
{
    private const string SecretKey = "my_super_secret_key_which_is_at_least_32_chars_long";

    private const string Issuer = "This_would_be_my_domain";

    private const string Audience = "This would also be my domain";

    public string GenerateJwtToken(string email)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[] { new System.Security.Claims.Claim("email", email) }),
            Expires = DateTime.UtcNow.AddMinutes(30), // Token expiration set to 30 minutes from the current time.
            Issuer = Issuer,
            Audience = Audience,
            SigningCredentials = credentials
        };

        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
}
