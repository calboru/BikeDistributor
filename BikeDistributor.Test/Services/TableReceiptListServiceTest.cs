using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Services.Receipt;

namespace BikeDistributor.Test.Services
{

    [TestClass]
    public class TableReceiptListServiceTest: BaseTest
    {
        private Mock<IOrderService> _orderServiceMock;
        private TableListReceiptContentService _tableReceiptListService;

        [TestInitialize]
        public void Initialize()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _tableReceiptListService = new TableListReceiptContentService(_orderServiceMock.Object)
            {
                LogService = LogServiceMock.Object
            };
        }

        [TestMethod]
        public void Generate_Success()
        {
            var orderModel = DummyData.DummyOrderModel();
            _orderServiceMock.Setup(y => y.GetOne(It.IsAny<Expression<Func<Order, bool>>>(), null)).Returns(() => orderModel);
            var a = _tableReceiptListService.Generate(1, "OrderItems", "OrderItem", "SubTotals", "SubTotalItem");
            var b = "<table class='OrderItems'><tr><th>Sku</th><th>Brand</th><th>Make</th><th>Model</th><th>Msrp</th><th>Discounted Price</th><th>Quantity</th></tr><tr class='OrderItem'><td></td><td>Bike1</td><td>2018</td><td>Bike1-Model</td><td>100</td><td>0</td><td>1</td></tr><tr class='OrderItem'><td></td><td>Bike2</td><td>2018</td><td>Bike2-Model</td><td>100</td><td>0</td><td>1</td></tr></table><table class='SubTotals'><tr><th>Total Discount</th><th>Total Tax</th><th>Sub total</th></tr><tr class='SubTotalItem'><td>0</td><td>0</td><td>0</td></tr></table>";

            Assert.IsTrue(a.Equals(b));
        }

    }
}
