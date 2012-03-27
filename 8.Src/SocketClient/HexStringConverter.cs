using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    /// <summary>
    /// 提供十六进制字符串到byte[]之间的转换
    /// </summary>
    public class HexStringConverter 
    {
        public readonly static HexStringConverter Default = new HexStringConverter();
        #region IBytesConverter 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] ConvertToBytes(object obj)
        {
             List<byte> listByte = new List<byte>();

            string str = obj.ToString();
            string[] items = str.Split(' ', '-', ',', '\'', '\r', '\n');
            if (items == null || items.Length == 0)
                return null;

            for (int i = 0; i < items.Length; i++)
            {
                string s = items[i].Trim ();
                if (s.Length > 0)
                {
                    listByte.Add(Convert.ToByte(items[i], 16));
                }
            }

            //return bs;
            return listByte.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public object ConvertToObject(byte[] bytes)
        {
            string s = string.Empty;
            if (bytes == null)
            {
                return string.Empty;
            }
            if (bytes.Length == 0)
                return string.Empty;

            for (int i = 0; i < bytes.Length; i++)
            {
                s += bytes[i].ToString("X2") + ((i != bytes.Length - 1) ? " " : "");
            }
            return s;
        }
        #endregion
    }
}
