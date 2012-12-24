using HTMLControlsReference.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HTMLControlsReference.Models;
using System.Collections.Generic;

namespace HTMLControlsTest
{
    
    
    /// <summary>
    ///This is a test class for ShiftsServiceTest and is intended
    ///to contain all ShiftsServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShiftsServiceTest
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
         
        //You can use the following additional attributes as you write your tests:
        
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            dbContext = new EmpDBContext(@"Data Source=.\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=TestDB; AttachDbFilename=C:\Users\Usha\documents\visual studio 2010\Projects\HTMLControlsTest\HTMLControlsTest\App_Data\TestDB.mdf;");
            dbContext.Database.CreateIfNotExists();
        }
        
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            if (dbContext.Database.Exists())
                dbContext.Database.Delete();
        }
        
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
        ///A test for getShift
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\Usha\\Documents\\Visual Studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        //[UrlToTest("http://localhost:52285/")]
        public void getShiftTest()
        {
            //Assign
            ShiftsService target = new ShiftsService(dbContext); // TODO: Initialize to an appropriate value
            Shift expected = new Shift();
            expected.ShiftID = 1;
            expected.ShiftType = "Morning";
            dbContext.Shifts.Add(expected);
            dbContext.SaveChanges();

            //Act
            Shift actual;
            actual = target.getShift(expected.ShiftID);

            //Assert
            Assert.AreEqual(expected, actual);

            //Clear
            dbContext.Shifts.Remove(expected);
        }

        /// <summary>
        ///A test for getAllShifts
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\Usha\\Documents\\Visual Studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        //[UrlToTest("http://localhost:52285/")]
        public void getAllShiftsTest()
        {
            ShiftsService target = new ShiftsService(dbContext); // TODO: Initialize to an appropriate value
            //Assign
            Shift expected1 = new Shift();
            expected1.ShiftID = 1;
            expected1.ShiftType = "Morning";
            dbContext.Shifts.Add(expected1);

            Shift expected2 = new Shift();
            expected2.ShiftID = 2;
            expected2.ShiftType = "Afternoon";
            dbContext.Shifts.Add(expected2);

            dbContext.SaveChanges();
            
            List<Shift> expected = new List<Shift>();
            expected.Add(expected1);
            expected.Add(expected2);

            //Act
            List<Shift> actual;
            actual = target.getAllShifts();

            //Assert
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].ShiftID, actual[0].ShiftID);
            Assert.AreEqual(expected[1].ShiftID, actual[1].ShiftID);

            //Clear
            dbContext.Shifts.Remove(expected1);
            dbContext.Shifts.Remove(expected2);
        }

        
    }
}
