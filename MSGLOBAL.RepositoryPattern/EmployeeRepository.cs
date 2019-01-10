using System;
using System.Collections.Generic;
using System.Text;
using MSGLOBAL.RepositoryPattern.Model;

namespace MSGLOBAL.RepositoryPattern
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
