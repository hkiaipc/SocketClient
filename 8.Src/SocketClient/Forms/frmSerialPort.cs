using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SocketClient
{
    using KV = KeyValuePair<string, object>;
    using KVList = List<KeyValuePair<string, object>>;

    public partial class frmSerialPort : Form
    {

        #region frmSerialPort
        public frmSerialPort()
        {
            InitializeComponent();

            BindDataSource();
        }
        #endregion //frmSerialPort

        #region btnCancel_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion //btnCancel_Click

        #region SerialPortSettings
        /// <summary>
        /// 
        /// </summary>
        public SerialPortSettings SerialPortSettings
        {
            get
            {
                SerialPortSettings settings = new SerialPortSettings();

                settings.PortName = this.cbPortName.Text;
                settings.BaudRate = (int)this.cbBaudRate.SelectedValue;
                settings.DataBits = (int)this.cbDataBits.SelectedValue;
                settings.Parity = (Parity)this.cbParity.SelectedValue;
                settings.StopBits = (StopBits)this.cbStopBits.SelectedValue;
                return settings;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("SerialPortSettings");
                }
                this.cbPortName.Text = value.PortName;
                this.cbBaudRate.SelectedValue = value.BaudRate;
                this.cbParity.SelectedValue = value.Parity;
                this.cbDataBits.SelectedValue = value.DataBits;
                this.cbStopBits.SelectedValue = value.StopBits;
            }
        }
        #endregion //SerialPortSettings

        #region btnOK_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            SerialPortSettings settings = this.SerialPortSettings;
            try
            {
                App.Default.SerialPortManager.SerialPortSettings = settings;
                App.Default.Config.SerialPortSettings = settings;
            }
            catch (Exception ex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion //btnOK_Click

        #region frmSerialPort_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSerialPort_Load(object sender, EventArgs e)
        {
            // this.txtSerialPortName.Text = App.Default.SerialPortManager.PortName;
            // this.txtSetting.Text = App.Default.SerialPortManager.Setting;
        }
        #endregion //frmSerialPort_Load

        #region BindDataSource
        /// <summary>
        /// 
        /// </summary>
        private void BindDataSource()
        {
            BindPortNameDataSource();
            BindBaudRateDataSource();
            BindDataBitsDataSource();
            BindStopBitsDataSource();
            BindParityBitsDataSource();
        }
        #endregion //BindDataSource

        private void BindPortNameDataSource()
        {
            BindComboBoxDataSource(this.cbPortName, this.PortNameDataSource);
        }

        private KVList PortNameDataSource
        {
            get
            {
                if (_portNameDataSource == null)
                {
                    _portNameDataSource = new KVList();
                    for (int i = 1; i <= 255; i++)
                    {
                        string n = "COM" + i;
                        _portNameDataSource.Add(new KV(n, n));
                    }
                }
                return _portNameDataSource;
            }
        } private KVList _portNameDataSource;

        #region ParityDataSource
        /// <summary>
        /// 
        /// </summary>
        private KVList ParityDataSource
        {
            get
            {
                if (_parityDataSource == null)
                {
                    _parityDataSource = new KVList();
                    _parityDataSource.Add(new KV(Parity.None.ToString(), Parity.None));
                    _parityDataSource.Add(new KV(Parity.Even.ToString(), Parity.Even));
                    _parityDataSource.Add(new KV(Parity.Odd.ToString(), Parity.Odd));
                    _parityDataSource.Add(new KV(Parity.Mark.ToString(), Parity.Mark));
                    _parityDataSource.Add(new KV(Parity.Space.ToString(), Parity.Space));
                }
                return _parityDataSource;
            }
        } private KVList _parityDataSource;
        #endregion //ParityDataSource

        #region StopBitsDataSource
        /// <summary>
        /// 
        /// </summary>
        private KVList StopBitsDataSource
        {
            get
            {
                if (_stopBitsDataSource == null)
                {
                    _stopBitsDataSource = new KVList();
                    _stopBitsDataSource.Add(new KV("1", StopBits.One));
                    _stopBitsDataSource.Add(new KV("1.5", StopBits.OnePointFive));
                    _stopBitsDataSource.Add(new KV("2", StopBits.Two));
                }
                return _stopBitsDataSource;
            }
        } private KVList _stopBitsDataSource;
        #endregion //StopBitsDataSource


        #region DataBitsDataSource
        /// <summary>
        /// 
        /// </summary>
        public KVList DataBitsDataSource
        {
            get
            {
                if (_dataBitsDataSource == null)
                {
                    _dataBitsDataSource = new KVList();
                    _dataBitsDataSource.Add(new KV("5", 5));
                    _dataBitsDataSource.Add(new KV("6", 6));
                    _dataBitsDataSource.Add(new KV("7", 7));
                    _dataBitsDataSource.Add(new KV("8", 8));
                }
                return _dataBitsDataSource;
            }
        } private KVList _dataBitsDataSource;
        #endregion //DataBitsDataSource

        #region BaudRateDataSource
        /// <summary>
        /// 
        /// </summary>
        public KVList BaudRateDataSource
        {
            get
            {
                if (_baudRateDataSource == null)
                {
                    _baudRateDataSource = new KVList();
                    _baudRateDataSource.Add(new KV("1200", 1200));
                    _baudRateDataSource.Add(new KV("2400", 2400));
                    _baudRateDataSource.Add(new KV("4800", 4800));
                    _baudRateDataSource.Add(new KV("9600", 9600));
                    _baudRateDataSource.Add(new KV("19200", 19200));
                    _baudRateDataSource.Add(new KV("38400", 38400));
                    _baudRateDataSource.Add(new KV("57600", 57600));
                    _baudRateDataSource.Add(new KV("115200", 115200));
                }
                return _baudRateDataSource;
            }
        } private KVList _baudRateDataSource;
        #endregion //BaudRateDataSource


        #region BindParityBitsDataSource
        /// <summary>
        /// 
        /// </summary>
        private void BindParityBitsDataSource()
        {
            BindComboBoxDataSource(this.cbParity, this.ParityDataSource);
        }
        #endregion //BindParityBitsDataSource

        #region BindComboBoxDataSource
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="ds"></param>
        private void BindComboBoxDataSource(ComboBox cb, KVList ds)
        {
            cb.DataSource = ds;
            cb.DisplayMember = "Key";
            cb.ValueMember = "Value";
        }
        #endregion //BindComboBoxDataSource

        #region BindStopBitsDataSource
        private void BindStopBitsDataSource()
        {
            BindComboBoxDataSource(this.cbStopBits, this.StopBitsDataSource);
        }
        #endregion //BindStopBitsDataSource

        #region BindDataBitsDataSource
        private void BindDataBitsDataSource()
        {
            BindComboBoxDataSource(this.cbDataBits, DataBitsDataSource);
            this.cbDataBits.SelectedValue = 8;
        }
        #endregion //BindDataBitsDataSource

        #region BindBaudRateDataSource
        /// <summary>
        /// 
        /// </summary>
        private void BindBaudRateDataSource()
        {
            BindComboBoxDataSource(this.cbBaudRate, this.BaudRateDataSource);
            this.cbBaudRate.SelectedValue = 9600;
        }
        #endregion //BindBaudRateDataSource
    }
}
