using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.DAL.EF;
using Projects.DAL.EF.Repository;

namespace Projects.DAL.EF
{
    public interface IUnitOfWork
    {
        IRepository<Project> projects { get; }
        void Save();
    }
}
