//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projects.DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public DateTime ProjectStart { get; set; }
        public DateTime ProjectEnd { get; set; }
        public string Description { get; set; }

        public Project()
        {

        }

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
