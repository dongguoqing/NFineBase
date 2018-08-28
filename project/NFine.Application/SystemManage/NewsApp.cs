using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Application.SystemManage
{
    public partial class NewsApp
    {
        public List<NewsEntity> GetList(string keyword = "",string ftype ="")
        {
            var expression = ExtLinq.True<NewsEntity>();
            if(!string.IsNullOrEmpty(ftype))
            {
                expression = expression.And(t => t.F_Type == ftype);//构造动态的表达式树
            }
            if(!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Id == keyword);
            }
           return service.IQueryable(expression).OrderBy(a => a.F_SortCode).ToList();
        }

        public List<NewsEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<NewsEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Author.Contains(keyword));
                expression = expression.Or(t => t.F_Type.Contains(keyword));

            }
            return service.FindList(expression, pagination);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }

    }
}
