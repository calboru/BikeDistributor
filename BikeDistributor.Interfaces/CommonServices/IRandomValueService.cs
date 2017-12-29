using System;

namespace BikeDistributor.Interfaces.CommonServices
{
    public interface IRandomValueService
    {
        string RandomString (string separatedValues, char separator);
        int RandomInt (int min, int max);
        double RandomDouble(int min, int max);
        Guid RandomGuid();

    }
}
