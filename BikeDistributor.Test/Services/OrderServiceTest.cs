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
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BikeDistributor.Test.Services
{
    [TestClass]
    public class OrderServiceTest : BaseTest
    {
        private Mock<IDataRepositoryService> _dataRepositoryService;
        private Mock<IDiscountService> _discountService;
        private IOrderService _orderService;

        [TestInitialize]
        public void Initialize()
        {

            _dataRepositoryService = new Mock<IDataRepositoryService>();
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
                OrderLines = new List<OrderLineModel>()
                {
                    new OrderLineModel()
                    {
                        OrderId = 1,
                        Quantity = 1 ,
                        Product =   new ProductModel()
                        {
                            Brand = "Brand",
                            Msrp = 100
                        }
                    }
                  }

            };
             
            //Act
            _dataRepositoryService.Setup(y => y.GetOne<OrderModel, Order>(It.IsAny<Expression <Func<Order, bool>>>(), null)).Returns(() => orderModel);
            _discountService.Setup(x => x.CalculateDiscount(It.IsAny<OrderModel>())).Returns(() => orderModel);

            var result =  _orderService.GetOne(x => x.Id == 1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CalculateTotals_Success()
        {
            var orderModel = new OrderModel()
            {
                Id = 1,
                DiscountCode = new DiscountCodeModel()
                {
                    Id = 1,
                    CampainCode = "20Down",
                    Flag = ">",
                    QuantityRange1 = 10,
                    DiscountRate = .80
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
                            TaxRate = 0.1
                        }
                    }
                },
                OrderLines = new List<OrderLineModel>()
                {
                    new OrderLineModel()
                    {
                        OrderId = 1,
                        Quantity = 1,
                        Product =   new ProductModel()
                        {
                            Brand = "Brand",
                            Msrp = 100
                        }
                    }
                }

            };

            _discountService.Setup(x => x.CalculateDiscount(It.IsAny<OrderModel>())).Returns(() => orderModel);


            //System and method under test
            var result = _orderService.CalculateTotals(orderModel);
            
            var taxedPrice = result.OrderLines.ToList()[0].Product.TaxedPrice;
            var discountedPrice = result.OrderLines.ToList()[0].Product.DiscountedPrice;

            Assert.IsTrue((int)taxedPrice == 110);
            Assert.IsTrue((int)discountedPrice == 100); //No discount provided in line #134 therefore Msrp should be returned
            Assert.IsTrue((int)orderModel.TaxTotal == 10);
            Assert.IsTrue((int)orderModel.SubTotal == 110);


        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateTotals_Throws_Exception_When_Location_is_not_provided()
        {

            var orderModel = new OrderModel()
            {
                Id = 1,
                DiscountCode = new DiscountCodeModel()
                {
                    Id = 1,
                    CampainCode = "20Down",
                    Flag = ">",
                    QuantityRange1 = 10,
                    DiscountRate = .80
                },
                OrderedBy = new BusinessEntityModel()
                {
                    CompanyName = "Company1",
                    Location = null //Null should throw an exception
                },
                OrderLines = new List<OrderLineModel>()
                {
                    new OrderLineModel()
                    {
                        OrderId = 1,
                        Quantity = 1,
                        Product =   new ProductModel()
                        {
                            Brand = "Brand",
                            Msrp = 100
                        }
                    }
                }

            };

            _discountService.Setup(x => x.CalculateDiscount(It.IsAny<OrderModel>())).Returns(() => orderModel);

            //System and method under test
            var result = _orderService.CalculateTotals(orderModel);

        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateTotals_Throws_Exception_When_Billing_Location_is_not_provided()
        {

            var orderModel = new OrderModel()
            {
                Id = 1,
                DiscountCode = new DiscountCodeModel()
                {
                    Id = 1,
                    CampainCode = "20Down",
                    Flag = ">",
                    QuantityRange1 = 10,
                    DiscountRate = .80
                },
                OrderedBy = new BusinessEntityModel()
                {
                    CompanyName = "Company1",
                    Location = new List<LocationModel>() //Empty location
                },
                OrderLines = new List<OrderLineModel>()
                {
                    new OrderLineModel()
                    {
                        OrderId = 1,
                        Quantity = 1,
                        Product =   new ProductModel()
                        {
                            Brand = "Brand",
                            Msrp = 100
                        }
                    }
                }

            };

            _discountService.Setup(x => x.CalculateDiscount(It.IsAny<OrderModel>())).Returns(() => orderModel);

            //System and method under test
            var result = _orderService.CalculateTotals(orderModel);

        }


    }
}
