using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDal.DbModels
{
    public class StoreDbItem
    {
        public string StoreId { get; set; } = null!;
        public string StoreName { get; set; } = null!;
        public string? StoreUrl { get; set; }
    }
}
