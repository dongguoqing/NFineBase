using NFine.Code;
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.SystemManage
{
    public partial interface IFileRepository : IRepositoryBase<FileEntity>
    {
        List<FileEntity> GetList(Pagination pagination, string keyword);
    }
}
