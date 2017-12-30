using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Models.Common;
using BikeDistributor.Services.Common;
using BikeDistributor.Services.Constants;

namespace BikeDistributor.Services
{
    public class DiscountService : BaseService, IDiscountService
    {

        private readonly IDataRepositoryService _dataRepositoryService;

        public DiscountService(IDataRepositoryService dataRepositoryService)
        {
            _dataRepositoryService = dataRepositoryService;
        }

        public OrderModel CalculateDiscount(OrderModel orderModel)
        {
            var calculatedOrderLines = new List<OrderLineModel>();
            var discountCodeModel = _dataRepositoryService.GetOne<DiscountCodeModel, DiscountCode>(d => d.Id == orderModel.DiscountCode.Id);
            if (discountCodeModel != null)
            {
                calculatedOrderLines.AddRange(orderModel.Products.Select(orderLine => ApplyDiscount(orderLine, discountCodeModel)));
            }
            orderModel.Products = calculatedOrderLines;
            return orderModel;
        }
     
        public OrderLineModel ApplyDiscount(OrderLineModel orderLineModel, DiscountCodeModel discountCodeModel)
        {

            switch (discountCodeModel.Flag.ToLower())
            {
                case ">=":
                    if (orderLineModel.Quantity >= discountCodeModel.QuantityRange1)
                    {
                        orderLineModel.FinalPrice = orderLineModel.Product.Msrps * discountCodeModel.DiscountRate;
                    }
                    break;
                case "<=":
                    if (orderLineModel.Quantity <= discountCodeModel.QuantityRange1)
                    {
                        orderLineModel.FinalPrice = orderLineModel.Product.Msrps * discountCodeModel.DiscountRate;
                    }
                    break;
                case ">":
                    if (orderLineModel.Quantity > discountCodeModel.QuantityRange1)
                    {
                        orderLineModel.FinalPrice = orderLineModel.Product.Msrps * discountCodeModel.DiscountRate;
                    }
                    break;
                case "<":
                    if (orderLineModel.Quantity < discountCodeModel.QuantityRange1)
                    {
                        orderLineModel.FinalPrice = orderLineModel.Product.Msrps * discountCodeModel.DiscountRate;
                    }
                    break;
                case "range":
                    if (orderLineModel.Quantity >= discountCodeModel.QuantityRange1 && orderLineModel.Quantity <= discountCodeModel.QuantityRange2)
                    {
                        orderLineModel.FinalPrice = orderLineModel.Product.Msrps * discountCodeModel.DiscountRate;
                    }

                    break;
                default:
                    var errorMessage =
                        $"Invalid discount flag for {discountCodeModel.Flag} !";

                    LogService.Error(errorMessage);
                    throw new ArgumentException(errorMessage);

            }

            return orderLineModel;
        }
    }
}
