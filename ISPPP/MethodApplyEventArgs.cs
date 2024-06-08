using ISPPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPPP
{
    class MethodApplyEventArgs : EventArgs
    {
        public Workpiece[] workpieces { get; set; }
        public MethodType method {get; set;}
        public double maxTime {get; set;}
        public bool has_extended_sum = false;
    }
}
