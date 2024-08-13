namespace XMLViewer2.Forms
{
    partial class ExportToExcelSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cbFieldsName = new CheckBox();
            settingsExportToExcelsBindingSource = new BindingSource(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)settingsExportToExcelsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // cbFieldsName
            // 
            cbFieldsName.AutoSize = true;
            cbFieldsName.Checked = true;
            cbFieldsName.CheckState = CheckState.Checked;
            cbFieldsName.DataBindings.Add(new Binding("CheckState", settingsExportToExcelsBindingSource, "ColumnNameWithParentName", true));
            cbFieldsName.Location = new Point(29, 22);
            cbFieldsName.Name = "cbFieldsName";
            cbFieldsName.Size = new Size(405, 24);
            cbFieldsName.TabIndex = 0;
            cbFieldsName.Text = "Сохранять в именах колонок имя родительского тега";
            cbFieldsName.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(207, 198);
            button1.Name = "button1";
            button1.Size = new Size(104, 44);
            button1.TabIndex = 1;
            button1.Text = "Экспорт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ExportToExcelSettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 267);
            Controls.Add(button1);
            Controls.Add(cbFieldsName);
            Name = "ExportToExcelSettingsForm";
            Text = "Экспорт в Excel. Настройки";
            ((System.ComponentModel.ISupportInitialize)settingsExportToExcelsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbFieldsName;
        private Button button1;
        private BindingSource settingsExportToExcelsBindingSource;
    }
}