using System;

namespace Laba6
{
    public abstract class Inventory
    {
        public Inventory()
        {
            Cost = 300;
        }

        public string Name { get; set; }
        public int Cost { get; set; }

        public virtual void TakeInventoryItem()
        {
            Console.WriteLine("Inventory Item");
        }

        public abstract void SayHelloWorld();
    }

    public class Bench : Inventory, IHelloWorld
    {
        public Bench()
        {
            Name = "Bench";
        }

        public Bench(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        void IHelloWorld.SayHelloWorld()
        {
            Console.WriteLine("Hello World(Interface)");
        }

        public override void TakeInventoryItem()
        {
            Console.WriteLine("Bench");
        }

        public override void SayHelloWorld()
        {
            Console.WriteLine("Hello World(abstract)");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name} cost - {Cost}";
        }
    }

    public class Bars : Inventory
    {
        public Bars()
        {
            Name = "Bars";
        }

        public Bars(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public override void TakeInventoryItem()
        {
            Console.WriteLine("Bench");
        }

        public override void SayHelloWorld()
        {
            Console.WriteLine("Hello World from Bars");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name} cost - {Cost}";
        }
    }

    public class Mats : Inventory
    {
        public Mats()
        {
            Name = "Mats";
        }

        public Mats(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public override void TakeInventoryItem()
        {
            Console.WriteLine("The item is mats");
        }

        public override void SayHelloWorld()
        {
            Console.WriteLine("Hello World from mats ");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name} cost - {Cost}";
        }

        private struct UnnecessaryStruct
        {
            private int unnecessaryInt;

            public void SaySomethingUnnecessary()
            {
                Console.WriteLine("Bruh");
            }
        } //<-- добавил бессмысленную структу для класса
    }

    public class BasketballBall : Ball
    {
        public BasketballBall()
        {
            Name = "Default";
            Type = BallType.Basketball;
        }

        public BasketballBall(string name, int cost)
        {
            Name = name;
            Cost = cost;
            Type = BallType.Basketball;
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name}, type - {Type} cost - {Cost}";
        }
    }

    public sealed class TennisBall : Ball, ITennis
    {
        public TennisBall()
        {
            Name = "Default";
            Type = BallType.Tennisball;
        }

        public TennisBall(string name, int cost)
        {
            Name = name;
            Cost = cost;
            Type = BallType.Tennisball;
        }

        public void WriteItForTennis()
        {
            Console.WriteLine("It's for tennis");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name}, type - {Type}, cost - {Cost}";
        }

        public override bool Equals(object? obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return new Random().Next(0, 100000000);
        }
    }
}