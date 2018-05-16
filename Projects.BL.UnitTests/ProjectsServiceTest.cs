using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Projects.BL;
using Projects.BL.DTO;
using Projects.DAL;
using Projects.DAL.Domain;
using Projects.BL.UnitTests.Moq;
using AutoMapper;
using Moq;

namespace Projects.BL.UnitTests
{
    [TestClass]
    public class ProjectsServiceTest
    {

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void ChangeProjectManagerTest()
        {
            var db = new Mock<TestUnitOfWork>();
            ProjectsService projectsService = new ProjectsService(db.Object);
            projectsService.ChangeProjectManager(1, new ProjectDTO(1, null, 0));
        }

        [TestMethod]
        public void DeleteSelectedProjectsTest()
        {
            var db = new Mock<TestUnitOfWork>();
            IEnumerable<ProjectDTO> projects = new List<ProjectDTO>()
            {
                new ProjectDTO(1,null,0),
                new ProjectDTO(2,null,0)
            };
            ProjectsService projectsService = new ProjectsService(db.Object);
            projectsService.DeleteProjects(projects);
        }

        [TestMethod]
        public void CreateProjectsTest()
        {

            var db = new Mock<TestUnitOfWork>();
            ProjectsService projectsService = new ProjectsService(db.Object);
            projectsService.DeleteProjects(new List<ProjectDTO> { new ProjectDTO(0,"test",0), new ProjectDTO(1, "test", 0) });
            projectsService.CreateProject(new ProjectDTO(1, "test", 0));
            db.Object.Save();
        }

        [TestMethod]
        public void GetProjectsTest()
        {
            var db = new Mock<TestUnitOfWork>();
            ProjectsService projectsService = new ProjectsService(db.Object);
            projectsService.GetProjects();
        }


        [TestMethod]
        public void GetManagersTest()
        {
            var db = new Mock<TestUnitOfWork>();
            ProjectsService projectsService = new ProjectsService(db.Object);
            projectsService.GetManagers();
        }
    }
}


