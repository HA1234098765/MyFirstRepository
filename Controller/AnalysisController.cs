using CarageMS.Model;
using CarageMS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarageMS.Controller
{
    public class AnalysisController
    {
        DBCarageMs db;
        CtrlAnalysis page;
        
        public AnalysisController() { }

        public AnalysisController(CtrlAnalysis page) 
        {
            this.page = page;
            Update();
            CreateEvents();
        }

        //----------------- Evetns ------------------//
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }
        

        //------------------ Private functions ---------------------//
        private void Update()
        {
            db = new DBCarageMs();
            page.lblCars.Text = " Cars: " + db.tbCars.Count().ToString();
            page.lblEmployees.Text = " Employees: " + db.tbEmployees.Count().ToString();
            page.lblSpairParts.Text = " Spair parts: " + db.tbStocks.Count().ToString();
            page.lblFinanes.Text = " Finanes: " + db.tbBills.GetSumOfTotalFeess().ToString() + "$";
        }

        private void CreateEvents()
        {
            page.btnUpdate.Click += BtnUpdate_Click;
        }

    }
}
