using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models.Common;
using BikeDistributor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BikeDistributor.Models;

namespace BikeDistributor.Test.Services
{
    [TestClass]
    public class DiscountServiceTest : BaseTest
    {
        private DiscountService _discountService;
        private OrderModel _orderModel;
      
        [TestInitialize]
        public void TestInitialize()
        {
            

            _discountService =
                new DiscountService() {LogService = LogServiceMock.Object};
        }

        public void CreateOrderModel(int productQuantity)
        {
            _orderModel = new OrderModel()
            {
                OrderLines = new List<OrderLineModel>()
                {
                    new OrderLineModel()
                    {
                        Quantity = productQuantity,
                        Product = new ProductModel()
                        {
                            Brand = "Brand1",
                            Msrp = 100
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void Calculates_GreaterThanEqualTo_Success()
        {
            //Arrange

            CreateOrderModel(100);
            _orderModel.DiscountCode = new DiscountCodeModel()
            {
                DiscountRate = 0.8,
                Flag = ">=",
                QuantityRange1 = 10
            };

            //Act
            var result = _discountService.CalculateDiscount(_orderModel);

            var discountedPrice = result.OrderLines.ToList()[0].Product.DiscountedPrice;


            //Assert
            Assert.IsTrue( discountedPrice == 80);

        }

        [TestMethod]
        public void Calculates_LessThanEqualTo_Success()
        {

            CreateOrderModel(10);
            //Arrange
            _orderModel.DiscountCode = new DiscountCodeModel()
            {
                DiscountRate = 0.8,
                Flag = "<=",
                QuantityRange1 = 10
            };

            //Act
            var result = _discountService.CalculateDiscount(_orderModel);

            var discountedPrice = result.OrderLines.ToList()[0].Product.DiscountedPrice;


            //Assert
            Assert.IsTrue( discountedPrice == 80);

        }


        [TestMethod]
        public void Calculates_Greater_Success()
        {

            CreateOrderModel(11);
            //Arrange
            _orderModel.DiscountCode = new DiscountCodeModel()
            {
                DiscountRate = 0.8,
                Flag = ">",
                QuantityRange1 = 10
            };

            //Act
            var result = _discountService.CalculateDiscount(_orderModel);

            var discountedPrice = result.OrderLines.ToList()[0].Product.DiscountedPrice;


            //Assert
            Assert.IsTrue(discountedPrice == 80);

        }


        [TestMethod]
        public void Calculates_Less_Success()
        {
            //Arrange
            CreateOrderModel(1);
            _orderModel.DiscountCode = new DiscountCodeModel()
            {
                DiscountRate = 0.8,
                Flag = "<",
                QuantityRange1 = 10
            };

            //Act
            var result = _discountService.CalculateDiscount(_orderModel);

            var discountedPrice = result.OrderLines.ToList()[0].Product.DiscountedPrice;


            //Assert
            Assert.IsTrue(discountedPrice == 80);

        }



        [TestMethod]
        public void Calculates_Range_Success()
        {

            //Arrange
            CreateOrderModel(3);
            _orderModel.DiscountCode = new DiscountCodeModel()
            {
                DiscountRate = 0.8,
                Flag = "RaNgE",
                QuantityRange1 = 1,
                QuantityRange2 = 5
            };

            //Act
            var result = _discountService.CalculateDiscount(_orderModel);

            var discountedPrice = result.OrderLines.ToList()[0].Product.DiscountedPrice;


            //Assert
            Assert.IsTrue(discountedPrice == 80);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_Flag_Throws_Exception()
        {

            //Arrange
            CreateOrderModel(3);
            _orderModel.DiscountCode = new DiscountCodeModel()
            {
                DiscountRate = 0.8,
                Flag = "sdfdsdfsdf",
                QuantityRange1 = 1,
                QuantityRange2 = 5
            };

            //Act
            var result = _discountService.CalculateDiscount(_orderModel);
            
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Throws_Exception_when_ordermodel_is_null()
        {
            //Act
            var result = _discountService.CalculateDiscount(null);
        }

        [TestMethod]
        public void Returns_OrderModel_When_No_DiscountCode_is_provided_Success()
        {
            //Arrange
            CreateOrderModel(1);
            _orderModel.DiscountCode = null;
       
            //Act
            var result = _discountService.CalculateDiscount(_orderModel);


            //Assert
            Assert.AreEqual(_orderModel, result);

        }



    }
}
