using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDal.DbModels
{
    public class GameTransactionDbItem
    {
        public string GameTxId { get; set; } = null!;
        public string GameId { get; set; } = null!;
        public string StoreId { get; set; } = null!;
        public string PlatformId { get; set; } = null!;
        public string LauncherId { get; set; } = null!;
        public string MediaFormatId { get; set; } = null!;
        public DateTime AcquireDate { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
