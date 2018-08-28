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
    public partial class NewsRepository : RepositoryBase<NewsEntity>, INewsRepository
    {
        public List<NewsEntity> GetList(Pagination pagination, string keyword)
        {
            return this.GetList(pagination, keyword);
        }

        public List<NewsEntity> GetList(string keyword = "", string ftype = "")
        {
            return this.GetList(keyword, ftype);
        }

        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<NewsEntity>(t => t.F_Id == keyValue);
                db.Delete<UserLogOnEntity>(t => t.F_UserId == keyValue);
                db.Commit();
            }
        }
    }
}
