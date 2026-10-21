using System;

namespace GeoAbstract
{
    public abstract class GeographicObject
    {
        public double X { get; }
        public double Y { get; }
        public string Name { get; }
        public string Description { get; }

        protected GeographicObject(double x, double y, string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва не може бути порожньою.");
            if (double.IsNaN(x) || double.IsInfinity(x) || double.IsNaN(y) || double.IsInfinity(y))
                throw new ArgumentException("Координати мають бути коректними числами.");

            X = x;
            Y = y;
            Name = name.Trim();
            Description = description?.Trim() ?? string.Empty;
        }

        public virtual string GetInfo()
        {
            return $"Назва: {Name}\nКоординати: X = {X}, Y = {Y}\nОпис: {Description}";
        }
    }
}