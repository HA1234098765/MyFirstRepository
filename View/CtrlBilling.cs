using CarageMS.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarageMS.View
{
    public partial class CtrlBilling : UserControl
    {
        BillController controller;
        private static CtrlBilling _ctrl;

        public CtrlBilling()
        {

        }
        public CtrlBilling(string employeeName)
        {
            InitializeComponent();
            controller = new BillController(this, employeeName);
        }

        public static CtrlBilling Instance(string employeeName)
        {
            return _ctrl ?? (_ctrl = new CtrlBilling(employeeName));
        }
    }
}
