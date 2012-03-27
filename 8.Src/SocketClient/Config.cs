using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Xdgk.Common;
using System.Net;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class Config : SelfSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        public Config()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public List<string> IPAddressList
        {
            get
            {
                if (_ipAddressList == null)
                {
                    _ipAddressList = new List<string>();
                }
                return _ipAddressList;
            }
            set { _ipAddressList = value; }
        } private List<string> _ipAddressList;

        /// <summary>
        /// 
        /// </summary>
        public List<UInt16> PortList
        {
            get
            {
                if (_portList == null)
                {
                    _portList = new List<ushort>();
                }
                return _portList;
            }

            set { _portList = value; }
        } private List<UInt16> _portList;

        #region LastIPAddress
        /// <summary>
        /// 
        /// </summary>
        public string LastIPAddress
        {
            get
            {
                if (_lastIPAddress == null)
                {
                    _lastIPAddress = string.Empty;
                }
                return _lastIPAddress;
            }
            set
            {
                _lastIPAddress = value;
            }
        } private string _lastIPAddress;
        #endregion //LastIPAddress

        #region LastPort
        /// <summary>
        /// 
        /// </summary>
        public UInt16 LastPort
        {
            get
            {
                return _lastPort;
            }
            set
            {
                _lastPort = value;
            }
        } private UInt16 _lastPort;
        #endregion //LastPort


        /// <summary>
        /// 
        /// </summary>
        public DataMode LogDataMode
        {
            get { return _logDataMode; }
            set { _logDataMode = value; }
        } private DataMode _logDataMode;

        /// <summary>
        /// 
        /// </summary>
        public DataMode SendDataMode
        {
            get { return _sendDataMode; }
            set { _sendDataMode = value; }
        } private DataMode _sendDataMode;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iPAddress"></param>
        internal void MarkIPAddress(IPAddress ipAddress)
        {
            string ip = ipAddress.ToString();
            if (!this.IPAddressList.Contains(ip))
            {
                this.IPAddressList.Add(ip);
            }
            this.LastIPAddress = ip;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        internal void MarkPort(ushort port)
        {
            if (!this.PortList.Contains(port))
            {
                this.PortList.Add(port);
            }
            this.LastPort = port;
        }

        #region ListViewColumnWidths
        /// <summary>
        /// 
        /// </summary>
        public int[] ListViewColumnWidths
        {
            get
            {
                if (_listViewColumnWidths == null)
                {
                    _listViewColumnWidths = new int[0];
                }
                return _listViewColumnWidths;
            }
            set
            {
                _listViewColumnWidths = value;
            }
        } private int[] _listViewColumnWidths;
        #endregion //ListViewColumnWidths

        #region FormSize
        /// <summary>
        /// 
        /// </summary>
        public Size FormSize
        {
            get
            {
                if (_formSize == null)
                {
                    _formSize = new Size();
                }
                return _formSize;
            }
            set
            {
                _formSize = value;
            }
        } private Size _formSize;
        #endregion //FormSize

        #region Location
        /// <summary>
        /// 
        /// </summary>
        public Point Location
        {
            get
            {
                if (_location == null)
                {
                    _location = new Point();
                }
                return _location;
            }
            set
            {
                _location = value;
            }
        } private Point _location;
        #endregion //Location

        //public byte[] bytes 
        //{
        //    get { return _bytes; }
        //    set { _bytes = value; }
        //} private byte[] _bytes;



        /// <summary>
        /// 
        /// </summary>
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
            set { _sendCollection = value; }
        } private SendCollection _sendCollection;
    }
}
