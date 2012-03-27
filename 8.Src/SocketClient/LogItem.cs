using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class LogItem
    {
        #region DT
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT
        {
            get
            {
                if (_dT == null)
                {
                    _dT = new DateTime();
                }
                return _dT;
            }
            set
            {
                _dT = value;
            }
        } private DateTime _dT;
        #endregion //DT

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
                    _bytes = new byte[0];
                }
                return _bytes;
            }
            set
            {
                _bytes = value;
            }
        } private byte[] _bytes;
        #endregion //Bytes

        #region From
        /// <summary>
        /// 
        /// </summary>
        public string From
        {
            get
            {
                if (_from == null)
                {
                    _from = string.Empty;
                }
                return _from;
            }
            set
            {
                _from = value;
            }
        } private string _from;
        #endregion //From

        #region TO
        /// <summary>
        /// 
        /// </summary>
        public string TO
        {
            get
            {
                if (_tO == null)
                {
                    _tO = string.Empty;
                }
                return _tO;
            }
            set
            {
                _tO = value;
            }
        } private string _tO;
        #endregion //TO

        #region DataDirection
        /// <summary>
        /// 
        /// </summary>
        public DataDirection DataDirection
        {
            get
            {
                return _dataDirection;
            }
            set
            {
                _dataDirection = value;
            }
        } private DataDirection _dataDirection;
        #endregion //DataDirection

    }

    /// <summary>
    /// 
    /// </summary>
    public class LogManager
    {
        /// <summary>
        /// 
        /// </summary>
        public List<LogItem> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<LogItem>();
                }
                return _items;
            }
            set { _items = value; }
        } private List<LogItem> _items;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bs"></param>
        public LogItem Add(DateTime dt, string from, string to, byte[] bs, DataDirection dataDirection)
        {
            LogItem item = new LogItem();
            item.DT = dt;
            item.From = from;
            item.TO = to;
            item.Bytes = bs;
            item.DataDirection = dataDirection;

            this.Items.Add(item);
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bs"></param>
        public LogItem Add(string from, string to, byte[] bs, DataDirection dataDirection)
        {
            return this.Add(DateTime.Now, from, to, bs,dataDirection);
        }
    }
}
