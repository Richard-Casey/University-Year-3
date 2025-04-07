using System;
using System.Collections.Generic;

public class RefreshTokenManager
{
    // To store refresh tokens associeated with user emails
    private Dictionary<string, string> refreshTokenDatabase = new Dictionary<string, string>();

    public string GenerateRefreshToken(string email)
    {
        // Create a new GUID as the refresh token
        var refreshToken = Guid.NewGuid().ToString();

        // Store the refresh token in the dictionary with the email as the key
        refreshTokenDatabase[email] = refreshToken;

        // Return the generated refresh token
        return refreshToken;
    }

    public bool ValidateRefreshToken(string email, string refreshToken)
    {
        // Check if the dictionary contains the email and if the stored refresh token matches the provided refresh token
        return refreshTokenDatabase.ContainsKey(email) && refreshTokenDatabase[email] == refreshToken;
    }

    public void RevokeRefreshToken(string email)
    {
        // Remove the refresh token associated with the email if it exists in the dictionary
        if (refreshTokenDatabase.ContainsKey(email))
        {
            refreshTokenDatabase.Remove(email);
        }
    }
}
