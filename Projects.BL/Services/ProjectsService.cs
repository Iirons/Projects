
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.BL.DTO;
using Projects.BL.Services;
using Projects.DAL.EF.Repository;
using Projects.DAL;
using Projects.DAL.EF;
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
            Project prj = db.projects.Get(project.Id);
            if (prj == null)
            {
                throw new Exception($"Project with id = {project.Id} not found");
            }
            prj.Name = project.Name;
            prj.Description = project.Description;
            prj.ManagerId = project.ManagerId;
            prj.ProjectStart = project.ProjectStart;
            prj.ProjectEnd = project.ProjectEnd;
            db.projects.Update(prj);
            db.Save();
            
        }

        public void DeleteProject(int id)
        {
            if (db.projects.Get(id) == null)
            {
                throw new Exception($"Project with id = {id} not found");
            }
            db.projects.Delete(id);
            db.Save();
        }

        public void CreateProject(ProjectDTO projectDto)
        {
            Project project = new Project(projectDto.Id, projectDto.Name, projectDto.ManagerId, projectDto.Description, 
                projectDto.ProjectStart, projectDto.ProjectEnd);
            db.projects.Create(project);
            db.Save();
        }

        public IEnumerable<ProjectDTO> GetProjects()
        {
            return db.projects.GetAll().Select(x => new ProjectDTO(x.Id,x.Name,x.ManagerId,x.Description,x.ProjectStart,x.ProjectEnd));
        }
        
    }
}
