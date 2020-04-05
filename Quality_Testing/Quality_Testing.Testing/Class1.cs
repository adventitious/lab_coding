using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quality_Testing.Testing
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public static void Test1()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(18, "rural");

            // assert
            Assert.That(result, Is.EqualTo(60));
        }

        [Test]
        public static void Test2()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(17, "rural");
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public static void Test3()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(35, "rural");
            Assert.That(result, Is.EqualTo(60));
        }
        [Test]
        public static void Test4()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(36, "rural");
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public static void Test5()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(50, "rural");
            Assert.That(result, Is.EqualTo(7.5));
        }

        [Test]
        public static void Test6()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(49, "rural");
            Assert.That(result, Is.EqualTo(50));
        }


        [Test]
        public static void Test7()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(18, "urban");
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public static void Test8()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(17, "urban");
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public static void Test9()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(30, "urban");
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public static void Test10()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(31, "urban");
            Assert.That(result, Is.EqualTo(2.5));
        }

        [Test]
        public static void Test11()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(50, "urban");
            Assert.That(result, Is.EqualTo(0.375));
        }

        [Test]
        public static void Test12()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(49, "urban");
            Assert.That(result, Is.EqualTo(2.5));
        }


        [Test]
        public static void Test13()
        {
            InsuranceService myService = new InsuranceService();
            double result = myService.CalcPremium(5, "other");
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
