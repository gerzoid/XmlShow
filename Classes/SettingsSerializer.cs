using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XMLViewer2.Models;

namespace XMLViewer2.Classes
{
    public static class SettingsSerializer
    {
        private static string settinsFileName = "settings.json";
        public static void Serialize(Settings settings)
        {
            var res = JsonSerializer.Serialize(settings);
            File.WriteAllText(settinsFileName, res);
        }

        public static Settings Deserialize()
        {
            {
                if (!File.Exists(settinsFileName))
                {
                    var settings = new Settings();
                    Serialize(settings);
                }
                var json = File.ReadAllText(settinsFileName);
                return JsonSerializer.Deserialize<Settings>(json);
            }
        }
    }
}
