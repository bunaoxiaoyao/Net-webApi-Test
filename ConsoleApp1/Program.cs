using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using ConsoleApp1.Entity;
using t_bi_walmart_publish_task_management;
using ConsoleApp1.Helper;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Web.UI.WebControls;
using OfficeOpenXml.Style;
using System.Threading;
using System.Collections;
using System.Reflection;
using Sunway.Task.Data.Entity.FyndiqListing;
using Newtonsoft.Json;
using OfficeOpenXml.Drawing;
using ConsoleApp1.Entity.测试库;
using ConsoleApp1.Entity.Json;
using System.Security.Cryptography;
using Image = System.Drawing.Image;
using System.Web;
using Microsoft.Win32.TaskScheduler;
using StackExchange.Redis;
using System.Configuration;
using DeveloperSharp.Redis;
using MiniExcelLibs;
using ICSharpCode.SharpZipLib.Zip;
using RestSharp;
using System.Net.Http;
using OfficeOpenXml.FormulaParsing.ExpressionGraph.CompileStrategy;
using NPOI.Util;
using ZXing;
using ZXing.Common;
using ConsoleApp1.Entity.墨西哥站点;
using ConsoleApp1.Entity.Common;
using ConsoleApp1.Helper.Account;
using ConsoleApp1.Helper.Account.Dto;

namespace ConsoleApp1
{
    class Program
    {
        static double[,] arry = new double[100, 100];
        private readonly static object lockObject = new object();

        public enum RoundingMode 
        {
            Floor,
            Ceiling,
            HalfUp
        }

        public class ColorStatus
        {
            public string Color { get; set; }
            public int Status { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public string Color { get; set; }
            public string Size { get; set; }
        }
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            test();
            Console.WriteLine();
            Console.ReadLine();
        }

        #region 二维码 条形码
        /// <summary>
        /// 二维码
        /// </summary>
        public static void QR() 
        {
            string content = "zhen de you dian chou";
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new EncodingOptions
            {
                Width = 300,
                Height = 300
            };

            // 自定义渲染器来改变颜色
            barcodeWriter.Renderer = new ZXing.Rendering.BitmapRenderer
            {
                Foreground = Color.Brown,    // 设置前景色（二维码的颜色）
                Background = Color.White   // 设置背景色
            };

            Bitmap bitmap = barcodeWriter.Write(content);


            // 保存二维码为文件
            bitmap.Save(@"D:\\二维码\qrcode.png");
        }
        #endregion

        static decimal GetPrice(decimal price)
        {
            decimal result;
            decimal fractionalPart = price - Math.Floor(price);

            if (fractionalPart < Convert.ToDecimal(0.50))
            {
                result = Math.Floor(price) - Convert.ToDecimal(0.01);
            }
            else
            {
                result = Math.Floor(price * 10) / 10 + Convert.ToDecimal(0.09);
            }

            return Math.Round(result, 2);
        }

        /// <summary>
        /// 定时任务    
        /// </summary>
        public static void TimedTask()
        {
            TaskService taskService = new TaskService();
            TaskDefinition taskDefinition = taskService.NewTask();
            taskDefinition.RegistrationInfo.Description = "My task description";
            taskDefinition.Settings.Enabled = true;
            taskDefinition.Data = ""; 
            taskDefinition.Settings.StartWhenAvailable = true;
            taskDefinition.Settings.RunOnlyIfIdle = false;
            TimeSpan delay = TimeSpan.FromMinutes(1);
            taskDefinition.Triggers.Add(new TimeTrigger(DateTime.Now.Add(delay))
            {
                Repetition = new RepetitionPattern(TimeSpan.FromMinutes(30), TimeSpan.FromDays(1))
            });
            taskDefinition.Actions.Add(new ExecAction("path/to/your/executable", "arguments", null));
            taskService.RootFolder.RegisterTaskDefinition("My Task Name", taskDefinition);
        }

        public static void show(ref bool isok)
        {
            isok = true;
        }
        
        /// <summary>
        /// 调用韩小韩api，随机获取一张头像
        /// </summary>
        public static async Task<string>  GetImage() 
        {
            var options = new RestClientOptions("https://api.vvhan.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/mobil.girl?type=json", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            var rootImage = JsonConvert.DeserializeObject<Root>(response.Content);
            return rootImage.imgurl;
        }

        /// <summary>
        /// 
        /// </summary>
        public async static Task<string> Shop() 
        {
            string apiUrl = "http://localhost:5003/ProductPropertyCommon/GetSalesStatus"; // 替换为实际的API URL

            List<string> proSkus = new List<string> { "DFB04322500", "DFB04315300" };
            string queryString = string.Join(",", proSkus);
            string requestUrl = $"{apiUrl}?proSkus={queryString}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // 在这里处理返回的JSON数据，例如进行反序列化等操作
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    Console.WriteLine("HTTP Request failed with status code: " + response.StatusCode);
                }
            }
            return null;
        }



        #region 读取文件流

