using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace DNA.Util
{
    public class SerializeAndDeserializeObjects
    {
        public static Object Deserialize(string XMLString, Object YourClassObject)
        {
            XmlSerializer oXmlSerializer = new XmlSerializer(YourClassObject.GetType());
            //The StringReader will be the stream holder for the existing XML file 

            YourClassObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
            //initially deserialized, the data is represented by an object without a defined type 

            return YourClassObject;
        }

        public static string Serialize(Object YourClassObject)
        {
            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            var xs = new XmlSerializer(YourClassObject.GetType());
            var xml = new StringWriter();
            xs.Serialize(xml, YourClassObject, xns);

            return xml.ToString();
        }
    }
}
