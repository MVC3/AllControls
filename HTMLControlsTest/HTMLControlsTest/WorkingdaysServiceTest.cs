using HTMLControlsReference.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HTMLControlsReference.Models;
using System.Collections.Generic;

namespace HTMLControlsTest
{
    
    
    /// <summary>
    ///This is a test class for WorkingdaysServiceTest and is intended
    ///to contain all WorkingdaysServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WorkingdaysServiceTest
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
        ///A test for WorkingdaysService Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void WorkingdaysServiceConstructorTest()
        {
            IEmpDBContext workingdayDBContext = null; // TODO: Initialize to an appropriate value
            WorkingdaysService target = new WorkingdaysService(workingdayDBContext);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for getAllWorkingDays
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void getAllWorkingDaysTest()
        {
            WorkingdaysService target = new WorkingdaysService(dbContext); // TODO: Initialize to an appropriate value
            WorkingDay expected1 = new WorkingDay();
            WorkingDay expected2 = new WorkingDay();

            expected1.WorkingDayID = 1;
            expected2.WorkingDayID = 2;

            expected1.WorkingDays = "Mon";
            expected2.WorkingDays = "Tue";

            dbContext.WorkingDays.Add(expected1);
            dbContext.WorkingDays.Add(expected2);
                        
            List<WorkingDay> expected = new List<WorkingDay>(); // TODO: Initialize to an appropriate value
            expected.Add(expected1);
            expected.Add(expected2);

            List<WorkingDay> actual;
            actual = target.getAllWorkingDays();
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].WorkingDayID, actual[0].WorkingDayID);
            Assert.AreEqual(expected[1].WorkingDays, actual[1].WorkingDays);

            dbContext.WorkingDays.Remove(expected1);
            dbContext.WorkingDays.Remove(expected2);
        }

        /// <summary>
        ///A test for getSelectedWorkingday
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void getSelectedWorkingdayTest()
        {
            WorkingdaysService target = new WorkingdaysService(dbContext); // TODO: Initialize to an appropriate value
            WorkingDay expected = new WorkingDay();
            expected.WorkingDayID = 1;
            expected.WorkingDays = "Wed";
            dbContext.WorkingDays.Add(expected);
            dbContext.SaveChanges();
            WorkingDay actual;
            actual = target.getSelectedWorkingday(expected.WorkingDayID);
            Assert.AreEqual(expected, actual);
            dbContext.WorkingDays.Remove(expected);
        }
    }
}
