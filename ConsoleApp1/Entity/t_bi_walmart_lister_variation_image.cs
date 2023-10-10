using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ConsoleApp1
{
    ///<summary>
    ///Walmart范本多属性图片表
    ///</summary>
    [SugarTable("t_bi_walmart_lister_variation_image")]
    public partial class t_bi_walmart_lister_variation_image
    {
           public t_bi_walmart_lister_variation_image(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long Id {get;set;}

           /// <summary>
           /// Desc:范本id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ListerId {get;set;}

           /// <summary>
           /// Desc:属性名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SpecificName {get;set;}

           /// <summary>
           /// Desc:属性值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SpecificValue {get;set;}

           /// <summary>
           /// Desc:属性图片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Images {get;set;}

           /// <summary>
           /// Desc:删除状态
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public byte IsDeleted {get;set;}

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
           public string DeleterUserId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DeletionTime {get;set;}

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
           public string LastModifierUserId {get;set;}

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
           public DateTime? CreationTime {get;set;}

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
           public string CreatorUserId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreatorDepartmentId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public string CreatorOrganizeId {get;set;}

    }
}
