﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using log4net;
using FT.Commons.Security;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 文件操作辅助类
    /// </summary>
    public class FileHelper : BaseHelper
    {
       

        [DllImport("shfolder.dll", CharSet = CharSet.Auto)] 
        internal static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);
        /// <summary>
        /// 获取所有用户的路径，类似C:\Documents and Settings\All Users
        /// </summary>
        /// <returns></returns>
        public static string GetAllUserPath()
        {
            StringBuilder lpszPath = new StringBuilder(260);
            SHGetFolderPath(IntPtr.Zero, (int)0x23, IntPtr.Zero, 0, lpszPath);
            string path = lpszPath.ToString();
            
            return path;
        }

        /// <summary>
        /// 清空所有摄像头捕获的照片
        /// </summary>
        public static void ClearCapturePhotoes()
        {
            DirectoryInfo inf = new DirectoryInfo(GetAllUserPath() + "\\Microsoft\\WIA");
            
            if (!inf.Exists)
                inf.Create();
            else
            {
                inf.Delete(true);
            }
        }

        public FileHelper()
        {
        }

        /// <summary>
        /// 删除隐藏的使用时间信息
        /// </summary>
        /// <param name="program">程序名</param>
        public static void ClearLastLog(string program)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + program + ".log";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 创建文件路径
        /// </summary>
        /// <param name="program">程序名</param>
        public static void CreateLastFile(string program)
        {
            string path=System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\"+program+".log";
            log.Debug("创建文件路径："+path);
            if (!File.Exists(path))
            {
                FileStream fs=File.Create(path);
                fs.Close();
            }
        }

        /// <summary>
        /// 读取系统返回的时间
        /// </summary>
        /// <param name="program">程序名</param>
        /// <returns>返回时间</returns>
        public static string ReadLastLog(string program)
        {
            string result = string.Empty;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + program + ".log";
            CreateLastFile(program);
            StreamReader reader=null;
            System.IO.FileStream fs = new FileStream(path, FileMode.Open);
            try
            {
                reader = new StreamReader(fs);

                result = SecurityFactory.GetSecurity().Decrypt(reader.ReadLine());
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {

                if (reader != null)
                    reader.Close();

                fs.Close();
            }
            return result;
        }

        /// <summary>
        /// 写最后登陆的日期到隐藏目录下
        /// </summary>
        /// <param name="program">程序名</param>
        public static void WriteLastLog(string program)
        {
            string path=System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\"+program+".log";
            CreateLastFile(program);
            StreamWriter streamWriter=null;
            try
            {
                streamWriter = new StreamWriter(path,false);
                streamWriter.WriteLine(SecurityFactory.GetSecurity().Encrypt(System.DateTime.Now.ToShortDateString()));
                streamWriter.Flush();
                
            }
            catch(Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

        #region 压缩解压

        public static bool ZipDir(string path, string zipfile)
        {
           return ZipDir(path, zipfile, string.Empty);
        }

        public static bool ZipDir(string path, string zipfile, string pwd)
        {
            FastZip fastZip = new FastZip();
            try
            {
                if (pwd.Length > 0)
                {
                    fastZip.Password = pwd;
                }
                fastZip.CreateZip(zipfile, path,true, null);
                return true;
            }
            catch (Exception ex)
            {

                log.Error("压缩失败！" + ex.ToString());
                return false;
            }
            /*bool result=false;
            if (!Directory.Exists(path))
            {
                log.Debug("压缩路径:"+path+"不存在，不进行压缩！");
                return false;
            }
            if (File.Exists(zipfile))
            {
                File.Delete(zipfile);
                //log.Debug("压缩路径:" + path + "不存在，不进行压缩！");
                //return;
            }
            try
            {
                Crc32 crc = new Crc32();
                ZipOutputStream s = new ZipOutputStream(File.Create(zipfile));
                if (pwd != string.Empty)
                {
                    s.Password = pwd;
                }
                s.SetLevel(6); // 0 - store only to 9 - means best compression
                DirectoryInfo dir = new DirectoryInfo(path);
                FileStream fs;
                foreach (FileInfo file in dir.GetFiles())
                {
                    //打开压缩文件
                    fs = File.OpenRead(file.FullName);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    ZipEntry entry = new ZipEntry(file.Name);

                    entry.DateTime = DateTime.Now;

                    // set Size and the crc, because the information
                    // about the size and crc should be stored in the header
                    // if it is not set it is automatically written in the footer.
                    // (in this case size == crc == -1 in the header)
                    // Some ZIP programs have problems with zip files that don't store
                    // the size and crc in the header.
                    entry.Size = fs.Length;
                    fs.Close();

                    crc.Reset();
                    crc.Update(buffer);

                    entry.Crc = crc.Value;

                    s.PutNextEntry(entry);

                    s.Write(buffer, 0, buffer.Length);

                }
                s.Finish();
                s.Close();
                result = true;
            }
            catch (Exception ex)
            {
                log.Error("压缩过程中发现未知错误！"+ex.ToString());

            }
            return result;*/
        }
        public static bool UnZipDir(string zipfile,string path)
        {
            return UnZipDir( zipfile,path, string.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipfile"></param>
        /// <param name="path">path必须带有/</param>
        /// <param name="pwd"></param>
        public static bool UnZipDir(string zipfile,string path, string pwd)
        {
            FastZip fastZip = new FastZip();
            try
            {
                if (pwd.Length > 0)
                {
                    fastZip.Password = pwd;
                }
                fastZip.ExtractZip(zipfile, path,null);
                return true;
            }
            catch (Exception ex)
            {

                log.Error("解压失败！"+ex.ToString());
                return false;
            }
            /*bool result = false;
            if (!File.Exists(zipfile) )
            {
                log.Debug("待解压文件:" + zipfile + "不存在，不进行解压！");
                return false;
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipfile));
            if (pwd != string.Empty)
            {
                s.Password = pwd;
            }
            try
            {
                ZipEntry theEntry;
                string dir = Path.GetDirectoryName(path);
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    
                    string fileName = Path.GetFileName(theEntry.Name);
                    if (fileName != String.Empty)
                    {
                        //解压文件到指定的目录
                        FileStream streamWriter = File.Create(dir + fileName);
                        
                        int size = 2048;
                        if (size > (int)theEntry.Size)
                        {
                            size = (int)theEntry.Size;
                        }
                        byte[] data = new byte[size];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }

                        streamWriter.Close();
                    }
                }
                s.Close();
                result = true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                
                throw ex;
            }
            finally
            {
                s.Close();
            }
            return result;*/
        }
        #endregion
    }
}