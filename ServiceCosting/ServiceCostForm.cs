using ServiceCosting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Text.RegularExpressions;

using Excel = Microsoft.Office.Interop.Excel;


namespace ServiceCosting
{
    public partial class ServicesCostForm : Form

    {
        //public List<InfrastructureCostModel> infraCostModelList { get; set; }

        List<ServiceCostModel> VpnCostModelList = new List<ServiceCostModel>();
        List<ServiceCostModel> EthernetCostModelList = new List<ServiceCostModel>();
        List<ServiceCostModel> TlsCostModelList = new List<ServiceCostModel>();
        List<ServiceCostModel> HsCostModelList = new List<ServiceCostModel>();

        List<ServiceCostModel> VpnCostModelList2 = new List<ServiceCostModel>();
        List<ServiceCostModel> EthernetCostModelList2 = new List<ServiceCostModel>();
        List<ServiceCostModel> TlsCostModelList2 = new List<ServiceCostModel>();
        List<ServiceCostModel> HsCostModelList2 = new List<ServiceCostModel>();

        List<CostGapModel> VpnCostGapList = new List<CostGapModel>();
        List<CostGapModel> EthernetCostGapList = new List<CostGapModel>();
        List<CostGapModel> TlsCostGapList = new List<CostGapModel>();
        List<CostGapModel> HsCostGapList = new List<CostGapModel>();

        List<M1Data> Data = new List<M1Data>();


        public ServicesCostForm(List<InfrastructureCostModel> infraCostModelList,
            List<ServiceCostModel> VpnList,
            List<ServiceCostModel> EthernetList,
            List<ServiceCostModel> TLSList,
            List<ServiceCostModel> HSList,
            List<ServiceCostModel> VpnList2,
            List<ServiceCostModel> EthernetList2,
            List<ServiceCostModel> TLSList2,
            List<ServiceCostModel> HSList2,
            List<CostGapModel> VpnCostGapList,
            List<CostGapModel> EthernetCostGapList,
            List<CostGapModel> TlsCostGapList,
            List<CostGapModel> HsCostGapList,
            List<M1Data> data)
        {
            InitializeComponent();


            //infraCostModelList = _infraCostModelList;
            dataGridView1.DataSource = infraCostModelList;
            dgvVPN.DataSource = VpnList;
            dgvEthernet.DataSource = EthernetList;
            dgvTLS.DataSource = TLSList;
            dgvHS.DataSource = HSList;

            dgVpnM2.DataSource = VpnList2;
            dgEthM2.DataSource = EthernetList2;
            dgTLSM2.DataSource = TLSList2;
            dgHSM2.DataSource = HSList2;

            dgVpnCostGap.DataSource = VpnCostGapList;
            dgEthCostGap.DataSource = EthernetCostGapList;
            dgTlsCostGap.DataSource = TlsCostGapList;
            dgHsCostGap.DataSource = HsCostGapList;



            this.Data = data;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            //Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //Excel.Worksheet worksheet = null;
            Excel.Workbook workbook = app.Workbooks.Add(Excel.XlSheetType.xlWorksheet);

            app.Visible = true;



            Excel.Worksheet worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            worksheet.Name = "Total Network Cost";

            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }


            Excel.Worksheet vpnSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[1], Type.Missing, Type.Missing);
            vpnSheet.Name = "VPN";

            // storing header part in Excel  
            for (int i = 1; i < dgvVPN.Columns.Count + 1; i++)
            {
                vpnSheet.Cells[1, i] = dgvVPN.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgvVPN.Rows.Count; i++)
            {
                for (int j = 0; j < dgvVPN.Columns.Count; j++)
                {
                    vpnSheet.Cells[i + 2, j + 1] = dgvVPN.Rows[i].Cells[j].Value.ToString();
                }
            }


