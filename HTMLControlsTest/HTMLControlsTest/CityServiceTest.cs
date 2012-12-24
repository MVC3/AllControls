using HTMLControlsReference.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HTMLControlsReference.Models;
using System.Collections.Generic;

namespace HTMLControlsTest
{
    
    
    /// <summary>
    ///This is a test class for CityServiceTest and is intended
    ///to contain all CityServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CityServiceTest
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
        ///A test for CityService Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void CityServiceConstructorTest()
        {
            IEmpDBContext CityDBContext = null; // TODO: Initialize to an appropriate value
            CityService target = new CityService(CityDBContext);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetAllCities
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void GetAllCitiesTest()
        {
            CityService target = new CityService(dbContext); // TODO: Initialize to an appropriate value
            City expected1 = new City();
            City expected2 = new City();

            expected1.CityID = 1;
            expected2.CityID = 2;

            expected1.CityName = "DeKalb";
            expected2.CityName = "Washington";

            dbContext.Cities.Add(expected1);
            dbContext.Cities.Add(expected2);

                     
            List<City> expected = new List<City>(); // TODO: Initialize to an appropriate value
            expected.Add(expected1);
            expected.Add(expected2);
            List<City> actual;
            //city needs stateid
            actual = target.GetAllCities(expected.Count);
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].CityID, actual[0].CityID);
            Assert.AreEqual(expected[1].CityName, expected[1].CityName);

            dbContext.Cities.Remove(expected1);
            dbContext.Cities.Remove(expected2);
        }

        /// <summary>
        ///A test for GetCity
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Usha\\documents\\visual studio 2010\\Projects\\HTMLControlsReference\\HTMLControlsReference", "/")]
        [UrlToTest("http://localhost:52285/")]
        public void GetCityTest()
        {
            CityService target = new CityService(dbContext);
            City expected = new City();
            expected.CityID = 1;
            expected.CityName = "city";
            dbContext.Cities.Add(expected);
            dbContext.SaveChanges();

            City actual;
            actual = target.GetCity(expected.CityID);
            Assert.AreEqual(expected, actual);
            dbContext.Cities.Remove(expected);
        }
    }
}
