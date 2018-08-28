using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.Common;
using System.Linq;
using System.Web.Script.Serialization;


namespace NFine.Code
{
    /// <summary>
    /// ConvertJson JSON转换类
    /// </summary>
    public static class ConvertJson
    {
        #region 私有方法
        #region 过滤特殊字符
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        private static string String2Json(string s)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
        #endregion
        #region 格式化字符型、日期型、布尔型
        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        private static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            return str;
        }
        #endregion
        #endregion

        #region 字符串转Jsion

        #endregion

        /// <summary>
        /// List转换成Json
        /// </summary>
        public static string ListToJson<T>(IList<T> list)
        {
            if (list.Count <= 0)
                return "";
            object obj = list[0];
            return ListToJson<T>(list, obj.GetType().Name);
        }

        /// <summary>
        /// List转换成Json 
        /// </summary>
        public static string ListToJson<T>(IList<T> list, string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName)) jsonName = list[0].GetType().Name;
            Json.Append("[");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    PropertyInfo[] pi = obj.GetType().GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pi.Length; j++)
                    {
                        if (pi[j].GetValue(list[i], null) != null)
                        {
                            Type type = pi[j].GetValue(list[i], null).GetType();
                            Json.Append("\"" + pi[j].Name.ToString() + "\":" + StringFormat(pi[j].GetValue(list[i], null).ToString(), type));

                            if (j < pi.Length - 1)
                            {
                                Json.Append(",");
                            }
                        }
                    }
                    Json.Append("}");
                    if (i < list.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]");
            return Json.ToString();
        }

        #region 对象转换为Json

        /// <summary>
        /// 对象转换为Json 
        /// </summary>
        /// <param name="jsonObject">自定义对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(object jsonObject)
        {
            var jsonString = "{";
            var propertyInfo = jsonObject.GetType().GetProperties();
            foreach (var t in propertyInfo)
            {
                var objectValue = t.GetGetMethod().Invoke(jsonObject, null);
                string value;
                if (objectValue is DateTime || objectValue is Guid || objectValue is TimeSpan || objectValue is string)
                {
                    value = "'" + objectValue.ToString() + "'";
                }
                else
                {
                    value = objectValue.ToString();
                }
                jsonString += "\"" + t.Name + "\":" + value + ",";
            }
            jsonString = jsonString.Remove(jsonString.LastIndexOf(",", StringComparison.Ordinal));
            return jsonString + "}";
        }

        #endregion

        #region  DataSet转换为Json
        /// <summary>
        /// DataSet转换为Json 
        /// </summary>
        /// <param name="dataSet">DataSet对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(DataSet dataSet)
        {
            var jsonString = dataSet.Tables.Cast<DataTable>().Aggregate("{", (current, table) => current + ("\"" + table.TableName + "\":" + ToJson(table) + ","));
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }
        #endregion

        #region Datatable转换为Json

        /// <summary> 
        /// Datatable转换为Json 
        /// </summary> 
        /// <param name="table">Datatable对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                StringBuilder jsonString = new StringBuilder();
                jsonString.Append("[");
                DataRowCollection drc = dt.Rows;
                for (int i = 0; i < drc.Count; i++)
                {
                    jsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string strKey = dt.Columns[j].ColumnName;
                        string strValue = drc[i][j].ToString();
                        Type type = dt.Columns[j].DataType;
                        jsonString.Append("\"" + strKey + "\":");
                        strValue = StringFormat(strValue, type);
                        if (j < dt.Columns.Count - 1)
                        {
                            jsonString.Append(strValue + ",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                    jsonString.Append("},");
                }
                jsonString.Remove(jsonString.Length - 1, 1);
                jsonString.Append("]");
                return jsonString.ToString();
            }
            else
                return "";
        }
        /// <summary>
        /// Datatable转换为Json
        /// </summary>
        /// <param name="dt">Datatable对象</param>
        /// <param name="jsonName"></param>
        /// <returns></returns>
        public static string ToJson(DataTable dt, string jsonName)
        {
            var json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName)) jsonName = dt.TableName;
            json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    json.Append("{");
                    for (var j = 0; j < dt.Columns.Count; j++)
                    {
                        var type = dt.Rows[j].GetType();
                        json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + StringFormat(dt.Rows[j].ToString(), type));
                        if (j < dt.Columns.Count - 1)
                        {
                            json.Append(",");
                        }
                    }
                    json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        json.Append(",");
                    }
                }
            }
            json.Append("]}");
            return json.ToString();
        }
        #endregion

        #region DataReader转换为Json
        /// <summary>
        /// DataReader转换为Json 
        /// </summary>
        /// <param name="dataReader">DataReader对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(DbDataReader dataReader)
        {
            var jsonString = new StringBuilder();
            jsonString.Append("[");
            while (dataReader.Read())
            {
                jsonString.Append("{");
                for (var i = 0; i < dataReader.FieldCount; i++)
                {
                    var type = dataReader.GetFieldType(i);
                    var strKey = dataReader.GetName(i);
                    var strValue = dataReader.ToString();
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (i < dataReader.FieldCount - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            dataReader.Close();
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
        #endregion

        #region 将制定的JSON字符串转换为T类型的对象
        /// <summary>
        /// 将制定的JSON字符串转换为T类型的对象
        /// </summary>
        /// <typeparam name="T">所生成对象的类型</typeparam>
        /// <param name="input">要进行反序列化的JSON字符串</param>
        /// <param name="def">反序列化失败时返回的默认值</param>
        /// <returns>反序列化的对象</returns>
        public static T JsonDeserialize<T>(string input, T def)
        {
            if (string.IsNullOrEmpty(input))
                return def;
            try
            {
                var jsSerializer = new JavaScriptSerializer();
                return jsSerializer.Deserialize<T>(input);
            }
            catch (InvalidOperationException)
            {
                return def;
                throw;
            }
        }
        #endregion

        #region
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
                    if (tempName == "num")
                        pro.SetValue(t, dt.Rows.Count, null);
                }
                //将对象添加到泛型集合
                ts.Add(t);
            }
            return ts;
        }
        #endregion
    }
}
