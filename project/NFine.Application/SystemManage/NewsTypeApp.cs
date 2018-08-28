using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.SystemManage
{
    public partial class NewsTypeApp
    {
        public List<NewsTypeEntity> GetList(string keyword="",string fname="")
        {
            var expression = ExtLinq.True<NewsTypeEntity>();
            if (!string.IsNullOrEmpty(keyword))
                expression.And(t => t.F_Id == keyword);
            if(!string.IsNullOrEmpty(fname))
            {
                expression.And(t => t.F_Name == fname);
                expression.Or(t => t.F_Type == fname);
            }
            return service.IQueryable(expression).OrderBy(t => t.F_Id).ToList();
        }
    }
}
