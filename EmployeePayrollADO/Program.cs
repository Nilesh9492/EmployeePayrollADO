using System;

namespace EmployeePayrollADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Payroll ADO!");
            EmployeeRepo repository = new EmployeeRepo();
            repository.GetEmployeeDetails();
        }
    }
}
