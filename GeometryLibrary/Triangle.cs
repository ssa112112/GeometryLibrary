namespace GeometryLibrary
{
    public class Triangle : Shape
    {
        /// <summary>
        /// Limit the size of the side to the level at which we can easily calculate the area
        /// </summary>
        public const double MAX_SIDE_LENGTH = 1e10;

        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;
        private double? _area;
        private bool? _isRight;

        public Triangle(double sideA, double sideB, double sideC)
        {
            ThrowIfSideInvalide(sideA, nameof(sideA));
            ThrowIfSideInvalide(sideB, nameof(sideB));
            ThrowIfSideInvalide(sideC, nameof(sideC));

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;

            ThrowIfTriangleInvalide();
        }

        public double SideA => _sideA;
        public double SideB => _sideB;
        public double SideC => _sideC;

        public override double GetArea()
        {
            _area ??= CalculateArea();
            return _area.Value;
        }

        private double CalculateArea()
        {
            if (IsRight())
            {
                //Finding the legs and hypotenuse
                double a = _sideA;
                double b = _sideB;
                double c = _sideC;

                if (a > b && a > c)
                {
                    (a, c) = (c, a);
                }
                else if (b > a && b > c)
                {
                    (b, c) = (c, b);
                }

                //Right triangle area formula: 0.5 * legA * legB
                return 0.5 * a * b;
            }
            else
            {
                //Use Heron's formula to calculate the area of ​​the triangle
                double s = (_sideA + _sideB + _sideC) / 2;
                return Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
            }
        }

        /// <summary>
        /// Right triangle = прямоугольный треугольник
        /// </summary>
        /// <returns></returns>
        public bool IsRight()
        {
            _isRight ??= CalculateIsRight();
            return _isRight.Value;
        }

        private bool CalculateIsRight()
        {
            double a2 = _sideA * _sideA;
            double b2 = _sideB * _sideB;
            double c2 = _sideC * _sideC;

            // Check for Pythagorean theorem (allowing for floating point precision issues)
            return Math.Abs(a2 + b2 - c2) < 1e-10 || Math.Abs(a2 + c2 - b2) < 1e-10 || Math.Abs(b2 + c2 - a2) < 1e-10;
        }

        private void ThrowIfTriangleInvalide()
        {
            //In a triangle, the sum of any two sides must be greater than the third. Otherwise, two sides will simply “lie” on the third
            //and there will be no triangle. 

            if (_sideA + _sideB <= _sideC || _sideA + _sideC <= _sideB || _sideB + _sideC <= _sideA)
            {
                throw new ArgumentException($"Invalid triangle sides. The sum of any two sides must be greater than the third side." +
                    $"{nameof(SideA)} = {SideA}, {nameof(SideB)} = {SideB}, {nameof(SideC)} = {SideC}");
            };
        }

        private void ThrowIfSideInvalide(double side, string paramName)
        {
            if (side <= 0 || side > MAX_SIDE_LENGTH)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Side must be greater than zero and less than {MAX_SIDE_LENGTH}.");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Triangle other)
            {
                return this == other;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_sideA, _sideB, _sideC);
        }

        public override string ToString()
        {
            return $"Triangle (SideA: {_sideA}, SideB: {_sideB}, SideC: {_sideC})";
        }

        public static bool operator ==(Triangle t1, Triangle t2)
        {
            if (ReferenceEquals(t1, t2))
            {
                return true;
            }

            if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null))
            {
                return false;
            }

            return t1._sideA == t2._sideA && t1._sideB == t2._sideB && t1._sideC == t2._sideC;
        }

        public static bool operator !=(Triangle t1, Triangle t2)
        {
            return !(t1 == t2);
        }

    }

}