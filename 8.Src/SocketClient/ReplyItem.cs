using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class ReplyItem
    {
        public string ReceivedPattern;
        public byte[] ReplyBytes;
        public string Name;
        public string Description;
        public bool Enabled;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Match(string s)
        {
            if (Enabled)
            {
                Regex reg = new Regex(ReceivedPattern);
                return reg.IsMatch(s);
            }
            else
            {
                return false;
            }
        }

        public bool Match(byte[] bytes)
        {
            if (bytes == null || 
                bytes.Length == 0)
            {
                return false;
            }

            string s = (string)HexStringConverter.Default.ConvertToObject(bytes);
            return Match(s);
        }

        public ReplyItem(string name, string description, bool enabled, string receivedPattern, byte[] replyBytes)
        {
            this.Name = name;
            this.Description = description;
            this.Enabled = enabled;
            this.ReceivedPattern = receivedPattern;
            this.ReplyBytes = replyBytes;
        }
    }
}
