using ProiectPractica.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectPractica.Mapper;
using Newtonsoft.Json;
using Microsoft.VisualBasic.FileIO;


namespace ProiectPractica.Persistance
{
    public class ConfigurationPersistence : IConfigurationPersistence
    {
        private ConfigurationContext _dbContext;
        public ConfigurationPersistence(ConfigurationContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns the first id for a configuration from a specific file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int GetFirstConfigurationIndexByFile(string filePath)
        {
            var configuration = _dbContext.Paths
                .Where(p => p.FilePath == filePath)
                .SelectMany(m => m.PathConfigurations.Select(c => c.ConfigurationLog)
                .OrderBy(c => c.ConfigurationLogID))
                .FirstOrDefault();
            if(configuration == null)
                return 0;
            return configuration.ConfigurationLogID;
        }

        /// <summary>
        /// Saves a configuration and the path in DB 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="fileSettings"></param>
        /// <returns></returns>
        public Configuration? Save(Configuration configuration, FileSettings fileSettings)
        {
            var dbConfiguration = _dbContext.Configuration.FirstOrDefault();
            if(dbConfiguration == null)
            {
                _dbContext.Configuration.Add(Mapper.Mapper.Convert(configuration));
            }
            else
            {
                dbConfiguration.MinAcceptablePrice = configuration.MinAcceptablePrice;
                dbConfiguration.MinPricePerKm = configuration.MinPricePerKm;
                dbConfiguration.NumberOfCars = configuration.NumberOfCars;
                dbConfiguration.ReservationCheckInterval = configuration.ReservationCheckInterval;
                dbConfiguration.PhoneNumber = configuration.PhoneNumber;
                dbConfiguration.MinPriceForShortTrips = configuration.MinPriceForShortTrips;
                dbConfiguration.ShortTripDistanceThreshold = configuration.ShortTripDistanceThreshold;
                dbConfiguration.StartBusinessHour = configuration.StartBusinessHour;
                dbConfiguration.EndBusinessHour = configuration.EndBusinessHour;
                _dbContext.Configuration.Update(dbConfiguration);
            }
            _dbContext.SaveChanges();
            SaveConfigurationLog(configuration);
            SavePath(fileSettings);
            var configurationLog = _dbContext.ConfigurationLog.OrderByDescending(u => u.ConfigurationLogID).FirstOrDefault();
            var path = _dbContext.Paths.OrderByDescending(u => u.FileSettingsID).FirstOrDefault();
            SavePathConfgurationLog(configurationLog, path);
            return configuration;
        }

        /// <summary>
        /// Returns the last id for a configuration from a specific file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public int GetLastConfigurationIndexByFile(string filePath)
        {
            var configurationId = _dbContext.Paths
                .Where(p => p.FilePath == filePath)
                .SelectMany(m => m.PathConfigurations.Select(c => c.ConfigurationLog))
                .OrderBy(c => c.ConfigurationLogID)
                .LastOrDefault();
            if (configurationId == null)
                return 0;
            return configurationId.ConfigurationLogID;
        }

        /// <summary>
        /// Returns the last configuration saved having that specific filepath
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Configuration? GetLastConfigurationFromFile(string filePath, out int id)
        {
            var configurationLog = _dbContext.Paths
                .Where (p => p.FilePath == filePath)
                .SelectMany(m => m.PathConfigurations.Select(c => c.ConfigurationLog))
                .OrderBy(c => c.ConfigurationLogID)
                .LastOrDefault();
            var configuration = JsonConvert.DeserializeObject<Configuration>(configurationLog.ConfigurationString);
            id = configurationLog.ConfigurationLogID;
            return configuration;
        }

        /// <summary>
        /// Retruns the configuration saved after the current selected configuration 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="currentId"></param>
        /// <param name="nextId"></param>
        /// <returns></returns>
        public Configuration? GetNextConfiguration(string filePath, int currentId, out int nextId)
        {
            var configurationLog = _dbContext.Paths
                .Where(p => p.FilePath == filePath)
                .SelectMany(m => m.PathConfigurations.Select(c => c.ConfigurationLog))
                .Where(c => c.ConfigurationLogID > currentId)
                .OrderBy(c => c.ConfigurationLogID)
                .FirstOrDefault();
            var configuration = new Configuration();
            if (configurationLog != null)
            {
                configuration = JsonConvert.DeserializeObject<Configuration>(configurationLog.ConfigurationString);
                nextId = configurationLog.ConfigurationLogID;
                return configuration;
            }
            else
            {
                nextId = 0;
                return configuration;
            }
        }

        /// <summary>
        /// Retruns the configuration saved before the current selected configuration 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="currentId"></param>
        /// <param name="previousId"></param>
        /// <returns></returns>
        public Configuration? GetPreviousConfiguration(string filePath, int currentId, out int previousId)
        {
            var configurationLog = _dbContext.Paths
                .Where(p => p.FilePath == filePath)
                .SelectMany(m => m.PathConfigurations.Select(c => c.ConfigurationLog))
                .Where(c => c.ConfigurationLogID < currentId)
                .OrderByDescending(c => c.ConfigurationLogID)
                .FirstOrDefault();
            var configuration = new Configuration();
            if (configurationLog != null)
            {
                configuration = JsonConvert.DeserializeObject<Configuration>(configurationLog.ConfigurationString);
                previousId = configurationLog.ConfigurationLogID;
                return configuration;
            }
            else
            {
                previousId = 0;
                return configuration;
            }
        }

        /// <summary>
        /// Saves all reservations read from a file
        /// </summary>
        /// <param name="path"></param>
         public void SaveReservationsInDb(string path)
        {
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    if(!_dbContext.Reservations.Any(p => p.ReservationID == int.Parse(fields[2])))
                    {
                        _dbContext.Reservations.Add(new ProiectPractica.DbModel.Reservation { Week = int.Parse(fields[0]), CongirmedTime = fields[1], ReservationID = int.Parse(fields[2]), Price = float.Parse(fields[3]), Currency = fields[4], Distance = float.Parse(fields[5]), PricePerKm = float.Parse(fields[6]) });
                    }
                }
                _dbContext.SaveChanges();
            }
        } 

        public List<ProiectPractica.DbModel.Reservation> GetReservations()
        {
            return _dbContext.Reservations.ToList();
        }

        private void SaveConfigurationLog(Configuration configuration)
        {
            var log = new ProiectPractica.DbModel.ConfigurationLog();
            log.ConfigurationString = JsonConvert.SerializeObject(configuration, Formatting.Indented);
            log.TimeStamp = DateTime.Now.ToString();
            _dbContext.ConfigurationLog.Add(log);
            _dbContext.SaveChanges();
        }

        private void SavePath(FileSettings fileSettings)
        {
            _dbContext.Paths.Add(Mapper.Mapper.Convert(fileSettings));
            _dbContext.SaveChanges();
        }

        private void SavePathConfgurationLog(ProiectPractica.DbModel.ConfigurationLog Configuration, ProiectPractica.DbModel.FileSettings Path)
        {
            _dbContext.PathConfigurationLog.Add(new DbModel.PathConfigurationLog { ConfigurationLog = Configuration, FileSettings = Path});
            _dbContext.SaveChanges();
        }

       
    }
}
