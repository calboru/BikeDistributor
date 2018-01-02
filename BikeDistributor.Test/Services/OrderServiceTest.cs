using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using BikeDistributor.Data.Interfaces.Common;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BikeDistributor.Test.Services
{
    [TestClass]
    public class OrderServiceTest : BaseTest
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<IEntityMappingService> _mappingServiceMock;

        private Mock<IDataRepositoryService> _dataRepositoryService;
        private Mock<IDiscountService> _discountService;
        private IOrderService _orderService;

        [TestInitialize]
        public void Initialize()
        {

            _repositoryMock = new Mock<IRepository>();
            _mappingServiceMock = new Mock<IEntityMappingService>();
            _dataRepositoryService = new Mock<IDataRepositoryService>();


            _dataRepositoryService.Object.Repository = _repositoryMock.Object;
            _dataRepositoryService.Object.EntityMapperService = _mappingServiceMock.Object;

            _discountService = new Mock<IDiscountService>();
            _orderService = new OrderService(_dataRepositoryService.Object, _discountService.Object)
            {
                LogService = LogServiceMock.Object
            };
        }

        [TestMethod]
        public void GetOne_Success()
        {
            //Arrange
          
            var orderModel = new OrderModel()
            {
                Id = 1,
                DiscountCode = new DiscountCodeModel()
                {
                    Id = 1,
                    CampainCode = "20Down",
                    Flag = ">",
                    QuantityRange1 = 10
                },
                OrderedBy = new BusinessEntityModel()
                {
                    CompanyName = "Company1",
                    Location = new List<LocationModel>()
                    {
                        new LocationModel()
                        {
                            Id = 1,
                            Type = "Billing",
                            TaxRate = 0.01
                        }
                    }
                },
                Products = new List<OrderLineModel>()
                {
                    new OrderLineModel()
                    {
                        OrderId = 1, Quantity = 100 ,
                        Product =   new ProductModel()
                        {
                            Brand = "Brand",
                            Msrp = 100
                        }
                    }
                  }

            };
            
            //Act

            _repositoryMock.Setup(x => x.GetOne(It.IsAny<Expression<Func<Order, bool>>>(), "")).Returns(new Order());
            
            _dataRepositoryService.Setup(y => y.GetOne<OrderModel, Order>(It.IsAny<Expression <Func<Order, bool>>>(), "")).Returns(() => orderModel);
            var result =  _orderService.GetOne(x => x.Id == 1);


            Assert.IsNotNull(result);
        }
    }
}
