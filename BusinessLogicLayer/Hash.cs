using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicLayer
{
    public static class Hash
    {
        private static string _salt = "rijnkdci3kjksdsaximihfew";

        public static string GenerateHashPassword(string password)
        {
            var hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(password + _salt)));
        }
    }
}
