using ProiectPractica.Model;
using System;
using ProiectPractica.Repository;
using System.Configuration;

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
            var repositoryConfigurare = new RepositoryConfigurare(filePath);
            ApplicationConfiguration.Initialize();
            var config = new ConfigForm();
            config.SetRepository(repositoryConfigurare);
            Application.Run(config);
        }
    }
}