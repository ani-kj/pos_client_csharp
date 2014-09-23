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
            ActivateCardResponse acrsp =  c.ActivateCard(new ActivateCardRequest(null, "+917042028893", "Aiman Ashraf IInd", 0, "1234"));
            Console.WriteLine(acrsp.ToJson());

            //Update balance of card / phone number
            AddPurchasePointsResponse aprsp = c.AddPurchasePoints(new AddPurchasePointsRequest(100, null, null, "+917042028893"));
            Console.WriteLine(aprsp.ToJson());

            //Update balance of card / phone number
            UpdateBalanceResponse ubrsp = c.UpdateBalance(new UpdateBalanceRequest(null, "+917042028893", "Bought Maal", 30, "1234"));
            Console.WriteLine(ubrsp.ToJson());

            Console.Read();

        }
    }
}
