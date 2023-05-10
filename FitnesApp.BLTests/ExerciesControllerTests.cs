using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnesApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnesApp.BL.Models;

namespace FitnesApp.BLTests
{
    [TestClass()]
    public class ExerciesControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var excercieController = new ExerciesController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 1000));
            // Act
            excercieController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            Assert.AreEqual(activity.Title, excercieController.Activites.First().Title);
        }
    }
}