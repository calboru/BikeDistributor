using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using BikeDistributor.Models.Common;
using BikeDistributor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test.Services
{
    /// <summary>
    /// This is a wrapper class for Newtonsoft.NET Json serializer
    /// </summary>
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class JsonSerializerTest:BaseTest
    {
        private string jsonText = "[{'Id':'1000', 'DiscountRate':'0.9', 'Flag':'>=', 'QuantityRange1':'20', 'QuantityRange2':'0'},{'Id':'2000','DiscountRate':'0.8','Flag':'>=','QuantityRange1':'10','QuantityRange2':'0'},{'Id':'5000','DiscountRate':'0.8','Flag':'>=','QuantityRange1':'5','QuantityRange2':'0'}]";
        private string failText = "sdfsdfsdfsdfsdf";
        [TestInitialize]
        public void TestInitialize()
        {
            jsonText = jsonText.Replace("'", "\"");
        }
        
        [TestMethod]
        public void DeserializeObject_Success()
        {

            var jsonsonSerializer = new JsonSerializerService();
            var result = jsonsonSerializer.DeserializeObject<DiscountCodeModel>(jsonText);
            
            Assert.IsTrue(result[0].Id == "1000");


        }

  }
}
