using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.DAL.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public DateTime ProjectStart { get; set; }
        public DateTime ProjectEnd { get; set; }

        public int ManagerId { get; set; }

        public Project() { }

        public Project(int id, string name, int managerid, string description, DateTime projectstart, DateTime projectend)
        {
            this.Id = id;
            this.Name = name;
            this.ManagerId = managerid;
            this.Description = description;
            this.ProjectStart = projectstart;
            this.ProjectEnd = projectend;
        }
    }
}
