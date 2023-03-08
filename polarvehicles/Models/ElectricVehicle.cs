namespace polarvehicles.Models
{
    public class ElectricVehicle
    {
        private readonly string modelName;
        private readonly string vehicleId;
        private readonly double batteryCapacity; // in kWh
        private readonly double batteryEfficiency; // in kWh per 100 km
        private double temperatureFactor; // between 0 and 1
        private double drivingFactor; // between 0 and 1

        public ElectricVehicle(string modelName, string vehicleId, string vehicleName, double batteryCapacity, double batteryEfficiency)
        {
            this.modelName = modelName;
            this.vehicleId = vehicleId;
            this.batteryCapacity = batteryCapacity;
            this.batteryEfficiency = batteryEfficiency;
            this.temperatureFactor = 1; // default to 1 for warm weather
            this.drivingFactor = 1; // default to 1 for efficient driving habits
        }

        // Add properties for temperature and driving factors
        public double TemperatureFactor
        {
            get { return temperatureFactor; }
            set { temperatureFactor = value; }
        }

        public double DrivingFactor
        {
            get { return drivingFactor; }
            set { drivingFactor = value; }
        }

        public int CalculateRange()
        {
            // Range = Battery Capacity * Efficiency / (Wh per km) * (1 - Temperature Factor) * (1 - Driving Factor)
            // Calculation was co-coded with ChatGPT (Im not that kind of engineer...) :)
            double rangeInKm = batteryCapacity * batteryEfficiency / (10 * (1 - temperatureFactor) * (1 - drivingFactor));
            return (int)rangeInKm;
        }
    }
}
