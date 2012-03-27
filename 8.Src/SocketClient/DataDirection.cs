using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    public class DataDirection
    {
        static public DataDirection In = new DataDirection(
            //Color.Red 
            Color.FromArgb(0xff, 0xd3, 0xe5, 0xfa)
            );
        static public DataDirection Out = new DataDirection(
            Color.FromArgb(0XFF, 0xF6, 0xE7, 0xB0)
            //Color.Yellow
            );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="backgroundColor"></param>
        private DataDirection(Color backgroundColor)
        {
            //Color r = Color.FromArgb(0xff0000);
            //Color re = Color.Red;

            this.BackColor = backgroundColor;
        }

        #region BackgroundColor
        /// <summary>
        /// 
        /// </summary>
        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        } private Color _backColor;
        #endregion //BackgroundColor
    }
}
