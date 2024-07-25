using ProiectPractica.Model;
using System;
using ProiectPractica.Repository;
using System.Configuration;
using ProiectPractica.Validator;
using ProiectPractica.SettingsHandler;

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
            var filePath = ConfigurationManager.AppSettings["filePath"];
            var fileSettingsHandler = new FileSettingsHandler(filePath);
            var configurationRepository = new ConfigurationRepository();
            ApplicationConfiguration.Initialize();
            var config = new ConfigForm();
            config.SetFileSettingsHandler(fileSettingsHandler);
            config.SetRepository(configurationRepository);
            Application.Run(config);
        }
    }
}