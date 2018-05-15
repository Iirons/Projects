using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.PL.Models
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ManagerModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
