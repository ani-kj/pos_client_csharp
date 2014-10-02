using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;

namespace UrbanPiper.Model
{
    public class AddPurchasePointsRequest
    {
        public AddPurchasePointsRequest(double purchaseAmount, string userSearchInfo, string cardNumber, string customerPhone, SkuItem[] skuItems)
        {
            PurchaseAmount = purchaseAmount;
            UserSearchInfo = userSearchInfo;
            CardNumber = cardNumber;
            CustomerPhone = customerPhone;
            SkuItems = skuItems;
        }

        public double PurchaseAmount { get; set; }
        public string UserSearchInfo { get; set; }
        public string CardNumber { get; set; }
        public string CustomerPhone { get; set; }
        public SkuItem[] SkuItems { get; set; }

        internal string GetQueryStringParams()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("&purchase_amount={0}", PurchaseAmount));
            if (UserSearchInfo!=null)
                sb.Append(String.Format("&user_search_info={0}", Uri.EscapeDataString(UserSearchInfo)));
            if (CardNumber != null)
                sb.Append(String.Format("&card_number={0}", Uri.EscapeDataString(CardNumber)));
            if (CustomerPhone != null)
                sb.Append(String.Format("&customer_phone={0}", Uri.EscapeDataString(CustomerPhone)));


            return sb.ToString();
        }

        internal string GetPostData()
        {
            if (SkuItems == null) return string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("{\"sku_data\":[");
            for (int i = 0; i < SkuItems.Length; i++)
            {
                sb.Append(SkuItems[i].ToJson());
                if (i < SkuItems.Length - 1) sb.Append(",");
            }
            sb.Append("]}");
            return sb.ToString();
        }
    }

    [DataContract]
    public class AddPurchasePointsResponse : JsonDataContractObject
    {
        [DataMember(Name = "success")]
        public string Success { get; set; }
        [DataMember(Name = "result")]
        public string Result { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "purchase_amount")]
        public string PurchaseAmount { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "image_url")]
        public string ImageUrl { get; set; }
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }
    }

}

