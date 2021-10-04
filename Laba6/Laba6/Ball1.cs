using System;

namespace Laba6
{
    public partial class Ball : Inventory
    {
        public Ball()
        {
            Name = "Ball";
        }

        public Ball(string name, int cost)
        {
            Name = name;
            Cost = cost;
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
            return $"It's a {GetType()} name - {Name}, type - {Type} cost - {Cost}";
        }
    }
}