using System;

namespace Bracket
{
    /// <summary>
    /// Класс параметр.
    /// </summary>
    public class Parameter : IEquatable<Parameter>
    {
        /// <summary>
        /// Поле текущего значения.
        /// </summary>
        private double _value;
        /// <summary>
        /// Поле максимального значения.
        /// </summary>
        private double _max;
        /// <summary>
        /// Поле минимального значения.
        /// </summary>
        private double _min;
        /// <summary>
        /// Имя параметра.
        /// </summary>
        private ParameterName _name;
        /// <summary>
        /// Имя параметра в виде строки.
        /// </summary>
        private string _parameterName;

        /// <summary>
        /// Максимальное значение.
        /// </summary>
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

        /// <summary>
        /// Минимальное значение.
        /// </summary>
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
        /// <summary>
        /// Текущее значение.
        /// </summary>
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
        /// <summary>
        /// Имя параметра.
        /// </summary>
        public ParameterName Name
        {
            get => _name;
            set
            {
                _name = value;
                _parameterName = System.Text.RegularExpressions.Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1 $2");
            }
        }

        /// <summary>
        /// Имя параметра в виде строки.
        /// </summary>
        public string ParameterName { get => _parameterName; }

        /// <summary>
        /// Конструктор параметра.
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="name">Имя параметра</param>
        public Parameter(double value, double min, double max, ParameterName name)
        {
            Min = min;
            Max = max;
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Конструктор для Юнит-тестов.
        /// </summary>
        public Parameter()
        {
        }

        /// <summary>
        /// Сравнение двух параметров.
        /// </summary>
        /// <param name="other">Сравниваемый параметр</param>
        /// <returns></returns>
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
