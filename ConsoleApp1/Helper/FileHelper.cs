using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper
{
    public class FileHelper
    {
        /// <summary>
        /// 获取店铺对应文件夹路径
        /// </summary>
        /// <param name="shopName"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetFolderPath(string shopName, string date)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files\\" + $"{shopName}\\{date}";
            CreateFolder(path);
            return path;
        }

        public static string GetBuboxFolderPath(string shopName, string date)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files-Buybox\\" + $"{shopName}\\{date}";
            CreateFolder(path);
            return path;
        }

        /// <summary>
        /// 获取文件目录列表
        /// </summary>
        /// <param name="shopName"></param>
        /// <returns></returns>
        public static string[] GetFolderList(string shopName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Files\\" + $"{shopName}";
            var dirs = Directory.GetDirectories(path);
            return dirs;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns></returns>
        public static bool CreateFolder(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            //创建文件夹
            DirectoryInfo dirInfo = Directory.CreateDirectory(path);
            return true;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static void CreateFile(string path)
        {
            try
            {
                if (CreateFolder(path.Substring(0, path.LastIndexOf("\\"))))
                {
                    if (!File.Exists(path))
                    {
                        FileStream fs = File.Create(path);
                        fs.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">创建文件</param>
        public static void DeleteFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }
            else
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="path">删除文件</param>
        /// <param name="content">内容</param>
        public static void WriteFile(string path, string content)
        {
            if (!File.Exists(path))
            {
                CreateFile(path);
            }
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(content);
            sw.Close();
        }

        /// <summary>
        /// 将即时日志保存入日志文件
        /// </summary>
        public static void WriteLogFile(string directoryPath, string content)
        {
            if (!Directory.Exists(directoryPath))
            {
                CreateFolder(directoryPath);
            }

            //写入新的文件
            string filePath = directoryPath + "\\" + DateTime.Now.Date.ToString("yyyyMMdd") + ".log";
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(content);
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="GzipFile">压缩包文件名</param>
        /// <param name="targetPath">解压缩目标路径</param>       
        public static void Decompress(string GzipFile, string targetPath)
        {
            string directoryName = targetPath;
            if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);//生成解压目录
            string CurrentDirectory = directoryName;
            byte[] data = new byte[1];
            int size = 0;
            ZipEntry theEntry = null;
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(GzipFile)))
            {
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.IsDirectory)
                    {
                        // 该结点是目录
                        if (!Directory.Exists(CurrentDirectory + theEntry.Name))
                            Directory.CreateDirectory(CurrentDirectory + theEntry.Name);
                    }
                    else
                    {
                        if (theEntry.Name != String.Empty)
                        {
                            //检查多级目录是否存在  
                            if (theEntry.Name.Contains("//"))
                            {
                                string parentDirPath = theEntry.Name.Remove(theEntry.Name.LastIndexOf("//") + 1);
                                if (!Directory.Exists(parentDirPath))
                                {
                                    Directory.CreateDirectory(CurrentDirectory + parentDirPath);
                                }
                            }
                            //解压文件到指定的目录
                            using (FileStream streamWriter = File.Create(CurrentDirectory + theEntry.Name))
                            {
                                while (true)
                                {
                                    data = new byte[theEntry.CompressedSize];
                                    size = s.Read(data, 0, data.Length);
                                    if (size <= 0) break;
                                    streamWriter.Write(data, 0, size);
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }
                s.Close();
            }
        }
    }
}
