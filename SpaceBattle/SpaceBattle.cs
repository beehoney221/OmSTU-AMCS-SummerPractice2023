namespace SpaceBattle;
public class SpaceBattle
{
    public static double[] Position(double[] pos, double[] speed) 
    {
        if ((pos.Length == 0) | (speed.Length == 0))
            throw new Exception();
        else
        {
            double[] array = { pos[0] + speed[0], pos[1] + speed[1] };
            return array;
        }
    } 

    public static double[] GiveS(double a, double b)
    {
        if ((a == double.NaN) | (b == double.NaN)) 
        {
            double[] array = { };
            return array;
        }
        else
        {
            double[] array = { Convert.ToDouble(a), Convert.ToDouble(b) };
            return array;
        }
    }
}
