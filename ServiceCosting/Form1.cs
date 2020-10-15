using ServiceCosting.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using Excel = Microsoft.Office.Interop.Excel;

namespace ServiceCosting
{
    public partial class Form1 : Form
    {
        //property
        public int MinNodes { get; set; } //parameters
        public int MaxNodes { get; set; }


        public int IterationsCount = 1;

        //parameters
        public decimal TotalCpeTypesCost, TotalEthernetTypesCost, TotalEdgeTypesCost, TotalOptSwTypesCost, TotalCoreTypesCost, TotalGatewayTypesCost;
        public decimal TotalCpeTypesCapacity, TotalEthernetTypesCapacity, TotalEdgeTypesCapacity, TotalOptSwTypesCapacity, TotalCoreTypesCapacity, TotalGatewayTypesCapacity;

        List<InfrastructureCostModel> infraCostModelList = new List<InfrastructureCostModel>();
        List<ServiceCostModel> VpnCostModelList = new List<ServiceCostModel>();
        List<ServiceCostModel> EthernetCostModelList = new List<ServiceCostModel>();
        List<ServiceCostModel> TlsCostModelList = new List<ServiceCostModel>();
        List<ServiceCostModel> HsCostModelList = new List<ServiceCostModel>();

        List<M1Data> Data = new List<M1Data>();

        List<ServiceCostModel> VpnCostModelList2 = new List<ServiceCostModel>();
        List<ServiceCostModel> EthernetCostModelList2 = new List<ServiceCostModel>();
        List<ServiceCostModel> TlsCostModelList2 = new List<ServiceCostModel>();
        List<ServiceCostModel> HsCostModelList2 = new List<ServiceCostModel>();

        List<CostGapModel> VpnCostGapList = new List<CostGapModel>();
        List<CostGapModel> EthernetCostGapList = new List<CostGapModel>();
        List<CostGapModel> TlsCostGapList = new List<CostGapModel>();
        List<CostGapModel> HsCostGapList = new List<CostGapModel>();

        List<CostGapModel> VpnAverageCostGapList = new List<CostGapModel>();
        List<CostGapModel> EthernetAverageCostGapList = new List<CostGapModel>();
        List<CostGapModel> TlsAverageCostGapList = new List<CostGapModel>();
        List<CostGapModel> HsAverageCostGapList = new List<CostGapModel>();


        public Form1()
        {

            InitializeComponent();

            txtMinNodeSize.Select();


            txtCpePercent.Text = 15.ToString();
            txtEthernetPercent.Text = 13.ToString();
            txtEdgePercent.Text = 22.ToString();
            txtOptSwPercent.Text = 16.ToString();
            txtCorePercent.Text = 18.ToString();
            txtGatewayPercent.Text = 16.ToString();

            txtCpe1gbps.Text = 30.ToString();
            txtCpe10Gbps.Text = 70.ToString();
            txtCpe40gbps.Text = 0.ToString();
            txtCpe100Gbps.Text = 0.ToString();
            txtCpe140Gbps.Text = 0.ToString();

            txtEth1Gbps.Text = 0.ToString();
            txtEth10Gbps.Text = 40.ToString();
            txtEth40Gbps.Text = 35.ToString();
            txtEth100Gbps.Text = 25.ToString();
            txtEth140Gbps.Text = 0.ToString();

            txtEdge1Gbps.Text = 0.ToString();
            txtEdge10Gbps.Text = 10.ToString();
            txtEdge40Gbps.Text = 30.ToString();
            txtEdge100Gbps.Text = 60.ToString();
            txtEdge140Gbps.Text = 0.ToString();

            txtOptSw1Gbps.Text = 0.ToString();
            txtOptSw10Gbps.Text = 0.ToString();
            txtOptSw40Gbps.Text = 0.ToString();
            txtOptSw100Gbps.Text = 25.ToString();
            txtOptSw140Gbps.Text = 75.ToString();


            txtCore1Gbps.Text = 0.ToString();
            txtCore10Gbps.Text = 0.ToString();
            txtCore40Gbps.Text = 0.ToString();
            txtCore100Gbps.Text = 60.ToString();
            txtCore140Gbps.Text = 40.ToString();

            txtGw1Gbps.Text = 0.ToString();
            txtGw10Gbps.Text = 0.ToString();
            txtGw40Gbps.Text = 0.ToString();
            txtGw100Gbps.Text = 60.ToString();
            txtGw140Gbps.Text = 40.ToString();

            txtCpeMinPrice.Text = 3500.ToString();
            txtCpeMaxPrice.Text = 4500.ToString();
            txtEthernetMinPrice.Text = 125000.ToString();
            txtEthernetMaxPrice.Text = 175000.ToString();
            txtEdgeMinPrice.Text = 275000.ToString();
            txtEdgeMaxPrice.Text = 325000.ToString();
            txtOptSwMinPrice.Text = 700000.ToString();
            txtOptSwMaxPrice.Text = 750000.ToString();
            txtCoreMinPrice.Text = 350000.ToString();
            txtCoreMaxPrice.Text = 425000.ToString();
            txtGatewayMinPrice.Text = 300000.ToString();
            txtGatewayMaxPrice.Text = 350000.ToString();

            txtCpeLCMin.Text = 0.ToString();
            txtCpeLCMax.Text = 0.ToString();

            txtEthernetLCMin.Text = 6.ToString();
            txtEthernetLCMax.Text = 8.ToString();

            txtEdgeLCMin.Text = 8.ToString();
            txtEdgeLCMax.Text = 10.ToString();

            txtOptSwLCMin.Text = 10.ToString();
            txtOptSwLCMax.Text = 12.ToString();

            txtCoreLCMin.Text = 14.ToString();
            txtCoreLCMax.Text = 16.ToString();

            txtGatewayLCMin.Text = 6.ToString();
            txtGatewayLCMax.Text = 8.ToString();

            txtCpePortsMin.Text = 0.ToString();
            txtCpePortsMax.Text = 0.ToString();

            txtEthernetPortsMin.Text = 4.ToString();
            txtEthernetPortsMax.Text = 6.ToString();

            txtEdgePortsMin.Text = 6.ToString();
            txtEdgePortsMax.Text = 8.ToString();

            txtOptSwPortsMin.Text = 10.ToString();
            txtOptSwPortsMax.Text = 12.ToString();

            txtCorePortsMin.Text = 10.ToString();
            txtCorePortsMax.Text = 12.ToString();

            txtGatewayPortsMin.Text = 10.ToString();
            txtGatewayPortsMax.Text = 12.ToString();


            txtIPVPNPerc.Text = 60.ToString();
            txtEthPerc.Text = 45.ToString();
            txtTLSPerc.Text = 50.ToString();
            txtHSPerc.Text = 70.ToString();

            groupBox2.Visible = false;

            btnCalculateNetworkCost.Hide();
            btnM2.Hide();

        }

        private void txtMinNodeSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtMaxNodeSize_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            txtCpeMinPrice.KeyPress += ValidateKeyPress;
            txtEthernetMinPrice.KeyPress += ValidateKeyPress;
            txtEdgeMinPrice.KeyPress += ValidateKeyPress;
            txtOptSwMinPrice.KeyPress += ValidateKeyPress;
            txtCoreMinPrice.KeyPress += ValidateKeyPress;
            txtGatewayMinPrice.KeyPress += ValidateKeyPress;
            txtCpeMaxPrice.KeyPress += ValidateKeyPress;
            txtEthernetMaxPrice.KeyPress += ValidateKeyPress;
            txtEdgeMaxPrice.KeyPress += ValidateKeyPress;
            txtOptSwMaxPrice.KeyPress += ValidateKeyPress;
            txtCoreMaxPrice.KeyPress += ValidateKeyPress;
            txtGatewayMaxPrice.KeyPress += ValidateKeyPress;
            txtEthernetLCMin.KeyPress += ValidateKeyPress;
            txtEdgeLCMin.KeyPress += ValidateKeyPress;
            txtOptSwLCMin.KeyPress += ValidateKeyPress;
            txtCoreLCMin.KeyPress += ValidateKeyPress;
            txtGatewayLCMin.KeyPress += ValidateKeyPress;
            txtEthernetPortsMin.KeyPress += ValidateKeyPress;
            txtEdgePortsMin.KeyPress += ValidateKeyPress;
            txtOptSwPortsMin.KeyPress += ValidateKeyPress;
            txtCorePortsMin.KeyPress += ValidateKeyPress;
            txtGatewayPortsMin.KeyPress += ValidateKeyPress;
            txtCpePercent.KeyPress += ValidateKeyPress;
            txtEthernetPercent.KeyPress += ValidateKeyPress;
            txtEdgePercent.KeyPress += ValidateKeyPress;
            txtOptSwPercent.KeyPress += ValidateKeyPress;
            txtCorePercent.KeyPress += ValidateKeyPress;
            txtGatewayPercent.KeyPress += ValidateKeyPress;
            txtCpe1gbps.KeyPress += ValidateKeyPress;
            txtEth1Gbps.KeyPress += ValidateKeyPress;
            txtEdge1Gbps.KeyPress += ValidateKeyPress;
            txtOptSw1Gbps.KeyPress += ValidateKeyPress;
            txtCore1Gbps.KeyPress += ValidateKeyPress;
            txtGw1Gbps.KeyPress += ValidateKeyPress;
            txtCpe10Gbps.KeyPress += ValidateKeyPress;
            txtEth10Gbps.KeyPress += ValidateKeyPress;
            txtEdge10Gbps.KeyPress += ValidateKeyPress;
            txtOptSw10Gbps.KeyPress += ValidateKeyPress;
            txtCore10Gbps.KeyPress += ValidateKeyPress;
            txtGw10Gbps.KeyPress += ValidateKeyPress;
            txtCpe40gbps.KeyPress += ValidateKeyPress;
            txtEth40Gbps.KeyPress += ValidateKeyPress;
            txtEdge40Gbps.KeyPress += ValidateKeyPress;
            txtOptSw40Gbps.KeyPress += ValidateKeyPress;
            txtCore40Gbps.KeyPress += ValidateKeyPress;
            txtGw40Gbps.KeyPress += ValidateKeyPress;
            txtCpe100Gbps.KeyPress += ValidateKeyPress;
            txtEth100Gbps.KeyPress += ValidateKeyPress;
            txtEdge100Gbps.KeyPress += ValidateKeyPress;
            txtOptSw100Gbps.KeyPress += ValidateKeyPress;
            txtCore100Gbps.KeyPress += ValidateKeyPress;
            txtGw100Gbps.KeyPress += ValidateKeyPress;
            txtCpe140Gbps.KeyPress += ValidateKeyPress;
            txtEth140Gbps.KeyPress += ValidateKeyPress;
            txtEdge140Gbps.KeyPress += ValidateKeyPress;
            txtOptSw140Gbps.KeyPress += ValidateKeyPress;
            txtCore140Gbps.KeyPress += ValidateKeyPress;
            txtGw140Gbps.KeyPress += ValidateKeyPress;
            txtIPVPNPerc.KeyPress += ValidateKeyPress;
            txtEthPerc.KeyPress += ValidateKeyPress;
            txtTLSPerc.KeyPress += ValidateKeyPress;
            txtHSPerc.KeyPress += ValidateKeyPress;


        }

