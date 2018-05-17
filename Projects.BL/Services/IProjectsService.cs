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
        void ChangeProjectManager(int managerid, ProjectDTO project);
        void DeleteProjects(IEnumerable<ProjectDTO> projects);
        void CreateProject(ProjectDTO projectDto);

        IEnumerable<ProjectDTO> GetProjects();
        IEnumerable<ManagerDTO> GetManagers();
    }
}
