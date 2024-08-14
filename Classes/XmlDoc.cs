using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using XMLViewer2.Models;

namespace XMLViewer2.Classes
{
    public class XmlDoc
    {
        XDocument doc = new XDocument();
        public XmlDoc(string path)
        {
            doc = XDocument.Load(path);
        }

        public int GetCountElement(string path)
        {
            return doc.XPathSelectElements(path).Count();
        }
        public int GetCountElementsWithValue(string path, string value)
        {
            return doc.XPathSelectElements(path).Where(d => d.Value == value).Count();
        }

        public Dictionary<string, int> GetStatisticsByPath(string path)
        {
            return doc.XPathSelectElements(path)
                    .GroupBy(d => d.Value)
                    .ToDictionary(g => g.Key, g => g
                    .Count());
        }

        public Dictionary<string, int> GetTagUsageStatistics()
        {
            Dictionary<string, int> tagStatistics = new Dictionary<string, int>();
            ProcessElement(doc.Root, "", tagStatistics);
            return tagStatistics;
        }

        private void ProcessElement(XElement element, string currentPath, Dictionary<string, int> tagStatistics)
        {         
            string elementPath = string.IsNullOrEmpty(currentPath) ? $"/{element.Name}" : $"{currentPath}/{element.Name}";         
            if (tagStatistics.ContainsKey(elementPath))
            {
                tagStatistics[elementPath]++;
            }
            else
            {
                tagStatistics[elementPath] = 1;
            }         
            foreach (XElement child in element.Elements())
            {
                ProcessElement(child, elementPath, tagStatistics);
            }
        }
    }
}
