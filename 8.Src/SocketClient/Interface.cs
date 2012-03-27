using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBytesConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytest"></param>
        /// <returns></returns>
        object ConvertToObject(byte[] bytes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        byte[] ConvertToBytes(object obj);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public interface ICRCer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        byte[] Calc(byte[] bytes, int begin, int length);

        /// <summary>
        /// 
        /// </summary>
        string Name { get; }
    }

    ///// <summary>
    ///// 
    ///// </summary>
    //public interface IBytesWrapper
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="bytes"></param>
    //    /// <returns></returns>
    //    byte[] Wrap(byte[] bytes);

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="bytes"></param>
    //    /// <returns></returns>
    //    byte[] Unwrap(byte[] bytes);
    //}
}
