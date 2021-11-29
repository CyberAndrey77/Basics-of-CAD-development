using System;

namespace Bracket
{
    public class Parameter : IEquatable<Parameter>
    {
        private double _value;
        private double _max;
        private double _min;
        private ParameterName _name;
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
        public ParameterName Name
        {
            get => _name;
            set
            {
                _name = value;
                _parameterName = System.Text.RegularExpressions.Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1 $2");
            }
        }

        public string ParameterName { get => _parameterName; }

        public Parameter(double value, double min, double max, ParameterName name)
        {
            Min = min;
            Max = max;
            Name = name;
            Value = value;
        }

        public Parameter()
        {
        }

        public bool Equals(Parameter other)
        {
            return _max == other._max
                && _min == other._min
                && _name == other._name
                && _parameterName == other._parameterName
                && _value == other._value;
        }
    }
}
