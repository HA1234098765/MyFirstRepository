using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarageMS.Controller;
using CarageMS.Model;
namespace CarageMS.View
{
    public partial class ctrlStock : UserControl
    {
        StockController controller;     
        private static ctrlStock _ctrl;
        public ctrlStock()
        {
            InitializeComponent();
            controller = new StockController(this);
        }

        public static ctrlStock Instance()
        {
            return _ctrl ?? (_ctrl = new ctrlStock());
        }

    }
}
