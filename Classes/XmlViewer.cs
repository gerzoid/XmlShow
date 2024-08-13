using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Collections;
using System.Data;
using BrightIdeasSoftware;

namespace XMLViewer2.Classes
{
    public sealed class XmlViewer
    {
        private XmlDocument xmlDoc;
        private XDocument xDoc;

        public ModelXML model;

        Searcher searcher;
        public XmlViewer()
        {
            model = new ModelXML();
            searcher = new Searcher();
        }

        public IEnumerable LoadXmlFile(string filePath)
        {
            model = new ModelXML();
            xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            model.node = xmlDoc;
            return model.GetChildrens();
        }


        public object? AspectGetterNames(object x)
        {
            if (x is ModelXML model)
            {
                if (model.isAttribute)
                {
                    return model.attribute.Name;
                }
                if (model.node is null)
                    return "null";
                return model.node?.Name;
            }
            return null;
        }
        public object? AspectGetterValues(object x)
        {
            if (x is ModelXML model)
            {
                if (model.isAttribute)
                    return model.attribute.InnerText;
                if (model?.node?.FirstChild?.NodeType != XmlNodeType.Element)
                    return model?.node?.InnerText;
            }
            return "";
        }
        public bool CanExpandGetter(object x)
        {
            if (((ModelXML)x)?.node?.FirstChild?.NodeType == XmlNodeType.Element) return true; return false;
        }
        public IEnumerable ChildrenGetter(object x)
        {
            return ((ModelXML)x).GetChildrens();
        }
        public object? GetImages(object x)
        {
            if (x is ModelXML model)
                if (model.isAttribute)
                    return 3;

            return 2;
        }

        public async Task<ModelXML?> SearchAsync(TreeListView treeListView, string searchTerm)
        {
            return await searcher.PerformSearchAsync(treeListView, searchTerm);
        }
        public void SearchNext(TreeListView treeListView)
        {
            searcher.SearchNext(treeListView);
        }

        public void Export()
        {
            Exporter exporter = new Exporter();
            exporter.Export(model);
        }

    }
}
