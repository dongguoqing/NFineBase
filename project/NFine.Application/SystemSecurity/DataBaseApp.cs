using NFine.Domain._03_Entity.SystemSecurity;
using  NFine.Domain._04_IRepository.SystemSecurity;
using  NFine.Domain.IRepository.SystemManage;
using  NFine.Repository.SystemManage;
using NFine.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.SystemSecurity
{
   public  class DataBaseApp
    {
       private IDataBaseRepository service = new DataBaseRepository();

       public List<DataBaseEntity> GetDataBase(string F_IP, string UserName, string Password)
       {
           return service.GetDataBase(F_IP,UserName,Password);
       }
    }
}
