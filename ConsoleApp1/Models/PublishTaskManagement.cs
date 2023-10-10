using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class PublishTaskManagement
    {

    }
    [SugarTable("PublishTaskManagement")]//当和数据库名称不一样可以设置表别名 指定表明
    public class Student
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//数据库是自增才配自增 
        public long Id { get; set; }
        public string ListerIds { get; set; }
        [SugarColumn(ColumnName = "StudentName")]//数据库与实体不一样设置列名 
        public long AccountId { get; set; }
        public int MyProperty { get; set; }
    }
}
