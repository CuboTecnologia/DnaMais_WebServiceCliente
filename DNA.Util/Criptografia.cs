using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DNA.Util
{
    public enum EncryptionAlgorithm { Des = 1, Rc2, Rijndael, TripleDes };

    /// <summary>
    /// Disponibiliza métodos para criptografia de dados. Esta classe não pode ser herdada.
    /// </summary>
    public sealed class Cryptography
    {
        private EncryptionAlgorithm _algId;
        private EncryptTransformer transformerEnc;
        private DecryptTransformer transformerDec;
        public static readonly byte[] Key = Encoding.ASCII.GetBytes("prospecttelemarketingkey");
        public static readonly byte[] Vector = Encoding.ASCII.GetBytes("prospect");

        /// <param name="algId">Tipo de algoritmo a ser usado para a criptografia.</param>
        public Cryptography(EncryptionAlgorithm algId)
        {
            _algId = algId;
        }

        /// <summary>
        /// Retorna o dado criptografado.
        /// </summary>
        /// <param name="bytesData">Dado a ser criptografado.</param>
        /// <param name="bytesData">Chave de encriptação.</param>
        public byte[] Encrypt(byte[] bytesData, byte[] bytesKey, byte[] initVec)
        {
            transformerEnc = new EncryptTransformer(_algId);

            //Set up the stream that will hold the encrypted data.
            MemoryStream memStreamEncryptedData = new MemoryStream();

            transformerEnc.IV = initVec;
            ICryptoTransform transform = transformerEnc.GetCryptoServiceProvider(bytesKey, initVec);
            CryptoStream encStream = new CryptoStream(memStreamEncryptedData, transform, CryptoStreamMode.Write);
            try
            {
                //Encrypt the data, write it to the memory stream.
                encStream.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while writing encrypted data to the stream: \n" + ex.Message);
            }
            //Set the IV and key for the client to retrieve
            //this.key = transformerEnc.Key;
            encStream.FlushFinalBlock();
            encStream.Close();

            //Send the data back.
            return memStreamEncryptedData.ToArray();
        }

        /// <summary>
        /// Retorna o dado descriptografado.
        /// </summary>
        /// <param name="bytesData">Dado a ser descriptografado.</param>
        /// <param name="bytesData">Chave de encriptação.</param>
        public byte[] Decrypt(byte[] bytesData, byte[] bytesKey, byte[] initVec)
        {
            transformerDec = new DecryptTransformer(_algId);

            //Set up the memory stream for the decrypted data.
            MemoryStream memStreamDecryptedData = new MemoryStream();

            //Pass in the initialization vector.
            transformerDec.IV = initVec;
            ICryptoTransform transform = transformerDec.GetCryptoServiceProvider(bytesKey, initVec);
            CryptoStream decStream = new CryptoStream(memStreamDecryptedData, transform, CryptoStreamMode.Write);
            try
            {
                decStream.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while writing encrypted data to the stream: \n" + ex.Message);
            }
            decStream.FlushFinalBlock();
            decStream.Close();
            // Send the data back.
            return memStreamDecryptedData.ToArray();
        }

    }

    /******************************************************************************************/

    internal class EncryptTransformer
    {
        public EncryptTransformer()
        { }

        private EncryptionAlgorithm algorithmID;
        private byte[] initVec;
        private byte[] encKey;

        internal EncryptTransformer(EncryptionAlgorithm algId)
        {
            algorithmID = algId;
        }

        internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey, byte[] initVec)
        {
            // Pick the provider.
            switch (algorithmID)
            {
                case EncryptionAlgorithm.Des:
                    {
                        DES des = new DESCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;

                        // See if a key was provided
                        if (null == bytesKey)
                        {
                            encKey = des.Key;
                        }
                        else
                        {
                            des.Key = bytesKey;
                            encKey = des.Key;
                        }
                        // See if the client provided an initialization vector
                        if (null == initVec)
                        { // Have the algorithm create one
                            initVec = des.IV;
                        }
                        else
                        { //No, give it to the algorithm
                            des.IV = initVec;
                        }
                        return des.CreateEncryptor();
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        TripleDES des3 = new TripleDESCryptoServiceProvider();
                        des3.Mode = CipherMode.CBC;
                        // See if a key was provided
                        if (null == bytesKey)
                        {
                            encKey = des3.Key;
                        }
                        else
                        {
                            des3.Key = bytesKey;
                            encKey = des3.Key;
                        }
                        // See if the client provided an IV
                        if (null == initVec)
                        { //Yes, have the alg create one
                            initVec = des3.IV;
                        }
                        else
                        { //No, give it to the alg.
                            des3.IV = initVec;
                        }
                        return des3.CreateEncryptor();
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        RC2 rc2 = new RC2CryptoServiceProvider();
                        rc2.Mode = CipherMode.CBC;
                        // Test to see if a key was provided
                        if (null == bytesKey)
                        {
                            encKey = rc2.Key;
                        }
                        else
                        {
                            rc2.Key = bytesKey;
                            encKey = rc2.Key;
                        }
                        // See if the client provided an IV
                        if (null == initVec)
                        { //Yes, have the alg create one
                            initVec = rc2.IV;
                        }
                        else
                        { //No, give it to the alg.
                            rc2.IV = initVec;
                        }
                        return rc2.CreateEncryptor();
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijndael = new RijndaelManaged();
                        rijndael.Mode = CipherMode.CBC;
                        // Test to see if a key was provided
                        if (null == bytesKey)
                        {
                            encKey = rijndael.Key;
                        }
                        else
                        {
                            rijndael.Key = bytesKey;
                            encKey = rijndael.Key;
                        }
                        // See if the client provided an IV
                        if (null == initVec)
                        { //Yes, have the alg create one
                            initVec = rijndael.IV;
                        }
                        else
                        { //No, give it to the alg.
                            rijndael.IV = initVec;
                        }
                        return rijndael.CreateEncryptor();
                    }
                default:
                    {
                        throw new CryptographicException("Algorithm ID '" +
                            algorithmID +
                            "' not supported.");
                    }
            }
        }


        internal byte[] IV
        {
            get { return initVec; }
            set { initVec = value; }
        }
        internal byte[] Key
        {
            get { return encKey; }
        }
    }
    internal class DecryptTransformer
    {
        public DecryptTransformer()
        { }

        internal DecryptTransformer(EncryptionAlgorithm deCryptId)
        {
            algorithmID = deCryptId;
        }

        private EncryptionAlgorithm algorithmID;
        private byte[] initVec;


        internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey,
            byte[] initVec)
        {
            // Pick the provider.
            switch (algorithmID)
            {
                case EncryptionAlgorithm.Des:
                    {
                        DES des = new DESCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;
                        des.Key = bytesKey;
                        des.IV = initVec;
                        return des.CreateDecryptor();
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        TripleDES des3 = new TripleDESCryptoServiceProvider();
                        des3.Mode = CipherMode.CBC;
                        return des3.CreateDecryptor(bytesKey, initVec);
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        RC2 rc2 = new RC2CryptoServiceProvider();
                        rc2.Mode = CipherMode.CBC;
                        return rc2.CreateDecryptor(bytesKey, initVec);
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijndael = new RijndaelManaged();
                        rijndael.Mode = CipherMode.CBC;
                        return rijndael.CreateDecryptor(bytesKey, initVec);
                    }
                default:
                    {
                        throw new CryptographicException("Algorithm ID '" +
                            algorithmID +
                            "' not supported.");
                    }
            }
        } //end GetCryptoServiceProvider

        internal byte[] IV
        {
            set { initVec = value; }
        }
    }
}
