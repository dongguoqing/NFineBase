
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain.Entity.SystemSecurity;
using NFine.Domain.IRepository.SystemSecurity;
using NFine.Repository.SystemSecurity;
namespace NFine.Application.SystemSecurity
{    

    /// <summary>
    /// LogApp
    /// </summary>    
    public partial class LogApp
    {
        private ILogRepository service=new LogRepository();

        public List<LogEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public LogEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(LogEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(LogEntity entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                service.Update(entity);
            }
            else
            {
                entity.Create();
                service.Insert(entity);
            }
        }

    }
		
    /// <summary>
    /// DbBackupApp
    /// </summary>    
    public partial class DbBackupApp
    {
        private IDbBackupRepository service=new DbBackupRepository();

        public List<DbBackupEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public DbBackupEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(DbBackupEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(DbBackupEntity entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                service.Update(entity);
            }
            else
            {
                entity.Create();
                service.Insert(entity);
            }
        }

    }
		
    /// <summary>
    /// FilterIPApp
    /// </summary>    
    public partial class FilterIPApp
    {
        private IFilterIPRepository service=new FilterIPRepository();

        public List<FilterIPEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public FilterIPEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(FilterIPEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(FilterIPEntity entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                service.Update(entity);
            }
            else
            {
                entity.Create();
                service.Insert(entity);
            }
        }

    }
		 
}