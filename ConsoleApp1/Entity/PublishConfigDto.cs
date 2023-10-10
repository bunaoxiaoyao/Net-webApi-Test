using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity
{
    public class PublishConfigDto
    {
        public int PublishTitleType { get; set; }
        public string PublishTitleTypeName { get; set; }
        public int Num { get; set; }
        /// <summary>
        /// 是否需要去重，0：否 1：是
        /// </summary>
        public bool IsQuChong { get; set; } = true;
    }
    public enum PublishTitleTypeEnum
    {
        [Description("核心关键词")]
        CoreKey = 1,
        [Description("长尾关键词")]
        LongTailKey = 2,
        [Description("使用人群")]
        UserPeople = 3,
        [Description("适应场景")]
        FitScene = 4,
        [Description("形容词")]
        Adjective = 5
    }
}
