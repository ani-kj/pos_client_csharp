using System;
using UrbanPiper;
using UrbanPiper.Model;

namespace UrbanPiperClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();

            //Activate a new card / phone number
            ActivateCardResponse acrsp = c.ActivateCard(new ActivateCardRequest(null, "+917042028893", "Aiman Ashraf IInd", 0, "1234"));
            Console.WriteLine(acrsp.ToJson());

            //Add purchase points of card / phone number. Pass in null for last parameter if you don't want to use sku data
            AddPurchasePointsResponse aprsp = c.AddPurchasePoints(new AddPurchasePointsRequest(100, null, null, "+917042028893", null));
            Console.WriteLine(aprsp.ToJson());

            //Add purchase points of card / phone number. With sku items
            AddPurchasePointsResponse aprsp2 = c.AddPurchasePoints(new AddPurchasePointsRequest(100, null, null, "+917042028893",
                new SkuItem[] { new SkuItem("ABCD", "Some Desc", 1, 2), new SkuItem("EFGH", "Some other Desc", 3, 4) }
            ));
            Console.WriteLine(aprsp2.ToJson());

            //Update balance of card / phone number
            UpdateBalanceResponse ubrsp = c.UpdateBalance(new UpdateBalanceRequest(null, "+917042028893", "Bought Maal", 30, "1234"));
            Console.WriteLine(ubrsp.ToJson());

            Console.Read();

        }
    }
}
