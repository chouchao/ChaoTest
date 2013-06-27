using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace TestSerialize
{
    public class XmlSerializer
    {
        public static string Serialize<T>(T item)
        {
            return Serialize(item, Encoding.UTF8);
        }

        public static string Serialize<T>(T item, Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            MemoryStream ms = new MemoryStream();
            using (XmlTextWriter textWriter = new XmlTextWriter(ms, encoding))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(textWriter, item);

                ms = textWriter.BaseStream as MemoryStream;
            }
            if (ms != null)
            {
                return encoding.GetString(ms.ToArray());
            }
            else
            {
                return null;
            }
        }

        public static T Deserialize<T>(string s)
        {
            return Deserialize<T>(s, Encoding.UTF8);
        }

        public static T Deserialize<T>(string s, Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            if (string.IsNullOrWhiteSpace(s))
            {
                return default(T);
            }

            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(s)))
            {
                using (StreamReader streamReader = new StreamReader(ms, encoding))
                {
                    System.Xml.Serialization.XmlSerializer serializer = 
                        new System.Xml.Serialization.XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(streamReader);
                }
            }
        }
    }
}
