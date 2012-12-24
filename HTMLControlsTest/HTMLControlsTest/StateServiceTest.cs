using HTMLControlsReference.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HTMLControlsReference.Models;
using System.Collections.Generic;

namespace HTMLControlsTest
{
    
    
    /// <summary>
    ///This is a test class for StateServiceTest and is intended
    ///to contain all StateServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StateServiceTest
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
        ///A test for StateService Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void StateServiceConstructorTest()
        {
            IEmpDBContext StateDBContext = null; // TODO: Initialize to an appropriate value
            StateService target = new StateService(StateDBContext);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetAllStates
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        //[UrlToTest("http://localhost:52285/")]
        public void GetAllStatesTest()
        {
            StateService target = new StateService(dbContext); // TODO: Initialize to an appropriate value
            State expected1 = new State();
            expected1.StateID = 1;
            expected1.StateName = "Alabama";
            dbContext.States.Add(expected1);

            State expected2 = new State();
            expected2.StateID = 2;
            expected2.StateName = "Alaska";
            dbContext.States.Add(expected2);

            List<State> expected = new List<State>() ; // TODO: Initialize to an appropriate value
            expected.Add(expected1);
            expected.Add(expected2);

            List<State> actual;
            actual = target.GetAllStates();

            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].StateID, actual[0].StateID);
            Assert.AreEqual(expected[1].StateID, actual[1].StateID);

            dbContext.States.Remove(expected1);
            dbContext.States.Remove(expected2);
         }

        /// <summary>
        ///A test for GetState
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        //[UrlToTest("http://localhost:52285/")]
        public void GetStateTest()
        {
            StateService target = new StateService(dbContext); // TODO: Initialize to an appropriate value
            State expected = new State();
            expected.StateID = 1;
            expected.StateName = "Alabama";
            dbContext.States.Add(expected);
            dbContext.SaveChanges();
            State actual;
            actual = target.GetState(expected.StateID);
            Assert.AreEqual(expected, actual);
            dbContext.States.Remove(expected);
        }
    }
}
