using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualityCode;
using NUnit.Framework;

namespace QualityCode.Test
{
    [TestFixture]
    public class Class1
    {
        /*

        1	20	"urban"	3	 3
        2	40	"urban"	4	 5
        3	16	"urban"	4	 6
        4	20	"rural"	4	 9
        5	40	"rural"	5	11
        6	16	"rural"	5	12
        7	60	"other"	3	14

        */


        [Test]
        public static void Test1()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(20, "urban");

            // assert
            Assert.That(result, Is.EqualTo(50.0));
        }

        [Test]
        public static void Test2()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(40, "urban");

            // assert
            Assert.That(result, Is.EqualTo(35.0));
        }

        [Test]
        public static void Test3()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(16, "urban");

            // assert
            Assert.That(result, Is.EqualTo(60.0)); 
        }

        [Test]
        public static void Test4()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(20, "rural");

            // assert
            Assert.That(result, Is.EqualTo(50.0));
        }

        [Test]
        public static void Test5()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(40, "rural");

            // assert
            Assert.That(result, Is.EqualTo(50.0));
        }

        [Test]
        public static void Test6()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(16, "rural");

            // assert
            Assert.That(result, Is.EqualTo(50.0));
        }

        [Test]
        public static void Test7()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(60, "other");

            // assert
            Assert.That(result, Is.EqualTo(50.0));
        }
    }
}
