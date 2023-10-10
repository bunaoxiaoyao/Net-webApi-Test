using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// 随机数帮助类
    /// </summary>
    public class RandomUtility
    {
        static List<FirstChar> _charList = new List<FirstChar>() 
        {
            new FirstChar(){FChar="A",Start=45217,End=45252},
            new FirstChar(){FChar="B",Start=45253,End=45760},
            new FirstChar(){FChar="C",Start=45761,End=46317},
            new FirstChar(){FChar="D",Start=46318,End=46825},
            new FirstChar(){FChar="E",Start=46826,End=47009},
            new FirstChar(){FChar="F",Start=47010,End=47296},
            new FirstChar(){FChar="G",Start=47297,End=47613},
            new FirstChar(){FChar="H",Start=47614,End=48118},
            new FirstChar(){FChar="J",Start=48119,End=49061},
            new FirstChar(){FChar="K",Start=49062,End=49323},
            new FirstChar(){FChar="L",Start=49324,End=49895},
            new FirstChar(){FChar="M",Start=49896,End=50370},
            new FirstChar(){FChar="N",Start=50371,End=50613},
            new FirstChar(){FChar="O",Start=50614,End=50621},
            new FirstChar(){FChar="P",Start=50622,End=50905},
            new FirstChar(){FChar="Q",Start=50906,End=51386},
            new FirstChar(){FChar="R",Start=51387,End=51445},
            new FirstChar(){FChar="S",Start=51446,End=52217},
            new FirstChar(){FChar="T",Start=52218,End=52697},
            new FirstChar(){FChar="W",Start=52698,End=52979},
            new FirstChar(){FChar="X",Start=52980,End=53640},
            new FirstChar(){FChar="Y",Start=53689,End=54480},
            new FirstChar(){FChar="Z",Start=54481,End=55289}
        };

        /// <summary>
        /// 随机生成N位数字符
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomCharacter(int length)
        {
            Random ra = new Random();
            char[] str = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string randomResult = String.Empty;
            for (int i = 0; i < length; i++)
            {
                randomResult += str[ra.Next(0, 34)];
            }
            return randomResult;
        }


        /// <summary>
        /// 随机生成N位数字符
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string RandomCharacter2(int length)
        {
            int number;
            string checkCode = String.Empty;     //存放随机码的字符串 
            Random random = new Random();

            for (int i = 0; i < length; i++) //产生4位校验码 
            {
                number = random.Next();
                number %= 36;
                if (number < 10)
                    number += 48;    //数字0-9编码在48-57 
                else
                    number += 55;    //字母A-Z编码在65-90 
                checkCode += ((char)number).ToString();
            }
            return checkCode;
        }

        /// <summary>
        /// 随机生成N位纯数字字符
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomNumber(int length)
        {
            char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder newRandom = new StringBuilder(10);
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                var value = Math.Abs(Guid.NewGuid().GetHashCode() % (10));
                newRandom.Append(constant[value]);
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// 获取中文首字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFirstCharCode(string str)
        {
            long iCnChar;
            byte[] ZW = System.Text.Encoding.GetEncoding("GB2312").GetBytes(str);
            string result = string.Empty;
            //如果是字母，则直接返回
            if (ZW.Length == 1)
            {
                result = str.ToUpper();
            }
            else
            {
                int i1 = ZW[0];
                int i2 = ZW[1];
                iCnChar = i1 * 256 + i2;
                var m = _charList.Where(x => x.Start <= iCnChar && x.End >= iCnChar).FirstOrDefault();
                if (m != null)
                    result = m.FChar;
            }
            return result;
        }

        /// <summary>
        /// 获取中文字符串首字母
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetChinesFirstCharCode(string str)
        {
            char[] nameChars = str.ToCharArray();
            List<string> list = new List<string>();
            foreach (var item in nameChars)
            {
                list.Add(GetFirstCharCode(item.ToString()));
            }
            return string.Join("", list);
        }

        /// <summary>
        /// 生成销售平台刊登SKU编码
        /// </summary>
        /// <param name="accountAlias">店铺简称</param>
        /// <param name="name">刊登员</param>
        /// <param name="length">随机数位数</param>
        /// <returns></returns>
        public static string GetPlatformSkuCode(string accountAlias,string name,int length)
        {
            return $"{accountAlias}{RandomNumber(length)}{GetChinesFirstCharCode(name)}";
        }

    }

    public class FirstChar
    {
        public string FChar { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
    }
}
