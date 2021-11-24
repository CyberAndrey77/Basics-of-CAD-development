using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bracket
{
    public class BracketParameters
    {
        private Dictionary<ParameterName, Parameter> _parameters = new Dictionary<ParameterName, Parameter>()
        {
            {ParameterName.PlateWidth, new Parameter(80, 70, 100, ParameterName.PlateWidth) },
            {ParameterName.PlateLength, new Parameter(120, 100, 130, ParameterName.PlateLength) },
            {ParameterName.OuterTubeDiameter, new Parameter(60, 50, 70, ParameterName.OuterTubeDiameter) },
            {ParameterName.MountingHoleDiameter, new Parameter(10, 5, 12, ParameterName.MountingHoleDiameter) },
            {ParameterName.HoleHeight, new Parameter(10, 8, 15, ParameterName.HoleHeight) },
            {ParameterName.SideWallHeight, new Parameter(25, 20, 30, ParameterName.SideWallHeight) },
            {ParameterName.PlaneThickness, new Parameter(3, 3, 3, ParameterName.PlaneThickness) },
            {ParameterName.TubeHeight, new Parameter(81, 81, 81, ParameterName.TubeHeight) },
            {ParameterName.TubeWallThickness, new Parameter(5, 5, 5, ParameterName.TubeWallThickness) }
        };

        public void SetParameter(ParameterName name, double value)
        {
            _parameters[name].Value = value;
            switch (name)
            {
                case ParameterName.OuterTubeDiameter:
                    {
                        double min = value + _parameters[ParameterName.PlaneThickness].Value * 2;
                        min = min < 70 ? 70 : min;
                        _parameters[ParameterName.PlateWidth].Min = min;
                    }
                    break;

                case ParameterName.PlateWidth:
                    {
                        double max = value - _parameters[ParameterName.PlaneThickness].Value * 2;
                        max = max > 70 ? 70 : max;
                        _parameters[ParameterName.OuterTubeDiameter].Max = max;
                    }
                    break;

                case ParameterName.SideWallHeight:
                    {
                        double maxMountingHoleDiameter =
                            value - _parameters[ParameterName.HoleHeight].Value - 5 +
                            _parameters[ParameterName.PlaneThickness].Value;

                        maxMountingHoleDiameter = maxMountingHoleDiameter > 12 ? 12 : maxMountingHoleDiameter;

                        double radius = _parameters[ParameterName.MountingHoleDiameter].Value / 2;
                        double maxHoleHeight =
                             value - radius - 5;
                        maxHoleHeight = maxHoleHeight > 15 ? 15 : maxHoleHeight;

                        double minHoleHeight = radius + _parameters[ParameterName.PlaneThickness].Value;
                        minHoleHeight = minHoleHeight > 7 ? minHoleHeight : 7;

                        _parameters[ParameterName.MountingHoleDiameter].Max = maxMountingHoleDiameter;
                        _parameters[ParameterName.HoleHeight].Min = minHoleHeight;
                        _parameters[ParameterName.HoleHeight].Max = maxHoleHeight;
                    }
                    break;

                case ParameterName.HoleHeight:
                    {
                        double minSideWallHeight =
                            _parameters[ParameterName.MountingHoleDiameter].Value / 2 + value + 5;
                        minSideWallHeight = minSideWallHeight < 20 ? 20 : minSideWallHeight;

                        double maxMountingHoleDiameter =
                            _parameters[ParameterName.SideWallHeight].Value - value - 5 +
                            _parameters[ParameterName.PlaneThickness].Value;

                        maxMountingHoleDiameter = maxMountingHoleDiameter > 12 ? 12 : maxMountingHoleDiameter;

                        _parameters[ParameterName.SideWallHeight].Min = minSideWallHeight;
                        _parameters[ParameterName.MountingHoleDiameter].Max = maxMountingHoleDiameter;
                    }
                    break;

                case ParameterName.MountingHoleDiameter:
                    {
                        double minSideWallHeight =
                           _parameters[ParameterName.HoleHeight].Value + value / 2 + 5;
                        minSideWallHeight = minSideWallHeight < 20 ? 20 : minSideWallHeight;

                        double maxHoleHeight =
                            _parameters[ParameterName.SideWallHeight].Value - value / 2 - 5;
                        maxHoleHeight = maxHoleHeight > 15 ? 15 : maxHoleHeight;

                        double minHoleHeight = value / 2 + _parameters[ParameterName.PlaneThickness].Value;
                        minHoleHeight = minHoleHeight > 7 ? minHoleHeight : 7;

                        _parameters[ParameterName.SideWallHeight].Min = minSideWallHeight;
                        _parameters[ParameterName.HoleHeight].Min = minHoleHeight;
                        _parameters[ParameterName.HoleHeight].Max = maxHoleHeight;
                    }
                    break;
            }
        }

        public Parameter this[ParameterName name]
        {
            get => _parameters[name];
        }
    }
}
