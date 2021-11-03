using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bracket
{
    public class Parameter
    {
        private double _value;
        public double Max { get; set; }
        public double Min { get; set; }
        public double Value
        {
            get => _value;
            set
            {
                if (value < Min || value > Max)
                {
                    throw new ArgumentException($"{ParameterName} must be greater than {Min} mm and not greater than {Max} mm, it was {value} mm");
                }
                _value = value;
            }
        }
        public ParameterName Name { get; set; }
        public string ParameterName { get; set; }

        public Parameter(double value, double min, double max, ParameterName name, string parameterName)
        {
            Min = min;
            Max = max;
            Name = name;
            ParameterName = parameterName;
            Value = value;
        }
    }
}
