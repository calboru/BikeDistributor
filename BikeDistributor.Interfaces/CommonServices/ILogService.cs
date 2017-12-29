using System;
using BikeDistributor.Interfaces.Shared;

namespace BikeDistributor.Interfaces.CommonServices
{
    public interface ILogService
    {
        void Error(Exception ex, string additionalInfo = "");
        void Error(string message);
        void Info(string message);
        void Info(IEntity entity);
        void Warn(string message);

    }
}
