using System;
using System.Collections.Generic;
using System.Text;
using MSGLOBAL.RepositoryPattern.Model;

namespace MSGLOBAL.RepositoryPattern.Factory
{
    public interface IEmployeeFactory
    {
        decimal CalculateAnnualSalary(string contractTypeName);
    }

    public class EmployeePaymentPerHour : Employee, IEmployeeFactory
    {
        public EmployeePaymentPerHour(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary) : base (id,name,contractTypeName,roleId,roleName,roleDescription,hourlySalary,monthlySalary)
        {
           
        }
        public decimal CalculateAnnualSalary(string contractTypeName)
        {
            return 120 * hourlySalary * 12;
        }
    }

    public class EmployeePaymentPerMonth : Employee, IEmployeeFactory
    {
        public EmployeePaymentPerMonth(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary) : base(id, name, contractTypeName, roleId, roleName, roleDescription, hourlySalary, monthlySalary)
        {

        }
        public decimal CalculateAnnualSalary(string contractTypeName)
        {
            return monthlySalary * 12;
        }
    }

    public abstract class EmployeeFactory
    {
        public abstract IEmployeeFactory GetEmployee(Employee item);

    }

    public class ConcreteEmployeeFactory : EmployeeFactory
    {
        public override IEmployeeFactory GetEmployee(Employee item)
        {
            switch (item.contractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new EmployeePaymentPerHour(item.id, item.name, item.contractTypeName, item.roleId, item.roleName, item.roleDescription, item.hourlySalary, item.monthlySalary);
                case "MonthlySalaryEmployee":
                    return new EmployeePaymentPerMonth(item.id, item.name, item.contractTypeName, item.roleId, item.roleName, item.roleDescription, item.hourlySalary, item.monthlySalary);
                default:
                    throw new ApplicationException(string.Format("Employee '{0}' cannot be created", item.contractTypeName));
            }
        }

    }
}
