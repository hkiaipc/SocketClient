using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SerialPortCommuni
{
    public partial class frmTest: Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.serialPort1.Open();
            _spc = new SerialPortCommuni(this.serialPort1);
        }
        private SerialPortCommuni _spc;

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bs = new byte[] {0x21, 0x58, 0x44, 0x00, 0xA0, 0x1E, 0x00, 0xDE, 0x97};
            _spc.Write(bs);
            Console.WriteLine("write: " + bs.Length);
        }


    
    }
}
