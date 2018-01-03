using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Interfaces
{
   public interface IReceiptContentService
   {

       string Generate(
           int orderId,
           string classForOrderLineContainer,
           string classForOrderLine,
           string classForSubTotalContainer,
           string classForSubTotalLines);
   }
}
