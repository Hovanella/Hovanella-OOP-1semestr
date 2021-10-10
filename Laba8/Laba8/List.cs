using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laba8
{
    public class List<T>:IGeneric<T>
    { 
        //класс элемента списка 
        public class ListNode<T>    
        {
            public T Data { get; set; } 
            public ListNode<T>Next { get; set; }
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
        public ListNode<T> Head { get; private set; }
        public ListNode<T> Tail { get; private set; }

        //конструкторы
        public List(T data)
        {
            Head = Tail = new ListNode<T>(); 
            Head.Data = data;
            Tail.Data = data;
            _count = 1;

            ListDate = new Date();
        }
        public List()
        {
            Head = Tail = new ListNode<T>();
            _count = 0;
            ListDate = new Date();
        }
        
        //методы
        public void Add(T data)
        {
            var newNode = new ListNode<T>
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
        
        public void Delete(T data)
        {
            if (_count == 0)
                throw new InvalidOperationException();
            
            ListNode<T> current = Head;
            ListNode<T> previous = null;

            while (current!=null)
            {
                if (Equals(current.Data, data))
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

            ListNode<T> current = Head;

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
            Head = Tail = new ListNode<T>();
            _count = 0;
        }
        
        /*public void WriteToFile <T>()
        {
            using (StreamWriter sw = new StreamWriter(@"D:\Образование\3Semester\OOP\OOP1Semestr\Laba8\Laba8\Data.txt"))
            {
                var temp = Head;
                while (temp.Next != null)
                {
                    sw.Write($"{temp.Data} --> ");
                    temp = temp.Next;
                }
                sw.WriteLine(temp.Data);
            }
        }

        public void ReadFromFile<T>() where T
        {
            using (StreamReader sw = new StreamReader(@"D:\Образование\3Semester\OOP\OOP1Semestr\Laba8\Laba8\Data.txt"))
            {
                string[] items = sw.ReadToEnd().Split(" --> ");
                foreach (T item in items)
                {
                    this.Add(item);
                }
            }
            //TODO как-то обобщить это
        }*/
    
        
        //Перегрузки операторов

        public static List<T> operator +(List<T> a, List<T> b)
        {
            List<T> newList = new List<T>();

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
        
        public static bool operator ==(List<T> a, List<T> b)
        {
            if (a._count != b._count)
                return false;

            var currentFirst = a.Head;
            var currentSecond = b.Head;
            while (currentFirst != null)
            {
                if (!Equals(currentFirst.Data, currentSecond.Data))
                    return false;
                currentFirst = currentFirst.Next;
                currentSecond = currentSecond.Next;
            }

            return true;
        }

        public static bool operator !=(List<T> a, List<T>  b)
        {
            return !(a == b);
        }

        public static List<T> operator <(List<T> a, List<T>  b)
        {
            return (a + b);
        }
        
        public static List<T> operator >(List<T> a, List<T>  b)
        {
            return (b + a);
        }
    }
}