﻿<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpFeeVerify.aspx.cs" Inherits="FpSystem_FpHelper_FpFeeVerify" Title="无标题页" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   <script type="text/javascript">
   
     $(document).ready(function(){
      
       var page= parseInt($("#tdPager").find("input:eq(0)").val());
       var size=30;
       var i=(page-1)*30;
      // alert(i);
       $("#tableFeeData").find("tr:gt(1)").each(function(){
         // alert(i);
          $(this).find("td:eq(0)").css("text-align","right").prepend((++i)+"&nbsp;");
       });
     });
   
   </script>
  
   <table class="table-border" >
   
       <tr class="table-content">
          <td style=" padding:10px; text-align:right">
                       交费状态：
              <asp:DropDownList ID="ddlFeeStatue" runat="server">
                 <asp:ListItem Text="未交费" Value="N"></asp:ListItem>
                 <asp:ListItem Text="已交费" Value="Y"></asp:ListItem>
              </asp:DropDownList>
              &nbsp;  驾校：<asp:DropDownList ID="ddlSchoolCode" runat="server" >
              </asp:DropDownList>
              &nbsp;  车型：<asp:DropDownList ID="ddlCarType" runat="server">
              </asp:DropDownList>
              &nbsp;学员信息:
                            <asp:DropDownList ID="ddlQueryType" runat="server">
                            <asp:ListItem Text="受理号" Value="lsh"></asp:ListItem>
              <asp:ListItem Text="证件号码" Value="idcard"></asp:ListItem>
              
              <asp:ListItem Text="姓名" Value="name"></asp:ListItem>
           </asp:DropDownList>
           <asp:TextBox ID="txtQueryValue" runat="server"></asp:TextBox>
              <asp:Button Text="查询" runat="server" ID="btnSearch" onclick="btnSearch_Click" />
          </td>
          
       </tr>
       
       <tr class="table-content">
          <td style="padding:15px;  text-align:right">
             <asp:CheckBox runat="server" Text="全选" id="cbAll"  AutoPostBack="true" Checked="true"
                  oncheckedchanged="cbAll_CheckedChanged" /> &nbsp;
             <asp:Button runat="server" Text="批量审核" id="btnBatchVerify" 
                  onclick="btnBatchVerify_Click" />&nbsp;
                               <asp:Button runat="server" Text="批量取消审核" 
                  id="btnBatchDisVerify" onclick="btnBatchDisVerify_Click" 
                   />
          </td>
       </tr>
   
   </table>
   

   <table class="table-border" id="tableFeeData">
          
   
        <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border"  OnItemCommand="DataGrid1_ItemCommand1"
                         
                        Width="100%">
                        <Columns>
                        
                            <asp:TemplateColumn HeaderStyle-Width="70px">
                               <ItemTemplate>
                                   <asp:CheckBox runat="server" ID="cbIdCard"  Checked="true"  ></asp:CheckBox>
                               </ItemTemplate>
                            </asp:TemplateColumn>
                   
                            <asp:BoundColumn DataField="lsh" HeaderText="流水号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="name" HeaderText="姓名" HeaderStyle-Width="90"></asp:BoundColumn>
                             <asp:BoundColumn DataField="idcard" HeaderText="身份证明号码" HeaderStyle-Width="220"></asp:BoundColumn>
                            <asp:BoundColumn DataField="school_name" HeaderText="驾校"></asp:BoundColumn>
                             <asp:BoundColumn DataField="car_type" HeaderText="车型" HeaderStyle-Width="70"></asp:BoundColumn>
                            <asp:BoundColumn DataField="fee_verify_date" HeaderText="收费审核时间"></asp:BoundColumn>
                             
                             <asp:TemplateColumn HeaderText="操作">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" AlternateText="审核" CommandArgument='<%#Eval("idcard") %>'
                                        CommandName="Verify" ImageUrl="~/images/modify.gif" 
                                        ToolTip="审核" />
                                        
                                   <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="审核" CommandArgument='<%#Eval("idcard") %>'
                                        CommandName="DisVerify" ImageUrl="~/images/delete.gif" 
                                        ToolTip="取消审核" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            
                            
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                        

                        
                    </asp:DataGrid>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
               <tr class="table-bottom">
                <td id="tdPager">
                 
                    <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True"  PageSize="30"
                        BindControlString="DataGrid1">
                    </WC:ProcedurePager>
                 
                </td>
            </tr>
   </table>


</asp:Content>

