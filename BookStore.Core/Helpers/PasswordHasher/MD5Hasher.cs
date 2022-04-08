using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Helpers.PasswordHasher
{
    public class MD5Hasher
    {
        public static string HashPassword(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] md5Pass = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < md5Pass.Length; i++)
            {
                stringBuilder.Append(md5Pass[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
