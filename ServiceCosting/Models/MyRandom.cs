using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCosting.Models
{
    public class myRandom
    {

        int rnd;
        int Next()
        {
            return rnd = ++rnd % int.MaxValue;
        }
    }
}

