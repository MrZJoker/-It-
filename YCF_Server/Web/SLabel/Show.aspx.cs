﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace YCF_Server.Web.SLabel
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int LID=(Convert.ToInt32(strid));
					ShowInfo(LID);
				}
			}
		}
		
	private void ShowInfo(int LID)
	{
		YCF_Server.BLL.SLabel bll=new YCF_Server.BLL.SLabel();
		YCF_Server.Model.SLabel model=bll.GetModel(LID);
		this.lblLID.Text=model.LID.ToString();
		this.lblLabel.Text=model.Label;

	}


    }
}
