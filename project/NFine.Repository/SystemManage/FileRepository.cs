using NFine.Code;
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.SystemManage
{
    public partial class FileRepository : RepositoryBase<FileEntity>, IFileRepository
    {
        public List<FileEntity> GetList(Pagination pagination, string keyword)
        {
            return this.GetList(pagination, keyword);
        }
    }
}
