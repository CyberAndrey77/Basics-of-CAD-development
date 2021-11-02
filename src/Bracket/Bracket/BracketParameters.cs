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
            { new Parameter(10, 7, 15, ParameterName.HoleHeight, "Hole Height") },
            { new Parameter(25, 20, 30, ParameterName.SideWallHeight, "Side Wall Height") }
        };

        public double this[ParameterName name]
        {
            get => _parameters.Find(x => x.Name.Equals(name)).Value;
            set 
            {
                switch (name)
                {
                    case ParameterName.OuterTubeDiameter:
                        {
                            //6  это толщина двух стенок
                            _parameters.Find(x => x.Name.Equals(name)).Max = 
                                _parameters.Find(x => x.Name.Equals(ParameterName.PlateWidth)).Value - 6;
                        }
                        break;

                    case ParameterName.PlateWidth:
                        {
                            //6  это толщина двух стенок
                            _parameters.Find(x => x.Name.Equals(name)).Min = 
                                _parameters.Find(x => x.Name.Equals(ParameterName.OuterTubeDiameter)).Value + 6;
                        }
                        break;

                    case ParameterName.SideWallHeight:
                        {
                            //5 это расстояние от границы отверстия до конца стенки сверху
                            _parameters.Find(x => x.Name.Equals(name)).Min = 
                                _parameters.Find(x => x.Name.Equals(ParameterName.MountingHoleDiameter)).Value + 
                                _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Value + 5;
                        }
                        break;

                    case ParameterName.HoleHeight:
                        {
                            //5 это расстояние от границы отверстия до конца стенки сверху
                            _parameters.Find(x => x.Name.Equals(name)).Max = 
                                _parameters.Find(x => x.Name.Equals(ParameterName.SideWallHeight)).Value - 
                                _parameters.Find(x => x.Name.Equals(ParameterName.MountingHoleDiameter)).Value - 5;
                        }
                        break;

                    case ParameterName.MountingHoleDiameter:
                        {
                            //5 это расстояние от границы отверстия до конца стенки сверху
                            _parameters.Find(x => x.Name.Equals(name)).Max = 
                                _parameters.Find(x => x.Name.Equals(ParameterName.SideWallHeight)).Value - 
                                _parameters.Find(x => x.Name.Equals(ParameterName.HoleHeight)).Value - 5;
                        }
                        break;
                }
                _parameters.Find(x => x.Name.Equals(name)).Value = value;
            }
        }
    }
}
