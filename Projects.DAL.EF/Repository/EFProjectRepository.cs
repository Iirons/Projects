using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL.EF.Repository
{
    public class EFProjectRepository : IRepository<Project>
    {
        private ProjectsContext db;

        public EFProjectRepository(ProjectsContext context)
        {
            this.db = context;
        }

        public void Create(Project item)
        {
            db.projects.Add(item);
        }

        public void Delete(int id)
        {
            Project prj = db.projects.Find(id);
            if (prj != null)
                db.projects.Remove(prj);
        }

        public Project Get(int id)
        {
            return db.projects.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return db.projects;
        }

        public void Update(Project item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
