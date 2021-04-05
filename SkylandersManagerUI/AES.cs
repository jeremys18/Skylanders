using System;
using System.Security.Cryptography;
using System.Text;

namespace SkylandersManagerUI
{
    public class AES
    {
        // Public Shared HeaderBytes() As Byte = Nothing
        // Encryption Notes
        // So for 24 block it will be-
        // <first 0x20 bytes of sector 0> <24> <0x35-byte constant>

        // <first 0x20 bytes of sector 0> <1-byte block index> <0x35-byte constant>
        // The First 20 Bytes is 32 Decimal Values
        // Why is the Middle Block 24 as Hex?
        // The Constant is: 53 Values Decimal

        // THEN, MD5 Hash the above bytes.
        // Encryption/Decryption Code

        // The Following blocks (Offsets) are NOT encrypted
        // All Offsets are in Hex and counted as such.
        // 0x000 Through 0x70
        // 0x0B0
        // 0x0F0
        // 0x130
        // 0x170
        // 0x1B0
        // 0x1F0
        // 0x230
        // 0x270
        // 0x2B0
        // 0x2F0
        // 0x330
        // 0x370
        // 0x3B0
        // 0X3F0

        static byte[] HeaderBytes = new byte[32];
        public static byte[] FullKey = new byte[86];
        static RijndaelManaged Aes = new RijndaelManaged();
        public static byte[] Magic = new byte[] { 0x20, 0x43, 0x6F, 0x70, 0x79, 0x72, 0x69, 0x67, 0x68, 0x74, 0x20, 0x28, 0x43, 0x29, 0x20, 0x32, 0x30, 0x31, 0x30, 0x20, 0x41, 0x63, 0x74, 0x69, 0x76, 0x69, 0x73, 0x69, 0x6F, 0x6E, 0x2E, 0x20, 0x41, 0x6C, 0x6C, 0x20, 0x52, 0x69, 0x67, 0x68, 0x74, 0x73, 0x20, 0x52, 0x65, 0x73, 0x65, 0x72, 0x76, 0x65, 0x64, 0x2E, 0x20 };


        // Get the Header
        static void Header()
        {
            Aes.Padding = PaddingMode.Zeros;
            Aes.Mode = CipherMode.ECB;

            var counter = 0;  // Necessary to add one to the Byte array Offset
            // Go up to 0x21 to get all 32 Bytes of Header
            do {
                HeaderBytes[counter] = WholeFile[counter];
                // HeadByteCounter += 0x1
                counter += 1;
           } while (counter != 32);
            // MessageBox.Show(BitConverter.ToString(HeaderBytes), "Head")
        }

        //todo: Get 16 Bytes read in to Byte array for Encryption/Decryption

        static void GetKey(ByVal AreaKey As Byte)
        {
            Array.Resize(FullKey, 856); // Reset and don't preserve
            HeaderBytes.CopyTo(FullKey, 0);
            // MessageBox.Show(BitConverter.ToString(FullKey), "Header into FullKey")
            FullKey[32] = AreaKey;
            // MessageBox.Show(BitConverter.ToString(FullKey), "Header and Area into FullKey")
            Magic.CopyTo(FullKey, 33);

            // FullKey now has the Correct Data.
        }

        // Encrypt
        static byte[] AESE(byte[] input, byte[] key)
        {
            var AES = new RijndaelManaged();
            AES.Padding = PaddingMode.Zeros;
            AES.Key = CalculateMD5Hash[key];
            AES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypter = AES.CreateEncryptor;
            byte[] Buffer = input;
            return DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length);
        }

        // Decrypt
        static byte[] AESD(byte[] input, byte[] key) 
        {
            var AES = new RijndaelManaged();
            AES.Padding = PaddingMode.Zeros;
            AES.Key = CalculateMD5Hash(key);
            AES.Mode = CipherMode.ECB;
            var DESDecrypter = AES.CreateDecryptor;
            var Buffer = input;
            return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length);
        }

        // Calculate MD5
        public static byte[] CalculateMD5Hash(byte[] input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(input);
            return hash;
        }

        // Return a Hex String from Byte Array.
        public static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);

            foreach (var b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        // This Generates the Bytes from the Hex String.
        public static byte[] StringToByteArray(string s)
        {
            // remove any spaces from, e.g. "A0 20 34 34"
            // s = s.Replace(" "c, "")
            // make sure we have an even number of digits
            if (s.Length == 1)
            {
                throw new FormatException("Odd string length when even string length is required.");
            }
    
            // calculate the length of the byte array and dim an array to that
            var nBytes = s.Length / 2;
            var a = new byte[nBytes - 1];

            // pick out every two bytes and convert them from hex representation
            for (var i = 0; i < nBytes; i++)
            {
                a[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
            }

            return a;
        }
    }
}
