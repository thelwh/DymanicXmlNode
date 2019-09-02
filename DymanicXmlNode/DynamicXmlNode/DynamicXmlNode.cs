using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DymanicXmlNode
{
    public class DynamicXmlNode : DynamicObject
    {

        public virtual XmlNode Node { get; private set; }

        public DynamicXmlNode(XmlNode node)
        {
            this.Node = node;

        }

        public dynamic this[string attribute]
        {
            get
            {
                return new DynamicAttributeValue(Node.Attributes?[attribute]?.Value);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {

            var nodeList = Node.SelectNodes(binder.Name);
            if (nodeList != null && nodeList.Count > 0)
            {
                result = new DynamicXmlNodeList(nodeList);
                return true;
            }

            return base.TryGetMember(binder, out result);
        }


        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof(XmlNode))
            {
                result = Node;
                return true;
            }

            result = Convert.ChangeType(Node.InnerText, binder.Type);
            return true;
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            if ((args.Length == 1) && (args[0] is string))
            {
                var nodeList = Node.SelectNodes((string)args[0]);

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
