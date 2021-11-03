using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bracket
{
    public class BracketParameters
    {
        private List<Parameter> _parameters = new List<Parameter>()
        {
            { new Parameter(80, 70, 100, ParameterName.PlateWidth, "Plate Width") },
            { new Parameter(120, 100, 130, ParameterName.PlateLength, "Plate Length") },
            { new Parameter(60, 50, 70, ParameterName.OuterTubeDiameter, "Outer Tube Diameter") },
            { new Parameter(10, 5, 12, ParameterName.MountingHoleDiameter, "Mounting Hole Diameter") },
            { new Parameter(10, 8, 15, ParameterName.HoleHeight, "Hole Height") },
            { new Parameter(25, 20, 30, ParameterName.SideWallHeight, "Side Wall Height") }
        };

        public double this[ParameterName name]
        {
            get => _parameters.Find(x => x.Name.Equals(name)).Value;
            set 
            {
                _parameters.Find(x => x.Name.Equals(name)).Value = value;
                switch (name)
                {
                    case ParameterName.OuterTubeDiameter:
                        {
                            //6  это толщина двух стенок
                            //double max = _parameters.Find(x => x.Name.Equals(ParameterName.PlateWidth)).Value - 6;
                            //max = max > 70 ? 70 : max;
                            //_parameters.Find(x => x.Name.Equals(name)).Max = max;
                            double min = value + 6;
                            min = min < 70 ? 70 : min;
                            _parameters.Find(x => x.Name.Equals(ParameterName.PlateWidth)).Min = min;
                        }
                        break;

                    case ParameterName.PlateWidth:
                        {
                            //6  это толщина двух стенок
                            //double min = _parameters.Find(x => x.Name.Equals(ParameterName.OuterTubeDiameter)).Value + 6;
                            //min = min < 70 ? 70 : min;
                            //_parameters.Find(x => x.Name.Equals(name)).Min = min;
                            double max = value - 6;
                            max = max > 70 ? 70 : max;
                            _parameters.Find(x => x.Name.Equals(ParameterName.OuterTubeDiameter)).Max = max;
                        }
                        break;

                    case ParameterName.SideWallHeight:
                        {
                            //5 это расстояние от границы отверстия до конца стенки сверху
                            //double min = _parameters.Find(x => x.Name.Equals(ParameterName.MountingHoleDiameter)).Value / 2 +
                            //    _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Value + 5;
                            //min = min < 20 ? 20 : min;
                            //_parameters.Find(x => x.Name.Equals(name)).Min = min;
                            double maxMountingHoleDiameter =
                                value - _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Value - 5 + 3;
                            maxMountingHoleDiameter = maxMountingHoleDiameter > 12 ? 12 : maxMountingHoleDiameter;

                            double radius = _parameters.Find(x => x.Name.Equals(ParameterName.MountingHoleDiameter)).Value / 2;
                            double maxHoleHeight =
                                 value - radius - 5;
                            maxHoleHeight = maxHoleHeight > 15 ? 15 : maxHoleHeight;

                            double minHoleHeight = radius + 3;
                            minHoleHeight = minHoleHeight > 7 ? minHoleHeight : 7;

                            _parameters.Find(x => x.Name.Equals(ParameterName.MountingHoleDiameter)).Max = maxMountingHoleDiameter;
                            _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Min = minHoleHeight;
                            _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Max = maxHoleHeight;
                        }
                        break;

                    case ParameterName.HoleHeight:
                        {
                            //5 это расстояние от границы отверстия до конца стенки сверху
                            //double max =_parameters.Find(x => x.Name.Equals(ParameterName.SideWallHeight)).Value -
                            //    _parameters.Find(x => x.Name.Equals(ParameterName.MountingHoleDiameter)).Value / 2 - 5;
                            //max = max > 15 ? max : 15;
                            //_parameters.Find(x => x.Name.Equals(name)).Max = max;
                            double minSideWallHeight = 
                                _parameters.Find(x => x.Name.Equals(ParameterName.MountingHoleDiameter)).Value / 2 + value + 5;
                            minSideWallHeight = minSideWallHeight < 20 ? 20 : minSideWallHeight;

                            double maxMountingHoleDiameter = 
                                _parameters.Find(x => x.Name.Equals(ParameterName.SideWallHeight)).Value - value - 5 + 3;
                            maxMountingHoleDiameter = maxMountingHoleDiameter > 12 ? 12 : maxMountingHoleDiameter;

                            _parameters.Find(x => x.Name.Equals(ParameterName.SideWallHeight)).Min = minSideWallHeight;
                            _parameters.Find(x => x.Name.Equals(ParameterName.MountingHoleDiameter)).Max = maxMountingHoleDiameter;
                        }
                        break;

                    case ParameterName.MountingHoleDiameter:
                        {
                            //5 это расстояние от границы отверстия до конца стенки сверху
                            //double max = _parameters.Find(x => x.Name.Equals(ParameterName.SideWallHeight)).Value -
                            //    _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Value - 5;
                            //max = max > 12 ? 12 : max;
                            //_parameters.Find(x => x.Name.Equals(name)).Max = max;
                            double minSideWallHeight =
                               _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Value + value / 2 + 5;
                            minSideWallHeight = minSideWallHeight < 20 ? 20 : minSideWallHeight;

                            double maxHoleHeight = 
                                _parameters.Find(x => x.Name.Equals(ParameterName.SideWallHeight)).Value - value / 2 - 5;
                            maxHoleHeight = maxHoleHeight > 15 ? 15 : maxHoleHeight;

                            double minHoleHeight = value / 2 + 3;
                            minHoleHeight = minHoleHeight > 7 ? minHoleHeight : 7;

                            _parameters.Find(x => x.Name.Equals(ParameterName.SideWallHeight)).Min = minSideWallHeight;
                            _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Min = minHoleHeight;
                            _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Max = maxHoleHeight;
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Метод для получения минимального или максимально значения
        /// </summary>
        /// <param name="name"> Название параметра</param>
        /// <param name="parameter"> название значения, которое надо получить (min или max)</param>
        /// <returns>Возвращает число или исключение </returns>
        public double this[ParameterName name, string parameter]
        {
            get
            {
                switch(parameter)
                {
                    case "min":
                        {
                            return _parameters.Find(x => x.Name.Equals(name)).Min;
                        }
                    case "max":
                        {
                            return _parameters.Find(x => x.Name.Equals(name)).Max;
                        }
                    default:
                        {
                            throw new ArgumentException("The wrong parameter was entered!");
                        }
                }
            }
        }
    }
}
