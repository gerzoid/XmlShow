﻿using OfficeOpenXml;
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
        Dictionary<string, int> columns;
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
                    if (nodeName != null)
                    {
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
            columns = new Dictionary<string, int>();
            dataTable.Rows.Add();
            _settings.CurrentOperation = "Составляем список колонок";

            FillDataTable(model);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string file = _settings.FilePath + "\\" + Path.GetRandomFileName() + ".xlsx";
            var excel = new ExcelPackage(file);
            ExcelWorksheet workSheet = excel.Workbook.Worksheets.Add("Export");
            
            _settings.CurrentOperation = "Вставка данных в Excel файл";            

            workSheet.Cells[1, 1].LoadFromDataTable(dataTable, true);

            _settings.CurrentOperation = $"Сохраняем файл {file}";
            excel.Save();
            _settings.CurrentOperation = "Готов";
            excel.Dispose();
        }

    }
}
