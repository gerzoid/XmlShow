using BrightIdeasSoftware;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using XMLViewer2.Classes;
using XMLViewer2.Forms;
using XMLViewer2.Models;
using static OfficeOpenXml.ExcelErrorValue;

namespace XMLViewer2
{
    public partial class MainForm : Form
    {
        XmlViewer _xmlViewer;
        Settings _settings;
        Lazy<XmlDoc> _xDocument;

        ExportToExcelSettingsForm _exportToExcelSettingsForm;

        public MainForm(Settings settings, XmlViewer viewer, ExportToExcelSettingsForm exportToExcelSettingsForm, Lazy<XmlDoc> document)
        {
            _settings = settings;
            _xmlViewer = viewer;
            _exportToExcelSettingsForm = exportToExcelSettingsForm;
            _xDocument = document;

            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            SetupTreeView();
            SetupDataBindings();

            ResizeForm();
        }

        public void CheckMenuEnabled()
        {

        }

        public void SetupTreeView()
        {
            OLVColumn column = new OLVColumn();
            column.Text = "���";
            column.Width = 300;

            column.AspectGetter = _xmlViewer.AspectGetterNames;
            column.ImageGetter = _xmlViewer.GetImages;

            treeListView1.Columns.Add(column);

            OLVColumn column2 = new OLVColumn();
            column2.Width = 200;
            column2.AspectGetter = _xmlViewer.AspectGetterValues;
            column2.Text = "��������";

            treeListView1.Columns.Add(column2);
            treeListView1.CanExpandGetter = _xmlViewer.CanExpandGetter;
            treeListView1.ChildrenGetter = _xmlViewer.ChildrenGetter;
        }

        public void SetupDataBindings()
        {
            tsStatusLabel.DataBindings.Add(new Binding("Text", _settings, "CurrentOperation", true, DataSourceUpdateMode.OnPropertyChanged));
            �������������������ToolStripMenuItem.DataBindings.Add(new Binding("Enabled", _settings, "FileIsOpened", true, DataSourceUpdateMode.OnPropertyChanged));
            ������������������������������������ToolStripMenuItem.DataBindings.Add(new Binding("Enabled", _settings, "FileIsOpened", true, DataSourceUpdateMode.OnPropertyChanged));
            ������������������������ToolStripMenuItem.DataBindings.Add(new Binding("Enabled", _settings, "FileIsOpened", true, DataSourceUpdateMode.OnPropertyChanged));
            tsButtonExportExcel.DataBindings.Add(new Binding("Enabled", _settings, "FileIsOpened", true, DataSourceUpdateMode.OnPropertyChanged));
            tsMenuExportExcel.DataBindings.Add(new Binding("Enabled", _settings, "FileIsOpened", true, DataSourceUpdateMode.OnPropertyChanged));
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
            _exportToExcelSettingsForm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _exportToExcelSettingsForm.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                treeListView1.ClearObjects();
                _xDocument = new Lazy<XmlDoc>(() => new XmlDoc(_settings.FilePath + "\\" + _settings.FileName));
                //await Task.Run(()=>_xDocument.Load(openFileDialog1.FileName));
                treeListView1.Roots = _xmlViewer.LoadXmlFile(openFileDialog1.FileName);
            }
        }

        private async void findTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var model = await _xmlViewer.SearchAsync(treeListView1, findTextBox.Text);
                ExpandAndSelectFoundNode(model);
            }
        }

        private async void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                var model = await _xmlViewer.SearchNextAsync(treeListView1);
                ExpandAndSelectFoundNode(model);
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

        private void buttonFindNext_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(this, null);
        }

        private void �������������������ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string path = "";

            memo.Clear();
            memo.SelectedRtf = @"{\rtf1\ansi\deff0 \b ���������� ���������: \b0\par}";
            memo.AppendText($"��� {GetParentPath(((ModelXML)(treeListView1.SelectedObject)).node, ref path)}\r\n");
            var cnt = _xDocument.Value.GetCountElement(path);
            memo.AppendText($"���������� = {cnt}\r\n");
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ������������������������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memo.Clear();
            string path = "";
            memo.SelectedRtf = @"{\rtf1\ansi\deff0 \b ���������� ��������� � ����� �� ���������. \b0\par}";
            memo.AppendText($"��� {GetParentPath(((ModelXML)(treeListView1.SelectedObject)).node, ref path)} = ");
            string value = "";
            if (((ModelXML)(treeListView1.SelectedObject)).node.FirstChild?.NodeType != XmlNodeType.Element)
                value = ((ModelXML)(treeListView1.SelectedObject)).node.InnerText;
            memo.AppendText($"{value}\r\n");

            int cnt = _xDocument.Value.GetCountElementsWithValue(path, value);
            memo.AppendText($"���������� = {cnt}\r\n");

        }

        private void ������������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memo.Clear();
            string path = "";
            memo.SelectedRtf = @"{\rtf1\ansi\deff0 \b ���������� �������� �� ����.\b0\par}";
            memo.AppendText($"��� {GetParentPath(((ModelXML)(treeListView1.SelectedObject)).node, ref path)}\r\n");
            //memo.AppendText($"��������\t����������\r\n");
            var result = _xDocument.Value.GetStatisticsByPath(path);


            StringBuilder sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi {");
            foreach (var item in result)
                sb.Append($"\\trowd \\cellx2000 \\cellx4000\\intbl {item.Key}\\cell {item.Value}\\cell\\row");
            sb.Append("}}");
            //memo.AppendText(sb.ToString());
            memo.SelectedRtf = (sb.ToString());
        }

        private void memo_TextChanged(object sender, EventArgs e)
        {
            memo.SelectionStart = memo.Text.Length;
            memo.SelectionLength = 0;
            memo.ScrollToCaret();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*var rtfTable = @"{\rtf1\ansi {\trowd \cellx2000 \cellx4000\intbl Cell 1\cell Cell 2\cell\row\trowd \cellx2000 \cellx4000\intbl Cell 1\cell Cell 2\cell\row}}";
            memo.SelectedRtf = rtfTable;
            memo.SelectionStart = memo.Text.Length;
            memo.SelectionLength = 0;
            memo.SelectedRtf = "\\parTEEEEEEEZTTT\\par";*/

        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memo.Clear();
        }

        private void ����������������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memo.Clear();
            string path = "";
            memo.SelectedRtf = @"{\rtf1\ansi\deff0 \b ���������� ������������� �����.\b0\par}";
            var result = _xDocument.Value.GetTagUsageStatistics();


            StringBuilder sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi {");
            foreach (var item in result)
                sb.Append($"\\trowd \\cellx4000 \\cellx6000\\intbl {item.Key}\\cell {item.Value}\\cell\\row");
            sb.Append("}}");
            //memo.AppendText(sb.ToString());
            memo.SelectedRtf = (sb.ToString());

        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memo.SelectAll();
            memo.Copy();
        }
    }
}
