using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    public class Transmitter
    {
        /// <summary>
        /// 
        /// </summary>
        private ITransmit _d1, _d2;

        /// <summary>
        /// 
        /// </summary>
        public Transmitter()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        public Transmitter(ITransmit d1, ITransmit d2)
        {
            D1 = d1;
            D2 = d2;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        } private bool _enable = false;

        /// <summary>
        /// 
        /// </summary>
        public ITransmit D2
        {
            get { return _d2; }
            set
            {
                _d2 = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ITransmit GetTo(object from)
        {
            if (D1.Source == from)
                return D2;
            if (D2.Source == from)
                return D1;

            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        public ITransmit D1
        {
            get { return _d1; }
            set
            {
                _d1 = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanTransmit()
        {
            return this.D1.CanWrite() && this.D2.CanWrite();
        }
    }
}
