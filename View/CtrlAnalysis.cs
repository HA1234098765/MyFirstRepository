using CarageMS.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarageMS.View
{
    public partial class CtrlAnalysis : UserControl
    {
        AnalysisController controller;
        private static CtrlAnalysis _ctrl;
        public CtrlAnalysis()
        {
            InitializeComponent();
            controller = new AnalysisController(this);
        }

        public static CtrlAnalysis Instance()
        {
            return _ctrl ?? (_ctrl = new CtrlAnalysis());
        }
    }
}
