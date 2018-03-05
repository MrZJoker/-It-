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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace YCF_Server.Web.ScheduleCount
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="班次名不能为空！\\n";	
			}
			if(this.txtStartTime.Text.Trim().Length==0)
			{
				strErr+="班次开始时间不能为空！\\n";	
			}
			if(this.txtEndTime.Text.Trim().Length==0)
			{
				strErr+="班次结束时间不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
			string StartTime=this.txtStartTime.Text;
			string EndTime=this.txtEndTime.Text;

			YCF_Server.Model.ScheduleCount model=new YCF_Server.Model.ScheduleCount();
			model.Name=Name;
			model.StartTime=StartTime;
			model.EndTime=EndTime;

			YCF_Server.BLL.ScheduleCount bll=new YCF_Server.BLL.ScheduleCount();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}