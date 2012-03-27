using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SocketRSLib
{
    public class SocketRSCollection : CollectionBase 
    {
        public SocketRSCollection()
        {

        }

        public void Add(ISocketRS val)
        {
            this.List.Add(val);
        }

        public void Remove(ISocketRS val)
        {
            this.List.Remove(val);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            foreach (object obj in this.List)
            {
                ISocketRS val = obj as ISocketRS;
                //val.Close();
            }
        }

        public ISocketRS this[int index]
        {
            get { return (ISocketRS)this.List[index]; }
        }

    }
}
