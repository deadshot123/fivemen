﻿<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpIdentityLesson_TL.aspx.cs" Inherits="FpSystem_FpHelper_FpIndentityLesson_TL" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:Button  runat="server" Text="指纹验证" ID="btnIdentity" 
        onclick="btnIdentity_Click" />
<asp:CheckBox runat="server" Text="自动打开" ID="cboAuto" />
</asp:Content>

