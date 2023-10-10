using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Count
    {
        /// <summary>
        /// 餐补
        /// </summary>
        public int Countnum { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string Name { get; set; }

        public int FortyMinutes { get; set; }

        /// <summary>
        /// 其他假期
        /// </summary>
        public string NameHoliday { get; set; }

        /// <summary>
        /// 迟到5分钟   6-10  5次扣30
        /// </summary>
        public int Num6_10 { get; set; }
        public decimal Monery6_10 { get; set; }

        /// <summary>
        /// 迟到15分钟   11-20   3次扣50
        /// </summary>
        public int Num11_20 { get; set; }
        public decimal Monery11_20 { get; set; }

        /// <summary>
        /// 迟到25分钟    21-30   1次50块钱
        /// </summary>
        public int Num21_30 { get; set; }
        public decimal Monery21_30 { get; set; }

        /// <summary>
        /// 迟到半小时   31-60  1次  
        /// </summary>
        public int Num31_60 { get; set; }
        public decimal MoneryHour { get; set; }

        /// <summary>
        /// 上班矿工迟到1小时前  1次 旷工半天
        /// </summary>
        public int Absenteeism1Front { get; set; }

        /// <summary>
        /// 上班矿工迟到1小时后    1次 旷工一天
        /// </summary>
        public int Absenteeism1Queen { get; set; }
        public decimal MoneryAbsenteeism { get; set; }

        /// <summary>
        /// 早退
        /// </summary>
        public int LeaveEarly { get; set; }

        /// <summary>
        /// 上班缺卡
        /// </summary>
        public int UpClassLackCalorie { get; set; }

        /// <summary>
        /// 下班缺卡
        /// </summary>
        public int NextClassLackCalorie { get; set; }

        /// <summary>
        /// 缺卡一整天
        /// </summary>
        public int LackCalorie { get; set; }
    }
}
