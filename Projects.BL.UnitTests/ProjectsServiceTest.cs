using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Projects.BL;
using Projects.BL.DTO;
using Projects.BL.Services;
using Projects.DAL;
using Projects.DAL.Domain;
using Projects.DAL.Repositories;
using AutoMapper;
using Moq;
using System.Linq;

namespace Projects.BL.UnitTests
{
    [TestClass]
    public class ProjectsServiceTest
    {

        private Mock<IRepository<Project>> mockRepository;
        private Mock<IUnitOfWork> mockUow;
        private IProjectsService projectsService;

        public ProjectsServiceTest()
        {
            mockRepository = new Mock<IRepository<Project>>();
            mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(m => m.projects).Returns(mockRepository.Object);
            projectsService = new ProjectsService(mockUow.Object);
        }

        [TestMethod]
        public void ChangeProjectTest()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(new Project(1, "test", 1, "sososo", 
                new DateTime(2008, 02, 4), new DateTime(2008, 02, 4)));
            projectsService.ChangeProject(new ProjectDTO(1, "test2", 3, "sososo", new DateTime(2008, 02, 4), new DateTime(2008, 02, 4)));
            mockRepository.Verify(m => m.Update(It.IsAny<Project>()), Times.Once);
        }

        [TestMethod]
        public void ChangeProjectExceptionTest()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            Assert.ThrowsException<Exception>(() => projectsService.ChangeProject(new ProjectDTO(1, "test2", 3, "sososo", 
                new DateTime(2008, 02, 4), new DateTime(2008, 02, 4))));
        }

        [TestMethod]
        public void DeleteProjectsExceptionTest()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            Assert.ThrowsException<Exception>(() => projectsService.DeleteProject(1));
        }

        [TestMethod]
        public void DeleteSelectedProjectsTest()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(new Project(1, "test", 3, "sososo",
                new DateTime(2008, 02, 4), new DateTime(2008, 02, 4)));
            int id = 1;
            projectsService.DeleteProject(id);
            mockRepository.Verify(m => m.Delete(id), Times.Once);
        }

        [TestMethod]
        public void CreateProjectTest()
        {
            mockRepository.Setup(m => m.Get(It.IsAny<Int32>())).Returns(() => null);
            projectsService.CreateProject(new ProjectDTO(1,"test",3,"sososo", new DateTime(2008, 02, 4), new DateTime(2008, 02, 4)));
            mockRepository.Verify(m => m.Create(It.IsAny<Project>()), Times.Once);
        }

        [TestMethod]
        public void GetProjectsTest()
        {
            mockRepository.Setup(m => m.GetAll()).Returns(new List<Project>()
            {
                new Project(1, "proj1", 1, "country1",new DateTime(2008,02,4),new DateTime(2008,02,4)),
                new Project(2, "proj2", 1, "country2",new DateTime(2008,02,4),new DateTime(2008,02,4)),
                new Project(3, "proj3", 2, "country3",new DateTime(2008,02,4),new DateTime(2008,02,4))
            });
            var projects = projectsService.GetProjects();
            Assert.AreEqual(3, projects.Count());
        }


    }
}


