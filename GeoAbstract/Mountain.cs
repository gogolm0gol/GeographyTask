using System;

namespace GeoAbstract
{
    public class Mountain : GeographicObject
    {
        public double HighestPoint { get; }

        public Mountain(double x, double y, string name, string description,
                        double highestPoint)
            : base(x, y, name, description)
        {
            if (highestPoint <= 0)
                throw new ArgumentException("Найвища точка має бути більшою за нуль.");

            HighestPoint = highestPoint;
        }

        public override string GetInfo()
        {
            return "Тип: Гора\n" + base.GetInfo() +
                   $"\nНайвища точка: {HighestPoint} м";
        }
    }
}