using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollADO
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=paroll_service;";
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        public void GetEmployeeDetails()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                string query = @"select * from employee_payroll";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                this.sqlconnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeModel.empId = Convert.ToInt32(reader["EmpId"]);
                        employeeModel.name = reader["name"].ToString();
                        employeeModel.Salary = Convert.ToDouble(reader["BasicPay"]);
                        employeeModel.startDate = reader.GetDateTime(3);
                        employeeModel.emailId = reader["emailId"].ToString();
                        employeeModel.Gender = reader["Gender"].ToString();
                        employeeModel.Department = reader["Department"].ToString();
                        employeeModel.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                        employeeModel.Address = reader["Address"].ToString();
                        employeeModel.Deductions = Convert.ToDouble(reader["Deductions"]);
                        employeeModel.TaxablePay = Convert.ToDouble(reader["TaxablePay"]);
                        employeeModel.IncomeTax = Convert.ToDouble(reader["IncomeTax"]);
                        employeeModel.NetPay = Convert.ToDouble(reader["NetPay"]);
                        Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11} {12}", employeeModel.empId, employeeModel.name, employeeModel.Salary, employeeModel.startDate, employeeModel.emailId, employeeModel.Gender, employeeModel.Department, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Deductions, employeeModel.TaxablePay, employeeModel.IncomeTax, employeeModel.NetPay);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("data not found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public void UpdateSalaryColumn(EmployeeModel model)
        {
            try
            {
                sqlconnection.Open();
                string query = @"update employee_payroll set salary=3000000 where name='Nilesh'";
                SqlCommand command = new SqlCommand(query, sqlconnection);

                int result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Salary Updated Successfully ");
                }
                else
                {
                    Console.WriteLine("salary update failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }

        }
        public void UpdateSalary()
        {
            EmployeeModel data = new EmployeeModel();
            using (this.sqlconnection)
            {
                SqlCommand command = new SqlCommand("UpdateBasePay", this.sqlconnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", data.empId);
                command.Parameters.AddWithValue("@name ", data.name);
                command.Parameters.AddWithValue("@salary", data.Salary);
                this.sqlconnection.Open();
                int res = command.ExecuteNonQuery();
                if (res == 0)
                {
                    Console.WriteLine("Query Not executed.");
                }
                else
                {
                    Console.WriteLine("Query executed successfully.");
                }
                this.sqlconnection.Close();
            }
        }
        public int ViewDataBasedOnDate(EmployeeModel model)
        {

            int count = 0;
            using (sqlconnection)
            {

                string query = @"select * from employee_payroll where startDate between('2021-01-01') and getdate()";

                SqlCommand command = new SqlCommand(query, this.sqlconnection);

                sqlconnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ViewEmployeeDetails(reader);
                        count++;
                    }
                }
                reader.Close();
            }
            return count;
        }
        public void ViewEmployeeDetails(SqlDataReader reader)
        {
            EmployeeModel model = new EmployeeModel();

            model.empId = Convert.ToInt32(reader["empId"]);
            model.name = reader["name"].ToString();
            model.Salary = Convert.ToDouble(reader["Salary"]);
            model.startDate = reader.GetDateTime(3);
            model.emailId = reader["emailId"].ToString();
            model.Gender = reader["Gender"].ToString();
            model.Department = reader["Department"].ToString();
            model.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
            model.Address = reader["Address"].ToString();
            model.Deductions = Convert.ToDouble(reader["Deductions"]);
            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"]);
            model.IncomeTax = Convert.ToDouble(reader["IncomeTax"]);
            model.NetPay = Convert.ToDouble(reader["NetPay"]);
            Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11} {12}", model.empId, model.name, model.Salary, model.startDate, model.emailId, model.Gender, model.Department, model.PhoneNumber, model.Address, model.Deductions, model.TaxablePay, model.IncomeTax, model.NetPay);
            Console.WriteLine("\n");

        }
        public string AlgebricFunctions(string Gender)
        {
            string result = null;
            string query = @"select sum(Salary) as TotalSalary,min(Salary) as MinSalary,max(Salary) as MaxSalary,Round(avg(Salary),0) as AvgSalary,Gender,Count(*) from employee_payroll where Gender =" + "'" + Gender + "'" + " group by Gender";
            SqlCommand sqlCommand = new SqlCommand(query, this.sqlconnection);
            sqlconnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Total Salary {0}", reader[0]);
                    Console.WriteLine("Min Salary {0}", reader[1]);
                    Console.WriteLine("Max Salary {0}", reader[2]);
                    Console.WriteLine("Average Salary {0}", reader[3]);
                    Console.WriteLine("Grouped By Gender {0}", reader[4]);
                    Console.WriteLine("No of employess {0}", reader[5]);
                    result += reader[4] + " " + reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[5];
                }
            }
            else
            {
                result = "Table is Empty";
            }
            reader.Close();
            return result;
        }
    } 
}

    

