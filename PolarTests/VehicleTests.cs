
using polarvehicles.Models;

namespace PolarTests
{
    [TestClass]
    public class VehicleTests
    {
        public static bool BetweenRanges(int a, int b, int number)
        {
            return (a <= number && number <= b);
        }
        [TestMethod]
        public void Electric_Vehicle_Calculates_Range_Close_To_Manufacturer_Specs()
        {

            int acceptedDifference = 80;

            // Arrange
            string vehicleId = "polestar_2";
            string modelName = "Polestar 2";
            double batteryCapacity = 78;
            double batteryEfficency = 0.22f;
            

            int maxRange = 426;
            int minRange = 375;

            ElectricVehicle polestar2 = new(vehicleId, modelName, batteryCapacity, batteryEfficency);
            int calculatedRange = polestar2.CalculateRange(3);

            // Act

            Assert.IsTrue(BetweenRanges(minRange - acceptedDifference, minRange + acceptedDifference, calculatedRange), $"calculated min range ({calculatedRange}) is greater or equal than specified min range. ({minRange})");
            Assert.IsTrue(BetweenRanges(maxRange - acceptedDifference, maxRange + acceptedDifference, calculatedRange), $"calculated max range ({calculatedRange}) is less or equal than specified max range. {maxRange}");

        }
    }
}