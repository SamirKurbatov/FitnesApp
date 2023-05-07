using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnesApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesApp.BL.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
    
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveUsersTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            // Act
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.FirstName);
        }
    }
}