﻿using Gaiokane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertDataInBatches
{
    class ConfigSettings
    {
        public static string QuickInsert, QuickInsert_IDIncrement, QuickInsert_RandomNum, QuickInsert_NewID, QuickInsert_NewDateTime;
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
                RWConfig.SetappSettingsValue("QuickInsert", "QuickInsert_IDIncrement;QuickInsert_RandomNum;QuickInsert_NewID;QuickInsert_NewDateTime", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_IDIncrement))
            {
                RWConfig.SetappSettingsValue("QuickInsert_IDIncrement", "指定id递增;{{id:x}}", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_RandomNum))
            {
                RWConfig.SetappSettingsValue("QuickInsert_RandomNum", "指定范围随机数;{{[1-2]}}", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_NewID))
            {
                RWConfig.SetappSettingsValue("QuickInsert_NewID", "生成newid/uuid;{{newid}}", ConfigPath);
            }
            if (string.IsNullOrEmpty(QuickInsert_NewDateTime))
            {
                RWConfig.SetappSettingsValue("QuickInsert_NewDateTime", "指定时间递增;{{timed+x:yyyy-MM-dd HH:mm:ss}}", ConfigPath);
            }
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
        public static string setQuickInsertModelCodeNameValue(string Code, string Name, string Value)
        {
            try
            {
                if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value))
                {
                    return "快捷插入配置编码/名称/值不能为空！";
                }
                else
                {
                    string[] str = getQuickInsertSettingsAllCodes();
                    QuickInsert = RWConfig.GetappSettingsValue("QuickInsert", ConfigPath);

                    foreach (var item in str)
                    {
                        if (item == Code)
                        {
                            return "已存在相同快捷插入配置编码，请确认！";
                        }
                    }
                    RWConfig.SetappSettingsValue(Code, Name + ";" + Value, ConfigPath);
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
        public static string editQuickInsertModelCodeNameValue(string Code, string Name, string Value)
        {
            try
            {
                if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value))
                {
                    return "快捷插入配置编码/名称/值不能为空！";
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
    }
}