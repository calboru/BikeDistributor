using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.CommonServices;

namespace BikeDistributor.Services.Common
{
    public class FileService: BaseService, IFileService
    {
        public string ReadAllText(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                LogService.Error(e);
                throw;
            }
        }
    }
}
