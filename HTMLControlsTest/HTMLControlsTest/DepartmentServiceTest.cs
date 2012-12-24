using HTMLControlsReference.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HTMLControlsReference.Models;
using System.Collections.Generic;

namespace HTMLControlsTest
{
    
    
    /// <summary>
    ///This is a test class for DepartmentServiceTest and is intended
    ///to contain all DepartmentServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DepartmentServiceTest
    {

        static EmpDBContext dbContext;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            dbContext = new EmpDBContext(@"Data Source=.\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=TestDB; AttachDbFilename=C:\Users\Usha\documents\visual studio 2010\Projects\HTMLControlsTest\HTMLControlsTest\App_Data\TestDB.mdf;");
            dbContext.Database.CreateIfNotExists();
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            if (dbContext.Database.Exists())
                dbContext.Database.Delete();
        }
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for DepartmentService Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void DepartmentServiceConstructorTest()
        {
            IEmpDBContext departmentDBContext = null; // TODO: Initialize to an appropriate value
            DepartmentService target = new DepartmentService(departmentDBContext);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for getAllDepartments
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        //[UrlToTest("http://localhost:52285/")]
        public void getAllDepartmentsTest()
        {
            DepartmentService target = new DepartmentService(dbContext); // TODO: Initialize to an appropriate value
            Department expected1 = new Department();
            expected1.DepartmentID = 1;
            expected1.Name = "Alabama";
            dbContext.Departments.Add(expected1);

            Department expected2 = new Department();
            expected2.DepartmentID = 2;
            expected2.Name = "Alaska";
            dbContext.Departments.Add(expected2);

            List<Department> expected = new List<Department>(); // TODO: Initialize to an appropriate value
            expected.Add(expected1);
            expected.Add(expected2);

            List<Department> actual;
            actual = target.getAllDepartments();

            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].DepartmentID, actual[0].DepartmentID);
            Assert.AreEqual(expected[1].Name, actual[1].Name);

            dbContext.Departments.Remove(expected1);
            dbContext.Departments.Remove(expected2);
        }

        /// <summary>
        ///A test for getDepartment
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void getDepartmentTest()
        {
            DepartmentService target = new DepartmentService(dbContext); // TODO: Initialize to an appropriate value
            Department expected = new Department();
            expected.DepartmentID = 1;
            expected.Name = "Alabama";
            dbContext.Departments.Add(expected);
            dbContext.SaveChanges();
            Department actual;
            actual = target.getDepartment(expected.DepartmentID);
            Assert.AreEqual(expected, actual);
            dbContext.Departments.Remove(expected);
        }
    }
}
