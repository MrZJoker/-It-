﻿<%@ Page Title="机构部门表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="YCF_Server.Web.Drug.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="DID" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="DrugName" HeaderText="药品名称" SortExpression="DrugName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Dlevel" HeaderText="药品级别" SortExpression="Dlevel" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ManufactureDate" HeaderText="生产日期" SortExpression="ManufactureDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ValidTime" HeaderText="有效日期" SortExpression="ValidTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Specification" HeaderText="规格" SortExpression="Specification" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DrugSource" HeaderText="来源" SortExpression="DrugSource" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="InDate" HeaderText="入库时间" SortExpression="InDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Storagetempera" HeaderText="存储温度" SortExpression="Storagetempera" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Manufacturers" HeaderText="厂家" SortExpression="Manufacturers" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Brand" HeaderText="品牌" SortExpression="Brand" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DrugIMG" HeaderText="图片" SortExpression="DrugIMG" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TID" HeaderText="外键-药品类型" SortExpression="TID" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="DID" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="DID" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
