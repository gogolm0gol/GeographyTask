using System;

namespace GeoAbstract
{
    public class River : GeographicObject
    {
        public double FlowSpeed { get; }   
        public double Length { get; }      

        public River(double x, double y, string name, string description,
                     double flowSpeed, double length)
            : base(x, y, name, description)
        {
            if (flowSpeed <= 0)
                throw new ArgumentException("Швидкість течії має бути більшою за нуль.");
            if (length <= 0)
                throw new ArgumentException("Довжина має бути більшою за нуль.");

            FlowSpeed = flowSpeed;
            Length = length;
        }

        public override string GetInfo()
        {
            return "Тип: Річка\n" + base.GetInfo() +
                   $"\nШвидкість течії: {FlowSpeed} см/с\nЗагальна довжина: {Length} км";
        }
    }
}