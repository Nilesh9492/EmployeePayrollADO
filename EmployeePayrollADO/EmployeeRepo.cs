using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Sql
using System.Text;

namespace EmployeePayrollADO
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=paroll_service;Integrated Security=True";
        SqlConnection sqlconnection = new SqlConnection(connectionString);
    }
}
