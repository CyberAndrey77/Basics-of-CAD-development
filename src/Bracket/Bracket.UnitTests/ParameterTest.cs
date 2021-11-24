using NUnit.Framework;
using System;

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

            //Act
            var parameter = new Parameter(expectedValue, expectedMin, expectedMax, expectedName);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedValue, parameter.Value);
                Assert.AreEqual(expectedMax, parameter.Max);
                Assert.AreEqual(expectedMin, parameter.Min);
                Assert.AreEqual(expectedName, parameter.Name);
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства Min на отрицательные значения")]
        public void SetMin_MinLessZero_ArgumentException()
        {
            //Arrange
            var expectedMin = -1.0;
            var parameter = new Parameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.Min = expectedMin;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства Min на внесение корректных значений")]
        public void SetCorrectMin_ResultCorrectSet()
        {
            //Arrange
            var expectedMin = 1.0;
            var parameter = new Parameter();

            //Act
            parameter.Min = expectedMin;

            //Assert
            Assert.AreEqual(expectedMin, parameter.Min);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства Max на отрицательные значения")]
        public void SetMAx_MAxLessZero_ArgumentException()
        {
            //Arrange
            var expectedMax = -1.0;
            var parameter = new Parameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.Max = expectedMax;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства Max, меньше ли он свойства Min")]
        public void SetMax_MaxLessMin_ArgumentException()
        {
            //Arrange
            var expectedMin = 10.0;
            var expectedMax = 5.0;
            var parameter = new Parameter() { Min = expectedMin };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.Max = expectedMax;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства Max на внесение корректных значений")]
        public void SetCorrectMax_ResultCorrectSet()
        {
            //Arrange
            var expectedMin = 1.0;
            var expectedMax = 5.0;
            var parameter = new Parameter()
            {
                Min = expectedMin
            };

            //Act
            parameter.Max = expectedMax;

            //Assert
            Assert.AreEqual(expectedMax, parameter.Max);
        }

        [TestCase(TestName = "Значение параметра меньше минимального порога")]
        public void SetMinimumValue_ArgumentExcepton()
        {
            //Arrange
            var expectedMin = 10.0;
            var expectedMax = 20.0;
            var expectedValue = 5.0;
            var parameter = new Parameter()
            {
                Min = expectedMin,
                Max = expectedMax
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.Value = expectedValue;
            });
        }

        [TestCase(TestName = "Значение параметра больше максимального порога")]
        public void SetMaximumValue_ArgumentExcepton()
        {
            //Arrange
            var expectedMin = 10.0;
            var expectedMax = 20.0;
            var expectedValue = 25.0;
            var parameter = new Parameter()
            {
                Min = expectedMin,
                Max = expectedMax
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.Value = expectedValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства Value на внесение корректных значений")]
        public void SetCorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedMin = 10.0;
            var expectedMax = 20.0;
            var expectedValue = 15.0;
            var parameter = new Parameter()
            {
                Min = expectedMin,
                Max = expectedMax
            };

            //Act
            parameter.Value = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.Value);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства Name на внесение корректных значений")]
        public void SetName_ResultCorrectSet()
        {
            //Arrange
            var expectedName = ParameterName.PlateLength;
            var parameter = new Parameter();

            //Act
            parameter.Name = expectedName;

            //Assert
            Assert.AreEqual(expectedName, parameter.Name);
        }
    }
}
