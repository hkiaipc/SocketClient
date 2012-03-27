using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class NoneCRC : ICRCer 
    {
        static public readonly NoneCRC Instance = new NoneCRC();

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return "None"; }
        }

        #region ICRCer 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte[] Calc(byte[] bytes, int begin, int length)
        {
            return bytes;
        }
        #endregion
    }
}