        /// <summary>
        /// 读取流
        /// </summary>
        public static void FileInputStream() 
        {
            string filePath = @"D:\公司资料\C#文件流测试文件.txt";
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // 处理每一行数据
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 写入流
        /// </summary>
        public static void FileOutputStream()
        {
            string filePath = @"D:\公司资料\C#文件流测试文件.txt";
            try
            {
                Console.WriteLine("请输入你要写入的文字");               
                string data = Console.ReadLine();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(data);
                    }
                }

                Console.WriteLine("Data has been written to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        #endregion

        #region 判断四舍或五入
        /// <summary>
        /// 判断是否四舍或五入
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static RoundingMode GetRoundingMode(double number)
        {
            double decimalPart = number - Math.Floor(number); // 获取小数部分
            if (decimalPart < 0.5)
            {
                return RoundingMode.Floor;
            }
            else if (decimalPart >= 0.5)
            {
                return RoundingMode.Ceiling;
            }
            else
            {
                return RoundingMode.HalfUp;//等于
            }
        }
        #endregion

        #region 提取json里面的属性名称属性值与提供的string对应上并去除
        public void ReplaceTitle(string title) 
        {
             title = "Niuer Women Mini Dress Pleated Summer Beach Sundress Pocket Short Dresses Casual Sleeve Gray 2XL";
            string json = "[{\"name\":\"actual_color\",\"value\":\"Gray\"},{\"name\":\"clothing_size\",\"value\":\"2XL\"}]";

            // 解析 JSON 数据
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

            // 提取颜色和尺码
            string color = data.Find(d => d["name"] == "actual_color")["value"];
            string size = data.Find(d => d["name"] == "clothing_size")["value"];

            // 使用正则表达式匹配标题并去除
            string pattern = $@"{color}\s+{size}";
            string result = Regex.Replace(title, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        #endregion

        #region 补字符或数字
        /// <summary>
        /// 补数字，或字符串
        /// </summary>
        /// <param name="num">需要补多少个零</param>
        /// <param name="number">你需要补零的号码</param>
        /// <returns></returns>
        public static int PadLeft(int num,int number) 
        {
            //number=123;num=2
            string paddedString = number.ToString().PadLeft(num, '0');//往左边补零
            Console.WriteLine(paddedString);//00123
            string paddedStringTwo = number.ToString().PadRight(num, '0');//往又边补零
            Console.WriteLine(paddedStringTwo);//12300
            return Convert.ToInt32(paddedString);
        }
        #endregion

        #region 连接Linux上的redis
        /// <summary>
        /// redis应用 连接Linux上的redis
        /// </summary>
        public static string ReidsUse(string str) 
        {
            // 存储字符串示例
            RedisHelper.SetStringKey("MyText", str);

            // 检索字符串示例
            string aa = RedisHelper.GetStringKey("MyText");

            // 存储对象示例
            UserManageMent obj = new UserManageMent { Name = "王老师", Grade = 42 };
            RedisHelper.SetStringKey("MyTeacher", obj);

            // 检索对象示例
            UserManageMent t = RedisHelper.GetStringKey<UserManageMent>("MyTeacher");
            string Name = t.Name;
            int Age = t.Grade.Value;
            return RedisHelper.GetStringKey("MyText");
        }
        #endregion

        #region 验证字符串有数字

        /// <summary>
        /// 正则验证字符串是否是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            // return Regex.IsMatch(value, @"^[+-]?/d*[.]?/d*$");
            // return Regex.IsMatch(value, @"^[+-]?/d*$");

            return Regex.IsMatch(value, @"^/d*[.]?/d*$");
        }

        /// <summary>
        /// 验证字符串是否包含数字包含饭会true否则false
        /// </summary>
        /// <param name="texts"></param>
        /// <returns></returns>
        public static bool ContainsNum(string texts)       //判断是否输入数字的方法(不包含小数) texts 是传入的文本
        {
            bool IsContain = false;
            int[] num = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < num.Length; i++)
            {
                if (texts.Contains(num[i].ToString()))
                {
                    IsContain = true;
                }
            }
            return IsContain;       //返回True 则说明有数字输入  false 就没有输入数字
        }
        #endregion

        #region 公司需求：我有一个字符串，里面的值是这样的"95% Polyester 5% Spandex".我想将其拆分为两个字符串第一个是"95% Polyester"第二个是"5% Spandex"

        /// <summary>
        /// 运算算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> OperationArithmetic()
        {
           string str = "05% Po25242lyester 5 %Spand24525425ex";//测试数据1
           // str = "100%dhasudhias";//测试数据2
            str = str.Replace(" ", "");
            int num = str.IndexOf('%');
            int end1 = 0;
            if (num == 2)
            {
                end1 = str.LastIndexOfAny(new char[] { '%', ' ' }) - 1;
            }
            else if (num == 3)
            {
                var strList = str.Split(' ').ToList();
            }
            else
            {
                end1 = str.LastIndexOfAny(new char[] { '%', ' ' }) - 2;
            }
            string sub = str.Substring(0, end1);
            var strs = str.Replace(sub, sub + ",").Trim().Split(',').ToList();
            return strs;
        }

        /// <summary>
        /// 分解运算
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> BreakDownArithmetic() 
        {
            string str = "92%polyester 5%spandex";//测试数据1
                                                          // str = "100%dhasudhias";//测试数据2
            str = str.Replace(" ", "");
            // 使用正则表达式截取字符串中的数字
            string pattern = @"\d+(\.\d+)?"; // 匹配整数或浮点数
            MatchCollection matches = Regex.Matches(str, pattern);//使用正则表达式找出所有的数字
            int count = str.ToCharArray().Count(c => c == '%');
            List<string> strs = new List<string>();
            for (int i = count-1; i >= 0; i--)
            {
                string subString = str.Substring(str.IndexOf(matches[i].Value));//从末尾的第一个数字开始截取包含数字以及前面的单词
                strs.Add(subString);
                str = str.Replace(subString, "");
            }
            return strs;

        }
        #endregion

        #region 随机数
        /// <summary>
        /// 抽取
        /// </summary>
        /// <param name="probabilityList"></param>
        /// <returns></returns>
        public static int Choose(int[] probabilityList)
        {
            int total = 0;
            //首先计算出概率的总值，用来计算随机范围
            for (int i = 0; i < probabilityList.Length; i++)
            {
                total += probabilityList[i];
            }
            Random rd = new Random();
            int randomDigit = rd.Next(0, total);
            for (int i = 0; i < probabilityList.Length; i++)
            {
                if (randomDigit < probabilityList[i])
                {
                    return i;
                }
                else
                {
                    randomDigit -= probabilityList[i];
                }
            }
            return probabilityList.Length - 1;
        }

        /// <summary>
        /// 随机字节，数字字母结合
        /// </summary>
        public static void RandomByteID()
        {
            //随机产生0到99直接的一个数，可随机产出100个不同的数
            for (int i = 0; i < 10; i++)
            {
                RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
                byte[] byteCsp = new byte[10];
                csp.GetBytes(byteCsp);
                Console.WriteLine(BitConverter.ToString(byteCsp));
            }
        }

        /// <summary>
        /// 概率
        /// </summary>
        public static void RandomDigit()
        {
            Random r = new Random();
            //随机产生0到99直接的一个数，可随机产出100个不同的数
            int num = r.Next(100);
            if (num >= 0 && num < 50)//num大于等于0并小于50概率为50/100=50%
            {
                Console.WriteLine("此时掉落金币");
            }
            if (num >= 50 && num < 70)//以下同理
            {
                Console.WriteLine("此时掉落钱包");
            }
            if (num >= 70 && num < 100)
            {
                Console.WriteLine("此时无东西掉落");
            }
        }
        #endregion

        #region Dictionary键值对集合复杂嵌套，大键，包含小键小值

        public void Complexdictionary(Dictionary<int, Dictionary<string, string>> keyValues)
        {
            keyValues.Add(1, new Dictionary<string, string>());
            keyValues[1].Add("unit_count", "1");
            Console.WriteLine(keyValues[1].Values);
        }

        #endregion

        #region 去重linq
        /// <summary>
        /// 根据条件去重实体类
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static List<UserManageMent> DistinctClass(List<UserManageMent> users)
        {
            users = users.Where((x, i) => users.FindIndex(z => z.Name == x.Name) == i).ToList();
            return users;
        }

        /// <summary>
        /// 分组筛选并根据条件去重
        /// </summary>
        public static void GroupByDistinct()
        {
            List<ColorStatus> data = new List<ColorStatus>
            {
                 new ColorStatus { Color = "red", Status = 0 },
                new ColorStatus { Color = "red", Status = 0 },
                new ColorStatus { Color = "red", Status = 1 },
                new ColorStatus { Color = "pink", Status = 0 },
                new ColorStatus { Color = "pink", Status = 1 },
                new ColorStatus { Color = "pink", Status = 1 },
                new ColorStatus { Color = "blue", Status = 0 },
                new ColorStatus { Color = "blue", Status = 3 },
                new ColorStatus { Color = "blue", Status = 0 },
                new ColorStatus { Color = "green", Status = 0 },
                new ColorStatus { Color = "green", Status = 0 },
                new ColorStatus { Color = "green", Status = 1 }
            };

            var result = data.GroupBy(cs => cs.Color)
                             .Select(group =>
                             {
                                 var statusGreaterThanZero = group.Where(cs => cs.Status > 0);
                                 if (statusGreaterThanZero.Any())
                                     return statusGreaterThanZero.First();
                                 return group.First();
                             })
                             .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"Color: {item.Color}, Status: {item.Status}");
            }
        }

        #endregion

