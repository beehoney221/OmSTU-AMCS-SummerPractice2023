namespace SpaceBattleTest;
using SpaceBattle;
using TechTalk.SpecFlow;

[Binding]
public class StepDefinitions
{
    private double[] ans = new double [0];
    private double[] ship = new double[0];
    private double[] speed = new double[0];
    private Exception ex = new Exception();

    [When("происходит прямолинейное равномерное движение без деформации")]
    public void Move()
    {
        try 
        {
            ans = SpaceBattle.Position(ship, speed);
        }
        catch (Exception except)
        {
            ex = except;
        }
    }

    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void IsSheep(double a, double b)
    {
        ship = SpaceBattle.GiveS(a, b);
    }

    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void IsSpeed(double a, double b)
    {
        speed = SpaceBattle.GiveS(a, b);
    }

    [Given("космический корабль, положение в пространстве которого невозможно определить")]
    public void NoShip()
    {
        ship = SpaceBattle.GiveS(double.NaN, double.NaN);
    }

    [Given("скорость корабля определить невозможно")]
    public void NoSpeed()
    {
        speed = SpaceBattle.GiveS(double.NaN, double.NaN);
    }

    [Given("изменить положение в пространстве космического корабля невозможно")]
    public void NoMove()
    {
        ship = SpaceBattle.GiveS(double.NaN, double.NaN);
        speed = SpaceBattle.GiveS(double.NaN, double.NaN);
    }

    [Then("возникает ошибка Exception")]
    public void ThrowingArgumentException()
    {
        Assert.ThrowsAsync<ArgumentException>(() => throw ex);
    }
    
    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void ShipMove(double a, double b)
    {
        double[] cor_ans = { a, b };
        Assert.Equal(cor_ans, ans);
    }
}