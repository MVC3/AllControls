using HTMLControlsReference.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HTMLControlsReference.Models;
using System.Collections.Generic;

namespace HTMLControlsTest
{
    
    
    /// <summary>
    ///This is a test class for JobServiceTest and is intended
    ///to contain all JobServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JobServiceTest
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
        ///A test for JobService Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void JobServiceConstructorTest()
        {
            IEmpDBContext jobDBContext = null; // TODO: Initialize to an appropriate value
            JobService target = new JobService(jobDBContext);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for getAllJobs
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void getAllJobsTest()
        {
            JobService target = new JobService(dbContext); // TODO: Initialize to an appropriate value
            JobTitle expected1 = new JobTitle();
            expected1.JobID = 1;
            expected1.JobTitleName = "Dev";
            dbContext.JobTitles.Add(expected1);

            JobTitle expected2 = new JobTitle();
            expected2.JobTitleName = "Dev2";
            expected2.JobID = 2;
            dbContext.JobTitles.Add(expected2);

            List<JobTitle> expected = new List<JobTitle>(); // TODO: Initialize to an appropriate value
            expected.Add(expected1);
            expected.Add(expected2);

            List<JobTitle> actual;
            actual = target.getAllJobs();

            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].JobID, actual[0].JobID);
            Assert.AreEqual(expected[1].JobTitleName, actual[1].JobTitleName);

            dbContext.JobTitles.Remove(expected1);
            dbContext.JobTitles.Remove(expected2);
        }

        /// <summary>
        ///A test for getJob
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void getJobTest()
        {
            JobService target = new JobService(dbContext); // TODO: Initialize to an appropriate value
            JobTitle expected = new JobTitle();
            expected.JobID = 1;
            expected.JobTitleName = "Dev";
            dbContext.JobTitles.Add(expected);
            dbContext.SaveChanges();
            JobTitle actual;
            actual = target.getJob(expected.JobID);
            Assert.AreEqual(expected, actual);
            dbContext.JobTitles.Remove(expected);
        }
    }
}
