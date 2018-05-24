
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

        public void ChangeProject(ProjectDTO project)
        {
            if (db.projects.Get(project.Id) == null)
            {
                throw new Exception($"Project with id = {project.Id} not found");
            }
            db.projects.Update(new Project(project.Id, project.Name, project.ManagerId, project.Description,
                project.ProjectStart, project.ProjectEnd));
            
        }

        public void DeleteProject(int id)
        {
            if (db.projects.Get(id) == null)
            {
                throw new Exception($"Project with id = {id} not found");
            }
            db.projects.Delete(id);
        }

        public void CreateProject(ProjectDTO projectDto)
        {
            Project project = new Project(projectDto.Id, projectDto.Name, projectDto.ManagerId, projectDto.Description, 
                projectDto.ProjectStart, projectDto.ProjectEnd);
            db.projects.Create(project);
        }

        public IEnumerable<ProjectDTO> GetProjects()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(db.projects.GetAll());
        }
        
    }
}
