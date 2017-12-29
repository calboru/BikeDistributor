using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Data.Interfaces.Common
{
    public interface IRandomValueService
    {
        string PickOneString (string separatedValues, char separator);
        int RandomInt (int min, int max);
        double RandomDouble(double min, double max);
        Guid RandomGuid();

    }
}
