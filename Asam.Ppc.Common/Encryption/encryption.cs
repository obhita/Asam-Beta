using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

// A simple, string-oriented wrapper class for encryption functions, including 
// Hashing, Symmetric Encryption, and Asymmetric Encryption.
namespace Asam.Ppc.Common.Encryption {
    /// <summary>
    /// This static class will provides encode and decode methods
    /// set the secretKey first to be the same as the key used to encrypt
    /// leave the secret key blank to use the default key
    /// </summary>
    public class Encryption {
        private const string DefaultKey = "secrectkey";
        private static string _key;

        public static string SecretKey {
            set {
                _key = string.IsNullOrEmpty(value) ? DefaultKey : value;
            }
        }

        public static string Encode(string sData) {
            try {
                // if the key is empty then use the default
                if (string.IsNullOrEmpty(_key))
                    _key = DefaultKey;

                const Symmetric.Provider p = Symmetric.Provider.TripleDes;
                var sym = new Symmetric(p) {Key = {text = _key}};
                var encryptedData = sym.Encrypt(new Data(sData));

                return encryptedData.hex;
            } catch {
                // we should just return an empty string
                return "";
            }
        }

        public static string Decode(string sData) {
            try {
                // if the key is empty then use the default
                if (string.IsNullOrEmpty(_key))
                    _key = DefaultKey;

                const Symmetric.Provider p = Symmetric.Provider.TripleDes;
                var sym = new Symmetric(p) {Key = {text = _key}};
                var encryptedData = new Data {hex = sData};
                var sym2 = new Symmetric(p) {Key = {text = sym.Key.text}};
                var decryptedData = sym2.Decrypt(encryptedData);

                return decryptedData.text;
            } catch {
                // we should just return an empty string
                return "";
            }
        }
    }

    #region "  Hash"

    /// <summary>
    /// Hash functions are fundamental to modern cryptography. These functions map binary 
    /// strings of an arbitrary length to small binary strings of a fixed length, known as 
    /// hash values. A cryptographic hash function has the property that it is computationally
    /// infeasible to find two distinct inputs that hash to the same value. Hash functions 
    /// are commonly used with digital signatures and for data integrity.
    /// </summary>
    internal class Hash {
        /// <summary>
        /// Type of hash; some are security oriented, others are fast and simple
        /// </summary>
        public enum Provider {
            /// <summary>
            /// Cyclic Redundancy Check provider, 32-bit
            /// </summary>
            Crc32,
            /// <summary>
            /// Secure Hashing Algorithm provider, SHA-1 variant, 160-bit
            /// </summary>
            Sha1,
            /// <summary>
            /// Secure Hashing Algorithm provider, SHA-2 variant, 256-bit
            /// </summary>
            Sha256,
            /// <summary>
            /// Secure Hashing Algorithm provider, SHA-2 variant, 384-bit
            /// </summary>
            Sha384,
            /// <summary>
            /// Secure Hashing Algorithm provider, SHA-2 variant, 512-bit
            /// </summary>
            Sha512,
            /// <summary>
            /// Message Digest algorithm 5, 128-bit
            /// </summary>
            Md5
        }

        private readonly HashAlgorithm _hash;

        private readonly Data _hashValue = new Data();
        //private Hash() {}

        /// <summary>
        /// Instantiate a new hash of the specified type
        /// </summary>
        public Hash(Provider p) {
            switch (p) {
                case Provider.Crc32:
                    _hash = new Crc32();
                    break;
                case Provider.Md5:
                    _hash = new MD5CryptoServiceProvider();
                    break;
                case Provider.Sha1:
                    _hash = new SHA1Managed();
                    break;
                case Provider.Sha256:
                    _hash = new SHA256Managed();
                    break;
                case Provider.Sha384:
                    _hash = new SHA384Managed();
                    break;
                case Provider.Sha512:
                    _hash = new SHA512Managed();
                    break;
            }
        }

        /// <summary>
        /// Returns the previously calculated hash
        /// </summary>
        public Data Value {
            get { return _hashValue; }
        }

        /// <summary>
        /// Calculates hash on a stream of arbitrary length
        /// </summary>
        public Data Calculate(ref Stream s) {
            _hashValue.bytes = _hash.ComputeHash(s);
            return _hashValue;
        }

        /// <summary>
        /// Calculates hash for fixed length <see cref="Data"/>
        /// </summary>
        public Data Calculate(Data d) {
            return CalculatePrivate(d.bytes);
        }

        /// <summary>
        /// Calculates hash for a string with a prefixed salt value. 
        /// A "salt" is random data prefixed to every hashed value to prevent 
        /// common dictionary attacks.
        /// </summary>
        public Data Calculate(Data d, Data salt) {
            byte[] nb = new byte[d.bytes.Length + salt.bytes.Length];
            salt.bytes.CopyTo(nb, 0);
            d.bytes.CopyTo(nb, salt.bytes.Length);
            return CalculatePrivate(nb);
        }

        /// <summary>
        /// Calculates hash for an array of bytes
        /// </summary>
        private Data CalculatePrivate(byte[] b) {
            _hashValue.bytes = _hash.ComputeHash(b);
            return _hashValue;
        }

        #region "  CRC32 HashAlgorithm"

        private class Crc32 : HashAlgorithm {
            private uint _result = 0xffffffff;

            protected override void HashCore(byte[] array, int ibStart, int cbSize) {
                for (int i = ibStart; i <= cbSize - 1; i++) {
                    uint lookup = (_result & 0xff) ^ array[i];
                    _result = (((_result & 0xffffff00) / 0x100) & 0xffffff);
                    _result = (_result ^ _crcLookup[lookup]);
                }
            }

            protected override byte[] HashFinal() {
                byte[] b = BitConverter.GetBytes(_result);
                Array.Reverse(b);
                return b;
            }

            public override void Initialize() {
                _result = 0xffffffff;
            }

