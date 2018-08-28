using NFine.Data;
using NFine.Domain._03_Entity.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.SystemSecurity
{
    public interface IDataBaseRepository:IRepositoryBase<DataBaseEntity>
    {
        List<DataBaseEntity> GetDataBase(string F_IP, string UserName, string Password);
    }
}
