using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

namespace SocketClient
{
    public class ReplyCollectionFactory
    {


        /// <summary>
        /// 
        /// </summary>
        private string FileName
        {
            get
            {
                return System.Windows.Forms.Application.StartupPath + "\\Config\\Reply.xml";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asc"></param>
        public void Save(ReplyCollection replyCollection)
        {
            Save(FileName, replyCollection);
        }

        public void Save(string file, ReplyCollection asc)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.AppendChild(doc.CreateElement("root"));
            foreach (ReplyItem item in asc)
            {
                XmlElement i = doc.CreateElement("item");

                //XmlAttribute a = doc.CreateAttribute("desc");
                //a.Value = item.Desc;
                //i.Attributes.Append(a);

                i.Attributes.Append(CreateAtt(doc, "name", item.Name));
                i.Attributes.Append(CreateAtt(doc, "description", item.Description));
                i.Attributes.Append(CreateAtt(doc, "enabled", item.Enabled.ToString()));
                i.Attributes.Append(CreateAtt(doc, "receivedPattern", item.ReceivedPattern));
                i.Attributes.Append(CreateAtt(doc, "replyBytes", 
                    HexStringConverter.Default.ConvertToObject(item.ReplyBytes).ToString()));

                root.AppendChild(i);
            }

            doc.Save(file);
        }

        XmlAttribute CreateAtt(XmlDocument doc, string n, string v)
        {
            XmlAttribute a = doc.CreateAttribute(n);
            a.Value = v;
            return a;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public ReplyItem Build(XmlElement e)
        {
            string name = e.Attributes["name"].Value;
            string desc = e.Attributes["description"].Value;
            bool enabled = bool.Parse(e.Attributes["enabled"].Value);
            string receivedPattern = e.Attributes["receivedPattern"].Value;
            byte[] bs = HexStringConverter.Default.ConvertToBytes(e.Attributes["replyBytes"].Value);

            return new ReplyItem(name, desc, enabled, receivedPattern, bs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public ReplyCollection Build(string filename)
        {
            ReplyCollection r = new ReplyCollection();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode root = doc.SelectSingleNode("root");
            foreach (XmlNode n in root.ChildNodes)
            {
                XmlElement e = n as XmlElement;
                ReplyItem item = Build(e);
                r.Add(item);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReplyCollection Create()
        {
            return Build(FileName);
        }

    }

}