using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DLL_Library_Lab2.Models;
using Newtonsoft.Json;

namespace Console_Application_Lab2
{
    class Program 
    {
        static Random r = new Random();
        
        static void Main(string[] args)
        {
            List<MeasuringChannel> mc = GetSomeRandomMeasuringChannels();

            File.WriteAllText("json.txt", JsonConvert.SerializeObject(mc));

            List<MeasuringChannel> nmc = JsonConvert.DeserializeObject<List<MeasuringChannel>>(File.ReadAllText("json.txt"));

            for (int i = 0; i < nmc.Count; i++)
                Console.WriteLine(nmc[i].ToString());
        }
        static public List<MeasuringChannel> GetSomeRandomMeasuringChannels()
        {
            List<MeasuringChannel> mc = new List<MeasuringChannel>();

            for (int i = 0; i < r.Next(1,5); i++)
                mc.Add(new MeasuringChannel(GetSomeRandomDevices()));

            return mc;
        }
        static public List<Device> GetSomeRandomDevices()
        {
            List<Device> devices = new List<Device>();

            for (int i = 0; i < r.Next(1, 5); i++)
                devices.Add(new Device(GetRandomSensor(), r.Next(4, 10), new DateTime(r.Next(2014, 2023), r.Next(1, 13), r.Next(1, 28))));

            return devices;
        }
        static public Sensor GetRandomSensor() => new Sensor((QuantityType) r.Next(1, 5), r.Next(0, 6), r.Next(10, 500), r.Next(0, 500));
    }
}
