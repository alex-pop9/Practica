using ProiectPractica.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.Persistance
{
    public class ConfigurationPersistence : IConfigurationPersistence
    {
        private string _dbConnection;

        public ConfigurationPersistence(string dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Configuration? GetLastConfigurationFromFile(string filePath,out int id)
        {
            var resultedConfiguration = new Configuration();
            id = 0;
            using (var connection = new SQLiteConnection(_dbConnection))
            {
                connection.Open();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    return resultedConfiguration;
                }
                var command = new SQLiteCommand("SELECT * FROM Configuration WHERE filePath = @filePath ORDER BY id DESC LIMIT 1", connection);
                command.Parameters.AddWithValue("@filePath", filePath);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return resultedConfiguration;
                    }
                    id = reader.GetInt32(0);
                    resultedConfiguration.MinAcceptablePrice = reader.GetInt32(1);
                    resultedConfiguration.MinPricePerKm = reader.GetFloat(2);
                    resultedConfiguration.NumberOfCars = reader.GetInt32(3);
                    resultedConfiguration.ReservationCheckInterval = reader.GetInt32(4);
                    resultedConfiguration.PhoneNumber = reader.GetString(5);
                    resultedConfiguration.MinPriceForShortTrips = reader.GetInt32(6);
                    resultedConfiguration.ShortTripDistanceThreshold = reader.GetInt32(7);
                    resultedConfiguration.StartBusinessHour = reader.GetInt32(8);
                    resultedConfiguration.EndBusinessHour = reader.GetInt32(9);
                }
            }
            return resultedConfiguration;
        }

        public Configuration? Save(Configuration configuration, string filePath)
        {
            using(var connection = new SQLiteConnection(_dbConnection))
            {
                connection.Open();
                if(connection.State != System.Data.ConnectionState.Open)
                {
                    return null;
                }
                using(var transaction = connection.BeginTransaction())
                {
                    var command = new SQLiteCommand("insert into Configuration(minAcceptablePrice,minPricePerKm," +
                        "numberOfCars,reservationCheckInterval,phoneNumber,minPriceForShortTrips,shortTripDistanceThreshold," +
                        "startBusinessHour,endBusinessHour,filePath) values (@minAcceptablePrice,@minPricePerKm,@numberOfCars," +
                        "@reservationCheckInterval,@phoneNumber,@minPriceForShortTrips,@shortTripDistanceThreshold,@startBusinessHour," +
                        "@endBusinessHour,@filePath)", connection);
                    command.Parameters.AddWithValue("@minAcceptablePrice", configuration.MinAcceptablePrice);
                    command.Parameters.AddWithValue("@minPricePerKm", configuration.MinPricePerKm);
                    command.Parameters.AddWithValue("@numberOfCars", configuration.NumberOfCars);
                    command.Parameters.AddWithValue("@reservationCheckInterval", configuration.ReservationCheckInterval);
                    command.Parameters.AddWithValue("@phoneNumber", configuration.PhoneNumber);
                    command.Parameters.AddWithValue("@minPriceForShortTrips", configuration.MinPriceForShortTrips);
                    command.Parameters.AddWithValue("@shortTripDistanceThreshold", configuration.ShortTripDistanceThreshold);
                    command.Parameters.AddWithValue("@startBusinessHour", configuration.StartBusinessHour);
                    command.Parameters.AddWithValue("@endBusinessHour", configuration.EndBusinessHour);
                    command.Parameters.AddWithValue("@filePath", filePath);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            return configuration;
        }

        public List<Configuration> FindAll()
        {
            var configurations = new List<Configuration>();
            using (var connection = new SQLiteConnection(_dbConnection))
            {
                connection.Open();
                if(connection.State != System.Data.ConnectionState.Open)
                {
                   return configurations;
                }
                var command = new SQLiteCommand("select * from Configurtion", connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var resultedConfiguration = new Configuration();
                        resultedConfiguration.MinAcceptablePrice = reader.GetInt32(1);
                        resultedConfiguration.MinPricePerKm = reader.GetFloat(2);
                        resultedConfiguration.NumberOfCars = reader.GetInt32(3);
                        resultedConfiguration.ReservationCheckInterval = reader.GetInt32(4);
                        resultedConfiguration.PhoneNumber = reader.GetString(5);
                        resultedConfiguration.MinPriceForShortTrips = reader.GetInt32(6);
                        resultedConfiguration.ShortTripDistanceThreshold = reader.GetInt32(7);
                        resultedConfiguration.StartBusinessHour = reader.GetInt32(8);
                        resultedConfiguration.EndBusinessHour = reader.GetInt32(9);
                        configurations.Add(resultedConfiguration);
                    }
                }
            }
            return configurations;
        }

        public Configuration? GetPreviousConfiguration(string filePath,int currentId, out int previousId)
        {
            var resultedConfiguration = new Configuration();
            using (var connection = new SQLiteConnection(_dbConnection))
            {
                connection.Open();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    previousId = 0;
                    return resultedConfiguration;
                }
                var command = new SQLiteCommand("SELECT * FROM Configuration WHERE filePath = @filePath AND id < @currentId ORDER BY id DESC LIMIT 1", connection);
                command.Parameters.AddWithValue("@filePath", filePath);
                command.Parameters.AddWithValue("@currentId", currentId);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        previousId = 0;
                        return resultedConfiguration;
                    }
                    previousId = reader.GetInt32(0);
                    resultedConfiguration.MinAcceptablePrice = reader.GetInt32(1);
                    resultedConfiguration.MinPricePerKm = reader.GetFloat(2);
                    resultedConfiguration.NumberOfCars = reader.GetInt32(3);
                    resultedConfiguration.ReservationCheckInterval = reader.GetInt32(4);
                    resultedConfiguration.PhoneNumber = reader.GetString(5);
                    resultedConfiguration.MinPriceForShortTrips = reader.GetInt32(6);
                    resultedConfiguration.ShortTripDistanceThreshold = reader.GetInt32(7);
                    resultedConfiguration.StartBusinessHour = reader.GetInt32(8);
                    resultedConfiguration.EndBusinessHour = reader.GetInt32(9);
                }
            }
            return resultedConfiguration;
        }

        public Configuration? GetNextConfiguration(string filePath, int currentId, out int nextId)
        {
            var resultedConfiguration = new Configuration();
            using (var connection = new SQLiteConnection(_dbConnection))
            {
                connection.Open();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    nextId = 0;
                    return resultedConfiguration;
                }
                var command = new SQLiteCommand("SELECT * FROM Configuration WHERE filePath = @filePath AND id > @currentId ORDER BY id ASC LIMIT 1", connection);
                command.Parameters.AddWithValue("@filePath", filePath);
                command.Parameters.AddWithValue("@currentId", currentId);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        nextId = 0;
                        return resultedConfiguration;
                    }
                    nextId = reader.GetInt32(0);
                    resultedConfiguration.MinAcceptablePrice = reader.GetInt32(1);
                    resultedConfiguration.MinPricePerKm = reader.GetFloat(2);
                    resultedConfiguration.NumberOfCars = reader.GetInt32(3);
                    resultedConfiguration.ReservationCheckInterval = reader.GetInt32(4);
                    resultedConfiguration.PhoneNumber = reader.GetString(5);
                    resultedConfiguration.MinPriceForShortTrips = reader.GetInt32(6);
                    resultedConfiguration.ShortTripDistanceThreshold = reader.GetInt32(7);
                    resultedConfiguration.StartBusinessHour = reader.GetInt32(8);
                    resultedConfiguration.EndBusinessHour = reader.GetInt32(9);
                }
            }
            return resultedConfiguration;
        }

        public int GetLastConfigurationIndexByFile(string filePath)
        {
            var id = 0;
            using (var connection = new SQLiteConnection(_dbConnection))
            {
                connection.Open();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    return 0;
                }
                var command = new SQLiteCommand("SELECT id FROM Configuration WHERE filePath = @filePath ORDER BY id DESC LIMIT 1;", connection);
                command.Parameters.AddWithValue("@filePath", filePath);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return 0;
                    }
                    id = reader.GetInt32(0);
                }
            }
            return id;
        }

        public int GetFirstConfigurationIndexByFile(string filePath)
        {
            var id = 0;
            using (var connection = new SQLiteConnection(_dbConnection))
            {
                connection.Open();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    return 0;
                }
                var command = new SQLiteCommand("SELECT id FROM Configuration WHERE filePath = @filePath ORDER BY id ASC LIMIT 1;", connection);
                command.Parameters.AddWithValue("@filePath", filePath);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return 0;
                    }
                    id = reader.GetInt32(0);
                }
            }
            return id;
        }
    }
}
