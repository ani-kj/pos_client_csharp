using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UrbanPiper.Model
{
    [DataContract]
    class SkuItem
    {
        public SkuItem(string skuCode, string skuDesc, int qty, int lineTotal)
        {
            SkuCode = skuCode;
            SkuDesc = skuDesc;
            Qty = qty;
            LineTotal = lineTotal;
        }

        [DataMember(Name="sku_code")]
        public string SkuCode { get; set; }
        [DataMember(Name = "sku_desc")]
        public string SkuDesc { get; set; }
        [DataMember(Name = "qty")]
        public int Qty { get; set; }
        [DataMember(Name = "line_total")]
        public int LineTotal { get; set; }
    }
}
