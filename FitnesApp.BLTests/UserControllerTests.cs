using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnesApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnesApp.BL.Controller;

namespace FitnesApp.BL.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var birthday = DateTime.Now.AddYears(-20);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);
            // Act
            controller.SetNewUserData(userName, gender, birthday, weight, height);
            var controller2 = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.FirstName);
            Assert.AreEqual(birthday, controller2.CurrentUser.BirthDay);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
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