using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.DAL.Repositories;
using Projects.DAL;
using Projects.DAL.Domain;

namespace Projects.BL.UnitTests.Moq
{
    public class TestUnitOfWork : IUnitOfWork
    {
        string connect;
        ProjectRepositoryTest ProjectRepository;
        ManagerRepositoryTest ManagerRepository;

        public TestUnitOfWork()
        {
        }

        public TestUnitOfWork(string connectionstring)
        {
            connect = connectionstring;
        }

        public IRepository<Manager> managers
        {
            get
            {
                if (ManagerRepository == null)
                {
                    ManagerRepository = new ManagerRepositoryTest();
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
                    ProjectRepository = new ProjectRepositoryTest();
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
