using System;
using BikeDistributor.Data.Entities;
using BikeDistributor.Interfaces;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Services.Common;

namespace BikeDistributor.Services.Receipt
{
    public class HtmlReceiptService: BaseService, IHtmlReceiptService
    {
        private readonly  IDataRepositoryService _dataRepositoryService;
        private readonly  IReceiptContentService _receiptContentService;

        public HtmlReceiptService(IDataRepositoryService dataRepositoryService, IReceiptContentService receiptContentService)
        {
            _dataRepositoryService = dataRepositoryService;
            _receiptContentService = receiptContentService;
        }

        public string Output(int orderId, int templateId, string token)
        {
            var result = "";

            try
            {
                var templateModel = _dataRepositoryService.GetOne<HtmlTemplateModel, HtmlTemplate>(t => t.Id == templateId);
                var content = _receiptContentService.Generate(orderId, "order-line-container", "order-line", "sub-total-container",
                    "sub-total-line");
                result = templateModel.Content.Replace(token, content);
            }
            catch (Exception e)
            {
                LogService.Error(e);
                throw;
            }

            return result;
        }

    }
}
