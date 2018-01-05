using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using BikeDistributor.Models;

namespace BikeDistributor.Interfaces.Services
{
    public interface IOrderService
    {
        OrderModel CalculateTotals(OrderModel orderModel);
        OrderModel GetOne(Expression<Func<Order, bool>> filter = null, string includeProperties = null);
        void Create(OrderModel orderModel, string createdBy = null);
    }
}
