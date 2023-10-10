using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Sunway.Task.Data.Entity.FyndiqListing
{
    /// <summary>
    /// Fyndiq在售任务类
    ///</summary>
    [SugarTable("t_bi_fyndiq_listing_job_task")]
    public class FyndiqListingJobTask 
    {
        /// <summary>
        /// 主键 
        ///</summary>
         public int Id { get; set; }
        /// <summary>
        /// 外键 
        ///</summary>
         public int ListingId { get; set; }
        /// <summary>
        /// 任务类型 
        ///</summary>
         public string TaskType { get; set; }
        /// <summary>
        /// 存储json 
        ///</summary>
         public string TaskInfoJson { get; set; }
        /// <summary>
        /// 店铺Id 
        ///</summary>
         public int? ShopId { get; set; }
        /// <summary>
        /// 店铺名称 
        ///</summary>
         public string ShopName { get; set; }
        /// <summary>
        /// 产品Id 
        ///</summary>
         public string ArticleId { get; set; }
        /// <summary>
        /// 平台sku 
        ///</summary>
         public string Sku { get; set; }
        /// <summary>
        /// 仓库sku 
        ///</summary>
         public string WarehouseSku { get; set; }
        /// <summary>
        /// 修改状态（未修改，处理中，修改失败，修改成功） 
        ///</summary>
         public int ChangeStatus { get; set; }


        //修改前单价
        public decimal Price { get; set; }

        /// <summary>
        /// 原增值税额 
        ///</summary>
        public decimal? OriginalVatAmount { get; set; }

        /// <summary>
        /// 原增值税率 
        ///</summary>
        public decimal? OriginalVatRate { get; set; }

        /// <summary>
        /// 原价 
        ///</summary>
        public decimal OriginalPriceAmount { get; set; }

        /// <summary>
        /// 修改前数量 
        ///</summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 增值税额 
        ///</summary>
        public decimal? PriceVatAmount { get; set; }
        /// <summary>
        /// 增值税率 
        ///</summary>
        public decimal? PriceVatRate { get; set; }
        /// <summary>
        /// 异常信息 
        ///</summary>
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// 创建时间 
        ///</summary>
         public DateTime CreationTime { get; set; }
        /// <summary>
        /// 创建人姓名 
        ///</summary>
         public string CreateUserName { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public string CreatorUserId { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public string CreatorDepartmentId { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public string CreatorOrganizeId { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public string LastModifierUserName { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public string LastModifierUserId { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public string LastModificationTime { get; set; }
        /// <summary>
        /// 删除状态 
        ///</summary>
         public byte IsDeleted { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public string DeleteUserName { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public string DeleterUserId { get; set; }
        /// <summary>
        ///  
        ///</summary>
         public DateTime? DeletionTime { get; set; }
        /// <summary>
        /// 标题 
        ///</summary>
         public string TitleEn { get; set; }
    }
}
