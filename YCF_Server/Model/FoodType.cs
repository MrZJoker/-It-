﻿using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题表（BADL、IADL、LSP）单选和多选考题
	/// </summary>
	[Serializable]
	public partial class FoodType
	{
		public FoodType()
		{}
		#region Model
		private int _tid;
		private string _type;
		/// <summary>
		/// 
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

