using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

/// <summary>
/// Validates JSON Web Tokens (JWT) for user authentication.
/// </summary>
public class JwtTokenValidator
{
    /// <summary>
    /// A constant secret key used for signing the JWT. This key should be at least 32 characters long for security.
    /// </summary>
    private const string SecretKey = "my_super_secret_key_which_is_at_least_32_chars_long";

    /// <summary>
    /// The expected issuer of the token.
    /// </summary>
    private const string Issuer = "This_would_be_my_domain";

    /// <summary>
    /// The expected audience of the token.
    /// </summary>
    private const string Audience = "This_would_also_be_my_domain";

    /// <summary>
    /// Validates the JWT token.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>True if the token is valid, otherwise false.</returns>
    public bool ValidateJwtToken(string token)
    {
        // Create a token handler
        var tokenHandler = new JwtSecurityTokenHandler();

        // Convert the secret key to a byte array
        var key = Encoding.UTF8.GetBytes(SecretKey);
        try
        {
            // Validate the token using the provided validation parameters
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

            // If the token validation is successful, then return true
            return true;
        }
        catch
        {
            // If not, return false
            return false;
        }
    }
}
