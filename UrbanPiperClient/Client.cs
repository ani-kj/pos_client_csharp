using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanPiper.Model;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace UrbanPiper
{
    public class Client
    {
        static readonly string USERNAME = "biz_adm_OedJvroFrbYxubEjbKXLTA";
        static readonly string PASSWD = "fr0d0";
        static readonly string URL_ADD_PURCHASE = "https://api.urbanpiper.com/api/v1/purchase/addpoints/?format=json";
        static readonly string URL_ACTIVATE_CARD = "https://api.urbanpiper.com/api/v1/card/activate/?format=json";
        static readonly string URL_UPDATE_BALANCE = "https://api.urbanpiper.com/api/v1/card/balanceupdate/?format=json";

        public AddPurchasePointsResponse AddPurchasePoints(AddPurchasePointsRequest apr)
        {
            if (apr.SkuItems == null)
            {
                return MakeGETRequest<AddPurchasePointsResponse>(URL_ADD_PURCHASE, apr.GetQueryStringParams());
            }
            else
            {
                return MakePOSTRequest<AddPurchasePointsResponse>(URL_ADD_PURCHASE, apr.GetQueryStringParams(), apr.GetPostData());
            }
        }

        public ActivateCardResponse ActivateCard(ActivateCardRequest car)
        {
            return MakeGETRequest<ActivateCardResponse>(URL_ACTIVATE_CARD, car.GetQueryStringParams());
        }

        public UpdateBalanceResponse UpdateBalance(UpdateBalanceRequest ubr)
        {
            return MakeGETRequest<UpdateBalanceResponse>(URL_UPDATE_BALANCE, ubr.GetQueryStringParams());
        }

        private T MakeGETRequest<T>(string baseUrl, String queryString)
        {
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create(
                baseUrl + queryString);
            req.Method = "GET";

            Console.WriteLine(baseUrl + queryString);

            string authInfo = string.Format("{0}:{1}", USERNAME, PASSWD);
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            req.Headers["Authorization"] = "Basic " + authInfo;

            using (HttpWebResponse httpResponse = (HttpWebResponse)req.GetResponse())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                return (T)ser.ReadObject(httpResponse.GetResponseStream());
            }
        }

        private T MakePOSTRequest<T>(string baseUrl, String queryString, String postData)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(
                baseUrl + queryString);
            req.Method = "POST";
            
            Console.WriteLine(baseUrl + queryString);
            
            string authInfo = string.Format("{0}:{1}", USERNAME, PASSWD);
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            req.Headers["Authorization"] = "Basic " + authInfo;

            byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = postDataBytes.Length;
            req.GetRequestStream().Write(postDataBytes, 0, postDataBytes.Length);
            req.GetRequestStream().Close();

            using (HttpWebResponse httpResponse = (HttpWebResponse)req.GetResponse())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                return (T)ser.ReadObject(httpResponse.GetResponseStream());
            }
        }

    }
}
