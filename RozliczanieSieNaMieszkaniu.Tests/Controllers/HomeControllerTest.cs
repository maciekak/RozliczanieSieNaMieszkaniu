using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RozliczanieSieNaMieszkaniu;
using RozliczanieSieNaMieszkaniu.Controllers;
using RozliczanieSieNaMieszkaniu.Models;

namespace RozliczanieSieNaMieszkaniu.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //        [TestMethod]
        //        public void Index()
        //        {
        //            // Arrange
        //            HomeController controller = new HomeController();
        //
        //            // Act
        //            ViewResult result = controller.Index() as ViewResult;
        //
        //            // Assert
        //            Assert.IsNotNull(result);
        //        }
        [TestMethod]
        public void TestAdd()
        {
            HomeController controller = new HomeController();

            //ViewResult result = controller.Add(new EntryViewModel()) as ViewResult;

            //Assert.IsNotNull(result);
        }
    }

}
