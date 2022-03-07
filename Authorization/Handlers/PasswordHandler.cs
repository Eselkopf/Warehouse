using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Handlers
{
    public class PasswordHandler
    {
        public byte[] Hash(string password)
        {
            var md5 = MD5.Create();
            md5.ComputeHash(Encoding.Default.GetBytes(password));
            return md5.Hash;
        }
    }
}
