using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;


// This class is responsible for generating JSON web tokens (JWT)
public class JwtTokenGenerator
{
    // Used for encoding the JWT
    private const string SecretKey = "Needtoinputmyownkeyherebutitneedstobeatleast32characterslong"; // This needs to be at least 32 characters long

    // Issuer of the token - this is typically the domain
    private const string Issuer = "myowndomain dot com";

    // Audience for the token
    private const string Audience = "myowndomain dot com";


    // Generates the token for the email as a string
    public string GenerateJwtToken(string email)
    {
        // Creates the security key
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        // Creates signing credentials using the security key
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Define the token descriptor
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[] { new System.Security.Claims.Claim("email", email) }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = Issuer,
            Audience = Audience,
            SigningCredentials = credentials
        };

        // Create a JWT token handler
        var handler = new JwtSecurityTokenHandler();

        // Create the token based on trhe token descriptor
        var token = handler.CreateToken(tokenDescriptor);

        // Return the token as a string
        return handler.WriteToken(token);
    }
}
