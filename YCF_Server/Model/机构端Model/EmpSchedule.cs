﻿using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 员工与排班关联表
	/// </summary>
	[Serializable]
	public partial class EmpSchedule
	{
		public EmpSchedule()
		{}
		#region Model
		private int _esid;
		private int _eid;
		private int _sid;
		private DateTime _datatime;
		/// <summary>
		/// 
		/// </summary>
		public int ESID
		{
			set{ _esid=value;}
			get{return _esid;}
		}
		/// <summary>
		/// 员工表
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 排班表
		/// </summary>
		public int SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 排版时间
		/// </summary>
		public DateTime DataTime
		{
			set{ _datatime=value;}
			get{return _datatime;}
		}
		#endregion Model

	}
}

