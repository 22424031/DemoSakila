using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Ententions
{
    public class EnCryptExtension
    {
        public static string Encrypt(string toEncrypt, string key)
        {
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = Encoding.UTF8.GetBytes(key);
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform cTransform = tdes.CreateEncryptor())
                {
                    byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    return Convert.ToBase64String(resultArray);
                }
            }
        }
        public static string Decrypt(string toDecrypt, string key)
        {
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = Encoding.UTF8.GetBytes(key);
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform cTransform = tdes.CreateDecryptor())
                {
                    byte[] toDecryptArray = Convert.FromBase64String(toDecrypt);
                    byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                    return Encoding.UTF8.GetString(resultArray);
                }
            }
        }
    }
}
