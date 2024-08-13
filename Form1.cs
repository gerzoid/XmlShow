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
using static System.Net.Mime.MediaTypeNames;

namespace XMLViewer2
{
    public partial class Form1 : Form
    {
        XmlViewer xmlViewer;

        //string fileName = @"c:\1\test.xml";
        string fileName = @"c:\1\F013.xml";

        public Form1()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            xmlViewer = new XmlViewer();
            OLVColumn column = new OLVColumn();
            column.Text = "���";
            column.Width = 300;

            column.AspectGetter = xmlViewer.AspectGetterNames;
            column.ImageGetter = xmlViewer.GetImages;

            treeListView1.Columns.Add(column);

            OLVColumn column2 = new OLVColumn();
            column2.Width = 200;
            column2.AspectGetter = xmlViewer.AspectGetterValues;
            column2.Text = "��������";

            treeListView1.Columns.Add(column2);
            treeListView1.CanExpandGetter = xmlViewer.CanExpandGetter;
            treeListView1.ChildrenGetter = xmlViewer.ChildrenGetter;
            
            ResizeForm();

            treeListView1.Roots = xmlViewer.LoadXmlFile(fileName);
            treeListView1.BaseSmallImageList = imageList1;
        }


        public void ExportToExcel()
        {
            xmlViewer.Export();
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
                rtbValue.Text = (String)xmlViewer.AspectGetterValues(list.SelectedObject);
            }
        }

        public string GetFullPath(XElement element)
        {
            if (element == null) return null;
            var ancestors = element.Ancestors().Reverse().Select(e => e.Name.LocalName);
            var path = string.Join("/", ancestors.Concat(new[] { element.Name.LocalName }));
            return path;
        }


        private void �������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(fileName);

            string path = "";
            memo.AppendText(GetParentPath(((ModelXML)(treeListView1.SelectedObject)).node, ref path));

            var pathSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            // ��������� ��������� ��������� - ��� ��������
            IEnumerable<XElement> currentElements = xdoc.Elements();

            foreach (var segment in pathSegments)
            {
                currentElements = currentElements.Elements(segment);
            }



            MessageBox.Show(Convert.ToString(currentElements.Count()));

            /* var nodes = FindNodesContainingText(xdoc, "�������");
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
            // ������� �������� �������
            var root = element.Document.Root;
            if (root == null)
            {
                return element;
            }

            // ����������� �� �������� �� ����������������� ������� ��������� ��������
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
            xmlViewer.Export();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var test = xmlViewer.model.GetChildrens();

            var b = test.Cast<ModelXML>().ToList()[1];
            //b.position = 4;
            treeListView1.Expand(b);
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                treeListView1.ClearObjects();
                treeListView1.Roots = xmlViewer.LoadXmlFile(openFileDialog1.FileName);
            }

        }

        private void sssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xmlViewer.SearchNext(treeListView1);
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void findTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var model = await xmlViewer.SearchAsync(treeListView1, findTextBox.Text);
                memo.AppendText(model.node.InnerText);
                ExpandAndSelectFoundNode(model);
            }

        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                xmlViewer.SearchNext(treeListView1);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                xmlViewer.SearchNext(treeListView1);
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
            // �������� ���� ��������� ����
            var parents = GetParentNodes(foundNode);

            // ������������� ������������ ����
            foreach (var parent in parents)
            {
                treeListView1.Expand(parent);
                System.Windows.Forms.Application.DoEvents();  // ��������� ���������
            }

            // �������� � ���������� ��������� ����
            treeListView1.SelectedObject = foundNode;
            treeListView1.EnsureModelVisible(foundNode);
            treeListView1.Focus();
        }


    }
}
