namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-9;
        if (Math.Abs(a) < eps) 
        {
            throw new System.ArgumentException();
        }
        else if (double.IsNaN(a) | double.IsNaN(b) | double.IsNaN(c)) 
        {
            throw new ArgumentException();
        }
        else if (double.IsPositiveInfinity(a) | double.IsPositiveInfinity(b) | double.IsPositiveInfinity(c)) 
        {
            throw new ArgumentException();
        }
        else if (double.IsNegativeInfinity(a) | double.IsNegativeInfinity(b) | double.IsNegativeInfinity(c)) 
        {
            throw new ArgumentException();
        }
        else 
        {
            double d = b * b - (4 * a * c);
            double x1, x2;
            if (d >= eps)
            {
                if (b != 0) x1 = - (b + Math.Sign(b) * Math.Sqrt(d)) / 2;
                else x1 = - Math.Sqrt(d) / 2;
                x2 = c / x1;
                double[] array = { x1, x2 };
                return array;
            }            
            else if (Math.Abs(d) < eps) 
            {   
                x1 = - (b + Math.Sign(b) * Math.Sqrt(d)) / 2;
                double[] array = { x1 };
                return array;
            }
            else
            {
                double[] array = {};
                return array;
            }
        }
    }
}
