using CarageMS.Model;
using CarageMS.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarageMS.Controller
{
    public class BillController
    {
        DBCarageMs db;
        CtrlBilling page;
        tbBills bill;
        string employeeName;
        public BillController() { }

        public BillController(CtrlBilling page, string employeeName) 
        {
            this.page = page;
            this.employeeName = employeeName;
            db = new DBCarageMs();
            SetPosition();
            DefaultFillTextBoxes();
            CreateEvents();
        }

        //------------------- Events -----------------------//
        private void Page_Load(object sender, EventArgs e)
        {
            LoadCarNumbers();
            LoadCarPartsData();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddParts();
        }

        private void BtnSaveBill_Click(object sender, EventArgs e)
        {
            SaveBill(employeeName);
        }
       
        private void BtnCalculateFees_Click(object sender, EventArgs e)
        {
            CalculatTotalFees();
        }

        //----------------------- Private functions ----------------------//
        private void LoadCarPartsData()
        {
            //Get all CarParts from tbStocks and store them in dgvCarParts
            page.dgvCarParts.DataSource = db.tbStocks.ToList();
        }

        private void LoadCarNumbers()
        {
            //Get the car numbers and store in the cboCarNumber(ComboBox)
            page.cboCarNumber.Items.AddRange(db.tbCars.SelectAllCarNumbers());
        }

        private void SaveBill(string employeeName)
        {
            //Check if the entry data is true or no
            if (SaveBillValidations() == false)
                return;
            //declaration and intialaization variables and save the bill object(Entity) in dataBase
            double partFees = Convert.ToDouble(page.lblPartFees.Text);
            double totalFees = Convert.ToDouble(page.lblTotalFess.Text);
            double mechanicFees = totalFees - partFees;
            bill = new tbBills()
            {
                CarNumber = page.cboCarNumber.SelectedItem.ToString(),
                EmployeeName = employeeName,
                Date = page.pickerDate.Value,
                MechanicFess = mechanicFees,
                PartFess = partFees,
                TotalFess = totalFees
            };

            db.tbBills.Add(bill);
            Clear();
        }

        private void AddParts()
        {
            //checking before add any carParts
            if(AddPartsValidations() == false) 
                return;
            // Add information of sepicefic car part to dgvTotalCarParts
            DataGridViewRow selectedRow = page.dgvCarParts.CurrentRow;
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(page.dgvTotalCarParts);
            string partName = selectedRow.Cells[1].Value.ToString();
            int quantity = Convert.ToInt32(page.txtQuantity.Text);
            double price = Convert.ToDouble(selectedRow.Cells[3].Value);
            double total = (quantity * price);
            newRow.Cells[0].Value = partName;
            newRow.Cells[1].Value =  quantity;
            newRow.Cells[2].Value = price;
            newRow.Cells[3].Value = total;
            page.dgvTotalCarParts.Rows.Add(newRow);

            //Calculation the part fees
            CalculatPartFess(total);
        }

        private void DefaultFillTextBoxes()
        {
            // Fill the textBoxes by Default Words
            page.txtQuantity.Text = "Quantity";
            page.txtMechanicsFees.Text = "MechanicsFees";
            page.lblTotalFess.Text = "TotalFees";
            page.lblPartFees.Text = "PartFees";
        }

        private void CalculatTotalFees()
        {
            //Validations
            if(CalculatTotalFeesValidations() == false) 
                return;

            if(page.lblTotalFess.Text == "TotalFees")
                 page.lblTotalFess.Text = "0";

            double totalFees = Convert.ToDouble(page.txtMechanicsFees.Text) +
                Convert.ToDouble(page.lblPartFees.Text);
            page.lblTotalFess.Text = totalFees.ToString();
        }

        private bool SaveBillValidations()
        {

            // Validation(1): Checking message
            DialogResult d = MessageBox.Show("Did you sure to save the bill", "Message", MessageBoxButtons.OKCancel);
            if (d != DialogResult.OK)
                return false;

            // Validation(2): check from the text boxes if it is empty or default text
            bool EmptyValidation = (page.txtQuantity.Text == "" || page.txtMechanicsFees.Text == "" 
                || page.cboCarNumber.Text == "" || page.dgvTotalCarParts.Rows.Count == 0);

            bool DefaultTextValidation = (page.lblTotalFess.Text == "TotalFees");

            if (EmptyValidation || DefaultTextValidation)
            {
                MessageBox.Show("Error in insertion", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool AddPartsValidations()
        {
            // If the dgvCarParts is an empty or the txtQuantity is not number return false otherwise true
            if(page.dgvCarParts.Rows.Count == 0 || IsNumber(page.txtQuantity.Text) == false)
            {
                MessageBox.Show("Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool CalculatTotalFeesValidations()
        {
            // If the lblPartFess is an empty or the txtMechanicsFees is not number return false otherwise true
            if (page.lblPartFees.Text == "PartFees" || IsNumber(page.txtMechanicsFees.Text) == false)
            {
                MessageBox.Show("Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Clear()
        {
            DefaultFillTextBoxes();
            page.dgvTotalCarParts.Rows.Clear();
        }

        private void CalculatPartFess(double fees)
        {
            if (page.lblPartFees.Text == "PartFees")
                page.lblPartFees.Text = "0";

            double partFees = Convert.ToDouble(page.lblPartFees.Text) + fees;
            page.lblPartFees.Text = partFees.ToString();
        }

        private void SetPosition()
        {
            // Set the position of the ctrlBilling controles
            int pointY = 100, pointX = 200;
            page.dgvTotalCarParts.Height = page.dgvTotalCarParts.Height + 200;
            page.dgvTotalCarParts.Width = page.dgvTotalCarParts.Width + pointX;
            page.dgvTotalCarParts.Location = new Point(page.dgvTotalCarParts.Location.X, page.dgvTotalCarParts.Location.Y - pointY);
            page.btnSaveBill.Location = new Point(page.btnSaveBill.Location.X + pointX / 2, page.btnSaveBill.Location.Y + pointY);
            page.lblTotalFess.Location = new Point(page.lblTotalFess.Location.X + pointX / 2, page.lblTotalFess.Location.Y + pointY);
            page.lblPartFees.Location = new Point(page.lblPartFees.Location.X + pointX / 2, page.lblPartFees.Location.Y + pointY);
            page.dgvCarParts.Location = new Point(page.dgvCarParts.Location.X, page.dgvCarParts.Location.Y - pointY);
            page.dgvCarParts.Height = page.dgvCarParts.Height + 200;
            page.dgvCarParts.Width = page.dgvCarParts.Width + pointX;
            page.btnAdd.Location = new Point(page.btnAdd.Location.X + pointX / 2, page.btnAdd.Location.Y + pointY);
        }

        private bool IsNumber(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                // If there is one character don't equal digit return false otherwise return true
                if (char.IsDigit(s[i]) == false)
                    return false;
            }
            return true;
        }

        private void CreateEvents()
        {
            page.Load += Page_Load;
            page.btnAdd.Click += BtnAdd_Click;
            page.btnSaveBill.Click += BtnSaveBill_Click;
            page.btnCalculateFees.Click += BtnCalculateFees_Click;
        }

        
    }
}
