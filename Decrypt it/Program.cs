using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Decrypt_it
{
    class Program
    {
        static void Main(string[] args)
        {
      
            string message = "ISPG PVFM";
            int[] key = new int[4];
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            message.ToCharArray();
            StreamWriter file = File.CreateText(@"C:\Users\cwolf_000\Documents\GitHub\Decrypt it\Decrypt it\Values.txt");
            StreamReader dict = File.OpenText(@"C:\Users\cwolf_000\Documents\GitHub\Decrypt it\Decrypt it\Dictionary.txt");
            string[] posibilities = new string[20];
            int counter = 0;

            for (int a = 0; a < 10; a++)
            {
                key[0] = a;
                for (int b = 0; b < 10; b++)
                {
                    key[1] = b;
                    for (int c = 0; c < 10; c++)
                    {
                        key[2] = c;
                        for (int d = 0; d < 10; d++)
                        {
                            string decryptedMessage = "";
                            key[3] = d;
                            for (int i = 0; i < message.Length; i++)
                            {
                                if (message[i] != ' ')
                                {
                                    decryptedMessage += Decrypt(alphabet, message[i], key[i % 4]);
                                }
                                else
                                {
                                    decryptedMessage += message[i];
                                }
                                
                            }
                            string word = "";
                            file.WriteLine(decryptedMessage + " " + key[0] + ", " + key[1] + ", " + key[2] + ", " + key[3]);
                            while (word != null)
                            {
                                word = dict.ReadLine();
                                if (word != null)
                                {
                                    word.ToUpper();
                                    word.Substring(0, 4);
                                    if (word == decryptedMessage.Substring(0, 4).ToUpper())
                                    {

                                    }
                                    
                                        
                                }
                            }
                        }
                        
                    }
                    
                }
                
            }
            file.Flush();
            file.Close();
            dict.Close();
            Console.ReadLine();
            
        }

        public static char Decrypt(String charSet, char ch, int key)
        {
            if (charSet.IndexOf(ch) >= 0)
                {
                    // Get the position of the character ch in the alphabet.
                    int charNumber = charSet.IndexOf(ch);

                    // add the key to the char number (this is the Ceaser Cipher step!)
                    // the % 26 wraps around the alphabet so 'x' + 5 => 'c'
                    int decryptedCharNumber = (charNumber - key) % charSet.Length;

                    if (decryptedCharNumber < 0) {
                        decryptedCharNumber = decryptedCharNumber + 26;
                    }

                    // get the character associated with the encrypted character number in the lowercase alphabet.
                    char decryptedChar = charSet[decryptedCharNumber];

                    // stick that encrypted character on the end of the encryptedMessage.
                    return decryptedChar;
                }
                else
                {
                    // ignore it if they character is not a part of the given character set
                    return ch;
                }
        }
    }
}

