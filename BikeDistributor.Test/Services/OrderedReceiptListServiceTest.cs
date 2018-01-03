using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using BikeDistributor.Interfaces;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Services.Receipt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BikeDistributor.Test.Services
{
    [TestClass]
    public class OrderedReceiptListServiceTest:BaseTest
    {
        private Mock<IOrderService> _orderServiceMock;
        private OrderedReceiptListService _orderedReceiptListService;
        
        [TestInitialize]
        public void Initialize()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _orderedReceiptListService = new OrderedReceiptListService(_orderServiceMock.Object)
            {
                LogService = LogServiceMock.Object
            };
        }

        [TestMethod]
        public void Generate_Success()
        {
            var orderModel = DummyData.DummyOrderModel();
            
            _orderServiceMock.Setup(y => y.GetOne(It.IsAny<Expression<Func<Order, bool>>>(), null)).Returns(() => orderModel);
            var a = _orderedReceiptListService.Generate(1, "OrderItems", "OrderItem", "SubTotals", "SubTotalItem");

            const string b =
                "<ul class='OrderItems'><li class='OrderItem'>SKU:  Brand:Bike1 Make: 2018 Model:Bike1-Model Msrp:100 Discounted Price:0 </li><li class='OrderItem'>SKU:  Brand:Bike2 Make: 2018 Model:Bike2-Model Msrp:100 Discounted Price:0 </li></ul><ul class='SubTotals'><li class='SubTotalItem'Total Discount:0</li><li class='SubTotalItem'Total Tax: 0</li><li class='SubTotalItem'Sub Total: 0</li></ul>";

            Assert.IsTrue(a.Equals(b));
        }

    }
}
