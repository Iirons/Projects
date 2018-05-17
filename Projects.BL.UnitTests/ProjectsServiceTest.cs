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
            projectsService.DeleteProjects(new List<ProjectDTO> { new ProjectDTO(0, "test", 0), new ProjectDTO(1, "test", 0) });
            projectsService.CreateProject(new ProjectDTO(1, "test", 0));
            projectsService.ChangeProjectManager(1, new ProjectDTO(0, "test", 1));
            db.Object.Save();
        }

        [TestMethod]
        public void ChangeProjectManagerException1Test()
        {
            var db = new Mock<TestUnitOfWork>();
            ProjectsService projectsService = new ProjectsService(db.Object);
            projectsService.DeleteProjects(new List<ProjectDTO> { new ProjectDTO(0, "test", 0), new ProjectDTO(1, "test", 0) });
            try
            {
                projectsService.ChangeProjectManager(1, new ProjectDTO(0, "test", 1));
                db.Object.Save();
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                db.Object.Save();
            }
            
        }

        [TestMethod]
        public void ChangeProjectManagerException2Test()
        {
            var db = new Mock<TestUnitOfWork>();
            ProjectsService projectsService = new ProjectsService(db.Object);
            projectsService.DeleteProjects(new List<ProjectDTO> { new ProjectDTO(0, "test", 0), new ProjectDTO(1, "test", 0) });
            try
            {
                projectsService.CreateProject(new ProjectDTO(1, "sest", 0));
                projectsService.ChangeProjectManager(1, new ProjectDTO(0, "test", 1));
                db.Object.Save();
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                db.Object.Save();
            }

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
            db.Object.Save();
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
            db.Object.Save();
        }


        [TestMethod]
        public void GetManagersTest()
        {
            var db = new Mock<TestUnitOfWork>();
            ProjectsService projectsService = new ProjectsService(db.Object);
            projectsService.GetManagers();
            db.Object.Save();
        }
    }
}


