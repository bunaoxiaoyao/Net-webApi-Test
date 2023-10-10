using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace ConsoleApp1.Entity.Common
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("t_bi_common_upc_manage_detail")]
    public partial class TCommonUpcManageDetail
    {
        public TCommonUpcManageDetail()
        {


        }
        /// <summary>
        /// Desc:主键Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// Desc:号码池外键
        /// Default:
        /// Nullable:False
        /// </summary>           
        public long NumberPoolId { get; set; }

        /// <summary>
        /// Desc:号码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Number { get; set; }

        /// <summary>
        /// Desc:是否使用
        /// Default:
        /// Nullable:False
        /// </summary>           
        public byte IsUse { get; set; }

        /// <summary>
        /// Desc:号码使用时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? UseTime { get; set; }

        /// <summary>
        /// Desc:删除状态
        /// Default:
        /// Nullable:False
        /// </summary>           
        public byte IsDeleted { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DeleteUserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DeleterUserId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string LastModifierUserId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string LastModifierUserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CreateUserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CreatorUserId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CreatorDepartmentId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CreatorOrganizeId { get; set; }

    }
}
