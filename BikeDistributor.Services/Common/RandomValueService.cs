using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.CommonServices;

namespace BikeDistributor.Services.Common
{
    public class RandomValueService: IRandomValueService
    {
        readonly Random _random = new Random();

        public string RandomString(string separatedValues, char separator)
        {
            if (!separatedValues.Contains(separator)) return string.Empty;
            var values = separatedValues.Split(separator);
            var index =  _random.Next(0, values.Length);
            return values[index].Trim();
        }

        public int RandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }

        public double RandomDouble(int min, int max)
        {
            var val = 0.0;

            while (val >= min || val <= max)
            {
                var r = _random.NextDouble();
                var m = _random.Next(min, max);
                val = r + m;
                return val;
            }

            return val;
        }

        public Guid RandomGuid()
        {
            return new Guid();
        }
    }
}
