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
    enum OperatoinType { Add, Modifay, Delete};
    public class Employees
    {
      static  string ConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
        SqlConnection sqlConn = new SqlConnection(ConnectionString);

        public Employees() { }

        public void Add(tbEmployees employee)
        {
            AddModifayDelete(employee, OperatoinType.Add, CommandType.StoredProcedure, "sp_AddEmployee");
        }

        public void Modifay(tbEmployees employee)
        {
            AddModifayDelete(employee, OperatoinType.Modifay, CommandType.StoredProcedure, "sp_ModifayEmployee");
        }

        public void Delete(tbEmployees employee)
        {
            AddModifayDelete(employee, OperatoinType.Delete, CommandType.StoredProcedure, "sp_DeleteEmployee");
        }

        public bool IsFound(string conditionParameter)
        {
            // True if the Employee with same Name(conditionParameter) is found
            string Query = "Select ID From tbEmployees Where Name = @Name";
            SqlCommand cmd = new SqlCommand(Query, sqlConn);
            cmd.Parameters.AddWithValue("@Name", conditionParameter);
            return ConnectionFind(cmd);

        }

        public bool IsFound(string conditionParameter1, string conditionParameter2)
        {
            // True if the Employee with same Name(conditionParameter1) and deffrint ID(conditionParameter2) is found
            string Query = "Select ID From tbEmployees Where Name = @Name and ID != @ID";
            SqlCommand cmd = new SqlCommand(Query, sqlConn);
            cmd.Parameters.AddWithValue("@Name", conditionParameter1);
            cmd.Parameters.AddWithValue("@ID", conditionParameter2);
            return ConnectionFind(cmd);
        }

        public bool IsFound(string userName, string password, string hint)
        {
            // hint: (From name it is a hint to deffrint bettwen overloadin IsFound functions
            // True if the Employee with same Name(userName) and same Password(password) is found
            string Query = "Select * From tbEmployees Where Name = @Name and Password = @Password";
            SqlCommand cmd = new SqlCommand(Query, sqlConn);
            cmd.Parameters.AddWithValue("@Name", userName);
            cmd.Parameters.AddWithValue("@Password", password);
            return ConnectionFind(cmd);
        }

        public tbEmployees Select(int id)
        {
            // Intialaizing 
            tbEmployees employee = new tbEmployees();
            SqlCommand cmd = new SqlCommand("sp_GetEmployee", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            // Set the parameters of stroed procedure
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                sqlConn.Open();
               SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                   employee.ID = Convert.ToInt32(dr[0]);
                   employee.Name = dr[1].ToString();
                   employee.Address =  dr[2].ToString();
                   employee.Password = dr[3].ToString();
                   employee.Phone = dr[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            return employee;
        }

        public List<tbEmployees> SelectEmployees(string SelectStatment)
        {
            //// Intialaizing 
            //tbEmployees employee = new tbEmployees();
            //SqlCommand cmd = new SqlCommand(SelectStatment, sqlConn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //// Set the parameters of stroed procedure
            //cmd.Parameters.AddWithValue("@ID", id);

            //try
            //{
            //    sqlConn.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        employee.ID = Convert.ToInt32(dr[0]);
            //        employee.Name = dr[1].ToString();
            //        employee.Address = dr[2].ToString();
            //        employee.Password = dr[3].ToString();
            //        employee.Gender = dr[4].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    sqlConn.Close();
            //}
            return null;
        }

        public DataTable ToList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetAllEmployees", sqlConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public int Count()
        {
            // Get the the number of the records in tbEmployees Table
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM tbEmployees", sqlConn);
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
        private void AddModifayDelete(tbEmployees employee, OperatoinType op, CommandType cmdType, string commandText)
        {
            // Intialaizing 
            SqlCommand cmd = new SqlCommand(commandText, sqlConn);
            cmd.CommandType = cmdType;
            if(op == OperatoinType.Add || op == OperatoinType.Modifay)
            {
                // Set the parameters of stored procedure
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@Phone", employee.Phone);
            }
            if (op == OperatoinType.Delete || op == OperatoinType.Modifay)
                // Set the parameters of stroed procedure
                cmd.Parameters.AddWithValue("@ID", employee.ID);
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
