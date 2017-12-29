using System;

namespace BikeDistributor.Interfaces.CommonServices
{
    public interface IRandomValueService
    {
        string PickOneString (string separatedValues, char separator);
        int RandomInt (int min, int max);
        double RandomDouble(double min, double max);
        Guid RandomGuid();

    }
}
