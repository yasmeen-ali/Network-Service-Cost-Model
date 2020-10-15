using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCosting.Models
{
    public class M1Data
    {
        public string ServiceName { get; set; }
        public List<RouterBasedData> RoutersData { get; set; } = new List<RouterBasedData>();           // Per Node Data
    }


    public class RouterBasedData
    {
        public int Node { get; set; }
        public int IterationNo { get; set; }
        public List<Detail> CpeRDetails { get; set; } = new List<Detail>();
        public List<Detail> EthRDetails { get; set; } = new List<Detail>();
        public List<Detail> EdgeRDetails { get; set; } = new List<Detail>();
        public List<Detail> OptSwRDetails { get; set; } = new List<Detail>();
        public List<Detail> CoreRDetails { get; set; } = new List<Detail>();
        public List<Detail> GatewayRDetails { get; set; } = new List<Detail>();
    }

    public class Detail
    {
        public decimal RouterCost { get; set; }
        public decimal CapacityPerRouter { get; set; }
    }
}
