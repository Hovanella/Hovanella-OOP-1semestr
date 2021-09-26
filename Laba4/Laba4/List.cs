using System;

namespace Laba4
{
    public class List
    { 
        //класс элемента списка 
        public class ListNode
        {
            public string Data { get; set; } 
            public ListNode Next { get; set; }
        }
        public class Owner
        {
            private readonly int _ownerID;
            
            public string Name { get; set; }
            public string Organisation { get; set; }

            public Owner(string name,string organisation)
            {
                _ownerID = GetHashCode();
                Name = name;
                Organisation = organisation;
            }
            
        }
        public class Date
        {
            public string CreationDate { get; private set; }

            public Date()
            {
                CreationDate = DateTime.Now.ToString();
            }
        }
        
      
        private int _count;
        
        public Owner ListOwner { get; init; }
        public Date ListDate { get; private set; }
        public ListNode Head { get; private set; }
        public ListNode Tail { get; private set; }

        //конструкторы
        public List(string data)
        {
            Head = Tail = new ListNode(); 
            Head.Data = data;
            Tail.Data = data;
            _count = 1;

            ListDate = new Date();
        }
        public List()
        {
            Head = Tail = new ListNode();
            _count = 0;
            ListDate = new Date();
        }
        
        //методы
        public void Add(string data)
        {
            var newNode = new ListNode
            {
                Data = data
            };

            if (_count == 0)
            {
                Tail = Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            _count++;
        }
        
        public void Remove(string data)
        {
            if (_count == 0)
                throw new InvalidOperationException();
            
            ListNode current = Head;
            ListNode previous = null;

            while (current!=null)
            {
                if (current.Data == data)
                {
                    _count--;
                    if (previous == null)
                    {
                        Head = Head.Next;
                        if (Head == null)
                        {
                            Tail = null;
                        }
                        return;
                    }

                    previous.Next = current.Next;

                    if (current.Next == null)
                        Tail = previous;
                    
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public void Show()
        {
            if (_count == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            if (_count == 1)
            {
                Console.WriteLine($"(HEAD){Head.Data}(TAIL)-->NULL");
                return;
            }

            ListNode current = Head;

            Console.Write($"{current.Data}(HEAD)-->");

            current = current.Next;

            while (current.Next!=null)
            {
                Console.Write($"{current.Data}-->");
                current = current.Next;
            }
            Console.WriteLine($"{current.Data}(TAIL)-->NULL");


        }

        public void Clear()
        {
            Head = Tail = new ListNode();
            _count = 0;
        }
        
        //Перегрузки операторов

        public static List operator +(List a, List b)
        {
            List newList = new List();

            if (a._count>0){
                var current = a.Head;
                while (current != null)
                {
                    newList.Add(current.Data);
                    current = current.Next;
                }
            }
            if (b._count>0){
                var current = b.Head;
                while (current != null)
                {
                    newList.Add(current.Data);
                    current = current.Next;
                }
            }
            
            return newList;
        }
        
        public static List operator !(List a)
        {
            if (a._count <= 0) return a;
            
            var newList = new List();
            var temporary = new string[a._count];
            var counter = a._count-1;
            var current = a.Head;
            
            while (current != null)
            {
                temporary[counter] = current.Data;
                counter--;
                current = current.Next;
            }
            
            foreach (string item in temporary)
            {
                newList.Add(item);
            }
            
            return newList;
        }

        public static bool operator ==(List a, List b)
        {
            if (a._count != b._count)
                return false;

            var currentFirst = a.Head;
            var currentSecond = b.Head;
            while (currentFirst != null)
            {
                if (currentFirst.Data != currentSecond.Data)
                    return false;
                currentFirst = currentFirst.Next;
                currentSecond = currentSecond.Next;
            }

            return true;
        }

        public static bool operator !=(List a, List b)
        {
            return !(a == b);
        }

        public static List operator <(List a, List b)
        {
            return (a + b);
        }
        
        public static List operator >(List a, List b)
        {
            return (b + a);
        }
    }
}