using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.DAL.Repositories;
using Projects.DAL.Domain;

namespace Projects.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Project> projects { get; }
    }
}
