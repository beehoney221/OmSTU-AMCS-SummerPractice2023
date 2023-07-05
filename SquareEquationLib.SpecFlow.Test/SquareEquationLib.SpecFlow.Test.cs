namespace SquareEquationLib.SpecFlow.Test;
using SquareEquationLib;
using TechTalk.SpecFlow;

[Binding]
public class StepDefinitions
{
    private double[] coef = new double [3];
    private double[] ans = new double [0];
    private Exception ex = new Exception();

    [When("вычисляются корни квадратного уравнения")]
    public void CalculatedRoots()
    {
        try 
        {
            ans = SquareEquation.Solve(coef[0], coef[1], coef[2]);
        }
        catch (Exception except)
        {
            ex = except;
        }

    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void EquationCoef(string A, string B, string C)
    {
        string[] str_coef = {A, B, C};
        for (int i = 0; i < str_coef.Length; i++)
        {
            if (str_coef[i] == "Double.PositiveInfinity") 
                coef[i] = double.PositiveInfinity;
            else if (str_coef[i] == "Double.NegativeInfinity") 
                coef[i] = double.NegativeInfinity;
            else if (str_coef[i] == "NaN") 
                coef[i] = double.NaN;
            else 
                coef[i] = Convert.ToDouble(str_coef[i]);
        }
    }

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
    public void EquationHasTwoRoots(double x1, double x2)
    {
        double[] cor_ans = { x1, x2 };
        Array.Sort(ans);
        Array.Sort(cor_ans);

        for (int i = 0; i < cor_ans.Length; i++)
        {
            Assert.Equal(cor_ans[i], ans[i], 10);
        }
    }

    [Then("квадратное уравнение имеет один корень (.*) кратности два")]
    public void EquationHasOneRoot(double x)
    {
        double[] cor_ans = { x };

        Assert.Equal(cor_ans, ans);
    }

    [Then("множество корней квадратного уравнения пустое")]
    public void EquationHasNotRoots()
    {
        double[] cor_ans = { };

        Assert.Equal(cor_ans, ans);
    }

    [Then("выбрасывается исключение ArgumentException")]
    public void ThrowingArgumentException()
    {
        Assert.ThrowsAsync<ArgumentException>(() => throw ex);
    }
}