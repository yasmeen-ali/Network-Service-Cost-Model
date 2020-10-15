using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCosting.Models
{
    public class InfrastructureCostModel
    {
        public int NoOfNodes { get; set; }
        public int IterationCount { get; set; }
        public decimal TotalNetworkCost { get; set; }
        public decimal TotalNetworkCapacity { get; set; }
        public decimal NetworkUnitCost { get; set; }

    }
}
