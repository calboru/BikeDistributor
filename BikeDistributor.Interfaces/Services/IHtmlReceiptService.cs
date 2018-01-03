using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Interfaces.Services
{
    public interface IHtmlReceiptService
    {
        string Output(int orderId, int templateId, string token);
    }
}
