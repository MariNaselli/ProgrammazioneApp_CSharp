using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDal.Criterias
{
    public class GameTransactionCriteria
    {
        public string GameTxId { get; set; } 
        public string GameId { get; set; } 
        public string StoreId { get; set; } 
        public string PlatformId { get; set; } 
        public string LauncherId { get; set; } 
        public string MediaFormatId { get; set; } 
        public DateTime? AcquireDate { get; set; }
        public decimal? PurchasePrice { get; set; }


    }
}
