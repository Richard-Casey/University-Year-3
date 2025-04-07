using System;
using System.Collections.Generic;

/// <summary>
/// Manages refresh tokens, including generation, validation, and revocation.
/// </summary>
public class RefreshTokenManager
{
    /// <summary>
    /// In-memory storage for refresh tokens associated with user emails.
    /// </summary>
    private Dictionary<string, string> refreshTokenDatabase = new Dictionary<string, string>();

    /// <summary>
    /// Generates a new refresh token for the given email.
    /// </summary>
    /// <param name="email">The email address for which to generate the refresh token.</param>
    /// <returns>A newly generated refresh token.</returns>
    public string GenerateRefreshToken(string email)
    {
        // Create a new GUID as the refresh token
        var refreshToken = Guid.NewGuid().ToString();

        // Store the refresh token in the dictionary with the email as the key
        refreshTokenDatabase[email] = refreshToken;

        // Return the generated refresh token
        return refreshToken;
    }

    /// <summary>
    /// Validates the provided refresh token for the given email.
    /// </summary>
    /// <param name="email">The email address associated with the refresh token.</param>
    /// <param name="refreshToken">The refresh token to validate.</param>
    /// <returns>True if the refresh token is valid, otherwise false.</returns>
    public bool ValidateRefreshToken(string email, string refreshToken)
    {
        // Check if the dictionary contains the email and if the stored refresh token matches the provided refresh token
        return refreshTokenDatabase.ContainsKey(email) && refreshTokenDatabase[email] == refreshToken;
    }

    /// <summary>
    /// Revokes the refresh token associated with the given email.
    /// </summary>
    /// <param name="email">The email address whose refresh token should be revoked.</param>
    public void RevokeRefreshToken(string email)
    {
        // Remove the refresh token associated with the email if it exists in the dictionary
        if (refreshTokenDatabase.ContainsKey(email))
        {
            refreshTokenDatabase.Remove(email);
        }
    }
}
