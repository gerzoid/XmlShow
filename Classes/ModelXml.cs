using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMLViewer2.Classes
{
    public class ModelXML
    {
        public int position;
        public bool isAttribute = false;
        public XmlAttribute attribute;
        public XmlNode node;
        public IEnumerable GetChildrens()
        {
            ArrayList tags = new ArrayList();
            if (node.Attributes != null)
                foreach (XmlAttribute attr in node.Attributes)
                {
                    tags.Add(new ModelXML() { node = null, attribute = attr, isAttribute = true });
                }
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Text)
                    continue;
                position++;
                tags.Add(new ModelXML() { node = childNode, attribute = null });
            }
            return tags;
        }
    }
}
