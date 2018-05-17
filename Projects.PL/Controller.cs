using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projects.BL;
using Projects.BL.DTO;
using Projects.PL.Models;
using Projects.BL.Services;

namespace Projects.PL
{
    class Controller
    {
        IProjectsService bl;
        public Controller(IProjectsService ps)
        {   
            this.bl = ps;
        }

        IEnumerable<ManagerModel> GetManagers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ManagerDTO, ManagerModel>()).CreateMapper();
            return mapper.Map<IEnumerable<ManagerDTO>, List<ManagerModel>>(bl.GetManagers());
        }

        IEnumerable<ProjectModel> GetProjects()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, ProjectModel>()).CreateMapper();
            return mapper.Map<IEnumerable<ProjectDTO>, List<ProjectModel>>(bl.GetProjects());
        }
    }
}
