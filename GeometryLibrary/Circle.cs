namespace GeometryLibrary
{
    public class Circle : Shape
    {
        /// <summary>
        /// Limit the radius to the level at which we can easily calculate the area
        /// </summary>
        public const double MAX_RADIUS = 1e10; 
        private readonly double _radius;
        private double? _area;

        public Circle(double radius)
        {
            if (radius <= 0 || radius > MAX_RADIUS)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), $"Radius must be greater than zero and less than {MAX_RADIUS}.");
            }

            _radius = radius;
        }

        public double Radius => _radius;

        public override double GetArea()
        {
            //Circle area formula: π*r^2
            _area ??= Math.PI * _radius * _radius;
            return _area.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Circle other)
            {
                return this == other;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _radius.GetHashCode();
        }

        public override string ToString()
        {
            return $"Circle (Radius: {_radius})";
        }

        public static bool operator ==(Circle c1, Circle c2)
        {
            if (ReferenceEquals(c1, c2))
            {
                return true;
            }

            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false;
            }

            return c1._radius == c2._radius;
        }

        public static bool operator !=(Circle c1, Circle c2)
        {
            return !(c1 == c2);
        }
    }

}