            private readonly uint[] _crcLookup = {
                                                     0x0,
                                                     0x77073096,
                                                     0xee0e612c,
                                                     0x990951ba,
                                                     0x76dc419,
                                                     0x706af48f,
                                                     0xe963a535,
                                                     0x9e6495a3,
                                                     0xedb8832,
                                                     0x79dcb8a4,
                                                     0xe0d5e91e,
                                                     0x97d2d988,
                                                     0x9b64c2b,
                                                     0x7eb17cbd,
                                                     0xe7b82d07,
                                                     0x90bf1d91,
                                                     0x1db71064,
                                                     0x6ab020f2,
                                                     0xf3b97148,
                                                     0x84be41de,
                                                     0x1adad47d,
                                                     0x6ddde4eb,
                                                     0xf4d4b551,
                                                     0x83d385c7,
                                                     0x136c9856,
                                                     0x646ba8c0,
                                                     0xfd62f97a,
                                                     0x8a65c9ec,
                                                     0x14015c4f,
                                                     0x63066cd9,
                                                     0xfa0f3d63,
                                                     0x8d080df5,
                                                     0x3b6e20c8,
                                                     0x4c69105e,
                                                     0xd56041e4,
                                                     0xa2677172,
                                                     0x3c03e4d1,
                                                     0x4b04d447,
                                                     0xd20d85fd,
                                                     0xa50ab56b,
                                                     0x35b5a8fa,
                                                     0x42b2986c,
                                                     0xdbbbc9d6,
                                                     0xacbcf940,
                                                     0x32d86ce3,
                                                     0x45df5c75,
                                                     0xdcd60dcf,
                                                     0xabd13d59,
                                                     0x26d930ac,
                                                     0x51de003a,
                                                     0xc8d75180,
                                                     0xbfd06116,
                                                     0x21b4f4b5,
                                                     0x56b3c423,
                                                     0xcfba9599,
                                                     0xb8bda50f,
                                                     0x2802b89e,
                                                     0x5f058808,
                                                     0xc60cd9b2,
                                                     0xb10be924,
                                                     0x2f6f7c87,
                                                     0x58684c11,
                                                     0xc1611dab,
                                                     0xb6662d3d,
                                                     0x76dc4190,
                                                     0x1db7106,
                                                     0x98d220bc,
                                                     0xefd5102a,
                                                     0x71b18589,
                                                     0x6b6b51f,
                                                     0x9fbfe4a5,
                                                     0xe8b8d433,
                                                     0x7807c9a2,
                                                     0xf00f934,
                                                     0x9609a88e,
                                                     0xe10e9818,
                                                     0x7f6a0dbb,
                                                     0x86d3d2d,
                                                     0x91646c97,
                                                     0xe6635c01,
                                                     0x6b6b51f4,
                                                     0x1c6c6162,
                                                     0x856530d8,
                                                     0xf262004e,
                                                     0x6c0695ed,
                                                     0x1b01a57b,
                                                     0x8208f4c1,
                                                     0xf50fc457,
                                                     0x65b0d9c6,
                                                     0x12b7e950,
                                                     0x8bbeb8ea,
                                                     0xfcb9887c,
                                                     0x62dd1ddf,
                                                     0x15da2d49,
                                                     0x8cd37cf3,
                                                     0xfbd44c65,
                                                     0x4db26158,
                                                     0x3ab551ce,
                                                     0xa3bc0074,
                                                     0xd4bb30e2,
                                                     0x4adfa541,
                                                     0x3dd895d7,
                                                     0xa4d1c46d,
                                                     0xd3d6f4fb,
                                                     0x4369e96a,
                                                     0x346ed9fc,
                                                     0xad678846,
                                                     0xda60b8d0,
                                                     0x44042d73,
                                                     0x33031de5,
                                                     0xaa0a4c5f,
                                                     0xdd0d7cc9,
                                                     0x5005713c,
                                                     0x270241aa,
                                                     0xbe0b1010,
                                                     0xc90c2086,
                                                     0x5768b525,
                                                     0x206f85b3,
                                                     0xb966d409,
                                                     0xce61e49f,
                                                     0x5edef90e,
                                                     0x29d9c998,
                                                     0xb0d09822,
                                                     0xc7d7a8b4,
                                                     0x59b33d17,
                                                     0x2eb40d81,
                                                     0xb7bd5c3b,
                                                     0xc0ba6cad,
                                                     0xedb88320,
                                                     0x9abfb3b6,
                                                     0x3b6e20c,
                                                     0x74b1d29a,
                                                     0xead54739,
                                                     0x9dd277af,
                                                     0x4db2615,
                                                     0x73dc1683,
                                                     0xe3630b12,
                                                     0x94643b84,
                                                     0xd6d6a3e,
                                                     0x7a6a5aa8,
                                                     0xe40ecf0b,
                                                     0x9309ff9d,
                                                     0xa00ae27,
                                                     0x7d079eb1,
                                                     0xf00f9344,
                                                     0x8708a3d2,
                                                     0x1e01f268,
                                                     0x6906c2fe,
                                                     0xf762575d,
                                                     0x806567cb,
                                                     0x196c3671,
                                                     0x6e6b06e7,
                                                     0xfed41b76,
                                                     0x89d32be0,
                                                     0x10da7a5a,
                                                     0x67dd4acc,
                                                     0xf9b9df6f,
                                                     0x8ebeeff9,
                                                     0x17b7be43,
                                                     0x60b08ed5,
                                                     0xd6d6a3e8,
                                                     0xa1d1937e,
                                                     0x38d8c2c4,
                                                     0x4fdff252,
                                                     0xd1bb67f1,
                                                     0xa6bc5767,
                                                     0x3fb506dd,
                                                     0x48b2364b,
                                                     0xd80d2bda,
                                                     0xaf0a1b4c,
                                                     0x36034af6,
                                                     0x41047a60,
                                                     0xdf60efc3,
                                                     0xa867df55,
                                                     0x316e8eef,
                                                     0x4669be79,
                                                     0xcb61b38c,
                                                     0xbc66831a,
                                                     0x256fd2a0,
                                                     0x5268e236,
                                                     0xcc0c7795,
                                                     0xbb0b4703,
                                                     0x220216b9,
                                                     0x5505262f,
                                                     0xc5ba3bbe,
                                                     0xb2bd0b28,
                                                     0x2bb45a92,
                                                     0x5cb36a04,
                                                     0xc2d7ffa7,
                                                     0xb5d0cf31,
                                                     0x2cd99e8b,
                                                     0x5bdeae1d,
                                                     0x9b64c2b0,
                                                     0xec63f226,
                                                     0x756aa39c,
                                                     0x26d930a,
                                                     0x9c0906a9,
                                                     0xeb0e363f,
                                                     0x72076785,
                                                     0x5005713,
                                                     0x95bf4a82,
                                                     0xe2b87a14,
                                                     0x7bb12bae,
                                                     0xcb61b38,
                                                     0x92d28e9b,
                                                     0xe5d5be0d,
                                                     0x7cdcefb7,
                                                     0xbdbdf21,
                                                     0x86d3d2d4,
                                                     0xf1d4e242,
                                                     0x68ddb3f8,
                                                     0x1fda836e,
                                                     0x81be16cd,
                                                     0xf6b9265b,
                                                     0x6fb077e1,
                                                     0x18b74777,
                                                     0x88085ae6,
                                                     0xff0f6a70,
                                                     0x66063bca,
                                                     0x11010b5c,
                                                     0x8f659eff,
                                                     0xf862ae69,
                                                     0x616bffd3,
                                                     0x166ccf45,
                                                     0xa00ae278,
                                                     0xd70dd2ee,
                                                     0x4e048354,
                                                     0x3903b3c2,
                                                     0xa7672661,
                                                     0xd06016f7,
                                                     0x4969474d,
                                                     0x3e6e77db,
                                                     0xaed16a4a,
                                                     0xd9d65adc,
                                                     0x40df0b66,
                                                     0x37d83bf0,
                                                     0xa9bcae53,
                                                     0xdebb9ec5,
                                                     0x47b2cf7f,
                                                     0x30b5ffe9,
                                                     0xbdbdf21c,
                                                     0xcabac28a,
                                                     0x53b39330,
                                                     0x24b4a3a6,
                                                     0xbad03605,
                                                     0xcdd70693,
                                                     0x54de5729,
                                                     0x23d967bf,
                                                     0xb3667a2e,
                                                     0xc4614ab8,
                                                     0x5d681b02,
                                                     0x2a6f2b94,
                                                     0xb40bbe37,
                                                     0xc30c8ea1,
                                                     0x5a05df1b,
                                                     0x2d02ef8d
                                                 };

