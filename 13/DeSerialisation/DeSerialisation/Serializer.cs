using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Soap;


namespace DeSerialisation
{
    class Serializer
    {
        

        public static string path = Path.GetFullPath(@"C:\2курс, 1 сем\ООП\13\DeSerialisation\");


        public static void SerializeBinary(object obj)
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path + @"out.txt"),
                                           FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
            }
        }
        public static void DeserializeBinary()
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path + @"out.txt"),
                                           FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Cartoon DesCartoon = (Cartoon)formatter.Deserialize(fs);
                Console.WriteLine(DesCartoon.ToString());
            }
        }

        public static void DeserializeBinaryARR()
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path + @"out.txt"),
                                           FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Cartoon[] DesCartoon = (Cartoon[])formatter.Deserialize(fs);

                foreach (var item in DesCartoon)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine();
                }
            }
        }


        public static void SerializeJSON(Cartoon cartoon)
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path + @"out.json"),
                                           FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Cartoon));
                jsonFormatter.WriteObject(fs, cartoon);
            }
        }
        public static void DeserializeJSON()
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path + @"out.json"),
                                           FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Cartoon));
                Cartoon? DesCartoon = (Cartoon?)jsonFormatter.ReadObject(fs);
                Console.WriteLine(DesCartoon?.ToString());
            }
        }


        public static void SerializeXML(Cartoon obj)
        {
            using (XmlTextWriter fs = new XmlTextWriter(Path.GetFullPath(path + @"out.xml"),
                                           new System.Text.UTF8Encoding(false)))
            {
                DataContractSerializer xmlFormatter = new DataContractSerializer(typeof(Cartoon));
                xmlFormatter.WriteObject(fs, obj);
            }
        }
        public static void DeserializeXML()
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path + @"out.xml"),
                                           FileMode.OpenOrCreate))
            {
                DataContractSerializer xmlFormatter = new DataContractSerializer(typeof(Cartoon));
                Cartoon DesCartoon = (Cartoon)xmlFormatter.ReadObject(fs);

                Console.WriteLine(DesCartoon?.ToString());
            }
        }


        public static void SerializeSOAP(Cartoon obj)
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path + @"out.soap"),
                                           FileMode.OpenOrCreate))
            {
                SoapFormatter soapformatter = new SoapFormatter();
                soapformatter.Serialize(fs, obj);
            }
        }
        public static void DeserializeSOAP()
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path + @"out.soap"),
                                           FileMode.OpenOrCreate))
            {
                SoapFormatter soapformatter = new SoapFormatter();
                Cartoon DesCartoon = (Cartoon)soapformatter.Deserialize(fs);
                Console.WriteLine(DesCartoon.ToString());
            }
        }
    }
}
