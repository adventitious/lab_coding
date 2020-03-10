using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDemoApp;
using NUnit.Framework;

namespace MyDemoApp.Test
{
    [TestFixture]
    public class Class1
    {

        [Test]
        public static void Test1()
        {
            // arrange
            Program p1 = new Program();

            // act
            int actualResult = p1.Add(5, 10);

            // assert
            Assert.That(actualResult, Is.EqualTo(15));  // 15 is expected answer
        }
        [Test]
        public static void Test2()
        {
            // arrange
            Program p1 = new Program();

            // act
            int actualResult = p1.Add(10, 0);

            // assert
            Assert.That(actualResult, Is.EqualTo(10));  // 15 is expected answer
        }

    }
}
