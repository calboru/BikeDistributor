using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Entities;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Models;
using BikeDistributor.Services.Common;
using BikeDistributor.Services.Infrastructure;

namespace BikeDistributor.Services
{
    public class HtmlReceiptService: BaseService, IReceiptService
    {
        private readonly IDataRepositoryService _dataRepositoryService;
        public HtmlReceiptService(IDataRepositoryService dataRepositoryService)
        {
            _dataRepositoryService = dataRepositoryService;
        }

        public string Output(int orderId, int templateId, string token, string contentType)
        {
            var receiptTemplate = _dataRepositoryService.GetOne<TemplateModel, Template>(x => x.Id == templateId);


            return "";
        }

    }
}
