using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper.Account.Dto
{
    public class PlatformAccountDto
    {
        public bool Success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PlatformAccountData> Data { get; set; }
    }
    public class PlatformAccountData
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountAlias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmailAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OmsCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OmsAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PlatformId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PlatformEn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SiteId { get; set; }
        /// <summary>
        /// 美国
        /// </summary>
        public string Site { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SiteEn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SiteCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AuthJson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        public string StatusCn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SoapAuthToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SoapAuthStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AuthStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExtensionInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeveloperJson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Manager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SellerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EbayAdAuthJson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AmazonAdAuthJson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MultiDeveloperToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderCrawlStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TaxNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PicCodingUrl { get; set; }
    }
}
