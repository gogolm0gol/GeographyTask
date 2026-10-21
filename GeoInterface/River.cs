using System;

namespace GeoInterface
{
    public class River : IGeographicObject
    {
        public double X { get; }
        public double Y { get; }
        public string Name { get; }
        public string Description { get; }
        public double FlowSpeed { get; }  
        public double Length { get; }      

        public River(double x, double y, string name, string description,
                     double flowSpeed, double length)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва не може бути порожньою.");
            if (double.IsNaN(x) || double.IsInfinity(x) || double.IsNaN(y) || double.IsInfinity(y))
                throw new ArgumentException("Координати мають бути коректними числами.");
            if (flowSpeed <= 0)
                throw new ArgumentException("Швидкість течії має бути більшою за нуль.");
            if (length <= 0)
                throw new ArgumentException("Довжина має бути більшою за нуль.");

            X = x;
            Y = y;
            Name = name.Trim();
            Description = description?.Trim() ?? string.Empty;
            FlowSpeed = flowSpeed;
            Length = length;
        }

        public string GetInfo()
        {
            return $"Тип: Річка\nНазва: {Name}\nКоординати: X = {X}, Y = {Y}\nОпис: {Description}" +
                   $"\nШвидкість течії: {FlowSpeed} см/с\nЗагальна довжина: {Length} км";
        }
    }
}