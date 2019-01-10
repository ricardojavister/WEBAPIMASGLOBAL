using System;
using System.Collections.Generic;
using System.Text;
using MSGLOBAL.RepositoryPattern.Model;
using MSGLOBAL.RepositoryPattern.Factory;

namespace MSGLOBAL.Business
{
    public static class EmployeeBusiness
    {
        public static IEnumerable<Employee> GetEmployees(IEnumerable<Employee> listOfEmployees)
        {
            EmployeeFactory factory = new ConcreteEmployeeFactory();
            List<Employee> listOfEmployeeNew = new List<Employee>();
            
            foreach (Employee x in listOfEmployees)
            {
                IEmployeeFactory employee = factory.GetEmployee(x);
                x.annualSalary = employee.CalculateAnnualSalary(x.contractTypeName);
                listOfEmployeeNew.Add(x);
            }

            return (IEnumerable<Employee>)listOfEmployeeNew;
        }
    }
}
