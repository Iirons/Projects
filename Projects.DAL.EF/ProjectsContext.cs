using System.Data.Entity;

namespace Projects.DAL.EF
{
    public class ProjectsContext : DbContext
    {
        public DbSet<Project> projects { get; set; }

        static ProjectsContext()
        {
            Database.SetInitializer<ProjectsContext>(new StoreDbInitializer());
        }
        public ProjectsContext(string connectionString) : base(connectionString) { }

    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ProjectsContext>
    {
        protected override void Seed(ProjectsContext db)
        {
            db.projects.Add(new Project(1, "HopHey", 1, "Some", new System.DateTime(1997, 9, 1), new System.DateTime(1998, 10, 1)));
            db.projects.Add(new Project(2, "LaLaLey", 2, "Body", new System.DateTime(1998, 10, 1), new System.DateTime(1999, 11, 1)));
            db.projects.Add(new Project(3, "HopHey", 1, "KillMe", new System.DateTime(1999, 11, 1), new System.DateTime(2000, 12, 1)));
            db.SaveChanges();
        }
    }
}
