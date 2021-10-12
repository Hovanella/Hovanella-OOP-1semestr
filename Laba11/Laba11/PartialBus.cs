using System;

namespace Laba11
{
    public partial class Bus
    {
        public override string ToString()
        {
            return "Class Fields:\n" +
                   $" busId:{busID}\n " +
                   $"driverInfo:{DriverFIO}\n" +
                   $" busNumber:{_busNumber}\n " +
                   $"routeNumber:{RouteNumber}\n " +
                   $"busBrand:{BusBrand}\n" +
                   $" yearOfOperationStart:{YearOfOpetationStart}\n" +
                   $" carMileage:{CarMileage}\n" +
                   " Methods:\n " +
                   "ShowClassInfo\n " +
                   "GetYearOfOperationStart\n" +
                   " CreateBus";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();

            var bus = obj as Bus;
            if (bus == null)
                return false;
            return bus.busID == busID;
        }

        public override int GetHashCode()
        {
            return (int)(CarMileage * YearOfOpetationStart * PI);
        }
    }
}