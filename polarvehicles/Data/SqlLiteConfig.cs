using polarvehicles.Models;
using System.Data.Entity;
using System.Data.SQLite;

namespace polarvehicles.Data
{
    public class SqlLiteConfig
    {

        public static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=../polaris.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                throw;
            }
            return sqlite_conn;
        }
        public static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE IF NOT EXISTS Vehicles ( vehicleId TEXT PRIMARY KEY, " + "modelName TEXT," + "batteryCapacity REAL," + "batteryEfficency REAL" + "" +
                ")";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();

        }

        public static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT OR IGNORE INTO Vehicles (vehicleId, modelName, batteryCapacity, batteryEfficency) VALUES('tesla_mod_3', 'Tesla Model 3', 75, 0.17 ); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT OR IGNORE INTO Vehicles (vehicleId, modelName, batteryCapacity, batteryEfficency) VALUES('wolks_id_4', 'Volkswagen ID.4', 52, 0.165 ); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT OR IGNORE INTO Vehicles (vehicleId, modelName, batteryCapacity, batteryEfficency) VALUES('nissan_leaf', 'Nissan Leaf', 50, 0.175 ); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT OR IGNORE INTO Vehicles (vehicleId, modelName, batteryCapacity, batteryEfficency) VALUES('audi_e_tron', 'Audi e-tron', 86, 0.234 ); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT OR IGNORE INTO Vehicles (vehicleId, modelName, batteryCapacity, batteryEfficency) VALUES('polestar_2', 'Polestar 2', 78, 0.19 ); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT OR IGNORE INTO Vehicles (vehicleId, modelName, batteryCapacity, batteryEfficency) VALUES('peugeot_e_2008', 'Peugeot e-2008', 50, 0.22 ); ";
            sqlite_cmd.ExecuteNonQuery();

        }

        public static IEnumerable<ElectricVehicle> ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Vehicles";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            List<ElectricVehicle> vehicles = new();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
            return vehicles;
        }

        public static void DropData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "DROP TABLE Vehicles;";
            sqlite_cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
