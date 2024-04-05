using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReiwaSupportApplication
{
    public partial class MasterSettings : Form
    {
        public MasterSettings()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // ↓ debugすると設定値が消える
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SupplyExcelPath"].Value = this.textBoxSupplyExcelPath.Text;
            config.Save();
            var fileName = ConfigurationManager.AppSettings["SupplyExcelPath"];
        }
    }
}
