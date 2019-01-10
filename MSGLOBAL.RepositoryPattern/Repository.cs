using MSGLOBAL.RepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSGLOBAL.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
