using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Blend.IT.CrossCutting.Util
{
    public static class Password
    {
        public static string GenerateDinamic()
        {
            Random rnd = new Random();
            int password = rnd.Next(100000, 999999);
            return password.ToString();
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
