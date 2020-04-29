using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using s20_project;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTruncateTwoPlaces1()
        {
            /*
            TruncateTwoPlaces divides the first argument 
            by the second argument.
            The answer goes to two decimal places but there is no rounding
            */

            // Arrange
            SimpleCount1 sc = new SimpleCount1(new Contest( 2 ));
            double expectedAnswer = 3.33;

            // Act
            double answer = sc.truncateTwoPlaces(10, 3);

            // Assert
            Assert.AreEqual(expectedAnswer, answer);
        }



        [TestMethod]
        public void TestTruncateTwoPlaces2()
        {
            // Arrange
            SimpleCount1 sc = new SimpleCount1(new Contest( 2 ));
            double expectedAnswer = 1.66;

            // Act
            double answer = sc.truncateTwoPlaces(10, 6);

            // Assert
            Assert.AreEqual(expectedAnswer, answer);
        }


        [TestMethod]
        public void TestTruncateTwoPlaces3()
        {
            /*
            TruncateTwoPlaces can take either an int or a double as the first argument
            */

            // Arrange
            SimpleCount1 sc = new SimpleCount1(new Contest( 2 ));
            double expectedAnswer = 0.03;

            // Act
            double answer = sc.truncateTwoPlaces(0.1, 3);

            // Assert
            Assert.AreEqual(expectedAnswer, answer);
        }
    }
}
