using System.Security.Cryptography;
using System.Text;

namespace WebMessengerMVC.Encoders
{
    public class ASCIIEncoder
    {
        public string Encode(string password)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(password);
            var sha1 = new SHA1CryptoServiceProvider();
            var hashedPasswordBytes = sha1.ComputeHash(passwordBytes);
            var hashedPassword = Encoding.ASCII.GetString(hashedPasswordBytes);

            return hashedPassword;
        }
    }
}
