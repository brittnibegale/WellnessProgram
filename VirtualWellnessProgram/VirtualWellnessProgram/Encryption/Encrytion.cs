using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Encryption
{
    public static class Encrytion
    {
        public static string Encrypt(string data)
        {
            try
            {
                byte[] encDataBytes = new byte[data.Length];
                encDataBytes = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encDataBytes);
                return encodedData;
            }
            catch (Exception e)
            {
              throw new Exception("Error in Encryption" + e.Message);  
            }
        }

        public static string Decrypt(string data)
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decoder = encoder.GetDecoder();
                byte[] todecodBytes = Convert.FromBase64String(data);
                int charCount = utf8Decoder.GetCharCount(todecodBytes, 0, todecodBytes.Length);
                char[] decodedChar = new char[charCount];
                utf8Decoder.GetChars(todecodBytes, 0, todecodBytes.Length, decodedChar, 0);
                string result = new string(decodedChar);
                return result;

            }
            catch (Exception e)
            {
                throw new Exception("Error in decyrtion" + e.Message);
            }
        }
    }
}