using System.Security.Cryptography;

namespace dotnetEncryptionSample.Services
{
  public class EncryptionService
  {
        public EncryptionService() { }

        public (byte[], byte[]) GetAesInstance()
        {
            var aes = Aes.Create();
            return (aes.Key, aes.IV);
        }

        public (string, string, string) EncryptAes(string plaintext) { 

            using (var aes = Aes.Create())
            {
                var encrypted = EncryptStringToBytes_Aes(plaintext, aes.Key, aes.IV);
                return (Convert.ToBase64String(encrypted), Convert.ToBase64String(aes.Key), Convert.ToBase64String(aes.IV));
            }
        }

        private static byte[] EncryptStringToBytes_Aes(string plaintext, byte[] key, byte[] IV) {
            byte[] encrypted;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = IV;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt =  new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) 
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plaintext);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
  }
}
