using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarageMS.Controller;

namespace CarageMS.View
{
    public partial class ctrlEmployees : UserControl
    {
        EmployeeController controller;
        private static ctrlEmployees _ctrl;
        public ctrlEmployees()
        {
            InitializeComponent();
            controller = new EmployeeController(this);
        }

        public static ctrlEmployees Inctance()
        {
            return _ctrl ?? (_ctrl = new ctrlEmployees());
        }

        
    }
}
