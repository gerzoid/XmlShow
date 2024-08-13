using Microsoft.Extensions.DependencyInjection;
using XMLViewer2.Classes;
using XMLViewer2.Forms;
using XMLViewer2.Models;

namespace XMLViewer2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            
            using (ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {         
            var settings = SettingsSerializer.Deserialize();
            services.AddSingleton(settings);
            services.AddTransient<Exporter>();
            services.AddTransient<Searcher>();
            services.AddSingleton<XmlViewer>();
            services.AddTransient<MainForm>();
            services.AddTransient<ExportToExcelSettingsForm>();         
        }
    }
}