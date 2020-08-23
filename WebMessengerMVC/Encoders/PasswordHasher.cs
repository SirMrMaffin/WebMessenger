using System.Security.Cryptography;
using System.Text;

namespace WebMessengerMVC.Encoders
{
    public class PasswordHasher
    {
        private readonly SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

        public string Encode(string password)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(password);
            var hashedPasswordBytes = sha1.ComputeHash(passwordBytes);
            var hashedPassword = Encoding.ASCII.GetString(hashedPasswordBytes);

            return hashedPassword;
        }
    }
}
