using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.PL.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }

        public ProjectModel(int id, string name, int managerid)
        {
            this.Id = id;
            this.Name = name;
            this.ManagerId = managerid;
        }
    }
}
