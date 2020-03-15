using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertDataInBatches
{
    public class SqlHelper
    {

        #region MySQL
        /// <summary>
        /// 传入SQL，返回查询结果记录条数
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="MySQLConn">MySqlConnection连接</param>
        /// <returns></returns>
        public int getRows(string Query, MySqlConnection MySQLConn)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand(Query, MySQLConn);
                MySqlDataAdapter mysqldataadapter = new MySqlDataAdapter();
                mysqldataadapter.SelectCommand = comm;
                DataSet ds = new DataSet();
                int n = mysqldataadapter.Fill(ds);
                return n;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySQLConn.Close();
            }
        }

        /// <summary>
        /// 传入SQL，返回该命令所影响行数，其他类型语句（建表）、回滚，返回值为-1
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="MySQLConn">MySqlConnection连接</param>
        /// <returns></returns>
        public int getAffectRows(string Query, MySqlConnection MySQLConn)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand(Query, MySQLConn);

                int result = comm.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySQLConn.Close();
            }
        }

        /// <summary>
        /// （支持事务）传入SQL，返回该命令所影响行数，其他类型语句（建表）、回滚，返回值为-1
        /// </summary>
        /// <param name="Querys">sql数组</param>
        /// <param name="MySQLConn">MySqlConnection连接</param>
        /// <returns></returns>
        public int getAffectRowsTransaction(string[] Querys, MySqlConnection MySQLConn)
        {
            int result = 0;
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = MySQLConn;
            comm.Transaction = MySQLConn.BeginTransaction();
            try
            {
                for (int i = 0; i < Querys.Length; i++)
                {
                    comm.CommandText = Querys[i];
                    result = comm.ExecuteNonQuery();
                }
                comm.Transaction.Commit();

                return result;
            }
            catch (Exception ex)
            {
                comm.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                //MySQLConn.Close();
            }
        }

        /// <summary>
        /// 传入SQL，返回查询结果中第一行第一列的值
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="MySQLConn">MySqlConnection连接</param>
        /// <returns></returns>
        public object getResult(string Query, MySqlConnection MySQLConn)
        {
            try
            {
                MySqlCommand sqlcommd = new MySqlCommand(Query, MySQLConn);
                object result = sqlcommd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySQLConn.Close();
            }
        }

        /// <summary>
        /// 传入SQL，返回DataSet
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="MySQLConn">MySqlConnection连接</param>
        /// <returns></returns>
        public DataSet getDataSet(string Query, MySqlConnection MySQLConn)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, MySQLConn);
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySQLConn.Close();
            }
        }
        #endregion
    }
}