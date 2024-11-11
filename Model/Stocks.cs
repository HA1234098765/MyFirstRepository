using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarageMS.Model
{
    public class Stocks
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
        SqlConnection sqlConn = new SqlConnection(ConnectionString);
        public Stocks() { }

        public void Add(tbStocks stock)
        {
            AddModifayDelete("sp_AddStock", CommandType.StoredProcedure, OperatoinType.Add, stock);
        }

        public void Modifay(tbStocks stock)
        {
            AddModifayDelete("sp_ModifayStock", CommandType.StoredProcedure, OperatoinType.Modifay, stock);
        }

        public void Delete(tbStocks stock)
        {
            AddModifayDelete("sp_DeleteStock", CommandType.StoredProcedure, OperatoinType.Delete, stock);
        }

        public bool IsFound(string conditionParameter)
        {
            // True if the Stock with same Name(conditionParameter) is found
            string Query = "Select ID From tbStocks Where Name = @Name";
            SqlCommand cmd = new SqlCommand(Query, sqlConn);
            cmd.Parameters.AddWithValue("@Name", conditionParameter);
            return ConnectionFind(cmd);

        }

        public bool IsFound(string conditionParameter1, string conditionParameter2)
        {
            // True if the Stock with same Name(conditionParameter1) and deffrint ID(conditionParameter2) is found
            string Query = "Select ID From tbStocks Where Name = @Name and ID != @ID";
            SqlCommand cmd = new SqlCommand(Query, sqlConn);
            cmd.Parameters.AddWithValue("@Name", conditionParameter1);
            cmd.Parameters.AddWithValue("@ID", conditionParameter2);
            return ConnectionFind(cmd);
        }

        public tbStocks Select(int id)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetStock", sqlConn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ID", id);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            tbStocks stock = new tbStocks();
            stock.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
            stock.Name = dt.Rows[0]["Name"].ToString();
            stock.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
            stock.Price = Convert.ToDouble(dt.Rows[0]["Price"]);
            return stock;
        }

        public List<tbStocks> Select(string SelectStatment)
        {
           
            
            return null;
        }

        public DataTable ToList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetAllStocks", sqlConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public int Count()
        {
            // Get the the number of the records in tbStocks Table
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM tbStocks", sqlConn);
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

        //----------------------------------Private functions----------------------------
        private void AddModifayDelete(string commandText, CommandType cmdType, OperatoinType opType, tbStocks stock)
        {
            // Intialaizing 
            SqlCommand cmd = new SqlCommand(commandText, sqlConn);
            cmd.CommandType = cmdType;
            if (opType == OperatoinType.Add || opType == OperatoinType.Modifay) // insert or update operation on the Database
            {
                
                // Set the parameters of stored procedure 
                cmd.Parameters.AddWithValue("@Name", stock.Name);
                cmd.Parameters.AddWithValue("@Quantity", stock.Quantity);
                cmd.Parameters.AddWithValue("@Price", stock.Price);
            }
            if (opType == OperatoinType.Delete || opType == OperatoinType.Modifay) // delete operation on the Database
                // Set the parameters of stroed procedure
                cmd.Parameters.AddWithValue("@ID", stock.Id);
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
