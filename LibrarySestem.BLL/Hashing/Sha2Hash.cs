using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LibrarySestem.BLL.Hashing
{
    public static class Sha2Hash
    {
        private static string salt = "91d0b433203e5a55";

        public static string GetHash(string str, bool withSalt = false)
        {
            if(withSalt)
            {
                str += salt;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(str);

            using (SHA256 sha = SHA256.Create())
            {
                bytes = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }

            return null;
        }
    }
}
