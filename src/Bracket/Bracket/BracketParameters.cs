using System.Collections.Generic;

namespace Bracket
{
    public class BracketParameters
    {
        /// <summary>
        /// Словарь содержит параметры кронштейна.
        /// </summary>
        private Dictionary<ParameterName, Parameter> _parameters;

        /// <summary>
        /// Задает значение параметра и изменяет минимальные и максимальные значения у зависимых параметров.
        /// </summary>
        /// <param name="name">Название параметра</param>
        /// <param name="value">Значение параметра</param>
        public void SetParameter(ParameterName name, double value)
        {
            _parameters[name].Value = value;
            switch (name)
            {
                case ParameterName.OuterTubeDiameter:
                    {
                        double minValuePlateWidth = 70;
                        double min = value + _parameters[ParameterName.PlaneThickness].Value * 2;
                        min = min < minValuePlateWidth ? minValuePlateWidth : min;
                        _parameters[ParameterName.PlateWidth].Min = min;
                    }
                    break;

                case ParameterName.PlateWidth:
                    {
                        double maxOuterTubeDiameter = 70;
                        double max = value - _parameters[ParameterName.PlaneThickness].Value * 2;
                        max = max > maxOuterTubeDiameter ? maxOuterTubeDiameter : max;
                        _parameters[ParameterName.OuterTubeDiameter].Max = max;
                    }
                    break;

                case ParameterName.SideWallHeight:
                    {

                        double maxMountingHoleRadius =
                            value - _parameters[ParameterName.HoleHeight].Min - 
                            _parameters[ParameterName.DistanceFromWall].Value + _parameters[ParameterName.PlaneThickness].Value;

                        double maxValueMountingHoleRadius = 6;
                        maxMountingHoleRadius = maxMountingHoleRadius > maxValueMountingHoleRadius ?
                            maxValueMountingHoleRadius : maxMountingHoleRadius;

                        double radius = _parameters[ParameterName.MountingHoleRadius].Max;
                        double maxHoleHeight =
                             value + radius - _parameters[ParameterName.DistanceFromWall].Value;//-

                        double maxValueHoleHeight = 15;
                        maxHoleHeight = maxHoleHeight > maxValueHoleHeight ? maxValueHoleHeight : maxHoleHeight;

                        double minHoleHeight = _parameters[ParameterName.MountingHoleRadius].Value + _parameters[ParameterName.PlaneThickness].Value;

                        double minValueHoleHeight = 7;
                        minHoleHeight = minHoleHeight > minValueHoleHeight ? minHoleHeight : minValueHoleHeight;

                        _parameters[ParameterName.MountingHoleRadius].Max = maxMountingHoleRadius;
                        _parameters[ParameterName.HoleHeight].Min = minHoleHeight;
                        _parameters[ParameterName.HoleHeight].Max = maxHoleHeight;
                    }
                    break;

                case ParameterName.HoleHeight:
                    {
                        double minSideWallHeight =
                            _parameters[ParameterName.MountingHoleRadius].Value + value + 
                            _parameters[ParameterName.DistanceFromWall].Value;

                        double minValueSideWallHeight = 20;
                        minSideWallHeight = minSideWallHeight < minValueSideWallHeight ? minValueSideWallHeight : minSideWallHeight;

                        double maxMountingHoleRadius =
                            _parameters[ParameterName.SideWallHeight].Max - value -
                            _parameters[ParameterName.DistanceFromWall].Value + _parameters[ParameterName.PlaneThickness].Value;

                        double maxValueMountingHoleRadius = 6;
                        maxMountingHoleRadius = maxMountingHoleRadius > maxValueMountingHoleRadius ?
                            maxValueMountingHoleRadius : maxMountingHoleRadius;

                        _parameters[ParameterName.SideWallHeight].Min = minSideWallHeight;
                        _parameters[ParameterName.MountingHoleRadius].Max = maxMountingHoleRadius;
                    }
                    break;

                case ParameterName.MountingHoleRadius:
                    {
                        double minSideWallHeight =
                           _parameters[ParameterName.HoleHeight].Value + value + 
                           _parameters[ParameterName.DistanceFromWall].Value;

                        double minValueSideWallHeight = 20;
                        minSideWallHeight = minSideWallHeight < minValueSideWallHeight ? minValueSideWallHeight : minSideWallHeight;

                        double maxHoleHeight =
                            _parameters[ParameterName.SideWallHeight].Max - value -
                            _parameters[ParameterName.DistanceFromWall].Value;

                        double maxValueHoleHeight = 15;
                        maxHoleHeight = maxHoleHeight > maxValueHoleHeight ? maxValueHoleHeight : maxHoleHeight;

                        double minHoleHeight = value + _parameters[ParameterName.PlaneThickness].Value;

                        double minValueHoleHeight = 7;
                        minHoleHeight = minHoleHeight > minValueHoleHeight ? minHoleHeight : minValueHoleHeight;

                        _parameters[ParameterName.SideWallHeight].Min = minSideWallHeight;
                        _parameters[ParameterName.HoleHeight].Min = minHoleHeight;
                        _parameters[ParameterName.HoleHeight].Max = maxHoleHeight;
                    }
                    break;
            }
        }

        /// <summary>
        /// Возвращает параметр кронштейна.
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <returns>Экземпляр класса Parameter</returns>
        public Parameter this[ParameterName name]
        {
            get => _parameters[name];
        }

        /// <summary>
        /// Конструктор задающий дефолтные значения параметров кронштейна.
        /// </summary>
        public BracketParameters()
        {
            _parameters = new Dictionary<ParameterName, Parameter>()
            {
                {ParameterName.PlateWidth, new Parameter(80, 70, 100, ParameterName.PlateWidth) },
                {ParameterName.PlateLength, new Parameter(120, 100, 130, ParameterName.PlateLength) },
                {ParameterName.OuterTubeDiameter, new Parameter(60, 50, 70, ParameterName.OuterTubeDiameter) },
                {ParameterName.MountingHoleRadius, new Parameter(5, 2.5, 6, ParameterName.MountingHoleRadius) },
                {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
                {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
                {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
                {ParameterName.TubeHeight, new Parameter(81, 81, 81, ParameterName.TubeHeight) },
                {ParameterName.TubeWallThickness, new Parameter(5, 5, 5, ParameterName.TubeWallThickness) },
                {ParameterName.DistanceFromWall, new Parameter(5, 5, 5, ParameterName.DistanceFromWall) }
            };
        }

        /// <summary>
        /// Конструктор позволяющий задать свой словарь с параметрами.
        /// </summary>
        /// <param name="parameters">Словарь параметров</param>
        public BracketParameters(Dictionary<ParameterName, Parameter> parameters)
        {
            _parameters = parameters;
        }
    }
}
