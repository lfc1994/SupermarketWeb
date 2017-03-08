using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//引入数据相关操作命令空间
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/***
 * 
 * 操作数据库的帮助类ADO.NET
 */
namespace ProductManage
{
    public class SQLHelper
    {
        public SQLHelper()
        { }
        private static string conString =
            ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
        /// <summary>
        /// 查询数据库返回SqlDataReader
        /// </summary>
        /// <param name="sql">sql语句或存储过程名</param>
        /// <param name="parms">SqlParameter[]参数</param>
        /// <param name="type">解释命行的执行方式</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] parms, CommandType type)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = type;
            if (parms != null)
            {
                command.Parameters.AddRange(parms);
            }
            con.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //返回SqlDataReader不能关闭连接,用完时记得关闭reader
            command.Parameters.Clear();
            return reader;
        }
        //重载(sql语句)
        public static SqlDataReader GetReader(string sql)
        {
            return GetReader(sql, null, CommandType.Text);
        }
        //重载(sql语句带参数)
        public static SqlDataReader GetReader(string sql, SqlParameter[] parms)
        {
            return GetReader(sql, parms, CommandType.Text);
        }
        //重载(存储过程，不带参数)
        public static SqlDataReader GetReader(string sql, CommandType type)
        {
            return GetReader(sql, null, type);
        }
        /// <summary>
        /// 查询数据库返回DataSet
        /// </summary>
        /// <param name="sql">sql语句或存储过程名</param>
        /// <param name="parms">SqlParameter[]参数</param>
        /// <param name="type">解释命行的执行方式</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string sql, SqlParameter[] parms, CommandType type)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand command = new SqlCommand(sql, con);
                    command.CommandType = type;
                    if (parms != null)
                    {
                        command.Parameters.AddRange(parms);
                    }
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
                    command.Parameters.Clear();
                    con.Close();//关闭连接                    
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            return ds;
        }
        //重载
        public static DataSet GetDataSet(string sql)
        {
            return GetDataSet(sql, null, CommandType.Text);
        }
        //重载
        public static DataSet GetDataSet(string sql, SqlParameter[] parms)
        {
            return GetDataSet(sql, parms, CommandType.Text);
        }
        //重载
        public static DataSet GetDataSet(string sql, CommandType type)
        {
            return GetDataSet(sql, null, type);
        }
        /// <summary>
        /// 增、删、改 执行1条SQL语句或存储过程
        /// </summary>
        /// <param name="sql">sql语句或存储过程名</param>
        /// <param name="parms">SqlParameter[]参数</param>
        /// <param name="type">解释命行的执行方式</param>
        /// <returns>受影响的行数</returns>
        public static int ExcuteSQL(string sql, SqlParameter[] parms, CommandType type)
        {
            int rows = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = type;
                    command.Connection = con;
                    if (parms != null)
                    {
                        command.Parameters.AddRange(parms);
                    }
                    command.CommandText = sql;
                    rows = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    con.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            return rows;
        }
        //重载
        public static int ExcuteSQL(string sql)
        {
            return ExcuteSQL(sql, null, CommandType.Text);
        }
        //重载
        public static int ExcuteSQL(string sql, SqlParameter[] parms)
        {
            return ExcuteSQL(sql, parms, CommandType.Text);
        }
        //重载
        public static int ExcuteSQL(string sql, CommandType type)
        {
            return ExcuteSQL(sql, null, type);
        }
        /// <summary>
        /// 查询返回首行首列的值(用于返回一个对象)
        /// </summary>
        /// <param name="sql">sql语句或存储过程名</param>
        /// <param name="parms">SqlParameter[]参数</param>
        /// <param name="type">解释命行的执行方式</param>
        /// <returns>首行首列的值object</returns>
        public static object GetFirstFieldValue(string sql, SqlParameter[] parms, CommandType type)
        {
            object obj = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand command = new SqlCommand(sql, con);
                    command.CommandType = type;
                    if (parms != null)
                    {
                        command.Parameters.AddRange(parms);
                    }
                    con.Open();
                    obj = command.ExecuteScalar();
                    command.Parameters.Clear();
                    con.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            return obj;
        }
        //重载
        public static object GetFirstFieldValue(string sql)
        {
            return GetFirstFieldValue(sql, null, CommandType.Text);
        }
        //重载
        public static object GetFirstFieldValue(string sql, SqlParameter[] parms)
        {
            return GetFirstFieldValue(sql, parms, CommandType.Text);
        }
        //重载
        public static object GetFirstFieldValue(string sql, CommandType type)
        {
            return GetFirstFieldValue(sql, null, type);
        }
    }
}
