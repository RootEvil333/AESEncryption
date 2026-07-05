using System.Security.Cryptography;

namespace AESEncryption
{
    public class AES256File
    {
        public static void EncryptFile(string inputFile, string outputFile, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.KeySize = 256;
            aes.Key     = key;
            aes.IV      = iv;
            aes.Mode    = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var inputStream  = File.OpenRead(inputFile);
            using var outputStream = File.Create(outputFile);

            outputStream.Write(iv, 0, iv.Length);

            using var encryptor  = aes.CreateEncryptor();
            using var cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write);
            inputStream.CopyTo(cryptoStream);
        }
        public static void DecryptFile(string inputFile, string outputFile, byte[] key)
        {
            using var inputStream = File.OpenRead(inputFile);

            byte[] iv = new byte[16];
            inputStream.Read(iv, 0, iv.Length);

            using var aes = Aes.Create();
            aes.KeySize = 256;
            aes.Key     = key;
            aes.IV      = iv;
            aes.Mode    = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var outputStream = File.Create(outputFile);
            using var decryptor    = aes.CreateDecryptor();
            using var cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read);
            cryptoStream.CopyTo(outputStream);
        }

        public static (byte[] key, byte[] salt) DeriveKeyFromPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            var pbkdf2  = new Rfc2898DeriveBytes(password, salt, 600_000, HashAlgorithmName.SHA256);
            return (pbkdf2.GetBytes(32), salt);
        }

        public static byte[] DeriveKeyFromPassword(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 600_000, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(32);
        }
    }
}
