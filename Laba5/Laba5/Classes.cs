using System;

namespace Laba5
{
    public abstract class Inventory
    {
        public Inventory()
        {
            Name = "Unknown inventory item";
        }
        public Inventory(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public virtual void TakeInventoryItem()
        {
            Console.WriteLine("Inventory Item");
        }
        public abstract void SayHelloWorld();

    }
    
    public class Bench : Inventory,IHelloWorld
    {
        public Bench() 
        {
            Name = "Bench";
        }
        public Bench(string name) : base(name)
        {
        }
        
        public override void TakeInventoryItem()
        {
            Console.WriteLine("Bench");
        }

        public override void SayHelloWorld()
        {
            Console.WriteLine("Hello World(abstract)");
        }

        void IHelloWorld.SayHelloWorld()
        {
            Console.WriteLine("Hello World(Interface)"); 
        }

        public override string ToString()
        {
            return $"It's a bench name - {this.Name}";
        }
    }

    public class Bars : Inventory
    {
        public Bars() 
        {
            Name = "Bars";
        }
        public Bars(string name) : base(name)
        {
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
            return $"It's a bars name - {this.Name}";
        }

    }       

    public class Mats : Inventory
    {
        public Mats()
        {
            Name = "Mats";
        }
        public Mats(string name) : base(name)
        {
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
            return $"It's a mats name - {this.Name}";
        }

    }
    public class Ball : Inventory
    {
        public Ball()
        {
            Name = "Ball";
        }

        public Ball(string name) : base(name)
        {
            
        }


        public BallType Type { get; protected init; } = BallType.Default;

        public override void TakeInventoryItem()
        {
            Console.WriteLine("You have taken a Ball");
        }

        public override void SayHelloWorld()
        {
            Console.WriteLine("Hello world from ball");
        }

        public override string ToString()
        {
            return $"There is a Ball name - {this.Name}, type - {this.Type}";
        }
    }

    public class BasketballBall : Ball
    {
        public BasketballBall()
        {
            Name = "Default";
            Type = BallType.Baseball;
        }

        public BasketballBall(string name)
        {
            Name = name;
            Type = BallType.Baseball;
        }
        public override string ToString()
        {
            return $"There is a Ball name - {this.Name}, type - {this.Type}";
        }
    }

    public sealed class TennisBall : Ball,ITennis
    {
        public TennisBall()
        {
            Name = "Default";
            Type = BallType.Tennisball;
        }

        public TennisBall(string name)
        {
            Name = name;
            Type = BallType.Tennisball;
        }
        
        public void WriteItForTennis()
        {
            Console.WriteLine("It's for tennis");
        }
        public override string ToString()
        {
            return $"There is a Ball name - {this.Name}, type - {this.Type}";
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