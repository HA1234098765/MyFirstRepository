using CarageMS.Model;
using CarageMS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarageMS.Controller
{
    public class LoginController
    {
        FrmLogin Login;
        DBCarageMs db;
        FrmMain main;
        public LoginController() { }

        public LoginController(FrmLogin login)
        {
            this.Login = login;
            db = new DBCarageMs();
            CreateEvents();
        }

        //------------------------------- Events -----------------------------------//
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Register();
        }


        //-------------------------------- Functions --------------------------------//
        //  Public functions
        public void Register()
        {
            if(Authentication() == true)
            {
                //Register
                main= new FrmMain();
                
                
                main.lblEmployeeName.Text = Login.txtUserName.Text;
                Login.Close(); // by Async way
                Thread th = new Thread(OpenMainForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }

            else
            {
                //Don't Register
                MessageBox.Show("The data is not true", "Message",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //  Private functions
        private bool Authentication()
        {
            // The third parameter is used as hint and doesn't used in the definiation of the function
            bool flag = db.tbEmployees.IsFound(Login.txtUserName.Text, Login.txtPassword.Text, ".");
            return flag;
        }

        private void OpenMainForm()
        {           
            Application.Run(main);
        }

        private void CreateEvents()
        {
            Login.btnLogin.Click += BtnLogin_Click;
        }

    }
}
