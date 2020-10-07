using System;
using System.Collections.Generic;

namespace Thermostat
{
    class Thermostat
    {
        public class TemperatureArgs : System.EventArgs
        {
            public TemperatureArgs(int newTemperature)
            {
                NewTemperature = newTemperature;
            }
            public int NewTemperature { get; set; }
        }

        public Thermostat() { }
        public Thermostat(int currentTemperature)
        {
            CurrentTemperature = currentTemperature;
        }

        public event EventHandler<TemperatureArgs> OnTemperatureChange = delegate { };

        public int CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                if (value != CurrentTemperature)
                {
                    _currentTemperature = value;
                    Console.WriteLine($"Zmieniono aktualną temperaturę na {CurrentTemperature} stopni");
                    EventHandler<TemperatureArgs> onTemperatureChange = OnTemperatureChange;
                    if (onTemperatureChange != null)
                    {
                        List<Exception> exceptionCollection =
                            new List<Exception>();
                        foreach (EventHandler<TemperatureArgs> handler in
                            onTemperatureChange.GetInvocationList())
                        {
                            try
                            {
                                handler(this, new Thermostat.TemperatureArgs(value));
                            }
                            catch (Exception exception)
                            {
                                exceptionCollection.Add(exception);
                            }
                        }
                        if (exceptionCollection.Count > 0)
                        {
                            //throw new AggregateException(
                            //    "Wystąpił wyjątek",
                            //    exceptionCollection);
                            //OnTemperatureChange(value);
                            foreach (Exception exception in exceptionCollection)
                                Console.WriteLine(exception.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podana temperatura jest taka sama jak poprzednia. Brak Akcji.");
                    }
                }
            }
        }
        private int _currentTemperature;
    }
}

