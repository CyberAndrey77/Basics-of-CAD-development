using System.Collections.Generic;

namespace Bracket
{
    public class BracketParameters
    {
        private const double MIN_SIDE_WALL_HEIGHT = 20;
        private const double MAX_HOLE_HEIGHT = 15;
        private const double MIN_HOLE_HEIGHT = 7;
        private const double MAX_MOUNTING_HOLE_RADIUS = 6;
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
                        SetMaxMountingHoleRadius();
                        SetMaxHoleHeight();
                        SetMinHoleHeight();
                    }
                    break;

                case ParameterName.HoleHeight:
                    {
                        SetMinSideWallHeight();
                        SetMaxMountingHoleRadius();
                    }
                    break;

                case ParameterName.MountingHoleRadius:
                    {
                        SetMinSideWallHeight();
                        SetMaxHoleHeight();
                        SetMinHoleHeight();
                    }
                    break;
            }
        }

        private void SetMaxMountingHoleRadius()
        {
            double bottomDistance = _parameters[ParameterName.HoleHeight].Value - 
                _parameters[ParameterName.PlaneThickness].Value;
            double topDistance = _parameters[ParameterName.SideWallHeight].Value - 
                _parameters[ParameterName.DistanceFromWall].Value - _parameters[ParameterName.HoleHeight].Value;

            double distance = bottomDistance < topDistance ? bottomDistance : topDistance;

            _parameters[ParameterName.MountingHoleRadius].Max = distance > MAX_MOUNTING_HOLE_RADIUS ?
                MAX_MOUNTING_HOLE_RADIUS : distance;
        }

        private void SetMinSideWallHeight()
        {
            var minSideWallHeight = _parameters[ParameterName.HoleHeight].Value + 
                _parameters[ParameterName.MountingHoleRadius].Value + _parameters[ParameterName.DistanceFromWall].Value;

            minSideWallHeight = minSideWallHeight < MIN_SIDE_WALL_HEIGHT ? MIN_SIDE_WALL_HEIGHT : minSideWallHeight;

            _parameters[ParameterName.SideWallHeight].Min = minSideWallHeight;
        }

        private void SetMaxHoleHeight()
        {
            var maxHoleHeight = _parameters[ParameterName.SideWallHeight].Value - 
                _parameters[ParameterName.DistanceFromWall].Value - _parameters[ParameterName.MountingHoleRadius].Value;

            maxHoleHeight = maxHoleHeight < MAX_HOLE_HEIGHT ? maxHoleHeight : MAX_HOLE_HEIGHT;

            _parameters[ParameterName.HoleHeight].Max = maxHoleHeight;
        }

        private void SetMinHoleHeight()
        {
            var minHoleHeight = _parameters[ParameterName.MountingHoleRadius].Value + 
                _parameters[ParameterName.PlaneThickness].Value;

            minHoleHeight = minHoleHeight < MIN_HOLE_HEIGHT ? MIN_HOLE_HEIGHT : minHoleHeight;

            _parameters[ParameterName.HoleHeight].Min = minHoleHeight;
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
