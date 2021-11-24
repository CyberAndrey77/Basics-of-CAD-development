using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Bracket;

namespace Bracket.UnitTests
{
    [TestFixture]
    class ParameterTest
    {
        [TestCase(TestName = "Проверка корректное создания объекта Параметр при помощи конструктора")]
        public void Constructor_ResultCorrectConstructorInit()
        {
            //Arrange
            var expectedValue = 17.5;
            var expectedMin = 10.0;
            var expectedMax = 20.0;
            var expectedName = ParameterName.PlateWidth;
            var expectedParameterName = "Plate Width";

            //Act
            var parameter = new Parameter(expectedValue, expectedMin, expectedMax, expectedName, expectedParameterName);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedValue, parameter.Value);
                Assert.AreEqual(expectedMax, parameter.Max);
                Assert.AreEqual(expectedMin, parameter.Min);
                Assert.AreEqual(expectedName, parameter.Name);
                Assert.AreEqual(expectedParameterName, parameter.ParameterName);
            });
        }

        [TestCase(TestName = "Значение параметра меньше минимального порога")]
        public void SetMinimumValue_ArgumentExcepton()
        {
            //Setup
            double minValue = 10.0;
            double maxValue = 20.0;
            double value = 5.0;
            var name = ParameterName.PlateWidth;
            var parameterName = "PlateWidth";

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                var parameter = new Parameter(value, minValue, maxValue, name, parameterName);
            });
        }

        [TestCase(TestName = "Значение параметра больше максимального порога")]
        public void SetMaximumValue_ArgumentExcepton()
        {
            //Setup
            double minValue = 10.0;
            double maxValue = 20.0;
            double value = 25.0;
            var name = ParameterName.PlateWidth;
            var parameterName = "PlateWidth";

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                var parameter = new Parameter(value, minValue, maxValue, name, parameterName);
            });
        }
    }
}
