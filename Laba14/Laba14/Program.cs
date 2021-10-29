using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Laba14
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            First();
            Second();
            Third();
            Fourth();
        }

        private static void First()
        {
            var ball = new Ball("Fedya");
            
            //Binary
            Ball containerForBinary = new Ball();
            CustomSerializer.SerializeToBinary(ball);
            CustomSerializer.DeserializeFromBinary(ref containerForBinary); // почему ссылку надо передавать?
            Console.WriteLine($"(from .bin) {containerForBinary.ToString()} {containerForBinary.FieldToBeNotSeriazable}" );
            
            //SOAP
            Ball containerForSOAP = new Ball();
            CustomSerializer.SerializeToSoap(ball);
            CustomSerializer.DeserializeFromSoap(ref containerForSOAP);
            Console.WriteLine($"(from .soap) {containerForSOAP.ToString()} {containerForSOAP.FieldToBeNotSeriazable}");
            
            //XML
            Ball containerForXML = new Ball();
            CustomSerializer.SerializeToXml(ball);
            CustomSerializer.DeserializefromXml(ref containerForXML);
            Console.WriteLine($"(from .xml) {containerForXML.ToString()} {containerForBinary.FieldToBeNotSeriazable}");
            
            //JSON
            Ball containerForJSON = new Ball();
            CustomSerializer.SerializeToJson(ball);
            CustomSerializer.DeserializeFromJson(ref containerForJSON);
            Console.WriteLine($"(from .json) {containerForJSON.ToString()} {containerForJSON.FieldToBeNotSeriazable}");
        }

        private static void Second()
        {
            /*Создайте    коллекцию    (массив)    объектов    и    выполните сериализацию/десериализацию*/
            Console.ForegroundColor = ConsoleColor.Blue;
            var items = new List<Inventory>();
            var itemsFromFile = new List<Inventory>();
            
            var firstitem = new Bench("Fedya");
            var seconditem = new Mats("Fedya");
            var thirditem = new Ball("Fedya");
            
            items.Add(firstitem);
            items.Add(seconditem);
            items.Add(thirditem);

            CustomSerializer.SerializeToJson(items);
            CustomSerializer.DeserializeFromJson(ref itemsFromFile);

            foreach (var inventory in itemsFromFile)
            {
                Console.WriteLine(inventory.ToString());   
            }

        }

        private static void Third()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
            // 3. Используя XPath напишите два селектора для  вашего XML документа.
            
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba14\Laba14\XML.xml");
            var xRoot = xmlDocument.DocumentElement;
            
            var selectNodes =  xRoot.SelectNodes("*");
            foreach (object node in selectNodes) Console.WriteLine((node as XmlNode).Name);

            Console.WriteLine();
            var nameNodes = xRoot.SelectNodes("Name");
            foreach (object nameNode in nameNodes) Console.WriteLine((nameNode as XmlNode).InnerText);
        }

        private static void Fourth()
        {
            // 4.Используя LinqtoXML(или LinqtoJSON)создайте новый xml(json) -документ и напишите несколько запросов
            
            //Thanks, Tsun4mii 
            
            XDocument Children = new XDocument();               
            XElement root = new XElement("Дети");               

            XElement child;                                     
            XElement name;                                     
            XAttribute year;                                   

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Юля";
            year = new XAttribute("year", "1998");
            child.Add(name);
            child.Add(year);
            root.Add(child);

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Наташа";
            year = new XAttribute("year", "1995");
            child.Add(name);
            child.Add(year);
            root.Add(child);

            Children.Add(root);
            Children.Save(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba14\Laba14\NewXML.xml");
            
            Console.WriteLine("Inter the year for searching: ");
            string yearXML = Console.ReadLine();
            var allAlbums = root.Elements("child");

            foreach (var item in allAlbums)
            {
                if (item.Attribute("year").Value == yearXML)
                {
                    Console.WriteLine(item.Value);
                }
            }
            
        }
    }
    // TODO Создайте клиент и сервер на синхронных сокетах.Нужно сериализованные данные(объект)  отправить по сокету и десериализовать на стороне клиента
}