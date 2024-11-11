using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarageMS.Model
{
    public class tbBills
    {
        public tbBills() { }

        public int BillNumber { get; set; }
        public string CarNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public double MechanicFess { get; set; }
        public double PartFess { get; set; }
        public double TotalFess { get; set; }
    }
}
