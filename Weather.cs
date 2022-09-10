using System;

namespace MedicalStoreManagementSystem
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public string day { get; set; }
		public string year { get; set; }
<<<<<<< HEAD
        public string month { get; set; }
=======
        public string week { get; set; }
>>>>>>> develop
    }
}
