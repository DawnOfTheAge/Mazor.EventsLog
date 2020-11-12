using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace General.Common.Database.Common
{
    public class AppConfigManager 
    {
        public event EventHandler AppConfigManagerMessage;

        public string Path { get; set; }

        public bool ConfigurationFileExists
        {
            get;
            set;
        }

        private XmlDocument m_XmlDocument;

        public AppConfigManager()
        {
        }

        public AppConfigManager(string path)
        {
            Path = path;
            ConfigurationFileExists = false;

            if (!loadConfigDocument())
            {
                OnAppConfigManagerMessage("Configuration file does not exist");
            }
        }

        public bool SetPath(string path)
        {
            Path = path;
            ConfigurationFileExists = false;

            if (!loadConfigDocument())
            {
                OnAppConfigManagerMessage("Configuration file does not exist");

                return false;
            }

            return true;
        }

        public string ReadSetting(string key)
        {
            try
            {
                if (m_XmlDocument == null)
                {
                    OnAppConfigManagerMessage("Couldn't load configuration file");

                    return "";
                }

                XmlNode node = m_XmlDocument.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                if (node == null)
                {
                    return "";
                }

                if (node.Attributes == null)
                {
                    return "";
                }

                return node.Attributes[1].Value;
            }
            catch
            {
                return "";
            }
        }

        public void WriteSetting(string key, string value)
        {
            try
            {
                if (m_XmlDocument == null)
                {
                    OnAppConfigManagerMessage("Couldn't load configuration file");

                    return;
                }

                XmlNode node = m_XmlDocument.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                if (node == null)
                {

                    XmlNode menu = m_XmlDocument.SelectSingleNode("configuration").SelectSingleNode("appSettings");
                    if (menu == null)
                    {
                        return;
                    }

                    XmlNode newSub = m_XmlDocument.CreateNode(XmlNodeType.Element, "add", null);

                    XmlAttribute xa = m_XmlDocument.CreateAttribute("key");
                    xa.Value = key;

                    XmlAttribute xb = m_XmlDocument.CreateAttribute("value");
                    xb.Value = value;

                    if (newSub.Attributes == null)
                    {
                        return;
                    }

                    newSub.Attributes.Append(xa);
                    newSub.Attributes.Append(xb);

                    menu.AppendChild(newSub);
                }
                else
                {
                    node.Attributes[1].Value = value;
                }

                m_XmlDocument.Save(getConfigFilePath());

                return;
            }
            catch (Exception e)
            {
                OnAppConfigManagerMessage("Key: " + key + " Value: " + value + ". " + e.Message);

                return;
            }
        }

        public void RemoveSetting(string key)
        {
            // retrieve appSettings node
            XmlNode node = m_XmlDocument.SelectSingleNode("//appSettings");

            try
            {
                if (node == null)
                    throw new InvalidOperationException("appSettings section not found in config file.");
                else
                {
                    // remove 'add' element with coresponding key
                    node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", key)));
                    m_XmlDocument.Save(getConfigFilePath());
                }
            }
            catch (NullReferenceException e)
            {
                throw new Exception(string.Format("The key {0} does not exist.", key), e);
            }
        }

        private bool loadConfigDocument()
        {
            string extension;

            try
            {
                m_XmlDocument = new XmlDocument();

                extension = System.IO.Path.GetExtension(Path);
                switch (extension)
                {
                    case ".dll":
                    case ".exe":
                        Path = Path.Replace(extension, ".xml");
                        break;

                    case ".xml":
                        break;

                    default:
                        return false;
                }

                if (File.Exists(Path))
                {
                    ConfigurationFileExists = true;
                }
                else
                {
                    ConfigurationFileExists = false;

                    return false;
                }

                m_XmlDocument.Load(Path);

                return true;
            }
            catch (System.IO.FileNotFoundException e)
            {
                OnAppConfigManagerMessage("No Configuration File Found. " + e.Message);

                return false;
            }
        }

        private string getConfigFilePath()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            path = path.Replace(".dll", ".xml");

            return path;
        }

        private void OnAppConfigManagerMessage(string message)
        {
            if (AppConfigManagerMessage != null)
            {
                AppConfigManagerMessage(message, null);
            }
        }
    }
}
