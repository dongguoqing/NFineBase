using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.IRepository.SystemManage
{
   public  partial interface INewsTypeRepository : IRepositoryBase<NewsTypeEntity>
    {
        List<NewsTypeEntity> GetList(string keyword, string fname);
    }
}
