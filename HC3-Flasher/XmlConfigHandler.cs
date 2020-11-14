using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HC3_Flasher
{
    class XmlConfigHandler
    {
        private readonly string configFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "HC3-Flasher-Config.xml");
        Profiles profiles;
        string defaultProfileName = "";

        public XmlConfigHandler() {
            XmlDocument xmlConfig = new XmlDocument();
            if (System.IO.File.Exists(configFilePath))
            {
                xmlConfig.Load(configFilePath);
            }
            profiles = new Profiles(ref xmlConfig);

            XmlNode nodeDefaultProfile = xmlConfig.SelectSingleNode("*/defaultProfile");
            if (nodeDefaultProfile != null)
            {
                defaultProfileName = nodeDefaultProfile.InnerText;
            }

        }

        /// <summary>
        /// Get the profile object
        /// </summary>
        public Profiles Profiles
        {
            get { return profiles; }
        }

        /// <summary>
        /// Get or Set the name of the default profile
        /// </summary>
        public string DefaultProfileName
        {
            get { return defaultProfileName; }
            set { defaultProfileName = value; }
        }

        /// <summary>
        /// Store the current configuration and all profiles
        /// </summary>
        public void Store()
        {

            XmlDocument xmlDest = new XmlDocument();
            XmlElement elem = xmlDest.CreateElement("HC3");

            XmlElement defaultProfile = xmlDest.CreateElement("defaultProfile");
            defaultProfile.InnerText = defaultProfileName;
            elem.AppendChild(defaultProfile);
            profiles.Store(ref xmlDest, ref elem);
            xmlDest.AppendChild(elem);
            xmlDest.Save(configFilePath);

        }
    }

    /// <summary>
    /// Handles profiles
    /// </summary>
    class Profiles
    {
        List<Profile> profiles = new List<Profile>();

        /// <summary>
        /// Handles profiles
        /// </summary>
        /// <param name="xmlSource">extract profiles from xml</param>
        public Profiles(ref XmlDocument xmlSource)
        {
            this.Load(ref xmlSource);
        }

        /// <summary>
        /// Get all loaded profiles
        /// </summary>
        public List<Profile> Get
        {
            get { return profiles; }
        }

        /// <summary>
        /// Load all profiles from xml file
        /// https://stackoverflow.com/questions/4835891/extract-value-of-attribute-node-via-xpath
        /// </summary>
        /// <param name="xmlSource">xml source</param>
        private void Load(ref XmlDocument xmlSource)
        {
            XmlNodeList profileNodes = xmlSource.SelectNodes("*/profile");
            foreach (XmlNode profile in profileNodes)
            {
                string name = profile.Attributes[0].Value;
                int baud = Convert.ToInt32(profile.Attributes[1].Value);
                System.IO.Ports.Parity parity = ParityStringToEnum(profile.Attributes[2].Value);
                int dBits = Convert.ToInt32(profile.Attributes[3].Value);
                System.IO.Ports.StopBits sBits = StopBitsStringToEnum(profile.Attributes[4].Value);
                string path = profile.Attributes[5].Value;
                string port = profile.Attributes[6].Value;

                Add(new Profile(name, baud, parity, dBits, sBits, path, port));
            }
        }

        /// <summary>
        /// Translate stop bits string to enum
        /// </summary>
        /// <param name="stopBits"></param>
        /// <returns></returns>
        public System.IO.Ports.StopBits StopBitsStringToEnum(string stopBits)
        {
            if (stopBits == "1")
            {
                return System.IO.Ports.StopBits.One;
            }
            else if (stopBits == "1.5")
            {
                return System.IO.Ports.StopBits.OnePointFive;
            }
            else if (stopBits == "2")
            {
                return System.IO.Ports.StopBits.Two;
            }
            return System.IO.Ports.StopBits.None;
        }

        /// <summary>
        /// Translate stop bits enum to string
        /// </summary>
        /// <param name="stopBits"></param>
        /// <returns></returns>
        public string StopBitsEnumToString(System.IO.Ports.StopBits stopBits)
        {
            switch(stopBits)
            {
                case System.IO.Ports.StopBits.None:
                    return "0";
                case System.IO.Ports.StopBits.One:
                    return "1";
                case System.IO.Ports.StopBits.OnePointFive:
                    return "1.5";
                case System.IO.Ports.StopBits.Two:
                    return "2";
            }
            return "0";
        }

        /// <summary>
        /// Translate parity string to enum
        /// </summary>
        /// <param name="parity"></param>
        /// <returns></returns>
        public System.IO.Ports.Parity ParityStringToEnum(string parity)
        {
            if (parity == "Even")
            {
                return System.IO.Ports.Parity.Even;
            }
            else if (parity == "Odd")
            {
                return System.IO.Ports.Parity.Odd;
            }
            else if (parity == "Space")
            {
                return System.IO.Ports.Parity.Space;
            }
            // no parity
            return System.IO.Ports.Parity.None;
        }

        /// <summary>
        /// Add a new profile to the profiles list
        /// </summary>
        /// <param name="newProfile">profile to add</param>
        public void Add(Profile newProfile)
        {
            profiles.Add(newProfile);
        }

        /// <summary>
        /// Remove the profile on position x of the profiles list
        /// </summary>
        /// <param name="index">position</param>
        public void Remove(int index)
        {
            profiles.RemoveAt(index);
        }

        /// <summary>
        /// Check if a profile exists
        /// </summary>
        /// <param name="name">name of the profile</param>
        /// <returns>true if the profile exits</returns>
        public bool Exists(string name)
        {
            foreach (Profile p in profiles)
            {
                if (p.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get the position of a specific profile
        /// </summary>
        /// <param name="name">name of the profile</param>
        /// <returns>position of the profile</returns>
        public int GetIndex(string name)
        {
            for(int i = 0; i < profiles.Count; i++)
            {
                if (profiles[i].Name == name)
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// Store all profiles
        /// </summary>
        public void Store(ref XmlDocument xmlDest, ref XmlElement elem)
        {
            foreach (Profile p in profiles)
            {
                XmlElement xmlProfile = xmlDest.CreateElement("profile");
                xmlProfile.SetAttribute("name", p.Name);
                xmlProfile.SetAttribute("baud", p.BaudRate.ToString());
                xmlProfile.SetAttribute("parity", p.Parity.ToString());
                xmlProfile.SetAttribute("dBits", p.DataBits.ToString());
                xmlProfile.SetAttribute("sBits", StopBitsEnumToString(p.StopBits));
                xmlProfile.SetAttribute("path", p.DefaultPath);
                xmlProfile.SetAttribute("port", p.DefaultPort);
                elem.AppendChild(xmlProfile);
            }
        }
    }
}
