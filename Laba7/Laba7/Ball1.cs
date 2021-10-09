using System;
using Laba7.Exceptions;

namespace Laba7
{
    public partial class Ball : Inventory
    {
        public Ball()
        {
            Name = "Ball";
        }

        public Ball(string name, int cost)
        {
            if (cost > 6666)
                throw new BallException("Ball should be cost less than 6666", "Ball");
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
            throw new InvalidOperationException("Ball can't talk");
            Console.WriteLine("Hello world from ball");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name}, type - {Type} cost - {Cost}";
        }
    }
}