using Gaiokane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertDataInBatches
{
    class ConfigSettings
    {
        public static string QuickInsert, QuickInsert_IDIncrement, QuickInsert_RandomNum, QuickInsert_NewID, QuickInsert_NewDateTime, QuickInsert_SameNewID, QuickInsert_RandomStr;
        public static string CommonlyUsedSQL, CommonlyUsedSQL_Default;
        public static string ConfigPath = "./InsertDataInBatches.exe";

        #region 获取配置文件中快捷插入配置
        /// <summary>
        /// 获取配置文件中快捷插入配置
        /// </summary>
        public static void getQuickInsertSettingsByappSettings()
        {
            QuickInsert = RWConfig.GetappSettingsValue("QuickInsert", ConfigPath);
            QuickInsert_IDIncrement = RWConfig.GetappSettingsValue("QuickInsert_IDIncrement", ConfigPath);
            QuickInsert_RandomNum = RWConfig.GetappSettingsValue("QuickInsert_RandomNum", ConfigPath);
            QuickInsert_NewID = RWConfig.GetappSettingsValue("QuickInsert_NewID", ConfigPath);
            QuickInsert_NewDateTime = RWConfig.GetappSettingsValue("QuickInsert_NewDateTime", ConfigPath);
            QuickInsert_SameNewID = RWConfig.GetappSettingsValue("QuickInsert_SameNewID", ConfigPath);
            QuickInsert_RandomStr = RWConfig.GetappSettingsValue("QuickInsert_RandomStr", ConfigPath);
        }
        #endregion

        #region 如果配置文件中无快捷插入配置，则新建配置，值默认
        /// <summary>
        /// 如果配置文件中无快捷插入配置，则新建配置，值默认
        /// </summary>
        public static void setDefaultQuickInsertSettingsIfIsNullOrEmptyByappSettings()
        {
            if (string.IsNullOrEmpty(QuickInsert))
            {
                RWConfig.SetappSettingsValue("QuickInsert", "QuickInsert_IDIncrement;QuickInsert_RandomNum;QuickInsert_NewID;QuickInsert_NewDateTime;QuickInsert_SameNewID", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_IDIncrement))
            {
                RWConfig.SetappSettingsValue("QuickInsert_IDIncrement", "指定id递增;{{id:x}};x替换为开始的序号，从x开始生成（包含x）", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomNum))
            {
                RWConfig.SetappSettingsValue("QuickInsert_RandomNum", "指定范围随机数;{{[1-2]}};-左边开始&#xA;-右边结束&#xA;不带小数点生成的随机数也不带", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_NewID))
            {
                RWConfig.SetappSettingsValue("QuickInsert_NewID", "生成newid/uuid;{{newid}};有匹配项就替换为新uuid", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_NewDateTime))
            {
                RWConfig.SetappSettingsValue("QuickInsert_NewDateTime", "指定时间递增;{{timed+x:yyyy-MM-dd HH:mm:ss}};+左边为时间类型（d|h|m|s 对应 日|时|分|秒）&#xA;+右边为递增/递减值", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_SameNewID))
            {
                RWConfig.SetappSettingsValue("QuickInsert_SameNewID", "生成相同newid/uuid;{{samenewid}};一次执行多条sql，使用相同uuid", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomStr))
            {
                RWConfig.SetappSettingsValue("QuickInsert_RandomStr", "在指定元素中随机选择一项;{{[x；y；z...]}};x、y、z为指定元素，\n能在元素中随机选择一项，\n请将；换成英文分号", ConfigPath);
            }

            //快捷插入中缺失默认配置会自动新增
            getQuickInsertSettingsByappSettings();
            string append = "";
            string[] arrayQuickInsert = QuickInsert.Split(';');
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_IDIncrement") == -1)
            {
                append += ";QuickInsert_IDIncrement";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_RandomNum") == -1)
            {
                append += ";QuickInsert_RandomNum";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_NewID") == -1)
            {
                append += ";QuickInsert_NewID";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_NewDateTime") == -1)
            {
                append += ";QuickInsert_NewDateTime";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_SameNewID") == -1)
            {
                append += ";QuickInsert_SameNewID";
            }
            if (Array.IndexOf(arrayQuickInsert, "QuickInsert_RandomStr") == -1)
            {
                append += ";QuickInsert_RandomStr";
            }
            RWConfig.SetappSettingsValue("QuickInsert", QuickInsert + append, ConfigPath);
        }
        #endregion

        #region 获取配置文件中快捷插入配置所有配置编码
        /// <summary>
        /// 获取配置文件中快捷插入配置所有配置编码
        /// </summary>
        public static string[] getQuickInsertSettingsAllCodes()
        {
            string[] result = { };
            QuickInsert = RWConfig.GetappSettingsValue("QuickInsert", ConfigPath);
            if (string.IsNullOrEmpty(QuickInsert))
            {
                setDefaultQuickInsertSettingsIfIsNullOrEmptyByappSettings();
                getQuickInsertSettingsByappSettings();
            }
            else
            {
                result = QuickInsert.Split(';');
            }
            return result;
        }
        #endregion

        #region 根据快捷插入模块编码获取快捷插入模块名称、值
        /// <summary>
        /// 根据快捷插入模块编码获取快捷插入模块名称、值
        /// </summary>
        public static string[] getQuickInsertModelNameValueByCode(string QuickInsertModelCode)
        {
            string[] result = { };
            string str = RWConfig.GetappSettingsValue(QuickInsertModelCode, ConfigPath);
            result = str.Split(';');
            return result;
        }
        #endregion

        #region 获取全部快捷插入模块编码、名称、值
        /// <summary>
        /// 获取全部快捷插入模块编码、名称、值
        /// </summary>
        public static string[,] getQuickInsertModelCodeNameValue()
        {
            string[] codes = getQuickInsertSettingsAllCodes();
            string[,] result = new string[codes.Length, 3];
            for (int i = 0; i < codes.Length; i++)
            {
                string[] nameValue = getQuickInsertModelNameValueByCode(codes[i]);
                result[i, 0] = codes[i];
                for (int j = 0; j < nameValue.Length; j++)
                {
                    result[i, j + 1] = nameValue[j];
                }
            }
            return result;
        }
        #endregion

        #region 根据快捷插入配置编码删除快捷插入配置
        /// <summary>
        /// 根据快捷插入配置编码删除快捷插入配置
        /// </summary>
        /// <param name="QuickInsertModelCode">快捷插入配置编码</param>
        /// <returns>string：删除成功/删除失败/没有匹配项/报错信息</returns>
        public static string delQuickInsertModelCodeNameValue(string QuickInsertModelCode)
        {
            try
            {
                string[] str = getQuickInsertSettingsAllCodes();
                foreach (var item in str)
                {
                    if (item == QuickInsertModelCode)
                    {
                        if (RWConfig.DelappSettingsValue(QuickInsertModelCode, ConfigPath) == true)
                        {
                            List<string> list = str.ToList();
                            list.Remove(item);
                            str = list.ToArray();
                            string result = String.Join(";", str);
                            RWConfig.SetappSettingsValue("QuickInsert", result, ConfigPath);
                            return QuickInsertModelCode + " 删除成功！";
                        }
                        else
                        {
                            return QuickInsertModelCode + " 删除失败！";
                        }
                    }
                }
                return "没有匹配项！";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 新增快捷插入配置
        /// <summary>
        /// 新增快捷插入配置
        /// </summary>
        /// <param name="Code">快捷插入配置编码</param>
        /// <param name="Name">快捷插入配置名称</param>
        /// <param name="Value">快捷插入配置值</param>
        /// <returns>string：新增成功/新增失败/新增项已存在，新增失败/报错信息</returns>
        public static string setQuickInsertModelCodeNameValue(string Code, string Name, string Value, string Instruction)
        {
            try
            {
                if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value) || string.IsNullOrEmpty(Instruction))
                {
                    return "快捷插入配置编码/名称/值/使用说明不能为空！";
                }
                else
                {
                    string[] str = getQuickInsertSettingsAllCodes();
                    foreach (var item in str)
                    {
                        if (item == Code)
                        {
                            return "在快捷插入配置编码中已存在相同编码，请确认！";
                        }
                    }

                    str = getCommonlyUsedSQLAllCodes();
                    foreach (var item in str)
                    {
                        if (item == Code)
                        {
                            return "在常用SQL配置编码中已存在相同编码，请确认！";
                        }
                    }

                    QuickInsert = RWConfig.GetappSettingsValue("QuickInsert", ConfigPath);
                    RWConfig.SetappSettingsValue(Code, Name + ";" + Value + ";" + Instruction, ConfigPath);
                    RWConfig.SetappSettingsValue("QuickInsert", QuickInsert + ";" + Code, ConfigPath);
                    return "新增成功";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 修改快捷插入配置
        /// <summary>
        /// 修改快捷插入配置
        /// </summary>
        /// <param name="Code">快捷插入配置编码</param>
        /// <param name="Name">快捷插入配置名称</param>
        /// <param name="Value">快捷插入配置值</param>
        /// <returns>string：修改成功/修改失败/报错信息</returns>
        public static string editQuickInsertModelCodeNameValue(string Code, string Name, string Value, string Instruction)
        {
            try
            {
                if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value) || string.IsNullOrEmpty(Instruction))
                {
                    return "快捷插入配置编码/名称/值/使用说明不能为空！";
                }
                else
                {

                    RWConfig.SetappSettingsValue(Code, Name + ";" + Value + ";" + Instruction, ConfigPath);
                    return "修改成功";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 获取配置文件中常用SQL配置
        /// <summary>
        /// 获取配置文件中常用SQL配置
        /// </summary>
        public static void getCommonlyUsedSQLByappSettings()
        {
            CommonlyUsedSQL = RWConfig.GetappSettingsValue("CommonlyUsedSQL", ConfigPath);
            CommonlyUsedSQL_Default = RWConfig.GetappSettingsValue("CommonlyUsedSQL_Default", ConfigPath);
        }
        #endregion

        #region 如果配置文件中无常用SQL配置，则新建配置，值默认
        /// <summary>
        /// 如果配置文件中无常用SQL配置，则新建配置，值默认
        /// </summary>
        public static void setDefaultCommonlyUsedSQLIfIsNullOrEmptyByappSettings()
        {
            if (string.IsNullOrEmpty(CommonlyUsedSQL))
            {
                RWConfig.SetappSettingsValue("CommonlyUsedSQL", "CommonlyUsedSQL_Default", ConfigPath);
            }
            if (string.IsNullOrEmpty(CommonlyUsedSQL_Default))
            {
                RWConfig.SetappSettingsValue("CommonlyUsedSQL_Default", "常用SQL名;select * from xxx", ConfigPath);
            }
        }
        #endregion

        #region 新增常用SQL配置
        /// <summary>
        /// 新增常用SQL配置
        /// </summary>
        /// <param name="Code">常用SQL编码</param>
        /// <param name="Name">常用SQL名称</param>
        /// <param name="Value">常用SQL语句</param>
        /// <returns>string：新增成功/新增失败/新增项已存在，新增失败/报错信息</returns>
        public static string setCommonlyUsedSQLCodeNameValue(string Code, string Name, string Value)
        {
            try
            {
                if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value))
                {
                    return "常用SQL编码/名称/语句不能为空！";
                }
                else
                {
                    string[] str = getQuickInsertSettingsAllCodes();
                    foreach (var item in str)
                    {
                        if (item == Code)
                        {
                            return "在快捷插入配置编码中已存在相同编码，请确认！";
                        }
                    }

                    str = getCommonlyUsedSQLAllCodes();
                    foreach (var item in str)
                    {
                        if (item == Code)
                        {
                            return "在常用SQL配置编码中已存在相同编码，请确认！";
                        }
                    }

                    CommonlyUsedSQL = RWConfig.GetappSettingsValue("CommonlyUsedSQL", ConfigPath);
                    RWConfig.SetappSettingsValue(Code, Name + ";" + Value, ConfigPath);
                    RWConfig.SetappSettingsValue("CommonlyUsedSQL", CommonlyUsedSQL + ";" + Code, ConfigPath);
                    return "新增成功";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 获取配置文件中常用SQL配置所有配置编码
        /// <summary>
        /// 获取配置文件中常用SQL配置所有配置编码
        /// </summary>
        public static string[] getCommonlyUsedSQLAllCodes()
        {
            string[] result = { };
            CommonlyUsedSQL = RWConfig.GetappSettingsValue("CommonlyUsedSQL", ConfigPath);
            if (string.IsNullOrEmpty(CommonlyUsedSQL))
            {
                setDefaultCommonlyUsedSQLIfIsNullOrEmptyByappSettings();
                getCommonlyUsedSQLByappSettings();
            }
            else
            {
                result = CommonlyUsedSQL.Split(';');
            }
            return result;
        }
        #endregion

        #region 修改常用SQL配置
        /// <summary>
        /// 修改常用SQL配置
        /// </summary>
        /// <param name="Code">常用SQL编码</param>
        /// <param name="Name">常用SQL名称</param>
        /// <param name="Value">常用SQL语句</param>
        /// <returns>string：修改成功/修改失败/报错信息</returns>
        public static string editCommonlyUsedSQLCodeNameValue(string Code, string Name, string Value)
        {
            try
            {
                if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value))
                {
                    return "常用SQL编码/名称/语句不能为空！";
                }
                else
                {

                    RWConfig.SetappSettingsValue(Code, Name + ";" + Value, ConfigPath);
                    return "修改成功";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 根据常用SQL编码获取常用SQL名称、语句
        /// <summary>
        /// 根据常用SQL编码获取常用SQL名称、语句
        /// </summary>
        public static string[] getCommonlyUsedSQLNameValueByCode(string CommonlyUsedSQLCode)
        {
            string[] result = { };
            string str = RWConfig.GetappSettingsValue(CommonlyUsedSQLCode, ConfigPath);
            result = str.Split(';');
            //数组转list，去除元素中结尾是空的元素
            List<string> list = result.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (string.IsNullOrEmpty(list[list.Count - 1]))
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
            result = list.ToArray();
            return result;
        }
        #endregion

        #region 根据常用SQL编码删除常用SQL
        /// <summary>
        /// 根据常用SQL编码删除常用SQL
        /// </summary>
        /// <param name="CommonlyUsedSQLCode">常用SQL编码</param>
        /// <returns>string：删除成功/删除失败/没有匹配项/报错信息</returns>
        public static string delCommonlyUsedSQLCodeNameValue(string CommonlyUsedSQLCode)
        {
            try
            {
                string[] str = getCommonlyUsedSQLAllCodes();
                foreach (var item in str)
                {
                    if (item == CommonlyUsedSQLCode)
                    {
                        if (RWConfig.DelappSettingsValue(CommonlyUsedSQLCode, ConfigPath) == true)
                        {
                            List<string> list = str.ToList();
                            list.Remove(item);
                            str = list.ToArray();
                            string result = String.Join(";", str);
                            RWConfig.SetappSettingsValue("CommonlyUsedSQL", result, ConfigPath);
                            return CommonlyUsedSQLCode + " 删除成功！";
                        }
                        else
                        {
                            return CommonlyUsedSQLCode + " 删除失败！";
                        }
                    }
                }
                return "没有匹配项！";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region （已注释，原本未分开记录MSSQL/MySQL配置）设置最后连接字符串
        /// <summary>
        /// 设置最后连接字符串
        /// </summary>
        /// <param name="sqlType">数据库类型 0=mssql 1=mysql</param>
        /// <param name="Host">数据库地址</param>
        /// <param name="isPort">是否需要端口</param>
        /// <param name="Port">端口号</param>
        /// <param name="Database">数据库名</param>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        /*public static bool setLastConnectionStrings(int sqlType, string Host, bool isPort, string Port, string Database, string Username, string Password)
        {
            string value = sqlType + ";" + Host + ";" + isPort + ";" + Port + ";" + Database + ";" + Username + ";" + Password;
            if (sqlType == 0 || sqlType == 1)//0=mssql，1=mysql
            {
                RWConfig.SetappSettingsValue("LastConnectionStrings", value, ConfigPath);
                return true;
            }
            else
            {
                return false;
            }
        }*/
        #endregion

        #region 设置最后连接字符串
        /// <summary>
        /// 设置最后连接字符串
        /// </summary>
        /// <param name="sqlType">数据库类型 0=mssql 1=mysql</param>
        /// <param name="Host">数据库地址</param>
        /// <param name="isPort">是否需要端口</param>
        /// <param name="Port">端口号</param>
        /// <param name="Database">数据库名</param>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>true/false</returns>
        public static bool setLastConnectionStrings(int sqlType, string Host, bool isPort, string Port, string Database, string Username, string Password)
        {
            string value = sqlType + ";" + Host + ";" + isPort + ";" + Port + ";" + Database + ";" + Username + ";" + Password;
            if (sqlType == 0 || sqlType == 1)//0=mssql，1=mysql
            {
                if (sqlType == 0)
                {
                    RWConfig.SetappSettingsValue("LastConnectionStringsForMSSQL", value, ConfigPath);
                    return true;
                }
                if (sqlType == 1)
                {
                    RWConfig.SetappSettingsValue("LastConnectionStringsForMySQL", value, ConfigPath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 设置最后连接数据库类型
        /// <summary>
        /// 设置最后连接数据库类型
        /// </summary>
        /// <param name="sqlType">数据库类型，MSSQL/MySQL</param>
        /// <returns>true/false</returns>
        public static bool setLastConnectionType(string sqlType)
        {
            if (sqlType == "MSSQL" || sqlType == "MySQL")
            {
                RWConfig.SetappSettingsValue("LastConnectionType", sqlType, ConfigPath);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 获取最后连接字符串
        /// <summary>
        /// 获取最后连接字符串
        /// </summary>
        /// <returns>数组 string[] sqlType, int sqlType, string Host, bool isPort, string Port, string Database, string Username, string Password</returns>
        public static string[] getLastConnectionStrings()
        {
            string temp = RWConfig.GetappSettingsValue("LastConnectionStrings", ConfigPath);
            string[] result = temp.Split(';');
            return result;
        }
        #endregion

        #region 获取最后连接数据库类型
        /// <summary>
        /// 获取最后连接数据库类型
        /// </summary>
        /// <returns>返回数据库类型，MSSQL/MySQL</returns>
        public static string getLastConnectionType()
        {
            string result = RWConfig.GetappSettingsValue("LastConnectionType", ConfigPath);
            return result;
        }
        #endregion

        #region 获取最后连接字符串MSSQL/MySQL
        /// <summary>
        /// 获取最后连接字符串MSSQL/MySQL
        /// </summary>
        /// <param name="sqlType">数据库类型，MSSQL/MySQL</param>
        /// <returns>数组 string[] sqlType, int sqlType, string Host, bool isPort, string Port, string Database, string Username, string Password</returns>
        public static string[] getLastConnectionStrings(string sqlType)
        {
            string temp = RWConfig.GetappSettingsValue("LastConnectionStringsFor" + sqlType, ConfigPath);
            string[] result = temp.Split(';');
            return result;
        }
        #endregion

        #region 根据配置文件中的Key获取对应Value
        /// <summary>
        /// 根据配置文件中的Key获取对应Value
        /// </summary>
        /// <param name="ConfigKey">配置文件中的Key</param>
        /// <returns>返回Key对应Value，数组</returns>
        public static string[] getConfigValueByKey(string ConfigKey)
        {
            string[] result = { };
            string str = RWConfig.GetappSettingsValue(ConfigKey, ConfigPath);
            result = str.Split(';');
            return result;
        }
        #endregion

        /// <summary>
        /// 保存成功连接的连接记录
        /// </summary>
        /// <param name="sqlType">数据库类型 0=mssql 1=mysql</param>
        /// <param name="Host">数据库地址</param>
        /// <param name="isPort">是否需要端口</param>
        /// <param name="Port">端口号</param>
        /// <param name="Database">数据库名</param>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>返回true/false</returns>
        public static bool saveConnectionString(int sqlType, string Host, bool isPort, string Port, string Database, string Username, string Password)
        {
            if (sqlType == 0)//MSSQL
            {
                return saveConnectionStringBySQLType("MSSQL", Host, isPort, Port, Database, Username, Password);
            }
            else//MySQL
            {
                return saveConnectionStringBySQLType("MySQL", Host, isPort, Port, Database, Username, Password);
            }
        }

        /// <summary>
        /// 根据数据库类型保存数据库连接记录
        /// </summary>
        /// <param name="sqlType">数据库类型 MSSQL MySQL</param>
        /// <param name="Host">数据库地址</param>
        /// <param name="isPort">是否需要端口</param>
        /// <param name="Port">端口号</param>
        /// <param name="Database">数据库名</param>
        /// <param name="Username">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>返回true/false</returns>
        public static bool saveConnectionStringBySQLType(string sqlType, string Host, bool isPort, string Port, string Database, string Username, string Password)
        {
            try
            {
                int n = getSameValueLenth(sqlType + "_Host", Host);//Host计数
                if (n == 0)//说明没有该记录
                {
                    string[] array = getConfigValueByKey(sqlType + "_Host");
                    List<string> List = array.ToList();
                    List.Add(Host);
                    array = List.ToArray();
                    string value;
                    if (array[0] == "")
                    {
                        value = array[array.Length - 1];
                    }
                    else
                    {
                        value = String.Join(";", array);
                    }
                    RWConfig.SetappSettingsValue(sqlType + "_Host", value, ConfigPath);
                }

                n = getSameValueLenth(sqlType + "_DB_" + Host, Database);//DB计数
                if (n == 0)//说明没有该记录
                {
                    string[] array = getConfigValueByKey(sqlType + "_DB_" + Host);
                    List<string> List = array.ToList();
                    List.Add(Database);
                    array = List.ToArray();
                    string value;
                    if (array[0] == "")
                    {
                        value = array[array.Length - 1];
                    }
                    else
                    {
                        value = String.Join(";", array);
                    }
                    RWConfig.SetappSettingsValue(sqlType + "_DB_" + Host, value, ConfigPath);
                }

                RWConfig.SetappSettingsValue(sqlType + "_Host_" + Host, isPort + ";" + Port + ";" + Username + ";" + Password, ConfigPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取指定Key下Value中匹配字符串数量
        /// </summary>
        /// <param name="ConfigKey">配置文件中的Key</param>
        /// <param name="Value">需要判断的Value</param>
        /// <returns>匹配数量</returns>
        public static int getSameValueLenth(string ConfigKey, string Value)
        {
            int n = 0;//计数
            string[] result = getConfigValueByKey(ConfigKey);
            foreach (var item in result)
            {
                if (Value == item)
                {
                    n += 1;
                }
            }
            return n;
        }
    }
}