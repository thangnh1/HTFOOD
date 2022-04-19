using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HTFOOD.Lib
{
    class Class_Encrypt
    {
        public string SHA1(string password)
        {
            byte[] textBytes = Encoding.Default.GetBytes(password);
            try
            {

                SHA1CryptoServiceProvider sha1crypt;
                sha1crypt = new SHA1CryptoServiceProvider();
                byte[] hash = sha1crypt.ComputeHash(textBytes);
                string passencrypt = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        passencrypt += "0" + a.ToString("x");
                    else
                        passencrypt += a.ToString("x");
                }
                return passencrypt;
            }
            catch
            {
                throw;
            }
        }
        public string MD5(string password)
        {
            byte[] textBytes = Encoding.Default.GetBytes(password);
            try
            {
                MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }
    }
}
