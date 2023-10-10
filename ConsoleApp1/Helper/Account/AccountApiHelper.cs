using ConsoleApp1.Helper.Account.Dto;
using MiniExcelLibs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper.Account
{
    public static  class AccountApiHelper
    {
        // 从配置对象中获取配置值
        //string url = ConfigurationManager.AppSettings["MicroServiceUrl:AccountUrl"].ToString();
        public static string  url = "https://pams.shengweiinc.com";

        /// <summary>
        /// 根据店铺id获取店铺信息
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static PlatformAccountData GetPlatformAccount(long accountId)
        {
            try
            {
                var restclient = new RestClient(url);
                var request = new RestRequest($"/Api/GetAccountToken?id={accountId}", Method.Get);
                var response = restclient.Execute(request);
                byte[] encodeBytes = Encoding.UTF8.GetBytes(response.Content);
                string content = Encoding.UTF8.GetString(encodeBytes);
                var account = JsonConvert.DeserializeObject<PlatformAccountDto>(content);
                if (account.Success && account.Data != null)
                    return account.Data[0];
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
