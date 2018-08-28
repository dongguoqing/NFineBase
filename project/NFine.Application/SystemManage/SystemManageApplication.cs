
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using NFine.Code;
namespace NFine.Application.SystemManage
{    

    /// <summary>
    /// AreaApp
    /// </summary>    
    public partial class AreaApp
    {
        private IAreaRepository service=new AreaRepository();

        public List<AreaEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public AreaEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(AreaEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(AreaEntity entity, string keyValue)
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
    /// ItemsApp
    /// </summary>    
    public partial class ItemsApp
    {
        private IItemsRepository service=new ItemsRepository();

        public List<ItemsEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public ItemsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(ItemsEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(ItemsEntity entity, string keyValue)
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
    /// ItemsDetailApp
    /// </summary>    
    public partial class ItemsDetailApp
    {
        private IItemsDetailRepository service=new ItemsDetailRepository();

        public List<ItemsDetailEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public ItemsDetailEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(ItemsDetailEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(ItemsDetailEntity entity, string keyValue)
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
    /// ModuleApp
    /// </summary>    
    public partial class ModuleApp
    {
        private IModuleRepository service=new ModuleRepository();

        public List<ModuleEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public ModuleEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(ModuleEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(ModuleEntity entity, string keyValue)
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
    /// ModuleButtonApp
    /// </summary>    
    public partial class ModuleButtonApp
    {
        private IModuleButtonRepository service=new ModuleButtonRepository();

        public List<ModuleButtonEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public ModuleButtonEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(ModuleButtonEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(ModuleButtonEntity entity, string keyValue)
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
    /// ModuleFormApp
    /// </summary>    
    public partial class ModuleFormApp
    {
        private IModuleFormRepository service=new ModuleFormRepository();

        public List<ModuleFormEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public ModuleFormEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(ModuleFormEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(ModuleFormEntity entity, string keyValue)
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
    /// ModuleFormInstanceApp
    /// </summary>    
    public partial class ModuleFormInstanceApp
    {
        private IModuleFormInstanceRepository service=new ModuleFormInstanceRepository();

        public List<ModuleFormInstanceEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public ModuleFormInstanceEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(ModuleFormInstanceEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(ModuleFormInstanceEntity entity, string keyValue)
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
    /// OrganizeApp
    /// </summary>    
    public partial class OrganizeApp
    {
        private IOrganizeRepository service=new OrganizeRepository();

        public List<OrganizeEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public OrganizeEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(OrganizeEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(OrganizeEntity entity, string keyValue)
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
    /// RoleApp
    /// </summary>    
    public partial class RoleApp
    {
        private IRoleRepository service=new RoleRepository();

        public List<RoleEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public RoleEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(RoleEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(RoleEntity entity, string keyValue)
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
    /// UserLogOnApp
    /// </summary>    
    public partial class UserLogOnApp
    {
        private IUserLogOnRepository service=new UserLogOnRepository();

        public List<UserLogOnEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public UserLogOnEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(UserLogOnEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(UserLogOnEntity entity, string keyValue)
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
    /// UserApp
    /// </summary>    
    public partial class UserApp
    {
        private IUserRepository service=new UserRepository();

        public List<UserEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public UserEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(UserEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(UserEntity entity, string keyValue)
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
    /// RoleAuthorizeApp
    /// </summary>    
    public partial class RoleAuthorizeApp
    {
        private IRoleAuthorizeRepository service=new RoleAuthorizeRepository();

        public List<RoleAuthorizeEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public RoleAuthorizeEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(RoleAuthorizeEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(RoleAuthorizeEntity entity, string keyValue)
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
    /// NewsApp
    /// </summary>    
    public partial class NewsApp
    {
        private INewsRepository service=new NewsRepository();

        public List<NewsEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public NewsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(NewsEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(NewsEntity entity, string keyValue)
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
    /// NewsTypeApp
    /// </summary>    
    public partial class NewsTypeApp
    {
        private INewsTypeRepository service=new NewsTypeRepository();

        public List<NewsTypeEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public NewsTypeEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(NewsTypeEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(NewsTypeEntity entity, string keyValue)
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
    /// FileApp
    /// </summary>    
    public partial class FileApp
    {
        private IFileRepository service=new FileRepository();

        public List<FileEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public FileEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(FileEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(FileEntity entity, string keyValue)
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
    /// TreeApp
    /// </summary>    
    public partial class TreeApp
    {
        private ITreeRepository service=new TreeRepository();

        public List<TreeEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public TreeEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(TreeEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(TreeEntity entity, string keyValue)
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
    /// DirectoryApp
    /// </summary>    
    public partial class DirectoryApp
    {
        private IDirectoryRepository service=new DirectoryRepository();

        public List<DirectoryEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

        public DirectoryEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(DirectoryEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(DirectoryEntity entity, string keyValue)
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