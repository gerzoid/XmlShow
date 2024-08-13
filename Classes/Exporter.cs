using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XMLViewer2.Models;

namespace XMLViewer2.Classes
{
    public class Exporter
    {
        Dictionary<string, int> columns = new Dictionary<string, int>();
        DataTable dataTable;
        Settings _settings;
        public Exporter(Settings settings)
        {
            _settings = settings;
        }   
        
        string GetNodename(XmlNode node)
        {
            return node.ParentNode?.Name + "/" + node.Name;
        }
        void FillDataTable(ModelXML model)
        {
            string nodeName = "";
            if (model.node != null)
            {

                if (model.node.NodeType == XmlNodeType.Element && model.node.FirstChild?.NodeType != XmlNodeType.Element)
                {
                    nodeName = GetNodename(model.node);
                    if (!columns.ContainsKey(nodeName))
                    {
                        dataTable.Columns.Add(nodeName);
                        columns.Add(nodeName, dataTable.Columns.Count - 1);
                    }
                    if (model.node.FirstChild?.NodeType != XmlNodeType.Element)
                    {
                        var t = dataTable.Rows[dataTable.Rows.Count - 1][columns[nodeName]].ToString();
                        if (t != "") dataTable.Rows.Add();
                        dataTable.Rows[dataTable.Rows.Count - 1][columns[nodeName]] = model.node.FirstChild?.InnerText;
                    }
                }
                foreach (ModelXML node in model.GetChildrens())
                {
                    FillDataTable(node);
                }
            }
        }

        public void Export(ModelXML model)
        {
            dataTable = new DataTable();
            dataTable.Rows.Add();
            FillDataTable(model);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var excel = new ExcelPackage("test1.xlsx");
            ExcelWorksheet workSheet = excel.Workbook.Worksheets.Add("Export");
            workSheet.Cells[1, 1].LoadFromDataTable(dataTable, true);

            excel.Save();
            excel.Dispose();
        }

    }
}
