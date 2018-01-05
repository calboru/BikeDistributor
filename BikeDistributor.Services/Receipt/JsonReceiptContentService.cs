using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Services.Common;

namespace BikeDistributor.Services.Receipt
{
    public class JsonReceiptContentService: BaseService, IReceiptContentService
    {
        private readonly IOrderService _orderService;
        private readonly IJsonSerializerService _jsonSerializerService;
        
        public JsonReceiptContentService(IOrderService orderService, IJsonSerializerService jsonSerializerService)
        {
            _orderService = orderService;
            _jsonSerializerService = jsonSerializerService;
        }

        public string Generate(int orderId, string classForOrderLineContainer, string classForOrderLine,
            string classForSubTotalContainer, string classForSubTotalLines)
        {
            try
            {
                var orderModel = _orderService.GetOne(o => o.Id == orderId);

                return _jsonSerializerService.SerializeObject(orderModel);
            }
            catch (Exception e)
            {
                LogService.Error(e);
                throw;
            }
        }
    }
}