            public override byte[] Hash {
                get {
                    byte[] b = BitConverter.GetBytes(_result);
                    Array.Reverse(b);
                    return b;
                }
            }
        }

        #endregion
    }

    #endregion

    #region "  Symmetric"

    /// <summary>
    /// Symmetric encryption uses a single key to encrypt and decrypt. 
    /// Both parties (encryptor and decryptor) must share the same secret key.
    /// </summary>
    internal class Symmetric {
        private const string DefaultIntializationVector = "%1Az=-@qT";

        private const int BufferSize = 2048;

        public enum Provider {
            /// <summary>
            /// The Data Encryption Standard provider supports a 64 bit key only
            /// </summary>
            Des,
            /// <summary>
            /// The Rivest Cipher 2 provider supports keys ranging from 40 to 128 bits, default is 128 bits
            /// </summary>
            Rc2,
            /// <summary>
            /// The Rijndael (also known as AES) provider supports keys of 128, 192, or 256 bits with a default of 256 bits
            /// </summary>
            Rijndael,
            /// <summary>
            /// The TripleDES provider (also known as 3DES) supports keys of 128 or 192 bits with a default of 192 bits
            /// </summary>
            TripleDes
        }

        private Data _key;
        private Data _iv;
        private readonly SymmetricAlgorithm _crypto;

        //private Symmetric() {}

        /// <summary>
        /// Instantiates a new symmetric encryption object using the specified provider.
        /// </summary>
        public Symmetric(Provider provider, bool useDefaultInitializationVector = true) {
            switch (provider) {
                case Provider.Des:
                    _crypto = new DESCryptoServiceProvider();
                    break;
                case Provider.Rc2:
                    _crypto = new RC2CryptoServiceProvider();
                    break;
                case Provider.Rijndael:
                    _crypto = new RijndaelManaged();
                    break;
                case Provider.TripleDes:
                    _crypto = new TripleDESCryptoServiceProvider();
                    break;
            }

            //-- make sure key and IV are always set, no matter what
            Key = RandomKey();
            IntializationVector = useDefaultInitializationVector ? new Data(DefaultIntializationVector) : RandomInitializationVector();
        }

        /// <summary>
        /// Key size in bytes. We use the default key size for any given provider; if you 
        /// want to force a specific key size, set this property
        /// </summary>
        public int KeySizeBytes {
            get { return _crypto.KeySize / 8; }
            set {
                _crypto.KeySize = value * 8;
                _key.maxBytes = value;
            }
        }

        /// <summary>
        /// Key size in bits. We use the default key size for any given provider; if you 
        /// want to force a specific key size, set this property
        /// </summary>
        public int KeySizeBits {
            get { return _crypto.KeySize; }
            set {
                _crypto.KeySize = value;
                _key.maxBits = value;
            }
        }

        /// <summary>
        /// The key used to encrypt/decrypt data
        /// </summary>
        public Data Key {
            get { return _key; }
            set {
                _key = value;
                _key.maxBytes = _crypto.LegalKeySizes[0].MaxSize / 8;
                _key.minBytes = _crypto.LegalKeySizes[0].MinSize / 8;
                _key.stepBytes = _crypto.LegalKeySizes[0].SkipSize / 8;
            }
        }

        /// <summary>
        /// Using the default Cipher Block Chaining (CBC) mode, all data blocks are processed using
        /// the value derived from the previous block; the first data block has no previous data block
        /// to use, so it needs an InitializationVector to feed the first block
        /// </summary>
        public Data IntializationVector {
            get { return _iv; }
            set {
                _iv = value;
                _iv.maxBytes = _crypto.BlockSize / 8;
                _iv.minBytes = _crypto.BlockSize / 8;
            }
        }

