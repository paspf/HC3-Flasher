using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HC3_Flasher
{

    /// <summary>
    /// Holds a single profile.
    /// </summary>
    class Profile
    {
        string name;
        int baudRate;
        System.IO.Ports.Parity parity;
        int dataBits;
        System.IO.Ports.StopBits stopBits;
        string defaultPort;
        string defaultPath;

        public Profile(string name, int baudRate, System.IO.Ports.Parity parity, int dataBits, System.IO.Ports.StopBits stopBits, string defaultPath, string defaultPort)
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
        public System.IO.Ports.Parity Parity
        {
            get { return parity; }
        }
        public int DataBits
        {
            get { return dataBits; }
        }
        public System.IO.Ports.StopBits StopBits
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
