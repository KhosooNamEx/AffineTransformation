using NUnit.Framework;
using Affine_Transformer;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        FirmwareCalculation obj;
        [SetUp]
        public void Setup()
        {
            obj = new FirmwareCalculation();
        }
        /// <summary>
        /// ToRadian Test
        /// </summary>
        [Test]
        public void ToRadianCalculation()
        {
            float angle = 3.6F;
            float angleInRadian = obj.ToRadianCalculation(angle);

            Assert.That(angleInRadian, Is.EqualTo(Convert.ToSingle(Math.PI / 180 * 3.6F)));
        }
        /// <summary>
        /// OutputA Test
        /// </summary>
        [Test]
        public void CalculationOutputA()
        {
            float angle = 3.6F;
            float angleInRadian = Convert.ToSingle(Math.PI / 180 * angle);

            float OutputA =obj.CalculateOutputA(angleInRadian);

            Assert.That(OutputA, Is.EqualTo(Convert.ToSingle(Math.Cos(angleInRadian))));
        }
    }
}