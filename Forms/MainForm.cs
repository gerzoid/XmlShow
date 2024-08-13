using BrightIdeasSoftware;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using XMLViewer2.Classes;
using XMLViewer2.Forms;
using XMLViewer2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace XMLViewer2
{
    public partial class MainForm : Form
    {
        XmlViewer _xmlViewer;
        Settings _settings;
        ExportToExcelSettingsForm _exportToExcelSettingsForm;
        //string fileName = @"c:\1\test.xml";
        string fileName = @"c:\1\F013.xml";


        public MainForm(Settings settings, XmlViewer viewer, ExportToExcelSettingsForm exportToExcelSettingsForm)
        {
            _settings = settings;
            _xmlViewer = viewer;
            _exportToExcelSettingsForm = exportToExcelSettingsForm;

            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //settings = SettingsSerializer.Deserialize();

            //xmlViewer = new XmlViewer();
            OLVColumn column = new OLVColumn();
            column.Text = "Тэг";
            column.Width = 300;

            column.AspectGetter = _xmlViewer.AspectGetterNames;
            column.ImageGetter = _xmlViewer.GetImages;

            treeListView1.Columns.Add(column);

            OLVColumn column2 = new OLVColumn();
            column2.Width = 200;
            column2.AspectGetter = _xmlViewer.AspectGetterValues;
            column2.Text = "Значение";

            treeListView1.Columns.Add(column2);
            treeListView1.CanExpandGetter = _xmlViewer.CanExpandGetter;
            treeListView1.ChildrenGetter = _xmlViewer.ChildrenGetter;
            
            ResizeForm();

            treeListView1.Roots =  _xmlViewer.LoadXmlFile(fileName);
            treeListView1.BaseSmallImageList = imageList1;
        }


        public void ExportToExcel()
        {
            _xmlViewer.Export();
        }

        public string GetParentPath(XmlNode node, ref string path)
        {
            if (node.ParentNode != null)
                GetParentPath(node.ParentNode, ref path);
            if (node.NodeType == XmlNodeType.Element)
                path += "/" + node.Name;

            return path;
        }
        private void treeListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (sender is TreeListView list)
            {
                rtbValue.Text = (String)_xmlViewer.AspectGetterValues(list.SelectedObject);
            }
        }

        public string GetFullPath(XElement element)
        {
            if (element == null) return null;
            var ancestors = element.Ancestors().Reverse().Select(e => e.Name.LocalName);
            var path = string.Join("/", ancestors.Concat(new[] { element.Name.LocalName }));
            return path;
        }

        private void количествоЭлементовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(fileName);

            string path = "";
            memo.AppendText(GetParentPath(((ModelXML)(treeListView1.SelectedObject)).node, ref path));

            var pathSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            // Начальное множество элементов - все элементы
            IEnumerable<XElement> currentElements = xdoc.Elements();

            foreach (var segment in pathSegments)
            {
                currentElements = currentElements.Elements(segment);
            }



            MessageBox.Show(Convert.ToString(currentElements.Count()));

            /* var nodes = FindNodesContainingText(xdoc, "Виталий");
            //((ModelXML)treeListView1.SelectedObject).node.Name;
            foreach (var node in nodes)
            {
                richTextBox1.AppendText(node.ToString());
            }*/

        }

        public IQueryable<XElement> FindNodesContainingText(XDocument document, string searchText)
        {
            var nodes = document.Descendants()
                                .Where(x => x.Value.Contains(searchText))
                                .Select(x => GetTopParentUnderRoot(x));

            return nodes.AsQueryable();
        }

        public XElement GetTopParentUnderRoot(XElement element)
        {
            // Находим корневой элемент
            var root = element.Document.Root;
            if (root == null)
            {
                return element;
            }

            // Поднимаемся по иерархии до непосредственного потомка корневого элемента
            XElement parent = element;
            while (parent.Parent != null && parent.Parent != root)
            {
                parent = parent.Parent;
            }
            return parent;
        }
        private void treeListView1_ContextMenuStripChanged(object sender, EventArgs e)
        {
            Console.WriteLine("as");
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void ResizeForm()
        {
            splitContainer2.Width = this.Width;
            splitContainer2.Height = this.Height;
            buttonFindNext.Top = findTextBox.Top;
            buttonFindNext.Left = (findTextBox.Width) - buttonFindNext.Width;
            treeListView1.Height = splitContainer1.Panel1.Height - findTextBox.Height - 5;
            splitContainer2.Height = this.Height - 10;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Exporter exporter = new Exporter();
            _xmlViewer.Export();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //ExportToExcelSettingsForm exportToExcelSettingsForm = new ExportToExcelSettingsForm();
            _exportToExcelSettingsForm.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                treeListView1.ClearObjects();
                treeListView1.Roots = _xmlViewer.LoadXmlFile(openFileDialog1.FileName);
            }

        }

        private void sssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _xmlViewer.SearchNext(treeListView1);
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void findTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var model = await _xmlViewer.SearchAsync(treeListView1, findTextBox.Text);
                memo.AppendText(model.node.InnerText);
                ExpandAndSelectFoundNode(model);
            }

        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                _xmlViewer.SearchNext(treeListView1);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                _xmlViewer.SearchNext(treeListView1);
            }
        }

        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ResizeForm();

        }
        private List<object> GetParentNodes(object node)
        {
            var parents = new List<object>();
            var current = node;

            while (current != null)
            {
                current = treeListView1.GetParent(current);
                if (current != null)
                {
                    parents.Add(current);
                }
            }

            parents.Reverse();
            return parents;
        }
        private void ExpandAndSelectFoundNode(ModelXML foundNode)
        {
            // Получаем всех родителей узла
            var parents = GetParentNodes(foundNode);

            // Разворачиваем родительские узлы
            foreach (var parent in parents)
            {
                treeListView1.Expand(parent);
                System.Windows.Forms.Application.DoEvents();  // Обновляем интерфейс
            }

            // Выделяем и фокусируем найденный узел
            treeListView1.SelectedObject = foundNode;
            treeListView1.EnsureModelVisible(foundNode);
            treeListView1.Focus();
        }


    }
}
