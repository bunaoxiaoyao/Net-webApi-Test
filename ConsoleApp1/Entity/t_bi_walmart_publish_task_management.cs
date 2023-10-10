using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace t_bi_walmart_publish_task_management
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("t_bi_walmart_publish_task_management")]
    public partial class t_bi_walmart_publish_task_management
    {
           public t_bi_walmart_publish_task_management(){


           }
           /// <summary>
           /// Desc:主键，序号（自动增长）
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long Id {get;set;}

           /// <summary>
           /// Desc:关联Lister表
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ListerIds {get;set;}

           /// <summary>
           /// Desc:账号id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long AccountId {get;set;}

           /// <summary>
           /// Desc:账号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string AccountName {get;set;}

           /// <summary>
           /// Desc:任务状态（0待处理，1处理中，2已完成）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte TaskStatus {get;set;}

           /// <summary>
           /// Desc:刊登状态（0未开始，1刊登失败，2刊登成功）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte PublishState {get;set;}

           /// <summary>
           /// Desc:刊登明细id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PublishDetailId {get;set;}

           /// <summary>
           /// Desc:刊登明细
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PublishDetail {get;set;}

           /// <summary>
           /// Desc:上传文件名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string fileName {get;set;}

           /// <summary>
           /// Desc:储存文件地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Url {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreationTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreatorUserId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreateUserName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreatorDepartmentId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreatorOrganizeId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastModificationTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LastModifierUserName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LastModifierUserId {get;set;}

           /// <summary>
           /// Desc:删除状态
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte IsDeleted {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DeleterUserId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DeleteUserName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DeletionTime {get;set;}

    }
}
