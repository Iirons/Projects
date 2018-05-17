
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.BL.DTO;
using Projects.BL.Services;
using Projects.DAL.Repositories;
using Projects.DAL;
using Projects.DAL.Domain;
using AutoMapper;

namespace Projects.BL
{
    public class ProjectsService: IProjectsService
    {
        IUnitOfWork db { get; set; }

        public ProjectsService(IUnitOfWork uow)
        {
            this.db = uow;
        }

        public void ChangeProjectManager(int managerid, ProjectDTO project)
        {
            if(db.projects.Get(project.Id).Name == project.Name)
            {
                db.projects.Update(new Project { Id = project.Id, Name = project.Name, ManagerId = managerid });
            }
            else
            {
                throw new InvalidOperationException("Could not find this project");
            }
        }

        public void DeleteProjects(IEnumerable<ProjectDTO> projects)
        {
            foreach (ProjectDTO projectDto in projects)
            {
                db.projects.Delete(projectDto.Id);
            }

        }

        public void CreateProject(ProjectDTO projectDto)
        {
            Project project = new Project
            {
                Name = projectDto.Name,
                ManagerId = projectDto.ManagerId
            };
            db.projects.Create(project);
        }

        public IEnumerable<ProjectDTO> GetProjects()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(db.projects.GetAll());
        }

        public IEnumerable<ManagerDTO> GetManagers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Manager, ManagerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Manager>, List<ManagerDTO>>(db.managers.GetAll());
        }
    }
}
