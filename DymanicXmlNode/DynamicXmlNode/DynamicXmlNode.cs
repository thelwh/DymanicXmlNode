using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DymanicXmlNode
{
    public class DynamicXmlNode:DynamicObject
    {
        
        public virtual XmlNode Node { get; private set; }
        //public XmlNodeList NodeList { get; private set; }

        public DynamicXmlNode(XmlNode node)
        {
            this.Node = node;
      
        }




        public dynamic this[string attribute]
        {
            get
            {
                return Node.Attributes?[attribute]?.Value;
            }
        }


        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {

            var nodeList = Node.SelectNodes(binder.Name);
            if (nodeList != null&& nodeList.Count>0)
            {
                result = new DynamicXmlNodeList(nodeList);
                return true;
            }

            //result = null;

            return base.TryGetMember(binder, out result);
        }


        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof(string))
            {
                result = Node.InnerText;
                return true;
            }
            else if (binder.Type == typeof(int))
            {
                result = Convert.ToInt32(Node.InnerText);
                return true;
            }
            else if(binder.Type == typeof(float))
            {
                result = Convert.ToSingle(Node.InnerText);
            }
            return base.TryConvert(binder, out result);
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            if ((args.Length == 1) && (args[0].GetType() == typeof(string)))
            {
                var nodeList = Node.SelectNodes((string) args[0]);

                if (nodeList != null && nodeList.Count > 0)
                {
                    result = new DynamicXmlNodeList(nodeList);
                    return true;
                }
            }
                return base.TryInvoke(binder, args, out result);
        }
    }
}
