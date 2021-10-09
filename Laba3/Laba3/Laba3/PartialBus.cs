using System;

namespace Laba3
{
    public partial class Bus
    {
        public override string ToString() =>
            $"Class Fields:\n" +
            $" busId:{this.busID}\n " +
            $"driverInfo:{this.DriverFIO}\n" +
            $" busNumber:{this._busNumber}\n " +
            $"routeNumber:{this.RouteNumber}\n " +
            $"busBrand:{this.BusBrand}\n" +
            $" yearOfOperationStart:{this.YearOfOpetationStart}\n" +
            $" carMileage:{this.CarMileage}\n" +
            $" Methods:\n " +
            $"ShowClassInfo\n " +
            $"GetYearOfOperationStart\n" +
            $" CreateBus";

        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();
            
            Bus bus = obj as Bus;
            if (bus == null)
                return false;
            return bus.busID== this.busID;
        }
        
        public override int GetHashCode()
        {
            return (int)(this.CarMileage * this.YearOfOpetationStart * Bus.PI);
        }
        
    }
}