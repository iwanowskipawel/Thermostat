using System;

namespace Thermostat
{
    class Heater
    {
        public Heater() { }
        public Heater(int startTemperature) { StartTemperature = startTemperature; }

        public int StartTemperature { get; set; }

        public void OnTemperatureChanged(object sender, Thermostat.TemperatureArgs e)
        {
            if (e.NewTemperature < StartTemperature)
                Console.WriteLine("Nagrzewnica włączona!");
            else
                Console.WriteLine("Nagrzewnica wyłączona!");
        }
    }
}

