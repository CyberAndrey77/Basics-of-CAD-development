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
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.PlateWidth, new Parameter(80, 70, 100, ParameterName.PlateWidth) },
                {ParameterName.OuterTubeDiameter, new Parameter(60, 50, 70, ParameterName.OuterTubeDiameter) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) }
            };
            var bracketParameters = new BracketParameters(parameters);

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
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.PlateWidth, new Parameter(80, 70, 100, ParameterName.PlateWidth) },
                {ParameterName.OuterTubeDiameter, new Parameter(60, 50, 70, ParameterName.OuterTubeDiameter) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) }
            };
            var bracketParameters = new BracketParameters(parameters);

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
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.MountingHoleRadius, new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) },
                {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
                {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
                {ParameterName.DistanceFromWall, new Parameter(5, 5, 5, ParameterName.DistanceFromWall) }
            };
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
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.MountingHoleRadius, new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) },
                {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
                {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
                {ParameterName.DistanceFromWall, new Parameter(5, 5, 5, ParameterName.DistanceFromWall) }
            };
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
            var expectedMinSideWallHeight = 26;
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.MountingHoleRadius, new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) },
                {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
                {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
                {ParameterName.DistanceFromWall, new Parameter(5, 5, 5, ParameterName.DistanceFromWall) }
            };
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим максимальное значение для радиуса отверстия
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, 6);
            //вводим максимальное значение для высоты отверстия
            bracketParameters.SetParameter(ParameterName.HoleHeight, 15);
            var actualMinSideWallHeight = bracketParameters[ParameterName.SideWallHeight].Min;

            //Assert
            Assert.AreEqual(expectedMinSideWallHeight, actualMinSideWallHeight);
        }

        [TestCase(TestName = "Изменение зависимого параметра HoleHeight путем изменения SideWallHeight")]
        public void ChangeHoleHeight_SetValueSideWallHeight_ResultCorrect()
        {
            //Arrange
            var expectedMaxHoleHeight = 10;
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.MountingHoleRadius, new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) },
                {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
                {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
                {ParameterName.DistanceFromWall, new Parameter(5, 5, 5, ParameterName.DistanceFromWall) }
            };
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим минимальное значение для высоты стенки
            bracketParameters.SetParameter(ParameterName.SideWallHeight, 20);
            var actualMaxHoleHeight = bracketParameters[ParameterName.HoleHeight].Max;

            //Assert
            Assert.AreEqual(expectedMaxHoleHeight, actualMaxHoleHeight);
        }

        [TestCase(TestName = "Изменение минимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на максимальное значение")]
        public void ChangeMinHoleHeight_SetMaxMountingHoleRadius_ResultCorrect()
        {
            //Arrange
            var expectedMinHoleHeight = 9;
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.MountingHoleRadius, new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) },
                {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
                {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
                {ParameterName.DistanceFromWall, new Parameter(5, 5, 5, ParameterName.DistanceFromWall) }
            };
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим максимальное значение для радиуса отверстия
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, 6);
            var actualMinHoleHeight = bracketParameters[ParameterName.HoleHeight].Min;

            //Assert
            Assert.AreEqual(expectedMinHoleHeight, actualMinHoleHeight);
        }

        [TestCase(TestName = "Изменение минимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на минимальное значение")]
        public void ChangeMinHoleHeight_SetMinMountingHoleRadius_ResultCorrect()
        {
            //Arrange
            var expectedMinHoleHeight = 7;
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.MountingHoleRadius, new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) },
                {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
                {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
                {ParameterName.DistanceFromWall, new Parameter(5, 5, 5, ParameterName.DistanceFromWall) }
            };
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим минимальное значение для радиуса отверстия
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, 2.5);
            var actualMinHoleHeight = bracketParameters[ParameterName.HoleHeight].Min;

            //Assert
            Assert.AreEqual(expectedMinHoleHeight, actualMinHoleHeight);
        }

        [TestCase(TestName = "Изменение максимума параметра HoleHeight путем " +
            "изменения MountingHoleRadius на максимальное значение")]
        public void ChangeMaxHoleHeight_SetMaxMountingHoleRadius_ResultCorrect()
        {
            //Arrange
            var expectedMaxHoleHeight = 14;
            Dictionary<ParameterName, Parameter> parameters = new Dictionary<ParameterName, Parameter>
            {
                {ParameterName.MountingHoleRadius, new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) },
                {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
                {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
                {ParameterName.DistanceFromWall, new Parameter(5, 5, 5, ParameterName.DistanceFromWall) }
            };
            var bracketParameters = new BracketParameters(parameters);

            //Act
            //вводим минимальное значение для радиуса отверстия
            bracketParameters.SetParameter(ParameterName.MountingHoleRadius, 6);
            var actualMaxHoleHeight = bracketParameters[ParameterName.HoleHeight].Max;

            //Assert
            Assert.AreEqual(expectedMaxHoleHeight, actualMaxHoleHeight);
        }
    }
}
