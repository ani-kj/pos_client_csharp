using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace UrbanPiper.Model
{
    public class ActivateCardRequest
    {
        public ActivateCardRequest(string cardNumber, string customerPhone, string customerName, double amount, string pin)
        {
            CardNumber = cardNumber;
            CustomerPhone = customerPhone;
            CustomerName = customerName;
            Amount = amount;
            Pin = pin;
        }

        public double Amount { get; set; }
        public string CustomerName { get; set; }
        public string CardNumber { get; set; }
        public string CustomerPhone { get; set; }
        public string Pin { get; set; }

        internal string GetQueryStringParams()
        {
            StringBuilder sb = new StringBuilder();
            if (CardNumber != null)
                sb.Append(String.Format("&card_number={0}", Uri.EscapeDataString(CardNumber)));
            if (CustomerPhone != null)
                sb.Append(String.Format("&customer_phone={0}", Uri.EscapeDataString(CustomerPhone)));
            if (CustomerName != null)
                sb.Append(String.Format("&customer_name={0}", Uri.EscapeDataString(CustomerName)));
            sb.Append(String.Format("&amount={0}", Amount));
            if (Pin != null)
                sb.Append(String.Format("&pin={0}", Uri.EscapeDataString(Pin)));

            return sb.ToString();
        }
    }

    [DataContract]
    public class ActivateCardResponse : JsonResponse
    {
        [DataMember(Name = "success")]
        public string Success { get; set; }
        [DataMember(Name = "result")]
        public string Result { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "card_number")]
        public string CardNumber { get; set; }
        [DataMember(Name = "balance")]
        public string Balance { get; set; }
        [DataMember(Name = "customer_name")]
        public string CustomerName { get; set; }
        [DataMember(Name = "customer_phone")]
        public string CustomerPhone { get; set; }
        [DataMember(Name = "approval_code")]
        public string ApprovalCode { get; set; }
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }
    }
}

