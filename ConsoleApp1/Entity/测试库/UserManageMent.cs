using MiniExcelLibs.Attributes;
using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Entity.测试库
{
    /// <summary>
    /// 
    /// </summary>
    [SugarTable("user_manage_ment")]
    public class UserManageMent
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [ExcelColumnName("姓名")]
        public System.String Name { get; set; }

        /// <summary>
        /// 年纪
        /// </summary >
        [ExcelColumnName("年纪")]
        public System.String Sex { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public System.Int32? Grade { get; set; }

    }
}
