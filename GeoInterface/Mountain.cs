using System;

namespace GeoInterface
{
    public class Mountain : IGeographicObject
    {
        public double X { get; }
        public double Y { get; }
        public string Name { get; }
        public string Description { get; }
        public double HighestPoint { get; }   

        public Mountain(double x, double y, string name, string description,
                        double highestPoint)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва не може бути порожньою.");
            if (double.IsNaN(x) || double.IsInfinity(x) || double.IsNaN(y) || double.IsInfinity(y))
                throw new ArgumentException("Координати мають бути коректними числами.");
            if (highestPoint <= 0)
                throw new ArgumentException("Найвища точка має бути більшою за нуль.");

            X = x;
            Y = y;
            Name = name.Trim();
            Description = description?.Trim() ?? string.Empty;
            HighestPoint = highestPoint;
        }

        public string GetInfo()
        {
            return $"Тип: Гора\nНазва: {Name}\nКоординати: X = {X}, Y = {Y}\nОпис: {Description}" +
                   $"\nНайвища точка: {HighestPoint} м";
        }
    }
}