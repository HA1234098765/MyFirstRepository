using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CarageMS.Model
{
    public class Cars
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
        SqlConnection sqlConn = new SqlConnection(ConnectionString);
        public Cars() { }

        public void Add(tbCars car)
        {
            AddModifayDelete(car, OperatoinType.Add, CommandType.StoredProcedure, "sp_AddCar");
        }

        public void Modifay(tbCars car)
        {
            AddModifayDelete(car, OperatoinType.Modifay, CommandType.StoredProcedure, "sp_ModifayCar");
        }

        public void Delete(tbCars car)
        {
            AddModifayDelete(car, OperatoinType.Delete, CommandType.StoredProcedure, "sp_DeleteCar");
        }

        public bool IsFound(string conditionParameter)
        {
            // True if the car with same carNumber is found
            string Query = "Select ID From tbCars Where CarNumber = @CarNumber";
            SqlCommand cmd = new SqlCommand(Query, sqlConn);
            cmd.Parameters.AddWithValue("@CarNumber", conditionParameter);
            return ConnectionFind(cmd);
            
        }

        public bool IsFound(string conditionParameter1, string conditionParameter2)
        {
            // True if the car with same carNumber and deffrint ID is found
            string Query = "Select ID From tbCars Where CarNumber = @CarNumber and ID != @ID";
            SqlCommand cmd = new SqlCommand(Query, sqlConn);
            cmd.Parameters.AddWithValue("@CarNumber", conditionParameter1);
            cmd.Parameters.AddWithValue("@ID", conditionParameter2);
            return ConnectionFind(cmd);
        }

        public tbCars Select(int id)
        {
            // Set the connection and the command of DataBase
            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetCar", sqlConn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ID", id);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // get the data from car table (tbCars)
            tbCars car = new tbCars();
            car.CarNumber = dt.Rows[0]["CarNumber"].ToString();
            car.Brand = dt.Rows[0]["Brand"].ToString();
            car.Model = dt.Rows[0]["Model"].ToString();
            car.Date = Convert.ToDateTime(dt.Rows[0]["Date"]);
            car.Color = dt.Rows[0]["Color"].ToString();
            car.OwnerName = dt.Rows[0]["OwnerName"].ToString();
            
              return car;
        }


        public string[] SelectAllCarNumbers()
        {
            string selectStatment = "SELECT CarNumber FROM tbCars";
            SqlDataAdapter adapter = new SqlDataAdapter(selectStatment, sqlConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string[] list = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list[i] = dt.Rows[i].ItemArray[0].ToString();
            }
            return list;
        }

        public DataTable ToList()
        {
            // Get all data from car table (tbCars)
            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetAllCars", sqlConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public int Count()
        {
            // Get the the number of the records in tbCars Table
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM tbCars", sqlConn);
            int count = 0;
            try
            {
                sqlConn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return count;
        }


        //-------------------------------Privat functions----------------------------------//
        private void AddModifayDelete(tbCars car, OperatoinType opType, CommandType cmdType, string commandText)
        {
            // Intialaizing 
            SqlCommand cmd = new SqlCommand(commandText, sqlConn);
            cmd.CommandType = cmdType;
            if (opType == OperatoinType.Add || opType == OperatoinType.Modifay) // insert or update operation on the Database
            {

                // Set the parameters of stored procedure 
                cmd.Parameters.AddWithValue("@CarNumber", car.CarNumber);
                cmd.Parameters.AddWithValue("@Brand", car.Brand);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Date", car.Date);
                cmd.Parameters.AddWithValue("@Color", car.Color);
                cmd.Parameters.AddWithValue("@OwnerName", car.OwnerName);
            }
             if (opType == OperatoinType.Delete || opType == OperatoinType.Modifay) // delete operation on the Database
                // Set the parameters of stroed procedure
                cmd.Parameters.AddWithValue("@Id", car.ID);
            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        }

        private bool ConnectionFind(SqlCommand cmd)
        {
            // return True if there is one or more record, False otherwise
            bool flag = false;
            try
            {
                sqlConn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                flag = dr.Read();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }

            return flag;
        }
    }
}
