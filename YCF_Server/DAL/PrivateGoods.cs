﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:PrivateGoods
	/// </summary>
	public partial class PrivateGoods
	{
		public PrivateGoods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PID", "PrivateGoods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PrivateGoods");
			strSql.Append(" where PID=@PID");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
			parameters[0].Value = PID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.PrivateGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PrivateGoods(");
			strSql.Append("Name,Number,Count,ParID,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Number,@Count,@ParID,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@ParID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Number;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.ParID;
			parameters[4].Value = model.Remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YCF_Server.Model.PrivateGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PrivateGoods set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Number=@Number,");
			strSql.Append("Count=@Count,");
			strSql.Append("ParID=@ParID,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where PID=@PID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@ParID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@PID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Number;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.ParID;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.PID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PrivateGoods ");
			strSql.Append(" where PID=@PID");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
			parameters[0].Value = PID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string PIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PrivateGoods ");
			strSql.Append(" where PID in ("+PIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YCF_Server.Model.PrivateGoods GetModel(int PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PID,Name,Number,Count,ParID,Remark from PrivateGoods ");
			strSql.Append(" where PID=@PID");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
			parameters[0].Value = PID;

			YCF_Server.Model.PrivateGoods model=new YCF_Server.Model.PrivateGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YCF_Server.Model.PrivateGoods DataRowToModel(DataRow row)
		{
			YCF_Server.Model.PrivateGoods model=new YCF_Server.Model.PrivateGoods();
			if (row != null)
			{
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Number"]!=null)
				{
					model.Number=row["Number"].ToString();
				}
				if(row["Count"]!=null && row["Count"].ToString()!="")
				{
					model.Count=int.Parse(row["Count"].ToString());
				}
				if(row["ParID"]!=null && row["ParID"].ToString()!="")
				{
					model.ParID=int.Parse(row["ParID"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PID,Name,Number,Count,ParID,Remark ");
			strSql.Append(" FROM PrivateGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PID,Name,Number,Count,ParID,Remark ");
			strSql.Append(" FROM PrivateGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM PrivateGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.PID desc");
			}
			strSql.Append(")AS Row, T.*  from PrivateGoods T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "PrivateGoods";
			parameters[1].Value = "PID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

