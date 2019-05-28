using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apitrial.Controllers;
using System.Web.Http.Results;
using apitrial.Models;
using WebAoi.Models;

namespace StoreApp.Tests
{
    [TestClass]
    public class TestCases
    {
        [TestMethod]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            List<Student> testStudents = GetTestStudents();
            var controller = new StudentsController(testStudents);
            var result = controller.GetAllStudents() as List<Student>;
            Assert.AreEqual(testStudents.Count, result.Count());

        }
        [TestMethod]
        public void GetStudents_ShouldReturnCorrectStudents()
        {
            var testStudents = GetTestStudents();
            var controller = new StudentsController(testStudents);

            var result = controller.GetStudents(2) as OkNegotiatedContentResult<Student>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testStudents[2].StudentName, result.Content.StudentName);
        }
        [TestMethod]
        public void GetStudents_ShouldNotFindStudents()
        {
            var controller = new StudentsController(GetTestStudents());

            var result = controller.GetStudents(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        private List<Student> GetTestStudents()
        {
            List<Student> testStudents = new List<Student>();
            testStudents.Add(new Student { StuentId = 100, StudentName = "Amoolya", Stream = "Electrical", StudentPercentage = 90 });
            testStudents.Add(new Student { StuentId = 101, StudentName = "Chirag", Stream = "Electronics", StudentPercentage = 95 });
       

            return testStudents;
        }


    }
}
