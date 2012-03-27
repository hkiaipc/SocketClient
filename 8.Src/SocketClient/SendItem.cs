using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class SendItem
    {
        #region Bytes
        /// <summary>
        /// 
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                if (_bytes == null)
                {
                }
                return _bytes;
            }
            set
            {
                _bytes = value;
            }
        } private byte[] _bytes;
        #endregion //Bytes
    }

    /// <summary>
    /// 
    /// </summary>
    public class SendCollection : System.Collections.Generic.List<SendItem>
    {
        /// <summary>
        /// 
        /// </summary>
        public int MaxCount
        {
            get { return _maxCount; }
            set
            {
                _maxCount = value;
                if (_maxCount < 1)
                {
                    _maxCount = 1;
                }
            }
        } private int _maxCount = 10;

        public new void Add(SendItem sendItem)
        {
            base.Add(sendItem);
            if (this.Count > this.MaxCount)
            {
                this.RemoveAt(0);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SendCollectionManager 
    {
        public SendCollection SendCollection
        {
            get
            {
                if (_sendCollection == null)
                {
                    _sendCollection = new SendCollection();
                    
                }
                return _sendCollection;
            }
        } private SendCollection _sendCollection;
    }
}
