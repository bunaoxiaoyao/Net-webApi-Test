using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Entity.Json
{
    public class CaJsonParse
    {
        /// <summary>
        /// 法语
        /// </summary>
        public string Fr { get; set; }

        /// <summary>
        /// 英语
        /// </summary>
        public string En { get; set; }
    }

    public class KeyFeature
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language{ get; set; }

        /// <summary>
        /// 五点描述
        /// </summary>
        [JsonProperty("keyFeatures")]
        public List<string> KeyFeatures { get; set; }
    }
}
