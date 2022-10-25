/*Duck newMallard = new MallardDuck();
Duck steamerDuck = new FuegianSteamerDuck();

newMallard.PerformFly();
steamerDuck.PerformQuack(); */

public abstract class Duck
{
    public IFlyBehaviour FlyBehaviour { get; set; }
    public IQuackBehaviour QuackBehaviour { get; set; }
    public void PerformFly()
    {
        FlyBehaviour.Fly();
    }
    public void PerformQuack()
    {
        QuackBehaviour.Quack();
    }

    public void Swim()
    {
        Console.WriteLine("All ducks can swim");
    }

}

public class MallardDuck : Duck
{
    public MallardDuck()
    {
        FlyBehaviour  =  new WingedFlyBehaviour();
        QuackBehaviour = new QuackLikeADuckBehaviour();
    }
}

public class FuegianSteamerDuck : Duck
{
    public FuegianSteamerDuck()
    {
        FlyBehaviour = new FlightlessFlyBehaviour();
        QuackBehaviour = new QuackLikeADuckBehaviour();
    }
}
public interface IQuackBehaviour
{
    public void Quack();
}

public interface IFlyBehaviour
{
    public void Fly();
}

public class WingedFlyBehaviour : IFlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("The duck flies with its wings.");
    }
}
public class FlightlessFlyBehaviour : IFlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("This duck does not fly");
    }
}

public class QuackLikeADuckBehaviour : IQuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine("The duck makes a quacking sound");
    }
}