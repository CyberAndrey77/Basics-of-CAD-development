using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace Bracket.UnitTests
{
    [TestFixture]
    public class BracketParametersTest
    {
        private Dictionary<ParameterName, Parameter> _threeParameters => 
            new Dictionary<ParameterName, Parameter>
        {
            {
                ParameterName.PlateWidth, 
                new Parameter(80, 70, 100, ParameterName.PlateWidth) 
            },
            {
                ParameterName.OuterTubeDiameter,
                new Parameter(60, 50, 70, ParameterName.OuterTubeDiameter) 
            },
            {
                ParameterName.PlaneThickness, 
                new Parameter(3, 3, 3, ParameterName.PlaneThickness) 
            }
        };
        
        private Dictionary<ParameterName, Parameter> _fiveParameters => 
            new Dictionary<ParameterName, Parameter>
        {
            {
                ParameterName.MountingHoleRadius, 
                new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) 
            },
            {
                ParameterName.HoleHeight, 
                new Parameter(10, 8, 15, ParameterName.HoleHeight) 
            },
            { 
                ParameterName.SideWallHeight, 
                new Parameter(25, 20, 30, ParameterName.SideWallHeight) 
            },
            { 
                ParameterName.PlaneThickness, 
                new Parameter(3, 3, 5, ParameterName.PlaneThickness) 
            },
            { 
                ParameterName.DistanceFromWall, 
                new Parameter(5, 5, 5, ParameterName.DistanceFromWall) 
            }
        };

        [TestCase(TestName = "Тестирование конструктора")]
        public void TestConstructor()
        {
            //Arrange
            var expectedParameters = new Dictionary<ParameterName, Parameter>()
            {
                {
                    ParameterName.PlateWidth,
                    new Parameter(80, 70, 100, ParameterName.PlateWidth)
                },
                {
                    ParameterName.PlateLength,
                    new Parameter(120, 100, 130, ParameterName.PlateLength)
                },
                {
                    ParameterName.OuterTubeDiameter,
                    new Parameter(60, 50, 70, ParameterName.OuterTubeDiameter)
                },
                {
                    ParameterName.MountingHoleRadius,
                    new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius)
                },
                {
                    ParameterName.HoleHeight,
                    new Parameter(10, 8, 15, ParameterName.HoleHeight)
                },
                {
                    ParameterName.SideWallHeight,
                    new Parameter(25, 20, 30, ParameterName.SideWallHeight)
                },
                {
                    ParameterName.PlaneThickness,
                    new Parameter(3, 3, 5, ParameterName.PlaneThickness)
                },
                {
                    ParameterName.TubeHeight,
                    new Parameter(81, 70, 90, ParameterName.TubeHeight)
                },
                {
                    ParameterName.TubeWallThickness,
                    new Parameter(5, 5, 5, ParameterName.TubeWallThickness)
                },
                {
                    ParameterName.DistanceFromWall,
                    new Parameter(5, 5, 10, ParameterName.DistanceFromWall)
                }
            };
            //Act
            var actualParameters = new BracketParameters();

            //Assert
            Assert.Multiple(() =>
            {
                foreach (var item in expectedParameters)
                {
                    Assert.AreEqual(item.Value.Value, actualParameters[item.Key].Value);
                    Assert.AreEqual(item.Value.Max, actualParameters[item.Key].Max);
                    Assert.AreEqual(item.Value.Min, actualParameters[item.Key].Min);
                }
            });
        }

        [TestCase(TestName = "Получение параметра")]
        public void GetParameter_ResultCorrect()
        {
            //Arrange
            var expectedParameter = new Parameter()
            {
                Max = 20.0,
                Min = 10.0,
                Name = ParameterName.PlateLength,
                Value = 15.0
            };
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                { expectedParameter.Name, expectedParameter }
            };
            var bracketParameters = new BracketParameters(parameters);

            //Act
            var actualParameter = new Parameter()
            {
                Min = bracketParameters[expectedParameter.Name].Min,
                Max = bracketParameters[expectedParameter.Name].Max,
                Name = bracketParameters[expectedParameter.Name].Name,
                Value = bracketParameters[expectedParameter.Name].Value
            };

            //Assert
            Assert.IsTrue(actualParameter.Equals(expectedParameter));
        }

        [TestCase(TestName = "Занесение параметра")]
        public void SetParameter_ResultCorrect()
        {
            //Arrange
            var expectedValue = 17.0;
            var parameter = new Parameter()
            {
                Max = 20.0,
                Min = 10.0,
                Name = ParameterName.PlateLength,
                Value = 15.0
            };
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                { parameter.Name, parameter }
            };
            var bracketParameters = new BracketParameters(parameters);

            //Act
            bracketParameters.SetParameter(parameter.Name, expectedValue);
            var actualValue = bracketParameters[parameter.Name].Value;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(TestName = "Изменение минимума параметра PlateWidth изменением OuterTubeDiameter")]
        public void ChangePlateWidthParameter_SetValueOuterTubeDiameter_ResultCorrect()
        {
            //Arrange
            var expectedMinPlateWidth = 76;
            var bracketParameters = new BracketParameters(_threeParameters);

            //Act
            //вводим максимальное значение для диаметра трубки
            bracketParameters.SetParameter(ParameterName.OuterTubeDiameter, 70);
            var actualMinPlateWidth = bracketParameters[ParameterName.PlateWidth].Min;

            //Assert
            Assert.AreEqual(expectedMinPlateWidth, actualMinPlateWidth);
        }

        [TestCase(TestName = "Изменение максимума параметра OuterTubeDiameter изменением PlateWidth")]
        public void ChangeOuterTubeDiameterParameter_SetValuePlatreWidth_ResultCorrect()
        {
            //Arrange
            var expectedMaxOuterTubeDiameter = 64;
            var bracketParameters = new BracketParameters(_threeParameters);

            //Act
            //вводим минимальное значение для ширины пластины
            bracketParameters.SetParameter(ParameterName.PlateWidth, 70);
            var actualMaxOuterTubeDiameter = bracketParameters[ParameterName.OuterTubeDiameter].Max;

            //Assert
            Assert.AreEqual(expectedMaxOuterTubeDiameter, actualMaxOuterTubeDiameter);
        }

        [TestCase(9, ParameterName.MountingHoleRadius, 6, ParameterName.HoleHeight, 
            TestName = "Изменение минимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на максимальное значение")]
        [TestCase(7, ParameterName.MountingHoleRadius, 2.5, ParameterName.HoleHeight,
            TestName = "Изменение минимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на минимальное значение")]
        [TestCase(25, ParameterName.HoleHeight, 15, ParameterName.SideWallHeight, 
            TestName = "Изменение минимума параметра SideWallHeight путем изменения HoleHeight")]
        [TestCase(21, ParameterName.MountingHoleRadius, 6, ParameterName.SideWallHeight, 
            TestName = "Изменение минимума параметра SideWallHeight путем изменения MountingHoleRadius")]
        [TestCase(8, ParameterName.PlaneThickness, 3, ParameterName.HoleHeight, 
            TestName = "Изменение минимума HoleHeight, путём изменения PlaneThickness")]
        [TestCase(10, ParameterName.PlaneThickness, 5, ParameterName.HoleHeight, 
            TestName = "Изменение минимума HoleHeight, путём изменения PlaneThickness")]
        public void ChangeDependentParameterMinimum_SetValue_ResultCorrect(
            double expected, ParameterName parameter, double value, ParameterName changeableParametr)
        {
            //Arrange
            var expectedMinSideWallHeight = expected;
            var bracketParameters = new BracketParameters(_fiveParameters);

            //Act
            bracketParameters.SetParameter(parameter, value);
            var actualMinSideWallHeight = bracketParameters[changeableParametr].Min;

            //Assert
            Assert.AreEqual(expectedMinSideWallHeight, actualMinSideWallHeight);
        }

        [TestCase(10, ParameterName.SideWallHeight, 20, ParameterName.HoleHeight,
            TestName = "Изменение максимума параметра HoleHeight путем изменения SideWallHeight")]
        [TestCase(14, ParameterName.MountingHoleRadius, 6, ParameterName.HoleHeight,
            TestName = "Изменение максимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на максимальное значение")]
        [TestCase(5, ParameterName.HoleHeight, 8, ParameterName.MountingHoleRadius,
            TestName = "Изменение максимума параметра MountingHoleRadius путем " +
            "изменения HoleHeight на минимальное значение")]
        [TestCase(5, ParameterName.SideWallHeight, 20, ParameterName.MountingHoleRadius,
            TestName = "Изменение максимума параметра MountingHoleRadius путем " +
            "изменения SideWallHeight на минимальное значение")]
        public void ChangeDependentParameterMaximum_SetValue_ResultCorrect(
            double expected, ParameterName parameter, double value, ParameterName changeableParametr)
        {
            //Arrange
            var expectedMaxHoleHeight = expected;
            var bracketParameters = new BracketParameters(_fiveParameters);

            //Act
            bracketParameters.SetParameter(parameter, value);
            var actualMaxHoleHeight = bracketParameters[changeableParametr].Max;

            //Assert
            Assert.AreEqual(expectedMaxHoleHeight, actualMaxHoleHeight);
        }

        [TestCase(TestName = "Изменение максимума параметра MountingHoleRadius путем " +
            "изменения HoleHeight на минимальное значение и изменение SideWallHeight на минимальное значение")]
        public void ChangeMaxMountingHoleRadius_SetMinHoleHeightAndMinSideWallHeight_ResultCorrect()
        {
            //Arrange
            var expectedMaxMountingHoleRadius = 5;

            //в этом месте нужно задать мин. радиус
            _fiveParameters[ParameterName.MountingHoleRadius].Value = 2.5;
            var bracketParameters = new BracketParameters(_fiveParameters);

            //Act
            bracketParameters.SetParameter(ParameterName.SideWallHeight, 20);
            bracketParameters.SetParameter(ParameterName.HoleHeight, 8);
            var actualMaxMountingHoleRadius = bracketParameters[ParameterName.MountingHoleRadius].Max;

            //Assert
            Assert.AreEqual(expectedMaxMountingHoleRadius, actualMaxMountingHoleRadius);
        }

        [TestCase(6, ParameterName.HoleHeight, 15, 
            ParameterName.SideWallHeight, 30, ParameterName.MountingHoleRadius, 
            TestName = "Изменение максимума параметра MountingHoleRadius путем " +
            "изменения HoleHeight на максимальное значение " +
            "и изменение SideWallHeight на максимальное значение")]
        [TestCase(12.5, ParameterName.MountingHoleRadius, 2.5, 
            ParameterName.SideWallHeight, 20, ParameterName.HoleHeight, 
            TestName = "Изменение максимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на минимальное значение и " +
            "изменение SideWallHeight на минимальное значение")]
        [TestCase(10, ParameterName.MountingHoleRadius, 6, 
            ParameterName.SideWallHeight, 21, ParameterName.HoleHeight, 
            TestName = "Изменение максимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на максимальное значение " +
            "и изменение SideWallHeight на минимально значение")]
        public void ChangeDependentParameterMaximum_SetTwoValues_ResultCorrect(
            double expected, ParameterName parameter1, double value1, 
            ParameterName parameter2, double value2, ParameterName changeableParametr)
        {
            //Arrange
            var expectedHoleHeight = expected;
            var bracketParameters = new BracketParameters(_fiveParameters);

            //Act
            bracketParameters.SetParameter(parameter1, value1);
            bracketParameters.SetParameter(parameter2, value2);
            var actualHoleHeight = bracketParameters[changeableParametr].Max;

            //Assert
            Assert.AreEqual(expectedHoleHeight, actualHoleHeight);
        }

        [TestCase(25, ParameterName.MountingHoleRadius, 6,
            ParameterName.HoleHeight, 14, ParameterName.SideWallHeight,
            TestName = "Изменение минимума зависимого параметра SideWallHeight путем " +
            "изменения MountingHoleRadius и HoleHeight")]
        public void ChangeDependentParameterMinimum_SetTwoValues_ResultCorrect(
            double expected, ParameterName parameter1, double value1,
            ParameterName parameter2, double value2, ParameterName changeableParametr)
        {
            //Arrange
            var expectedMinSideWallHeight = expected;
            var bracketParameters = new BracketParameters(_fiveParameters);

            //Act
            //вводим максимальное значение для радиуса отверстия
            bracketParameters.SetParameter(parameter1, value1);
            //вводим максимальное значение для высоты отверстия
            bracketParameters.SetParameter(parameter2, value2);
            var actualMinSideWallHeight = bracketParameters[changeableParametr].Min;

            //Assert
            Assert.AreEqual(expectedMinSideWallHeight, actualMinSideWallHeight);
        }
    }
}
