


using System;
namespace NFine.Domain.Entity.SystemSecurity
{    

    /// <summary>
    /// Sys_Log
    /// </summary>    
    public class LogEntity:IEntity<LogEntity>, ICreationAudited
    {
      public string F_Id { get; set; }
      public DateTime? F_Date { get; set; }
      public string F_Account { get; set; }
      public string F_NickName { get; set; }
      public string F_Type { get; set; }
      public string F_IPAddress { get; set; }
      public string F_IPAddressName { get; set; }
      public string F_ModuleId { get; set; }
      public string F_ModuleName { get; set; }
      public bool? F_Result { get; set; }
      public string F_Description { get; set; }
      public DateTime? F_CreatorTime { get; set; }
      public string F_CreatorUserId { get; set; }
 
    }
	    /// <summary>
    /// Sys_DbBackup
    /// </summary>    
    public class DbBackupEntity:IEntity<DbBackupEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
      public string F_Id { get; set; }
      public string F_BackupType { get; set; }
      public string F_DbName { get; set; }
      public string F_FileName { get; set; }
      public string F_FileSize { get; set; }
      public string F_FilePath { get; set; }
      public DateTime? F_BackupTime { get; set; }
      public int? F_SortCode { get; set; }
      public bool? F_DeleteMark { get; set; }
      public bool? F_EnabledMark { get; set; }
      public string F_Description { get; set; }
      public DateTime? F_CreatorTime { get; set; }
      public string F_CreatorUserId { get; set; }
      public DateTime? F_LastModifyTime { get; set; }
      public string F_LastModifyUserId { get; set; }
      public DateTime? F_DeleteTime { get; set; }
      public string F_DeleteUserId { get; set; }
 
    }
	    /// <summary>
    /// Sys_FilterIP
    /// </summary>    
    public class FilterIPEntity:IEntity<FilterIPEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
      public string F_Id { get; set; }
      public bool? F_Type { get; set; }
      public string F_StartIP { get; set; }
      public string F_EndIP { get; set; }
      public int? F_SortCode { get; set; }
      public bool? F_DeleteMark { get; set; }
      public bool? F_EnabledMark { get; set; }
      public string F_Description { get; set; }
      public DateTime? F_CreatorTime { get; set; }
      public string F_CreatorUserId { get; set; }
      public DateTime? F_LastModifyTime { get; set; }
      public string F_LastModifyUserId { get; set; }
      public DateTime? F_DeleteTime { get; set; }
      public string F_DeleteUserId { get; set; }
 
    }
	 
}