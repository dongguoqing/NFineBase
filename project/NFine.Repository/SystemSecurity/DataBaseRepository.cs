using NFine.Code;
using NFine.Data;
using NFine.Data.Extensions;
using NFine.Domain._03_Entity.SystemSecurity;
using NFine.Domain._04_IRepository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.SystemSecurity
{
    public class DataBaseRepository : RepositoryBase<DataBaseEntity>, IDataBaseRepository
    {
        public List<DataBaseEntity> GetDataBase(string F_IP, string UserName, string Password)
        {
            DbHelper.connstring = string.Format("Server={0};Initial Catalog=master;User ID={1};Password={2}", F_IP,UserName,Password);
            return Common.TableToEntity<DataBaseEntity>(DbHelper.ExecuteDataTable("select Name From master..SysDatabases order by Name"));
        }
    }
}
