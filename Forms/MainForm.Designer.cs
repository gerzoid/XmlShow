namespace XMLViewer2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            treeListView1 = new BrightIdeasSoftware.TreeListView();
            treeContextMenu = new ContextMenuStrip(components);
            количествоЭлементовToolStripMenuItem = new ToolStripMenuItem();
            количествоЭлементовСТакимЖеЗначениемToolStripMenuItem = new ToolStripMenuItem();
            статистикаЗначенийПоТегуToolStripMenuItem = new ToolStripMenuItem();
            статистикаИспользованияТеговToolStripMenuItem = new ToolStripMenuItem();
            imageList1 = new ImageList(components);
            memo = new RichTextBox();
            contextMenuStrip2 = new ContextMenuStrip(components);
            очиститьToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            buttonFindNext = new Button();
            findTextBox = new TextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            rtbValue = new RichTextBox();
            splitContainer2 = new SplitContainer();
            statusStrip1 = new StatusStrip();
            tsStatusLabel = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            tsButtonExportExcel = new ToolStripButton();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsMenuExportExcel = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            imageList2 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)treeListView1).BeginInit();
            treeContextMenu.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // treeListView1
            // 
            treeListView1.Activation = ItemActivation.OneClick;
            treeListView1.AlternateRowBackColor = Color.FromArgb(255, 128, 0);
            treeListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            treeListView1.ContextMenuStrip = treeContextMenu;
            treeListView1.Dock = DockStyle.Top;
            treeListView1.EmptyListMsg = "";
            treeListView1.EmptyListMsgFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            treeListView1.FullRowSelect = true;
            treeListView1.HeaderWordWrap = true;
            treeListView1.LargeImageList = imageList1;
            treeListView1.Location = new Point(2, 2);
            treeListView1.Margin = new Padding(3, 4, 3, 4);
            treeListView1.Name = "treeListView1";
            treeListView1.RevealAfterExpand = false;
            treeListView1.ShowCommandMenuOnRightClick = true;
            treeListView1.ShowFilterMenuOnRightClick = false;
            treeListView1.ShowGroups = false;
            treeListView1.ShowImagesOnSubItems = true;
            treeListView1.Size = new Size(547, 568);
            treeListView1.SmallImageList = imageList1;
            treeListView1.StateImageList = imageList1;
            treeListView1.TabIndex = 0;
            treeListView1.View = View.Details;
            treeListView1.VirtualMode = true;
            treeListView1.ItemSelectionChanged += treeListView1_ItemSelectionChanged;
            treeListView1.ContextMenuStripChanged += treeListView1_ContextMenuStripChanged;
            // 
            // treeContextMenu
            // 
            treeContextMenu.ImageScalingSize = new Size(20, 20);
            treeContextMenu.Items.AddRange(new ToolStripItem[] { количествоЭлементовToolStripMenuItem, количествоЭлементовСТакимЖеЗначениемToolStripMenuItem, статистикаЗначенийПоТегуToolStripMenuItem, статистикаИспользованияТеговToolStripMenuItem });
            treeContextMenu.Name = "contextMenuStrip1";
            treeContextMenu.Size = new Size(398, 100);
            treeContextMenu.Opening += contextMenuStrip1_Opening;
            // 
            // количествоЭлементовToolStripMenuItem
            // 
            количествоЭлементовToolStripMenuItem.Name = "количествоЭлементовToolStripMenuItem";
            количествоЭлементовToolStripMenuItem.Size = new Size(397, 24);
            количествоЭлементовToolStripMenuItem.Text = "Количество элементов";
            количествоЭлементовToolStripMenuItem.Click += количествоЭлементовToolStripMenuItem_Click_1;
            // 
            // количествоЭлементовСТакимЖеЗначениемToolStripMenuItem
            // 
            количествоЭлементовСТакимЖеЗначениемToolStripMenuItem.Name = "количествоЭлементовСТакимЖеЗначениемToolStripMenuItem";
            количествоЭлементовСТакимЖеЗначениемToolStripMenuItem.Size = new Size(397, 24);
            количествоЭлементовСТакимЖеЗначениемToolStripMenuItem.Text = "Количество элементов с таким же значением";
            количествоЭлементовСТакимЖеЗначениемToolStripMenuItem.Click += количествоЭлементовСТакимЖеЗначениемToolStripMenuItem_Click;
            // 
            // статистикаЗначенийПоТегуToolStripMenuItem
            // 
            статистикаЗначенийПоТегуToolStripMenuItem.Name = "статистикаЗначенийПоТегуToolStripMenuItem";
            статистикаЗначенийПоТегуToolStripMenuItem.Size = new Size(397, 24);
            статистикаЗначенийПоТегуToolStripMenuItem.Text = "Статистика значений по тегу";
            статистикаЗначенийПоТегуToolStripMenuItem.Click += статистикаЗначенийПоТегуToolStripMenuItem_Click;
            // 
            // статистикаИспользованияТеговToolStripMenuItem
            // 
            статистикаИспользованияТеговToolStripMenuItem.Name = "статистикаИспользованияТеговToolStripMenuItem";
            статистикаИспользованияТеговToolStripMenuItem.Size = new Size(397, 24);
            статистикаИспользованияТеговToolStripMenuItem.Text = "Статистика использования тегов";
            статистикаИспользованияТеговToolStripMenuItem.Click += статистикаИспользованияТеговToolStripMenuItem_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "collapse");
            imageList1.Images.SetKeyName(1, "expand");
            imageList1.Images.SetKeyName(2, "tag.png");
            imageList1.Images.SetKeyName(3, "attr.png");
            // 
            // memo
            // 
            memo.BackColor = SystemColors.Info;
            memo.ContextMenuStrip = contextMenuStrip2;
            memo.Dock = DockStyle.Fill;
            memo.Location = new Point(0, 0);
            memo.Margin = new Padding(3, 4, 3, 4);
            memo.Name = "memo";
            memo.ReadOnly = true;
            memo.ScrollBars = RichTextBoxScrollBars.Vertical;
            memo.Size = new Size(1390, 190);
            memo.TabIndex = 8;
            memo.Text = "";
            memo.TextChanged += memo_TextChanged;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { очиститьToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(143, 28);
            // 
            // очиститьToolStripMenuItem
            // 
            очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            очиститьToolStripMenuItem.Size = new Size(142, 24);
            очиститьToolStripMenuItem.Text = "Очистить";
            очиститьToolStripMenuItem.Click += очиститьToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(buttonFindNext);
            splitContainer1.Panel1.Controls.Add(findTextBox);
            splitContainer1.Panel1.Controls.Add(treeListView1);
            splitContainer1.Panel1.Padding = new Padding(2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(1390, 537);
            splitContainer1.SplitterDistance = 551;
            splitContainer1.TabIndex = 9;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            splitContainer1.Resize += splitContainer1_Resize;
            // 
            // buttonFindNext
            // 
            buttonFindNext.FlatStyle = FlatStyle.Flat;
            buttonFindNext.Image = Properties.Resources.icons8_найти_24;
            buttonFindNext.Location = new Point(514, 545);
            buttonFindNext.Name = "buttonFindNext";
            buttonFindNext.Size = new Size(34, 27);
            buttonFindNext.TabIndex = 15;
            buttonFindNext.UseVisualStyleBackColor = true;
            buttonFindNext.Click += buttonFindNext_Click;
            // 
            // findTextBox
            // 
            findTextBox.Dock = DockStyle.Bottom;
            findTextBox.Location = new Point(2, 508);
            findTextBox.Name = "findTextBox";
            findTextBox.PlaceholderText = "Текст для поиска...";
            findTextBox.Size = new Size(547, 27);
            findTextBox.TabIndex = 8;
            findTextBox.KeyDown += findTextBox_KeyDown;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(835, 537);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Honeydew;
            tabPage1.Controls.Add(rtbValue);
            tabPage1.Font = new Font("Segoe UI", 9F);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(827, 504);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Содержимое";
            // 
            // rtbValue
            // 
            rtbValue.BackColor = Color.Honeydew;
            rtbValue.Dock = DockStyle.Fill;
            rtbValue.Location = new Point(3, 3);
            rtbValue.Name = "rtbValue";
            rtbValue.ReadOnly = true;
            rtbValue.Size = new Size(821, 498);
            rtbValue.TabIndex = 0;
            rtbValue.Text = "";
            // 
            // splitContainer2
            // 
            splitContainer2.Location = new Point(0, 62);
            splitContainer2.Margin = new Padding(3, 53, 3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(memo);
            splitContainer2.Size = new Size(1390, 731);
            splitContainer2.SplitterDistance = 537;
            splitContainer2.TabIndex = 10;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsStatusLabel });
            statusStrip1.Location = new Point(0, 728);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1390, 26);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLabel
            // 
            tsStatusLabel.Name = "tsStatusLabel";
            tsStatusLabel.Size = new Size(15, 20);
            tsStatusLabel.Text = "-";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, tsButtonExportExcel });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1390, 27);
            toolStrip1.TabIndex = 13;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.icons8_открыть_папку_48;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "Открыть";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // tsButtonExportExcel
            // 
            tsButtonExportExcel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsButtonExportExcel.Image = Properties.Resources.icons8_экспорт_excel_48;
            tsButtonExportExcel.ImageTransparentColor = Color.Magenta;
            tsButtonExportExcel.Name = "tsButtonExportExcel";
            tsButtonExportExcel.Size = new Size(29, 24);
            tsButtonExportExcel.Text = "Экспорт в Excel";
            tsButtonExportExcel.Click += toolStripButton2_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1390, 28);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripSeparator1, tsMenuExportExcel, toolStripSeparator2, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Image = Properties.Resources.icons8_открыть_папку_48;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(224, 26);
            toolStripMenuItem2.Text = "Открыть";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // tsMenuExportExcel
            // 
            tsMenuExportExcel.Image = Properties.Resources.icons8_экспорт_excel_48;
            tsMenuExportExcel.Name = "tsMenuExportExcel";
            tsMenuExportExcel.Size = new Size(224, 26);
            tsMenuExportExcel.Text = "Экспорт";
            tsMenuExportExcel.Click += toolStripMenuItem3_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(224, 26);
            выходToolStripMenuItem.Text = "Выход";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(30, 24);
            toolStripMenuItem1.Text = "?";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "XML файлы|*.xml";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageSize = new Size(16, 16);
            imageList2.TransparentColor = Color.Transparent;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 754);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(splitContainer2);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "XmlShow";
            SizeChanged += Form1_SizeChanged;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)treeListView1).EndInit();
            treeContextMenu.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView1;
        private ImageList imageList1;
        private RichTextBox memo;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem tsMenuExportExcel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem выходToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox  findTextBox;
        private RichTextBox rtbValue;
        private ToolStripButton tsButtonExportExcel;
        private OpenFileDialog openFileDialog1;
        private Button buttonFindNext;
        private ImageList imageList2;
        private ToolStripStatusLabel tsStatusLabel;
        private ContextMenuStrip treeContextMenu;
        private ToolStripMenuItem количествоЭлементовToolStripMenuItem;
        private ToolStripMenuItem количествоЭлементовСТакимЖеЗначениемToolStripMenuItem;
        private ToolStripMenuItem статистикаЗначенийПоТегуToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem очиститьToolStripMenuItem;
        private ToolStripMenuItem статистикаИспользованияТеговToolStripMenuItem;
    }
}
