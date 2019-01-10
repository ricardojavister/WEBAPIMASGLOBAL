using MSGLOBAL.RepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSGLOBAL.RepositoryPattern
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(Int64 id);
        List<T> GetAll();
    }
}
