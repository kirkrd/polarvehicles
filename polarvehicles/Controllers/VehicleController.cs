using Microsoft.AspNetCore.Mvc;
using polarvehicles.Data;
using polarvehicles.Models;
using System.Data.SQLite;

namespace polarvehicles.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public class VehicleController : ControllerBase
    {
        
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger; 
        }

        public static IEnumerable<ElectricVehicle> ReadVehicleData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Vehicles";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            List<ElectricVehicle> vehicles = new();
            while (sqlite_datareader.Read())
            {
                string vehicleId = sqlite_datareader.GetString(0);
                string modelName = sqlite_datareader.GetString(1);
                double batteryCapacity = (double)sqlite_datareader.GetValue(2);
                double batteryEfficency = (double)sqlite_datareader.GetValue(3);
                ElectricVehicle currVehicle = new(vehicleId, modelName, batteryCapacity, batteryEfficency);
                vehicles.Add(currVehicle);

            }
            conn.Close();
            return vehicles;
        }

        [HttpGet(Name = "GetVehicles")]
        public IEnumerable<ElectricVehicle> Get()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = SqlLiteConfig.CreateConnection();
            var test = ReadVehicleData(sqlite_conn);
            return test;
        }
    }
}
