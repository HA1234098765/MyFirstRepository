using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Collections;

namespace CarageMS.Model
{
    public class Bills
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
        SqlConnection sqlConn = new SqlConnection(ConnectionString);

        public Bills() { }

        public void Add(tbBills bill)
        {
            AddModifayDelete("sp_AddBill", CommandType.StoredProcedure, OperatoinType.Add, bill);
        }

        public void Modifay(tbBills bill)
        {
            AddModifayDelete("sp_ModifayBill", CommandType.StoredProcedure, OperatoinType.Modifay, bill);
        }

        public void Delete(tbBills bill)
        {
            AddModifayDelete("sp_DeleteBill", CommandType.StoredProcedure, OperatoinType.Delete, bill);
        }

        public tbBills Select(int id)
        {
            // Set the connection and the command of DataBase
            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetBill", sqlConn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ID", id);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // get the data from bill table (tbBills)
            tbBills bill = new tbBills();
            bill.BillNumber = Convert.ToInt32(dt.Rows[0]["BillNumber"]);
            bill.CarNumber = dt.Rows[0]["CarNumber"].ToString();
            bill.EmployeeName = dt.Rows[0]["EmployeeName"].ToString();
            bill.Date = Convert.ToDateTime(dt.Rows[0]["Date"]);
            bill.MechanicFess = Convert.ToDouble( dt.Rows[0]["MechanicFess"]);
            bill.PartFess = Convert.ToDouble(dt.Rows[0]["PartFess"]);
            bill.TotalFess = Convert.ToDouble(dt.Rows[0]["TotalFess"]);
            return bill;
        }

        public List<tbBills> Select(string SelectStatment)
        {
            return null;
        }

        public DataTable ToList()
        {
            // Get all data from bill table (tbBills)
            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetAllBills", sqlConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public double GetSumOfTotalFeess()
        {
            // Get the the sumation of all TotalFees Column in tbBills Table
            SqlCommand cmd = new SqlCommand("SELECT Sum(TotalFees) FROM tbBills", sqlConn);
            double sum = 0;
            try
            {
                sqlConn.Open();
                sum = Convert.ToDouble( cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return sum;
        }

        //-----------------------------------Private functions-----------------------------------
        private void AddModifayDelete(string commandText, CommandType cmdType, OperatoinType opType, tbBills bill)
        {
            // Intialaizing 
            SqlCommand cmd = new SqlCommand(commandText, sqlConn);
            cmd.CommandType = cmdType;
            if (opType == OperatoinType.Add || opType == OperatoinType.Modifay) // insert or update operation on the Database
            {

                // Set the parameters of stored procedure 
                cmd.Parameters.AddWithValue("@CarNumber", bill.CarNumber);
                cmd.Parameters.AddWithValue("@EmployeeName", bill.EmployeeName);
                cmd.Parameters.AddWithValue("@Date", bill.Date);
                cmd.Parameters.AddWithValue("@MechanicsFees", bill.MechanicFess);
                cmd.Parameters.AddWithValue("@PartFees", bill.PartFess);
                cmd.Parameters.AddWithValue("@TotalFees", bill.TotalFess);
            }
            if (opType == OperatoinType.Delete || opType == OperatoinType.Modifay) // delete operation on the Database
                // Set the parameters of stroed procedure
                cmd.Parameters.AddWithValue("@BillNumber", bill.BillNumber);
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
    }
}
