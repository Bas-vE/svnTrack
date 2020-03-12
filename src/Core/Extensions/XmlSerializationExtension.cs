using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace svnTrack.Core.Extensions
{
    public static class XmlSerializationExtension
    {
        /// <summary>
        /// Serializes an object to XML string
        /// </summary>
        /// <param name="objectInstance">The object you want to serialize to XML string</param>
        /// <returns></returns>
        public static string SerializeToXmlString(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectData"></param>
        /// <returns></returns>
        public static T DeserializeFromXmlString<T>(this string objectData)
        {
            return (T)DeserializeFromXmlString(objectData, typeof(T));
        }

        public static object DeserializeFromXmlString(this string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;
            try
            {
                using (TextReader reader = new StringReader(objectData))
                {
                    result = serializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                result = null;
            }
            return result;
        }
    }
}
