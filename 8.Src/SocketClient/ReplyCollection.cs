using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class ReplyCollection : System.Collections.ObjectModel.Collection<ReplyItem>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public byte[] GetSendBytes(byte[] bs)
        {
            foreach (ReplyItem item in this)
            {
                if (item.Match(bs))
                {
                    return item.ReplyBytes;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        } private bool _enabled;

    }
}
