//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BikeDistributor.Interfaces.CommonServices;
//using BikeDistributor.Interfaces.Services;
//using BikeDistributor.Models.Common;
//using BikeDistributor.Models.Interfaces;
//using BikeDistributor.Services;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace BikeDistributor.Test.Services
//{
//    [TestClass]
//   public class DiscountServiceTest: BaseTest
//    {
//        private Mock<IJsonSerializerService> _jsonSerializerServiceMock;
//        private Mock<IAppSettingsService> _appSettingsServiceMock;
//        private Mock<IFileService> _fileServiceMock;
//        private DiscountService _discountService;
//        private List<DiscountCodeModel> _discountRules;
        

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            _jsonSerializerServiceMock = new Mock<IJsonSerializerService>();
//            _appSettingsServiceMock = new Mock<IAppSettingsService>();
//            _fileServiceMock = new Mock<IFileService>();

//            _discountRules = new List<DiscountCodeModel>()
//            {
//                 new DiscountCodeModel()
//                 {
//                     DiscountRate = 0.8,
//                     Id = "1000",
//                     Flag = ">=",
//                     QuantityRange1 = 100,
//                     QuantityRange2 = 0
//                 },
//                new DiscountCodeModel() {
//                    DiscountRate = 0.7,
//                    Id = "2000",
//                    Flag = "<=",
//                    QuantityRange1 = 100,
//                    QuantityRange2 = 0
//                },
//                new DiscountCodeModel() {
//                    DiscountRate = 0.6,
//                    Id = "3000",
//                    Flag = ">",
//                    QuantityRange1 = 200,
//                    QuantityRange2 = 0
//                },
//                new DiscountCodeModel() {
//                    DiscountRate = 0.5,
//                    Id = "4000",
//                    Flag = "<",
//                    QuantityRange1 = 200,
//                    QuantityRange2 = 0
//                },
//                new DiscountCodeModel() {
//                    DiscountRate = 0.4,
//                    Id = "5000",
//                    Flag = "RaNgE",
//                    QuantityRange1 = 100,
//                    QuantityRange2 = 200
//                },
//                new DiscountCodeModel() {
//                DiscountRate = 0.8,
//                Id = "6000",
//                Flag = "Invalid Flag which will throw an exception",
//                QuantityRange1 = 200,
//                QuantityRange2 = 0
//            }

//            };

//            _discountService = new DiscountService(_jsonSerializerServiceMock.Object, _appSettingsServiceMock.Object,
//                _fileServiceMock.Object) {DiscountRules = _discountRules, LogService = this.LogServiceMock.Object};

//        }

//        [TestMethod]
//        public void Calculates_Bigger_Than_EqualTo_Success()
//        {
//            //arrange
//            IProductModel product = new ProductModel() { 
//                DiscountRuleCode = "1000",
//                BasePrice = 100,
//                Quantity = 2000
//            };
//            //act
//            var calculatedProduct = _discountService.CalculateDiscount(product);

//            //assert
//            Assert.IsTrue(calculatedProduct.FinalPrice == 80);
//        }


//        [TestMethod]
//        public void Calculates_LessThanEqualTo_Success()
//        {
//            //arrange
//            IProductModel product = new ProductModel()
//            {
//                DiscountRuleCode = "2000",
//                BasePrice = 100,
//                Quantity = 99
//            };
//            //act
//            var calculatedProduct = _discountService.CalculateDiscount(product);

//            //assert
//            Assert.IsTrue(calculatedProduct.FinalPrice == 70);
//        }

//        [TestMethod]
//        public void Calculates_More_Success()
//        {
//            //arrange
//            IProductModel product = new ProductModel()
//            {
//                DiscountRuleCode = "3000",
//                BasePrice = 100,
//                Quantity = 201
//            };
//            //act
//            var calculatedProduct = _discountService.CalculateDiscount(product);

//            //assert
//            Assert.IsTrue(calculatedProduct.FinalPrice == 60);
//        }

//        [TestMethod]
//        public void Calculates_Less_Success()
//        {
//            //arrange
//            IProductModel product = new ProductModel()
//            {
//                DiscountRuleCode = "4000",
//                BasePrice = 100,
//                Quantity = 199
//            };
//            //act
//            var calculatedProduct = _discountService.CalculateDiscount(product);

//            //assert
//            Assert.IsTrue(calculatedProduct.FinalPrice == 50);
//        }



//        [TestMethod]
//        public void Calculates_Range_Success()
//        {
//            //arrange
//            IProductModel product = new ProductModel()
//            {
//                DiscountRuleCode = "5000",
//                BasePrice = 100,
//                Quantity = 100
//            };
//            //act
//            var calculatedProduct = _discountService.CalculateDiscount(product);

//            //assert
//            Assert.IsTrue(calculatedProduct.FinalPrice == 40);
//        }


//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Throws_Invalid_Flag_Exception()
//        {
//            //arrange
//            IProductModel product = new ProductModel()
//            {
//                DiscountRuleCode = "6000",
//                BasePrice = 100,
//                Quantity = 100
//            };
//            //act
//            var calculatedProduct = _discountService.CalculateDiscount(product);
         
//        }

//        [TestMethod]
//        public void Returns_IProduct_Success()
//        {
//            //arrange
//            IProductModel product = new ProductModel()
//            {
//                DiscountRuleCode = "5000",
//                BasePrice = 100,
//                Quantity = 10
//            };
//            //act
//            var calculatedProduct = _discountService.CalculateDiscount(product);

//            Assert.IsNotNull(calculatedProduct);
//        }

//        [TestMethod]
//       public void Loads_Configuration_Success()
//        {
           
//            _jsonSerializerServiceMock.Setup(x => x.DeserializeObject<DiscountCodeModel>(It.IsAny<string>()))
//                .Returns(this._discountRules);
//            var result = _discountService.LoadConfiguration();

//            Assert.IsTrue(result);
//            Assert.IsTrue(_discountService.DiscountRules.Count > 0);
            
//        }


//    }
//}
