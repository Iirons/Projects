using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }

        public ProjectDTO(int id, string name,int managerid)
        {
            this.Id = id;
            this.Name = name;
            this.ManagerId = managerid;
        }
    }
}
