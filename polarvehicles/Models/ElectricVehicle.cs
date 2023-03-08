namespace polarvehicles.Models
{
    public class ElectricVehicle
    {

        private readonly string vehicleId;
        private readonly string modelName;
        private readonly double batteryCapacity; // in kWh
        private readonly double batteryEfficiency; // in kWh per 100 km
        private double temperatureFactor; // between 0 and 1

        public ElectricVehicle(string vehicleId, string modelName, double batteryCapacity, double batteryEfficiency)
        {
            this.vehicleId = vehicleId;
            this.modelName = modelName;
            this.batteryCapacity = batteryCapacity;
            this.batteryEfficiency = batteryEfficiency;
            temperatureFactor = 5; // default to 5 for warm weather
        }

    
        public string ModelName
        {
            get { return modelName; }
        }
        public double TemperatureFactor
        {
            get { return temperatureFactor; }
            set { temperatureFactor = value; }
        }


        public int RangeColdWeatherKM
        {
            get { return CalculateRange(1); }
        }

        public int RangeNormalWeatherKM
        {
            get { return CalculateRange(3); }
        }

        public int RangeHotWeatherKM
        {
            get { return CalculateRange(5); }
        }

        public double EnergyConsumption(double distance)
        {
            double energy = (batteryCapacity * TemperatureFactor) / (distance * batteryEfficiency);
            return energy; // kWh/km
        }



        public int CalculateRange()
        {
            double estimatedRange = batteryCapacity / batteryEfficiency;
         
            // Adjust estimated range based on temperature factor
            if (TemperatureFactor >= 1 && TemperatureFactor <= 5)
            {
                double temperatureAdjustment = 1.0;

                if (TemperatureFactor == 1)
                {
                    temperatureAdjustment = 0.6;
                }
                else if (TemperatureFactor == 2)
                {
                    temperatureAdjustment = 0.8;
                }
                else if (TemperatureFactor == 4)
                {
                    temperatureAdjustment = 1.2;
                }
                else if (TemperatureFactor == 5)
                {
                    temperatureAdjustment = 1.4;
                }

                estimatedRange *= temperatureAdjustment;
            }

            return (int)estimatedRange; // km
        }

        public int CalculateRange(double tempFactor)
        {
            double estimatedRange = batteryCapacity / batteryEfficiency;

            // Adjust estimated range based on temperature factor
            if (tempFactor >= 1 && tempFactor <= 5)
            {
                double temperatureAdjustment = 1.0;

                if (tempFactor == 1)
                {
                    temperatureAdjustment = 0.6;
                }
                else if (tempFactor == 2)
                {
                    temperatureAdjustment = 0.8;
                }
                else if (tempFactor == 4)
                {
                    temperatureAdjustment = 1.2;
                }
                else if (tempFactor == 5)
                {
                    temperatureAdjustment = 1.4;
                }

                estimatedRange *= temperatureAdjustment;
            }

            return (int)estimatedRange; //km
        }
    }
}
