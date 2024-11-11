using CarageMS.Model;
using CarageMS.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarageMS.Controller
{
    public class MainController
    {
        FrmMain frm;

        MainController()
        {

        }
        public MainController(FrmMain frm)
        {
            this.frm = frm;
            CreateEvents();
        }

        //-------------------- Events -------------------------//
        private void Frm_Load(object sender, EventArgs e)
        {
            FillContainer(ctrlCar.Instance(), "Cars");
            //Set the ForeColor of the FrmMain Buttons of the side bar
            SetButtonsForeColor(Color.White);
            frm.btnCars.ForeColor = Color.CadetBlue;
        }

        private void BtnCars_Click(object sender, EventArgs e)
        {
            // Fill Cars control in the container
            FillContainer(ctrlCar.Instance(), "Cars");
            //Set the ForeColor of the FrmMain Buttons of the side bar
            SetButtonsForeColor(Color.White);
            frm.btnCars.ForeColor = Color.CadetBlue;
        }

        private void BtnStock_Click(object sender, EventArgs e)
        {
            // Fill Stock control in the container
            FillContainer(ctrlStock.Instance(), "Stocks");
            //Set the ForeColor of the FrmMain Buttons of the side bar
            SetButtonsForeColor(Color.White);
            frm.btnStock.ForeColor = Color.CadetBlue;
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            // Fill Employee control in the container
            FillContainer(ctrlEmployees.Inctance(), "Employees");
            //Set the ForeColor of the FrmMain Buttons of the side bar
            SetButtonsForeColor(Color.White);
            frm.btnEmployee.ForeColor = Color.CadetBlue;
        }

        private void BtnBilling_Click(object sender, EventArgs e)
        {
            // Fill Bill control in the container            
            FillContainer(CtrlBilling.Instance(frm.lblEmployeeName.Text), "Billing");
            //Set the ForeColor of the FrmMain Buttons of the side bar
            SetButtonsForeColor(Color.White);
            frm.btnBilling.ForeColor = Color.CadetBlue;
        }

        private void BtnAnalysis_Click(object sender, EventArgs e)
        {
            // Fill Analysis control in the container
            FillContainer(CtrlAnalysis.Instance(), "Analysis");
            //Set the ForeColor of the FrmMain Buttons of the side bar
            SetButtonsForeColor(Color.White);
            frm.btnAnalysis.ForeColor = Color.CadetBlue;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            //Close the Main Form (FrmMain)
            frm.Close();
        }


        //-------------------------- Private functions--------------------------------------//
        private void FillContainer(UserControl page, string Titel)
        {
            var oldPage = frm.pnlContainer.Controls.OfType<UserControl>().FirstOrDefault();
            //Clear the pnlContainer and Add new page (UserControl)
            if (oldPage == null || (oldPage != null && oldPage.GetType() != page.GetType()))
            {
                page.Dock = DockStyle.Fill;
                frm.pnlContainer.Controls.Clear();
                frm.pnlContainer.Controls.Add(page);
                //Set the Titel text of the  Controls 
                frm.lblTitel.Text = Titel;
            }
            
        }

        private void SetButtonsForeColor(Color col)
        {
            // Set The ForeColor of SideBar  Buttons 
            frm.btnCars.ForeColor = 
                frm.btnStock.ForeColor = 
                frm.btnEmployee.ForeColor =
                frm.btnBilling.ForeColor = 
                frm.btnAnalysis.ForeColor = 
                col;
        }

        private void CreateEvents()
        {
            //Create the Events
            frm.Load += Frm_Load;
            frm.btnCars.Click += BtnCars_Click;
            frm.btnStock.Click += BtnStock_Click;
            frm.btnEmployee.Click += BtnEmployee_Click;
            frm.btnBilling.Click += BtnBilling_Click;
            frm.btnAnalysis.Click += BtnAnalysis_Click;
            frm.btnLogOut.Click += BtnLogOut_Click;
        }

        
    }  
}
