using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.DAL.EF.Repository;

namespace Projects.DAL.EF
{
    public class EFUnitOfWork: IUnitOfWork
    {
        ProjectsContext db;
        EFProjectRepository ProjectRepository;

        public EFUnitOfWork(string connectionstring)
        {
            db = new ProjectsContext(connectionstring);
        }

        public IRepository<Project> projects
        {
            get
            {
                if (ProjectRepository == null)
                {
                    ProjectRepository = new EFProjectRepository(db);
                }
                return ProjectRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
