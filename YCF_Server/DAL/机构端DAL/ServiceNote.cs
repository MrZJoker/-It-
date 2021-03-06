﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:ServiceNote
	/// </summary>
	public partial class ServiceNote
	{
		public ServiceNote()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("NID", "ServiceNote"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ServiceNote");
			strSql.Append(" where NID=@NID");
			SqlParameter[] parameters = {
					new SqlParameter("@NID", SqlDbType.Int,4)
			};
			parameters[0].Value = NID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.ServiceNote model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ServiceNote(");
			strSql.Append("Note,Picture,NTime,EID,PID)");
			strSql.Append(" values (");
			strSql.Append("@Note,@Picture,@NTime,@EID,@PID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@Picture", SqlDbType.NVarChar,255),
					new SqlParameter("@NTime", SqlDbType.DateTime),
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4)};
			parameters[0].Value = model.Note;
			parameters[1].Value = model.Picture;
			parameters[2].Value = model.NTime;
			parameters[3].Value = model.EID;
			parameters[4].Value = model.PID;

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
		public bool Update(YCF_Server.Model.ServiceNote model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ServiceNote set ");
			strSql.Append("Note=@Note,");
			strSql.Append("Picture=@Picture,");
			strSql.Append("NTime=@NTime,");
			strSql.Append("EID=@EID,");
			strSql.Append("PID=@PID");
			strSql.Append(" where NID=@NID");
			SqlParameter[] parameters = {
					new SqlParameter("@Note", SqlDbType.NVarChar,500),
					new SqlParameter("@Picture", SqlDbType.NVarChar,255),
					new SqlParameter("@NTime", SqlDbType.DateTime),
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@NID", SqlDbType.Int,4)};
			parameters[0].Value = model.Note;
			parameters[1].Value = model.Picture;
			parameters[2].Value = model.NTime;
			parameters[3].Value = model.EID;
			parameters[4].Value = model.PID;
			parameters[5].Value = model.NID;

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
		public bool Delete(int NID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServiceNote ");
			strSql.Append(" where NID=@NID");
			SqlParameter[] parameters = {
					new SqlParameter("@NID", SqlDbType.Int,4)
			};
			parameters[0].Value = NID;

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
		public bool DeleteList(string NIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ServiceNote ");
			strSql.Append(" where NID in ("+NIDlist + ")  ");
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
		public YCF_Server.Model.ServiceNote GetModel(int NID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NID,Note,Picture,NTime,EID,PID from ServiceNote ");
			strSql.Append(" where NID=@NID");
			SqlParameter[] parameters = {
					new SqlParameter("@NID", SqlDbType.Int,4)
			};
			parameters[0].Value = NID;

			YCF_Server.Model.ServiceNote model=new YCF_Server.Model.ServiceNote();
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
		public YCF_Server.Model.ServiceNote DataRowToModel(DataRow row)
		{
			YCF_Server.Model.ServiceNote model=new YCF_Server.Model.ServiceNote();
			if (row != null)
			{
				if(row["NID"]!=null && row["NID"].ToString()!="")
				{
					model.NID=int.Parse(row["NID"].ToString());
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["Picture"]!=null)
				{
					model.Picture=row["Picture"].ToString();
				}
				if(row["NTime"]!=null && row["NTime"].ToString()!="")
				{
					model.NTime=DateTime.Parse(row["NTime"].ToString());
				}
				if(row["EID"]!=null && row["EID"].ToString()!="")
				{
					model.EID=int.Parse(row["EID"].ToString());
				}
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
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
			strSql.Append("select NID,Note,Picture,NTime,EID,PID ");
			strSql.Append(" FROM ServiceNote ");
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
			strSql.Append(" NID,Note,Picture,NTime,EID,PID ");
			strSql.Append(" FROM ServiceNote ");
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
			strSql.Append("select count(1) FROM ServiceNote ");
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
				strSql.Append("order by T.NID desc");
			}
			strSql.Append(")AS Row, T.*  from ServiceNote T ");
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
			parameters[0].Value = "ServiceNote";
			parameters[1].Value = "NID";
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

