using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayollDomain
{
    public abstract class Affiliation
    {
        public abstract int? MemberId { get; set; }
        public abstract double CalculateDeductions(PayCheck paycheck);
    }
}
