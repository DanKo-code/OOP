using System.Collections;
using System.Xml;
using System.Xml.Linq;

namespace DeSerialisation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cartoon cartoon_1 = new("SpongeBob", "Anime", 15 ,"SB");

            Serializer.SerializeBinary(cartoon_1);
            Serializer.DeserializeBinary();

            Console.WriteLine();

            Serializer.SerializeJSON(cartoon_1);
            Serializer.DeserializeJSON();

            Console.WriteLine();

            Serializer.SerializeXML(cartoon_1);
            Serializer.DeserializeXML();

            Console.WriteLine();

            Serializer.SerializeSOAP(cartoon_1);
            Serializer.DeserializeSOAP();

            Cartoon cartoon_2 = new("Batman", "thriller", 150, "BM");
            Cartoon[] cartoonArr = { cartoon_1, cartoon_2 };

            Console.WriteLine("\n\n\n Сериализация массива объектов:\n");
            Serializer.SerializeBinary(cartoonArr);
            Serializer.DeserializeBinaryARR();

            Console.WriteLine();
            XPath();
            Console.WriteLine();

            var xdoc = LINQ_to_XML.CreateXML();
            LINQ_to_XML.PrintXML(xdoc);
            LINQ_to_XML.LinqXML(xdoc);

        }

        public static void XPath()
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(Serializer.path + @"out.xml");

            Console.WriteLine("Запросы к селекторам XML:\n");
            Console.WriteLine("Дочерние селекторы:");                              
            XmlNodeList childNodes = xd.SelectNodes("*");                   //выбор всех дочерних узлов текущего узла               
            foreach (XmlNode n in childNodes)
            {
                Console.WriteLine(n.OuterXml);
                
            }
               
            Console.WriteLine("\nВыбор текущего узла :");
            XmlNodeList namesNodes = xd.SelectNodes(".");                   //выбор текущего узла

            foreach (XmlNode n in namesNodes)
                Console.WriteLine(n.OuterXml);
        }

        public static class LINQ_to_XML
        {
            public static XDocument CreateXML()
            {
                XDocument people = new XDocument(new XElement("people",                  
                    new XElement("man",
                        new XAttribute("name", "Danila"),
                        new XElement("speciality", "POIT"),
                        new XElement("weight", "80kg")),
                    new XElement("man",
                        new XAttribute("name", "Nikita"),
                        new XElement("speciality", "POIBMS"),
                        new XElement("weight", "100kg"))));
                people.Save(Path.GetFullPath(Serializer.path + @"people.xml"));     
                return people;
            }


            public static void PrintXML(XDocument people)                                  
            {
                Console.WriteLine("Linq to XML:");
                foreach (XElement phoneElement in people.Element("people").Elements("man"))
                {
                    XAttribute nameAttribute = phoneElement.Attribute("name");
                    XElement companyElement = phoneElement.Element("speciality");
                    XElement priceElement = phoneElement.Element("weight");

                    if (nameAttribute != null && companyElement != null && priceElement != null)
                    {
                        Console.WriteLine($"Чел: {nameAttribute.Value}");
                        Console.WriteLine($"Спецуха: {companyElement.Value}");
                        Console.WriteLine($"Вес: {priceElement.Value}");
                    }
                    Console.WriteLine();
                }
            }


            public static void LinqXML(XDocument people)
            {
                XElement? root = people.Element("people");

                root.Add(new XElement("person",
                new XAttribute("name", "Sam"),
                new XElement("company", "JetBrains"),
                new XElement("age", 28)));

                people.Save(Serializer.path + @"people.xml");


                var items1 = from man in people.Element("people").Elements("man")        
                             where man.Element("weight").Value == "80kg"                 
                             select new Man
                             {
                                 Name = man.Attribute("name").Value,
                                 Weight = man.Element("weight").Value
                             };

                foreach (var item in items1)                                            
                    Console.WriteLine($"{item.Name} - {item.Weight}");                   
            }

            class Man
            {
                public string Name { get; set; }
                public string Weight { get; set; }
            }
        }
    }
}