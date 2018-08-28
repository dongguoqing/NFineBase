using NFine.Code;
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace NFine.Domain.IRepository.SystemManage
{
    public partial interface INewsRepository : IRepositoryBase<NewsEntity>
    {
        List<NewsEntity> GetList(Pagination pagination, string keyword);

        List<NewsEntity> GetList(string keyword = "", string ftype = "");

        void DeleteForm(string keyValue);
    }
}
