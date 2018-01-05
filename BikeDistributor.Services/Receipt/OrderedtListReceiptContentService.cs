using BikeDistributor.Interfaces.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using BikeDistributor.Interfaces;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Services.Common;

namespace BikeDistributor.Services.Receipt
{
    public  class OrderedtListReceiptContentService:BaseService, IReceiptContentService
    {
        private readonly IOrderService _orderService;

        public OrderedtListReceiptContentService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public string Generate(
            int orderId, 
            string classForOrderLineContainer, 
            string classForOrderLine, 
            string classForSubTotalContainer, 
            string classForSubTotalLines)
        {
            try
            {
                var sb = new StringBuilder();
                var orderModel = _orderService.GetOne(o => o.Id == orderId);

                PrintOrderLines(sb, orderModel, classForOrderLineContainer, classForOrderLine, classForSubTotalContainer, classForSubTotalLines);

                PrintSubTotals(classForSubTotalContainer, classForSubTotalLines, sb, orderModel);

                return sb.ToString();
            }
            catch (Exception e)
            {
                LogService.Error(e);
                throw;
            }
        }

        private static void PrintSubTotals(string classForSubTotalContainer, string classForSubTotalLines, StringBuilder sb,
            OrderModel orderModel)
        {
            sb.Append($"<ul class='{classForSubTotalContainer}'>");

            sb.Append($"<li class='{classForSubTotalLines}'");
            sb.Append($"Total Discount:{orderModel.DiscountTotal}");
            sb.Append("</li>");

            sb.Append($"<li class='{classForSubTotalLines}'");
            sb.Append($"Total Tax: {orderModel.TaxTotal}");
            sb.Append("</li>");

            sb.Append($"<li class='{classForSubTotalLines}'");
            sb.Append($"Sub Total: {orderModel.SubTotal}");
            sb.Append("</li>");

            sb.Append("</ul>");
        }

        private void PrintOrderLines(StringBuilder sb, OrderModel orderModel, string ulClassForOrderLine, string liClassForOrderLine, string ulClassForSubTotals, string liClassForSubTotals)
        {
            sb.Append($"<ul class='{ulClassForOrderLine}'>");

            foreach (var orderLineModel in orderModel.OrderLines)
            {
                sb.Append($"<li class='{liClassForOrderLine}'>");
                var receiptLine =
                    $"SKU:{orderLineModel.Product.Sku}  Brand:{orderLineModel.Product.Brand} Make: {orderLineModel.Product.Make} Model:{orderLineModel.Product.Model} Msrp:{orderLineModel.Product.Msrp} Discounted Price:{orderLineModel.Product.DiscountedPrice} Quantity:{orderLineModel.Quantity}";
               sb.Append(receiptLine);
                sb.Append("</li>");
            }
            sb.Append("</ul>");
        }
    }
}
