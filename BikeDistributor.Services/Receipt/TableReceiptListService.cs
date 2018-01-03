using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Services.Common;

namespace BikeDistributor.Services.Receipt
{
    public class TableReceiptListService: BaseService, IReceiptContentService
    {
        private readonly IOrderService _orderService;

        public TableReceiptListService(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public string Generate(int orderId, string classForOrderLineContainer, string classForOrderLine,
            string classForSubTotalContainer, string classForSubTotalLines)
        {
            var sb = new StringBuilder();
            var orderModel = _orderService.GetOne(o => o.Id == orderId);

            sb.Append($"<table class='{classForOrderLineContainer}'>");
            PrintHeader(sb);

            PrintContent(classForOrderLine, orderModel, sb);

            sb.Append("</table>");

            PrintSubTotals(classForSubTotalContainer, classForSubTotalLines, sb, orderModel);

            return sb.ToString();
        }

        private static void PrintSubTotals(string classForSubTotalContainer, string classForSubTotalLines, StringBuilder sb,
            OrderModel orderModel)
        {
            sb.Append($"<table class='{classForSubTotalContainer}'>");

            sb.Append("<tr>");
            sb.Append("<th>Total Discount</th>");
            sb.Append("<th>Total Tax</th>");
            sb.Append("<th>Sub total</th>");
            sb.Append("</tr>");

            sb.Append($"<tr class='{classForSubTotalLines}'>");
            sb.Append($"<td>{orderModel.DiscountTotal}</td>");
            sb.Append($"<td>{orderModel.TaxTotal}</td>");
            sb.Append($"<td>{orderModel.SubTotal}</td>");
            sb.Append("</tr>");

            sb.Append("</table>");
        }

        private static void PrintContent(string classForOrderLine, OrderModel orderModel, StringBuilder sb)
        {
            foreach (var orderLine in orderModel.Products)
            {
                sb.Append($"<tr class='{classForOrderLine}'>");
                sb.Append($"<td>{orderLine.Product.Sku}</td>");
                sb.Append($"<td>{orderLine.Product.Brand}</td>");
                sb.Append($"<td>{orderLine.Product.Make}</td>");
                sb.Append($"<td>{orderLine.Product.Model}</td>");
                sb.Append($"<td>{orderLine.Product.Msrp}</td>");
                sb.Append($"<td>{orderLine.Product.DiscountedPrice}</td>");
                sb.Append("</tr>");
            }
        }

        private static void PrintHeader(StringBuilder sb)
        {
            sb.Append("<tr>");
            sb.Append("<th>Sku</th>");
            sb.Append("<th>Brand</th>");
            sb.Append("<th>Make</th>");
            sb.Append("<th>Model</th>");
            sb.Append("<th>Msrp</th>");
            sb.Append("<th>Discounted Price</th>");
            sb.Append("</tr>");
        }
    }
}
