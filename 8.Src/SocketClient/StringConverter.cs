using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{

    public class StringConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        static public string HexToUTF8(string hexString)
        {
            byte[] bs = HexStringConverter.Default.ConvertToBytes(hexString);
            //string s = ASCIIEncoding.UTF8.GetString(bs);
            string s = ASCIIEncoding.Default.GetString(bs);
            return s; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="utf8String"></param>
        /// <returns></returns>
        static public string UTF8ToHex( string utf8String )
        {
            //byte[] bs = UTF8Encoding.UTF8.GetBytes ( utf8String );
            byte[] bs = UTF8Encoding.Default.GetBytes(utf8String);
            string s = (string)HexStringConverter.Default.ConvertToObject(bs);
            return s;
        }
    }
}
