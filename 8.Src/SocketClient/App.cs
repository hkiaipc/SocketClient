using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SocketClient
{

    /// <summary>
    /// 
    /// </summary>
    public class App
    {

        #region Default
        /// <summary>
        /// 
        /// </summary>
        static public App Default
        {
            get
            {
                if (_default == null)
                    _default = new App();
                return _default;
            }
        } static private App _default;
        #endregion //Default

        #region SyncContext
        /// <summary>
        /// 
        /// </summary>
        public SynchronizationContext SyncContext
        {
            get { return _syncContext; }
            set { _syncContext = value; }
        } private SynchronizationContext _syncContext;
        #endregion //SyncContext

        #region MainForm
        /// <summary>
        /// 
        /// </summary>
        public frmMain MainForm
        {
            get
            {
                if (_mainForm == null)
                {
                    _mainForm = new frmMain();
                    //this.SyncContext = _mainForm.GetSyncContext();
                    this.SyncContext = System.Windows.Forms.WindowsFormsSynchronizationContext.Current;
                }
                return _mainForm;
            }
        } private frmMain _mainForm;
        #endregion //MainForm


        #region SerialPortManager
        /// <summary>
        /// 
        /// </summary>
        public SerialPortManager SerialPortManager
        {
            get
            {
                if (_serialPortManager == null)
                {
                    _serialPortManager = new SerialPortManager();
                    _serialPortManager.SerialPortSettings = Config.SerialPortSettings;
                }
                return _serialPortManager;
            }

        } private SerialPortManager _serialPortManager;
        #endregion //SerialPortManager

        #region OnReceived
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="bytes"></param>
        void OnReceived(object from, byte[] bytes)
        {
            if (this.Transmitter.Enable)
            {
                ITransmit to = this.Transmitter.GetTo(from);
                if (to != null)
                {
                    to.Write(bytes);
                }
            }
        }
        #endregion //OnReceived

        #region Transmitter
        /// <summary>
        /// 
        /// </summary>
        public Transmitter Transmitter
        {
            get
            {
                if (_transmitter == null)
                {
                    _transmitter = new Transmitter();
                    _transmitter.D1 = new SocketTransmitAdpater(this.SocketClient);
                    _transmitter.D2 = new SerialPortTransmitAdpater(this.SerialPortManager);
                }
                return _transmitter; 
            }
        } private Transmitter _transmitter;
        #endregion //Transmitter

        #region Config
        /// <summary>
        /// 
        /// </summary>
        public Config Config
        {
            get
            {
                if (_config == null)
                {
                    try
                    {
                        _config = (Config)SelfSerializer.Load(
                            typeof(Config),
                            "Config\\Config.xml");
                    }
                    catch (Exception ex)
                    {
                        NUnit.UiKit.UserMessage.DisplayFailure(ex.ToString());
                        _config = new Config();
                    }
                }
                return _config;
            }
        } private Config _config;
        #endregion //Config

        #region Save
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            FileStream stream = null;
            string filename = Application.StartupPath + "\\Config\\Config.xml";
            Config cfg = this.Config;
            try
            {
                stream = new FileStream(filename, FileMode.Create);
                //this.Save(stream);
                new XmlSerializer(typeof(Config)).Serialize(stream, cfg);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            try
            {
                ReplyManager.Save();
            }
            catch (Exception ex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
            }
        }
        #endregion //Save

        #region SocketClient
        /// <summary>
        /// 
        /// </summary>
        public SocketClient SocketClient
        {
            get
            {
                if (_socketClient == null)
                {
                    _socketClient = new SocketClient();
                }
                return _socketClient;
            }
        }private SocketClient _socketClient;
        #endregion // SocketClient


        /// <summary>
        /// 
        /// </summary>
        public ReplyManager ReplyManager 
        {
            get 
            {
                if (_replyManager == null)
                {
                    _replyManager = new ReplyManager();
                }
                return _replyManager;
            }
        } private ReplyManager _replyManager;

        #region LogManager
        /// <summary>
        /// 
        /// </summary>
        public LogManager LogManager
        {
            get
            {
                if (_logManager == null)
                {
                    _logManager = new LogManager();
                }
                return _logManager;
            }
            set
            {
                _logManager = value;
            }
        } private LogManager _logManager;
        #endregion //LogManager

    }
}
