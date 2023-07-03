using Xunit;
using SquareEquationLib;

namespace Square.UnitTests.Equation
{
    public class SquareEquationTests
    {
        [Fact]
        public void Solve_Null()
        {
            bool result = false;
            double[] array = SquareEquation.Solve(1, 0, 9);

            if (array.Length == 0)
            {
                result = true;
            }
            Assert.True(result, "Correctly");
        }

        [Fact]
        public void Solve_One()
        {
            bool result = false;
            double[] t_a = { -2 };
            double[] array = SquareEquation.Solve(1, 4, 4);
            
            if ((Math.Abs(array[0] - t_a[0]) < 1e-9) & (array.Length == 1))
            {
                result = true;
            }
            Assert.True(result, "Correctly");
        }

        [Fact]
        public void Solve_TwoB()
        {
            bool result = false;
            double[] t_a = { -8, 1 };
            double[] array = SquareEquation.Solve(1, 7, -8);
            
            if ((Math.Abs(array[0] - t_a[0]) < 1e-9) & (Math.Abs(array[1] - t_a[1]) < 1e-9))
            {
                result = true;
            }
            Assert.True(result, "Correctly");
        }

        [Fact]
        public void Solve_Two()
        {
            bool result = false;
            double[] t_a = { (-1) * Math.Sqrt(7), Math.Sqrt(7) };
            double[] array = SquareEquation.Solve(1, 0, -7);
            
            if ((Math.Abs(array[0] - t_a[0]) < 1e-9) & (Math.Abs(array[1] - t_a[1]) < 1e-9))
            {
                result = true;
            }
            Assert.True(result, "Correctly");
        }

        [Theory]
        [InlineData(double.NaN, 2, 37)]
        [InlineData(10, double.NaN, 999.58)]
        [InlineData(1, 55, double.NaN)]
        [InlineData(double.PositiveInfinity, 8, 763)]
        [InlineData(2, double.PositiveInfinity, 985.3)]
        [InlineData(32, 4580.2, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, 5, 7)]
        [InlineData(7, double.NegativeInfinity, 83)]
        [InlineData(65, 4.22222, double.NegativeInfinity)]
        [InlineData(0, 2, 37)]
        public void Solve_Exc(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
        }
    }
}