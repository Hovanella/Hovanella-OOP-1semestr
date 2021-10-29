using System;
using System.Xml.Serialization;

namespace Laba14
{
    [Serializable]
    public abstract class Inventory
    {
        
        public string Name { get; set; }
        
        public virtual void TakeInventoryItem()
        {
            Console.WriteLine("Inventory Item");
        }
        public abstract void SayHelloWorld();

    }
    
    [Serializable]
    public class Bench : Inventory,IHelloWorld
    {
        public Bench() 
        {
            Name = "Bench";
        }
        public Bench(string name)
        {
            Name = name;
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
            return $"It's a {this.GetType()} name - {this.Name}";
        }
    }

    public class Bars : Inventory
    {
        public Bars() 
        {
            Name = "Bars";
        }
        public Bars(string name)
        {
            Name = name;
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
            return $"It's a {this.GetType()} name - {this.Name}";
        }

    }       
    [Serializable]
    public class Mats : Inventory
    {
        public Mats()
        {
            Name = "Mats";
        }
        public Mats(string name)
        {
            Name = name;
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
            return $"It's a {GetType()} name - {this.Name}";
        }

    }
    [Serializable]
    public class Ball : Inventory
    {
        public Ball()
        {
            Name = "Ball";
        }
        
        public Ball(string name)
        {
            Name = name;
        }

       [NonSerialized]
        public int FieldToBeNotSeriazable = 666;
            
        public BallType Type { get; set; } = BallType.Default;

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
            return $"There is a {GetType()} name - {this.Name}, type - {this.Type}";
        }
    }

    public class BasketballBall : Ball
    {
        public BasketballBall()
        {
            Name = "Default";
            Type = BallType.Basketball;
        }

        public BasketballBall(string name)
        {
            Name = name;
            Type = BallType.Basketball;
        }
        public override string ToString()
        {
            return $"It's a {GetType()} name - {this.Name}, type - {this.Type}";
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
            return $"There is a {GetType()} name - {this.Name}, type - {this.Type}";
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