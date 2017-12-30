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

namespace BikeDistributor.Services
{
    public class OrderService
    {
        private readonly IDataRepositoryService _dataRepositoryService;
        private readonly IDiscountService _discountService;

        public OrderService(IDataRepositoryService dataRepositoryService, IDiscountService discountService)
        {
            _dataRepositoryService = dataRepositoryService;
            _discountService = discountService;
        }

        public OrderModel GetOne(Expression<Func<Order, bool>> filter = null, string includeProperties = null)
        {
            _dataRepositoryService.GetOne<OrderModel, Order>(filter, includeProperties);
        }

    }
}
