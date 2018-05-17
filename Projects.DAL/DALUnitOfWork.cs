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
        ManagerRepository ManagerRepository;

        public IRepository<Manager> managers
        {
            get
            {
                if (ManagerRepository == null)
                {
                    ManagerRepository = new ManagerRepository();
                }
                return ManagerRepository;
            }

        }

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

        public void Save()
        {
            projects.Close();
            managers.Close();
        }
    }
}
