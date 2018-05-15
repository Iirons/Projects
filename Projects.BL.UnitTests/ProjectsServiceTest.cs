using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Projects.BL;
using Projects.BL.DTO;

namespace Projects.BL.UnitTests
{
    [TestClass]
    public class ProjectsServiceTest
    {
        [TestMethod]
        public void ChangeProjectManagerTest()
        {
            ProjectsService projectsService = new ProjectsService();
            projectsService.ChangeProjectManager(new ManagerDTO(1, null),new ProjectDTO(1, null, 0));
        }

        [TestMethod]
        public void DeleteSelectedProjectsTest()
        {
            IEnumerable<ProjectDTO> projects = new List<ProjectDTO>()
            {
                new ProjectDTO(1,null,0),
                new ProjectDTO(2,null,0),
                new ProjectDTO(3,null,0),
            };
            ProjectsService projectsService = new ProjectsService();
            projectsService.DeleteProjects(projects);
        }

        [TestMethod]
        public void CreateProjectsTest()
        {
            ProjectsService projectsService = new ProjectsService();
            projectsService.CreateProject(new ProjectDTO(1, null, 0));
        }
    }
}
