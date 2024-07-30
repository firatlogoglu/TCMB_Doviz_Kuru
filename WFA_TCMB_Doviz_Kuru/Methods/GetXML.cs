using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace WFA_TCMB_Doviz_Kuru.Methods
{
    internal class GetXML
    {
        internal static T DeserializeXML<T>(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("XML deserialization error: " + ex.Message);
            }
        }

        public static void SerializeXML<T>(string filePath, T data)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    serializer.Serialize(writer, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred during XML Serialization: {ex.Message}");
                // You might want to throw or log the exception here
            }
        }
    }
}