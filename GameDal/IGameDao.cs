using GameDal.Criterias;
using GameDal.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDal
{
    public interface IGameDao
    {
        Task<GameDbItem[]> GetAllGameDbItemsAsync();

        Task<GameDbItem[]> GetGameDbItemsByPartialTitleAsync
        (
            string? id = null,
            string? title = null,
            string? json = null,
            string? mainId = null
        );

        Task<StoreDbItem[]> GetStoreDbItemsByCriteriaAsync
        (
            StoreCriteria? criteria = null
        );
    }
}
