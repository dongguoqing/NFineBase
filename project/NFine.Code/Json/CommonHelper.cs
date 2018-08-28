using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Code.Json
{
   public   class CommonHelper
    {
        /// <summary>
        /// 将DataTable转换为实体类对象的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> TableToEntity<T>(DataTable dt) where T : class,new()
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
    }
}
