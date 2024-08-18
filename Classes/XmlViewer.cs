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
using XMLViewer2.Models;
using System.Reflection.Metadata.Ecma335;

namespace XMLViewer2.Classes
{
    public sealed class XmlViewer
    {
        private XmlDocument xmlDoc;
        //private XDocument xDoc;

        public ModelXML model;

        Searcher _searcher;
        Exporter _exporter;
        Settings _settings;

        public bool FileOpened = false;
        public XmlViewer(Exporter exporter, Searcher searcher, Settings settings)
        {
            model = new ModelXML();
            _searcher = searcher;
            _exporter = exporter;
            _settings = settings;
        }

        public IEnumerable LoadXmlFile(string filePath)
        {
            _settings.FileIsOpened = false;

            model = new ModelXML();
            xmlDoc = new XmlDocument();                       
            
            _settings.FileName = Path.GetFileName(filePath);
            _settings.FilePath = Path.GetDirectoryName(filePath);

            xmlDoc.Load(filePath);
            model.node = xmlDoc;
            _settings.FileIsOpened = true;
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
            var model = await _searcher.PerformSearchAsync(treeListView, searchTerm);
            _settings.SearchNextEnabled = model != null;
            return model;
        }
        public async Task<ModelXML?> SearchNextAsync(TreeListView treeListView)
        {
            var model = await _searcher.SearchNextAsync(treeListView);
            _settings.SearchNextEnabled = model != null;
            return model;
        }

        public bool Export()
        {
            //Exporter exporter = new Exporter();            
            _exporter.Export(model);
            return true;
        }

    }
}
