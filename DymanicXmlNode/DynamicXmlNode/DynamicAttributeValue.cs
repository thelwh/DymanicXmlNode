using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace DymanicXmlNode
{
    public class DynamicAttributeValue : DynamicObject
    {
        private string value;

        public DynamicAttributeValue(string value)
        {
            this.value = value;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            result = Convert.ChangeType(value, binder.Type);
            return true;
        }

    }
}
