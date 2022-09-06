using System.Security.Cryptography;
using System.Text;

namespace Entra21.CSharp.Area21.Repository.Authentication
{
    public static class Cryptography
    {
        public static string GetHash(this string value)
        {
            var hash = SHA256.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(value);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
