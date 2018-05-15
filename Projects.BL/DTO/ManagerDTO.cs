using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BL.DTO
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ManagerDTO(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
