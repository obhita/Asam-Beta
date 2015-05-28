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

namespace Asam.Ppc.Common.Crypto
{
    #region Using Statements

    using System;
    using System.Configuration;
    using System.IO;
    using System.Text;

    #endregion

    public abstract class BaseCrypto : ICrypto
    {
        #region Properties

        protected string CipherText { get; private set; }

        protected string Key { get; private set; }

        protected string PlainText { get; private set; }

        protected byte[] Salt { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public string Decrypt ( string cipherText )
        {
            return Decrypt ( new DecryptoParameter () { CipherText = cipherText } );
        }

        /// <summary>
        /// Decrypts the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public string Decrypt ( DecryptoParameter parameter )
        {
            BuildDecryptoParameters ( parameter );
            return Decrypt ();
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns></returns>
        public string Encrypt ( string plainText )
        {
            return Encrypt ( new EncryptoParameter () { PlainText = plainText } );
        }

        /// <summary>
        /// Encrypts the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public string Encrypt ( EncryptoParameter parameter )
        {
            BuildEncryptoParameters ( parameter );
            return Encrypt ();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Decrypts this instance.
        /// </summary>
        /// <returns></returns>
        protected abstract string Decrypt ();

        /// <summary>
        /// Encrypts this instance.
        /// </summary>
        /// <returns></returns>
        protected abstract string Encrypt ();

        /// <summary>
        /// Reads the byte array.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        /// <exception cref="System.SystemException">
        /// Stream did not contain properly formatted byte array
        /// or
        /// Did not read byte array properly
        /// </exception>
        protected byte[] ReadByteArray ( Stream s )
        {
            var rawLength = new byte[sizeof(int)];
            if ( s.Read ( rawLength, 0, rawLength.Length ) != rawLength.Length )
            {
                throw new SystemException ( "Stream did not contain properly formatted byte array" );
            }

            var buffer = new byte[BitConverter.ToInt32 ( rawLength, 0 )];
            if ( s.Read ( buffer, 0, buffer.Length ) != buffer.Length )
            {
                throw new SystemException ( "Did not read byte array properly" );
            }

            return buffer;
        }

        /// <summary>
        /// Builds the decrypto parameters.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <exception cref="System.Exception">Ciphertext not found.</exception>
        private void BuildDecryptoParameters ( DecryptoParameter parameter )
        {
            if ( string.IsNullOrEmpty ( parameter.CipherText ) )
            {
                throw new ArgumentException( "Ciphertext not found." );
            }

            CipherText = parameter.CipherText;
            BuildCommonParameters ( parameter );
        }

        /// <summary>
        /// Builds the encrypto parameters.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <exception cref="System.Exception">Plaintext not found.</exception>
        private void BuildEncryptoParameters ( EncryptoParameter parameter )
        {
            if ( string.IsNullOrEmpty ( parameter.PlainText ) )
            {
                throw new ArgumentException( "Plaintext not found." );
            }

            PlainText = parameter.PlainText;
            BuildCommonParameters ( parameter );
        }

        /// <summary>
        /// Builds the common parameters.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void BuildCommonParameters ( CryptoParameter parameter )
        {
            var salt = string.IsNullOrEmpty ( parameter.Salt ) ? ConfigurationManager.AppSettings["CryptoSalt"] : parameter.Salt;
            Salt = Encoding.ASCII.GetBytes ( salt );
            Key = string.IsNullOrEmpty ( parameter.Key ) ? ConfigurationManager.AppSettings["CryptoKey"] : parameter.Key;
        }

        #endregion
    }
}