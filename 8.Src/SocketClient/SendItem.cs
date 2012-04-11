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
        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

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
