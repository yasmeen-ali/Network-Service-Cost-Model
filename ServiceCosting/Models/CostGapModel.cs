using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCosting.Models
{
    public class CostGapModel
    {
        public int NoOfNodes { get; set; }
        public int NoOfUsedNodes { get; set; }
        //public int IterationCount { get; set; }

        //public decimal TotalNetworkUnitCost { get; set; }
        public decimal M1UnitCost { get; set; }
        public decimal M2UnitCost { get; set; }
        //public decimal TotalNetworkCostGap { get; set; }
        public decimal M2CostGap { get; set; }
    }
}