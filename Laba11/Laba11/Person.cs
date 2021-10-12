namespace Laba11
{
    public class Person
    {
        public string Name { get; set;}
        public string BusNumber { get; set; }
        public Person()
        {
            Name = "default";
            BusNumber = "default number";
        }

        public Person(string name,string busNumber)
        {
            BusNumber = busNumber;
            Name = name;
        }
    }
}