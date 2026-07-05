using System;
using System.IO;
using System.Security.Cryptography;
using AESEncryption;

namespace AESEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalFile = "file.txt";
            string encryptedFile = "file.enc";
            string decryptedFile = "file_decrypted.txt";
            string password = "MySecretPassword123!";

            File.WriteAllText(originalFile, "This is the secret content of my file!");

            var (key, salt) = AES256File.DeriveKeyFromPassword(password);
            byte[] iv = RandomNumberGenerator.GetBytes(16);

            AES256File.EncryptFile(originalFile, encryptedFile, key, iv);

            byte[] encryptedData = File.ReadAllBytes(encryptedFile);
            using (var fs = File.Create(encryptedFile))
            {
                fs.Write(salt, 0, salt.Length);
                fs.Write(encryptedData, 0, encryptedData.Length);
            }

            Console.WriteLine($"File encrypted -> {encryptedFile}");

            byte[] fullFile = File.ReadAllBytes(encryptedFile);

            byte[] savedSalt = new byte[16];
            Buffer.BlockCopy(fullFile, 0, savedSalt, 0, 16);

            byte[] ivAndCipher = new byte[fullFile.Length - 16];
            Buffer.BlockCopy(fullFile, 16, ivAndCipher, 0, ivAndCipher.Length);

            string tempFile = encryptedFile + ".tmp";
            File.WriteAllBytes(tempFile, ivAndCipher);

            byte[] derivedKey = AES256File.DeriveKeyFromPassword(password, savedSalt);
            AES256File.DecryptFile(tempFile, decryptedFile, derivedKey);
            File.Delete(tempFile);

            Console.WriteLine($"File decrypted -> {decryptedFile}");
            Console.WriteLine($"Content: {File.ReadAllText(decryptedFile)}");
        }
    }
}
