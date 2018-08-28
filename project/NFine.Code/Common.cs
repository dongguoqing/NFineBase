/*******************************************************************************
 * Copyright © 2016 .Framework 版权所有
 * Author: 
 * Description: 快速开发平台
 * Website：http://www..cn
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Linq;

namespace NFine.Code
{
    /// <summary>
    /// 常用公共类
    /// </summary>
    public class Common
    {
        #region Stopwatch计时器
        /// <summary>
        /// 计时器开始
        /// </summary>
        /// <returns></returns>
        public static Stopwatch TimerStart()
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            return watch;
        }
        /// <summary>
        /// 计时器结束
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public static string TimerEnd(Stopwatch watch)
        {
            watch.Stop();
            double costtime = watch.ElapsedMilliseconds;
            return costtime.ToString();
        }
        #endregion

        #region 删除数组中的重复项
        /// <summary>
        /// 删除数组中的重复项
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string[] RemoveDup(string[] values)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < values.Length; i++)//遍历数组成员
            {
                if (!list.Contains(values[i]))
                {
                    list.Add(values[i]);
                };
            }
            return list.ToArray();
        }
        #endregion

        #region 自动生成编号
        /// <summary>
        /// 表示全局唯一标识符 (GUID)。
        /// </summary>
        /// <returns></returns>
        public static string GuId()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 自动生成编号  201008251145409865
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); //生成编号 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;//形如
            return code;
        }
        #endregion

        #region 生成0-9随机数
        /// <summary>
        /// 生成0-9随机数
        /// </summary>
        /// <param name="codeNum">生成长度</param>
        /// <returns></returns>
        public static string RndNum(int codeNum)
        {
            StringBuilder sb = new StringBuilder(codeNum);
            Random rand = new Random();
            for (int i = 1; i < codeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
        #endregion

        #region 删除最后一个字符之后的字符
        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }
        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        /// <summary>
        /// 删除最后结尾的长度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string DelLastLength(string str, int Length)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            str = str.Substring(0, str.Length - Length);
            return str;
        }

        /// <summary>
        /// 将DataTable转换为实体类对象的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> TableToEntity<T>(DataTable dt) where T : class, new()
        {
            //定义集合
            List<T> ts = new List<T>();
            //获得此模型的类型
            Type type = typeof(T);
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行
            foreach (DataRow row in dt.Rows)
            {
                T t = new T();
                //获得此模型的公共属性
                PropertyInfo[] properties = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pro in properties)
                {
                    //将属性名称赋值给临时变量
                    tempName = pro.Name;
                    //检查DataTable 是否包含此列（列明==对象的属性名）
                    if (dt.Columns.Contains(tempName))
                    {
                        //判断此属性是否有Setter
                        if (!pro.CanWrite)
                            continue;//此属性不可写，直接跳出
                        //取值
                        object value = row[tempName];
                        //如果为非空则赋值给对象的属性
                        if (value != DBNull.Value)
                            pro.SetValue(t, value, null);
                    }
                }
                //将对象添加到泛型集合
                ts.Add(t);
            }
            return ts;
        }

        /// <summary>
        /// 获取所有子级元素  仅用于蓝色星球项目
        /// </summary>
        /// <param name="listAll"></param>
        /// <returns></returns>
        public static string GetAllChildren(List<QualityTypeModel> listAll)
        {
            StringBuilder sbResult = new StringBuilder();
            List<QualityTypeModel> list_children;//生命一个临时集合  用于存储循环中当前子级取出的子级的元素
            //获取当前一级目录下面的所有子级目录
            List<QualityTypeModel> list_second = listAll.Where(a => a.Level == "2").ToList();
            //循环二级子级目录  
            foreach (QualityTypeModel item in list_second)
            {
                //将二级子级目录的id以,连接拼接到结果中
                sbResult.Append(item.Mocode + ",");
                //初始化用于存储当前子级的子级元素
                list_children = new List<QualityTypeModel>();
                list_children.AddRange(listAll.Where(a => a.UpperName == item.Mocode.ToString()).ToList());//找出子级的子级元素
                do
                {
                    List<QualityTypeModel> current = new List<QualityTypeModel>();
                    for (int i = 0; i < list_children.Count; i++)
                    {
                        current.AddRange(listAll.Where(a => a.UpperName == list_children[i].Mocode.ToString()));//查出父级为当前mocode的几个
                        sbResult.Append(list_children[i].Mocode + ",");//将子级的mocode加到查询条件中
                    }
                    list_children = new List<QualityTypeModel>();
                    list_children.AddRange(current);
                } while (list_second.Count > 0);
            }
            return sbResult.ToString();
        }


        public class QualityTypeModel
        {
            public int Mocode { get; set; }
            public string Level { get; set; }
            public string UpperName { get; set; }
        }
        #endregion
    }
}
