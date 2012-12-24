using HTMLControlsReference.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HTMLControlsReference.Models;
using System.Collections.Generic;

namespace HTMLControlsTest
{
    
    
    /// <summary>
    ///This is a test class for EmployeeServiceTest and is intended
    ///to contain all EmployeeServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmployeeServiceTest
    {


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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
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
        ///A test for EmployeeService Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void EmployeeServiceConstructorTest()
        {
            IEmpDBContext empDBContext = null; // TODO: Initialize to an appropriate value
            EmployeeService target = new EmployeeService(empDBContext);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void CreateTest()
        {
            IEmpDBContext empDBContext = null; // TODO: Initialize to an appropriate value
            EmployeeService target = new EmployeeService(empDBContext); // TODO: Initialize to an appropriate value
            Employee employee = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Create(employee);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void DeleteTest()
        {
            IEmpDBContext empDBContext = null; // TODO: Initialize to an appropriate value
            EmployeeService target = new EmployeeService(empDBContext); // TODO: Initialize to an appropriate value
            Employee employee = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Delete(employee);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEmployee
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void GetEmployeeTest()
        {
            IEmpDBContext empDBContext = null; // TODO: Initialize to an appropriate value
            EmployeeService target = new EmployeeService(empDBContext); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Employee expected = null; // TODO: Initialize to an appropriate value
            Employee actual;
            actual = target.GetEmployee(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEmployees
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void GetEmployeesTest()
        {
            IEmpDBContext empDBContext = null; // TODO: Initialize to an appropriate value
            EmployeeService target = new EmployeeService(empDBContext); // TODO: Initialize to an appropriate value
            List<Employee> expected = null; // TODO: Initialize to an appropriate value
            List<Employee> actual;
            actual = target.GetEmployees();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void UpdateTest()
        {
            IEmpDBContext empDBContext = null; // TODO: Initialize to an appropriate value
            EmployeeService target = new EmployeeService(empDBContext); // TODO: Initialize to an appropriate value
            Employee employee = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Update(employee);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
