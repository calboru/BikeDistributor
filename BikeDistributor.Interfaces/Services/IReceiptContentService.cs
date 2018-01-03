namespace BikeDistributor.Interfaces.Services
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
