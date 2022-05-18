using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EnAndDecrypt
{
    public class EncoddeMD5
    {
        public String Encrypt(string s)
        {
            String result = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(s);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                result += b.ToString("X");
            }
            return result;
        }
    }
}
