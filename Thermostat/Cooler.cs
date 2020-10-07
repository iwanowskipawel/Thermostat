using System;

namespace Thermostat
{
    class Cooler
    {
        public Cooler() { }
        public Cooler(int startTemperature) { StartTemperature = startTemperature; }

        public int StartTemperature { get; set; }

        public void OnTemperatureChanged(object sender, Thermostat.TemperatureArgs e)
        {
            if (e.NewTemperature > StartTemperature)
                Console.WriteLine("Chłodnica włączona!");
            else
                Console.WriteLine("Chłodnica wyłączona!");
        }
    }
}

