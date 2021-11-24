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
        private double _max;
        private double _min;
        private string _parameterName;
        public double Max 
        {
            get => _max; 
            set
            {
                if (value < Min)
                {
                    throw new ArgumentException($"Max value cannot be less than the Min");
                }
                if (value < 0)
                {
                    throw new ArgumentException($"Value must be greater than zero");
                }
                _max = value;   
            }
        }
        public double Min 
        { 
            get => _min;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Value must be greater than zero");
                }
                _min = value;
            }
        }
        public double Value
        {
            get => _value;
            set
            {
                if (value < Min || value > Max)
                {
                    throw new ArgumentException($"{_parameterName} must be greater than {Min} mm and not greater than " +
                        $"{Max} mm, it was {value} mm");
                }
                _value = value;
            }
        }
        public ParameterName Name { get; set; }

        public Parameter(double value, double min, double max, ParameterName name)
        {
            Min = min;
            Max = max;
            Name = name;
            _parameterName = System.Text.RegularExpressions.Regex.Replace(name.ToString(), "([a-z])([A-Z])", "$1 $2");
            Value = value;
        }

        public Parameter()
        {
        }
    }
}