        /// <summary>
        /// generates a random Initialization Vector, if one was not provided
        /// </summary>
        public Data RandomInitializationVector() {
            _crypto.GenerateIV();
            var d = new Data(_crypto.IV);
            return d;
        }

        /// <summary>
        /// generates a random Key, if one was not provided
        /// </summary>
        public Data RandomKey() {
            _crypto.GenerateKey();
            var d = new Data(_crypto.Key);
            return d;
        }

        /// <summary>
        /// Ensures that _crypto object has valid Key and IV
        /// prior to any attempt to encrypt/decrypt anything
        /// </summary>
        private void ValidateKeyAndIv(bool isEncrypting) {
            if (_key.isEmpty) {
                if (isEncrypting)
                    _key = RandomKey();
                else
                    throw new CryptographicException("No key was provided for the decryption operation!");
            }
            if (_iv.isEmpty) {
                if (isEncrypting)
                    _iv = RandomInitializationVector();
                else
                    throw new CryptographicException("No initialization vector was provided for the decryption operation!");
            }
            _crypto.Key = _key.bytes;
            _crypto.IV = _iv.bytes;
        }

        /// <summary>
        /// Encrypts the specified Data using provided key
        /// </summary>
        public Data Encrypt(Data d, Data dKey) {
            Key = dKey;
            return Encrypt(d);
        }

        /// <summary>
        /// Encrypts the specified Data using preset key and preset initialization vector
        /// </summary>
        public Data Encrypt(Data d) {
            MemoryStream ms = new MemoryStream();

            ValidateKeyAndIv(true);

            CryptoStream cs = new CryptoStream(ms, _crypto.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(d.bytes, 0, d.bytes.Length);
            cs.Close();
            ms.Close();

            return new Data(ms.ToArray());
        }

        /// <summary>
        /// Encrypts the stream to memory using provided key and provided initialization vector
        /// </summary>
        public Data Encrypt(Stream s, Data dKey, Data iv) {
            IntializationVector = iv;
            Key = dKey;
            return Encrypt(s);
        }

        /// <summary>
        /// Encrypts the stream to memory using specified key
        /// </summary>
        public Data Encrypt(Stream s, Data dKey) {
            Key = dKey;
            return Encrypt(s);
        }

        /// <summary>
        /// Encrypts the specified stream to memory using preset key and preset initialization vector
        /// </summary>
        public Data Encrypt(Stream s) {
            var ms = new MemoryStream();
            var b = new byte[BufferSize + 1];

            ValidateKeyAndIv(true);

            var cs = new CryptoStream(ms, _crypto.CreateEncryptor(), CryptoStreamMode.Write);
            var i = s.Read(b, 0, BufferSize);
            while (i > 0) {
                cs.Write(b, 0, i);
                i = s.Read(b, 0, BufferSize);
            }

            cs.Close();
            ms.Close();

            return new Data(ms.ToArray());
        }

        /// <summary>
        /// Decrypts the specified data using provided key and preset initialization vector
        /// </summary>
        public Data Decrypt(Data encryptedData, Data dKey) {
            Key = dKey;
            return Decrypt(encryptedData);
        }

        /// <summary>
        /// Decrypts the specified stream using provided key and preset initialization vector
        /// </summary>
        public Data Decrypt(Stream encryptedStream, Data dKey) {
            Key = dKey;
            return Decrypt(encryptedStream);
        }

        /// <summary>
        /// Decrypts the specified stream using preset key and preset initialization vector
        /// </summary>
        public Data Decrypt(Stream encryptedStream) {
            var ms = new MemoryStream();
            var b = new byte[BufferSize + 1];

            ValidateKeyAndIv(false);
            var cs = new CryptoStream(encryptedStream, _crypto.CreateDecryptor(), CryptoStreamMode.Read);

            var i = cs.Read(b, 0, BufferSize);

            while (i > 0) {
                ms.Write(b, 0, i);
                i = cs.Read(b, 0, BufferSize);
            }
            cs.Close();
            ms.Close();

            return new Data(ms.ToArray());
        }

        /// <summary>
        /// Decrypts the specified data using preset key and preset initialization vector
        /// </summary>
        public Data Decrypt(Data encryptedData) {
            var ms = new MemoryStream(encryptedData.bytes, 0, encryptedData.bytes.Length);
            var b = new byte[encryptedData.bytes.Length];

            ValidateKeyAndIv(false);
            var cs = new CryptoStream(ms, _crypto.CreateDecryptor(), CryptoStreamMode.Read);

            try {
                cs.Read(b, 0, encryptedData.bytes.Length - 1);
            } catch (CryptographicException ex) {
                throw new CryptographicException("Unable to decrypt data. The provided key may be invalid.", ex);
            } finally {
                cs.Close();
            }
            return new Data(b);
        }
    }

    #endregion

    #region "  Asymmetric"

    /// <summary>
    /// Asymmetric encryption uses a pair of keys to encrypt and decrypt.
    /// There is a "public" key which is used to encrypt. Decrypting, on the other hand, 
    /// requires both the "public" key and an additional "private" key. The advantage is 
    /// that people can send you encrypted messages without being able to decrypt them.
    /// </summary>
    /// <remarks>
    /// The only provider supported is the <see cref="RSACryptoServiceProvider"/>
    /// </remarks>
    internal class Asymmetric {
        private readonly RSACryptoServiceProvider _rsa;
        private string _keyContainerName = "Encryption.AsymmetricEncryption.DefaultContainerName";

        private readonly int _keySize = 1024;
        private const string ELEMENT_PARENT = "RSAKeyValue";
        private const string ELEMENT_MODULUS = "Modulus";
        private const string ELEMENT_EXPONENT = "Exponent";
        private const string ELEMENT_PRIME_P = "P";
        private const string ELEMENT_PRIME_Q = "Q";
        private const string ELEMENT_PRIME_EXPONENT_P = "DP";
        private const string ELEMENT_PRIME_EXPONENT_Q = "DQ";
        private const string ELEMENT_COEFFICIENT = "InverseQ";