        #region 将字符串的第一个字母改成大小写
        /// <summary>
        /// 改为大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;
            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);
            return str.ToUpper();
        }
        /// <summary>
        /// 改小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstLetterToLower(string str) 
        {
            if (str == null)
                return null;
            if (str.Length > 1)
                return char.ToLower(str[0]) + str.Substring(1);
            return str.ToLower();
        }
        #endregion

        #region 利用index取值集合里面某个值的位置
        public static void ListIndexOf()
        {
            string a = "color|size";
            string b = "red|S";
            string[] colorSize = a.Split('|');
            string[] sizeColor = b.Split('|');
            int index = colorSize.ToList().IndexOf("size");
            var list = new List<string>()
            {
                colorSize[index],
                sizeColor[index]
            };
            Console.WriteLine(index);
        }
        #endregion

        #region switch Case共用 
        public static void SwitchShow()
        {
            string Name = Console.ReadLine();
            switch (Name)
            {
                case "汤纪元":
                case "汤圆":
                    Console.WriteLine("人名:" + Name);
                    break;
                case "动物":
                case "马马虎虎":
                case "熊大熊二":
                    Console.WriteLine("动物名称:" + Name);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 非创建实体
        /// <summary>
        /// 非创建实体
        /// </summary>
        public void TheEntity()
        {
            object obj = new
            {
                Name = "小明",
                SayHi = "你妹的！"
            };

            dynamic dyName = ((dynamic)obj).Name;
            dynamic dySayHi = ((dynamic)obj).SayHi;

            Console.WriteLine(dyName + "\t" + dySayHi);
        }
        #endregion

        #region  ref out 关键字
        /// <summary>
        /// 测试 ref out 关键字
        /// </summary>
        /// <param name="str"></param>
        /// 引用类型赋值等于创建一个新的对象
        public static void Setstr(ref string str)
        {
            str = "0";
        }
        /// <summary>
        /// 
        /// </summary>
        public static void SetInt(int a)
        {
            a = 0;
        }
        #endregion

        #region 正则表达式
        /// <summary>
        /// 正则表达式判断字符串是否为汉字（不包含中文符号）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

        /// <summary>
        /// 去掉字符串中有转义字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceStr(string str) 
        {
            // 1 去掉转义字符
            return str.Replace(@"([^|\\]|\\.)+", "");
        }
        #endregion

        #region 判断字符串是否为汉字
        /// <summary>
        /// 判断字符串是否为汉字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChineseChar(string str)
        {
            if (str != null)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if ((int)str[i] > 127)
                        return true;
                }
            }
            return false;
        }
        #endregion

        #region 人民币 数字转中文大写
        /// <summary>
        /// 人民币大写
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字 
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
            string str3 = "";    //从原num值中取出的值 
            string str4 = "";    //数字的字符串形式 
            string str5 = "";  //人民币大写金额形式 
            int i;    //循环变量 
            int j;    //num的值乘以100的字符串长度 
            string ch1 = "";    //数字的汉语读法 
            string ch2 = "";    //数字位的汉字读法 
            int nzero = 0;  //用来计算连续的零值是几个 
            int temp;            //从原num值中取出的值 

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数 
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式 
            j = str4.Length;      //找出最高位 
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分 

            //循环取出每一位需要转换的值 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值 
                temp = Convert.ToInt32(str3);      //转换为数字 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }
        #endregion

        #region 生成实体类
        /// <summary>
        /// 生成实体类  创建上下文
        /// </summary>
        public static void CreateEntity()
        {
            //生成实体类
            var db = DBContText.GetSqlClient();
            // db.DbFirst.Where("t_bi_walmart_listing_log").CreateClassFile(@"D:\code\Sql SugarEntity\DbModels", "Bailun.Walmart.Publish.Core.SqlsugarExtension.Entity");
            //List<User> Users = new List<User>();
            //for (int i = 0; i < 5; i++)
            //{
            //    User user = new User() {
            //        Name="朱晓明",
            //        Sex = $"{i}岁"
            //    };
            //    Users.Add(user);
            //}
            //var userId = db.Insertable(Users).ExecuteReturnBigIdentity();

            var users = db.Queryable<UserManageMent>().Where(p => true).ToList();
            //var KeyFeatures = JsonConvert.DeserializeObject<List<KeyFeature>>(users.Name);
            users.GroupBy(p => new { p.Id }).Select(g => new {Key = g.Key, ListGroup = g }).ToList();//按照id分组
            string t = "dasdsa";
            string m = "dasxs";
            string a = string.Format($@"INSERT INTO `user` ( `Name`, `Sex`, `Grade`)values 
            ('{t}', '{m}', {t}),
            ('{t}', '{m}', {t}),
            ('{t}', '{m}', {t}");
            Console.WriteLine();
            //var txt = db.Queryable<a>().ToList();
        }
        #endregion

        #region 查询优化
        public static void Query()
        {
            string name = "猪头";
            StudentUitl student = new StudentUitl();
            List<StudentUitl> list = new List<StudentUitl>();
            for (int i = 0; i < 100000; i++)
            {

                student.ID = i;
                student.NAME = "猪头";
                if (i == 0)
                {
                    student.NAME = "🐖" + i;
                }
                student.STUDENT_ID = 2000 + i;
                list.Add(student);
                student = new StudentUitl();
            }
            var stu = list.FirstOrDefault(p => p.NAME.Contains(name));
            var result1 = list.FindAll(s => s.NAME == "猪头");
            var result2 = list.Where((StudentUitl s) => s.NAME == "学生15").ToList();


            Console.WriteLine();
        }
        #endregion

        #region List指定位置插入元素
        /// <summary>
        /// List指定位置插入元素
        /// </summary>
        public static void Interposition()
        {
            List<string> list = new List<string>();
            List<string> list1 = new List<string>() { "xasxsajhbcbsda" };
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            list.InsertRange(1, list1);
            var model = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            Console.WriteLine(model);
        }
        #endregion

        #region 递归 阶乘 
        public static void Recursion()
        {
            long num = RecursionFactorial(6);
            Console.WriteLine(num);
        }

        static int Fibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        /// <summary>
        ///递归阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long RecursionFactorial(int n)
        {
            if (n == 0) //限制条件，对该方法调用自己做了限制
                return 1;
            Console.WriteLine(n);
            return n * RecursionFactorial(n - 1);
        }

        /// <summary>
        /// 阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Factorial(int n)
        {
            if (n == 0)
                return 1;
            long value = 1;
            for (int i = n; i > 0; i--)
            {
                value *= i;
            }
            return value;
        }
        #endregion

        #region JSON序列化
        /// <summary>
        /// json对象序列化实体
        /// </summary>
        /// <typeparam name="JSON"></typeparam>
        /// <param name="json"></param>
        public static List<PriceJSON> JSON()
        {
            // var db = DBContText.GetSqlClient();
            //var job = db.Queryable<FyndiqListingJobTask>().Where(p => p.IsDeleted == 0 && p.TaskType.Contains("修改价格与数量") && p.ChangeStatus == 1).ToList();
            List<PriceJSON> priceJSONs = new List<PriceJSON>();
            priceJSONs.Add(new PriceJSON()
            {
                Id = 007,
                Name = "阿元",
                Age = "19"
            });
            var list = new List<string>();
            list.Add("xasbjhbjhacuyashoidjsahdu");
            list.Add("我是阿元，我篮球打的很好");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(priceJSONs);
            var model = JsonConvert.DeserializeObject<List<PriceJSON>>(json);

            model.Take(100);
            Console.WriteLine(model);
            return null;
        }
        #endregion

        #region 多线程

        /// <summary>
        /// 多线程测试一
        /// </summary>
        public static void Text2()
        {
            Console.WriteLine("我无语了");
            Console.WriteLine("靓仔无语");
        }

        /// <summary>
        /// 多线程测试二 加锁
        /// </summary>
        /// <param name="src"></param>
        public static void ThreadLock(Object src)
        {
            lock (lockObject)
            {
                Console.WriteLine("-> {0} is executing Printnumbers(){1}", Thread.CurrentThread.ManagedThreadId, src);
                for (int i = 0; i < 5; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(600 * r.Next(5));
                    Console.Write(i + ",");
                }
            }
            Console.WriteLine("靓仔无语");
        }

        /// <summary>
        /// 并发运行测试
        /// </summary>
        /// <param name="src"></param>
        public static void ConcurrentCirculation()
        {
            List<UserManageMent> Users = new List<UserManageMent>();
            int pageSize = 5000;
            for (int i = 0; i < 20000; i++)
            {
                Users.Add(new UserManageMent()
                {
                    Name = "朱晓明",
                    Sex = $"{i}岁",
                    Grade = 0
                });
            }
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2;
            int a = 0;
            int limit = Users.Count / 10;//页数
            if (limit == 0) limit = 1;
            var VariantGroupIds = Users.ToArray().SplitArray(limit);
            while (Users.Any(p => p.Grade == 0))
            {
                Parallel.ForEach(Users.Where(p => p.Grade == 0).Take(pageSize).ToList(), options, p =>
                {
                    p.Name += "小KK";
                    p.Grade = 1;
                });
                Console.WriteLine("靓仔无语" + a++);
            }
        }

        #region 使用分页拆分集合 控制线程数量
        public void Multithreading()
        {
            //生成实体类
            var db = DBContText.GetSqlClient();
            var listUser = db.Queryable<UserManageMent>().ToList();
            if (listUser.Count == 0) return;
            int limit = listUser.Count / 10;
            if (limit == 0) limit = 1;
            var VariantGroupIds = listUser.ToArray().SplitArray(limit);
            foreach (var VariantGroupId in VariantGroupIds)
            {
                System.Threading.Tasks.Task.Factory.StartNew(() => Average());
                System.Threading.Thread.Sleep(200);
            }
        }
        #endregion

        #endregion

        #region EPPlus读取表取Execl文件导入导出
        /// <summary>
        ///导出Execl
        /// </summary>
        /// <param name="counts"></param>
        /// <param name="type"></param>
        /// <param name="ColCount"></param>
        public static void SaveAttendance(List<Count> counts, string type, int ColCount)
        {
            try
            {
                FileInfo newFile = new FileInfo(@"D:\公司资料\考勤.xlsx");
                if (newFile.Exists)
                {
                    newFile = new FileInfo(@"D:\公司资料\考勤.xlsx");
                }
                if (type == "餐补")
                {
                    using (ExcelPackage package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("餐补");
                        worksheet.View.ShowGridLines = false;//去掉sheet的网格线
                        worksheet.Cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //ExcelPicture picture = worksheet.Drawings.AddPicture("logo", System.Drawing.Image.FromFile(@""));//插入图片
                        //picture.SetPosition(400, 400);//设置图片的位置
                        //picture.SetSize(400, 400);//设置图片的大小
                        worksheet.Cells.Style.Fill.BackgroundColor.SetColor(Color.LightGray);//设置背景色
                        worksheet.Cells.Style.ShrinkToFit = true;//单元格自动适应大小
                        worksheet.Cells[1, 1].Value = "姓名";
                        worksheet.Cells[1, 2].Value = "餐补";
                        worksheet.Cells[1, 3].Value = "餐补Money";
                        for (int i = 1; i <= counts.Count; i++)
                        {
                            int num = i - 1;
                            int row = i + 1;
                            worksheet.Cells[row, 1].Value = counts[num].Name;
                            worksheet.Cells[row, 2].Value = counts[num].Countnum;
                            worksheet.Cells[row, 3].Value = counts[num].Countnum * 15;
                        }
                        package.Save();
                    }
                }
                else if (type == "考勤")
                {
                    using (ExcelPackage package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("考勤");
                        worksheet.View.ShowGridLines = false;//去掉sheet的网格线
                        worksheet.Cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells.Style.Fill.BackgroundColor.SetColor(Color.LightGray);//设置背景色
                        worksheet.Cells.Style.ShrinkToFit = true;//单元格自动适应大小
                        worksheet.Cells[1, 1].Value = "姓名";
                        worksheet.Cells[1, 2].Value = "迟到1-5分钟";
                        worksheet.Cells[1, 3].Value = "迟到6-15分钟";
                        worksheet.Cells[1, 4].Value = "严重迟到16-25分钟";
                        worksheet.Cells[1, 6].Value = "上班矿工1小时前";
                        worksheet.Cells[1, 7].Value = "上班矿工1小时后";
                        worksheet.Cells[1, 8].Value = "上班缺卡";
                        worksheet.Cells[1, 9].Value = "下班缺卡";
                        worksheet.Cells[1, 10].Value = "缺卡一天";
                        worksheet.Cells[1, 11].Value = "早退";
                        for (int i = 1; i <= counts.Count; i++)
                        {
                            int num = i - 1;
                            int row = i + 1;
                            //if (counts[num].Name== "郁沁") 
                            //{

                            //}
                            worksheet.Cells[row, 1].Value = counts[num].Name;
                            worksheet.Cells[row, 2].Value = counts[num].Num6_10;
                            worksheet.Cells[row, 3].Value = counts[num].Num11_20;
                            worksheet.Cells[row, 4].Value = counts[num].Num21_30;
                            worksheet.Cells[row, 6].Value = counts[num].Absenteeism1Front;
                            worksheet.Cells[row, 7].Value = counts[num].Absenteeism1Queen;
                            worksheet.Cells[row, 8].Value = counts[num].UpClassLackCalorie;
                            worksheet.Cells[row, 9].Value = counts[num].NextClassLackCalorie;
                            worksheet.Cells[row, 10].Value = counts[num].LackCalorie;
                            worksheet.Cells[row, 11].Value = counts[num].LeaveEarly;
                        }
                        package.Save();
                    }
                    using (ExcelPackage package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("扣钱");
                        worksheet.View.ShowGridLines = false;//去掉sheet的网格线
                        worksheet.Cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells.Style.ShrinkToFit = true;//单元格自动适应大小
                        worksheet.Cells.Style.Fill.BackgroundColor.SetColor(Color.LightGray);//设置背景色
                        worksheet.Cells[1, 1].Value = "姓名";
                        worksheet.Cells[1, 2].Value = "迟到6-10分钟 扣钱";
                        worksheet.Cells[1, 3].Value = "迟到11-20分钟 扣钱";
                        worksheet.Cells[1, 4].Value = "迟到21-30分钟 扣钱";
                        worksheet.Cells[1, 5].Value = "总和";
                        for (int i = 1; i <= counts.Count; i++)
                        {
                            int num = i - 1;
                            int row = i + 1;
                            worksheet.Cells[row, 1].Value = counts[num].Name;
                            worksheet.Cells[row, 2].Value = counts[num].Monery6_10;
                            worksheet.Cells[row, 3].Value = counts[num].Monery11_20;
                            worksheet.Cells[row, 4].Value = counts[num].Monery21_30;
                            worksheet.Cells[row, 5].Value = counts[num].Monery21_30 + counts[num].Monery6_10 + counts[num].Monery11_20;
                        }
                        package.Save();
                    }
                }
                if (!newFile.Exists)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 导入考勤
        /// </summary>
        public static void ImportAttendance(string excelName)
        {
            FileInfo newFile2 = new FileInfo(excelName);
            FileInfo newFile = new FileInfo(@"D:\公司资料\考勤.xlsx");
            if (!newFile2.Exists)
            {
                return;
            }
            if (newFile.Exists)
            {
                newFile.Delete();
            }
            try
            {
                using (ExcelPackage package = new OfficeOpenXml.ExcelPackage(newFile2))
                {
                    for (int w = 0; w <= 1; w++)
                    {

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[w];

                        int rowCount = worksheet.Dimension.Rows;
                        int ColCount = worksheet.Dimension.Columns;
                        if (w == 0)
                        {
                            List<Count> nums = new List<Count>();
                            for (int i = 3; i <= rowCount; i++)
                            {
                                Count ct = new Count();
                                string columnName = worksheet.Cells[i, 1].Value?.ToString()?.Trim();
                                ct.Name = columnName;
                                int a = 0;
                                for (int j = worksheet.Dimension.Start.Column, k = worksheet.Dimension.End.Column; j <= k; j++)
                                {
                                    #region 判断迟到人数
                                    string th = worksheet.Cells[i, j + 1].Value?.ToString()?.Trim();
                                    if (!string.IsNullOrWhiteSpace(th) && th != "正常" && th != "休息")
                                    {
                                        int index = th.IndexOf("上班迟到");
                                        int index2 = th.IndexOf("上班旷工迟到");
                                        int index4 = th.IndexOf("旷工");
                                        int index5 = th.IndexOf("早退");
                                        int index6 = th.IndexOf("上班缺卡");
                                        int index7 = th.IndexOf("下班缺卡");
                                        int index8 = th.IndexOf("上班严重迟到");
                                        if (index >= 0)
                                        {
                                            string q = "到";
                                            string b = "分";
                                            int time = Convert.ToInt32(th.Substring(th.IndexOf(q) + 1, th.IndexOf(b) - th.IndexOf(q) - 1));
                                            if (time <= 5)
                                            {
                                                ct.Num6_10++;
                                            }
                                            if (time >= 6 && time <= 15)
                                            {
                                                ct.Num11_20++;
                                            }
                                        }
                                        if (index2 >= 0)
                                        {
                                            int x = th.IndexOf("小时");
                                            if (x >= 0)
                                            {
                                                ct.Absenteeism1Queen++;
                                            }
                                            else
                                            {
                                                ct.Absenteeism1Front++;
                                            }
                                        }
                                        if (index5 >= 0)
                                        {
                                            ct.LeaveEarly++;
                                        }
                                        if (index6 >= 0)
                                        {
                                            ct.UpClassLackCalorie++;
                                        }
                                        if (index7 >= 0)
                                        {
                                            ct.NextClassLackCalorie++;
                                        }
                                        if (index4 >= 0 && index2 >= -1)
                                        {
                                            ct.LackCalorie++;
                                        }
                                        if (index8 >= 0)
                                        {
                                            ct.Num21_30++;

                                        }
                                    }
                                    #endregion
                                }
                                nums.Add(ct);
                            }
                            DeductMoney(nums);
                            SaveAttendance(nums, "考勤", rowCount);
                        }
                        else
                        {
                            List<Count> nums = new List<Count>();
                            for (int i = 2; i <= rowCount; i++)
                            {
                                Count ct = new Count();
                                string columnName = worksheet.Cells[i, 1].Value?.ToString()?.Trim();
                                ct.Name = columnName;
                                int a = 0;
                                for (int j = worksheet.Dimension.Start.Column, k = worksheet.Dimension.End.Column; j <= k; j++)
                                {
                                    #region 判断颜色单元格
                                    // if (w == 0) continue;
                                    var s = worksheet.Cells[i, j + 1].Value?.ToString()?.Trim();
                                    ExcelColor columnCNName = worksheet.Cells[i, j + 1].Style.Fill.BackgroundColor;
                                    if (columnCNName.Rgb == "FFFFFF00" && columnCNName.Rgb != null)
                                    {
                                        a++;
                                    }
                                    #endregion
                                }
                                ct.Countnum = a;
                                nums.Add(ct);
                            }
                            SaveAttendance(nums, "餐补", rowCount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 迟到扣罚
        /// </summary>
        public static void DeductMoney(List<Count> Money)
        {
            for (int i = 0; i < Money.Count; i++)
            {

                string name = Money[i].Name;
                int Num6_10 = Money[i].Num6_10;
                int seriousLate = Money[i].Num11_20 % 3;
                if (seriousLate > 0)
                {
                    Num6_10 += seriousLate;
                }

                int count6_10 = Num6_10 / 5;
                int count11_20 = Money[i].Num11_20 / 3;
                int count21_30 = Money[i].Num21_30 / 1;

                if (count6_10 > 0)
                {
                    Money[i].Monery6_10 = count6_10 * 30;
                }
                if (count11_20 > 0)
                {
                    Money[i].Monery11_20 = count11_20 * 50;
                }
                if (count21_30 > 0)
                {
                    Money[i].Monery21_30 = count21_30 * 50;
                }
            }
        }

        /// <summary>
        /// 读取上架配置表格进入公司数据库
        /// </summary>
        public static void ImportAddedConfig()
        {
            //获取表格地址
            FileInfo newFile = new FileInfo(@"D:\公司资料\Walmart标题配置--11月8日 (1).xlsx");
            if (!newFile.Exists)
            {
                return;
            }
            try
            {
                using (ExcelPackage package = new OfficeOpenXml.ExcelPackage(newFile))
                {
                    //生成实体类
                    var db = DBContText.GetSqlClient();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];//execl第一张表
                    int rowCount = worksheet.Dimension.Rows;//列
                    int ColCount = worksheet.Dimension.Columns;//行
                    List<WalmartPublishConfig> publishConfigDtos = new List<WalmartPublishConfig>();
                    var walmartPublishCofigs = db.Queryable<WalmartPublishConfig>().ToList();
                    for (int i = 2; i <= rowCount; i++)
                    {
                        //这里我是重第二行开始，列少表头固定，所以写死不需要判断表头
                        string columnName = worksheet.Cells[i, 1].Value?.ToString()?.Trim();
                        Console.WriteLine(columnName);
                        string AddedConfigName = worksheet.Cells[i, 1].Value?.ToString()?.Trim();
                        string ShopAlias = worksheet.Cells[i, 3].Value?.ToString()?.Trim();
                        string Site = worksheet.Cells[i, 2].Value?.ToString()?.Trim();
                        var publishCofig = walmartPublishCofigs.Where(p => p.AddedConfigName == AddedConfigName).FirstOrDefault();
                        if (publishCofig != null)
                        {
                            List<PublishConfigDto> publishConfigs = new List<PublishConfigDto>();
                            var titleJson = worksheet.Cells[i, 4].Value?.ToString()?.Trim();
                            //处理数据将标题转换为json格式
                            if (!string.IsNullOrWhiteSpace(titleJson)) 
                            {
                                var titleJsons = titleJson.Split('+').ToList();
                                foreach (var item in titleJsons)
                                {
                                    PublishConfigDto publishConfigDto = new PublishConfigDto();
                                    int count = item.IndexOf('(');
                                    int str = item.Length;
                                    var publishTitleTypeName = item.Replace(item.Substring(count, 3), "");
                                    publishConfigDto.IsQuChong = true;
                                    publishConfigDto.Num = Convert.ToInt32(item.Substring(count + 1, 1));
                                    if (publishTitleTypeName == "使用场景")
                                    {
                                        publishTitleTypeName = "适应场景";
                                    }
                                    publishConfigDto.PublishTitleTypeName = publishTitleTypeName;
                                    int numBer = Switch(item.Replace("(1)", ""));
                                    publishConfigDto.PublishTitleType = Switch(item.Replace("(1)", ""));
                                    publishConfigs.Add(publishConfigDto);
                                    Console.WriteLine("数量" + publishConfigDto.Num + "\n类型" + publishConfigDto.PublishTitleType + "\n名称" + publishConfigDto.PublishTitleTypeName);
                                }
                                publishCofig.TitleConfigJson = Newtonsoft.Json.JsonConvert.SerializeObject(publishConfigs);
                                publishConfigDtos.Add(publishCofig);
                            }
                        }  
                    }
                   var result =  db.Updateable(publishConfigDtos).ExecuteCommand();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int Switch(string titleName) {
            switch (titleName)
            {
                case "核心关键词":
                    return 1;
                case "长尾关键词":
                    return 2;
                case "使用人群":
                    return 3;
                case "适应场景":
                    return 4;
                case "形容词":
                    return 5;
                case "使用场景":
                    return 3;
                default:
                    break;
            }
            return 0;
        }

        #endregion

        #region MiniExecl读取表取Execl文件导入导出
        /// <summary>
        /// 轻量级框架读取Execl（miniExecl）
        /// </summary>
        public static void miniExeclRead()
        {
            using (var stream = File.OpenRead(@"D:\公司资料\user_manage_ment.xlsx"))
            {
                var rows = stream.Query<UserManageMent>().ToList();
                Console.WriteLine(rows);
            }
        }

        /// <summary>
        /// 轻量级框架导出Execl（miniExecl）
        /// </summary>
        public static void MinniExeclExport() 
        {
            //Path.GetTempPath() 默认C:\Users\Administrator\AppData\Local\Temp，可以自己手动设置地址
            //var path = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.xlsx");
            var path = Path.Combine(@"D:\公司资料", $"{Guid.NewGuid()}.xlsx");
            //生成实体类
            var db = DBContText.GetSqlClient();
           var configs = db.Queryable<WalmartPublishConfig>().Where(p => p.IsDeleted == false).ToList();
            foreach (var item in configs)
            {
                if (!string.IsNullOrEmpty(item.TitleConfigJson))
                {
                    item.TitleConfigs.AddRange(JsonHelper.FromJsonList<TitleConfig>(item.TitleConfigJson));
                }
                if (item.TitleConfigs != null && item.TitleConfigs.Count > 0)
                {
                    var content = new List<string>();
                    item.TitleConfigs.ForEach(u => {
                        content.Add($"{u.PublishTitleTypeName}({u.Num})");
                    });

                    item.TitleConfigNames =  content.Join("+");
                }
                else
                {
                    item.TitleConfigNames = "";
                }
            }
            MiniExcel.SaveAs(path, configs.Select(p=> new {p.AddedConfigName,p.ShopAlias,p.TitleConfigNames}));//该方法两个属性（导出的盘符地址，集合）这种方式直接导出，使用集合里的字段做列名
        }

        /// <summary>
        /// 导出框架（NPOI）墨西哥范本导出
        /// </summary>
        public static void test()
        {
            var pathExport = Path.Combine(@"D:\公司资料\墨西哥测试文件夹", $"服装测试数据{Guid.NewGuid()}MX.xlsx"); //导出地址于表格名称
            var pathToExcelFile = @"D:\公司资料\墨西哥服装刊登测试.xlsx";
            var worksheetName = "Ropa"; // 你的工作表名称
            //var startColumnIndex = 4; // 指定起始列的索引，这里表示第 4 列（D列）
            //var headerRowIndex = 5; // 指定表头所在行
            //var dataStartRowIndex = 10; // 指定数据起始行

            //生成实体类
            var db = DBContText.GetSqlClient();
            List<long>  listerIds = new List<long> { 1 };
            var listers = db.Queryable<WalmartListerMx>().Where(p => listerIds.Contains(p.Id)).ToList();
            var publishConfigIds = listers.Select(p => Convert.ToInt64(p.PublishConfigId)).ToList();
            var variationList = db.Queryable<WalmartListerMxVariation>().Where(v => listerIds.Contains(v.ListerId) && v.IsDeleted == false).ToList();
            var variationImagesList = db.Queryable<WalmartListerMxVariationImage>().Where(vs => listerIds.Contains(vs.ListerId) && vs.IsDeleted == false).ToList();
            var specificList = db.Queryable<WalmartListerMxSpecific>().Where(v => listerIds.Contains(v.ListerId) && v.IsDeleted == false).ToList();
            var publishConfigs = db.Queryable<WalmartPublishConfig>().Where(p => p.IsDeleted == false && publishConfigIds.Contains(p.Id)).ToList();
            var upcIds = listers.Select(s => s.UpcId).Distinct().ToList();
            var accountIds = listers.Select(p => p.AccountId).Distinct().ToList();
            var accounts = db.Queryable<PlatformAccount>().Where(v => accountIds.Contains(v.Id)).ToList();
            using (var fileStream = new FileStream(pathToExcelFile, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fileStream);
                ISheet sheet = workbook.GetSheet(worksheetName);
                //未备案需要设置ean（测试中不调用正式库EAN）
                foreach (var upcId in upcIds)
                {
                    //int eanCount = listers.Count + variationList.Count;
                    //if (listers.Count > 0 || variationList.Count > 0)
                    //{
                    //    lock (lockObject)
                    //    {
                    //        var upcDetails = db.Queryable<TCommonUpcManageDetail>().Where(u => u.NumberPoolId == upcId && u.IsUse == 0).Take(eanCount).ToList();
                    //        if (eanCount != upcDetails.Count)
                    //            break;
                    //        foreach (var variation in variationList)
                    //        {
                    //            if (string.IsNullOrEmpty(variation.ProductId))
                    //            {
                    //                var upcDetail = upcDetails.Where(d => d.IsUse == 0).FirstOrDefault();
                    //                upcDetail.IsUse = 1;
                    //                upcDetail.UseTime = DateTime.Now;
                    //                variation.ProductId = upcDetail.Number;
                    //            }
                    //        }
                    //        foreach (var lister in listers)
                    //        {
                    //            if (string.IsNullOrEmpty(lister.ProductId))
                    //            {
                    //                var upcDetail = upcDetails.Where(d => d.IsUse == 0).FirstOrDefault();
                    //                upcDetail.IsUse = 1;
                    //                upcDetail.UseTime = DateTime.Now;
                    //                lister.ProductId = upcDetail.Number;
                    //            }
                    //        }
                    //        if (listers.Count > 0)
                    //            db.Updateable(listers).UpdateColumns(l => l.ProductId).ExecuteCommandAsync();
                    //        if (variationList.Count > 0)
                    //            db.Updateable(variationList).UpdateColumns(l => l.ProductId).ExecuteCommandAsync();
                    //            db.Updateable(upcDetails).UpdateColumns(d => new { d.IsUse, d.UseTime }).ExecuteCommandAsync();
                    //    }
                    //}
                }
                //表头
                int rowIndexNum = 9;
                IRow row3 = sheet.GetRow(2);
                IRow row = sheet.GetRow(4);
                //IRow row2 = sheet.GetRow(4);

                //对其方式
                ICellStyle cellStyle = workbook.CreateCellStyle();
                cellStyle.Alignment = HorizontalAlignment.Left; //左对齐           
                Action<string, object> setCellValue = (name, value) =>
                {
                    if (name == "SKU")
                    {
                        IRow rows = sheet.GetRow(rowIndexNum);
                        ICell cellSKU = rows.CreateCell(3);
                        cellSKU.SetCellValue(value?.ToString());
                        cellSKU.CellStyle = cellStyle;
                    }
                    if (name.Contains("keyFeatures") || name.Contains("mainImageUrl"))
                    {
                        var names = name.Split(',').ToList();
                        var num = Convert.ToInt32(names[1]);
                        var cellIndex = row.Cells.FindIndex(c => c.StringCellValue == names[0].ToString());
                        if (cellIndex != -1)
                        {
                            IRow rows = sheet.GetRow(rowIndexNum);
                            var cell = rows.GetCell(cellIndex + 3 + num);
                            if (cell == null)
                            {
                                cell = rows.CreateCell(cellIndex + 3 + num);
                            }
                            cell.SetCellValue(value?.ToString());
                            cell.CellStyle = cellStyle;
                        }
                    }
                    else 
                    {
                        var cellIndex = row.Cells.FindIndex(c => c.StringCellValue == name);
                        if (cellIndex != -1)
                        {
                            IRow rows = sheet.GetRow(rowIndexNum);
                            ICell cell = null;
                            cell = rows.GetCell(cellIndex + 3);
                            if (cell == null)
                            {
                                cell = rows.CreateCell(cellIndex + 3);
                            }
                            cell.SetCellValue(value?.ToString());
                            cell.CellStyle = cellStyle;
                        }
                    }                    
                };
                //设置图片
                var imgMapping = new Dictionary<string, string>();
                Action<string> setImages = (images) =>
                {
                    if (!string.IsNullOrWhiteSpace(images))
                    {
                        var imgArr = images.Split('|');
                        for (int i = 0; i < 9; i++)
                        {
                            string imgVal = null;
                            if (i <= imgArr.Length - 1)
                            {
                                imgVal = imgArr[i];
                            }
                            if (!string.IsNullOrEmpty(imgVal)) 
                            {
                                setCellValue("mainImageUrl", imgVal);
                            }
                        }
                    }
                };
                //创建导出数据
                foreach (var lister in listers)
                {
                    //创建行
                    sheet.CreateRow(rowIndexNum);
                    var publishConfig = publishConfigs.Where(p => p.Id == lister.PublishConfigId).FirstOrDefault();
                    if (publishConfig == null)
                        throw new Exception("获取店铺上架配置信息异常");
                    var account = AccountApiHelper.GetPlatformAccount(lister.AccountId);
                    if (account == null)
                        throw new Exception("获取店铺信息异常");
                    List<string> colorMapFiled = new List<string>();
                    List<string> sizeMapFiled = new List<string>();
                    setCellValue("SKU", lister.SkuCode);                    
                    var variations = variationList.Where(p => p.ListerId == lister.Id && p.IsDeleted == false).ToList();
                    var specifics = specificList.Where(p => p.ListerId == lister.Id && p.IsDeleted == false).ToList();
                    if (variations!=null&& variations.Count>0)
                    {
                        variations.ForEach(p =>
                        {
                            rowIndexNum++;
                            sheet.CopyRow(rowIndexNum - 1, rowIndexNum);
                            if (!string.IsNullOrEmpty(lister.KeyFeatures))
                            {
                                var bulletPointList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(lister.KeyFeatures);
                                for (int i = 0; i < bulletPointList.Count; i++)
                                {
                                    if (i > 4) break;
                                    setCellValue($"keyFeatures,{i}", bulletPointList[i]); // BulletPoint
                                }
                            }
                            setCellValue("shortDescription", lister.ShortDescription);
                            setCellValue("ProductTaxCode", lister.ProductTaxCode);
                            setCellValue("brand", lister.Brand);
                            setCellValue("productIdType", lister.ProductIdType);
                            setCellValue("productId", p.ProductId ?? "6110001087901");
                            setCellValue("SKU", p.SkuCode);
                            setCellValue("isPrimaryVariant", p.IsPrimaryVariant);

                            //specific
                            var specificNames = p.SpecificName.Split('|');
                            var specificValues = p.SpecificValue.Split('|');
                            WalmartListerMxVariationImage listerVariationImage = null;
                            var variationImages = variationImagesList.Where(i => i.ListerId == lister.Id).ToList();
                            //循环属性值
                            for (int i = 0; i < specificNames.Length; i++)
                            {
                                var attrName = specificNames[i].Trim();
                                var attrValue = specificValues[i].Trim();
                                if (attrName.ToLower().Contains("color"))
                                {
                                    setCellValue("color", attrValue);
                                }
                                else if (attrName.ToLower().Contains("size")) 
                                {                                    
                                    setCellValue("clothingStyle", attrValue);
                                }
                                setCellValue(attrName, attrValue); 
                                if (variationImages.Count > 0 && listerVariationImage == null)
                                {
                                    listerVariationImage = variationImages.Where(t => t.SpecificValue.Trim() == attrValue).FirstOrDefault();
                                }
                            }
                            setCellValue("isPrimaryVariant", p.IsPrimaryVariant);
                            setCellValue("swatchVariantAttribute", p.SwatchVariantAttribute);
                            setCellValue("swatchImageUrl", p.SwatchImageUrl);
                            setCellValue("productName", $"{lister.Title} {string.Join(" ", specificValues)}");
                            //image
                            if (listerVariationImage != null)
                            {
                                var imageVList = ReplaceImage(account.PicCodingUrl, listerVariationImage.Images.Split('|'));
                                //setImages(string.Join("|", imageVList));
                                var count = row.Cells.Where(z => z.StringCellValue == "mainImageUrl").ToList().Count;
                                var images = imageVList.ToArray().SplitArray(count);
                                int a = 0;
                                foreach (var item in images)
                                {
                                    if (a<=count)
                                    {
                                        string image = string.Join("|", item);
                                        setCellValue($"mainImageUrl,{a}", image);
                                        a++;
                                    }
                                }
                            }
                            List<string> strs = new List<string>() { "ShippingDimensionsWidth", "ShippingDimensionsHeight", "ShippingDimensionsDepth" };
                            int countNum =  row.Cells.Where(z => z.StringCellValue == "measure").ToList().Count;
                            // specific
                            specificList.ForEach(spec =>
                            {
                                if (strs.Contains(spec.FeedName)) 
                                {
                                    var json  = JsonConvert.DeserializeObject<List<SpecificJsonDto>>(spec.SpecificValue);
                                    if (json!=null && json.Count>0) 
                                    {
                                        foreach (var item in json)
                                        {
                                            var cellIndex = row3.Cells.FindIndex(c => c.StringCellValue.Contains(spec.FeedName));
                                            if (cellIndex != -1)
                                            {
                                                IRow rows = sheet.GetRow(rowIndexNum);
                                                ICell cell = null;
                                                if (item.FeedSpecificName == "measure")
                                                {
                                                    cell = rows.GetCell(cellIndex + 3);
                                                    if (cell == null)
                                                    {
                                                        cell = rows.CreateCell(cellIndex + 3);
                                                    }
                                                    cell.SetCellValue(item.Name?.ToString());
                                                    cell.CellStyle = cellStyle;
                                                }
                                                if (item.FeedSpecificValue == "unit") 
                                                {
                                                    cell = rows.CreateCell(cellIndex + 4);
                                                    cell.SetCellValue(item.Value?.ToString());
                                                    cell.CellStyle = cellStyle;
                                                }
                                            }
                                        }
                                    }
                                    setCellValue(spec.FeedName, spec.SpecificValue);
                                }
                                if (!string.IsNullOrEmpty(spec.SpecificValue))
                                {
                                    setCellValue(spec.FeedName, spec.SpecificValue);
                                }
                            });
                        });
                    }
                    rowIndexNum++;
                }

                // 3. 保存修改后的数据
                using (var memoryStream = new MemoryStream())
                {
                    workbook.Write(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // 4. 导出 Excel 文件
                    using (var fileStreamExport = new FileStream(pathExport, FileMode.Create))
                    {
                        memoryStream.CopyTo(fileStreamExport);
                    }
                }
                Console.WriteLine("Excel 文件已导出。");

                // 读取表头
                //IRow headerRow = sheet.GetRow(headerRowIndex - 1); // Excel 行索引从 0 开始，所以减去 1
                //for (int colIndex = headerRowIndex - 1; colIndex < headerRow.LastCellNum; colIndex++)
                //{
                //    ICell cell = headerRow.GetCell(colIndex);
                //    if (cell != null)
                //    {
                //        Console.WriteLine($"表头列名：{cell.StringCellValue}");
                //    }
                //}
                //// 读取数据
                //for (int rowIndex = dataStartRowIndex - 1; rowIndex < sheet.LastRowNum; rowIndex++)
                //{
                //    IRow dataRow = sheet.GetRow(rowIndex);
                //    if (dataRow == null) continue;

                //    for (int colIndex = startColumnIndex - 1; colIndex < dataRow.LastCellNum; colIndex++)
                //    {
                //        ICell cell = dataRow.GetCell(colIndex);
                //        if (cell != null)
                //        {
                //            Console.WriteLine($"数据：{cell.StringCellValue}");
                //        }
                //    }
                //}

            }
        }

        /// <summary>
        /// 图片链接地址替换
        /// </summary>
        /// <param name="picCodingUrl"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        public static List<string> ReplaceImage(string picCodingUrl, string[] images)
        {
            List<string> imageList = new List<string>();
            foreach (var img in images)
            {
                imageList.Add($"{picCodingUrl}/product-image/{Path.GetFileName(img.Split('?')[0])}");
            }
            return imageList;
        }

        /// <summary>
        /// 尺码
        /// </summary>
        public void SwitchSize() 
        {
            
        }

        /// <summary>
        /// execl导出墨西哥站点表格数据
        /// </summary>
        public static void ExeclImportMxLister()
        {
            test();
            var pathImport = Path.Combine(@"D:\公司资料", $"{Guid.NewGuid()}MX.xlsx"); //导出地址于表格名称
            var pathToExcelFile = @"D:\公司资料\服装测试刊登(1).xlsx";
            var worksheetName = "Ropa"; // 你的工作表名称
            var startColumnIndex = 4; // 指定起始列的索引，这里表示第 4 列（D列）
            var headerRowIndex = 5; // 指定表头所在行
            var dataStartRowIndex = 10; // 指定数据起始行

            using (var stream = new FileStream(pathToExcelFile, FileMode.Open))
            {
                var dataList = new List<Dictionary<string, object>>();
                var query = stream.Query(sheetName: worksheetName, startCell: "D5");
                var data = new Dictionary<string, object>();
                var  datas = query
                    .Where((row, index) => index >= headerRowIndex - 1) // 跳过前 headerRowIndex - 1 行
                    //.Skip(dataStartRowIndex - 1)
                    .ToArray();

                // 提取表头
                var headerRow = datas.ElementAt(headerRowIndex);

                // 查询数据
                foreach (var row in datas)
                {
                    foreach (var item in row)
                    {
                        Console.WriteLine(item.Key);
                    }
                    var rowData = row.ToDictionary(headerRow);
                    
                    // 在这里你可以处理 rowData，它是一个包含列名和对应值的字典
                    Console.WriteLine($"列1: {rowData["列1"]}, 列2: {rowData["列2"]}, 列3: {rowData["列3"]}");
                }
            }
        }

        #endregion

        #region 根据正则表达式替换
        /// <summary>
        /// 根据正则表达式替换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Replace(string str)
        {
            string LinkA = "<span style='font-size：18px;'>Description:</span>";
            Match mt = Regex.Match(LinkA, "style=\"(.*?)\"");
            Console.WriteLine(mt.Value);
            return LinkA.Replace(mt.Value, "");
        }
        #endregion

        #region 点列阵
        /// <summary>
        /// 按照二进制来判断点阵列是否为true或false
        /// 二进制通常为0和1组成 在点阵列里1为true0为false
        /// </summary>
        public static void DotArray()
        {
            // 创建两个大小为 8 的点阵列
            System.Collections.BitArray ba1 = new System.Collections.BitArray(8);
            System.Collections.BitArray ba2 = new System.Collections.BitArray(8);
            byte[] a = { 60 };
            byte[] b = { 13 };

            // 把值 60 和 13 存储到点阵列中
            ba1 = new System.Collections.BitArray(a);
            ba2 = new System.Collections.BitArray(b);

            // ba1 的内容
            Console.WriteLine("Bit array ba1: 60");
            for (int i = 0; i < ba1.Count; i++)
            {
                Console.Write("{0, -6} ", ba1[i]);
            }
            Console.WriteLine();

            // ba2 的内容
            Console.WriteLine("Bit array ba2: 13");
            for (int i = 0; i < ba2.Count; i++)
            {
                Console.Write("{0, -6} ", ba2[i]);
            }
            Console.WriteLine();


            System.Collections.BitArray ba3 = new System.Collections.BitArray(8);
            ba3 = ba1.And(ba2);

            // ba3 的内容
            Console.WriteLine("Bit array ba3 after AND operation: 12");
            for (int i = 0; i < ba3.Count; i++)
            {
                Console.Write("{0, -6} ", ba3[i]);
            }
            Console.WriteLine();

            ba3 = ba1.Or(ba2);
            // ba3 的内容
            Console.WriteLine("Bit array ba3 after OR operation: 61");
            for (int i = 0; i < ba3.Count; i++)
            {
                Console.Write("{0, -6} ", ba3[i]);
            }
            Console.WriteLine();
        }
        #endregion

        #region 取平均值
        public static void Average()
        {
            int[] score = new int[] { 75, 65, 85, 85, 95, 65, 46, 46, 12, 46, 50, 55, 66, 66, 99, 87, 89, 91, 95 };
            int sumscore = 0;
            foreach (var item in score)
            {
                sumscore += item;
            }
            int sumad = sumscore / score.Length;
            Console.WriteLine("平均成绩是{0}", sumad);
        }
        #endregion

        #region string.Jion组合集合
        /// <summary>
        /// string.Jion组合集合
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringJion(List<string> strs)
        {
            return string.Join("|", strs);
        }
        #endregion
            
        #region 按照string类型拆分
        /// <summary>
        /// 按照string类型拆分
        /// </summary>
        /// <returns></returns>
        public List<string> Split()
        {
            //拆分
            string a = "1232514%45";
            var b = a.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return b;
        }
        #endregion

        #region json转换为Obj数组
        public static void JsonTransitionObj() 
        {
            List<PriceJSON> priceJSONs = new List<PriceJSON>();
            priceJSONs.Add(new PriceJSON()
            {
                Id = 007,
                Name = "阿元",
                Age = "19"
            });
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(priceJSONs);
            var jsonTostring = JsonConvert.DeserializeObject<Object[]>(json);
        }
        #endregion

        #region bese64转图片
        public static void BeseCharTransitionImg() 
        {
            Console.WriteLine("请输入一个字符串");
            string imageBase = Console.ReadLine();
            byte[] imageBytes = Convert.FromBase64String(imageBase.GetBytes("GBK").ToBase64String());
            //读入MemoryStream对象
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            //  转成图片
            Image image = Image.FromStream(memoryStream);
            Console.WriteLine(image);
        }

        #region base64转图片

        /// <summary>
        /// 图片上传 Base64解码
        /// </summary>
        /// <param name="dataURL">Base64数据</param>
        /// <param name="imgName">图片名字</param>
        /// <returns>返回一个相对路径</returns>
        public string decodeBase64ToImage(string dataURL, string imgName)
        {
            string filename = "";//声明一个string类型的相对路径
            String base64 = dataURL.Substring(dataURL.IndexOf(",") + 1);      //将‘，’以前的多余字符串删除
            System.Drawing.Bitmap bitmap = null;//定义一个Bitmap对象，接收转换完成的图片
            try//会有异常抛出，try，catch一下
            {
                byte[] arr = Convert.FromBase64String(base64);//将纯净资源Base64转换成等效的8位无符号整形数组
                System.IO.MemoryStream ms = new System.IO.MemoryStream(arr);//转换成无法调整大小的MemoryStream对象
                bitmap = new System.Drawing.Bitmap(ms);//将MemoryStream对象转换成Bitmap对象
                filename = "Knowledge_" + imgName + ".jpg";//所要保存的相对路径及名字
                string url = HttpRuntime.AppDomainAppPath.ToString();
                string tmpRootDir = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()); //获取程序根目录 
                string imagesurl2 = tmpRootDir + filename; //转换成绝对路径 
                bitmap.Save(imagesurl2, System.Drawing.Imaging.ImageFormat.Jpeg);//保存到服务器路径

                //bitmap.Save(filePath + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                //bitmap.Save(filePath + ".gif", System.Drawing.Imaging.ImageFormat.Gif);

                //bitmap.Save(filePath + ".png", System.Drawing.Imaging.ImageFormat.Png);

                ms.Close();//关闭当前流，并释放所有与之关联的资源                
                bitmap.Dispose();
            }
            catch (Exception e)
            {
                string massage = e.Message;
            }
            return filename;//返回相对路径
        }
        #endregion

        #region 图片转base64
        /// <summary>
        /// 图片转base64
        /// </summary>
        /// <param name="path">图片路径</param><br>        
        /// <returns>返回一个base64字符串</returns>
        public string decodeImageToBase64(string path)
        {
            path = "E:/vs 2015/newaqtcprj/WEB/UpFile/2018/12/20181229174708_7471722c425a2ec08fa513ddf4f8c76306d55fbb0fbd9d8.jpg";
            string base64str = "";
            //站点文件目录
            string fileDir = HttpContext.Current.Server.MapPath("/");
            string[] arrfileDir = fileDir.Split('\\');
            fileDir = arrfileDir[0] + "\\" + arrfileDir[1] + "\\" + arrfileDir[2];
            try
            {
                //读图片转为Base64String
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(Path.Combine(fileDir, "WEB\\UpFile\\2018\\12\\20181229174708_7471722c425a2ec08fa513ddf4f8c76306d55fbb0fbd9d8.jpg"));
                //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(path);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                bmp.Dispose();
                base64str = Convert.ToBase64String(arr);
            }
            catch (Exception e)
            {
                string mss = e.Message;
            }
            return "data:image/jpg;base64," + base64str;
        }
        #endregion

        #endregion

        #region 兼容调用，一个方法同类型，多条和单条数据的兼容
        /// <summary>
        /// 数字运算
        /// </summary>
        /// <param name="sums"></param>
        public static long Calculation(List<long> sums) 
        {
            long sum = 0;
            foreach (var item in sums)
            {
                sum += item;
            }
            return sum;
        }
        /// <summary>
        /// 调用数字运算的方法
        /// </summary>
        public static void GetCalculation() 
        {
            List<long> numbers = new List<long>();
            long sum = Calculation(numbers);//这是正常的传值直接把集合丢进去

            long sumTwo = Calculation(new List<long>(new long[] { 38}));// 假设你接受的值是一个数字那么你要兼容那边的调用类型，你可以这么去接收
        }
        #endregion
    }

    public class Info
    {
        /// <summary>
        /// 宽
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 类型（nan/nv）
        /// </summary>
        public string type { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 成功
        /// </summary>
        public string success { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string imgurl { get; set; }
        /// <summary>
        /// 图片信息
        /// </summary>
        public Info info { get; set; }
    }

}