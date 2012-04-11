using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class LogSaver
    {
        /// <summary>
        /// 
        /// </summary>
        private LogManager _logManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logManager"></param>
        public LogSaver(LogManager logManager)
        {
            if (logManager == null)
            {
                throw new ArgumentNullException("logManager");
            }
            _logManager = logManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save(string path)
        {
            StreamWriter sw = null;
            string format = "{0}\t{1}\t{2}\t{3}\t{4}";
            
            try
            {
                sw = File.CreateText(path);
                string head = string.Format(
                    format,
                    Strings.Time,
                    Strings.From,
                    Strings.To,
                    Strings.Length,
                    Strings.DataHex);
                sw.WriteLine(head);

                foreach (LogItem li in _logManager.Items)
                {
                    string line = string.Format(
                        format,
                        li.DT.ToString("yyyy-MM-dd hh:mm:ss.fff"),
                        li.From,
                        li.TO,
                        li.Bytes.Length,
                        HexStringConverter.Default.ConvertToObject(li.Bytes)
                        );
                    sw.WriteLine(line);
                }
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