            Excel.Worksheet EthSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[2], Type.Missing, Type.Missing);
            EthSheet.Name = "Ethernet";

            // storing header part in Excel  
            for (int i = 1; i < dgvEthernet.Columns.Count + 1; i++)
            {
                EthSheet.Cells[1, i] = dgvEthernet.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgvEthernet.Rows.Count; i++)
            {
                for (int j = 0; j < dgvEthernet.Columns.Count; j++)
                {
                    EthSheet.Cells[i + 2, j + 1] = dgvEthernet.Rows[i].Cells[j].Value.ToString();
                }
            }


            Excel.Worksheet TlsSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[3], Type.Missing, Type.Missing);
            TlsSheet.Name = "TLS";

            // storing header part in Excel  
            for (int i = 1; i < dgvTLS.Columns.Count + 1; i++)
            {
                TlsSheet.Cells[1, i] = dgvTLS.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgvTLS.Rows.Count; i++)
            {
                for (int j = 0; j < dgvTLS.Columns.Count; j++)
                {
                    TlsSheet.Cells[i + 2, j + 1] = dgvTLS.Rows[i].Cells[j].Value.ToString();
                }
            }


            Excel.Worksheet HsSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[4], Type.Missing, Type.Missing);
            HsSheet.Name = "HS";

            // storing header part in Excel  
            for (int i = 1; i < dgvHS.Columns.Count + 1; i++)
            {
                HsSheet.Cells[1, i] = dgvHS.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgvHS.Rows.Count; i++)
            {
                for (int j = 0; j < dgvHS.Columns.Count; j++)
                {
                    HsSheet.Cells[i + 2, j + 1] = dgvHS.Rows[i].Cells[j].Value.ToString();
                }
            }


            // M2 Tabs

            Excel.Worksheet vpnSheet2 = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[5], Type.Missing, Type.Missing);
            vpnSheet2.Name = "VPN M2";

            // storing header part in Excel  
            for (int i = 1; i < dgVpnM2.Columns.Count + 1; i++)
            {
                vpnSheet2.Cells[1, i] = dgVpnM2.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgVpnM2.Rows.Count; i++)
            {
                for (int j = 0; j < dgVpnM2.Columns.Count; j++)
                {
                    vpnSheet2.Cells[i + 2, j + 1] = dgVpnM2.Rows[i].Cells[j].Value.ToString();
                }
            }


            Excel.Worksheet EthSheet2 = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[6], Type.Missing, Type.Missing);
            EthSheet2.Name = "Eth M2";

            // storing header part in Excel  
            for (int i = 1; i < dgEthM2.Columns.Count + 1; i++)
            {
                EthSheet2.Cells[1, i] = dgEthM2.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgEthM2.Rows.Count; i++)
            {
                for (int j = 0; j < dgEthM2.Columns.Count; j++)
                {
                    EthSheet2.Cells[i + 2, j + 1] = dgEthM2.Rows[i].Cells[j].Value.ToString();
                }
            }


            Excel.Worksheet TlsSheet2 = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[7], Type.Missing, Type.Missing);
            TlsSheet2.Name = "TLS M2";

            // storing header part in Excel  
            for (int i = 1; i < dgTLSM2.Columns.Count + 1; i++)
            {
                TlsSheet2.Cells[1, i] = dgTLSM2.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgTLSM2.Rows.Count; i++)
            {
                for (int j = 0; j < dgTLSM2.Columns.Count; j++)
                {
                    TlsSheet2.Cells[i + 2, j + 1] = dgTLSM2.Rows[i].Cells[j].Value.ToString();
                }
            }


            Excel.Worksheet HsSheet2 = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[8], Type.Missing, Type.Missing);
            HsSheet2.Name = "HS M2";

            // storing header part in Excel  
            for (int i = 1; i < dgHSM2.Columns.Count + 1; i++)
            {
                HsSheet2.Cells[1, i] = dgHSM2.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgHSM2.Rows.Count; i++)
            {
                for (int j = 0; j < dgHSM2.Columns.Count; j++)
                {
                    HsSheet2.Cells[i + 2, j + 1] = dgHSM2.Rows[i].Cells[j].Value.ToString();
                }
            }


            Excel.Worksheet VpnCostGapSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[9], Type.Missing, Type.Missing);
            VpnCostGapSheet.Name = "VPN COST GAP";

            // storing header part in Excel  
            for (int i = 1; i < dgVpnCostGap.Columns.Count + 1; i++)
            {
                VpnCostGapSheet.Cells[1, i] = dgVpnCostGap.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgVpnCostGap.Rows.Count; i++)
            {
                for (int j = 0; j < dgVpnCostGap.Columns.Count; j++)
                {
                    VpnCostGapSheet.Cells[i + 2, j + 1] = dgVpnCostGap.Rows[i].Cells[j].Value.ToString();
                }
            }
            //------------------------------------------------------------------------------------------------------------------------//
            // Trying for chart
            // i is row count last row is i+1
            // j is coulumn count  J
            // Excel.Range chartRange;
            // Excel.ChartObjects xlCharts = (Excel.ChartObjects)VpnCostGapSheet.ChartObjects(Type.Missing);
            // Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(20, 80, 450, 250);
            // Excel.Chart chartPage = myChart.Chart;
            // myChart.Select();


            // chartPage.ChartType = Excel.XlChartType.xlLineMarkers;
            // chartPage.ChartType = Excel.XlChartType.xlXYScatterLines;
            // Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            // Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();

            // chartPage.HasTitle = true;
            // chartPage.ChartTitle.Text = "Cost Gap";
            // chartPage.HasLegend = false;

            // var yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
            // yAxis.HasTitle = true;
            // yAxis.AxisTitle.Text = "Difference in percentage (%)";
            // yAxis.MinimumScale = -0.025;
            // yAxis.MaximumScale = 0.025;
            //// yAxis.TickLabels.NumberFormat = "\"%\"";

            // yAxis.AxisTitle.Orientation = Excel.XlOrientation.xlUpward;

            //var xAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
            //xAxis.HasTitle = true;
            //xAxis.AxisTitle.Text = "No of Nodes in Service";
            ////xAxis.MinimumScale = -0.025;
            ////xAxis.MaximumScale = 0.025;
            //// yAxis.TickLabels.NumberFormat = "\"%\"";

            //xAxis.AxisTitle.Orientation = Excel.XlOrientation.xlHorizontal;

            // Excel.Range Data_Range = VpnCostGapSheet.get_Range("G1", "G" + dgVpnCostGap.Rows.Count.ToString());//Data to be plotted in chart
            //Excel.Range XVal_Range = VpnCostGapSheet.get_Range("B1: B" + dgVpnCostGap.Rows.Count.ToString()); //Catagory Names I want on X-Axis as range


            //Excel.Series series = chartPage.SeriesCollection().Add(VpnCostGapSheet.Range["G1: G" + dgVpnCostGap.Rows.Count.ToString()]);

            //series.XValues = VpnCostGapSheet.Range["B1: B" + dgVpnCostGap.Rows.Count.ToString()];

            ////// VpnCostGapSheet.Range["G1: G" + dgVpnCostGap.Rows.Count.ToString()].Style.NumberFormat = "\"%\"#,##0";

            //chartPage.ChartType = Excel.XlChartType.xlColumnClustered;


            // chartRange = VpnCostGapSheet.get_Range("B" + dgVpnCostGap.Rows.Count.ToString(), "G1: G" + dgVpnCostGap.Rows.Count.ToString());
            //chartPage.SetSourceData(chartRange, Type.Missing);



            //// Make it a Line Chart

            //workbook.ActiveChart.ApplyCustomType(Microsoft.Office.Interop.Excel.XlChartType.xlLine);

            //Excel.ChartObjects xlChart = (Excel.ChartObjects)VpnCostGapSheet.ChartObjects(Type.Missing);
            //Excel.ChartObject myChart = (Excel.ChartObject)xlChart.Add(1420, 660, 320, 180);
            //Excel.Chart chartPage = myChart.Chart;
            //chartPage.ChartType = Excel.XlChartType.xlLineMarkers;
            //chartPage.HasTitle = true;
            //chartPage.ChartTitle.Text = "Title Text";
            //chartPage.HasLegend = false;

            //var yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
            //yAxis.HasTitle = true;
            //yAxis.AxisTitle.Text = "Y-Axis Title text";
            //yAxis.MinimumScale = -2.5;
            //yAxis.MaximumScale = 2.5;
            //yAxis.AxisTitle.Orientation = Excel.XlOrientation.xlUpward;

            //Excel.Range Data_Range = VpnCostGapSheet.get_Range("G1", "G" + dgVpnCostGap.Rows.Count.ToString());//Data to be plotted in chart
            //Excel.Range XVal_Range = VpnCostGapSheet.get_Range("B1: B" + dgVpnCostGap.Rows.Count.ToString()); //Catagory Names I want on X-Axis as range

            //Excel.SeriesCollection oSeriesCollection = (Excel.SeriesCollection)myChart.Chart.SeriesCollection(Type.Missing);
            //Excel.Series Data = oSeriesCollection.NewSeries();
            //Data.Values = Data_Range;
            //Data.Name = "Plot Data";

            //Excel.Axis xAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
            //xAxis.CategoryNames = XVal_Range;

            //------------------------------------------------------------------------------------------------------------------------------------//



            Excel.Worksheet EthernetCostGapSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[10], Type.Missing, Type.Missing);
            EthernetCostGapSheet.Name = "ETHERNET COST GAP";

            // storing header part in Excel  
            for (int i = 1; i < dgEthCostGap.Columns.Count + 1; i++)
            {
                EthernetCostGapSheet.Cells[1, i] = dgEthCostGap.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgEthCostGap.Rows.Count; i++)
            {
                for (int j = 0; j < dgEthCostGap.Columns.Count; j++)
                {
                    EthernetCostGapSheet.Cells[i + 2, j + 1] = dgEthCostGap.Rows[i].Cells[j].Value.ToString();
                }
            }






            Excel.Worksheet TLSCostGapSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[11], Type.Missing, Type.Missing);
            TLSCostGapSheet.Name = "TLS COST GAP";

            // storing header part in Excel  
            for (int i = 1; i < dgTlsCostGap.Columns.Count + 1; i++)
            {
                TLSCostGapSheet.Cells[1, i] = dgTlsCostGap.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgTlsCostGap.Rows.Count; i++)
            {
                for (int j = 0; j < dgTlsCostGap.Columns.Count; j++)
                {
                    TLSCostGapSheet.Cells[i + 2, j + 1] = dgTlsCostGap.Rows[i].Cells[j].Value.ToString();
                }
            }

            Excel.Worksheet HSCostGapSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[12], Type.Missing, Type.Missing);
            HSCostGapSheet.Name = "HS COST GAP";

            // storing header part in Excel  
            for (int i = 1; i < dgHsCostGap.Columns.Count + 1; i++)
            {
                HSCostGapSheet.Cells[1, i] = dgHsCostGap.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgHsCostGap.Rows.Count; i++)
            {
                for (int j = 0; j < dgHsCostGap.Columns.Count; j++)
                {
                    HSCostGapSheet.Cells[i + 2, j + 1] = dgHsCostGap.Rows[i].Cells[j].Value.ToString();
                }
            }

            // save the application  

            // workbook.SaveAs("C:\\Users\\Yasmeen Ali\\Documents\\WINTER TERM 2019\\Model Results\\output.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //workbook.SaveAs("c:\\Users\\Yasmeen Ali\\Documents\\WINTER TERM 2019\\Model Results\\output.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            //false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            //Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // FileInfo excelFile = new FileInfo(@"C:\\Users\\Yasmeen Ali\\Documents\\WINTER TERM 2019\\Model Results\\output.xlsx");
            //workbook.SaveAs(excelFile);

            //app.Workbooks.Add("C:\\Users\\Yasmeen Ali\\Documents\\WINTER TERM 2019\\Model Results\\output.xlsx");
            // workbook.Close(true, Type.Missing, Type.Missing);


            // Exit from the application  

            //app.Quit();
        }

        private void ExportResultFile()
        {
            Excel.Application app = new Excel.Application();
            //Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //Excel.Worksheet worksheet = null;
            Excel.Workbook workbook = app.Workbooks.Add(Excel.XlSheetType.xlWorksheet);

            app.Visible = true;

            Excel.Worksheet CostGapSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[1], Type.Missing, Type.Missing);
            CostGapSheet.Name = "COST GAP";

            // storing header part in Excel  
            for (int i = 1; i < dgVpnCostGap.Columns.Count + 1; i++)
            {
                CostGapSheet.Cells[1, i] = dgVpnCostGap.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgVpnCostGap.Rows.Count; i++)
            {
                for (int j = 0; j < dgVpnCostGap.Columns.Count; j++)
                {
                    CostGapSheet.Cells[i + 2, j + 1] = dgVpnCostGap.Rows[i].Cells[j].Value.ToString();
                }
            }

            //Excel.Worksheet EthernetCostGapSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[2], Type.Missing, Type.Missing);
            //EthernetCostGapSheet.Name = "ETHERNET COST GAP";

            // storing header part in Excel  
            for (int i = 1; i < dgEthCostGap.Columns.Count + 1; i++)
            {
                CostGapSheet.Cells[1, i] = dgEthCostGap.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgEthCostGap.Rows.Count; i++)
            {
                for (int j = 0; j < dgEthCostGap.Columns.Count; j++)
                {
                    CostGapSheet.Cells[i + 2, j + 1] = dgEthCostGap.Rows[i].Cells[j].Value.ToString();
                }
            }



            //Excel.Worksheet TLSCostGapSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[3], Type.Missing, Type.Missing);
            //TLSCostGapSheet.Name = "TLS COST GAP";

            // storing header part in Excel  
            for (int i = 1; i < dgTlsCostGap.Columns.Count + 1; i++)
            {
                CostGapSheet.Cells[1, i] = dgTlsCostGap.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgTlsCostGap.Rows.Count; i++)
            {
                for (int j = 0; j < dgTlsCostGap.Columns.Count; j++)
                {
                    CostGapSheet.Cells[i + 2, j + 1] = dgTlsCostGap.Rows[i].Cells[j].Value.ToString();
                }
            }

            //Excel.Worksheet HSCostGapSheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[4], Type.Missing, Type.Missing);
            //HSCostGapSheet.Name = "HS COST GAP";

            // storing header part in Excel  
            for (int i = 1; i < dgHsCostGap.Columns.Count + 1; i++)
            {
                CostGapSheet.Cells[1, i] = dgHsCostGap.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgHsCostGap.Rows.Count; i++)
            {
                for (int j = 0; j < dgHsCostGap.Columns.Count; j++)
                {
                    CostGapSheet.Cells[i + 2, j + 1] = dgHsCostGap.Rows[i].Cells[j].Value.ToString();
                }
            }

            workbook.SaveAs(@"C:\Users\Yasmeen Ali\Documents\PyCharmFiles\KMeansClusteringPython\CostGapM2.csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV);

            try
            {
                // System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(CostGapSheet);
                // SystRuntime.InteropServices.Marshal.ReleaseComObject(sheets);
                workbook.Save();
                workbook.Close(true);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(CostGapSheet);
                //app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                /*
                 * 			Excel.Application app = new Excel.Application();
                            Excel.Workbooks workbooks; //= app.Workbooks.Add(Type.Missing);
                                                       //Excel.Worksheet worksheet = null;
                            Excel.Workbook workbook;
                            workbooks = app.Workbooks;
                            workbook = workbooks.Add(@"C:/C#Data.csv");
                */
            }
            finally
            {

                if (CostGapSheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(CostGapSheet);
                //app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            // Exit from the application  

            this.Close();
        }

        private void btnGenExcelData_Click(object sender, EventArgs e)
        {
            //ExportResultFile();

            GenerateExcelData();
            RunPython();
            KMeansResult();

            //Back from python
            // DO YOUR work


        }
       
        private void RunPython()
        {

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = Environment.SystemDirectory + "/cmd.exe";
            startInfo.Arguments = "/E cd E:\\GitHub-Projects\\ServiceCostModel\\ServiceCosting\\KMeansClusteringPython\\venv\\Scripts &python NewResults-TestFinal.py& ";
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.RedirectStandardOutput = false;
            process.Start();
            //string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

        }
       

        private void KMeansResult()
        {
            String name = "CostGap";
            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            "E:\\GitHub-Projects\\ServiceCostModel\\ServiceCosting\\KMeansClusteringPython\\SendtoCSharps.xlsx" +
                            ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable Filedata = new DataTable();
            sda.Fill(Filedata);
            KMeansDGV.DataSource = Filedata;
            con.Close();
        }

        private void GenerateExcelData()
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbooks workbooks; //= app.Workbooks.Add(Type.Missing);
                                       //Excel.Worksheet worksheet = null;
            Excel.Workbook workbook;
            workbooks = app.Workbooks;
            workbook = workbooks.Add(Type.Missing);

            /*
                public Excel.Application excelApp = new Excel.Application();
                public Excel.Workbooks workbooks;
                public Excel.Workbook excelBook;
                workbooks = excelApp.Workbooks;
                excelBook = workbooks.Add(@"C:/pape.xltx");
            */

            app.Visible = true;



            Excel.Worksheet worksheet = workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;

            //worksheet.Name = "Data";

            // storing header part in Excel  

            int rowNumber = 1;

            worksheet.Cells[rowNumber, 1] = "Service";
            worksheet.Cells[rowNumber, 2] = "Node";
            worksheet.Cells[rowNumber, 3] = "Iteration";
            worksheet.Cells[rowNumber, 4] = "Type";
            worksheet.Cells[rowNumber, 5] = "Cost";
            worksheet.Cells[rowNumber, 6] = "Capacity";


            foreach (var m1Data in Data)
            {
                foreach (var nodeData in m1Data.RoutersData)
                {

                    foreach (var item in nodeData.CpeRDetails)
                    {
                        rowNumber++;
                        worksheet.Cells[rowNumber, 1] = m1Data.ServiceName;
                        worksheet.Cells[rowNumber, 2] = nodeData.Node.ToString();
                        worksheet.Cells[rowNumber, 3] = nodeData.IterationNo.ToString();
                        worksheet.Cells[rowNumber, 4] = "CPE";
                        worksheet.Cells[rowNumber, 5] = item.RouterCost.ToString();
                        worksheet.Cells[rowNumber, 6] = item.CapacityPerRouter.ToString();



                    }
                    foreach (var item in nodeData.EthRDetails)
                    {
                        rowNumber++;
                        worksheet.Cells[rowNumber, 1] = m1Data.ServiceName;
                        worksheet.Cells[rowNumber, 2] = nodeData.Node.ToString();
                        worksheet.Cells[rowNumber, 3] = nodeData.IterationNo.ToString();
                        worksheet.Cells[rowNumber, 4] = "ETH";
                        worksheet.Cells[rowNumber, 5] = item.RouterCost.ToString();
                        worksheet.Cells[rowNumber, 6] = item.CapacityPerRouter.ToString();


                    }
                    foreach (var item in nodeData.EdgeRDetails)
                    {
                        rowNumber++;
                        worksheet.Cells[rowNumber, 1] = m1Data.ServiceName;
                        worksheet.Cells[rowNumber, 2] = nodeData.Node.ToString();
                        worksheet.Cells[rowNumber, 3] = nodeData.IterationNo.ToString();
                        worksheet.Cells[rowNumber, 4] = "EDGE";
                        worksheet.Cells[rowNumber, 5] = item.RouterCost.ToString();
                        worksheet.Cells[rowNumber, 6] = item.CapacityPerRouter.ToString();


                    }
                    foreach (var item in nodeData.OptSwRDetails)
                    {
                        rowNumber++;
                        worksheet.Cells[rowNumber, 1] = m1Data.ServiceName;
                        worksheet.Cells[rowNumber, 2] = nodeData.Node.ToString();
                        worksheet.Cells[rowNumber, 3] = nodeData.IterationNo.ToString();
                        worksheet.Cells[rowNumber, 4] = "OPTSW";
                        worksheet.Cells[rowNumber, 5] = item.RouterCost.ToString();
                        worksheet.Cells[rowNumber, 6] = item.CapacityPerRouter.ToString();


                    }
                    foreach (var item in nodeData.CoreRDetails)
                    {
                        rowNumber++;
                        worksheet.Cells[rowNumber, 1] = m1Data.ServiceName;
                        worksheet.Cells[rowNumber, 2] = nodeData.Node.ToString();
                        worksheet.Cells[rowNumber, 3] = nodeData.IterationNo.ToString();
                        worksheet.Cells[rowNumber, 4] = "CORE";
                        worksheet.Cells[rowNumber, 5] = item.RouterCost.ToString();
                        worksheet.Cells[rowNumber, 6] = item.CapacityPerRouter.ToString();

                    }
                    foreach (var item in nodeData.GatewayRDetails)
                    {
                        rowNumber++;
                        worksheet.Cells[rowNumber, 1] = m1Data.ServiceName;
                        worksheet.Cells[rowNumber, 2] = nodeData.Node.ToString();
                        worksheet.Cells[rowNumber, 3] = nodeData.IterationNo.ToString();
                        worksheet.Cells[rowNumber, 4] = "GATEWAY";
                        worksheet.Cells[rowNumber, 5] = item.RouterCost.ToString();
                        worksheet.Cells[rowNumber, 6] = item.CapacityPerRouter.ToString();


                    }

                }


            }


        // save the application  

        //workbook.SaveAs("C:\\Users\\Yasmeen Ali\\Documents\\WINTER TERM 2019\\Model Results\\output.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        //workbook.SaveAs("c:\\Users\\Yasmeen Ali\\Documents\\WINTER TERM 2019\\Model Results\\output.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
        //false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
        //Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        // FileInfo excelFile = new FileInfo(@"C:\\Users\\Yasmeen Ali\\Documents\\WINTER TERM 2019\\Model Results\\output.xlsx");
        //workbook.SaveAs(excelFile);

        //app.Workbooks.Add("C:\\Users\\Yasmeen Ali\\Documents\\WINTER TERM 2019\\Model Results\\output.xlsx");
        // workbook.Close(true, Type.Missing, Type.Missing);


        // Exit from the application  

        //app.Quit();
       

            workbook.SaveAs(@"E:\GitHub-Projects\ServiceCostModel\ServiceCosting\KMeansClusteringPython\PythonFile.csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV);

            try
            {
                // System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                // SystRuntime.InteropServices.Marshal.ReleaseComObject(sheets);
                workbook.Save();
                workbook.Close(true);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
                //app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                /*
                 * 			Excel.Application app = new Excel.Application();
                            Excel.Workbooks workbooks; //= app.Workbooks.Add(Type.Missing);
                                                       //Excel.Worksheet worksheet = null;
                            Excel.Workbook workbook;
                            workbooks = app.Workbooks;
                            workbook = workbooks.Add(@"C:/C#Data.csv");
                */
            }
            finally
            {

                if (workbooks != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
                //app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }


        //-----------Cell Formatting----//

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgvVPN_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvVPN.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgvVPN.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgvEthernet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvEthernet.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgvEthernet.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgvTLS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvTLS.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgvTLS.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgvHS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHS.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgvHS.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgVpnM2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgVpnM2.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgVpnM2.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgEthM2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgEthM2.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgEthM2.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgTLSM2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgTLSM2.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgTLSM2.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgHSM2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgHSM2.Columns[e.ColumnIndex].Name == "NetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgHSM2.Columns[e.ColumnIndex].Name == "TotalNetworkCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
        }

        private void dgVpnCostGap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgVpnCostGap.Columns[e.ColumnIndex].Name == "TotalNetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgVpnCostGap.Columns[e.ColumnIndex].Name == "M1UnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgVpnCostGap.Columns[e.ColumnIndex].Name == "M2UnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }

            if (this.dgVpnCostGap.Columns[e.ColumnIndex].Name == "TotalNetworkCostGap")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
            if (this.dgVpnCostGap.Columns[e.ColumnIndex].Name == "M2CostGap")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
        }

        private void dgEthCostGap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgEthCostGap.Columns[e.ColumnIndex].Name == "TotalNetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgEthCostGap.Columns[e.ColumnIndex].Name == "M1UnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgEthCostGap.Columns[e.ColumnIndex].Name == "M2UnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }

            if (this.dgEthCostGap.Columns[e.ColumnIndex].Name == "TotalNetworkCostGap")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
            if (this.dgEthCostGap.Columns[e.ColumnIndex].Name == "M2CostGap")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
        }

        private void dgTlsCostGap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgTlsCostGap.Columns[e.ColumnIndex].Name == "TotalNetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgTlsCostGap.Columns[e.ColumnIndex].Name == "M1UnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgTlsCostGap.Columns[e.ColumnIndex].Name == "M2UnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }

            if (this.dgTlsCostGap.Columns[e.ColumnIndex].Name == "TotalNetworkCostGap")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
            if (this.dgTlsCostGap.Columns[e.ColumnIndex].Name == "M2CostGap")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
        }

        private void dgHsCostGap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgHsCostGap.Columns[e.ColumnIndex].Name == "TotalNetworkUnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgHsCostGap.Columns[e.ColumnIndex].Name == "M1UnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.dgHsCostGap.Columns[e.ColumnIndex].Name == "M2UnitCost")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }

            if (this.dgHsCostGap.Columns[e.ColumnIndex].Name == "TotalNetworkCostGap")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
            if (this.dgHsCostGap.Columns[e.ColumnIndex].Name == "M2CostGap")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
        }

        private void KMeansDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.KMeansDGV.Columns[e.ColumnIndex].Name == "NetworkServiceUnitCostM3")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.KMeansDGV.Columns[e.ColumnIndex].Name == "NetworkServiceUnitCostM1")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.00");
                }
            }
            if (this.KMeansDGV.Columns[e.ColumnIndex].Name == "CostGapM3")
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("0.0%");
                }
            }
        }

        private void KMeansDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
