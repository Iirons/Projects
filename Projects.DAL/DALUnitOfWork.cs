using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.DAL.Repositories;
using Projects.DAL;
using Projects.DAL.Domain;


namespace Projects.DAL
{
    public class DALUnitOfWork : IUnitOfWork
    {
        ProjectRepository ProjectRepository;

        public IRepository<Project> projects
        {
            get
            {
                if (ProjectRepository == null)
                {
                    ProjectRepository = new ProjectRepository();
                }
                return ProjectRepository;
            }
        }
    }
}
