﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:GroupLader
	/// </summary>
	public partial class GroupLader
	{
		public GroupLader()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("GID", "GroupLader"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GroupLader");
			strSql.Append(" where GID=@GID");
			SqlParameter[] parameters = {
					new SqlParameter("@GID", SqlDbType.Int,4)
			};
			parameters[0].Value = GID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.GroupLader model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GroupLader(");
			strSql.Append("Name,UID,Remak)");
			strSql.Append(" values (");
			strSql.Append("@Name,@UID,@Remak)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,255),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Remak", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.UID;
			parameters[2].Value = model.Remak;

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
		public bool Update(YCF_Server.Model.GroupLader model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GroupLader set ");
			strSql.Append("Name=@Name,");
			strSql.Append("UID=@UID,");
			strSql.Append("Remak=@Remak");
			strSql.Append(" where GID=@GID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,255),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Remak", SqlDbType.NVarChar,255),
					new SqlParameter("@GID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.UID;
			parameters[2].Value = model.Remak;
			parameters[3].Value = model.GID;

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
		public bool Delete(int GID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupLader ");
			strSql.Append(" where GID=@GID");
			SqlParameter[] parameters = {
					new SqlParameter("@GID", SqlDbType.Int,4)
			};
			parameters[0].Value = GID;

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
		public bool DeleteList(string GIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupLader ");
			strSql.Append(" where GID in ("+GIDlist + ")  ");
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
		public YCF_Server.Model.GroupLader GetModel(int GID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 GID,Name,UID,Remak from GroupLader ");
			strSql.Append(" where GID=@GID");
			SqlParameter[] parameters = {
					new SqlParameter("@GID", SqlDbType.Int,4)
			};
			parameters[0].Value = GID;

			YCF_Server.Model.GroupLader model=new YCF_Server.Model.GroupLader();
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
		public YCF_Server.Model.GroupLader DataRowToModel(DataRow row)
		{
			YCF_Server.Model.GroupLader model=new YCF_Server.Model.GroupLader();
			if (row != null)
			{
				if(row["GID"]!=null && row["GID"].ToString()!="")
				{
					model.GID=int.Parse(row["GID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
				}
				if(row["Remak"]!=null)
				{
					model.Remak=row["Remak"].ToString();
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
			strSql.Append("select GID,Name,UID,Remak ");
			strSql.Append(" FROM GroupLader ");
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
			strSql.Append(" GID,Name,UID,Remak ");
			strSql.Append(" FROM GroupLader ");
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
			strSql.Append("select count(1) FROM GroupLader ");
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
				strSql.Append("order by T.GID desc");
			}
			strSql.Append(")AS Row, T.*  from GroupLader T ");
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
			parameters[0].Value = "GroupLader";
			parameters[1].Value = "GID";
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

