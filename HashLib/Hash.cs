using System.Security.Cryptography;
using System.Text;

namespace HashLib
{
    public class Hash
    {
        private string _salt = "rijnkdci3kjksdsaximihfew";

        public string GenerateHashPassword(string password)
        {
            var hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(password + _salt)));
        }
    }
}
