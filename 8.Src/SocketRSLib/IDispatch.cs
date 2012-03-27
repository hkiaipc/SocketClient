using System;
using System.Collections.Generic;
using System.Text;

namespace SocketRSLib
{
    public interface IDispatch
    {
        object Source{get;set;}
        void Write(byte[] bytes);
        //event EventHandler ReceivedEvent;
        //byte[] ReceivedBytes
        //{
        //    get;
        //}
    }
}
