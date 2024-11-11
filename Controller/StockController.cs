using CarageMS.Model;
using CarageMS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarageMS.Controller
{
    public class StockController
    {
        DBCarageMs db;
        ctrlStock page;
        tbStocks stock;

        public StockController()
        {

        }

        public StockController(ctrlStock page)
        {
            // Initialization ctrlStock object(page) and dataBase model object(db)
            this.page = page;
            db = new DBCarageMs();
            LoadStocksData();
            CreateEvents();
        }

        //--------------- Events -------------------//
        private void Page_Load(object sender, EventArgs e)
        {
            DefaultFillTextBoxes();
        }

        private void BtnAddStock_Click(object sender, EventArgs e)
        {
            AddStock();
        }
        private void BtnEditeStock_Click(object sender, EventArgs e)
        {
            ModifayStock();
        }

        private void BtnDeleteStock_Click(object sender, EventArgs e)
        {
            DeleteStock();
        }


        private void DgvStocks_SelectionChanged(object sender, EventArgs e)
        {
            FillTextBoxes();
        }

        public void LoadStocksData()
        {
            //Get All records of tbStocks from DataBase
            page.dgvStocks.DataSource = db.tbStocks.ToList();
        }


        //-------------------private functions--------------------//
        private void AddStock()
        {
            // Add record to tbStocks table
            if (Validation(AddOrEdite.Add) == false)
                return;
            stock = new tbStocks()
            {
                Name = page.txtName.Text,
                Quantity = Convert.ToInt32( page.txtQuantity.Text),
                Price = Convert.ToDouble(page.txtPrice.Text)
            };

            db.tbStocks.Add(stock);
            LoadStocksData();
        }


        private void ModifayStock()
        {
            // Modifay  record to tbStocks table
            if (Validation(AddOrEdite.Edite) == false)
                return;
            stock = new tbStocks()
            {
                Id = Convert.ToInt32( page.dgvStocks.CurrentRow.Cells[0].Value),
                Name = page.txtName.Text,
                Quantity = Convert.ToInt32(page.txtQuantity.Text),
                Price = Convert.ToDouble(page.txtPrice.Text)
            };

            db.tbStocks.Modifay(stock);
            LoadStocksData();
        }

        private void DeleteStock()
        {
            // Delete record from tbStocks table
            DialogResult d = MessageBox.Show("Did you sure to delete this", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (d != DialogResult.OK)
                return;

            stock = new tbStocks()
            {
                Id = Convert.ToInt32(page.dgvStocks.CurrentRow.Cells[0].Value),
                Name = page.txtName.Text,
                Quantity = Convert.ToInt32(page.txtQuantity.Text),
                Price = Convert.ToDouble(page.txtPrice.Text)
            };

            db.tbStocks.Delete(stock);
            LoadStocksData();
        }

        private void DefaultFillTextBoxes()
        {
            // Fill the textBoxes by Default Words
            page.txtName.Text = "PartName";
            page.txtQuantity.Text = "Quantity";
            page.txtPrice.Text = "Price";
        }

        private void FillTextBoxes()
        {
            // Fill the textBoxes by data from selected Row
            page.txtName.Text = page.dgvStocks.CurrentRow.Cells[1].Value.ToString();
            page.txtQuantity.Text = page.dgvStocks.CurrentRow.Cells[2].Value.ToString();
            page.txtPrice.Text = page.dgvStocks.CurrentRow.Cells[3].Value.ToString();
        }

        private bool Validation(AddOrEdite ae)
        {

            // Validation(1): Checking message
            DialogResult d = MessageBox.Show("Did you sure", "Message", MessageBoxButtons.OKCancel);
            if (d != DialogResult.OK)
                return false;

            // Validation(2): check from the text boxes if it is empty or default text
            bool EmptyValidation = (page.txtName.Text == "" || page.txtQuantity.Text == "" ||
              page.txtPrice.Text == "");

            bool DefaultTextValidation = (page.txtName.Text == "PartName" || page.txtQuantity.Text == "Quantity" ||
              page.txtPrice.Text == "Price");

            if (EmptyValidation || DefaultTextValidation)
            {
                MessageBox.Show("Error in insertion", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validation(3): Check to prevent the duplicat PartName Either in Add or Edite operatoin

            bool AddOrEditeValedation = false;
            if (ae == AddOrEdite.Add)
            {
                AddOrEditeValedation = db.tbStocks.IsFound(page.txtName.Text);

            }
            else if (ae == AddOrEdite.Edite)
            {
                int id = Convert.ToInt16(page.dgvStocks.CurrentRow.Cells[0].Value);
                AddOrEditeValedation = db.tbStocks.IsFound(page.txtName.Text, id.ToString());
            }

            if (AddOrEditeValedation)
            {
                MessageBox.Show("Sory there is already Parts with same Name");
                return false;
            }

            return true;
        }

        private void CreateEvents()
        {
            page.Load += Page_Load;
            page.btnAddStock.Click += BtnAddStock_Click;
            page.btnDeleteStock.Click += BtnDeleteStock_Click;
            page.btnEditeStock.Click += BtnEditeStock_Click;
            page.dgvStocks.SelectionChanged += DgvStocks_SelectionChanged;
        }

       
    }
}

