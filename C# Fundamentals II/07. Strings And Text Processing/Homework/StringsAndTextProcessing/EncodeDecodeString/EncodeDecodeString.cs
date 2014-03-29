using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeDecodeString
{
   
    class EncodeDecodeString
    {
        /*Write a program that encodes and decodes a string using given encryption key (cipher). 
         * The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation 
         * over the first letter of the string with the first of the key, the second – with the second, etc. 
         * When the last key character is reached, the next is the first.*/

        static void Main(string[] args)
        {
            string text = "This is some text that we are going to encrypt and decrypt. Enjoy!";
            Console.WriteLine(text);

            Console.WriteLine("Specify the Encryption Key:");
            string encryptionKey = Console.ReadLine();

            string encryptedText = EncryptStringUsingEncryptionKey(text, encryptionKey);
            Console.WriteLine("The encrypted text:\n{0}", encryptedText);

            string decryptedText = DecryptStringUsingEncryptionKey(encryptedText, encryptionKey);

            Console.WriteLine("The decrypted text:\n{0}", decryptedText);

        }

        public static string EncryptStringUsingEncryptionKey(string text, string encryptionKey)
        {
            int j = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(Convert.ToChar(text[i] ^ encryptionKey[j]));

                if (j == encryptionKey.Length - 1)
                {
                    j = 0;
                }
            }

            string encryptedText = sb.ToString();
            return encryptedText;
        }

        public static string DecryptStringUsingEncryptionKey(string encryptedText, string encryptionKey)
        {
            int j = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < encryptedText.Length; i++)
            {
                sb.Append(Convert.ToChar(encryptedText[i] ^ encryptionKey[j]));

                if (j == encryptionKey.Length - 1)
                {
                    j = 0;
                }
            }

            string decryptedText = sb.ToString();
            return decryptedText;
        }
    }
}
