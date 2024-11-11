using CarageMS.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarageMS.Model;
using System.Runtime.InteropServices;
using CarageMS.Controller;

namespace CarageMS
{
    
    public partial class FrmMain : Form
    {
        
        MainController mainController;

        public FrmMain()
        {
            InitializeComponent();
            mainController = new MainController(this);
        }
    }
}
