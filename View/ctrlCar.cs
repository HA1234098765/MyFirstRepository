using CarageMS.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarageMS.View
{
    public partial class ctrlCar : UserControl
    {
        CarController controller;
        private static  ctrlCar _ctrl;
        public ctrlCar()
        {
            InitializeComponent();
            controller = new CarController(this);
        }

        public static ctrlCar Instance()
        {
            return _ctrl ?? (_ctrl = new ctrlCar());
        }

    }
}
