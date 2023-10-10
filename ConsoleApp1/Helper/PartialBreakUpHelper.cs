using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper
{
    public static class PartialBreakUpHelper
    {
        #region 随机打乱集合顺序
        /// <summary>
        /// 随机打乱顺序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ListT"></param>
        /// <returns></returns>
        public static List<T> RandomSortList<T>(this List<T> ListT)
        {
            Random random = new Random();
            List<T> newList = new List<T>();
            foreach (T item in ListT)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            return newList;
        }
        #endregion

        #region 按照批次拆分集合，分批拆分
        public static List<T[]> SplitArray<T>(this T[] data, int size)
        {
            if (data == null)
            {
                return null;
            }
            List<T[]> list = new List<T[]>();
            for (int i = 0; i < data.Length / size; i++)
            {
                T[] r = new T[size];
                Array.Copy(data, i * size, r, 0, size);
                list.Add(r);
            }
            if (data.Length % size != 0)
            {
                T[] r = new T[data.Length % size];
                Array.Copy(data, data.Length - data.Length % size, r, 0, data.Length % size);
                list.Add(r);
            }
            return list;
        }
        #endregion
        public static List<long> String2LongList(string str)
        {
            List<string> strList = str.Split(',').ToList();
            List<long> longList = new List<long>();
            strList.ForEach(item => longList.Add(Convert.ToInt64(item)));
            return longList;
        }
        public static List<int> StringIntList(string str)
        {
            List<string> strList = str.Split(',').ToList();
            List<int> intList = new List<int>();
            strList.ForEach(item => intList.Add(Convert.ToInt32(item)));
            return intList;
        }
    }
}
