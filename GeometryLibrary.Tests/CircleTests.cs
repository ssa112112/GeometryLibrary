using System;
using NUnit.Framework;
using GeometryLibrary;

namespace GeometryLibrary.Tests
{
    //Convenient external triangle calculator https://www.calculator.net/circle-calculator.html
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void Constructor_ValidRadius_ShouldSetRadius()
        {
            // Arrange
            double radius = 5;

            // Act
            var circle = new Circle(radius);

            // Assert
            Assert.AreEqual(radius, circle.Radius);
        }

        [Test]
        public void Constructor_RadiusZero_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            double radius = 0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }

        [Test]
        public void Constructor_NegativeRadius_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            double radius = -5;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }

        [Test]
        public void Constructor_RadiusExceedsMax_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            double radius = Circle.MAX_RADIUS + 1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }

        [TestCase(1, 3.14159)]
        [TestCase(3, 28.27433)]
        [TestCase(0.5, 0.7854)]
        [TestCase(1999999999, 1.25663706017928e+19)]
        [TestCase(9999999999, 3.1415926529614748e+20)]
        public void GetArea_ValidRadius_ShouldReturnCorrectArea(double radius, double expectedArea)
        {
            // Arrange
            var circle = new Circle(radius);

            // Act
            double area = circle.GetArea();

            //Todo: вынести куда-нибудь 0.0001
            // Assert
            Assert.AreEqual(expectedArea, area, 0.0001);
        }

        [Test]
        public void Equals_SameRadius_ShouldReturnTrue()
        {
            // Arrange
            var circle1 = new Circle(5);
            var circle2 = new Circle(5);

            // Act & Assert
            Assert.IsTrue(circle1.Equals(circle2));
        }

        [Test]
        public void Equals_DifferentRadius_ShouldReturnFalse()
        {
            // Arrange
            var circle1 = new Circle(5);
            var circle2 = new Circle(10);

            // Act & Assert
            Assert.IsFalse(circle1.Equals(circle2));
        }

        [Test]
        public void GetHashCode_SameRadius_ShouldReturnSameHashCode()
        {
            // Arrange
            var circle1 = new Circle(5);
            var circle2 = new Circle(5);

            // Act & Assert
            Assert.AreEqual(circle1.GetHashCode(), circle2.GetHashCode());
        }

        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var circle = new Circle(5);
            string expectedString = "Circle (Radius: 5)";

            // Act
            string result = circle.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }

        [Test]
        public void OperatorEquals_SameRadius_ShouldReturnTrue()
        {
            // Arrange
            var circle1 = new Circle(5);
            var circle2 = new Circle(5);

            // Act & Assert
            Assert.IsTrue(circle1 == circle2);
        }

        [Test]
        public void OperatorEquals_SameCircle_ShouldReturnTrue()
        {
            // Arrange
            var circle = new Circle(0.1);

            // Act & Assert
            Assert.IsTrue(circle == circle);
        }

        [Test]
        public void OperatorNotEquals_DifferentRadius_ShouldReturnTrue()
        {
            // Arrange
            var circle1 = new Circle(5);
            var circle2 = new Circle(10);

            // Act & Assert
            Assert.IsTrue(circle1 != circle2);
        }
    }
}
