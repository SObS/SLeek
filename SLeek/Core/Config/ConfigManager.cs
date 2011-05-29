using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SLeek
{
    public class ConfigManager
    {
        private string defaultConfigPath = Path.Combine(Environment.CurrentDirectory, "SLeek.ini");
        private Config currentConfig;

        public ConfigManager()
        {

        }

        public void ApplyCurrentConfig()
        {
            Apply(currentConfig);
        }

        public void Apply(Config config)
        {
            currentConfig = config;
            OnConfigApplied(new ConfigAppliedEventArgs(currentConfig));
        }

        public void ApplyDefault()
        {
            Config config;

            if (File.Exists(defaultConfigPath))
            {
                config = Config.LoadFrom(defaultConfigPath);
            }
            else
            {
                config = new Config();
                config.Save(defaultConfigPath);
            }

            Apply(config);
        }

        public void Reset()
        {
            Config config = new Config();
            config.Save(defaultConfigPath);

            Apply(config);
        }

        public void SaveCurrentConfig()
        {
            currentConfig.Save(defaultConfigPath);
        }

        public event EventHandler<ConfigAppliedEventArgs> ConfigApplied;
        protected virtual void OnConfigApplied(ConfigAppliedEventArgs e)
        {
            if (ConfigApplied != null) ConfigApplied(this, e);
        }

        public Config CurrentConfig
        {
            get { return currentConfig; }
        }
    }
}
