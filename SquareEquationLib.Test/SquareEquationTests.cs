using Xunit;
using SquareEquationLib;

namespace Square.UnitTests.Equation
{
    public class SquareEquationTests
    {
        [Fact]
        public void Solve_Null()
        {
            double[] t_a = {  };
            double[] array = SquareEquation.Solve(1, 0, 9);

            Assert.Equal(t_a, array);
        }

        [Fact]
        public void Solve_One()
        {
            double[] t_a = { -2 };
            double[] array = SquareEquation.Solve(1, 4, 4);

            Assert.Equal(t_a, array);
        }

        [Fact]
        public void Solve_TwoB()
        {
            double[] t_a = { -8, 1 };
            double[] array = SquareEquation.Solve(1, 7, -8);
            
            Assert.Equal(t_a, array);
        }

        [Fact]
        public void Solve_Two()
        {
            double[] t_a = { (-1) * Math.Sqrt(7), Math.Sqrt(7) };
            double[] array = SquareEquation.Solve(1, 0, -7);
            
            for (int i = 0; i < t_a.Length; i++)
            {
                Assert.Equal(t_a[i], array[i], 10);
            }
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
