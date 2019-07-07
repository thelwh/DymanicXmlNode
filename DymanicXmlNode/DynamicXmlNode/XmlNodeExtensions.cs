using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DymanicXmlNode
{
    public static class XmlNodeExtensions
    {
        public static DynamicXmlNode ToDynamic(this XmlNode node)
        {
            return new DynamicXmlNode(node);
        }
    }
}
