using System;
using System.Linq;
using System.Text;

namespace Thermostat
{
    class Program
    {
        static void Main(string[] args)
        {
            Cooler cooler = new Cooler(95);
            Heater heater = new Heater(40);
            Thermostat thermostat = new Thermostat();
            string input;
            int currentTemperature = 55; 

            thermostat.OnTemperatureChange += heater.OnTemperatureChanged;
            //thermostat.OnTemperatureChange += (newTemperature) => { throw new InvalidOperationException(); };
            thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;
            thermostat.CurrentTemperature = currentTemperature;
            
            do
            {
                Console.WriteLine("\nPodaj temperaturę termostatu (x - zamyka program)");
                input = Console.ReadLine();
                if (int.TryParse(input, out currentTemperature))
                    thermostat.CurrentTemperature = currentTemperature;

            } while (input != "x");
        }
    }
}

