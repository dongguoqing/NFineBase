

using NFine .Data;
using NFine.Domain.Entity.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.IRepository.SystemSecurity
{    
    /// <summary>
    /// LogRepository
    /// </summary>    
    public partial interface ILogRepository:IRepositoryBase<LogEntity>
    {

    }
	    /// <summary>
    /// DbBackupRepository
    /// </summary>    
    public partial interface IDbBackupRepository:IRepositoryBase<DbBackupEntity>
    {

    }
	    /// <summary>
    /// FilterIPRepository
    /// </summary>    
    public partial interface IFilterIPRepository:IRepositoryBase<FilterIPEntity>
    {

    }
	 
}