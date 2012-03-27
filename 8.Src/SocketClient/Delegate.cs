using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="text"></param>
    //delegate void SetTextCallBack(string text);


    public delegate void ReceivedDelegate( object sender, byte[] bytes );
}
