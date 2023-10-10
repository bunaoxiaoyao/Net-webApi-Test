using SqlSugar;

namespace ConsoleApp1.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [SugarTable("t_bi_platform_account")]
    public class PlatformAccount
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int64 Id { get; set; }

        /// <summary>
        /// (账号系统)账号Id
        /// </summary>
        public System.Int32? AccountId { get; set; }

        /// <summary>
        /// 账号别名-简称
        /// </summary>
        public System.String AccountAlias { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public System.String Account { get; set; }

        /// <summary>
        /// 登陆账号
        /// </summary>
        public System.String EmailAccount { get; set; }

        /// <summary>
        /// 平台Id
        /// </summary>
        public System.Int32? PlatformId { get; set; }

        /// <summary>
        /// 平台(中文)
        /// </summary>
        public System.String PlatformCn { get; set; }

        /// <summary>
        /// 平台(英文)
        /// </summary>
        public System.String PlatformEn { get; set; }

        /// <summary>
        /// 站点Id
        /// </summary>
        public System.Int32? SiteId { get; set; }

        /// <summary>
        /// 站点(中文)
        /// </summary>
        public System.String SiteCn { get; set; }

        /// <summary>
        /// 站点(英文)
        /// </summary>
        public System.String SiteEn { get; set; }

        /// <summary>
        /// OA状态:1#启用;2#禁用;
        /// </summary>
        public System.Int32? OAStatus { get; set; }

        /// <summary>
        /// SOAP Token
        /// </summary>
        public System.String SoapToken { get; set; }

        /// <summary>
        /// SOAP授权状态:1#未授权;2#已授权;3#授权过期;
        /// </summary>
        public System.Int32? SoapAuthStatus { get; set; }

        /// <summary>
        /// 授权JSON
        /// </summary>
        public System.String AuthJson { get; set; }

        /// <summary>
        /// 授权状态:1#未授权;2#已授权;3#授权过期;
        /// </summary>
        public System.Int32? AuthStatus { get; set; }

        /// <summary>
        /// 开发者账号json
        /// </summary>
        public System.String DeveloperJson { get; set; }

        /// <summary>
        /// 账号扩展信息(json)
        /// </summary>
        public System.String ExtensionInfo { get; set; }

        /// <summary>
        /// 删除状态
        /// </summary>
        public System.SByte IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String DeleteUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String DeleterUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String LastModifierUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String LastModifierUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreateUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreatorUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreatorDepartmentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreatorOrganizeId { get; set; }
    }
}