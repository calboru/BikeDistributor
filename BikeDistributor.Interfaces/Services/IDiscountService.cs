using BikeDistributor.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace BikeDistributor.Interfaces.Services
{
    public interface IDiscountService
    {
        OrderModel CalculateDiscount(OrderModel orderModel);
        double ApplyDiscount(OrderLineModel orderLineModel, DiscountCodeModel discountCodeModel);
    }
}
