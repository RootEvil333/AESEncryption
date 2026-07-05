# AES256 File Encryption (Educational Project)

## Overview

This project demonstrates how file encryption and decryption can be implemented in C# using AES-256 and password-based key derivation.

The objective of this repository is to help developers understand:

* AES-256 encryption fundamentals
* Initialization Vectors (IVs)
* Salt generation and storage
* Password-based key derivation
* File encryption and decryption workflows in .NET

This project is intended exclusively for educational and learning purposes.

## Features

* AES-256 file encryption
* Random IV generation using `RandomNumberGenerator`
* Password-derived encryption keys
* Salt generation and storage for key derivation
* Example program demonstrating encryption and decryption

## File Format

The encrypted file stores metadata required for decryption.

Current structure:

```text
+----------------+
| Salt (16 bytes)|
+----------------+
| IV + Ciphertext|
+----------------+
```

The salt is used to derive the encryption key from the provided password, while the IV ensures that encrypting the same data multiple times produces different ciphertexts.

## Example Usage

```csharp
var (key, salt) = AES256File.DeriveKeyFromPassword(password);

byte[] iv = RandomNumberGenerator.GetBytes(16);

AES256File.EncryptFile(
    originalFile,
    encryptedFile,
    key,
    iv
);

byte[] derivedKey =
    AES256File.DeriveKeyFromPassword(password, salt);

AES256File.DecryptFile(
    encryptedFile,
    decryptedFile,
    derivedKey
);
```

## Educational Disclaimer

**This project is NOT intended for production use.**

The implementation was created to demonstrate cryptographic concepts and should not be considered a secure, production-ready encryption solution.

The code may lack features and guarantees that are expected in real-world applications, including:

* Comprehensive security reviews
* Protection against misuse
* Secure key management practices
* Authentication and integrity verification mechanisms
* Resistance to implementation-specific attacks
* Long-term maintenance and support

If you need file encryption for a production environment, use well-established, audited cryptographic libraries and follow current security best practices.

## Learning Objectives

This project can be used to study:

* How AES-256 encryption works
* The purpose of initialization vectors (IVs)
* Why salts are required for password-based encryption
* Basic file I/O operations in C#
* Cryptographic APIs provided by .NET

## License

This project is provided for educational purposes only. Use it at your own risk.


Made with <3 by RootEvil333
