using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Services.Data;
using BikeDistributor.Services.Common;
using Unity.Interception.Utilities;

namespace BikeDistributor.Services
{
    public class OrderService: BaseService, IOrderService
    {
        private readonly IDataRepositoryService _dataRepositoryService;
        private readonly IDiscountService _discountService;

        public OrderService(IDataRepositoryService dataRepositoryService, IDiscountService discountService)
        {
            _dataRepositoryService = dataRepositoryService;
            _discountService = discountService;
        }

        public virtual OrderModel CalculateTotals(OrderModel orderModel)
        {
            if (orderModel.OrderedBy.Location == null)
            {
                var err = $"Location info was not found for {orderModel.OrderedBy.CompanyName}";
                LogService.Error(err);
                throw new Exception(err);
            }

            var location = orderModel.OrderedBy.Location.SingleOrDefault(x => x.Type == "Billing");
            if (location == null)
            {
                var err = $"Billing info was not found for {orderModel.OrderedBy.CompanyName}";
                LogService.Error(err);
                throw new Exception(err);
            }

            foreach (var orderLineModel in orderModel.Products)
            {
                if (orderLineModel.Product.DiscountedPrice.Equals(0))
                {
                    orderLineModel.Product.DiscountedPrice = orderLineModel.Product.Msrp;
                }

                orderLineModel.Product.TaxedPrice = orderLineModel.Product.DiscountedPrice * (1 + location.TaxRate);

                orderModel.TaxTotal += orderLineModel.Product.TaxedPrice * orderLineModel.Quantity -
                                       orderLineModel.Product.DiscountedPrice;
                orderModel.SubTotal += orderLineModel.Product.TaxedPrice * orderLineModel.Quantity;
            }

            return orderModel;
        }

        public virtual OrderModel GetOne(Expression<Func<Order, bool>> filter = null, string includeProperties = null)
        {
           var dbResult =  _dataRepositoryService.GetOne<OrderModel, Order>(filter, includeProperties);
           var discountedResult = _discountService.CalculateDiscount(dbResult);
           var calculatedResult = CalculateTotals(discountedResult);
           return calculatedResult;
        }

    }
}
