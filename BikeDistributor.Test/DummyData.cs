using System.Collections.Generic;
using BikeDistributor.Models;

namespace BikeDistributor.Test
{
    public static  class DummyData
    {
        public static OrderModel DummyOrderModel()
        {
            return  new OrderModel()
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
                    CompanyName = "Trainer Road LLC",
                    Location = new List<LocationModel>()
                    {
                        new LocationModel()
                        {
                            Id = 1,
                            Type = "Billing",
                            TaxRate = 0.01,
                            AddressLine1 = "Address line 1",
                            AddressLine2 = "Address Line 2",
                            BusinessEntityId = 1,
                            City = "Carson",
                            Country = "USA",
                            State = "NV"
                        }
                    }
                },
                Products = new List<OrderLineModel>()
                {
                    new OrderLineModel()
                    {
                        OrderId = 1,
                        Quantity = 1 ,
                        Product =   new ProductModel()
                        {
                            Brand = "Bike1",
                            Model = "Bike1-Model",
                            Make = "2018",
                            Msrp = 100
                        }
                    },

                    new OrderLineModel()
                    {
                        OrderId = 1,
                        Quantity = 1 ,
                        Product =   new ProductModel()
                        {
                            Brand = "Bike2",
                            Model = "Bike2-Model",
                            Make = "2018",
                            Msrp = 100
                        }
                    }
                }

            };
        }

    }
}
