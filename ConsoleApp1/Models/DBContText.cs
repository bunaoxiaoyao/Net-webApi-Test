using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class DBContText
    {
        public static ISqlSugarClient GetSqlClient()
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = @"Server=gz-cdb-ezvn7csl.sql.tencentcdb.com;port=58892;database=bailun_bltpro;uid=root;password=shengye2021;Convert Zero Datetime=True;Allow User Variables=True;pooling=true", //必填, 数据库连接字符串 公司数据库
                //ConnectionString = @"server=localhost;database=text;uid=root;password=wojiaoyk123;port=3306;Convert Zero Datetime=True;SslMode=none;", //必填, 数据库连接字符串 本地库
                //DbType = System.Data.DbType.MySql, //必填, 数据库类型
                IsAutoCloseConnection = true, //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                InitKeyType = InitKeyType.SystemTable, //默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息
            });
        }
    }
}