        private const string ELEMENT_PRIVATE_EXPONENT = "D";
        //-- http://forum.java.sun.com/thread.jsp?forum=9&thread=552022&tstart=0&trange=15 
        private const string KEY_MODULUS = "PublicKey.Modulus";
        private const string KEY_EXPONENT = "PublicKey.Exponent";
        private const string KEY_PRIME_P = "PrivateKey.P";
        private const string KEY_PRIME_Q = "PrivateKey.Q";
        private const string KEY_PRIME_EXPONENT_P = "PrivateKey.DP";
        private const string KEY_PRIME_EXPONENT_Q = "PrivateKey.DQ";
        private const string KEY_COEFFICIENT = "PrivateKey.InverseQ";

        private const string KEY_PRIVATE_EXPONENT = "PrivateKey.D";

        #region "  PublicKey Class"

        /// <summary>
        /// Represents a public encryption key. Intended to be shared, it 
        /// contains only the Modulus and Exponent.
        /// </summary>
        public class PublicKey {
            public string modulus;
            public string exponent;
            public PublicKey() {}

            public PublicKey(string keyXml) {
                loadFromXml(keyXml);
            }

            /// <summary>
            /// Load public key from App.config or Web.config file
            /// </summary>
            public void loadFromConfig() {
                //Me.Modulus = Utils.GetConfigString(_KeyModulus)
                //Me.Exponent = Utils.GetConfigString(_KeyExponent)
            }

            /// <summary>
            /// Returns *.config file XML section representing this public key
            /// </summary>
            public string toConfigSection() {
                StringBuilder sb = new StringBuilder();
                var with1 = sb;
                with1.Append(Utils.writeConfigKey(Asymmetric.KEY_MODULUS, modulus));
                with1.Append(Utils.writeConfigKey(Asymmetric.KEY_EXPONENT, exponent));
                return sb.ToString();
            }

            /// <summary>
            /// Writes the *.config file representation of this public key to a file
            /// </summary>
            public void exportToConfigFile(string filePath) {
                StreamWriter sw = new StreamWriter(filePath, false);
                sw.Write(toConfigSection());
                sw.Close();
            }

            /// <summary>
            /// Loads the public key from its XML string
            /// </summary>
            public void loadFromXml(string keyXml) {
                modulus = Utils.getXmlElement(keyXml, "Modulus");
                exponent = Utils.getXmlElement(keyXml, "Exponent");
            }

            /// <summary>
            /// Converts this public key to an RSAParameters object
            /// </summary>
            public RSAParameters toParameters() {
                RSAParameters r = new RSAParameters();
                r.Modulus = Convert.FromBase64String(modulus);
                r.Exponent = Convert.FromBase64String(exponent);
                return r;
            }

