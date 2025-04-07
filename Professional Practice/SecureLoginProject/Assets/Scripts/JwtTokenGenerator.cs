using System;
using System.IdentityModel.Tokens.Jwt; // Provides classes for creating and validating JSON web tokens
using System.Text;
using Microsoft.IdentityModel.Tokens; // Classes for cryptographic operations

/// <summary>
/// Generates JSON Web Tokens (JWT) for user authentication.
/// </summary>
public class JwtTokenGenerator
{
    /// <summary>
    /// A constant secret key used for signing the JWT. This key should be at least 32 characters long for security.
    /// </summary>
    private const string SecretKey = "my_super_secret_key_which_is_at_least_32_chars_long";

    /// <summary>
    /// Issuer of the token - normally the domain or application name.
    /// </summary>
    private const string Issuer = "This_would_be_my_domain";

    /// <summary>
    /// The audience of the token - normally domain or application name.
    /// </summary>
    private const string Audience = "This would also be my domain";

    /// <summary>
    /// Creates a JWT token for the given email address.
    /// </summary>
    /// <param name="email">The email address for which to generate the token.</param>
    /// <returns>A JWT token as a string.</returns>
    public string GenerateJwtToken(string email)
    {
        // Convert the secret key to a byte array.
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        // Create signing credentials using the secret key and the HMAC SHA-256 algorithm.
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Describe the security token, including claims, expiration, issuer, audience, and signing credentials.
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[] { new System.Security.Claims.Claim("email", email) }),
            Expires = DateTime.UtcNow.AddMinutes(30), // Token expiration set to 30 minutes from the current time.
            Issuer = Issuer,
            Audience = Audience,
            SigningCredentials = credentials
        };

        // Create token handler
        var handler = new JwtSecurityTokenHandler();

        // Create the token based on the token descriptor
        var token = handler.CreateToken(tokenDescriptor);

        // Write the token as a string and return it
        return handler.WriteToken(token);
    }
}
