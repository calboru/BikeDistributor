//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BikeDistributor.Interfaces.CommonServices;
//using BikeDistributor.Interfaces.Services;
//using BikeDistributor.Models.Common;
//using BikeDistributor.Models.Interfaces;
//using BikeDistributor.Services.Common;
//using BikeDistributor.Services.Constants;

//namespace BikeDistributor.Services
//{
//    public class DiscountService: BaseService, IDiscountService
//    {
//        private readonly IJsonSerializerService _jsonJsonSerializerService;
//        private readonly IAppSettingsService _appSettingsService;
//        private readonly IFileService _fileService;
//        public  List<DiscountCodeModel> DiscountRules { get; set; }

//        public DiscountService(IJsonSerializerService iJsonSerializerService, IAppSettingsService appSettingsService, IFileService fileService)
//        {
//            DiscountRules = new List<DiscountCodeModel>();
//            _jsonJsonSerializerService = iJsonSerializerService;
//            _appSettingsService = appSettingsService;
//            _fileService = fileService;

//        }
        
//        public bool LoadConfiguration()
//        {
//            try
//            {
//                var discountRulesFilePath = _appSettingsService.Get(ConfigurationConstants.DiscountCodesConfigFile);
//                var discountRulesText = _fileService.ReadAllText(discountRulesFilePath);
//                DiscountRules = _jsonJsonSerializerService.DeserializeObject<DiscountCodeModel>(discountRulesText);

//                return true;
//            }
//            catch (Exception e)
//            {
//                LogService.Error(e);
//                throw;
//            }
//        }

//        public IProductModel CalculateDiscount(IProductModel product)
//        {
//            var discountRule =
//                DiscountRules.SingleOrDefault(x => x.Id.ToLower().Equals(product.DiscountRuleCode.ToLower()));
            
//            if (discountRule == null) return product;
            

//            switch (discountRule.Flag.ToLower())
//            {
//                case ">=":
//                    if (product.Quantity >= discountRule.QuantityRange1)
//                    {
//                        product.DiscountedPrice = product.BasePrice * discountRule.DiscountRate;
//                    }
//                    break;
//                case "<=":
//                    if (product.Quantity <= discountRule.QuantityRange1)
//                    {
//                        product.DiscountedPrice = product.BasePrice * discountRule.DiscountRate;
//                    }
//                    break;
//                case ">":
//                    if (product.Quantity > discountRule.QuantityRange1)
//                    {
//                        product.DiscountedPrice = product.BasePrice * discountRule.DiscountRate;
//                    }
//                    break;
//                case "<":
//                    if (product.Quantity < discountRule.QuantityRange1)
//                    {
//                        product.DiscountedPrice = product.BasePrice * discountRule.DiscountRate;
//                    }
//                    break;
//                case "range":
//                    if (product.Quantity >= discountRule.QuantityRange1 &&  product.Quantity <= discountRule.QuantityRange2)
//                    {
//                        product.DiscountedPrice = product.BasePrice * discountRule.DiscountRate;
//                    }

//                    break;

//                default:
//                    var errorMessage =
//                        $"Invalid discount flag for {discountRule.Flag} flag {discountRule.Flag} is not valid!";

//                    LogService.Error(errorMessage);
//                    throw new ArgumentException(errorMessage);
                  
//            }

            
//            return product;
//        }
//    }
//}
