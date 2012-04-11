using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class KeyPressHelper
    {
        internal static void Process(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            char key = e.KeyChar;

            if (char.IsDigit(key) ||
                (key >= 'a' && key <= 'f') ||
                (key >= 'A' && key <= 'F') ||
                key == (char)System.Windows.Forms.Keys.Back ||
                key == ' ')
            {

            }
            else
            {
                e.KeyChar = (char)0;
            }

        }
    }
}
