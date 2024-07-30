using ProiectPractica.Model;
using System;
using ProiectPractica.Repository;
using ProiectPractica.Validator;
using ProiectPractica.SettingsHandler;
using System.Reflection;
using ProiectPractica.Persistance;

namespace ProiectPractica
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "//fileSettings.json";
            var fileSettingsHandler = new FileSettingsHandler(filePath);
            var configurationRepository = new ConfigurationRepository();
            var dbContext = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
            var configurationPersistence = new ConfigurationPersistence(dbContext);
            ApplicationConfiguration.Initialize();
            var config = new ConfigForm();
            config.SetFileSettingsHandler(fileSettingsHandler);
            config.SetDbPersistence(configurationPersistence);
            config.SetRepository(configurationRepository);
            Application.Run(config);
        }
    }
}
