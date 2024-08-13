using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLViewer2.Classes;
using XMLViewer2.Models;

namespace XMLViewer2.Forms
{
    public partial class ExportToExcelSettingsForm : Form
    {
        Settings _settings;
        bool isBinded = false;
        public ExportToExcelSettingsForm(Settings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ExportToExcelSettingsForm_Load(object sender, EventArgs e)
        {
            //settings = SettingsSerializer.Deserialize();
            if (isBinded) return;
            cbFieldsName.DataBindings.Add(new Binding("Checked", _settings, "ColumnNameWithParentName", true, DataSourceUpdateMode.OnPropertyChanged));
            isBinded = true;
        }

        private void ExportToExcelSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsSerializer.Serialize(_settings);
            //SettingsSerializer.Serialize(settings);
        }
    }
}
