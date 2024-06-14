using System;
using NUnit.Framework;
using GeometryLibrary;

namespace GeometryLibrary.Tests
{
    //Convenient external triangle calculator https://www.calculator.net/triangle-calculator.html
    [TestFixture]
    public class TriangleTests
    {

        [Test]
        public void Constructor_ValidSides_ShouldSetSides()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;

            // Act
            var triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual(sideA, triangle.SideA);
            Assert.AreEqual(sideB, triangle.SideB);
            Assert.AreEqual(sideC, triangle.SideC);
        }

        [TestCase(-1, 1, 2)] 
        [TestCase(1, -1, 2)] 
        [TestCase(1, 2, -1)]
        [TestCase(0, 1, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(1, 2, 0)]
        [TestCase(1, 2, 0)]
        [TestCase(Triangle.MAX_SIDE_LENGTH + 1, 2, 1)]
        [TestCase(1, Triangle.MAX_SIDE_LENGTH + 1, 2)]
        [TestCase(1, 2, Triangle.MAX_SIDE_LENGTH + 1)]
        public void Constructor_InvalidSide_ShouldThrowArgumentOutOfRangeException(double sideA, double sideB, double sideC)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideA, sideB, sideC));
        }

        [TestCase(1, 1, 3)]
        [TestCase(1, 3, 1)]
        [TestCase(3, 1, 1)]
        public void Constructor_InvalidTriangle_ShouldThrowArgumentException(double sideA, double sideB, double sideC)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [TestCase(3, 4, 5, 6)] // Right triangle
        [TestCase(6, 8, 10, 24)] // Right triangle, bigest side is C, smallest A
        [TestCase(8, 6, 10, 24)] // Right triangle, bigest side is C, smallest B
        [TestCase(6, 10, 8, 24)] // Right triangle, bigest side is B, smallest A
        [TestCase(8, 10, 6, 24)] // Right triangle, bigest side is B, smallest C
        [TestCase(10, 8, 6, 24)] // Right triangle, bigest side is A, smallest C
        [TestCase(10, 6, 8, 24)] // Right triangle, bigest side is A, smallest B
        [TestCase(7, 10, 5, 16.248)] // Usual triangle
        [TestCase(5, 5, 6, 12)] // Isosceles triangle
        [TestCase(9999999999, 9999999999, 9999999999, 4.3301270180561682e+19)] //Big triangle
        public void GetArea_ValidSides_ShouldReturnCorrectArea(double sideA, double sideB, double sideC, double expectedArea)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            double area = triangle.GetArea();

            //Todo: вынести куда-нибудь 0.0001
            // Assert
            Assert.AreEqual(expectedArea, area, 0.0001);
        }

        [TestCase(3, 4, 5, true)]
        [TestCase(6, 8, 10, true)]
        [TestCase(7, 10, 5, false)]
        [TestCase(5, 5, 6, false)]
        public void IsRight_ValidSides_ShouldReturnCorrectResult(double sideA, double sideB, double sideC, bool expectedResult)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isRight = triangle.IsRight();

            // Assert
            Assert.AreEqual(expectedResult, isRight);
        }

        [Test]
        public void Equals_SameSides_ShouldReturnTrue()
        {
            // Arrange
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(3, 4, 5);

            // Act & Assert
            Assert.IsTrue(triangle1.Equals(triangle2));
        }

        [Test]
        public void Equals_DifferentSides_ShouldReturnFalse()
        {
            // Arrange
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(6, 8, 10);

            // Act & Assert
            Assert.IsFalse(triangle1.Equals(triangle2));
        }

        [Test]
        public void GetHashCode_SameSides_ShouldReturnSameHashCode()
        {
            // Arrange
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(3, 4, 5);

            // Act & Assert
            Assert.AreEqual(triangle1.GetHashCode(), triangle2.GetHashCode());
        }

        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);
            string expectedString = "Triangle (SideA: 3, SideB: 4, SideC: 5)";

            // Act
            string result = triangle.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }

        [Test]
        public void OperatorEquals_SameSides_ShouldReturnTrue()
        {
            // Arrange
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(3, 4, 5);

            // Act & Assert
            Assert.IsTrue(triangle1 == triangle2);
        }


        [Test]
        public void OperatorEquals_SameTriangle_ShouldReturnTrue()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);

            // Act & Assert
            Assert.IsTrue(triangle == triangle);
        }


        [Test]
        public void OperatorNotEquals_DifferentSides_ShouldReturnTrue()
        {
            // Arrange
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(6, 8, 10);

            // Act & Assert
            Assert.IsTrue(triangle1 != triangle2);
        }
    }
}
