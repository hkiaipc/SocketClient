using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    public interface ITransmit
    {
        object Source { get; set; }
        void Write(byte[] bytes);
        bool CanWrite();
    }
}
