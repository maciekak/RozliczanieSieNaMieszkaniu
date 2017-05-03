using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RozliczanieSieNaMieszkaniu.BusinessLogic;
using RozliczanieSieNaMieszkaniu.Models;

namespace RozliczanieSieNaMieszkaniu.Tests.BussinesLogic
{
    /// <summary>
    /// Summary description for Test
    /// </summary>
    [TestClass]
    public class ReckoningCostsServiceTest
    {
        public ReckoningCostsServiceTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CheckingPropertyOfReckoning1()
        {
            // Arrange
            var session = new SessionModel()
            {
                Entries = new List<EntryModel>()
                {
                    new EntryModel()
                    {
                        ApplicationUserId = "A",
                        Price = 0.80M,
                    },
                    new EntryModel()
                    {
                        ApplicationUserId = "B",
                        Price = 2.00M,
                    },
                    new EntryModel()
                    {
                        ApplicationUserId = "C",
                        Price = 3.20M,
                    }
                }
            };
            var correctResult = new List<FiguredCostsUpViewModel>()
            {
                new FiguredCostsUpViewModel()
                {
                    Who = "A",
                    Whom = "C",
                    HowMuch = 1.20M
                }
            };
            var service = new ReckoningCostsService();


            // Act
            var result = service.GetFiguredCostsUpList(session);


            // Assert
            CollectionAssert.AreEquivalent(result, correctResult);
        }

        [TestMethod]
        public void CheckingPropertyOfReckoning2()
        {
            // Arrange
            var session = new SessionModel()
            {
                Entries = new List<EntryModel>()
                {
                    new EntryModel()
                    {
                        ApplicationUserId = "A",
                        Price = 0.80M,
                    },
                    new EntryModel()
                    {
                        ApplicationUserId = "B",
                        Price = 2.00M,
                    },
                    new EntryModel()
                    {
                        ApplicationUserId = "C",
                        Price = 4.50M,
                    },
                    new EntryModel()
                    {
                        ApplicationUserId = "D",
                        Price = 5.0M,
                    },
                    new EntryModel()
                    {
                        ApplicationUserId = "E",
                        Price = 1.20M,
                    },
                }
            };
            var correctResult = new List<FiguredCostsUpViewModel>()
            {
                new FiguredCostsUpViewModel()
                {
                    Who = "A",
                    Whom = "D",
                    HowMuch = 1.90M
                },
                new FiguredCostsUpViewModel()
                {
                    Who = "E",
                    Whom = "D",
                    HowMuch = 0.40M
                },
                new FiguredCostsUpViewModel()
                {
                    Who = "E",
                    Whom = "C",
                    HowMuch = 1.10M
                },
                new FiguredCostsUpViewModel()
                {
                    Who = "B",
                    Whom = "C",
                    HowMuch = 0.70M
                },
            };
            var service = new ReckoningCostsService();


            // Act
            var result = service.GetFiguredCostsUpList(session);


            // Assert
            CollectionAssert.AreEquivalent(result, correctResult);
        }

        [TestMethod]
        public void CheckingPropertyOfReckoning3()
        {
            // Arrange
            var session = new SessionModel()
            {
                Entries = new List<EntryModel>()
                {
                    new EntryModel()
                    {
                        ApplicationUserId = "A",
                        Price = 1.00M,
                    },
                    new EntryModel()
                    {
                        ApplicationUserId = "B",
                        Price = 2.00M,
                    },
                    new EntryModel()
                    {
                        ApplicationUserId = "C",
                        Price = 3.20M,
                    }
                }
            };
            var correctResult = new List<FiguredCostsUpViewModel>()
            {
                new FiguredCostsUpViewModel()
                {
                    Who = "A",
                    Whom = "C",
                    HowMuch = 1.07M
                },
                new FiguredCostsUpViewModel()
                {
                    Who = "B",
                    Whom = "C",
                    HowMuch = 0.07M
                },
            };
            var service = new ReckoningCostsService();


            // Act
            var result = service.GetFiguredCostsUpList(session);


            // Assert
            CollectionAssert.AreEquivalent(result, correctResult);
        }

    }
}
