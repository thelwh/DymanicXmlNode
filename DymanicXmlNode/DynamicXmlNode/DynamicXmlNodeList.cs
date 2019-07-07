using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DymanicXmlNode
{
    class DynamicXmlNodeList : DynamicXmlNode
    {

        public XmlNodeList NodeList { get; private set; }


        public DynamicXmlNodeList(XmlNodeList nodeList) : base(nodeList[0])
        {
            this.NodeList = nodeList;
        }

        public dynamic this[int index]
        {
            get
            {
                if (index < NodeList.Count)
                {
                    return NodeList[index].ToDynamic();
                }
                return null;
            }
        }
    }
}
