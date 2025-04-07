using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class CredentialsManager
{
    private Dictionary<string, string> userDatabase = new Dictionary<string, string>();

    public void RegisterUser(string email, string password)
    {
        string normalizedEmail = email.ToLowerInvariant();
        string hashedPassword = HashPassword(password);
        userDatabase[normalizedEmail] = hashedPassword;
    }

    public bool ValidateUser(string email, string password)
    {
        string normalizedEmail = email.ToLowerInvariant();
        if (userDatabase.ContainsKey(normalizedEmail))
        {
            string storedHashedPassword = userDatabase[normalizedEmail];
            string hashedPassword = HashPassword(password);
            return storedHashedPassword == hashedPassword;
        }
        return false;
    }

    private string HashPassword(string password)
    {
        using (var rfc2898 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("Randomsaltesrdiufhb4q3805tgbieuarbg"), 10000))
        {
            byte[] hash = rfc2898.GetBytes(20);
            StringBuilder builder = new StringBuilder();
            foreach (byte b in hash)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
