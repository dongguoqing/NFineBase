

using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;
namespace NFine.Mapping.SystemManage
{    


    /// <summary>
    /// AreaMap
    /// </summary>    
    public partial class AreaMap:EntityTypeConfiguration<AreaEntity>
    {
       public  AreaMap()
       {
          this.ToTable("Sys_Area");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// ItemsMap
    /// </summary>    
    public partial class ItemsMap:EntityTypeConfiguration<ItemsEntity>
    {
       public  ItemsMap()
       {
          this.ToTable("Sys_Items");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// ItemsDetailMap
    /// </summary>    
    public partial class ItemsDetailMap:EntityTypeConfiguration<ItemsDetailEntity>
    {
       public  ItemsDetailMap()
       {
          this.ToTable("Sys_ItemsDetail");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// ModuleMap
    /// </summary>    
    public partial class ModuleMap:EntityTypeConfiguration<ModuleEntity>
    {
       public  ModuleMap()
       {
          this.ToTable("Sys_Module");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// ModuleButtonMap
    /// </summary>    
    public partial class ModuleButtonMap:EntityTypeConfiguration<ModuleButtonEntity>
    {
       public  ModuleButtonMap()
       {
          this.ToTable("Sys_ModuleButton");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// ModuleFormMap
    /// </summary>    
    public partial class ModuleFormMap:EntityTypeConfiguration<ModuleFormEntity>
    {
       public  ModuleFormMap()
       {
          this.ToTable("Sys_ModuleForm");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// ModuleFormInstanceMap
    /// </summary>    
    public partial class ModuleFormInstanceMap:EntityTypeConfiguration<ModuleFormInstanceEntity>
    {
       public  ModuleFormInstanceMap()
       {
          this.ToTable("Sys_ModuleFormInstance");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// OrganizeMap
    /// </summary>    
    public partial class OrganizeMap:EntityTypeConfiguration<OrganizeEntity>
    {
       public  OrganizeMap()
       {
          this.ToTable("Sys_Organize");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// RoleMap
    /// </summary>    
    public partial class RoleMap:EntityTypeConfiguration<RoleEntity>
    {
       public  RoleMap()
       {
          this.ToTable("Sys_Role");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// UserLogOnMap
    /// </summary>    
    public partial class UserLogOnMap:EntityTypeConfiguration<UserLogOnEntity>
    {
       public  UserLogOnMap()
       {
          this.ToTable("Sys_UserLogOn");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// UserMap
    /// </summary>    
    public partial class UserMap:EntityTypeConfiguration<UserEntity>
    {
       public  UserMap()
       {
          this.ToTable("Sys_User");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// RoleAuthorizeMap
    /// </summary>    
    public partial class RoleAuthorizeMap:EntityTypeConfiguration<RoleAuthorizeEntity>
    {
       public  RoleAuthorizeMap()
       {
          this.ToTable("Sys_RoleAuthorize");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// NewsMap
    /// </summary>    
    public partial class NewsMap:EntityTypeConfiguration<NewsEntity>
    {
       public  NewsMap()
       {
          this.ToTable("Sys_News");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// NewsTypeMap
    /// </summary>    
    public partial class NewsTypeMap:EntityTypeConfiguration<NewsTypeEntity>
    {
       public  NewsTypeMap()
       {
          this.ToTable("Sys_NewsType");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// FileMap
    /// </summary>    
    public partial class FileMap:EntityTypeConfiguration<FileEntity>
    {
       public  FileMap()
       {
          this.ToTable("Sys_File");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// TreeMap
    /// </summary>    
    public partial class TreeMap:EntityTypeConfiguration<TreeEntity>
    {
       public  TreeMap()
       {
          this.ToTable("Sys_Tree");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// DirectoryMap
    /// </summary>    
    public partial class DirectoryMap:EntityTypeConfiguration<DirectoryEntity>
    {
       public  DirectoryMap()
       {
          this.ToTable("Sys_Directory");
          this.HasKey(t=>t.F_Id);
       }
    }
		 
}