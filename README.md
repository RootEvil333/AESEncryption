# AES-256 File Encryption (Educational Project)

> A C# demonstration of file encryption and decryption using AES-256 and password-based key derivation.

---

## Overview

This project shows how AES-256 encryption and decryption can be implemented in C#. It's meant to help developers understand:

- AES-256 encryption fundamentals
- Initialization Vectors (IVs)
- Salt generation and storage
- Password-based key derivation
- File encryption/decryption workflows in .NET

> **Note:** This project is intended **exclusively** for educational and learning purposes.

---

## Features

- ✅ AES-256 file encryption
- ✅ Random IV generation via `RandomNumberGenerator`
- ✅ Password-derived encryption keys
- ✅ Salt generation and storage for key derivation
- ✅ Example program demonstrating encryption and decryption

---

## File Format

The encrypted file stores the metadata required for decryption:

```
+------------------+
|  Salt (16 bytes) |
+------------------+
|  IV + Ciphertext |
+------------------+
```

- **Salt** — used to derive the encryption key from the provided password
- **IV** — ensures that encrypting the same data multiple times produces different ciphertexts

---

## Learning Objectives

Use this project to study:

- How AES-256 encryption works
- The purpose of initialization vectors (IVs)
- Why salts are required for password-based encryption
- Basic file I/O operations in C#
- Cryptographic APIs provided by .NET

---

## ⚠️ Educational Disclaimer

**This project is NOT intended for production use.**

It was built to demonstrate cryptographic concepts, not to serve as a secure, production-ready encryption solution. It may lack:

- Comprehensive security reviews
- Protection against misuse
- Secure key management practices
- Authentication and integrity verification mechanisms
- Resistance to implementation-specific attacks
- Long-term maintenance and support

If you need file encryption for a production environment, use well-established, audited cryptographic libraries and follow current security best practices.

---

## License

Provided for educational purposes only. Use it at your own risk.

---

<div align="center">

Made with ❤️ by **RootEvil333**

</div>
