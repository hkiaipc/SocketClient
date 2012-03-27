using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class ReplyManager
    {
        #region RelyCollection
        /// <summary>
        /// 
        /// </summary>
        public ReplyCollection ReplyCollection
        {
            get
            {
                if (_relyCollection == null)
                {
                    ReplyCollectionFactory f = new ReplyCollectionFactory();
                    try
                    {
                        _relyCollection = f.Create();
                    }
                    catch (Exception ex)
                    {
                        NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                        _relyCollection = new ReplyCollection();
                    }
                }
                return _relyCollection;
            }
            set
            {
                _relyCollection = value;
            }
        } private ReplyCollection _relyCollection;
        #endregion //RelyCollection

        public void Save()
        {
            ReplyCollectionFactory f = new ReplyCollectionFactory();
            f.Save(this.ReplyCollection);
        }
    }
}
