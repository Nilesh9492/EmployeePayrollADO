using System;

namespace EmployeePayrollADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Payroll ADO!");
            EmployeeRepo repository = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel();
            Console.WriteLine("Enter \n 1.Retrieve Data from Sql server");
            Console.WriteLine("2. Update Salary to 3000000");
            Console.WriteLine("3. Retrieve Updated Salary");
            Console.WriteLine("4. Retrieve Data Based on Date");
            Console.WriteLine("5. Algebric Functions");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    repository.GetEmployeeDetails();
                    break;
                case 2:
                    repository.UpdateSalaryColumn(model);
                    repository.GetEmployeeDetails();
                    break;
                case 3:
                    repository.GetEmployeeDetails();
                    break;
                case 4:
                    EmployeeRepo repo = new EmployeeRepo();
                    repo.ViewDataBasedOnDate(model);
                    break;
                case 5:
                    EmployeeRepo repository1 = new EmployeeRepo();
                    repository1.AlgebricFunctions("F");
                    break;
            }
        }
    }
}
