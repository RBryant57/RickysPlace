using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;
using ShootingManager.Service.Interfaces;
using ShootingManager.Web.Controllers;
using ShootingManager.Web.Tests.Repositories;

namespace ShootingManager.Web.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void ViewBrasses()
        {
            //var moq = new Mock<IBrassService>();
            //moq.Setup(m => m.GetAll()).Returns(FBrassRepository.AllBrasses);

            //var brassController = new BrassController((IBrassService)moq.Object);

            //brassController.Index();

        }

        [TestMethod]
        public void CreateBrass()
        {
            //var moq = new Mock<IBrassService>();
            //moq.Setup(m => m.GetAll()).Returns(FBrassRepository.AllBrasses);

            //var brassController = new BrassController((IBrassService)moq.Object);

            //brassController.Create();

        }
    }
}
