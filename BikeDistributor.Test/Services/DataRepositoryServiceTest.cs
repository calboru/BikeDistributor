using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using BikeDistributor.Data.Interfaces.Common;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Models;
using BikeDistributor.Services.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BikeDistributor.Test.Services
{
    [TestClass]
    public class DataRepositoryServiceTest: BaseTest
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<IEntityMappingService> _mappingServiceMock;

        private DataRepositoryService _dataRepositoryService;

        [TestInitialize]
        public void Initialize()
        {
            _repositoryMock = new Mock<IRepository>();
            _mappingServiceMock = new Mock<IEntityMappingService>();

            _dataRepositoryService = new DataRepositoryService
            {
                LogService = LogServiceMock.Object,
                Repository = _repositoryMock.Object,
                EntityMapperService = _mappingServiceMock.Object
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

            var order = new Order()
            {
                Id = 1,
                DiscountCode = new DiscountCode()
                {
                    Id = 1,
                    CampainCode = "20Down",
                    Flag = ">",
                    QuantityRange1 = 10
                },
                OrderedBy = new BusinessEntity()
                {
                    CompanyName = "Company1",
                    Location = new List<Location>()
                    {
                        new Location()
                        {
                            Id = 1,
                            Type = "Billing",
                            TaxRate = 0.01
                        }
                    }
                },
                Products = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        OrderId = 1, Quantity = 100 ,
                        Product =   new Product()
                        {
                            Brand = "Brand",
                            Msrp = 100
                        }
                    }
                }

            };


            //Act
            _repositoryMock.Setup(x => x.GetOne(It.IsAny<Expression<Func<Order, bool>>>(), null)).Returns(order);
            _mappingServiceMock.Setup(x => x.Map<Order, OrderModel>(order)).Returns(orderModel);

            //Assert
            var result = _dataRepositoryService.GetOne<OrderModel, Order>(x => x.Id == 1);

            Assert.IsNotNull(result);

        }

    }
}
