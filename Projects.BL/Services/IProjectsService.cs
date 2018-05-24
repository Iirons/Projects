using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.BL.DTO;

namespace Projects.BL.Services
{
    public interface IProjectsService
    {
        void ChangeProject(ProjectDTO project);
        void DeleteProject(int id);
        void CreateProject(ProjectDTO projectDto);

        IEnumerable<ProjectDTO> GetProjects();
    }
}
