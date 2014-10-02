using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace UrbanPiper.Model
{
    public class UpdateBalanceRequest
    {
        public UpdateBalanceRequest(string cardNumber, string customerPhone, string message, double amount, string pin)
        {
            CardNumber = cardNumber;
            CustomerPhone = customerPhone;
            Message = message;
            Amount = amount;
            Pin = pin;
        }

        public double Amount { get; set; }
        public string Message { get; set; }
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
            if (Message != null)
                sb.Append(String.Format("&message={0}", Uri.EscapeDataString(Message)));
            sb.Append(String.Format("&amount={0}", Amount));
            if (Pin != null)
                sb.Append(String.Format("&pin={0}", Uri.EscapeDataString(Pin)));

            return sb.ToString();
        }
    }

    [DataContract]
    public class UpdateBalanceResponse : JsonDataContractObject
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
        [DataMember(Name = "points")]
        public string Points { get; set; }
        [DataMember(Name = "customer_phone")]
        public string CustomerPhone { get; set; }
        [DataMember(Name = "approval_code")]
        public string ApprovalCode { get; set; }
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }
    }
}

