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
            Console.WriteLine("6. Retrieve data from Sql");
            Console.WriteLine("7. Update Salary data in table");
            Console.WriteLine("8. View the employee details between date range");
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
                case 6:
                    ER er = new ER();
                    er.RetrieveAllData();
                    break;
                case 7:
                    ER eRRepository = new ER();
                    eRRepository.UpdateSalaryQuery();
                    eRRepository.RetrieveAllData();
                    break;
                case 8:
                    ER eR = new ER();
                    eR.DataBasedOnDateRange();
                    break;
            }
        }
    }
}
