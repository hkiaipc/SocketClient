using System;
using System.Collections.Generic;
using System.Text;
using SocketRSLib;

namespace SocketRSLib
{
    public class Dispatcher
    {
        /// <summary>
        /// 
        /// </summary>
        private IDispatch _d1, _d2;

        /// <summary>
        /// 
        /// </summary>
        public Dispatcher()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        public Dispatcher(IDispatch d1, IDispatch d2)
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
        public IDispatch D2
        {
            get { return _d2; }
            set
            {
                if (this._d2 != value)
                {
                    if (_d2 != null)
                    {
                        UnregisterEvents(_d2);
                    }
                    if (value != null)
                    {
                        RegisterEvents(value );
                    }
                    _d2 = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDispatch GetToDispatch(object from)
        {
            if (D1.Source == from)
                return D2;
            if (D2.Source == from)
                return D1;

            return null;
        }

        //public IDispatch GetToDispatch( serialpor

        /// <summary>
        /// 
        /// </summary>
        public IDispatch D1
        {
            get { return _d1; }
            set
            {
                if (this._d1 != value)
                {
                    if (_d1 != null)
                    {
                        UnregisterEvents(_d1);
                    }
                    if (value != null)
                    {
                        RegisterEvents(value );
                    }
                    _d1 = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        void UnregisterEvents(IDispatch d)
        {
            //d.ReceivedEvent -= new EventHandler(d_ReceivedEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        private void RegisterEvents(IDispatch d )
        {
            //d.ReceivedEvent += new EventHandler(d_ReceivedEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void d_ReceivedEvent(object sender, EventArgs e)
        {
            IDispatch from = sender as IDispatch;
            Dispatch(from);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        void Dispatch(IDispatch from)
        {
            if (this.Enable)
            {
                IDispatch to = GetTo(from);
                if (to != null)
                {
                    //to.Write(from.ReceivedBytes);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        IDispatch GetTo(IDispatch from)
        {
            if (from == _d1)
                return _d2;
            if (from == _d2)
                return _d1;
            throw new InvalidOperationException("from");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = string.Format("{0}, ({1} <-> {2})",
                this.Enable, this.D1, this.D2 );
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.D1 = null;
            this.D2 = null;
        }
    }
}
