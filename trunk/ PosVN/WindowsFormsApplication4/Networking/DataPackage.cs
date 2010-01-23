using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net.Sockets;

namespace WindowsFormsApplication4.Networking
{
    [Serializable]
    public class DataPackage
    {
        [NonSerialized]
        public Socket Socket;
        [NonSerialized]
        public ArrayList TransmissionBuffer = new ArrayList();
        [NonSerialized]
        public byte[] buffer = new byte[1024];

        //Properties
        //Return value

        public byte header { get; set; }
        public byte content { get; set; }
        //Usually you shouldn't put these 2 methods in your class because they don't operate specifically on this object
        //and we would get a lot of duplicate code if we would put those 2 methods in each class we would like to
        //be able to send but to not wind up having to write a couple of utility classes (where these should reside)
        // I let them reside here for now.
        public byte[] Serialize()
        {
            BinaryFormatter bin = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            bin.Serialize(mem, this);
            return mem.GetBuffer();
        }

        public DataPackage DeSerialize()
        {
            byte[] dataBuffer = (byte[])TransmissionBuffer.ToArray(typeof(byte));
            BinaryFormatter bin = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            mem.Write(dataBuffer, 0, dataBuffer.Length);
            mem.Seek(0, 0);
            return (DataPackage)bin.Deserialize(mem);
        }
    }
}
