using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DymanicXmlNode
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("TestXml.xml");

            dynamic rootNode = xmlDoc.DocumentElement.ToDynamic();
            string stringValue = rootNode.StringNode;
            Console.WriteLine(stringValue);//StringNodeValue

            string attributeValue = rootNode.StringNode["attribute"];
            Console.WriteLine(attributeValue);//AttributeValue

            int intValue = rootNode.ParentNode.IntNode;
            Console.WriteLine(intValue);//12345

            int itemValue = rootNode.ListNode.Item[1];
            Console.WriteLine(itemValue);//2


            int xPathItemValue = rootNode("ListNode/Item")[2];
            Console.WriteLine(xPathItemValue);//3
            Console.ReadLine();

        }
    }
}
