// /*******************************************************************************
//  * Open Behavioral Health Information Technology Architecture (OBHITA.org)
//  * 
//  * Redistribution and use in source and binary forms, with or without
//  * modification, are permitted provided that the following conditions are met:
//  *     * Redistributions of source code must retain the above copyright
//  *       notice, this list of conditions and the following disclaimer.
//  *     * Redistributions in binary form must reproduce the above copyright
//  *       notice, this list of conditions and the following disclaimer in the
//  *       documentation and/or other materials provided with the distribution.
//  *     * Neither the name of the <organization> nor the
//  *       names of its contributors may be used to endorse or promote products
//  *       derived from this software without specific prior written permission.
//  * 
//  * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//  * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//  * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//  * DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
//  * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
//  * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
//  * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
//  * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//  * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//  ******************************************************************************/

#region Using Statements



#endregion

namespace Asam.Ppc.Common.Crypto
{
    #region Using Statements

    using System;
    using System.IO;
    using System.Security.Cryptography;

    #endregion

    public class AesCrypto : BaseCrypto
    {
        #region Methods

        /// <summary>
        /// Decrypts this instance.
        /// </summary>
        /// <returns>Returns the encrypted string.</returns>
        protected override string Decrypt ()
        {
            AesManaged aesManaged = null;
            string plaintext = null;

            try
            {
                var key = new Rfc2898DeriveBytes ( Key, Salt );
                var bytes = Convert.FromBase64String ( CipherText );
                using ( var memoryStream = new MemoryStream ( bytes ) )
                {
                    aesManaged = new AesManaged ();
                    aesManaged.Key = key.GetBytes ( aesManaged.KeySize / 8 );
                    aesManaged.IV = ReadByteArray ( memoryStream );
                    var decryptor = aesManaged.CreateDecryptor ( aesManaged.Key, aesManaged.IV );
                    using ( var csDecrypt = new CryptoStream ( memoryStream, decryptor, CryptoStreamMode.Read ) )
                    {
                        using ( var srDecrypt = new StreamReader ( csDecrypt ) )
                            plaintext = srDecrypt.ReadToEnd ();
                    }
                }
            }
            finally
            {
                if ( aesManaged != null )
                {
                    aesManaged.Clear ();
                }
            }

            return plaintext;
        }

        /// <summary>
        /// Encrypts this instance.
        /// </summary>
        /// <returns>Returns the decrypted string.</returns>
        protected override string Encrypt ()
        {
            string encryptedString = null;
            AesManaged aesManaged = null;

            try
            {
                var key = new Rfc2898DeriveBytes ( Key, Salt );
                aesManaged = new AesManaged ();
                aesManaged.Key = key.GetBytes ( aesManaged.KeySize / 8 );
                var encryptor = aesManaged.CreateEncryptor ( aesManaged.Key, aesManaged.IV );
                using ( var memoryStream = new MemoryStream () )
                {
                    // prepend the IV
                    memoryStream.Write ( BitConverter.GetBytes ( aesManaged.IV.Length ), 0, sizeof(int) );
                    memoryStream.Write ( aesManaged.IV, 0, aesManaged.IV.Length );
                    using ( var csEncrypt = new CryptoStream ( memoryStream, encryptor, CryptoStreamMode.Write ) )
                    {
                        using ( var swEncrypt = new StreamWriter ( csEncrypt ) )
                        {
                            swEncrypt.Write ( PlainText );
                        }
                    }

                    encryptedString = Convert.ToBase64String ( memoryStream.ToArray () );
                }
            }
            finally
            {
                if ( aesManaged != null )
                {
                    aesManaged.Clear ();
                }
            }

            return encryptedString;
        }

        #endregion
    }
}