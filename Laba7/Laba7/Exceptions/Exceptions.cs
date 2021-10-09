using System;

namespace Laba7.Exceptions
{
    
    /*Создать иерархию классов исключений (собственных)–3 типа и более.Сделать  наследование  пользовательских  типов  исключений  от стандартных классов .Net(например,Exception,IndexOutofRange).*/
    public class InventoryException : Exception
    {
        public InventoryException(string message, string errorClass) : base(message)
        {
            ErrorClass = errorClass;
        }

        public string ErrorClass { get; }
    }

    public class BallException : InventoryException
    {
        public BallException(string message, string errorClass) : base(message, "Ball")
        {
        }

        public BallType BallType { get; private set; }
    }

    public class CostExeption : InventoryException
    {
        public CostExeption(string message, string errorClass, int cost) : base(message, errorClass)
        {
            Cost = cost;
        }

        public int Cost { get; }
    }
}