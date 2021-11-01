using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bracket
{
    public class BracketParameters
    {
        private List<Parameter> _parameters = new List<Parameter>();

        public double this[ParameterName name]
        {
            get => _parameters.Find(x => x.Name.Equals(name)).Value;
            set => _parameters.Find(x => x.Name.Equals(name)).Value = value;
        }

        //private double _plateWidth = 0;
        //private double _plateLength = 0;
        //private double _outerTubeDiameter = 0;
        //private double _mountingHoleDiameter = 0;
        //private double _holeHeight = 0;
        //private double _sideWallHeight = 0;

        //public double PlateWidth
        //{
        //    get
        //    {
        //        return _plateWidth;
        //    }
        //    set
        //    {

        //    }
        //}
        //public double PlateLength
        //{
        //    get
        //    {
        //        return _plateLength;
        //    }
        //    set
        //    {

        //    }
        //}
        //public double OuterTubeDiameter
        //{
        //    get
        //    {
        //        return _outerTubeDiameter;
        //    }
        //    set
        //    {

        //    }
        //}
        //public double MountingHoleDiameter
        //{
        //    get
        //    {
        //        return _mountingHoleDiameter;
        //    }
        //    set
        //    {

        //    }
        //}
        //public double HoleHeight
        //{
        //    get
        //    {
        //        return _holeHeight;
        //    }
        //    set
        //    {

        //    }
        //}
        //public double SideWallHeight
        //{
        //    get
        //    {
        //        return _sideWallHeight;
        //    }
        //    set
        //    {

        //    }
        //}
    }
}
