
namespace U2U.UtilityFunctions
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Summary description for UtilityFunctionsEncryption.
    /// </summary>
    public class Encryption
    {
        public static string EncryptData(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return String.Empty;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Mode = CipherMode.CBC;
                    using (CryptoStream cryptostream = new CryptoStream(stream,
                                                                        des.CreateEncryptor(Keys.DesKey, Keys.DesIV),
                                                                        CryptoStreamMode.Write))
                    {
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        cryptostream.Write(data, 0, data.Length);
                        cryptostream.FlushFinalBlock();
                    }
                }
                // if you use System.Text.Encoding.UTF8.GetBytes(message) and then store it
                // in the database, decryption will not succeed.
                return System.Convert.ToBase64String(stream.ToArray());
            }
        }

        public static string DecryptData(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return String.Empty;
            }

            try
            {
                using (MemoryStream stream = new System.IO.MemoryStream())
                {
                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {

                        des.Mode = CipherMode.CBC;
                        using (CryptoStream cryptostream = new CryptoStream(stream,
                                                                            des.CreateDecryptor(Keys.DesKey, Keys.DesIV),
                                                                            CryptoStreamMode.Write))
                        {
                            byte[] data = System.Convert.FromBase64String(message);
                            cryptostream.Write(data, 0, data.Length);
                            cryptostream.FlushFinalBlock();
                        }
                        return System.Text.Encoding.UTF8.GetString(stream.ToArray());
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static string ComputeHash(string message)
        {
            SHA1Managed sha = new SHA1Managed();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            byte[] outdata = sha.ComputeHash(data);

            return System.Text.Encoding.UTF8.GetString(outdata);
        }
    }

    public static class Keys
    {
        public static byte[] DesKey = System.Text.Encoding.UTF8.GetBytes("nvutweeu");
        public static byte[] DesIV = System.Text.Encoding.UTF8.GetBytes("uytt wim");
    }

}
