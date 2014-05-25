using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using System.IO;

namespace PatkaPlayer
{
    class Settings
    {
        public string LoadSetting(string key)
        {
            try
            {
                string originalPath = Application.ExecutablePath;
                string path = Path.GetDirectoryName(originalPath);
                string file = Path.GetFileNameWithoutExtension(originalPath);
                string customPath = path + "\\" + file + ".cfg";

                if (File.Exists(customPath))
                {
                    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                    configFileMap.ExeConfigFilename = customPath;

                    var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;

                    string result = settings[key].Value ?? null;

                    return result;
                }
                else return null;
            }
            
            catch (Exception e) //(NullReferenceException)
            {
                //MessageBox.Show(e.ToString());
                return null;
            }
            
            /*
            catch (ConfigurationErrorsException)
            {
                return null;
            }
            */
        }

        public void SaveSetting(string key, string value)
        {
            try
            {
                string originalPath = Application.ExecutablePath;
                string path = Path.GetDirectoryName(originalPath);
                string file = Path.GetFileNameWithoutExtension(originalPath);
                string customPath = path + "\\" + file + ".cfg";

                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            
            catch (Exception e) //(ConfigurationErrorsException)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void showError()
        {
            MessageBox.Show("Cannot save config, write access denied.", "Error saving configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
