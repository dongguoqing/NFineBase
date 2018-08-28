

using NFine.Domain.Entity.SystemSecurity;
using System.Data.Entity.ModelConfiguration;
namespace NFine.Mapping.SystemSecurity
{    


    /// <summary>
    /// LogMap
    /// </summary>    
    public partial class LogMap:EntityTypeConfiguration<LogEntity>
    {
       public LogMap()
       {
          this.ToTable("Sys_Log");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// DbBackupMap
    /// </summary>    
    public partial class DbBackupMap:EntityTypeConfiguration<DbBackupEntity>
    {
       public DbBackupMap()
       {
          this.ToTable("Sys_DbBackup");
          this.HasKey(t=>t.F_Id);
       }
    }
		

    /// <summary>
    /// FilterIPMap
    /// </summary>    
    public partial class FilterIPMap:EntityTypeConfiguration<FilterIPEntity>
    {
       public FilterIPMap()
       {
          this.ToTable("Sys_FilterIP");
          this.HasKey(t=>t.F_Id);
       }
    }
		 
}