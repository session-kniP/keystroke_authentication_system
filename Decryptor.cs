using System;
using System.Linq;
using System.Text;

namespace KeyboardWriting
{
    public abstract class Decryptor
    {

        public static string Decrypt(string input)
        {
            string crypt = input;
            string code = crypt.Substring(1);
            char[] encode = new char[code.Length];

            if (crypt[0] == 'l' || crypt[0] == 'L')
            {
                for (int i = 0; i < code.Length; i++)
                {
                    if (code[i] == 'l' || code[i] == 'L')
                    {
                        encode[i] = '0';
                    }
                    else if (code[i] == 'I' || code[i] == 'i')
                    {
                        encode[i] = '1';
                    }
                }
            }
            else if (crypt[0] == 'I' || crypt[0] == 'i')
            {
                for (int i = 0; i < code.Length; i++)
                {
                    if (code[i] == 'l' || code[i] == 'L')
                    {
                        encode[i] = '1';
                    }
                    else if (code[i] == 'I' || code[i] == 'i')
                    {
                        encode[i] = '0';
                    }
                }
            }
            string bitStr = new string(encode);

            var stringArray = Enumerable.Range(0, bitStr.Length / 8).Select(pos => Convert.ToByte(bitStr.Substring(pos * 8, 8), 2)).ToArray();

            string outstr = Encoding.UTF8.GetString(stringArray);

            return outstr;
        }

    }
}