        private void ValidateKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar))
            {

                TextBox textBox = (TextBox)sender;

                if (textBox.Text.IndexOf('.') > -1 &&
                         textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }

            }


        }

        private void btnCalculateNetworkCost_Click(object sender, EventArgs e)
        {
            CalculateNetworkCost();

            InfrastructureCostForm infraCostForm = new InfrastructureCostForm(infraCostModelList);
            infraCostForm.infraCostModelList = infraCostModelList;


            DialogResult result = infraCostForm.ShowDialog();

            //dataGridView1.DataSource = infraCostModelList;
        }

        private void CalculateNetworkCost()
        {
            infraCostModelList.Clear();

            if (string.IsNullOrEmpty(txtMinNodeSize.Text) || string.IsNullOrEmpty(txtMaxNodeSize.Text))
            {
                MessageBox.Show("Please fill Min and Max Nodes used.");
                return;
            }

            Random random = new Random();
            int MinNodes = Convert.ToInt32(txtMinNodeSize.Text);
            int MaxNodes = Convert.ToInt32(txtMaxNodeSize.Text);

            for (int i = MinNodes; i <= MaxNodes; i += 5)
            {
                for (int z = 1; z <= IterationsCount; z++)
                {
                    int CpeNodes = (int)Math.Round(Convert.ToDecimal(txtCpePercent.Text) * i / 100);
                    int EthernetNodes = (int)Math.Round(Convert.ToDecimal(txtEthernetPercent.Text) * i / 100);
                    int EdgeNodes = (int)Math.Round(Convert.ToDecimal(txtEdgePercent.Text) * i / 100);
                    int OptSwNodes = (int)Math.Round(Convert.ToDecimal(txtOptSwPercent.Text) * i / 100);
                    int CoreNodes = (int)Math.Round(Convert.ToDecimal(txtCorePercent.Text) * i / 100);
                    //int GatewayNodes = (int)Math.Round(Convert.ToDecimal(txtGatewayPercent.Text) * i / 100);
                    int GatewayNodes = i - (CpeNodes + EthernetNodes + EdgeNodes + OptSwNodes + CoreNodes);


                    //random.Next((int)Math.Round(cpeMinPrice), (int)Math.Round(cpeMaxPrice));

                    decimal CpeRouterCost = random.Next((int)Math.Round(Convert.ToDecimal(txtCpeMinPrice.Text)), (int)Math.Round(Convert.ToDecimal(txtCpeMaxPrice.Text)));
                    decimal EthernetRouterCost = random.Next((int)Math.Round(Convert.ToDecimal(txtEthernetMinPrice.Text)), (int)Math.Round(Convert.ToDecimal(txtEthernetMaxPrice.Text)));
                    decimal EdgeRouterCost = random.Next((int)Math.Round(Convert.ToDecimal(txtEdgeMinPrice.Text)), (int)Math.Round(Convert.ToDecimal(txtEdgeMaxPrice.Text)));
                    decimal OptSwRouterCost = random.Next((int)Math.Round(Convert.ToDecimal(txtOptSwMinPrice.Text)), (int)Math.Round(Convert.ToDecimal(txtOptSwMaxPrice.Text)));
                    decimal CoreRouterCost = random.Next((int)Math.Round(Convert.ToDecimal(txtCoreMinPrice.Text)), (int)Math.Round(Convert.ToDecimal(txtCoreMaxPrice.Text)));
                    decimal GatewayRouterCost = random.Next((int)Math.Round(Convert.ToDecimal(txtGatewayMinPrice.Text)), (int)Math.Round(Convert.ToDecimal(txtGatewayMaxPrice.Text)));

                    //decimal CpeRouterCost = (Convert.ToDecimal(txtCpeMinPrice.Text) + Convert.ToDecimal(txtCpeMaxPrice.Text)) / 2;
                    //decimal EthernetRouterCost = (Convert.ToDecimal(txtEthernetMinPrice.Text) + Convert.ToDecimal(txtEthernetMaxPrice.Text)) / 2;
                    //decimal EdgeRouterCost = (Convert.ToDecimal(txtEdgeMinPrice.Text) + Convert.ToDecimal(txtEdgeMaxPrice.Text)) / 2;
                    //decimal OptSwRouterCost = (Convert.ToDecimal(txtOptSwMinPrice.Text) + Convert.ToDecimal(txtOptSwMaxPrice.Text)) / 2;
                    //decimal CoreRouterCost = (Convert.ToDecimal(txtCoreMinPrice.Text) + Convert.ToDecimal(txtCoreMaxPrice.Text)) / 2;
                    //decimal GatewayRouterCost = (Convert.ToDecimal(txtGatewayMinPrice.Text) + Convert.ToDecimal(txtGatewayMaxPrice.Text)) / 2;

                    decimal CpeInstallationCost = CpeRouterCost * 0.2m;
                    decimal EthernetInstallationCost = EthernetRouterCost * 0.2m;
                    decimal EdgeInstallationCost = EdgeRouterCost * 0.2m;
                    decimal OptSwInstallationCost = OptSwRouterCost * 0.2m;
                    decimal CoreInstallationCost = CoreRouterCost * 0.2m;
                    decimal GatewayInstallationCost = GatewayRouterCost * 0.2m;

                    decimal SingleCpeRouterCost = CpeRouterCost + CpeInstallationCost;
                    decimal SingleEthernetRouterCost = EthernetRouterCost + EthernetInstallationCost;
                    decimal SingleEdgeRouterCost = EdgeRouterCost + EdgeInstallationCost;
                    decimal SingleOptSwRouterCost = OptSwRouterCost + OptSwInstallationCost;
                    decimal SingleCoreRouterCost = CoreRouterCost + CoreInstallationCost;
                    decimal SingleGatewayRouterCost = GatewayRouterCost + GatewayInstallationCost;

                    decimal TotalCpeRoutersCost = CpeNodes * SingleCpeRouterCost;
                    decimal TotalEthernetRoutersCost = EthernetNodes * SingleEthernetRouterCost;
                    decimal TotalEdgeRoutersCost = EdgeNodes * SingleEdgeRouterCost;
                    decimal TotalOptSwRoutersCost = OptSwNodes * SingleOptSwRouterCost;
                    decimal TotalCoreRoutersCost = CoreNodes * SingleCoreRouterCost;
                    decimal TotalGatewayRoutersCost = GatewayNodes * SingleGatewayRouterCost;

                    //int CpePortsPerRouter = Convert.ToInt32(txtCpeLan.Text) * Convert.ToInt32(txtCpePorts.Text);


                    int EthLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtEthernetLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtEthernetLCMax.Text)));
                    int EthPorts = random.Next((int)Math.Round(Convert.ToDecimal(txtEthernetPortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtEthernetPortsMax.Text)));
                    int EthernetPortsPerRouter = EthLineCard * EthPorts;
                    //int EthernetPortsPerRouter = Convert.ToInt32(txtEthernetLCMin.Text) * Convert.ToInt32(txtEthernetPortsMin.Text);

                    // int EdgePortsPerRouter = Convert.ToInt32(txtEdgeLCMin.Text) * Convert.ToInt32(txtEdgePortsMin.Text);
                    int EdgeLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtEdgeLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtEdgeLCMax.Text)));
                    int EdgePorts = random.Next((int)Math.Round(Convert.ToDecimal(txtEdgePortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtEdgePortsMax.Text)));
                    int EdgePortsPerRouter = EdgeLineCard * EdgePorts;

                    //int OptSwPortsPerRouter = Convert.ToInt32(txtOptSwLCMin.Text) * Convert.ToInt32(txtOptSwPortsMin.Text);
                    int OptSwLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtOptSwLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtOptSwLCMax.Text)));
                    int OptSwPorts = random.Next((int)Math.Round(Convert.ToDecimal(txtOptSwPortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtOptSwPortsMax.Text)));
                    int OptSwPortsPerRouter = OptSwLineCard * OptSwPorts;

                    //int CorePortsPerRouter = Convert.ToInt32(txtCoreLan.Text) * Convert.ToInt32(txtCorePorts.Text);
                    int CoreLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtCoreLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtCoreLCMax.Text)));
                    int CorePorts = random.Next((int)Math.Round(Convert.ToDecimal(txtCorePortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtCorePortsMax.Text)));
                    int CorePortsPerRouter = CoreLineCard * CorePorts;

                    //int GatewayPortsPerRouter = Convert.ToInt32(txtGatewayLCMin.Text) * Convert.ToInt32(txtGatewayPortsMin.Text);
                    int GatewayLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtGatewayLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtGatewayLCMax.Text)));
                    int GatewayPorts = random.Next((int)Math.Round(Convert.ToDecimal(txtGatewayPortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtGatewayPortsMax.Text)));
                    int GatewayPortsPerRouter = GatewayLineCard * GatewayPorts;

                    //decimal CpeCapacityPerRouter = CpePortsPerRouter * 10;
                    int Cpe1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCpe1gbps.Text)) * CpeNodes / 100;
                    // int Cpe1gbpsPortsUsed = CpeNodes * (30 / 100);
                    int Cpe10gbpsPortsUsed = CpeNodes - Cpe1gbpsPortsUsed;
                    int Cpe40gbpsPortsUsed = 0;
                    int Cpe100gbpsPortsUsed = 0;
                    int Cpe140gbpsPortsUsed = 0;
                    decimal CpeCapacityPerRouter = CalculateCapacityPerRouter(CpeNodes, Cpe1gbpsPortsUsed, Cpe10gbpsPortsUsed, Cpe40gbpsPortsUsed, Cpe100gbpsPortsUsed, Cpe140gbpsPortsUsed);

                    //decimal EthernetCapacityPerRouter = EthernetPortsPerRouter * 10;
                    int Eth1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth1Gbps.Text)) * EthernetPortsPerRouter / 100;
                    int Eth10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth10Gbps.Text)) * EthernetPortsPerRouter / 100;
                    int Eth40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth40Gbps.Text)) * EthernetPortsPerRouter / 100;
                    //int Eth100gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth100Gbps.Text)) * EthernetPortsPerRouter / 100;
                    int Eth140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth140Gbps.Text)) * EthernetPortsPerRouter / 100;
                    int Eth100gbpsPortsUsed = EthernetPortsPerRouter - (Eth1gbpsPortsUsed + Eth10gbpsPortsUsed + Eth40gbpsPortsUsed + Eth140gbpsPortsUsed);
                    decimal EthernetCapacityPerRouter = CalculateCapacityPerRouter(EthernetPortsPerRouter, Eth1gbpsPortsUsed, Eth10gbpsPortsUsed, Eth40gbpsPortsUsed, Eth100gbpsPortsUsed, Eth140gbpsPortsUsed);

                    //decimal EdgeCapacityPerRouter = EdgePortsPerRouter * 10;
                    int Edge1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge1Gbps.Text)) * EdgePortsPerRouter / 100;
                    int Edge10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge10Gbps.Text)) * EdgePortsPerRouter / 100;
                    int Edge40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge40Gbps.Text)) * EdgePortsPerRouter / 100;
                    //int Edge100gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge100Gbps.Text)) * EdgePortsPerRouter / 100;
                    int Edge140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge140Gbps.Text)) * EdgePortsPerRouter / 100;
                    int Edge100gbpsPortsUsed = EdgePortsPerRouter - (Edge1gbpsPortsUsed + Edge10gbpsPortsUsed + Edge40gbpsPortsUsed + Edge140gbpsPortsUsed);
                    decimal EdgeCapacityPerRouter = CalculateCapacityPerRouter(EdgePortsPerRouter, Edge1gbpsPortsUsed, Edge10gbpsPortsUsed, Edge40gbpsPortsUsed, Edge100gbpsPortsUsed, Edge140gbpsPortsUsed);

                    //decimal OptSwCapacityPerRouter = OptSwPortsPerRouter * 10;
                    int OptSw1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw1Gbps.Text)) * OptSwPortsPerRouter / 100;
                    int OptSw10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw10Gbps.Text)) * OptSwPortsPerRouter / 100;
                    int OptSw40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw40Gbps.Text)) * OptSwPortsPerRouter / 100;
                    //int OptSw100gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw100Gbps.Text)) * OptSwPortsPerRouter / 100;
                    int OptSw140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw140Gbps.Text)) * OptSwPortsPerRouter / 100;
                    int OptSw100gbpsPortsUsed = OptSwPortsPerRouter - (OptSw1gbpsPortsUsed + OptSw10gbpsPortsUsed + OptSw40gbpsPortsUsed + OptSw140gbpsPortsUsed);
                    decimal OptSwCapacityPerRouter = CalculateCapacityPerRouter(OptSwPortsPerRouter, OptSw1gbpsPortsUsed, OptSw10gbpsPortsUsed, OptSw40gbpsPortsUsed, OptSw100gbpsPortsUsed, OptSw140gbpsPortsUsed);

                    //decimal CoreCapacityPerRouter = CorePortsPerRouter * 10;
                    int Core1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore1Gbps.Text)) * CorePortsPerRouter / 100;
                    int Core10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore10Gbps.Text)) * CorePortsPerRouter / 100;
                    int Core40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore40Gbps.Text)) * CorePortsPerRouter / 100;
                    //int Core100gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore100Gbps.Text)) * CorePortsPerRouter / 100;
                    int Core140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore140Gbps.Text)) * CorePortsPerRouter / 100;
                    int Core100gbpsPortsUsed = CorePortsPerRouter - (Core1gbpsPortsUsed + Core10gbpsPortsUsed + Core40gbpsPortsUsed + Core140gbpsPortsUsed);
                    decimal CoreCapacityPerRouter = CalculateCapacityPerRouter(CorePortsPerRouter, Core1gbpsPortsUsed, Core10gbpsPortsUsed, Core40gbpsPortsUsed, Core100gbpsPortsUsed, Core140gbpsPortsUsed);

                    //decimal GatewayCapacityPerRouter = GatewayPortsPerRouter * 10;
                    int GW1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw1Gbps.Text)) * GatewayPortsPerRouter / 100;
                    int GW10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw10Gbps.Text)) * GatewayPortsPerRouter / 100;
                    int GW40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw40Gbps.Text)) * GatewayPortsPerRouter / 100;
                    //int GW100gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw100Gbps.Text)) * GatewayPortsPerRouter / 100;
                    int GW140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw140Gbps.Text)) * GatewayPortsPerRouter / 100;
                    int GW100gbpsPortsUsed = GatewayPortsPerRouter - (GW1gbpsPortsUsed + GW10gbpsPortsUsed + GW40gbpsPortsUsed + GW140gbpsPortsUsed);
                    decimal GatewayCapacityPerRouter = CalculateCapacityPerRouter(GatewayPortsPerRouter, GW1gbpsPortsUsed, GW10gbpsPortsUsed, GW40gbpsPortsUsed, GW100gbpsPortsUsed, GW140gbpsPortsUsed);



                    decimal CpeTotalCapacity = CpeCapacityPerRouter * CpeNodes;
                    decimal EthernetTotalCapacity = EthernetCapacityPerRouter * EthernetNodes;
                    decimal EdgeTotalCapacity = EdgeCapacityPerRouter * EdgeNodes;
                    decimal OptSwTotalCapacity = OptSwCapacityPerRouter * OptSwNodes;
                    decimal CoreTotalCapacity = CoreCapacityPerRouter * CoreNodes;
                    decimal GatewayTotalCapacity = GatewayCapacityPerRouter * GatewayNodes;



                    InfrastructureCostModel infraCostModel = new InfrastructureCostModel();
                    infraCostModel.NoOfNodes = i;
                    infraCostModel.IterationCount = z;
                    infraCostModel.TotalNetworkCapacity = CpeTotalCapacity + EthernetTotalCapacity + EdgeTotalCapacity + OptSwTotalCapacity + CoreTotalCapacity + GatewayTotalCapacity;
                    infraCostModel.TotalNetworkCost = TotalCpeRoutersCost + TotalEthernetRoutersCost + TotalEdgeRoutersCost + TotalOptSwRoutersCost + TotalCoreRoutersCost + TotalGatewayRoutersCost;
                    infraCostModel.NetworkUnitCost = (decimal)(infraCostModel.TotalNetworkCost / infraCostModel.TotalNetworkCapacity);

                    infraCostModelList.Add(infraCostModel);
                }

            }


        }

        private void btnCalculateService_Click(object sender, EventArgs e)
        {
            ClearAllLists();
            //nfraCostModelList.Clear();

            if (string.IsNullOrEmpty(txtMinNodeSize.Text) || string.IsNullOrEmpty(txtMaxNodeSize.Text))
            {
                MessageBox.Show("Please fill Min and Max Nodes used.");
                return;
            }
            if ((Convert.ToInt32(txtMinNodeSize.Text) < 25) || (Convert.ToInt32(txtMaxNodeSize.Text) < 25))
            {
                MessageBox.Show("Node size must be greater and equal to 25");
                return;
            }

            int MinNodesSizeCheck = Convert.ToInt32(txtMinNodeSize.Text);
            int MaxNodesSizeCheck = Convert.ToInt32(txtMaxNodeSize.Text);
            if (MaxNodesSizeCheck < MinNodesSizeCheck)
            {
                MessageBox.Show("Min Nodes cannot be greater than Max Nodes");

                int check = Convert.ToInt32(txtCpePercent.Text) + Convert.ToInt32(txtEthernetPercent.Text) + Convert.ToInt32(txtEdgePercent.Text) + Convert.ToInt32(txtOptSwPercent.Text) + Convert.ToInt32(txtCorePercent.Text) + Convert.ToInt32(txtGatewayPercent.Text);
                if (check != 100)
                {
                    MessageBox.Show("Sum of Percentage of nodes is not 100%");
                }
            }
            else
            {
                CalculateNetworkCost();

                CalculateServiceCostM1();

                CalculateServiceCostM2();

                CalculateCostGap();
                CalculateAverageCostGap();

                List<CostGapModel> VpnCostGapAverageList = new List<CostGapModel>();


                //ServicesCostForm servicesCostForm = new ServicesCostForm(infraCostModelList, VpnCostModelList, EthernetCostModelList, TlsCostModelList, HsCostModelList,
                //	VpnCostModelList2, EthernetCostModelList2, TlsCostModelList2, HsCostModelList2, VpnCostGapList, EthernetCostGapList, TlsCostGapList, HsCostGapList);

                ServicesCostForm servicesCostForm = new ServicesCostForm(infraCostModelList, VpnCostModelList, EthernetCostModelList, TlsCostModelList, HsCostModelList,
                    VpnCostModelList2, EthernetCostModelList2, TlsCostModelList2, HsCostModelList2, VpnAverageCostGapList, EthernetAverageCostGapList, TlsAverageCostGapList, HsAverageCostGapList, Data);

                DialogResult result = servicesCostForm.ShowDialog();
            }
        }

        private void ClearAllLists()
        {
            Data.Clear();
            infraCostModelList.Clear();

            VpnCostModelList.Clear();
            EthernetCostModelList.Clear();
            TlsCostModelList.Clear();
            HsCostModelList.Clear();

            VpnCostModelList2.Clear();
            EthernetCostModelList2.Clear();
            TlsCostModelList2.Clear();
            HsCostModelList2.Clear();

            VpnAverageCostGapList.Clear();
            EthernetAverageCostGapList.Clear();
            TlsAverageCostGapList.Clear();
            HsAverageCostGapList.Clear();

        }

        private void btnAppClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateCostGap()
        {
            CalculateCostGapForService(VpnCostModelList, VpnCostModelList2, VpnCostGapList);
            CalculateCostGapForService(EthernetCostModelList, EthernetCostModelList2, EthernetCostGapList);
            CalculateCostGapForService(TlsCostModelList, TlsCostModelList2, TlsCostGapList);
            CalculateCostGapForService(HsCostModelList, HsCostModelList2, HsCostGapList);
        }

        private void CalculateCostGapForService(List<ServiceCostModel> M1List, List<ServiceCostModel> M2List, List<CostGapModel> costGapList)
        {
            for (int node = MinNodes; node <= MaxNodes; node += 5)
            {
                for (int z = 1; z <= IterationsCount; z++)
                {
                    var costGap = new CostGapModel();


                    costGap.NoOfNodes = node;
                    //costGap.IterationCount = z;
                    //costGap.TotalNetworkUnitCost = infraCostModelList.FirstOrDefault(x => x.NoOfNodes == node && x.IterationCount == z).NetworkUnitCost;
                    costGap.NoOfUsedNodes = M1List.FirstOrDefault(x => x.NoOfNodes == node && x.IterationCount == z).NoOfUsedNodes;
                    costGap.M1UnitCost = M1List.FirstOrDefault(x => x.NoOfNodes == node && x.IterationCount == z).NetworkUnitCost;
                    costGap.M2UnitCost = M2List.FirstOrDefault(x => x.NoOfNodes == node && x.IterationCount == z).NetworkUnitCost;
                    //costGap.M1CostGap = ((costGap.M1UnitCost - costGap.TotalNetworkUnitCost) / costGap.TotalNetworkUnitCost) * 100;
                    //costGap.M2CostGap = ((costGap.M2UnitCost - costGap.TotalNetworkUnitCost) / costGap.TotalNetworkUnitCost) * 100;
                    //costGap.TotalNetworkCostGap = ((costGap.M1UnitCost - costGap.TotalNetworkUnitCost) / costGap.M1UnitCost);

                    //costGap.M2CostGap = ((costGap.M1UnitCost - costGap.M2UnitCost) / costGap.M1UnitCost);
                    costGap.M2CostGap = costGap.M1UnitCost != 0 ? ((costGap.M1UnitCost - costGap.M2UnitCost) / costGap.M1UnitCost) : 0;


                    costGapList.Add(costGap);
                }

            }
        }

        private void CalculateAverageCostGap()
        {
            CalculateAverageCostGapForService(VpnCostGapList, VpnAverageCostGapList);
            CalculateAverageCostGapForService(EthernetCostGapList, EthernetAverageCostGapList);
            CalculateAverageCostGapForService(TlsCostGapList, TlsAverageCostGapList);
            CalculateAverageCostGapForService(HsCostGapList, HsAverageCostGapList);
        }

        private void CalculateAverageCostGapForService(List<CostGapModel> costGapList, List<CostGapModel> AveragecostGapList)
        {
            for (int node = MinNodes; node <= MaxNodes; node += 5)
            {
                var costGap = new CostGapModel();

                costGap.NoOfNodes = node;
                //costGap.TotalNetworkUnitCost = costGapList.Where(x => x.NoOfNodes == node).Average(x => x.TotalNetworkUnitCost);
                costGap.NoOfUsedNodes = (int)costGapList.Where(x => x.NoOfNodes == node).Average(x => x.NoOfUsedNodes);
                costGap.M1UnitCost = costGapList.Where(x => x.NoOfNodes == node).Average(x => x.M1UnitCost);
                costGap.M2UnitCost = costGapList.Where(x => x.NoOfNodes == node).Average(x => x.M2UnitCost);
                //costGap.M1CostGap = ((costGap.M1UnitCost - costGap.TotalNetworkUnitCost) / costGap.TotalNetworkUnitCost) * 100;
                //costGap.M2CostGap = ((costGap.M2UnitCost - costGap.TotalNetworkUnitCost) / costGap.TotalNetworkUnitCost) * 100;
                //costGap.TotalNetworkCostGap = costGapList.Where(x => x.NoOfNodes == node).Average(x => x.TotalNetworkCostGap);
                costGap.M2CostGap = costGapList.Where(x => x.NoOfNodes == node).Average(x => x.M2CostGap);

                AveragecostGapList.Add(costGap);
            }
        }


        private void CalculateServiceCostM1()
        {
            //Calculate Vpn Cost
            var vpn = Convert.ToDecimal(txtIPVPNPerc.Text);
            decimal x = vpn / (Convert.ToDecimal(txtCpePercent.Text) + Convert.ToDecimal(txtEdgePercent.Text) + Convert.ToDecimal(txtOptSwPercent.Text) + Convert.ToDecimal(txtCorePercent.Text));
            decimal CpePercent = Convert.ToDecimal(txtCpePercent.Text) * x;
            decimal EthernetPercent = 0;
            decimal EdgePercent = Convert.ToDecimal(txtEdgePercent.Text) * x;
            decimal OptPercent = Convert.ToDecimal(txtOptSwPercent.Text) * x;
            decimal CorePercent = Convert.ToDecimal(txtCorePercent.Text) * x;
            decimal GatewayPercent = 0;
            CalculateServiceCost(CpePercent, EthernetPercent, EdgePercent, OptPercent, CorePercent, GatewayPercent, VpnCostModelList, vpn, "VPN");

            // Calculate Ethernet Cost
            var eth = Convert.ToDecimal(txtEthPerc.Text);
            x = eth / (Convert.ToDecimal(txtCpePercent.Text) + Convert.ToDecimal(txtEthernetPercent.Text) + Convert.ToDecimal(txtOptSwPercent.Text));
            CpePercent = Convert.ToDecimal(txtCpePercent.Text) * x;
            EthernetPercent = Convert.ToDecimal(txtEthernetPercent.Text) * x;
            EdgePercent = 0;
            OptPercent = Convert.ToDecimal(txtOptSwPercent.Text) * x;
            CorePercent = 0;
            GatewayPercent = 0;
            CalculateServiceCost(CpePercent, EthernetPercent, EdgePercent, OptPercent, CorePercent, GatewayPercent, EthernetCostModelList, eth, "ETH");


            // Calculate TLS Cost
            var tls = Convert.ToDecimal(txtTLSPerc.Text);
            x = tls / (Convert.ToDecimal(txtCpePercent.Text) + Convert.ToDecimal(txtEdgePercent.Text) + Convert.ToDecimal(txtOptSwPercent.Text));
            //x = tls / (Convert.ToDecimal(txtCpePercent.Text)  + Convert.ToDecimal(txtOptSwPercent.Text));
            CpePercent = Convert.ToDecimal(txtCpePercent.Text) * x;
            EthernetPercent = 0;
            EdgePercent = Convert.ToDecimal(txtEdgePercent.Text) * x;
            //EdgePercent = 0;
            OptPercent = Convert.ToDecimal(txtOptSwPercent.Text) * x;
            CorePercent = 0;
            GatewayPercent = 0;
            CalculateServiceCost(CpePercent, EthernetPercent, EdgePercent, OptPercent, CorePercent, GatewayPercent, TlsCostModelList, tls, "TLS");


            // Calculate HS Cost
            var hs = Convert.ToDecimal(txtHSPerc.Text);
            x = hs / (Convert.ToDecimal(txtCpePercent.Text) + Convert.ToDecimal(txtEdgePercent.Text) + Convert.ToDecimal(txtOptSwPercent.Text) + Convert.ToDecimal(txtCorePercent.Text) + Convert.ToDecimal(txtGatewayPercent.Text));
            CpePercent = Convert.ToDecimal(txtCpePercent.Text) * x;
            EthernetPercent = 0;
            EdgePercent = Convert.ToDecimal(txtEdgePercent.Text) * x;
            OptPercent = Convert.ToDecimal(txtOptSwPercent.Text) * x;
            CorePercent = Convert.ToDecimal(txtCorePercent.Text) * x;
            GatewayPercent = Convert.ToDecimal(txtGatewayPercent.Text) * x;
            CalculateServiceCost(CpePercent, EthernetPercent, EdgePercent, OptPercent, CorePercent, GatewayPercent, HsCostModelList, hs, "HS");


        }

        private void btnM2_Click(object sender, EventArgs e)
        {
            CalculateServiceCostM2();
        }





        private void CalculateServiceCost(decimal CpePercent, decimal EthernetPercent, decimal EdgePercent, decimal OptPercent,
        decimal CorePercent, decimal GatewayPercent, List<ServiceCostModel> serviceCostModelList, decimal x, string name)
        {
            Random random = new Random(new System.DateTime().Millisecond);

            M1Data m1Data = new M1Data();
            m1Data.ServiceName = name;

            MinNodes = Convert.ToInt32(txtMinNodeSize.Text);
            MaxNodes = Convert.ToInt32(txtMaxNodeSize.Text);

            for (int i = MinNodes; i <= MaxNodes; i += 5)
            {
                for (int z = 1; z <= IterationsCount; z++)
                {
                    Thread.Sleep(1);
                    RouterBasedData routerData = new RouterBasedData();
                    m1Data.RoutersData.Add(routerData);

                    routerData.Node = i;
                    routerData.IterationNo = z;

                    var totalPercent = i * x / 100;
                    int EthernetNodes = (int)Math.Floor(EthernetPercent * i / 100);
                    int EdgeNodes = (int)Math.Floor(EdgePercent * i / 100);
                    int OptSwNodes = (int)Math.Round(OptPercent * i / 100);
                    int CoreNodes = (int)Math.Round(CorePercent * i / 100);
                    int GatewayNodes = (int)Math.Floor(GatewayPercent * i / 100);
                    // int CpeNodes = (int)Math.Floor(CpePercent * i / 100);
                    int CpeNodes = (int)totalPercent - (GatewayNodes + EthernetNodes + EdgeNodes + OptSwNodes + CoreNodes);
                    //int GatewayNodes = (int)totalPercent - (CpeNodes + EthernetNodes + EdgeNodes + OptSwNodes + CoreNodes);

                    //int EthernetNodes = (int)Math.Round(EthernetPercent * i / 100);
                    //int EdgeNodes = (int)Math.Round(EdgePercent * i / 100);
                    //int OptSwNodes = (int)Math.Round(OptPercent * i / 100);
                    //int CoreNodes = (int)Math.Round(CorePercent * i / 100);
                    //int GatewayNodes = (int)Math.Round(GatewayPercent * i / 100);
                    //int CpeNodes = (int)totalPercent - (GatewayNodes + EthernetNodes + EdgeNodes + OptSwNodes + CoreNodes);
                    ////int GatewayNodes = (int)totalPercent - (CpeNodes + EthernetNodes + EdgeNodes + OptSwNodes + CoreNodes);


                    //details.CpeRDetails = new List<Detail>();


                    //Random random = new Random();

                    decimal TotalCpeRoutersCost = 0;
                    decimal CpeTotalCapacity = 0;
                    var cpeMinPrice = Convert.ToDecimal(txtCpeMinPrice.Text);
                    var cpeMaxPrice = Convert.ToDecimal(txtCpeMaxPrice.Text);


                    for (int j = 1; j <= CpeNodes; j++)
                    {

                        decimal CpeRouterCost = random.Next((int)Math.Round(cpeMinPrice), (int)Math.Round(cpeMaxPrice));
                        decimal CpeInstallationCost = CpeRouterCost * 0.2m;
                        decimal SingleCpeRouterCost = CpeRouterCost + CpeInstallationCost;
                        TotalCpeRoutersCost = TotalCpeRoutersCost + SingleCpeRouterCost;

                        decimal ThirtyPercentOfCpeNodes = CpeNodes * 30 / 100;

                        decimal CpeCapacityPerRouter;
                        if (j <= ThirtyPercentOfCpeNodes)
                        {
                            CpeCapacityPerRouter = 1;
                        }
                        else
                        {
                            CpeCapacityPerRouter = 10;
                        }

                        CpeTotalCapacity = CpeTotalCapacity + CpeCapacityPerRouter;

                        routerData.CpeRDetails.Add(new Detail { RouterCost = CpeRouterCost, CapacityPerRouter = CpeCapacityPerRouter });

                    }


                    decimal TotalEthernetRoutersCost = 0;
                    decimal EthernetTotalCapacity = 0;

                    for (int j = 1; j <= EthernetNodes; j++)
                    {
                        var ethernetMinPrice = Convert.ToDecimal(txtEthernetMinPrice.Text);
                        var ethernetMaxPrice = Convert.ToDecimal(txtEthernetMaxPrice.Text);
                        decimal EthernetRouterCost = random.Next((int)Math.Round(ethernetMinPrice), (int)Math.Round(ethernetMaxPrice));
                        decimal EthernetInstallationCost = EthernetRouterCost * 0.2m;
                        decimal SingleEthernetRouterCost = EthernetRouterCost + EthernetInstallationCost;
                        TotalEthernetRoutersCost = TotalEthernetRoutersCost + SingleEthernetRouterCost;

                        //int EthLineCard = random.Next(6, 8);
                        //int EthPorts = random.Next(4, 6);
                        //int EthernetPortsPerRouter = EthLineCard * EthPorts;
                        int EthLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtEthernetLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtEthernetLCMax.Text)));
                        int EthPorts = random.Next((int)Math.Round(Convert.ToDecimal(txtEthernetPortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtEthernetPortsMax.Text)));
                        int EthernetPortsPerRouter = EthLineCard * EthPorts;

                        //decimal EthernetCapacityPerRouter = EthernetPortsPerRouter * 10;
                        int Eth1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth1Gbps.Text)) * EthernetPortsPerRouter / 100;
                        int Eth10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth10Gbps.Text)) * EthernetPortsPerRouter / 100;
                        int Eth40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth40Gbps.Text)) * EthernetPortsPerRouter / 100;
                        int Eth140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEth140Gbps.Text)) * EthernetPortsPerRouter / 100;
                        int Eth100gbpsPortsUsed = EthernetPortsPerRouter - (Eth1gbpsPortsUsed + Eth10gbpsPortsUsed + Eth40gbpsPortsUsed + Eth140gbpsPortsUsed);
                        decimal EthernetCapacityPerRouter = CalculateCapacityPerRouter(EthernetPortsPerRouter, Eth1gbpsPortsUsed, Eth10gbpsPortsUsed, Eth40gbpsPortsUsed, Eth100gbpsPortsUsed, Eth140gbpsPortsUsed);
                        EthernetTotalCapacity = EthernetTotalCapacity + EthernetCapacityPerRouter;

                        routerData.EthRDetails.Add(new Detail { RouterCost = EthernetRouterCost, CapacityPerRouter = EthernetCapacityPerRouter });
                    }

                    decimal TotalEdgeRoutersCost = 0;
                    decimal EdgeTotalCapacity = 0;
                    for (int j = 1; j <= EdgeNodes; j++)
                    {
                        var edgeMinPrice = Convert.ToDecimal(txtEdgeMinPrice.Text);
                        var edgeMaxPrice = Convert.ToDecimal(txtEdgeMaxPrice.Text);
                        decimal EdgeRouterCost = random.Next((int)Math.Round(edgeMinPrice), (int)Math.Round(edgeMaxPrice));
                        decimal EdgeInstallationCost = EdgeRouterCost * 0.2m;
                        decimal SingleEdgeRouterCost = EdgeRouterCost + EdgeInstallationCost;
                        TotalEdgeRoutersCost = TotalEdgeRoutersCost + SingleEdgeRouterCost;

                        //int EdgeLineCard = random.Next(8, 10);
                        //int EdgePorts = random.Next(6, 8);
                        //int EdgePortsPerRouter = EdgeLineCard * EdgePorts;
                        int EdgeLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtEdgeLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtEdgeLCMax.Text)));
                        int EdgePorts = random.Next((int)Math.Round(Convert.ToDecimal(txtEdgePortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtEdgePortsMax.Text)));
                        int EdgePortsPerRouter = EdgeLineCard * EdgePorts;

                        //decimal EdgeCapacityPerRouter = EdgePortsPerRouter * 10;
                        int Edge1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge1Gbps.Text)) * EdgePortsPerRouter / 100;
                        int Edge10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge10Gbps.Text)) * EdgePortsPerRouter / 100;
                        int Edge40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge40Gbps.Text)) * EdgePortsPerRouter / 100;
                        int Edge140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge140Gbps.Text)) * EdgePortsPerRouter / 100;
                        //int Edge100gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtEdge100Gbps.Text)) * EdgePortsPerRouter / 100;
                        int Edge100gbpsPortsUsed = EdgePortsPerRouter - (Edge1gbpsPortsUsed + Edge10gbpsPortsUsed + Edge40gbpsPortsUsed + Edge140gbpsPortsUsed);
                        decimal EdgeCapacityPerRouter = CalculateCapacityPerRouter(EdgePortsPerRouter, Edge1gbpsPortsUsed, Edge10gbpsPortsUsed, Edge40gbpsPortsUsed, Edge100gbpsPortsUsed, Edge140gbpsPortsUsed);
                        EdgeTotalCapacity = EdgeTotalCapacity + EdgeCapacityPerRouter;

                        routerData.EdgeRDetails.Add(new Detail { RouterCost = EdgeRouterCost, CapacityPerRouter = EdgeCapacityPerRouter });
                    }

                    decimal TotalOptSwRoutersCost = 0;
                    decimal OptSwTotalCapacity = 0;
                    for (int j = 1; j <= OptSwNodes; j++)
                    {
                        var OptSwMinPrice = Convert.ToDecimal(txtOptSwMinPrice.Text);
                        var OptSwMaxPrice = Convert.ToDecimal(txtOptSwMaxPrice.Text);
                        decimal OptSwRouterCost = random.Next((int)Math.Round(OptSwMinPrice), (int)Math.Round(OptSwMaxPrice));
                        decimal OptSwInstallationCost = OptSwRouterCost * 0.2m;
                        decimal SingleOptSwRouterCost = OptSwRouterCost + OptSwInstallationCost;
                        TotalOptSwRoutersCost = TotalOptSwRoutersCost + SingleOptSwRouterCost;

                        //int OptSwLineCard = random.Next(10, 12);
                        //int OptSwPorts = random.Next(10, 12);
                        //int OptSwPortsPerRouter = OptSwLineCard * OptSwPorts;
                        int OptSwLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtOptSwLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtOptSwLCMax.Text)));
                        int OptSwPorts = random.Next((int)Math.Round(Convert.ToDecimal(txtOptSwPortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtOptSwPortsMax.Text)));
                        int OptSwPortsPerRouter = OptSwLineCard * OptSwPorts;

                        //decimal OptSwCapacityPerRouter = OptSwPortsPerRouter * 10;
                        int OptSw1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw1Gbps.Text)) * OptSwPortsPerRouter / 100;
                        int OptSw10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw10Gbps.Text)) * OptSwPortsPerRouter / 100;
                        int OptSw40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw40Gbps.Text)) * OptSwPortsPerRouter / 100;
                        int OptSw140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtOptSw140Gbps.Text)) * OptSwPortsPerRouter / 100;
                        int OptSw100gbpsPortsUsed = OptSwPortsPerRouter - (OptSw1gbpsPortsUsed + OptSw10gbpsPortsUsed + OptSw40gbpsPortsUsed + OptSw140gbpsPortsUsed);


                        decimal OptSwCapacityPerRouter = CalculateCapacityPerRouter(OptSwPortsPerRouter, OptSw1gbpsPortsUsed, OptSw10gbpsPortsUsed, OptSw40gbpsPortsUsed, OptSw100gbpsPortsUsed, OptSw140gbpsPortsUsed);
                        OptSwTotalCapacity = OptSwTotalCapacity + OptSwCapacityPerRouter;

                        routerData.OptSwRDetails.Add(new Detail { RouterCost = OptSwRouterCost, CapacityPerRouter = OptSwCapacityPerRouter });
                    }

                    decimal TotalCoreRoutersCost = 0;
                    decimal CoreTotalCapacity = 0;
                    for (int j = 1; j <= CoreNodes; j++)
                    {
                        var CoreMinPrice = Convert.ToDecimal(txtCoreMinPrice.Text);
                        var CoreMaxPrice = Convert.ToDecimal(txtCoreMaxPrice.Text);
                        decimal CoreRouterCost = random.Next((int)Math.Round(CoreMinPrice), (int)Math.Round(CoreMaxPrice));
                        decimal CoreInstallationCost = CoreRouterCost * 0.2m;
                        decimal SingleCoreRouterCost = CoreRouterCost + CoreInstallationCost;
                        TotalCoreRoutersCost = TotalCoreRoutersCost + SingleCoreRouterCost;

                        //int CoreLineCard = random.Next(14, 16);
                        //int CorePorts = random.Next(10, 12);
                        //int CorePortsPerRouter = CoreLineCard * CorePorts;
                        int CoreLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtCoreLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtCoreLCMax.Text)));
                        int CorePorts = random.Next((int)Math.Round(Convert.ToDecimal(txtCorePortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtCorePortsMax.Text)));
                        int CorePortsPerRouter = CoreLineCard * CorePorts;

                        //decimal CoreCapacityPerRouter = CorePortsPerRouter * 10;
                        int Core1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore1Gbps.Text)) * CorePortsPerRouter / 100;
                        int Core10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore10Gbps.Text)) * CorePortsPerRouter / 100;
                        int Core40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore40Gbps.Text)) * CorePortsPerRouter / 100;
                        int Core140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtCore140Gbps.Text)) * CorePortsPerRouter / 100;
                        int Core100gbpsPortsUsed = CorePortsPerRouter - (Core1gbpsPortsUsed + Core10gbpsPortsUsed + Core40gbpsPortsUsed + Core140gbpsPortsUsed);

                        decimal CoreCapacityPerRouter = CalculateCapacityPerRouter(CorePortsPerRouter, Core1gbpsPortsUsed, Core10gbpsPortsUsed, Core40gbpsPortsUsed, Core100gbpsPortsUsed, Core140gbpsPortsUsed);
                        CoreTotalCapacity = CoreTotalCapacity + CoreCapacityPerRouter;

                        routerData.CoreRDetails.Add(new Detail { RouterCost = CoreRouterCost, CapacityPerRouter = CoreCapacityPerRouter });
                    }

                    decimal TotalGatewayRoutersCost = 0;
                    decimal GatewayTotalCapacity = 0;
                    for (int j = 1; j <= GatewayNodes; j++)
                    {
                        var GWMinPrice = Convert.ToDecimal(txtGatewayMinPrice.Text);
                        var GWMaxPrice = Convert.ToDecimal(txtGatewayMaxPrice.Text);
                        decimal GatewayRouterCost = random.Next((int)Math.Round(GWMinPrice), (int)Math.Round(GWMaxPrice));
                        decimal GatewayInstallationCost = GatewayRouterCost * 0.2m;
                        decimal SingleGatewayRouterCost = GatewayRouterCost + GatewayInstallationCost;
                        TotalGatewayRoutersCost = TotalGatewayRoutersCost + SingleGatewayRouterCost;

                        //int gwLineCard = random.Next(6, 8);
                        //int gwPorts = random.Next(6, 8);
                        //int GatewayPortsPerRouter = gwLineCard * gwPorts;
                        int GatewayLineCard = random.Next((int)Math.Round(Convert.ToDecimal(txtGatewayLCMin.Text)), (int)Math.Round(Convert.ToDecimal(txtGatewayLCMax.Text)));
                        int GatewayPorts = random.Next((int)Math.Round(Convert.ToDecimal(txtGatewayPortsMin.Text)), (int)Math.Round(Convert.ToDecimal(txtGatewayPortsMax.Text)));
                        int GatewayPortsPerRouter = GatewayLineCard * GatewayPorts;

                        //decimal GatewayCapacityPerRouter = GatewayPortsPerRouter * 10;
                        int GW1gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw1Gbps.Text)) * GatewayPortsPerRouter / 100;
                        int GW10gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw10Gbps.Text)) * GatewayPortsPerRouter / 100;
                        int GW40gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw40Gbps.Text)) * GatewayPortsPerRouter / 100;
                        int GW140gbpsPortsUsed = (int)Math.Round(Convert.ToDecimal(txtGw140Gbps.Text)) * GatewayPortsPerRouter / 100;
                        int GW100gbpsPortsUsed = GatewayPortsPerRouter - (GW1gbpsPortsUsed + GW10gbpsPortsUsed + GW40gbpsPortsUsed + GW140gbpsPortsUsed);

                        decimal GatewayCapacityPerRouter = CalculateCapacityPerRouter(GatewayPortsPerRouter, GW1gbpsPortsUsed, GW10gbpsPortsUsed, GW40gbpsPortsUsed, GW100gbpsPortsUsed, GW140gbpsPortsUsed);
                        GatewayTotalCapacity = GatewayTotalCapacity + GatewayCapacityPerRouter;

                        routerData.GatewayRDetails.Add(new Detail { RouterCost = GatewayRouterCost, CapacityPerRouter = GatewayCapacityPerRouter });
                    }

                    ServiceCostModel serviceCostModel = new ServiceCostModel();
                    serviceCostModel.NoOfNodes = i;
                    serviceCostModel.IterationCount = z;
                    serviceCostModel.NoOfUsedNodes = (int)Math.Floor(x * i / 100);
                    serviceCostModel.TotalNetworkCapacity = CpeTotalCapacity + EthernetTotalCapacity + EdgeTotalCapacity + OptSwTotalCapacity + CoreTotalCapacity + GatewayTotalCapacity;
                    serviceCostModel.TotalNetworkCost = TotalCpeRoutersCost + TotalEthernetRoutersCost + TotalEdgeRoutersCost + TotalOptSwRoutersCost + TotalCoreRoutersCost + TotalGatewayRoutersCost;
                    //serviceCostModel.NetworkUnitCost = (decimal)(serviceCostModel.TotalNetworkCost / serviceCostModel.TotalNetworkCapacity);
                    serviceCostModel.NetworkUnitCost = serviceCostModel.TotalNetworkCapacity != 0 ? (decimal)(serviceCostModel.TotalNetworkCost / serviceCostModel.TotalNetworkCapacity) : 0;




                    serviceCostModelList.Add(serviceCostModel);
                }

            }

            Data.Add(m1Data);
        }


        private void CalculateServiceCostM2()
        {
            // Calculate For VPN
            VpnCostModelList2 = CalculateServiceCostsMethod2("VPN");

            // Calculate for ETH
            EthernetCostModelList2 = CalculateServiceCostsMethod2("ETH");

            // Calculate For TLS
            TlsCostModelList2 = CalculateServiceCostsMethod2("TLS");

            // Calculate For HS
            HsCostModelList2 = CalculateServiceCostsMethod2("HS");
        }

        private List<ServiceCostModel> CalculateServiceCostsMethod2(string serviceName)
        {

            List<ServiceCostModel> CostModelList = new List<ServiceCostModel>();

            for (int i = MinNodes; i <= MaxNodes; i += 5)
            {
                for (int z = 1; z <= IterationsCount; z++)
                {
                    M1Data m1Data = Data.Where(x => x.ServiceName == serviceName).FirstOrDefault();

                    RouterBasedData singleNodeData = m1Data.RoutersData.FirstOrDefault(x => x.Node == i && x.IterationNo == z);



                    // Calculate For Cpe
                    if (singleNodeData.CpeRDetails.Count > 0)
                    {
                        int cpeCount = singleNodeData.CpeRDetails.Count();

                        var cpeMinCost = singleNodeData.CpeRDetails.Min(x => x.RouterCost);
                        //var cpeMinInstallationCost = cpeMinCost * 0.2m;
                        //var cpeMinCostPerRouter = cpeMinCost + cpeMinInstallationCost;

                        var cpeMaxCost = singleNodeData.CpeRDetails.Max(x => x.RouterCost);
                        //var cpeMaxInstallationCost = cpeMaxCost * 0.2m;
                        //var cpeMaxCostPerRouter = cpeMaxCost + cpeMaxInstallationCost;

                        var cpeMedianCost = CalculateMedian(singleNodeData.CpeRDetails.Select(x => x.RouterCost).ToList());
                        //var cpeMedianInstallationCost = cpeMedianCost * 0.2m;
                        //var cpeMedianCostPerRouter = cpeMedianCost + cpeMedianInstallationCost;

                        //var cpeRange = cpeMaxCost - cpeMinCost;
                        //var cpeRangeOneThird = cpeRange / 2;

                        //var cpePLow = cpeMinCost + cpeRangeOneThird;
                        ////var cpePMid = cpePLow + cpeRangeOneThird;
                        //var cpePHi = cpePLow + cpeRangeOneThird;

                        //List<Detail> T1CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost <= cpePLow).ToList();
                        //List<Detail> T2CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost > cpePLow && x.RouterCost <= cpePHi).ToList();
                        //  List<Detail> T3CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost > cpePMid && x.RouterCost <= cpePHi).ToList();



                        var cpeMedianCapacity = CalculateMedian(singleNodeData.CpeRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //if ((cpeCount % 2) == 0)
                        //{

                        //    var cpeMedianCapacity = CalculateMedian(singleNodeData.CpeRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //    if ((cpeCount % 2) != 0)
                        //    {
                        //        cpeMedianCapacity = singleNodeData.CpeRDetails.Find(x => x.RouterCost == cpeMedianCost).CapacityPerRouter;

                        //var cpeMinCapacity = singleNodeData.CpeRDetails.Min(x => x.CapacityPerRouter);
                        //var cpeMaxCapacity = singleNodeData.CpeRDetails.Max(x => x.CapacityPerRouter);
                        //// var cpeMedianCapacity = singleNodeData.CpeRDetails.Average(x => x.CapacityPerRouter);

                        //var cpeMedianCapacity = CalculateMedian(singleNodeData.CpeRDetails.Select(x => x.CapacityPerRouter).ToList());

                        var CpeRange = cpeMaxCost - cpeMinCost;
                        var CpeRangeOnefourth = CpeRange / 5;

                        var cpePLow = cpeMinCost + CpeRangeOnefourth;
                        var cpePMidCost1 = cpePLow + CpeRangeOnefourth;
                        var cpePMidCost2 = cpePMidCost1 + CpeRangeOnefourth;
                        var cpePMidCost3 = cpePMidCost2 + CpeRangeOnefourth;
                        var cpePMidCost4 = cpePMidCost3 + CpeRangeOnefourth;
                        var cpePMidCost5 = cpePMidCost4 + CpeRangeOnefourth;
                        var cpePHi = cpePMidCost3 + CpeRangeOnefourth;

                        List<Detail> T1CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost <= cpePLow).ToList();
                        List<Detail> T2CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost > cpePLow && x.RouterCost <= cpePMidCost1).ToList();
                        List<Detail> T3CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost > cpePMidCost1 && x.RouterCost <= cpePMidCost2).ToList();
                        List<Detail> T4CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost > cpePMidCost2 && x.RouterCost <= cpePMidCost3).ToList();
                        //List<Detail> T5CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost > cpePMidCost3 && x.RouterCost <= cpePMidCost4).ToList();
                        //List<Detail> T6CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost > cpePMidCost4 && x.RouterCost <= cpePMidCost5).ToList();
                        List<Detail> T5CpeData = singleNodeData.CpeRDetails.Where(x => x.RouterCost > cpePMidCost3).ToList();

                        var CpeT1Cost = cpeMinCost;
                        var CpeT1InstallationCost = CpeT1Cost * 0.2m;
                        var CpeT1CostPerRouter = CpeT1Cost + CpeT1InstallationCost;

                        var CpeT2Cost = T2CpeData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var CpeT2InstallationCost = CpeT2Cost * 0.2m;
                        var CpeT2CostPerRouter = CpeT2Cost + CpeT2InstallationCost;

                        //var CpeT3Cost = T3CpeData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var CpeT3InstallationCost = CpeT3Cost * 0.2m;
                        //var CpeT3CostPerRouter = CpeT3Cost + CpeT3InstallationCost;

                        var CpeT3Cost = cpeMedianCost;
                        var CpeT3InstallationCost = CpeT3Cost * 0.2m;
                        var CpeT3CostPerRouter = CpeT3Cost + CpeT3InstallationCost;

                        //var CpeT5Cost = T5CpeData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var CpeT5InstallationCost = CpeT5Cost * 0.2m;
                        //var CpeT5CostPerRouter = CpeT5Cost + CpeT5InstallationCost;

                        var CpeT4Cost = T4CpeData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var CpeT4InstallationCost = CpeT4Cost * 0.2m;
                        var CpeT4CostPerRouter = CpeT4Cost + CpeT4InstallationCost;


                        var CpeT5Cost = cpeMaxCost;
                        var CpeT5InstallationCost = CpeT5Cost * 0.2m;
                        var CpeT5CostPerRouter = CpeT5Cost + CpeT5InstallationCost;

                        //var cpeMinCapacity = singleNodeData.CpeRDetails.Find(x => x.RouterCost == cpeMinCost).CapacityPerRouter;
                        //var cpeMaxCapacity = singleNodeData.CpeRDetails.Find(x => x.RouterCost == cpeMaxCost).CapacityPerRouter;
                        // var cpeMedianCapacity = CalculateMedian(singleNodeData.CpeRDetails.Select(x => x.CapacityPerRouter).ToList());

                        // var cpeT1TotalCost = cpeMinCostPerRouter * T1CpeData.Count();
                        // var cpeT2TotalCost = cpeMaxCostPerRouter * T2CpeData.Count();
                        //// var cpeT3TotalCost = cpeMaxCostPerRouter * T3CpeData.Count();
                        // TotalCpeTypesCost = cpeT1TotalCost + cpeT2TotalCost;// + cpeT3TotalCost;



                        // var cpeT1TotalCapacity = cpeMinCapacity * T1CpeData.Count();
                        // var cpeT2TotalCapacity = cpeMaxCapacity * T2CpeData.Count();
                        //// var cpeT3TotalCapacity = cpeMaxCapacity * T3CpeData.Count();
                        // TotalCpeTypesCapacity = cpeT1TotalCapacity + cpeT2TotalCapacity;//  + cpeT3TotalCapacity;



                        var cpeMinCapacity = singleNodeData.CpeRDetails.Min(x => x.CapacityPerRouter);
                        var cpeMaxCapacity = singleNodeData.CpeRDetails.Max(x => x.CapacityPerRouter);


                        //var CpeRangeCap = cpeMaxCapacity;
                        //var CpeRangeCapOnefourth = (CpeRangeCap / 7);

                        //var CpePLowCap = cpeMinCapacity + CpeRangeCapOnefourth;
                        //var CpePMidCap1 = CpePLowCap + CpeRangeCapOnefourth;
                        //var CpePMidCap2 = CpePMidCap1 + CpeRangeCapOnefourth;
                        //var CpePMidCap3 = CpePMidCap2 + CpeRangeCapOnefourth;
                        //var CpePMidCap4 = CpePMidCap3 + CpeRangeCapOnefourth;
                        //var CpePMidCap5 = CpePMidCap4 + CpeRangeCapOnefourth;
                        //var CpePHiCap = CpePMidCap5 + CpeRangeCapOnefourth;


                        ////var CpeT1Capacity = singleNodeData.CpeRDetails.Find(x => x.RouterCost == cpeMinCost).CapacityPerRouter;
                        var CpeT1Capacity = cpeMinCapacity;
                        //List<Detail> CpeT2Capacitylist = singleNodeData.CpeRDetails.Where(x => x.CapacityPerRouter > CpePLowCap && x.CapacityPerRouter <= CpePMidCap1).ToList();
                        //var CpeT2Capacity = CpeT2Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        var CpeT3Capacity = CalculateMedian(singleNodeData.CpeRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //var CpeT2Capacity = (CpeT1Capacity + CpeT3Capacity) / 2;

                        var CpeT4Capacity = CalculateMedian(singleNodeData.CpeRDetails.Select(x => x.CapacityPerRouter).ToList());
                        var CpeT2Capacity = CalculateMedian(singleNodeData.CpeRDetails.Select(x => x.CapacityPerRouter).ToList());
                        //var CpeT4Capacity = (CpeT3Capacity + CpeT5Capacity) / 2;
                        //List<Detail> CpeT6Capacitylist = singleNodeData.CpeRDetails.Where(x => x.CapacityPerRouter > CpePMidCap4 && x.CapacityPerRouter <= CpePMidCap5).ToList();
                        //var CpeT6Capacity = CpeT6Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        //var CpeT3Capacity = cpeMedianCapacity;
                        //var CpeT2Capacity = (CpeT1Capacity + CpeT3Capacity) / 2;

                        var CpeT5Capacity = cpeMaxCapacity;
                        //var CpeT6Capacity = (CpeT5Capacity + CpeT7Capacity) / 2;

                        // var CpeT5Capacity = singleNodeData.CpeRDetails.Find(x => x.RouterCost == cpeMaxCost).CapacityPerRouter;


                        var cpeT1TotalCost = CpeT1CostPerRouter * T1CpeData.Count();
                        var cpeT2TotalCost = CpeT2CostPerRouter * T2CpeData.Count();
                        var cpeT3TotalCost = CpeT3CostPerRouter * T3CpeData.Count();
                        var cpeT4TotalCost = CpeT4CostPerRouter * T4CpeData.Count();
                        var cpeT5TotalCost = CpeT5CostPerRouter * T5CpeData.Count();
                        //var cpeT6TotalCost = CpeT6CostPerRouter * T6CpeData.Count();
                        //var cpeT7TotalCost = CpeT7CostPerRouter * T7CpeData.Count();
                        TotalCpeTypesCost = cpeT1TotalCost + cpeT2TotalCost + cpeT3TotalCost + cpeT4TotalCost + cpeT5TotalCost;
                        //+ cpeT6TotalCost + cpeT7TotalCost;

                        var cpeT1TotalCapacity = CpeT1Capacity * T1CpeData.Count();
                        var cpeT2TotalCapacity = CpeT2Capacity * T2CpeData.Count();
                        var cpeT3TotalCapacity = CpeT3Capacity * T3CpeData.Count();
                        var cpeT4TotalCapacity = CpeT4Capacity * T4CpeData.Count();
                        var cpeT5TotalCapacity = CpeT5Capacity * T5CpeData.Count();
                        //var cpeT6TotalCapacity = CpeT6Capacity * T6CpeData.Count();
                        //var cpeT7TotalCapacity = CpeT7Capacity * T7CpeData.Count();
                        TotalCpeTypesCapacity = cpeT1TotalCapacity + cpeT2TotalCapacity + cpeT2TotalCapacity + cpeT3TotalCapacity + cpeT4TotalCapacity + cpeT5TotalCapacity;
                        //+ cpeT6TotalCapacity + cpeT7TotalCapacity;



                        //var cpeMinUnitCostPerRouter = cpeT1TotalCapacity != 0 ? cpeT1TotalCost / cpeT1TotalCapacity : 0;
                        //var cpeMiedianUnitCostPerRouter = cpeT2TotalCapacity != 0 ? cpeT2TotalCost / cpeT2TotalCapacity : 0;
                        //var cpeMaxUnitCostPerRouter = cpeT3TotalCapacity != 0 ? cpeT3TotalCost / cpeT3TotalCapacity : 0;
                    }



                    // Calculate For Ethernet
                    if (singleNodeData.EthRDetails.Count() > 0)
                    {
                        int ethernetCount = singleNodeData.EthRDetails.Count();
                        var ethernetMinCost = singleNodeData.EthRDetails.Min(x => x.RouterCost);
                        var ethernetMinInstallationCost = ethernetMinCost * 0.2m;
                        var ethernetMinCostPerRouter = ethernetMinCost + ethernetMinInstallationCost;

                        var ethernetMaxCost = singleNodeData.EthRDetails.Max(x => x.RouterCost);
                        var ethernetMaxInstallationCost = ethernetMaxCost * 0.2m;
                        var ethernetMaxCostPerRouter = ethernetMaxCost + ethernetMaxInstallationCost;

                        //var ethernetMedianCost = singleNodeData.EthRDetails.Average(x => x.RouterCost);
                        var ethernetMedianCost = CalculateMedian(singleNodeData.EthRDetails.Select(x => x.RouterCost).ToList());
                        var ethernetMedianInstallationCost = ethernetMedianCost * 0.2m;
                        var ethernetMedianCostPerRouter = ethernetMedianCost + ethernetMedianInstallationCost;

                        var ethernetMinCapacity = singleNodeData.EthRDetails.Min(x => x.CapacityPerRouter);
                        var ethernetMaxCapacity = singleNodeData.EthRDetails.Max(x => x.CapacityPerRouter);
                        //var ethernetMedianCapacity = singleNodeData.EthRDetails.Average(x => x.CapacityPerRouter);
                        var ethernetMedianCapacity = CalculateMedian(singleNodeData.EthRDetails.Select(x => x.CapacityPerRouter).ToList());

                        var ethernetRange = ethernetMaxCost - ethernetMinCost;
                        var ethernetRangeOneThird = ethernetRange / 3;

                        var ethPLow = ethernetMinCost + ethernetRangeOneThird;
                        var ethPHi = ethPLow + ethernetRangeOneThird;

                        List<Detail> T1EthernetData = singleNodeData.EthRDetails.Where(x => x.RouterCost <= ethPLow).ToList();
                        List<Detail> T3EthernetData = singleNodeData.EthRDetails.Where(x => x.RouterCost >= ethPHi).ToList();
                        List<Detail> T2EthernetData = singleNodeData.EthRDetails.Where(x => x.RouterCost > ethPLow && x.RouterCost < ethPHi).ToList();




                        var EthernetT1TotalCost = ethernetMinCostPerRouter * T1EthernetData.Count();
                        var EthernetT2TotalCost = ethernetMedianCostPerRouter * T2EthernetData.Count();
                        var EthernetT3TotalCost = ethernetMaxCostPerRouter * T3EthernetData.Count();
                        TotalEthernetTypesCost = EthernetT1TotalCost + EthernetT2TotalCost + EthernetT3TotalCost;

                        var EthernetT1TotalCapacity = ethernetMinCapacity * T1EthernetData.Count();
                        var EthernetT2TotalCapacity = ethernetMedianCapacity * T2EthernetData.Count();
                        var EthernetT3TotalCapacity = ethernetMaxCapacity * T3EthernetData.Count();
                        TotalEthernetTypesCapacity = EthernetT1TotalCapacity + EthernetT2TotalCapacity + EthernetT3TotalCapacity;

                        var EthernetMinUnitCostPerRouter = EthernetT1TotalCapacity != 0 ? EthernetT1TotalCost / EthernetT1TotalCapacity : 0;
                        var EthernetMiedianUnitCostPerRouter = EthernetT2TotalCapacity != 0 ? EthernetT2TotalCost / EthernetT2TotalCapacity : 0;
                        var EthernetMaxUnitCostPerRouter = EthernetT3TotalCapacity != 0 ? EthernetT3TotalCost / EthernetT3TotalCapacity : 0;
                    }

                    // Calculate For Edge
                    if (singleNodeData.EdgeRDetails.Count() > 0)
                    {
                        int edgeCount = singleNodeData.EdgeRDetails.Count();
                        var edgeMinCost = singleNodeData.EdgeRDetails.Min(x => x.RouterCost);
                        //var edgeMinInstallationCost = edgeMinCost * 0.2m;
                        //var edgeMinCostPerRouter = edgeMinCost + edgeMinInstallationCost;

                        var edgeMaxCost = singleNodeData.EdgeRDetails.Max(x => x.RouterCost);
                        //var edgeMaxInstallationCost = edgeMaxCost * 0.2m;
                        //var edgeMaxCostPerRouter = edgeMaxCost + edgeMaxInstallationCost;

                        //var edgeMedianCost = singleNodeData.EdgeRDetails.Average(x => x.RouterCost);
                        var edgeMedianCost = CalculateMedian(singleNodeData.EdgeRDetails.Select(x => x.RouterCost).ToList());
                        //var edgeMedianInstallationCost = edgeMedianCost * 0.2m;
                        //var edgeMedianCostPerRouter = edgeMedianCost + edgeMedianInstallationCost;



                        //var edgeMinCapacity = singleNodeData.EdgeRDetails.Find(x => x.RouterCost == edgeMinCost).CapacityPerRouter;
                        //var edgeMaxCapacity = singleNodeData.EdgeRDetails.Find(x => x.RouterCost == edgeMaxCost).CapacityPerRouter;
                        //var edgeMedianCapacity = CalculateMedian(singleNodeData.EdgeRDetails.Select(x => x.CapacityPerRouter).ToList());
                        //if ((edgeCount % 2) == 0)
                        //{

                        //    var edgeMedianCapacity = CalculateMedian(singleNodeData.EdgeRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //    if ((edgeCount % 2) != 0)
                        //    {
                        //        edgeMedianCapacity = singleNodeData.EdgeRDetails.Find(x => x.RouterCost == edgeMedianCost).CapacityPerRouter;



                        var edgeMinCapacity = singleNodeData.EdgeRDetails.Min(x => x.CapacityPerRouter);
                        var edgeMaxCapacity = singleNodeData.EdgeRDetails.Max(x => x.CapacityPerRouter);
                        ////var edgeMedianCapacity = singleNodeData.EdgeRDetails.Average(x => x.CapacityPerRouter);
                        var edgeMedianCapacity = CalculateMedian(singleNodeData.EdgeRDetails.Select(x => x.CapacityPerRouter).ToList());

                        // var edgeRange = edgeMaxCost - edgeMinCost;
                        // var edgeRangeOneThird = edgeRange / 2;

                        // var edgePLow = edgeMinCost + edgeRangeOneThird;
                        // //var edgePMid = edgePLow + edgeRangeOneThird;
                        // var edgePHi = edgePLow + edgeRangeOneThird;

                        // List<Detail> T1EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost <= edgePLow).ToList();
                        // List<Detail> T2EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost > edgePLow && x.RouterCost <= edgePHi).ToList();
                        //// List<Detail> T3EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost > edgePMid && x.RouterCost <= edgePHi).ToList();

                        // var EdgeT1TotalCost = edgeMinCostPerRouter * T1EdgeData.Count();
                        // var EdgeT2TotalCost = edgeMaxCostPerRouter * T2EdgeData.Count();
                        // //var EdgeT3TotalCost = edgeMaxCostPerRouter * T3EdgeData.Count();
                        // TotalEdgeTypesCost = EdgeT1TotalCost + EdgeT2TotalCost;// + EdgeT3TotalCost;

                        // var EdgeT1TotalCapacity = edgeMinCapacity * T1EdgeData.Count();
                        // var EdgeT2TotalCapacity = edgeMaxCapacity * T2EdgeData.Count();
                        //// var EdgeT3TotalCapacity = edgeMaxCapacity * T3EdgeData.Count();
                        // TotalEdgeTypesCapacity = EdgeT1TotalCapacity + EdgeT2TotalCapacity;// + EdgeT3TotalCapacity;
                        /////////////////////////////////////////////////////////////////////////////

                        var EdgeRange = edgeMaxCost - edgeMinCost;
                        var EdgeRangeOnefourth = EdgeRange / 5;

                        var edgePLow = edgeMinCost + EdgeRangeOnefourth;
                        var edgePMidCost1 = edgePLow + EdgeRangeOnefourth;
                        var edgePMidCost2 = edgePMidCost1 + EdgeRangeOnefourth;
                        var edgePMidCost3 = edgePMidCost2 + EdgeRangeOnefourth;
                        var edgePMidCost4 = edgePMidCost3 + EdgeRangeOnefourth;
                        var edgePMidCost5 = edgePMidCost4 + EdgeRangeOnefourth;
                        var edgePHi = edgePMidCost3 + EdgeRangeOnefourth;

                        List<Detail> T1EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost <= edgePLow).ToList();
                        List<Detail> T2EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost > edgePLow && x.RouterCost <= edgePMidCost1).ToList();
                        List<Detail> T3EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost > edgePMidCost1 && x.RouterCost <= edgePMidCost2).ToList();
                        List<Detail> T4EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost > edgePMidCost2 && x.RouterCost <= edgePMidCost3).ToList();
                        //List<Detail> T5EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost > edgePMidCost3 && x.RouterCost <= edgePMidCost4).ToList();
                        //List<Detail> T6EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost > edgePMidCost4 && x.RouterCost <= edgePMidCost5).ToList();
                        List<Detail> T5EdgeData = singleNodeData.EdgeRDetails.Where(x => x.RouterCost > edgePMidCost3).ToList();

                        var EdgeT1Cost = edgeMinCost;
                        var EdgeT1InstallationCost = EdgeT1Cost * 0.2m;
                        var EdgeT1CostPerRouter = EdgeT1Cost + EdgeT1InstallationCost;

                        var EdgeT2Cost = T2EdgeData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var EdgeT2InstallationCost = EdgeT2Cost * 0.2m;
                        var EdgeT2CostPerRouter = EdgeT2Cost + EdgeT2InstallationCost;

                        //var EdgeT3Cost = T3EdgeData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var EdgeT3InstallationCost = EdgeT3Cost * 0.2m;
                        //var EdgeT3CostPerRouter = EdgeT3Cost + EdgeT3InstallationCost;

                        var EdgeT3Cost = edgeMedianCost;
                        var EdgeT3InstallationCost = EdgeT3Cost * 0.2m;
                        var EdgeT3CostPerRouter = EdgeT3Cost + EdgeT3InstallationCost;

                        //var EdgeT5Cost = T5EdgeData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var EdgeT5InstallationCost = EdgeT5Cost * 0.2m;
                        //var EdgeT5CostPerRouter = EdgeT5Cost + EdgeT5InstallationCost;

                        var EdgeT4Cost = T4EdgeData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var EdgeT4InstallationCost = EdgeT4Cost * 0.2m;
                        var EdgeT4CostPerRouter = EdgeT4Cost + EdgeT4InstallationCost;

                        var EdgeT5Cost = edgeMaxCost;
                        var EdgeT5InstallationCost = EdgeT5Cost * 0.2m;
                        var EdgeT5CostPerRouter = EdgeT5Cost + EdgeT5InstallationCost;

                        //var edgeMinCapacity = singleNodeData.EdgeRDetails.Min(x => x.CapacityPerRouter);
                        //var edgeMaxCapacity = singleNodeData.EdgeRDetails.Max(x => x.CapacityPerRouter);

                        ////var EdgeRangeCap = edgeMaxCapacity - edgeMinCapacity;
                        ////var EdgeRangeCapOnefourth = EdgeRangeCap / 7;

                        ////var EdgePLowCap = edgeMinCapacity + EdgeRangeCapOnefourth;
                        ////var EdgePMidCap1 = EdgePLowCap + EdgeRangeCapOnefourth;
                        ////var EdgePMidCap2 = EdgePMidCap1 + EdgeRangeCapOnefourth;
                        ////var EdgePMidCap3 = EdgePMidCap2 + EdgeRangeCapOnefourth;
                        ////var EdgePMidCap4 = EdgePMidCap3 + EdgeRangeCapOnefourth;
                        ////var EdgePMidCap5 = EdgePMidCap4 + EdgeRangeCapOnefourth;
                        ////var EdgePHiCap = EdgePMidCap5 + EdgeRangeCapOnefourth;

                        //var EdgeT1Capacity = singleNodeData.EdgeRDetails.Find(x => x.RouterCost == edgeMinCost).CapacityPerRouter;
                        var EdgeT1Capacity = edgeMinCapacity;
                        //List<Detail> EdgeT2Capacitylist = singleNodeData.EdgeRDetails.Where(x => x.CapacityPerRouter > EdgePLowCap && x.CapacityPerRouter <= EdgePMidCap1).ToList();
                        //var EdgeT2Capacity = EdgeT2Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        var EdgeT3Capacity = CalculateMedian(singleNodeData.EdgeRDetails.Select(x => x.CapacityPerRouter).ToList());
                        //var EdgeT2Capacity = (EdgeT1Capacity + EdgeT3Capacity) / 2;
                        var EdgeT4Capacity = CalculateMedian(singleNodeData.EdgeRDetails.Select(x => x.CapacityPerRouter).ToList());
                        var EdgeT2Capacity = CalculateMedian(singleNodeData.EdgeRDetails.Select(x => x.CapacityPerRouter).ToList());



                        //List<Detail> EdgeT6Capacitylist = singleNodeData.EdgeRDetails.Where(x => x.CapacityPerRouter > EdgePMidCap4 && x.CapacityPerRouter <= EdgePMidCap5).ToList();
                        //var EdgeT6Capacity = EdgeT6Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        var EdgeT5Capacity = edgeMaxCapacity;
                        //var EdgeT6Capacity = (EdgeT5Capacity + EdgeT7Capacity) / 2;


                        //var EdgeT4Capacity = (EdgeT3Capacity + EdgeT5Capacity) / 2;
                        //var EdgeT5Capacity = singleNodeData.EdgeRDetails.Find(x => x.RouterCost == edgeMaxCost).CapacityPerRouter;


                        var EdgeT1TotalCost = EdgeT1CostPerRouter * T1EdgeData.Count();
                        var EdgeT2TotalCost = EdgeT2CostPerRouter * T2EdgeData.Count();
                        var EdgeT3TotalCost = EdgeT3CostPerRouter * T3EdgeData.Count();
                        var EdgeT4TotalCost = EdgeT4CostPerRouter * T4EdgeData.Count();
                        var EdgeT5TotalCost = EdgeT5CostPerRouter * T5EdgeData.Count();
                        //var EdgeT6TotalCost = EdgeT6CostPerRouter * T6EdgeData.Count();
                        //var EdgeT7TotalCost = EdgeT7CostPerRouter * T7EdgeData.Count();
                        TotalEdgeTypesCost = EdgeT1TotalCost + EdgeT2TotalCost + EdgeT3TotalCost + EdgeT3TotalCost + EdgeT4TotalCost + EdgeT5TotalCost;
                        //+ EdgeT6TotalCost + EdgeT7TotalCost;

                        var EdgeT1TotalCapacity = EdgeT1Capacity * T1EdgeData.Count();
                        var EdgeT2TotalCapacity = EdgeT2Capacity * T2EdgeData.Count();
                        var EdgeT3TotalCapacity = EdgeT3Capacity * T3EdgeData.Count();
                        var EdgeT4TotalCapacity = EdgeT4Capacity * T4EdgeData.Count();
                        var EdgeT5TotalCapacity = EdgeT5Capacity * T5EdgeData.Count();
                        //var EdgeT6TotalCapacity = EdgeT6Capacity * T5EdgeData.Count();
                        //var EdgeT7TotalCapacity = EdgeT7Capacity * T7EdgeData.Count();
                        TotalEdgeTypesCapacity = EdgeT1TotalCapacity + EdgeT2TotalCapacity + EdgeT3TotalCapacity + EdgeT3TotalCapacity + EdgeT4TotalCapacity + EdgeT5TotalCapacity;
                        //+ EdgeT6TotalCapacity + EdgeT7TotalCapacity;

                        //var EdgeMinUnitCostPerRouter = EdgeT1TotalCapacity != 0 ? EdgeT1TotalCost / EdgeT1TotalCapacity : 0;
                        //var EdgeMedianUnitCostPerRouter = EdgeT2TotalCapacity != 0 ? EdgeT2TotalCost / EdgeT2TotalCapacity : 0;
                        //var EdgeMaxUnitCostPerRouter = EdgeT3TotalCapacity != 0 ? EdgeT3TotalCost / EdgeT3TotalCapacity : 0;
                    }



                    // Calculate For Optical Transport
                    if (singleNodeData.OptSwRDetails.Count() > 0)
                    {
                        int OptSwCount = singleNodeData.OptSwRDetails.Count();
                        var OptSwMinCost = singleNodeData.OptSwRDetails.Min(x => x.RouterCost);
                        //var OptSwMinInstallationCost = OptSwMinCost * 0.2m;
                        //var OptSwMinCostPerRouter = OptSwMinCost + OptSwMinInstallationCost;

                        var OptSwMaxCost = singleNodeData.OptSwRDetails.Max(x => x.RouterCost);
                        //var OptSwMaxInstallationCost = OptSwMaxCost * 0.2m;
                        //var OptSwMaxCostPerRouter = OptSwMaxCost + OptSwMaxInstallationCost;

                        //var OptSwMedianCost = singleNodeData.OptSwRDetails.Average(x => x.RouterCost);
                        var OptSwMedianCost = CalculateMedian(singleNodeData.OptSwRDetails.Select(x => x.RouterCost).ToList());
                        //var OptSwMedianInstallationCost = OptSwMedianCost * 0.2m;
                        //var OptSwMedianCostPerRouter = OptSwMedianCost + OptSwMedianInstallationCost;


                        //var OptSwMinCapacity = singleNodeData.OptSwRDetails.Find(x => x.RouterCost == OptSwMinCost).CapacityPerRouter;
                        //var OptSwMaxCapacity = singleNodeData.OptSwRDetails.Find(x => x.RouterCost == OptSwMaxCost).CapacityPerRouter;
                        //var OptSwMedianCapacity = CalculateMedian(singleNodeData.OptSwRDetails.Select(x => x.CapacityPerRouter).ToList());
                        //if ((OptSwCount % 2) == 0)
                        //{

                        //    var OptSwMedianCapacity = CalculateMedian(singleNodeData.OptSwRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //    if ((OptSwCount % 2) != 0)
                        //    {
                        //        OptSwMedianCapacity = singleNodeData.OptSwRDetails.Find(x => x.RouterCost == OptSwMedianCost).CapacityPerRouter;

                        var OptSwMinCapacity = singleNodeData.OptSwRDetails.Min(x => x.CapacityPerRouter);
                        var OptSwMaxCapacity = singleNodeData.OptSwRDetails.Max(x => x.CapacityPerRouter);
                        //////var OptSwMedianCapacity = singleNodeData.OptSwRDetails.Average(x => x.CapacityPerRouter);
                        var OptSwMedianCapacity = CalculateMedian(singleNodeData.OptSwRDetails.Select(x => x.CapacityPerRouter).ToList());

                        // var OptSwRange = OptSwMaxCost - OptSwMinCost;
                        // var OptSwRangeOneThird = OptSwRange / 2;

                        // var OptSwPLow = OptSwMinCost + OptSwRangeOneThird;
                        // //var OptSwPMid = OptSwPLow + OptSwRangeOneThird;
                        // var OptSwPHi = OptSwPLow + OptSwRangeOneThird;

                        // List<Detail> T1OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost <= OptSwPLow).ToList();
                        // List<Detail> T2OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost > OptSwPLow && x.RouterCost <= OptSwPHi).ToList();
                        // // List<Detail> T3OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost > OptSwPMid && x.RouterCost <= OptSwPHi).ToList();

                        // var OptSwT1TotalCost = OptSwMinCostPerRouter * T1OptSwData.Count();
                        // var OptSwT2TotalCost = OptSwMaxCostPerRouter * T2OptSwData.Count();
                        //// var OptSwT3TotalCost = OptSwMaxCostPerRouter * T3OptSwData.Count();
                        // TotalOptSwTypesCost = OptSwT1TotalCost + OptSwT2TotalCost;// + OptSwT3TotalCost;

                        // var OptSwT1TotalCapacity = OptSwMinCapacity * T1OptSwData.Count();
                        // var OptSwT2TotalCapacity = OptSwMaxCapacity * T2OptSwData.Count();
                        // // var OptSwT3TotalCapacity = OptSwMaxCapacity * T3OptSwData.Count();
                        // TotalOptSwTypesCapacity = OptSwT1TotalCapacity + OptSwT2TotalCapacity;// + OptSwT3TotalCapacity;


                        var OptSwRange = OptSwMaxCost - OptSwMinCost;
                        var OptSwRangeOnefourth = OptSwRange / 5;

                        var OptSwPLow = OptSwMinCost + OptSwRangeOnefourth;
                        var OptSwPMidCost1 = OptSwPLow + OptSwRangeOnefourth;
                        var OptSwPMidCost2 = OptSwPMidCost1 + OptSwRangeOnefourth;
                        var OptSwPMidCost3 = OptSwPMidCost2 + OptSwRangeOnefourth;
                        //var OptSwPMidCost4 = OptSwPMidCost3 + OptSwRangeOnefourth;
                        //var OptSwPMidCost5 = OptSwPMidCost4 + OptSwRangeOnefourth;
                        var OptSwPHi = OptSwPMidCost3 + OptSwRangeOnefourth;

                        List<Detail> T1OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost <= OptSwPLow).ToList();
                        List<Detail> T2OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost > OptSwPLow && x.RouterCost <= OptSwPMidCost1).ToList();
                        List<Detail> T3OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost > OptSwPMidCost1 && x.RouterCost <= OptSwPMidCost2).ToList();
                        List<Detail> T4OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost > OptSwPMidCost2 && x.RouterCost <= OptSwPMidCost3).ToList();
                        //List<Detail> T5OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost > OptSwPMidCost3 && x.RouterCost <= OptSwPMidCost4).ToList();
                        //List<Detail> T6OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost > OptSwPMidCost4 && x.RouterCost <= OptSwPMidCost5).ToList();
                        List<Detail> T5OptSwData = singleNodeData.OptSwRDetails.Where(x => x.RouterCost > OptSwPMidCost3).ToList();

                        var OptSwT1Cost = OptSwMinCost;
                        var OptSwT1InstallationCost = OptSwT1Cost * 0.2m;
                        var OptSwT1CostPerRouter = OptSwT1Cost + OptSwT1InstallationCost;

                        var OptSwT2Cost = T2OptSwData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var OptSwT2InstallationCost = OptSwT2Cost * 0.2m;
                        var OptSwT2CostPerRouter = OptSwT2Cost + OptSwT2InstallationCost;

                        //var OptSwT3Cost = T3OptSwData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var OptSwT3InstallationCost = OptSwT3Cost * 0.2m;
                        //var OptSwT3CostPerRouter = OptSwT3Cost + OptSwT3InstallationCost;

                        var OptSwT3Cost = OptSwMedianCost;
                        var OptSwT3InstallationCost = OptSwT3Cost * 0.2m;
                        var OptSwT3CostPerRouter = OptSwT3Cost + OptSwT3InstallationCost;

                        //var OptSwT5Cost = T5OptSwData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var OptSwT5InstallationCost = OptSwT5Cost * 0.2m;
                        //var OptSwT5CostPerRouter = OptSwT5Cost + OptSwT5InstallationCost;

                        var OptSwT4Cost = T4OptSwData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var OptSwT4InstallationCost = OptSwT4Cost * 0.2m;
                        var OptSwT4CostPerRouter = OptSwT4Cost + OptSwT4InstallationCost;

                        var OptSwT5Cost = OptSwMaxCost;
                        var OptSwT5InstallationCost = OptSwT5Cost * 0.2m;
                        var OptSwT5CostPerRouter = OptSwT5Cost + OptSwT5InstallationCost;

                        //var OptSwMinCapacityT1 = singleNodeData.OptSwRDetails.Find(x => x.RouterCost == OptSwMinCost).CapacityPerRouter;
                        //var OptSwMaxCapacityT7 = singleNodeData.OptSwRDetails.Find(x => x.RouterCost == OptSwMaxCost).CapacityPerRouter;
                        // var OptSwMedianCapacity = CalculateMedian(singleNodeData.OptSwRDetails.Select(x => x.CapacityPerRouter).ToList());


                        //var OptSwMinCapacity = singleNodeData.OptSwRDetails.Min(x => x.CapacityPerRouter);
                        //var OptSwMaxCapacity = singleNodeData.OptSwRDetails.Max(x => x.CapacityPerRouter);
                        //var OptSwRangeCap = OptSwMaxCapacity - OptSwMinCapacity;
                        //var OptSwRangeCapOnefourth = OptSwRangeCap / 7;

                        //var OptSwPLowCap = OptSwMinCapacity + OptSwRangeCapOnefourth;
                        //var OptSwPMidCap1 = OptSwPLowCap + OptSwRangeCapOnefourth;
                        //var OptSwPMidCap2 = OptSwPMidCap1 + OptSwRangeCapOnefourth;
                        //var OptSwPMidCap3 = OptSwPMidCap2 + OptSwRangeCapOnefourth;
                        //var OptSwPMidCap4 = OptSwPMidCap3 + OptSwRangeCapOnefourth;
                        //var OptSwPMidCap5 = OptSwPMidCap4 + OptSwRangeCapOnefourth;
                        //var OptSwPHiCap = OptSwPMidCap5 + OptSwRangeCapOnefourth;


                        var OptSwT1Capacity = OptSwMinCapacity;
                        //List<Detail> OptSwT2Capacitylist = singleNodeData.OptSwRDetails.Where(x => x.CapacityPerRouter > OptSwPLowCap && x.CapacityPerRouter <= OptSwPMidCap1).ToList();
                        //var OptSwT2Capacity = OptSwT2Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        //var OptSwT3Capacity = CalculateMedian(singleNodeData.OptSwRDetails.Select(x => x.CapacityPerRouter).ToList());



                        //List<Detail> OptSwT6Capacitylist = singleNodeData.OptSwRDetails.Where(x => x.CapacityPerRouter > OptSwPMidCap4 && x.CapacityPerRouter <= OptSwPMidCap5).ToList();
                        //var OptSwT6Capacity = OptSwT6Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        var OptSwT3Capacity = OptSwMedianCapacity;
                        //var OptSwT2Capacity = (OptSwT1Capacity + OptSwT3Capacity) / 2;
                        var OptSwT4Capacity = CalculateMedian(singleNodeData.OptSwRDetails.Select(x => x.CapacityPerRouter).ToList());
                        var OptSwT2Capacity = CalculateMedian(singleNodeData.OptSwRDetails.Select(x => x.CapacityPerRouter).ToList());
                        var OptSwT5Capacity = OptSwMaxCapacity;
                        //var OptSwT6Capacity = (OptSwT5Capacity + OptSwT7Capacity) / 2;
                        //var OptSwT5Capacity = singleNodeData.OptSwRDetails.Find(x => x.RouterCost == OptSwMaxCost).CapacityPerRouter;


                        var OptSwT1TotalCost = OptSwT1CostPerRouter * T1OptSwData.Count();
                        var OptSwT2TotalCost = OptSwT2CostPerRouter * T2OptSwData.Count();
                        var OptSwT3TotalCost = OptSwT3CostPerRouter * T3OptSwData.Count();
                        var OptSwT4TotalCost = OptSwT4CostPerRouter * T4OptSwData.Count();
                        var OptSwT5TotalCost = OptSwT5CostPerRouter * T5OptSwData.Count();
                        //var OptSwT6TotalCost = OptSwT6CostPerRouter * T6OptSwData.Count();
                        //var OptSwT7TotalCost = OptSwT7CostPerRouter * T7OptSwData.Count();
                        TotalOptSwTypesCost = OptSwT1TotalCost + OptSwT2TotalCost + OptSwT3TotalCost + OptSwT3TotalCost + OptSwT4TotalCost + OptSwT5TotalCost;
                        //+ OptSwT6TotalCost; + OptSwT7TotalCost;

                        var OptSwT1TotalCapacity = OptSwT1Capacity * T1OptSwData.Count();
                        var OptSwT2TotalCapacity = OptSwT2Capacity * T2OptSwData.Count();
                        var OptSwT3TotalCapacity = OptSwT3Capacity * T3OptSwData.Count();
                        var OptSwT4TotalCapacity = OptSwT4Capacity * T4OptSwData.Count();
                        var OptSwT5TotalCapacity = OptSwT5Capacity * T5OptSwData.Count();
                        //var OptSwT6TotalCapacity = OptSwT6Capacity * T6OptSwData.Count();
                        //var OptSwT7TotalCapacity = OptSwT7Capacity * T7OptSwData.Count();
                        TotalOptSwTypesCapacity = OptSwT1TotalCapacity + OptSwT2TotalCapacity + OptSwT3TotalCapacity + OptSwT3TotalCapacity + OptSwT4TotalCapacity + OptSwT5TotalCapacity;
                        //+ OptSwT6TotalCapacity + OptSwT7TotalCapacity;


                        //var OptSwMinUnitCostPerRouter = OptSwT1TotalCapacity != 0 ? OptSwT1TotalCost / OptSwT1TotalCapacity : 0;
                        //    var OptSwMiedianUnitCostPerRouter = OptSwT2TotalCapacity != 0 ? OptSwT2TotalCost / OptSwT2TotalCapacity : 0;
                        //    var OptSwMaxUnitCostPerRouter = OptSwT3TotalCapacity != 0 ? OptSwT3TotalCost / OptSwT3TotalCapacity : 0;
                    }



                    // Calculate For Core
                    if (singleNodeData.CoreRDetails.Count() > 0)
                    {
                        int CoreCount = singleNodeData.CoreRDetails.Count();
                        var CoreMinCost = singleNodeData.CoreRDetails.Min(x => x.RouterCost);
                        //var CoreMinInstallationCost = CoreMinCost * 0.2m;
                        //var CoreMinCostPerRouter = CoreMinCost + CoreMinInstallationCost;

                        var CoreMaxCost = singleNodeData.CoreRDetails.Max(x => x.RouterCost);
                        //var CoreMaxInstallationCost = CoreMaxCost * 0.2m;
                        //var CoreMaxCostPerRouter = CoreMaxCost + CoreMaxInstallationCost;

                        //var CoreMedianCost = singleNodeData.CoreRDetails.Average(x => x.RouterCost);
                        var CoreMedianCost = CalculateMedian(singleNodeData.CoreRDetails.Select(x => x.RouterCost).ToList());
                        //var CoreMedianInstallationCost = CoreMedianCost * 0.2m;
                        //var CoreMedianCostPerRouter = CoreMedianCost + CoreMedianInstallationCost;

                        //var CoreMinCapacity = singleNodeData.CoreRDetails.Find(x => x.RouterCost == CoreMinCost).CapacityPerRouter;
                        //var CoreMaxCapacity = singleNodeData.CoreRDetails.Find(x => x.RouterCost == CoreMaxCost).CapacityPerRouter;
                        //var CoreMedianCapacity = CalculateMedian(singleNodeData.CoreRDetails.Select(x => x.CapacityPerRouter).ToList());
                        //if ((CoreCount % 2) == 0)
                        //{

                        //    var CoreMedianCapacity = CalculateMedian(singleNodeData.CoreRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //    if ((CoreCount % 2) != 0)
                        //    {
                        //        CoreMedianCapacity = singleNodeData.OptSwRDetails.Find(x => x.RouterCost == CoreMedianCost).CapacityPerRouter;

                        //var CoreMinCapacity = singleNodeData.CoreRDetails.Min(x => x.CapacityPerRouter);
                        //var CoreMaxCapacity = singleNodeData.CoreRDetails.Max(x => x.CapacityPerRouter);
                        ////var CoreMedianCapacity = singleNodeData.CoreRDetails.Average(x => x.CapacityPerRouter);
                        var CoreMedianCapacity = CalculateMedian(singleNodeData.CoreRDetails.Select(x => x.CapacityPerRouter).ToList());
                        ///////////////

                        //var CoreRange = CoreMaxCost - CoreMinCost;
                        //var CoreRangeOneThird = CoreRange / 2;

                        //var CorePLow = CoreMinCost + CoreRangeOneThird;
                        ////var CorePMid = CorePLow + CoreRangeOneThird;
                        //var CorePHi = CorePLow + CoreRangeOneThird;

                        //List<Detail> T1CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost <= CorePLow).ToList();
                        //List<Detail> T2CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost > CorePLow && x.RouterCost <= CorePHi).ToList();
                        ////List<Detail> T3CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost > CorePMid && x.RouterCost <= CorePHi).ToList();

                        //var CoreT1TotalCost = CoreMinCostPerRouter * T1CoreData.Count();
                        //var CoreT2TotalCost = CoreMaxCostPerRouter * T2CoreData.Count();
                        ////var CoreT3TotalCost = CoreMaxCostPerRouter * T3CoreData.Count();
                        //TotalCoreTypesCost = CoreT1TotalCost + CoreT2TotalCost;// + CoreT3TotalCost;

                        //var CoreT1TotalCapacity = CoreMinCapacity * T1CoreData.Count();
                        //var CoreT2TotalCapacity = CoreMaxCapacity * T2CoreData.Count();
                        ////var CoreT3TotalCapacity = CoreMaxCapacity * T3CoreData.Count();
                        //TotalCoreTypesCapacity = CoreT1TotalCapacity + CoreT2TotalCapacity;// + CoreT3TotalCapacity;
                        ////////////////
                        ///
                        var CoreRange = CoreMaxCost - CoreMinCost;
                        var CoreRangeOnefourth = CoreRange / 5;

                        var CorePLow = CoreMinCost + CoreRangeOnefourth;
                        var CorePMidCost1 = CorePLow + CoreRangeOnefourth;
                        var CorePMidCost2 = CorePMidCost1 + CoreRangeOnefourth;
                        var CorePMidCost3 = CorePMidCost2 + CoreRangeOnefourth;
                        //var CorePMidCost4 = CorePMidCost3 + CoreRangeOnefourth;
                        //var CorePMidCost5 = CorePMidCost4 + CoreRangeOnefourth;
                        var CorePHi = CorePMidCost3 + CoreRangeOnefourth;

                        List<Detail> T1CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost <= CorePLow).ToList();
                        List<Detail> T2CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost > CorePLow && x.RouterCost <= CorePMidCost1).ToList();
                        List<Detail> T3CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost > CorePMidCost1 && x.RouterCost <= CorePMidCost2).ToList();
                        List<Detail> T4CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost > CorePMidCost2 && x.RouterCost <= CorePMidCost3).ToList();
                        //List<Detail> T5CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost > CorePMidCost3 && x.RouterCost <= CorePMidCost4).ToList();
                        //List<Detail> T6CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost > CorePMidCost4 && x.RouterCost <= CorePMidCost5).ToList();
                        List<Detail> T5CoreData = singleNodeData.CoreRDetails.Where(x => x.RouterCost > CorePMidCost3).ToList();

                        var CoreT1Cost = CoreMinCost;
                        var CoreT1InstallationCost = CoreT1Cost * 0.2m;
                        var CoreT1CostPerRouter = CoreT1Cost + CoreT1InstallationCost;

                        var CoreT2Cost = T2CoreData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var CoreT2InstallationCost = CoreT2Cost * 0.2m;
                        var CoreT2CostPerRouter = CoreT2Cost + CoreT2InstallationCost;

                        //var CoreT3Cost = T3CoreData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var CoreT3InstallationCost = CoreT3Cost * 0.2m;
                        //var CoreT3CostPerRouter = CoreT3Cost + CoreT3InstallationCost;

                        var CoreT3Cost = CoreMedianCost;
                        var CoreT3InstallationCost = CoreT3Cost * 0.2m;
                        var CoreT3CostPerRouter = CoreT3Cost + CoreT3InstallationCost;

                        //var CoreT5Cost = T5CoreData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var CoreT5InstallationCost = CoreT5Cost * 0.2m;
                        //var CoreT5CostPerRouter = CoreT5Cost + CoreT5InstallationCost;

                        var CoreT4Cost = T4CoreData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var CoreT4InstallationCost = CoreT4Cost * 0.2m;
                        var CoreT4CostPerRouter = CoreT4Cost + CoreT4InstallationCost;

                        var CoreT5Cost = CoreMaxCost;
                        var CoreT5InstallationCost = CoreT5Cost * 0.2m;
                        var CoreT5CostPerRouter = CoreT5Cost + CoreT5InstallationCost;


                        var CoreMinCapacity = singleNodeData.CoreRDetails.Min(x => x.CapacityPerRouter);
                        var CoreMaxCapacity = singleNodeData.CoreRDetails.Max(x => x.CapacityPerRouter);
                        //var CoreRangeCap = CoreMaxCapacity - CoreMinCapacity;
                        //var CoreRangeCapOnefourth = CoreRangeCap / 7;

                        //var CorePLowCap = CoreMinCapacity + CoreRangeCapOnefourth;
                        //var CorePMidCap1 = CorePLowCap + CoreRangeCapOnefourth;
                        //var CorePMidCap2 = CorePMidCap1 + CoreRangeCapOnefourth;
                        //var CorePMidCap3 = CorePMidCap2 + CoreRangeCapOnefourth;
                        //var CorePMidCap4 = CorePMidCap3 + CoreRangeCapOnefourth;
                        //var CorePMidCap5 = CorePMidCap4 + CoreRangeCapOnefourth;
                        //var CoreePHiCap = CorePMidCap5 + CoreRangeCapOnefourth;

                        ////var CoreT1Capacity = singleNodeData.CoreRDetails.Find(x => x.RouterCost == CoreMinCost).CapacityPerRouter;
                        var CoreT1Capacity = CoreMinCapacity;
                        //List<Detail> CoreT2Capacitylist = singleNodeData.CoreRDetails.Where(x => x.CapacityPerRouter > CorePLowCap && x.CapacityPerRouter <= CorePMidCap1).ToList();
                        //var CoreT2Capacity = CoreT2Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        var CoreT3Capacity = CalculateMedian(singleNodeData.CoreRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //var CoreT4Capacity = CoreMedianCapacity;
                        //var CoreT2Capacity = (CoreT1Capacity + CoreT3Capacity) / 2;
                        var CoreT2Capacity = CalculateMedian(singleNodeData.CoreRDetails.Select(x => x.CapacityPerRouter).ToList());
                        var CoreT4Capacity = CalculateMedian(singleNodeData.CoreRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //List<Detail> CoreT6Capacitylist = singleNodeData.CoreRDetails.Where(x => x.CapacityPerRouter > CorePMidCap4 && x.CapacityPerRouter <= CorePMidCap4).ToList();
                        //var CoreT6Capacity = CoreT6Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();

                        var CoreT5Capacity = CoreMaxCapacity;
                        //var CoreT6Capacity = (CoreT5Capacity + CoreT7Capacity) / 2;
                        //var CoreT5Capacity = singleNodeData.CoreRDetails.Find(x => x.RouterCost == CoreMaxCost).CapacityPerRouter;


                        var CoreT1TotalCost = CoreT1CostPerRouter * T1CoreData.Count();
                        var CoreT2TotalCost = CoreT2CostPerRouter * T2CoreData.Count();
                        var CoreT3TotalCost = CoreT3CostPerRouter * T3CoreData.Count();
                        var CoreT4TotalCost = CoreT4CostPerRouter * T4CoreData.Count();
                        var CoreT5TotalCost = CoreT5CostPerRouter * T5CoreData.Count();
                        //var CoreT6TotalCost = CoreT6CostPerRouter * T6CoreData.Count();
                        //var CoreT7TotalCost = CoreT7CostPerRouter * T7CoreData.Count();
                        TotalCoreTypesCost = CoreT1TotalCost + CoreT2TotalCost + CoreT3TotalCost + CoreT3TotalCost + CoreT4TotalCost + CoreT5TotalCost;
                        //+ CoreT6TotalCost + CoreT7TotalCost;

                        var CoreT1TotalCapacity = CoreT1Capacity * T1CoreData.Count();
                        var CoreT2TotalCapacity = CoreT2Capacity * T2CoreData.Count();
                        var CoreT3TotalCapacity = CoreT3Capacity * T3CoreData.Count();
                        var CoreT4TotalCapacity = CoreT4Capacity * T4CoreData.Count();
                        var CoreT5TotalCapacity = CoreT5Capacity * T5CoreData.Count();
                        //var CoreT6TotalCapacity = CoreT6Capacity * T6CoreData.Count();
                        //var CoreT7TotalCapacity = CoreT7Capacity * T7CoreData.Count();

                        TotalCoreTypesCapacity = CoreT1TotalCapacity + CoreT2TotalCapacity + CoreT3TotalCapacity + CoreT3TotalCapacity + CoreT4TotalCapacity + CoreT5TotalCapacity;
                        //+ CoreT6TotalCapacity + CoreT7TotalCapacity;

                        //var CoreMinUnitCostPerRouter = CoreT1TotalCapacity != 0 ? CoreT1TotalCost / CoreT1TotalCapacity : 0;
                        //        var CoreMiedianUnitCostPerRouter = CoreT2TotalCapacity != 0 ? CoreT2TotalCost / CoreT2TotalCapacity : 0;
                        //        var CoreMaxUnitCostPerRouter = CoreT3TotalCapacity != 0 ? CoreT3TotalCost / CoreT3TotalCapacity : 0;
                    }



                    // Calculate For Gateway
                    if (singleNodeData.GatewayRDetails.Count() > 0)
                    {
                        int GatewayCount = singleNodeData.GatewayRDetails.Count();
                        var GatewayMinCost = singleNodeData.GatewayRDetails.Min(x => x.RouterCost);
                        //var GatewayMinInstallationCost = GatewayMinCost * 0.2m;
                        //var GatewayMinCostPerRouter = GatewayMinCost + GatewayMinInstallationCost;

                        var GatewayMaxCost = singleNodeData.GatewayRDetails.Max(x => x.RouterCost);
                        //var GatewayMaxInstallationCost = GatewayMaxCost * 0.2m;
                        //var GatewayMaxCostPerRouter = GatewayMaxCost + GatewayMaxInstallationCost;

                        //var GatewayMedianCost = singleNodeData.GatewayRDetails.Average(x => x.RouterCost);
                        var GatewayMedianCost = CalculateMedian(singleNodeData.GatewayRDetails.Select(x => x.RouterCost).ToList());
                        //var GatewayMedianInstallationCost = GatewayMedianCost * 0.2m;
                        //var GatewayMedianCostPerRouter = GatewayMedianCost + GatewayMedianInstallationCost;

                        //var GatewayMinCapacity = singleNodeData.GatewayRDetails.Find(x => x.RouterCost == GatewayMinCost).CapacityPerRouter;
                        //var GatewayMaxCapacity = singleNodeData.GatewayRDetails.Find(x => x.RouterCost == GatewayMaxCost).CapacityPerRouter;
                        //var GatewayMedianCapacity = CalculateMedian(singleNodeData.GatewayRDetails.Select(x => x.CapacityPerRouter).ToList());
                        //if ((GatewayCount % 2) == 0)
                        //{

                        //    var GatewayMedianCapacity = CalculateMedian(singleNodeData.GatewayRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //    if ((GatewayCount % 2) != 0)
                        //    {
                        //        GatewayMedianCapacity = singleNodeData.GatewayRDetails.Find(x => x.RouterCost == GatewayMedianCost).CapacityPerRouter;

                        var GatewayMinCapacity = singleNodeData.GatewayRDetails.Min(x => x.CapacityPerRouter);
                        var GatewayMaxCapacity = singleNodeData.GatewayRDetails.Max(x => x.CapacityPerRouter);
                        ////var GatewayMedianCapacity = singleNodeData.GatewayRDetails.Average(x => x.CapacityPerRouter);
                        // var GatewayMedianCapacity = CalculateMedian(singleNodeData.GatewayRDetails.Select(x => x.CapacityPerRouter).ToList());

                        //  var GatewayRange = GatewayMaxCost - GatewayMinCost;
                        //  var GatewayRangeOneThird = GatewayRange / 2;

                        //  var GatewayPLow = GatewayMinCost + GatewayRangeOneThird;
                        //  //var GatewayPMid = GatewayPLow + GatewayRangeOneThird;
                        //  var GatewayPHi = GatewayPLow + GatewayRangeOneThird;

                        //  List<Detail> T1GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost <= GatewayPLow).ToList();
                        //  List<Detail> T2GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost > GatewayPLow && x.RouterCost <= GatewayPHi).ToList();
                        ////  List<Detail> T3GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost > GatewayPMid && x.RouterCost <= GatewayPHi).ToList();

                        //  var GatewayT1TotalCost = GatewayMinCostPerRouter * T1GatewayData.Count();
                        //  var GatewayT2TotalCost = GatewayMaxCostPerRouter * T2GatewayData.Count();
                        //  //var GatewayT3TotalCost = GatewayMaxCostPerRouter * T3GatewayData.Count();
                        //  TotalGatewayTypesCost = GatewayT1TotalCost + GatewayT2TotalCost; //+ GatewayT3TotalCost;

                        //  var GatewayT1TotalCapacity = GatewayMinCapacity * T1GatewayData.Count();
                        //  var GatewayT2TotalCapacity = GatewayMaxCapacity * T2GatewayData.Count();
                        //  //var GatewayT3TotalCapacity = GatewayMaxCapacity * T3GatewayData.Count();
                        // TotalGatewayTypesCapacity = GatewayT1TotalCapacity + GatewayT2TotalCapacity;// + GatewayT3TotalCapacity;
                        //////////////////////////

                        var GatewayRange = GatewayMaxCost - GatewayMinCost;
                        var GatewayRangeOnefourth = GatewayRange / 5;

                        var GatewayPLow = GatewayMinCost + GatewayRangeOnefourth;
                        var GatewayPMidCost1 = GatewayPLow + GatewayRangeOnefourth;
                        var GatewayPMidCost2 = GatewayPMidCost1 + GatewayRangeOnefourth;
                        var GatewayPMidCost3 = GatewayPMidCost2 + GatewayRangeOnefourth;
                        //var GatewayPMidCost4 = GatewayPMidCost3 + GatewayRangeOnefourth;
                        //var GatewayPMidCost5 = GatewayPMidCost4 + GatewayRangeOnefourth;
                        var GatewayPHi = GatewayPMidCost3 + GatewayRangeOnefourth;

                        List<Detail> T1GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost <= GatewayPLow).ToList();
                        List<Detail> T2GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost > GatewayPLow && x.RouterCost <= GatewayPMidCost1).ToList();
                        List<Detail> T3GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost > GatewayPMidCost1 && x.RouterCost <= GatewayPMidCost2).ToList();
                        List<Detail> T4GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost > GatewayPMidCost2 && x.RouterCost <= GatewayPMidCost3).ToList();
                        //List<Detail> T5GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost > GatewayPMidCost3 && x.RouterCost <= GatewayPMidCost4).ToList();
                        //List<Detail> T6GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost > GatewayPMidCost4 && x.RouterCost <= GatewayPMidCost5).ToList();
                        List<Detail> T5GatewayData = singleNodeData.GatewayRDetails.Where(x => x.RouterCost > GatewayPMidCost3).ToList();

                        var GatewayT1Cost = GatewayMinCost;
                        var GatewayT1InstallationCost = GatewayT1Cost * 0.2m;
                        var GatewayT1CostPerRouter = GatewayT1Cost + GatewayT1InstallationCost;

                        var GatewayT2Cost = T2GatewayData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var GatewayT2InstallationCost = GatewayT2Cost * 0.2m;
                        var GatewayT2CostPerRouter = GatewayT2Cost + GatewayT2InstallationCost;

                        //var GatewayT3Cost = T3GatewayData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var GatewayT3InstallationCost = GatewayT3Cost * 0.2m;
                        //var GatewayT3CostPerRouter = GatewayT3Cost + GatewayT3InstallationCost;

                        var GatewayT3Cost = GatewayMedianCost;
                        var GatewayT3InstallationCost = GatewayT3Cost * 0.2m;
                        var GatewayT3CostPerRouter = GatewayT3Cost + GatewayT3InstallationCost;

                        //var GatewayT5Cost = T5GatewayData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        //var GatewayT5InstallationCost = GatewayT5Cost * 0.2m;
                        //var GatewayT5CostPerRouter = GatewayT5Cost + GatewayT5InstallationCost;

                        var GatewayT4Cost = T4GatewayData.Select(x => x.RouterCost).DefaultIfEmpty().Average();
                        var GatewayT4InstallationCost = GatewayT4Cost * 0.2m;
                        var GatewayT4CostPerRouter = GatewayT4Cost + GatewayT4InstallationCost;

                        var GatewayT5Cost = GatewayMaxCost;
                        var GatewayT5InstallationCost = GatewayT5Cost * 0.2m;
                        var GatewayT5CostPerRouter = GatewayT5Cost + GatewayT5InstallationCost;


                        //var GatewayMinCapacity = singleNodeData.GatewayRDetails.Min(x => x.CapacityPerRouter);
                        //var GatewayMaxCapacity = singleNodeData.GatewayRDetails.Max(x => x.CapacityPerRouter);
                        //var GatewayRangeCap = GatewayMaxCapacity - GatewayMinCapacity;
                        //var GatewayRangeCapOnefourth = GatewayRangeCap / 7;

                        //var GatewayPLowCap = GatewayMinCapacity + GatewayRangeCapOnefourth;
                        //var GatewayPMidCap1 = GatewayPLowCap + GatewayRangeCapOnefourth;
                        //var GatewayPMidCap2 = GatewayPMidCap1 + GatewayRangeCapOnefourth;
                        //var GatewayPMidCap3 = GatewayPMidCap2 + GatewayRangeCapOnefourth;
                        //var GatewayPMidCap4 = GatewayPMidCap3 + GatewayRangeCapOnefourth;
                        //var GatewayPMidCap5 = GatewayPMidCap4 + GatewayRangeCapOnefourth;
                        //var GatewayePHiCap = GatewayPMidCap3 + GatewayRangeCapOnefourth;


                        var GatewayT1Capacity = GatewayMinCapacity;
                        //List<Detail> GatewayT2Capacitylist = singleNodeData.GatewayRDetails.Where(x => x.CapacityPerRouter > GatewayPLowCap && x.CapacityPerRouter <= GatewayPMidCap1).ToList();
                        //var GatewayT2Capacity = GatewayT2Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        var GatewayT3Capacity = CalculateMedian(singleNodeData.GatewayRDetails.Select(x => x.CapacityPerRouter).ToList());
                        //var GatewayT2Capacity = (GatewayT1Capacity + GatewayT3Capacity) / 2;
                        var GatewayT4Capacity = CalculateMedian(singleNodeData.GatewayRDetails.Select(x => x.CapacityPerRouter).ToList());
                        var GatewayT2Capacity = CalculateMedian(singleNodeData.GatewayRDetails.Select(x => x.CapacityPerRouter).ToList());


                        //List<Detail> GatewayT6Capacitylist = singleNodeData.GatewayRDetails.Where(x => x.CapacityPerRouter > GatewayPMidCap4 && x.CapacityPerRouter <= GatewayPMidCap5).ToList();
                        //var GatewayT6Capacity = GatewayT6Capacitylist.Select(x => x.CapacityPerRouter).DefaultIfEmpty().Average();
                        var GatewayT5Capacity = GatewayMaxCapacity;
                        //var GatewayT4Capacity = (GatewayT3Capacity + GatewayT5Capacity) / 2;



                        var GatewayT1TotalCost = GatewayT1CostPerRouter * T1GatewayData.Count();
                        var GatewayT2TotalCost = GatewayT2CostPerRouter * T2GatewayData.Count();
                        var GatewayT3TotalCost = GatewayT3CostPerRouter * T3GatewayData.Count();
                        var GatewayT4TotalCost = GatewayT4CostPerRouter * T4GatewayData.Count();
                        var GatewayT5TotalCost = GatewayT5CostPerRouter * T5GatewayData.Count();
                        //var GatewayT6TotalCost = GatewayT6CostPerRouter * T6GatewayData.Count();
                        //var GatewayT7TotalCost = GatewayT7CostPerRouter * T7GatewayData.Count();
                        TotalGatewayTypesCost = GatewayT1TotalCost + GatewayT2TotalCost + GatewayT3TotalCost + GatewayT4TotalCost + GatewayT5TotalCost;
                        //+ GatewayT6TotalCost + GatewayT7TotalCost;

                        var GatewayT1TotalCapacity = GatewayT1Capacity * T1GatewayData.Count();
                        var GatewayT2TotalCapacity = GatewayT2Capacity * T2GatewayData.Count();
                        var GatewayT3TotalCapacity = GatewayT3Capacity * T3GatewayData.Count();
                        var GatewayT4TotalCapacity = GatewayT4Capacity * T4GatewayData.Count();
                        var GatewayT5TotalCapacity = GatewayT5Capacity * T5GatewayData.Count();
                        //var GatewayT6TotalCapacity = GatewayT6Capacity * T6GatewayData.Count();
                        //var GatewayT7TotalCapacity = GatewayT7Capacity * T7GatewayData.Count();
                        TotalGatewayTypesCapacity = GatewayT1TotalCapacity + GatewayT2TotalCapacity + GatewayT3TotalCapacity + GatewayT4TotalCapacity + GatewayT5TotalCapacity;
                        //+ GatewayT6TotalCapacity + GatewayT7TotalCapacity;

                        //var GatewayMinUnitCostPerRouter = GatewayT1TotalCapacity != 0 ? GatewayT1TotalCost / GatewayT1TotalCapacity : 0;
                        //        var GatewayMiedianUnitCostPerRouter = GatewayT2TotalCapacity != 0 ? GatewayT2TotalCost / GatewayT2TotalCapacity : 0;
                        //        var GatewayMaxUnitCostPerRouter = GatewayT3TotalCapacity != 0 ? GatewayT3TotalCost / GatewayT3TotalCapacity : 0;
                    }




                    // CostModel Calculation
                    ServiceCostModel serviceCostModel = new ServiceCostModel();
                    serviceCostModel.NoOfNodes = i;
                    serviceCostModel.IterationCount = z;
                    //serviceCostModel.NoOfUsedNodes =  
                    serviceCostModel.TotalNetworkCost = TotalCpeTypesCost + TotalEthernetTypesCost + TotalEdgeTypesCost + TotalOptSwTypesCost + TotalCoreTypesCost + TotalGatewayTypesCost;
                    serviceCostModel.TotalNetworkCapacity = TotalCpeTypesCapacity + TotalEthernetTypesCapacity + TotalEdgeTypesCapacity + TotalOptSwTypesCapacity + TotalCoreTypesCapacity + TotalGatewayTypesCapacity;
                    //serviceCostModel.NetworkUnitCost = (decimal)(serviceCostModel.TotalNetworkCost / serviceCostModel.TotalNetworkCapacity);
                    serviceCostModel.NetworkUnitCost = serviceCostModel.TotalNetworkCapacity != 0 ? (decimal)(serviceCostModel.TotalNetworkCost / serviceCostModel.TotalNetworkCapacity) : 0;


                    if (serviceName == "VPN")
                    {
                        serviceCostModel.NoOfUsedNodes = VpnCostModelList.FirstOrDefault(x => x.NoOfNodes == i).NoOfUsedNodes;
                    }
                    else if (serviceName == "ETH")
                    {
                        serviceCostModel.NoOfUsedNodes = EthernetCostModelList.FirstOrDefault(x => x.NoOfNodes == i).NoOfUsedNodes;
                    }
                    else if (serviceName == "TLS")
                    {
                        serviceCostModel.NoOfUsedNodes = TlsCostModelList.FirstOrDefault(x => x.NoOfNodes == i).NoOfUsedNodes;
                    }
                    else if (serviceName == "HS")
                    {
                        serviceCostModel.NoOfUsedNodes = HsCostModelList.FirstOrDefault(x => x.NoOfNodes == i).NoOfUsedNodes;
                    }

                    CostModelList.Add(serviceCostModel);

                    // Reset all variables for next iteration
                    TotalCpeTypesCost = TotalEthernetTypesCost = TotalEdgeTypesCost = TotalOptSwTypesCost = TotalCoreTypesCost = TotalGatewayTypesCost = 0;
                    TotalCpeTypesCapacity = TotalEthernetTypesCapacity = TotalEdgeTypesCapacity = TotalOptSwTypesCapacity = TotalCoreTypesCapacity = TotalGatewayTypesCapacity = 0;
                }
            }

            return CostModelList;
        }


        private void btnSetDummyValues_Click(object sender, EventArgs e)

        {
            groupBox2.Visible = !groupBox2.Visible;
            txtCpeMinPrice.Select();

            //txtCpePercent.Text = 20.ToString();
            //txtEthernetPercent.Text = 10.ToString();
            //txtEdgePercent.Text = 25.ToString();
            //txtOptSwPercent.Text = 15.ToString();
            //txtCorePercent.Text = 20.ToString();
            //txtGatewayPercent.Text = 10.ToString();

            //txtCpe1gbps.Text = 30.ToString();
            //txtCpe10Gbps.Text = 70.ToString();
            //txtCpe40gbps.Text = 0.ToString();
            //txtCpe100Gbps.Text = 0.ToString();
            //txtCpe140Gbps.Text = 0.ToString();

            //txtEth1Gbps.Text = 0.ToString();
            //txtEth10Gbps.Text = 40.ToString();
            //txtEth40Gbps.Text = 35.ToString();
            //txtEth100Gbps.Text = 25.ToString();
            //txtEth140Gbps.Text = 0.ToString();

            //txtEdge1Gbps.Text = 0.ToString();
            //txtEdge10Gbps.Text = 10.ToString();
            //txtEdge40Gbps.Text = 30.ToString();
            //txtEdge100Gbps.Text = 60.ToString();
            //txtEdge140Gbps.Text = 0.ToString();

            //txtOptSw1Gbps.Text = 0.ToString();
            //txtOptSw10Gbps.Text = 0.ToString();
            //txtOptSw40Gbps.Text = 0.ToString();
            //txtOptSw100Gbps.Text = 25.ToString();
            //txtOptSw140Gbps.Text = 75.ToString();


            //txtCore1Gbps.Text = 0.ToString();
            //txtCore10Gbps.Text = 0.ToString();
            //txtCore40Gbps.Text = 0.ToString();
            //txtCore100Gbps.Text = 80.ToString();
            //txtCore140Gbps.Text = 20.ToString();

            //txtGw1Gbps.Text = 0.ToString();
            //txtGw10Gbps.Text = 0.ToString();
            //txtGw40Gbps.Text = 0.ToString();
            //txtGw100Gbps.Text = 60.ToString();
            //txtGw140Gbps.Text = 40.ToString();

            //txtCpeMinPrice.Text = 3500.ToString();
            //txtCpeMaxPrice.Text = 4500.ToString();
            //txtEthernetMinPrice.Text = 125000.ToString();
            //txtEthernetMaxPrice.Text = 175000.ToString();
            //txtEdgeMinPrice.Text = 275000.ToString();
            //txtEdgeMaxPrice.Text = 325000.ToString();
            //txtOptSwMinPrice.Text = 700000.ToString();
            //txtOptSwMaxPrice.Text = 750000.ToString();
            //txtCoreMinPrice.Text = 350000.ToString();
            //txtCoreMaxPrice.Text = 425000.ToString();
            //txtGatewayMinPrice.Text = 300000.ToString();
            //txtGatewayMaxPrice.Text = 350000.ToString();

            //txtCpeLan.Text = 0.ToString();
            //txtEthernetLan.Text = 7.ToString();
            //txtEdgeLan.Text = 9.ToString();
            //txtOptSwLan.Text = 11.ToString();
            //txtCoreLan.Text = 14.ToString();
            //txtGatewayLan.Text = 7.ToString();

            //txtCpePorts.Text = 0.ToString();
            //txtEthernetPorts.Text = 5.ToString();
            //txtEdgePorts.Text = 7.ToString();
            //txtOptSwPorts.Text = 11.ToString();
            //txtCorePorts.Text = 11.ToString();
            //txtGatewayPorts.Text = 7.ToString();


            //txtIPVPNPerc.Text = 35.ToString();
            //txtEthPerc.Text = 15.ToString();
            //txtTLSPerc.Text = 60.ToString();
            //txtHSPerc.Text = 75.ToString();

        }

        private decimal CalculateCapacityPerRouter(int ports, int perc1, int perc10, int perc40, int perc100, int perc140)
        {
            //int Ports1gbps = perc1 * ports / 100;
            //         int Ports10gbps = perc10 * ports / 100;
            //         int Ports40gbps = perc40 * ports / 100;
            //int Ports100gbps = perc100 * ports / 100;
            //         int Ports140gbps = perc140 * ports / 100;

            decimal CapacityPerRouter = perc1 + (perc10 * 10) + (perc40 * 40) + (perc100 * 100) + (perc140 * 140);

            return CapacityPerRouter;
        }

        private decimal CalculateMedian(List<Decimal> numbers)
        {
            int numberCount = numbers.Count();
            int halfIndex = numbers.Count() / 2;
            var sortedNumbers = numbers.OrderBy(n => n);
            decimal median;
            if ((numberCount % 2) == 0)
            {
                median = ((sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt((halfIndex - 1))) / 2);
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
            }

            return median;
        }
    }
}
