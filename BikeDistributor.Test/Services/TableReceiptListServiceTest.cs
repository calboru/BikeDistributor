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
            var b = "";

            Assert.IsTrue(a.Equals(b));
        }

    }
}
