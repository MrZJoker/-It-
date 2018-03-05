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
namespace YCF_Server.Web.Drug
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtDrugName.Text.Trim().Length==0)
			{
				strErr+="药品名称不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDlevel.Text))
			{
				strErr+="药品级别格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtManufactureDate.Text))
			{
				strErr+="生产日期格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtValidTime.Text))
			{
				strErr+="有效日期格式错误！\\n";	
			}
			if(this.txtPrice.Text.Trim().Length==0)
			{
				strErr+="价格不能为空！\\n";	
			}
			if(this.txtSpecification.Text.Trim().Length==0)
			{
				strErr+="规格不能为空！\\n";	
			}
			if(this.txtDrugSource.Text.Trim().Length==0)
			{
				strErr+="来源不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtInDate.Text))
			{
				strErr+="入库时间格式错误！\\n";	
			}
			if(this.txtStoragetempera.Text.Trim().Length==0)
			{
				strErr+="存储温度不能为空！\\n";	
			}
			if(this.txtManufacturers.Text.Trim().Length==0)
			{
				strErr+="厂家不能为空！\\n";	
			}
			if(this.txtBrand.Text.Trim().Length==0)
			{
				strErr+="品牌不能为空！\\n";	
			}
			if(this.txtDrugIMG.Text.Trim().Length==0)
			{
				strErr+="图片不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtTID.Text))
			{
				strErr+="外键-药品类型格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string DrugName=this.txtDrugName.Text;
			int Dlevel=int.Parse(this.txtDlevel.Text);
			DateTime ManufactureDate=DateTime.Parse(this.txtManufactureDate.Text);
			DateTime ValidTime=DateTime.Parse(this.txtValidTime.Text);
			string Price=this.txtPrice.Text;
			string Specification=this.txtSpecification.Text;
			string DrugSource=this.txtDrugSource.Text;
			DateTime InDate=DateTime.Parse(this.txtInDate.Text);
			string Storagetempera=this.txtStoragetempera.Text;
			string Manufacturers=this.txtManufacturers.Text;
			string Brand=this.txtBrand.Text;
			string DrugIMG=this.txtDrugIMG.Text;
			int TID=int.Parse(this.txtTID.Text);

			YCF_Server.Model.Drug model=new YCF_Server.Model.Drug();
			model.DrugName=DrugName;
			model.Dlevel=Dlevel;
			model.ManufactureDate=ManufactureDate;
			model.ValidTime=ValidTime;
			model.Price=Price;
			model.Specification=Specification;
			model.DrugSource=DrugSource;
			model.InDate=InDate;
			model.Storagetempera=Storagetempera;
			model.Manufacturers=Manufacturers;
			model.Brand=Brand;
			model.DrugIMG=DrugIMG;
			model.TID=TID;

			YCF_Server.BLL.Drug bll=new YCF_Server.BLL.Drug();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
