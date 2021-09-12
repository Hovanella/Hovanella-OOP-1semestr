using System;
using System.IO;

namespace Laba3
{
    //Создать класс Bus: Фамилия и инициалы водителя, 
    // Номер автобуса, Номер маршрута, Марка, Год начала 
    //эксплуатации, Пробег. Свойства и конструкторы должны
    /*обеспечивать проверку корректности. Добавить метод
    вывода возраста автобуса.Создать массив объектов. Вывести:
    a) список автобусов для заданного номера маршрута;
    b) список автобусов, которые эксплуатируются больше
    заданного срока*/
    
    public partial class Bus
    {
        //Поля
        private double PI = 3.14;
        private readonly int busID; 
        private string _busNumber;
       
        
        //Свойства и автосвойства(заменял ими поля+свойства,когда нет логики в get/set) 
        public static int BusCounter{ get; private set; }
        public string BusNumber
        {
            get => _busNumber;
            set
            {
                if (value.Length is > 0 and < 7)
                {
                    _busNumber = value;
                }
            }
        }
        public string RouteNumber { get; set; }
        public string DriverFIO { get; private set;}
        public string BusBrand { get; set;}
        public int YearOfOpetationStart {private get; set;}
        public int CarMileage {get; set;}
        
        
        //Конструкторы
        static Bus()
        {
            BusCounter = 0;
        }
        
        public Bus()
        {
            DriverFIO = "Default driver";
            _busNumber = "Default bus number";
            RouteNumber = "Default route number";
            BusBrand = "Default brand";
            YearOfOpetationStart = 2000;
            CarMileage = 0;
            busID = GetHashCode();
            
            Bus.BusCounter++;
        }
        
        public Bus(string driverFIO,string busNumber,string routeNumber,string busBrand,int yearOfOpetationStart,int carMileage=0)
        {
            if (busNumber.Length is > 0 and < 7)
            {
                DriverFIO = driverFIO;
                _busNumber = busNumber;
                RouteNumber = routeNumber;
                BusBrand = busBrand;
                YearOfOpetationStart = yearOfOpetationStart;
                CarMileage = carMileage;
                busID = GetHashCode();
                
                Bus.BusCounter++;
            }
            else
                throw new ArgumentException();
        }
        
        private Bus(int busId)
        {
            DriverFIO = "Default driver";
            _busNumber = "Default bus number";
            RouteNumber = "Default route number";
            BusBrand = "Default brand";
            YearOfOpetationStart = 2000;
            CarMileage = 0;

            Bus.BusCounter++;
        }
        
        
        //Методы
        public void ShowClassInfo()
        {
            Console.WriteLine(this.ToString());
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        
        public int GetYearOfOperationStart()
        {
            return YearOfOpetationStart;
        }
        
        public static void IncreaseCarMileage(ref int carMileage)
        {
            carMileage++;
        }
        
        public static void ChangeBrand(out string brand, string newBrand)
        {
            brand = newBrand;
        }
        
        public static Bus CreateBus(int ID)
        {
            return new Bus(ID);
        }
        
        

    }
}