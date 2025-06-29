using NUnit.Framework;
using System;

namespace NUNIT
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            // Initialize before each test
            _calculator = new Calculator();
            Console.WriteLine("Calculator initialized for test");
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup after each test
            _calculator = null;
            Console.WriteLine("Calculator cleanup completed");
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            // Arrange
            int a = 5, b = 3;
            int expected = 8;

            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2, 3, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, 1, 0)]
        [TestCase(10, -5, 5)]
        [TestCase(-3, -7, -10)]
        [TestCase(100, 25, 125)]
        public void Add_WithTestCases_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            // Arrange
            int a = 10, b = 4;
            int expected = 6;

            // Act
            int result = _calculator.Subtract(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 3, 7)]
        [TestCase(0, 5, -5)]
        [TestCase(-2, -8, 6)]
        public void Subtract_WithTestCases_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Act
            int result = _calculator.Subtract(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("Multiplication test temporarily disabled for demonstration")]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            // Arrange
            int a = 4, b = 5;
            int expected = 20;

            // Act
            int result = _calculator.Multiply(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(3, 4, 12)]
        [TestCase(-2, 5, -10)]
        [TestCase(0, 10, 0)]
        public void Multiply_WithTestCases_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Act
            int result = _calculator.Multiply(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            // Arrange
            int a = 15, b = 3;
            int expected = 5;

            // Act
            int result = _calculator.Divide(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(20, 4, 5)]
        [TestCase(100, 10, 10)]
        [TestCase(-15, 3, -5)]
        public void Divide_WithTestCases_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Act
            int result = _calculator.Divide(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            // Arrange & Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [Test]
        public void Square_PositiveNumber_ReturnsSquare()
        {
            // Arrange
            double number = 4.0;
            double expected = 16.0;

            // Act
            double result = _calculator.Square(number);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SquareRoot_PositiveNumber_ReturnsSquareRoot()
        {
            // Arrange
            double number = 16.0;
            double expected = 4.0;

            // Act
            double result = _calculator.SquareRoot(number);

            // Assert
            Assert.That(result, Is.EqualTo(expected).Within(0.001));
        }

        [Test]
        public void SquareRoot_NegativeNumber_ThrowsException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(-4));
        }
    }
}
