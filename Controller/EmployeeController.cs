using CarageMS.Model;
using CarageMS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarageMS.Controller
{
    public class EmployeeController
    {
        DBCarageMs db;
        ctrlEmployees page;
        tbEmployees employee;

        public EmployeeController()
        {

        }

        public EmployeeController(ctrlEmployees page)
        {
            // Initialization ctrlEmployee object(page) and dataBase model object(db)
            this.page = page;
            db = new DBCarageMs();
            CreateEvents();
            LoadEmployeesData();
        }

        //------------ Events --------------//
        private void Page_Load(object sender, EventArgs e)
        {
            DefaultFillTextBoxes();
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }

        private void BtnEditeEmployee_Click(object sender, EventArgs e)
        {
            ModifayEmployee();
        }

        private void BtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }
       
        private void DgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            FillTextBoxes();
        }


        //------------------- Private functions--------------------//
        private void LoadEmployeesData()
        {
            //Get All records of tbEmployees from DataBase
            page.dgvEmployees.DataSource = db.tbEmployees.ToList();
        }

        private void AddEmployee()
        {
            // Add record to tbEmployees table
            if (Validation(AddOrEdite.Add) == false)
                return;
            employee = new tbEmployees()
            {
                Name = page.txtName.Text,
                Address = page.txtAdderss.Text,
                Password = page.txtPassword.Text,
               Phone = page.txtPassword.Text
            };

            db.tbEmployees.Add(employee);
            LoadEmployeesData();
        }

        private void ModifayEmployee()
        {
            // Modifay  record to tbCars table
            if (Validation(AddOrEdite.Edite) == false)
                return;
            employee = new tbEmployees()
            {
                ID = Convert.ToInt16( page.dgvEmployees.CurrentRow.Cells[0].Value),
                Name = page.txtName.Text,
                Address = page.txtAdderss.Text,
                Password = page.txtPassword.Text,
                Phone = page.txtPhone.Text
            };

            db.tbEmployees.Modifay(employee);
            LoadEmployeesData();
        }

        private void DeleteEmployee()
        {
            // Delete record from tbEmployees table
            DialogResult d = MessageBox.Show("Did you sure to delete this employee", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (d != DialogResult.OK)
                return;

            employee = new tbEmployees()
            {
                ID = Convert.ToInt16(page.dgvEmployees.CurrentRow.Cells[0].Value),
                Name = page.txtName.Text,
                Address = page.txtAdderss.Text,
                Password = page.txtPassword.Text,
                Phone = page.txtPhone.Text
            };

            db.tbEmployees.Delete(employee);
            LoadEmployeesData();
        }

        private void DefaultFillTextBoxes()
        {
            // Fill the textBoxes by Default Words
            page.txtName.Text = "Name";
            page.txtAdderss.Text = "Address";
            page.txtPassword.Text = "Password";
            page.txtPhone.Text = "Phone";
        }

        private void FillTextBoxes()
        {
            // Fill the textBoxes by data of the selected Row
            page.txtName.Text =   page.dgvEmployees.CurrentRow.Cells[1].Value.ToString();
            page.txtAdderss.Text = page.dgvEmployees.CurrentRow.Cells[2].Value.ToString();
            page.txtPassword.Text = page.dgvEmployees.CurrentRow.Cells[3].Value.ToString();
            page.txtPhone.Text =  page.dgvEmployees.CurrentRow.Cells[4].Value.ToString();
             
        }

        private bool Validation(AddOrEdite ae)
        {

            // Validation(1): Checking message
            DialogResult d = MessageBox.Show("Did you sure", "Message", MessageBoxButtons.OKCancel);
            if (d != DialogResult.OK)
                return false;

            // Validation(2): check from the text boxes if it is empty or default text
            bool EmptyValidation = (page.txtName.Text == "" || page.txtAdderss.Text == "" ||
              page.txtPassword.Text == "" || page.txtPhone.Text == "" );

            bool DefaultTextValidation = (page.txtName.Text == "Name" || page.txtAdderss.Text == "Address" ||
              page.txtPassword.Text == "Password" || page.txtPhone.Text == "Phone");

            if (EmptyValidation || DefaultTextValidation)
            {
                MessageBox.Show("Error in insertion", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validation(3): Check to prevent the duplicat CarNumber Either in Add or Edite operatoin

            bool AddOrEditeValedation = false;
            if (ae == AddOrEdite.Add)
            {
                AddOrEditeValedation = db.tbEmployees.IsFound(page.txtName.Text);

            }
            else if (ae == AddOrEdite.Edite)
            {
                int id = Convert.ToInt16(page.dgvEmployees.CurrentRow.Cells[0].Value);
                AddOrEditeValedation = db.tbEmployees.IsFound(page.txtName.Text, id.ToString());
            }

            if (AddOrEditeValedation)
            {
                MessageBox.Show("Sory there is already Employee with same Name");
                return false;
            }

            return true;
        }

        private void CreateEvents()
        {
            page.Load += Page_Load;
            page.btnAddEmployee.Click += BtnAddEmployee_Click;
            page.btnEditeEmployee.Click += BtnEditeEmployee_Click;
            page.btnDeleteEmployee.Click += BtnDeleteEmployee_Click;
            page.dgvEmployees.SelectionChanged += DgvEmployees_SelectionChanged;
        }

        
    }
}

