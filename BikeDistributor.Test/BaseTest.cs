using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.CommonServices;
using Moq;

namespace BikeDistributor.Test
{
    public class BaseTest
    {

        public Mock<ILogService> LogServiceMock { get; set; }

        public BaseTest()
        {
            LogServiceMock = new Mock<ILogService>();
            LogServiceMock.Setup(x => x.Error(It.IsAny<Exception>(), It.IsAny<string>()));
            LogServiceMock.Setup(x => x.Info(It.IsAny<string>()));
            LogServiceMock.Setup(x => x.Warn(It.IsAny<string>()));
        }
 
    }
}
