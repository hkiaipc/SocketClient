using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    public class PostStateObject
    {
        public PostStateObject(int id, object state)
        {
            this.ID = id;
            this.State = state;
        }

        public int ID;
        public object State;

    }
}
