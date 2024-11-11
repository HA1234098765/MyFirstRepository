using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarageMS.Model;
using CarageMS.View;

namespace CarageMS.Controller
{
    enum AddOrEdite { Add, Edite};
    public class CarController
    {
        DBCarageMs db;
        ctrlCar page;
        tbCars car;
        
        public CarController()
        {

        }

        public CarController(ctrlCar page)
        {
            // Initialization ctrlCar object(page) and dataBase model object(db)
            this.page = page;
            db = new DBCarageMs();
            CreateEvents();
            LoadCarsData();
        }

        //----------------- Events -----------------//
        private void Page_Load(object sender, EventArgs e)
        {
            DefaultFillTextBoxes();
        }
        private void BtnAddCar_Click(object sender, EventArgs e)
        {
            AddCar();
        }

        private void BtnEditeCar_Click(object sender, EventArgs e)
        {
            ModifayCar();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteCar();
        }

        private void DgvCars_SelectionChanged(object sender, EventArgs e)
        {
            FillTextBoxes();
        }

        private void LoadCarsData()
        {
            //Get All records of tbCars from DataBase
            page.dgvCars.DataSource = db.tbCars.ToList();
        }


        //-------------------private functions--------------------//
        private void AddCar()
        {
            // Add record to tbCars table
            if (Validation(AddOrEdite.Add) == false)
                return;
            car = new tbCars()
            {
                CarNumber = page.txtCarNumber.Text,
                Brand = page.txtBrand.Text,
                Model = page.txtModel.Text,
                Date = page.pickerDate.Value,
                Color = page.txtColor.Text,
                OwnerName = page.txtOwnerName.Text
            };
            
            db.tbCars.Add(car);
            LoadCarsData();
        }


        private void ModifayCar()
        {
            // Modifay  record to tbCars table
            if (Validation(AddOrEdite.Edite) == false)
                return;
            car = new tbCars()
            {
                ID = Convert.ToInt16(page.dgvCars.CurrentRow.Cells[0].Value),
                CarNumber = page.txtCarNumber.Text,
                Brand = page.txtBrand.Text,
                Model = page.txtModel.Text,
                Date = page.pickerDate.Value,
                Color = page.txtColor.Text,
                OwnerName = page.txtOwnerName.Text
            };
            
            db.tbCars.Modifay(car);
            LoadCarsData();
        }

        private void DeleteCar()
        {
            // Delete record from tbCars table
            DialogResult d = MessageBox.Show("Did you sure", "Message", MessageBoxButtons.OKCancel);
            if (d != DialogResult.OK)
                return;
                    
            car = new tbCars()
            {
                ID = Convert.ToInt16(page.dgvCars.CurrentRow.Cells[0].Value),
                CarNumber = page.txtCarNumber.Text,
                Brand = page.txtBrand.Text,
                Model = page.txtModel.Text,
                Date = page.pickerDate.Value,
                Color = page.txtColor.Text,
                OwnerName = page.txtOwnerName.Text
            };
            
            db.tbCars.Delete(car);
            LoadCarsData();
        }

        private void DefaultFillTextBoxes()
        {
            // Fill the textBoxes by Default Words
            page.txtCarNumber.Text = "CarNumber";
            page.txtBrand.Text = "Brand";
            page.txtModel.Text = "Model";
            page.txtColor.Text = "Color";
            page.txtOwnerName.Text = "OwnerName";
        }

        private void FillTextBoxes()
        {
            // Fill the textBoxes by data of the selected Row
            page.txtCarNumber.Text = page.dgvCars.CurrentRow.Cells[1].Value.ToString();
            page.txtBrand.Text = page.dgvCars.CurrentRow.Cells[2].Value.ToString();
            page.txtModel.Text = page.dgvCars.CurrentRow.Cells[3].Value.ToString();
            page.txtColor.Text = page.dgvCars.CurrentRow.Cells[5].Value.ToString();
            page.txtOwnerName.Text = page.dgvCars.CurrentRow.Cells[6].Value.ToString(); 
        }

       
        private bool Validation(AddOrEdite ae)
        {
            
            // Validation(1): Checking message
            DialogResult d = MessageBox.Show("Did you sure", "Message", MessageBoxButtons.OKCancel);
            if (d != DialogResult.OK)
                return false;

            // Validation(2): check from the text boxes if it is empty or default text
            bool EmptyValidation = (page.txtCarNumber.Text == "" || page.txtBrand.Text == "" ||
              page.txtModel.Text == "" || page.txtColor.Text == "" || page.txtOwnerName.Text == "");

            bool DefaultTextValidation = (page.txtCarNumber.Text == "CarNumber" || page.txtBrand.Text == "Brand" ||
              page.txtModel.Text == "Model" || page.txtColor.Text == "Color"
              || page.txtOwnerName.Text == "OwnerName");

            if (EmptyValidation || DefaultTextValidation)
            {
                MessageBox.Show("Error in insertion", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validation(3): Check to prevent the duplicat CarNumber Either in Add or Edite operatoin
            
            bool AddOrEditeValedation = false;
            if (ae == AddOrEdite.Add)
            {
                AddOrEditeValedation = db.tbCars.IsFound(page.txtCarNumber.Text);
                
            }
            else if(ae == AddOrEdite.Edite)
            {
                int id = Convert.ToInt16(page.dgvCars.CurrentRow.Cells[0].Value);
                 AddOrEditeValedation = db.tbCars.IsFound(page.txtCarNumber.Text, id.ToString());
            }

            if (AddOrEditeValedation)
            {
                MessageBox.Show("Sory there is already car with same number");
                return false;
            }

            return true;
        }

        private void CreateEvents()
        {
            page.Load += Page_Load;
            page.btnAddCar.Click += BtnAddCar_Click;
            page.btnEditeCar.Click += BtnEditeCar_Click;
            page.btnDelete.Click += BtnDelete_Click;
            page.dgvCars.SelectionChanged += DgvCars_SelectionChanged;
        }

        
    }
}
