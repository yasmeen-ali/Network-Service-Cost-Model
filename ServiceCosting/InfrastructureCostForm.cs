using ServiceCosting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ServiceCosting
{
    public partial class InfrastructureCostForm : Form
    {
        public List<InfrastructureCostModel> infraCostModelList { get; set; }

        public InfrastructureCostForm(List<InfrastructureCostModel> _infraCostModelList)
        {
            InitializeComponent();

            infraCostModelList = _infraCostModelList;
            dataGridView1.DataSource = infraCostModelList;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
