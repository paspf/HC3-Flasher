using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HC3_Flasher
{
    /*
     * LoadProfiles
     * This class handles loading and storeing of profiles
     * into the .cfg file
     */
    class ProfileHandler
    {
        List<Profile> profiles = new List<Profile>();
        string profileFileName;
        string profileString;
        public List<Profile> Profiles
        {
            get { return profiles; }
        }
        /*
         * ProfileHandler
         * If the profile file doesnt exists a new one is created
         */
        public ProfileHandler()
        {
            profileFileName = "HC3 Flasher Profiles.cfg";
            if (!File.Exists(profileFileName))
            {
                using (FileStream fs = File.Create(profileFileName))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("HC3 flasher profiles\r\n" +
                        "Name\r\n" +
                        "BaudRate\r\n" +
                        "Parity\r\n" +
                        "DataBits\r\n" +
                        "StopBits\r\n" +
                        "default path\r\n" +
                        "default COM port\r\n" +
                        "endProfile\r\n" +
                        "\r\n#endOfFile");
                    // write in the file
                    fs.Write(info, 0, info.Length);
                }
            }
        }
        /*
         * loadProfiles
         * This function loads the profiles out of an .cfg file
         * The profiles are stored in the list profiles
         */
        public int loadProfiles()
        {
            string name;
            int baudRate;
            string par;
            int parity;
            int dataBits;
            int stopBits;
            string defaultPort;
            string defaultPath;

            profileString = File.ReadAllText(profileFileName, Encoding.UTF8);
            int index = profileString.IndexOf('#') + 1;
            int enddex = profileString.IndexOf("#endOfFile") + 1;
            try
            {
                while (index != enddex)
                {
                    // get profile name
                    // index = cfgFile.IndexOf('#', index) + 1;
                    name = profileString.Substring(index, profileString.IndexOf('\r', index) - index);

                    // get profile baudRate
                    index = profileString.IndexOf('#', index) + 1;
                    baudRate = Int32.Parse(profileString.Substring(index, profileString.IndexOf('\r', index) - index));

                    // get profile parity
                    index = profileString.IndexOf('#', index) + 1;
                    par = profileString.Substring(index, profileString.IndexOf('\r', index) - index);
                    if (par == "Even")
                        parity = 2;
                    else if (par == "Odd")
                        parity = 1;
                    else
                        // None parity
                        parity = 0;

                    // get profile dataBits
                    index = profileString.IndexOf('#', index) + 1;
                    dataBits = Int32.Parse(profileString.Substring(index, profileString.IndexOf('\r', index) - index));

                    // get profile stopBits
                    index = profileString.IndexOf('#', index) + 1;
                    stopBits = Int32.Parse(profileString.Substring(index, profileString.IndexOf('\r', index) - index));

                    // get profile default path
                    index = profileString.IndexOf('#', index) + 1;
                    defaultPath = profileString.Substring(index, profileString.IndexOf('\r', index) - index);

                    // get default COM port
                    index = profileString.IndexOf('#', index) + 1;
                    defaultPort = profileString.Substring(index, profileString.IndexOf('\r', index) - index);

                    // skip endProfile
                    index = profileString.IndexOf('#', index) + 1;

                    profiles.Add(new Profile(name, baudRate, parity, dataBits, stopBits, defaultPath, defaultPort));
                    index = profileString.IndexOf('#', index) + 1;
                }
            }
            catch
            {
                return 1;
            }
            return 0;
        }
        /*
         * This function stores new created profiles
         * in the .cfg file
         * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
         */
        public int storeProfile(Profile newProfile)
        {
            profiles.Add(newProfile);
            // parity to string
            string par;
            if (newProfile.Parity == 1)
            {
                par = "Odd";
            }
            else if (newProfile.Parity == 2)
            {
                par = "Even";
            }
            else
            {
                par = "None";
            }
            // create new profile file
            string newProfileText = newProfileText = string.Format("#{0}\r\n#{1}\r\n#{2}\r\n#{3}\r\n#{4}\r\n#{5}\r\n#{6}\r\n#endProfile\r\n\r\n#endOfFile",
                newProfile.Name, newProfile.BaudRate, par, newProfile.DataBits, newProfile.StopBits, newProfile.DefaultPath, newProfile.DefaultPort);
            profileString = profileString.Replace("#endOfFile", newProfileText);
            File.WriteAllText(profileFileName, profileString);
            return 0;
        }
        /*
         * dropProfile
         * This function deletes a profile
         * out of the cfg file
         */
        public int dropProfile(int toDropIndex)
        {
            int indexA = profileString.IndexOf("\r\n#" + profiles.ElementAt(toDropIndex).Name);
            int indexB = profileString.IndexOf("#endProfile\r\n", indexA);
            indexB += 13;
            profileString = profileString.Substring(0, indexA) + profileString.Substring(indexB);
            File.WriteAllText(profileFileName, profileString);
            profiles.RemoveAt(toDropIndex);
            return 0;
        }
        /*
         * profileExists
         * This function checks with the name
         * of the profile, if the profile already
         * exists
         */
        public bool profileExists(string toCompare)
        {
            foreach (Profile p in profiles)
            {
                if (p.Name == toCompare)
                {
                    return true;
                }
            }
            return false;
        }
    }
    /*
     * Profile
     * This class is used to store the different profiles
     */
    class Profile
    {
        string name;
        int baudRate;
        int parity;
        int dataBits;
        int stopBits;
        string defaultPort;
        string defaultPath;

        public Profile(string name, int baudRate, int parity, int dataBits, int stopBits, string defaultPath, string defaultPort)
        {
            this.name = name;
            this.baudRate = baudRate;
            this.parity = parity;
            this.dataBits = dataBits;
            this.stopBits = stopBits;
            this.defaultPath = defaultPath;
            this.defaultPort = defaultPort;
        }
        public string Name
        {
            get { return name; }
        }
        public int BaudRate
        {
            get { return baudRate; }
        }
        public int Parity
        {
            get { return parity; }
        }
        public int DataBits
        {
            get { return dataBits; }
        }
        public int StopBits
        {
            get { return stopBits; }
        }
        public string DefaultPort
        {
            get { return defaultPort; }
        }
        public string DefaultPath
        {
            get { return defaultPath; }
        }
    }
}
