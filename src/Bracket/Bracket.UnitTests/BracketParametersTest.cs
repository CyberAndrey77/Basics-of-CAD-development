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
        //TODO
        private readonly Dictionary<ParameterName, Parameter> _threeParameters = 
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

        //TODO
        private readonly Dictionary<ParameterName, Parameter> _fiveParameters = 
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

        private Dictionary<ParameterName, Parameter> CreateNewDictionry(Dictionary<ParameterName, Parameter> oldDictionary)
        {
            var newDictionary = new Dictionary<ParameterName, Parameter>();
            foreach (var item in oldDictionary)
            {
                ParameterName key = item.Key;
                var value = (Parameter)item.Value.Clone();
                newDictionary.Add(key, value);
            }

            return newDictionary;
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

        [TestCase(TestName = "Изменение зависимого параметра PlateWidth")]
        public void ChangePlateWidthParameter_SetValueOuterTubeDiameter_ResultCorrect()
        {
            //Arrange
            var expectedMinPlateWidth = 76;
            Dictionary<ParameterName, Parameter> parameters = _threeParameters;
            //var bracketParameters = new BracketParameters(parameters);
            var bracketParameters = new BracketParameters(CreateNewDictionry(_threeParameters));

            //Act
            //вводим максимальное значение для диаметра трубки
            bracketParameters.SetParameter(ParameterName.OuterTubeDiameter, 70);
            var actualMinPlateWidth = bracketParameters[ParameterName.PlateWidth].Min;

            //Assert
            Assert.AreEqual(expectedMinPlateWidth, actualMinPlateWidth);
        }

        [TestCase(TestName = "Изменение зависимого параметра OuterTubeDiameter")]
        public void ChangeOuterTubeDiameterParameter_SetValuePlatreWidth_ResultCorrect()
        {
            //Arrange
            var expectedMaxOuterTubeDiameter = 64;
            var bracketParameters = new BracketParameters(CreateNewDictionry(_threeParameters));

            //Act
            //вводим минимальное значение для ширины пластины
            bracketParameters.SetParameter(ParameterName.PlateWidth, 70);
            var actualMaxOuterTubeDiameter = bracketParameters[ParameterName.OuterTubeDiameter].Max;

            //Assert
            Assert.AreEqual(expectedMaxOuterTubeDiameter, actualMaxOuterTubeDiameter);
        }

        [TestCase(TestName = "Изменение зависимого параметра SideWallHeight путем изменения HoleHeight")]
        public void ChangeSideWallHeight_SetValueHoleHeight_ResultCorrect()
        {
            //Arrange
            var expectedMinSideWallHeight = 25;

            //TODO: Дубли убрать.
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters); ;
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим максимальное значение для высоты отверстия
            bracketParameters.SetParameter(ParameterName.HoleHeight, 15);
            var actualMinSideWallHeight = bracketParameters[ParameterName.SideWallHeight].Min;

            //Assert
            Assert.AreEqual(expectedMinSideWallHeight, actualMinSideWallHeight);
        }

        [TestCase(TestName = "Изменение зависимого параметра SideWallHeight путем изменения MountingHoleRadius")]
        public void ChangeSideWallHeight_SetValueMountingHoleRadius_ResultCorrect()
        {
            //Arrange
            var expectedMinSideWallHeight = 21;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters); ;
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим максимальное значение для радиуса отверстия
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, 6);
            var actualMinSideWallHeight = bracketParameters[ParameterName.SideWallHeight].Min;

            //Assert
            Assert.AreEqual(expectedMinSideWallHeight, actualMinSideWallHeight);
        }

        [TestCase(TestName = "Изменение зависимого параметра SideWallHeight путем " +
            "изменения MountingHoleRadius и HoleHeight")]
        public void ChangeSideWallHeight_SetValueHoleHeightAndMountingHoleRadius_ResultCorrect()
        {
            //Arrange
            var expectedMinSideWallHeight = 25;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим максимальное значение для радиуса отверстия
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, 6);
            //вводим максимальное значение для высоты отверстия
            bracketParameters.SetParameter(ParameterName.HoleHeight, 14);
            var actualMinSideWallHeight = bracketParameters[ParameterName.SideWallHeight].Min;

            //Assert
            Assert.AreEqual(expectedMinSideWallHeight, actualMinSideWallHeight);
        }

        [TestCase(TestName = "Изменение зависимого параметра HoleHeight путем изменения SideWallHeight")]
        public void ChangeHoleHeight_SetValueSideWallHeight_ResultCorrect()
        {
            //Arrange
            var expectedMaxHoleHeight = 10;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим минимальное значение для высоты стенки
            bracketParameters.SetParameter(ParameterName.SideWallHeight, 20);
            var actualMaxHoleHeight = bracketParameters[ParameterName.HoleHeight].Max;

            //Assert
            Assert.AreEqual(expectedMaxHoleHeight, actualMaxHoleHeight);
        }

        [TestCase(9, 6, TestName = "Изменение минимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на максимальное значение")]
        [TestCase(7, 2.5, TestName = "Изменение минимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на минимальное значение")]
        public void ChangeMinHoleHeight_SetMountingHoleRadius_ResultCorrect(double holeHeight, 
            double mountingHoleRadius)
        {
            //Arrange
            var expectedHoleHeight = holeHeight;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим минимальное значение для радиуса отверстия
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, mountingHoleRadius);
            var actualHoleHeight = bracketParameters[ParameterName.HoleHeight].Min;

            //Assert
            Assert.AreEqual(expectedHoleHeight, actualHoleHeight);
        }

        [TestCase(TestName = "Изменение максимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на максимальное значение")]
        public void ChangeMaxHoleHeight_SetMaxMountingHoleRadius_ResultCorrect()
        {
            //Arrange
            var expectedMaxHoleHeight = 14;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим максимальное значение для радиуса отверстия
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, 6);
            var actualMaxHoleHeight = bracketParameters[ParameterName.HoleHeight].Max;

            //Assert
            Assert.AreEqual(expectedMaxHoleHeight, actualMaxHoleHeight);
        }

        [TestCase(12.5, 2.5, 20, TestName = "Изменение максимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на минимальное значение и изменение SideWallHeight на минимальное значение")]
        [TestCase(10, 6, 21, TestName = "Изменение максимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на максимальное значение и изменение SideWallHeight на минимально значение")]
        public void ChangeHoleHeight_SetMountingHoleRadiusAndSideWallHeight_ResultCorrect(double holeHeight,
            double mountingHoleRadius, double sideWallHeight)
        {
            //Arrange
            var expectedHoleHeight = holeHeight;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, mountingHoleRadius);
            bracketParameters.SetParameter(ParameterName.SideWallHeight, sideWallHeight);
            var actualHoleHeight = bracketParameters[ParameterName.HoleHeight].Max;

            //Assert
            Assert.AreEqual(expectedHoleHeight, actualHoleHeight);
        }

        [TestCase(TestName = "Изменение максимума параметра MountingHoleRadius путем " +
            "изменения HoleHeight на максимальное значение и изменение SideWallHeight на максимальное значение")]
        public void ChangeMaxMountingHoleRadius_SetMaxHoleHeightAndMaxSideWallHeight_ResultCorrect()
        {
            //Arrange
            var expectedMaxMountingHoleRadius = 6;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            bracketParameters.SetParameter(ParameterName.HoleHeight, 15);
            bracketParameters.SetParameter(ParameterName.SideWallHeight, 30);
            var actualMaxMountingHoleRadius = bracketParameters[ParameterName.MountingHoleRadius].Max;

            //Assert
            Assert.AreEqual(expectedMaxMountingHoleRadius, actualMaxMountingHoleRadius);
        }

        [TestCase(TestName = "Изменение максимума параметра MountingHoleRadius путем " +
            "изменения HoleHeight на минимальное значение и изменение SideWallHeight на минимальное значение")]
        public void ChangeMaxMountingHoleRadius_SetMinHoleHeightAndMinSideWallHeight_ResultCorrect()
        {
            //Arrange
            var expectedMaxMountingHoleRadius = 4;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);

            //в этом месте нужно задать мин. радиус
            parameters[ParameterName.MountingHoleRadius].Value = 2.5;
            var bracketParameters = new BracketParameters(parameters);

            //Act
            bracketParameters.SetParameter(ParameterName.SideWallHeight, 20);
            bracketParameters.SetParameter(ParameterName.HoleHeight, 7);
            var actualMaxMountingHoleRadius = bracketParameters[ParameterName.MountingHoleRadius].Max;

            //Assert
            Assert.AreEqual(expectedMaxMountingHoleRadius, actualMaxMountingHoleRadius);
        }

        [TestCase(TestName = "Изменение максимума параметра MountingHoleRadius путем " +
            "изменения HoleHeight на минимальное значение")]
        public void ChangeMaxMountingHoleRadius_SetMinHoleHeight_ResultCorrect()
        {
            //Arrange
            var expectedMaxMountingHoleRadius = 5;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            bracketParameters.SetParameter(ParameterName.HoleHeight, 8);
            var actualMaxMountingHoleRadius = bracketParameters[ParameterName.MountingHoleRadius].Max;

            //Assert
            Assert.AreEqual(expectedMaxMountingHoleRadius, actualMaxMountingHoleRadius);
        }

        [TestCase(TestName = "Изменение максимума параметра MountingHoleRadius путем " +
            "изменения SideWallHeight на минимальное значение")]
        public void ChangeMaxMountingHoleRadius_SetMinSideWallHeight_ResultCorrect()
        {
            //Arrange
            var expectedMaxMountingHoleRadius = 5;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            bracketParameters.SetParameter(ParameterName.SideWallHeight, 20);
            var actualMaxMountingHoleRadius = bracketParameters[ParameterName.MountingHoleRadius].Max;

            //Assert
            Assert.AreEqual(expectedMaxMountingHoleRadius, actualMaxMountingHoleRadius);
        }

        [TestCase(3, 8, TestName = "Изменение минимума HoleHeight, путём изменения PlaneThickness")]
        [TestCase(5, 10, TestName = "Изменение минимума HoleHeight, путём изменения PlaneThickness")]
        public void ChangeMinHoleHeight_SetPlaneThickness_ResultCorrect(double planeThickness, double expectedHoleHeight)
        {
            //Arrange
            var exectedPlaneThickness = planeThickness;
            Dictionary<ParameterName, Parameter> parameters = CreateNewDictionry(_fiveParameters);
            var bracketParameters = new BracketParameters(parameters);

            //Act
            bracketParameters.SetParameter(ParameterName.PlaneThickness, exectedPlaneThickness);
            var actualHoleHeight = bracketParameters[ParameterName.HoleHeight].Min;

            //Assert
            Assert.AreEqual(expectedHoleHeight, actualHoleHeight);
        }
    }
}
