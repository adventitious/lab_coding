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
        // For an urban client of age >= 18 and <= 30 the premium is €50. 
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

        // An urban client aged >=31 pays €35.  
        [Test]
        public static void Test2()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(32, "urban");

            // assert
            Assert.That(result, Is.EqualTo(35.0));
        }

        // A rural client of age >= 18 and <= 35 pays €60. 
        [Test]
        public static void Test3()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(20, "rural");

            // assert
            Assert.That(result, Is.EqualTo(60.0)); 
        }


        // A rural client aged >=36 pays €50.  
        [Test]
        public static void Test4()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result = myService.CalcPremium(37, "rural");

            // assert
            Assert.That(result, Is.EqualTo(50.0)); 
        }

        // People aged 50 or more pay half premium. 
        [Test]
        public static void Test5()
        {
            // arange
            InsuranceService myService = new InsuranceService();

            // act
            double result1 = myService.CalcPremium(49, "rural");
            double result2 = myService.CalcPremium(51, "rural");

            // double result = myService.CalcPremium(51, "rural");

            double result3 = result2 / result1;

            // assert
            Assert.That( result3, Is.EqualTo( 0.5 ));
        }



    }
}