            /// <summary>
            /// Converts this public key to its XML string representation
            /// </summary>
            public string toXml() {
                StringBuilder sb = new StringBuilder();
                var with2 = sb;
                with2.Append(Utils.writeXmlNode(Asymmetric.ELEMENT_PARENT));
                with2.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_MODULUS, modulus));
                with2.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_EXPONENT, exponent));
                with2.Append(Utils.writeXmlNode(Asymmetric.ELEMENT_PARENT, true));
                return sb.ToString();
            }

            /// <summary>
            /// Writes the Xml representation of this public key to a file
            /// </summary>
            public void exportToXmlFile(string filePath) {
                StreamWriter sw = new StreamWriter(filePath, false);
                sw.Write(toXml());
                sw.Close();
            }
        }

        #endregion

        #region "  PrivateKey Class"

        /// <summary>
        /// Represents a private encryption key. Not intended to be shared, as it 
        /// contains all the elements that make up the key.
        /// </summary>
        public class PrivateKey {
            public string modulus;
            public string exponent;
            public string primeP;
            public string primeQ;
            public string primeExponentP;
            public string primeExponentQ;
            public string coefficient;

            public string privateExponent;
            public PrivateKey() {}

            public PrivateKey(string keyXml) {
                loadFromXml(keyXml);
            }

            /// <summary>
            /// Load private key from App.config or Web.config file
            /// </summary>
            public void loadFromConfig() {
                //    Me.Modulus = Utils.GetConfigString(_KeyModulus)
                //    Me.Exponent = Utils.GetConfigString(_KeyExponent)
                //    Me.PrimeP = Utils.GetConfigString(_KeyPrimeP)
                //    Me.PrimeQ = Utils.GetConfigString(_KeyPrimeQ)
                //    Me.PrimeExponentP = Utils.GetConfigString(_KeyPrimeExponentP)
                //    Me.PrimeExponentQ = Utils.GetConfigString(_KeyPrimeExponentQ)
                //    Me.Coefficient = Utils.GetConfigString(_KeyCoefficient)
                //    Me.PrivateExponent = Utils.GetConfigString(_KeyPrivateExponent)
            }

            /// <summary>
            /// Converts this private key to an RSAParameters object
            /// </summary>
            public RSAParameters toParameters() {
                RSAParameters r = new RSAParameters();
                r.Modulus = Convert.FromBase64String(modulus);
                r.Exponent = Convert.FromBase64String(exponent);
                r.P = Convert.FromBase64String(primeP);
                r.Q = Convert.FromBase64String(primeQ);
                r.DP = Convert.FromBase64String(primeExponentP);
                r.DQ = Convert.FromBase64String(primeExponentQ);
                r.InverseQ = Convert.FromBase64String(coefficient);
                r.D = Convert.FromBase64String(privateExponent);
                return r;
            }

            /// <summary>
            /// Returns *.config file XML section representing this private key
            /// </summary>
            public string toConfigSection() {
                StringBuilder sb = new StringBuilder();
                var with3 = sb;
                with3.Append(Utils.writeConfigKey(Asymmetric.KEY_MODULUS, modulus));
                with3.Append(Utils.writeConfigKey(Asymmetric.KEY_EXPONENT, exponent));
                with3.Append(Utils.writeConfigKey(Asymmetric.KEY_PRIME_P, primeP));
                with3.Append(Utils.writeConfigKey(Asymmetric.KEY_PRIME_Q, primeQ));
                with3.Append(Utils.writeConfigKey(Asymmetric.KEY_PRIME_EXPONENT_P, primeExponentP));
                with3.Append(Utils.writeConfigKey(Asymmetric.KEY_PRIME_EXPONENT_Q, primeExponentQ));
                with3.Append(Utils.writeConfigKey(Asymmetric.KEY_COEFFICIENT, coefficient));
                with3.Append(Utils.writeConfigKey(Asymmetric.KEY_PRIVATE_EXPONENT, privateExponent));
                return sb.ToString();
            }

            /// <summary>
            /// Writes the *.config file representation of this private key to a file
            /// </summary>
            public void exportToConfigFile(string strFilePath) {
                StreamWriter sw = new StreamWriter(strFilePath, false);
                sw.Write(toConfigSection());
                sw.Close();
            }

            /// <summary>
            /// Loads the private key from its XML string
            /// </summary>
            public void loadFromXml(string keyXml) {
                modulus = Utils.getXmlElement(keyXml, "Modulus");
                exponent = Utils.getXmlElement(keyXml, "Exponent");
                primeP = Utils.getXmlElement(keyXml, "P");
                primeQ = Utils.getXmlElement(keyXml, "Q");
                primeExponentP = Utils.getXmlElement(keyXml, "DP");
                primeExponentQ = Utils.getXmlElement(keyXml, "DQ");
                coefficient = Utils.getXmlElement(keyXml, "InverseQ");
                privateExponent = Utils.getXmlElement(keyXml, "D");
            }

            /// <summary>
            /// Converts this private key to its XML string representation
            /// </summary>
            public string toXml() {
                StringBuilder sb = new StringBuilder();
                var with4 = sb;
                with4.Append(Utils.writeXmlNode(Asymmetric.ELEMENT_PARENT));
                with4.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_MODULUS, modulus));
                with4.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_EXPONENT, exponent));
                with4.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_PRIME_P, primeP));
                with4.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_PRIME_Q, primeQ));
                with4.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_PRIME_EXPONENT_P, primeExponentP));
                with4.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_PRIME_EXPONENT_Q, primeExponentQ));
                with4.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_COEFFICIENT, coefficient));
                with4.Append(Utils.writeXmlElement(Asymmetric.ELEMENT_PRIVATE_EXPONENT, privateExponent));
                with4.Append(Utils.writeXmlNode(Asymmetric.ELEMENT_PARENT, true));
                return sb.ToString();
            }

            /// <summary>
            /// Writes the Xml representation of this private key to a file
            /// </summary>
            public void exportToXmlFile(string filePath) {
                StreamWriter sw = new StreamWriter(filePath, false);
                sw.Write(toXml());
                sw.Close();
            }
        }

        #endregion

        /// <summary>
        /// Instantiates a new asymmetric encryption session using the default key size; 
        /// this is usally 1024 bits
        /// </summary>
        public Asymmetric() {
            _rsa = getRsaProvider();
        }

        /// <summary>
        /// Instantiates a new asymmetric encryption session using a specific key size
        /// </summary>
        public Asymmetric(int keySize) {
            _keySize = keySize;
            _rsa = getRsaProvider();
        }

        /// <summary>
        /// Sets the name of the key container used to store this key on disk; this is an 
        /// unavoidable side effect of the underlying Microsoft CryptoAPI. 
        /// </summary>
        /// <remarks>
        /// http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q322/3/71.asp&NoWebContent=1
        /// </remarks>
        public string keyContainerName {
            get { return _keyContainerName; }
            set { _keyContainerName = value; }
        }

        /// <summary>
        /// Returns the current key size, in bits
        /// </summary>
        public int keySizeBits {
            get { return _rsa.KeySize; }
        }

        /// <summary>
        /// Returns the maximum supported key size, in bits
        /// </summary>
        public int keySizeMaxBits {
            get { return _rsa.LegalKeySizes[0].MaxSize; }
        }

        /// <summary>
        /// Returns the minimum supported key size, in bits
        /// </summary>
        public int keySizeMinBits {
            get { return _rsa.LegalKeySizes[0].MinSize; }
        }

        /// <summary>
        /// Returns valid key step sizes, in bits
        /// </summary>
        public int keySizeStepBits {
            get { return _rsa.LegalKeySizes[0].SkipSize; }
        }

        /// <summary>
        /// Returns the default public key as stored in the *.config file
        /// </summary>
        public PublicKey defaultPublicKey {
            get {
                PublicKey pubkey = new PublicKey();
                pubkey.loadFromConfig();
                return pubkey;
            }
        }

        /// <summary>
        /// Returns the default private key as stored in the *.config file
        /// </summary>
        public PrivateKey defaultPrivateKey {
            get {
                PrivateKey privkey = new PrivateKey();
                privkey.loadFromConfig();
                return privkey;
            }
        }

        /// <summary>
        /// Generates a new public/private key pair as objects
        /// </summary>
        public void generateNewKeyset(ref PublicKey publicKey, ref PrivateKey privateKey) {
            string publicKeyXml = null;
            string privateKeyXml = null;
            generateNewKeyset(ref publicKeyXml, ref privateKeyXml);
            publicKey = new PublicKey(publicKeyXml);
            privateKey = new PrivateKey(privateKeyXml);
        }

        /// <summary>
        /// Generates a new public/private key pair as XML strings
        /// </summary>
        public void generateNewKeyset(ref string publicKeyXml, ref string privateKeyXml) {
            RSA rsa = RSACryptoServiceProvider.Create();
            publicKeyXml = rsa.ToXmlString(false);
            privateKeyXml = rsa.ToXmlString(true);
        }

        /// <summary>
        /// Encrypts data using the default public key
        /// </summary>
        public Data encrypt(Data d) {
            PublicKey publicKey = defaultPublicKey;
            return encrypt(d, publicKey);
        }

        /// <summary>
        /// Encrypts data using the provided public key
        /// </summary>
        public Data encrypt(Data d, PublicKey publicKey) {
            _rsa.ImportParameters(publicKey.toParameters());
            return encryptPrivate(d);
        }

        /// <summary>
        /// Encrypts data using the provided public key as XML
        /// </summary>
        public Data encrypt(Data d, string publicKeyXml) {
            //LoadKeyXml(publicKeyXML, False)
            return encryptPrivate(d);
        }

        private Data encryptPrivate(Data d) {
            try {
                return new Data(_rsa.Encrypt(d.bytes, false));
            } catch (CryptographicException ex) {
                if (ex.Message.ToLower().IndexOf("bad length") > -1)
                    throw new CryptographicException("Your data is too large; RSA encryption is designed to encrypt relatively small amounts of data. The exact byte limit depends on the key size. To encrypt more data, use symmetric encryption and then encrypt that symmetric key with asymmetric RSA encryption.", ex);
                else
                    throw;
            }
        }

        /// <summary>
        /// Decrypts data using the default private key
        /// </summary>
        public Data decrypt(Data encryptedData) {
            PrivateKey privateKey = new PrivateKey();
            privateKey.loadFromConfig();
            return decrypt(encryptedData, privateKey);
        }

        /// <summary>
        /// Decrypts data using the provided private key
        /// </summary>
        public Data decrypt(Data encryptedData, PrivateKey privateKey) {
            _rsa.ImportParameters(privateKey.toParameters());
            return decryptPrivate(encryptedData);
        }

        /// <summary>
        /// Decrypts data using the provided private key as XML
        /// </summary>
        public Data decrypt(Data encryptedData, string privateKeyXml) {
            //LoadKeyXml(PrivateKeyXML, True)
            //Return DecryptPrivate(encryptedData)
            return null;
        }

        //Private Sub LoadKeyXml(ByVal keyXml As String, ByVal isPrivate As Boolean)
        //    Try
        //        _rsa.FromXmlString(keyXml)
        //    Catch ex As Security.XmlSyntaxException
        //        Dim s As String
        //        If isPrivate Then
        //            s = "private"
        //        Else
        //            s = "public"
        //        End If
        //        Throw New Security.XmlSyntaxException( _
        //            String.Format("The provided {0} encryption key XML does not appear to be valid.", s), ex)
        //    End Try
        //End Sub

        private Data decryptPrivate(Data encryptedData) {
            return new Data(_rsa.Decrypt(encryptedData.bytes, false));
        }

        /// <summary>
        /// gets the default RSA provider using the specified key size; 
        /// note that Microsoft's CryptoAPI has an underlying file system dependency that is unavoidable
        /// </summary>
        /// <remarks>
        /// http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q322/3/71.asp&NoWebContent=1
        /// </remarks>
        private RSACryptoServiceProvider getRsaProvider() {
            RSACryptoServiceProvider rsa = null;
            CspParameters csp = null;
            try {
                csp = new CspParameters();
                csp.KeyContainerName = _keyContainerName;
                rsa = new RSACryptoServiceProvider(_keySize, csp);
                rsa.PersistKeyInCsp = false;
                RSACryptoServiceProvider.UseMachineKeyStore = true;
                return rsa;
            } catch (CryptographicException ex) {
                if (ex.Message.ToLower().IndexOf("csp for this implementation could not be acquired") > -1) {
                    //Throw New Exception("Unable to obtain Cryptographic Service Provider. " & _
                    //    "Either the permissions are incorrect on the " & _
                    //    "'C:\Documents and Settings\All Users\Application Data\Microsoft\Crypto\RSA\MachineKeys' " & _
                    //    "folder, or the current security context '" & Security.Principal.WindowsIdentity.GetCurrent.Name & "'" & _
                    //    " does not have access to this folder.", ex)
                } else
                    throw;
            } finally {
                if ((rsa != null))
                    rsa = null;
                if ((csp != null))
                    csp = null;
            }
            return null;
        }
    }

    #endregion

    #region "  Data"

    /// <summary>
    /// represents Hex, Byte, Base64, or String data to encrypt/decrypt;
    /// use the .Text property to set/get a string representation 
    /// use the .Hex property to set/get a string-based Hexadecimal representation 
    /// use the .Base64 to set/get a string-based Base64 representation 
    /// </summary>
    internal class Data {
        private byte[] _b;
        private int _maxBytes = 0;
        private int _minBytes = 0;

        private int _stepBytes = 0;

        /// <summary>
        /// Determines the default text encoding across ALL Data instances
        /// </summary>
        public static Encoding defaultEncoding = System.Text.Encoding.GetEncoding("Windows-1252");

        /// <summary>
        /// Determines the default text encoding for this Data instance
        /// </summary>
        public Encoding encoding = defaultEncoding;

        /// <summary>
        /// Creates new, empty encryption data
        /// </summary>
        public Data() {}

        /// <summary>
        /// Creates new encryption data with the specified byte array
        /// </summary>
        public Data(byte[] b) {
            _b = b;
        }

        /// <summary>
        /// Creates new encryption data with the specified string; 
        /// will be converted to byte array using default encoding
        /// </summary>
        public Data(string s) {
            text = s;
        }

        /// <summary>
        /// Creates new encryption data using the specified string and the 
        /// specified encoding to convert the string to a byte array.
        /// </summary>
        public Data(string s, Encoding encoding) {
            this.encoding = encoding;
            text = s;
        }

        /// <summary>
        /// returns true if no data is present
        /// </summary>
        public bool isEmpty {
            get {
                if (_b == null)
                    return true;
                if (_b.Length == 0)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// allowed step interval, in bytes, for this data; if 0, no limit
        /// </summary>
        public int stepBytes {
            get { return _stepBytes; }
            set { _stepBytes = value; }
        }

        /// <summary>
        /// allowed step interval, in bits, for this data; if 0, no limit
        /// </summary>
        public int stepBits {
            get { return _stepBytes * 8; }
            set { _stepBytes = value / 8; }
        }

        /// <summary>
        /// minimum number of bytes allowed for this data; if 0, no limit
        /// </summary>
        public int minBytes {
            get { return _minBytes; }
            set { _minBytes = value; }
        }

        /// <summary>
        /// minimum number of bits allowed for this data; if 0, no limit
        /// </summary>
        public int minBits {
            get { return _minBytes * 8; }
            set { _minBytes = value / 8; }
        }

        /// <summary>
        /// maximum number of bytes allowed for this data; if 0, no limit
        /// </summary>
        public int maxBytes {
            get { return _maxBytes; }
            set { _maxBytes = value; }
        }

        /// <summary>
        /// maximum number of bits allowed for this data; if 0, no limit
        /// </summary>
        public int maxBits {
            get { return _maxBytes * 8; }
            set { _maxBytes = value / 8; }
        }

        /// <summary>
        /// Returns the byte representation of the data; 
        /// This will be padded to MinBytes and trimmed to MaxBytes as necessary!
        /// </summary>
        public byte[] bytes {
            get {
                if (_maxBytes > 0) {
                    if (_b.Length > _maxBytes) {
                        byte[] b = new byte[_maxBytes];
                        Array.Copy(_b, b, b.Length);
                        _b = b;
                    }
                }
                if (_minBytes > 0) {
                    if (_b.Length < _minBytes) {
                        byte[] b = new byte[_minBytes];
                        Array.Copy(_b, b, _b.Length);
                        _b = b;
                    }
                }
                return _b;
            }
            set { _b = value; }
        }

        /// <summary>
        /// Sets or returns text representation of bytes using the default text encoding
        /// </summary>
        public string text {
            get {
                if (_b == null)
                    return "";
                else {
                    //-- need to handle nulls here; oddly, C# will happily convert
                    //-- nulls into the string whereas VB stops converting at the
                    //-- first null!
                    int i = Array.IndexOf(_b, Convert.ToByte(0));
                    if (i >= 0)
                        return encoding.GetString(_b, 0, i);
                    else
                        return encoding.GetString(_b);
                }
            }
            set { _b = encoding.GetBytes(value); }
        }

        /// <summary>
        /// Sets or returns Hex string representation of this data
        /// </summary>
        public string hex {
            get { return Utils.toHex(_b); }
            set { _b = Utils.fromHex(value); }
        }

        /// <summary>
        /// Sets or returns Base64 string representation of this data
        /// </summary>
        public string base64 {
            get { return Utils.toBase64(_b); }
            set { _b = Utils.fromBase64(value); }
        }

        /// <summary>
        /// Returns text representation of bytes using the default text encoding
        /// </summary>
        public string toString() {
            return text;
        }

        /// <summary>
        /// returns Base64 string representation of this data
        /// </summary>
        public string toBase64() {
            return base64;
        }

        /// <summary>
        /// returns Hex string representation of this data
        /// </summary>
        public string toHex() {
            return hex;
        }
    }

    #endregion

    #region "  Utils"

    /// <summary>
    /// public class for shared utility methods used by multiple Encryption classes
    /// </summary>
    internal class Utils {
        /// <summary>
        /// converts an array of bytes to a string Hex representation
        /// </summary>
        public static string toHex(byte[] ba) {
            if (ba == null || ba.Length == 0)
                return "";
            const string HEX_FORMAT = "{0:X2}";
            StringBuilder sb = new StringBuilder();
            foreach (byte b in ba) {
                sb.Append(string.Format(HEX_FORMAT, b));
            }
            return sb.ToString();
        }

        /// <summary>
        /// converts from a string Hex representation to an array of bytes
        /// </summary>
        public static byte[] fromHex(string hexEncoded) {
            if (string.IsNullOrEmpty(hexEncoded))
                return null;
            try {
                int l = Convert.ToInt32(hexEncoded.Length / 2);
                byte[] b = new byte[l];
                for (int i = 0; i <= l - 1; i++) {
                    b[i] = Convert.ToByte(hexEncoded.Substring(i * 2, 2), 16);
                }
                return b;
            } catch (Exception ex) {
                throw new FormatException("The provided string does not appear to be Hex encoded:" + Environment.NewLine + hexEncoded + Environment.NewLine, ex);
            }
        }

        /// <summary>
        /// converts from a string Base64 representation to an array of bytes
        /// </summary>
        public static byte[] fromBase64(string base64Encoded) {
            if (string.IsNullOrEmpty(base64Encoded))
                return null;
            try {
                return Convert.FromBase64String(base64Encoded);
            } catch (FormatException ex) {
                throw new FormatException("The provided string does not appear to be Base64 encoded:" + Environment.NewLine + base64Encoded + Environment.NewLine, ex);
            }
        }

        /// <summary>
        /// converts from an array of bytes to a string Base64 representation
        /// </summary>
        public static string toBase64(byte[] b) {
            if (b == null || b.Length == 0)
                return "";
            return Convert.ToBase64String(b);
        }

        /// <summary>
        /// retrieve an element from an XML string
        /// </summary>
        public static string getXmlElement(string xml, string element) {
            Match m = Regex.Match(xml, "<" + element + ">(?<Element>[^>]*)</" + element + ">", RegexOptions.IgnoreCase);
            if (m == null)
                throw new Exception("Could not find <" + element + "></" + element + "> in provided Public Key XML.");
            return m.Groups["Element"].ToString();
        }


        //public Shared Function GetConfigString(ByVal key As String, _
        //    Optional ByVal isRequired As Boolean = True) As String

        //    Dim s As String = CType(ConfigurationManager.AppSettings.Get(key), String)
        //    If s = Nothing Then
        //        If isRequired Then
        //            Throw New ConfigurationErrorsException("key <" & key & "> is missing from .config file")
        //        Else
        //            Return ""
        //        End If
        //    Else
        //        Return s
        //    End If
        //End Function

        public static string writeConfigKey(string key, string value) {
            string s = "<add key=\"{0}\" value=\"{1}\" />" + Environment.NewLine;
            return string.Format(s, key, value);
        }

        public static string writeXmlElement(string element, string value) {
            string s = "<{0}>{1}</{0}>" + Environment.NewLine;
            return string.Format(s, element, value);
        }

        public static string writeXmlNode(string element, bool isClosing = false) {
            string s;
            if (isClosing)
                s = "</{0}>" + Environment.NewLine;
            else
                s = "<{0}>" + Environment.NewLine;
            return string.Format(s, element);
        }
    }

    #endregion
}