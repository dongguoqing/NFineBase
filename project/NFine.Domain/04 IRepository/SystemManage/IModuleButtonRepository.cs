/*******************************************************************************
 * Copyright © 2016 .Framework 版权所有
 * Author: 
 * Description: 快速开发平台
 * Website：http://www..cn
*********************************************************************************/
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace NFine.Domain.IRepository.SystemManage
{
    public partial interface IModuleButtonRepository : IRepositoryBase<ModuleButtonEntity>
    {
        void SubmitCloneButton(List<ModuleButtonEntity> entitys);
    }
}
