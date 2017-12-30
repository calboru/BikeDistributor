using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Shared.Interfaces;

namespace BikeDistributor.Services.Common
{
    public class LogService : ILogService
    {
        public void Error(Exception ex, string additionalInfo = "")
        {
            Console.WriteLine(ex.Message);
        }

        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(IEntity entity)
        {
            if (entity != null)
            {
                Console.Write(
                    $@"{entity.ToString()} has been created by succesfully");
            }
        }

        public void Warn(string message)
        {
            Console.WriteLine(message);
        }
    }
}
