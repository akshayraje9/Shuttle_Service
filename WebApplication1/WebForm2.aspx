<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="clear:both; padding:15px">
    <asp:GridView ID="grdData" runat="server" AllowPaging="True" Height="174px" OnPageIndexChanged="grdData_PageIndexChanged" OnPageIndexChanging="grdData_PageIndexChanging" OnSelectedIndexChanged="grdData_SelectedIndexChanged" PageSize="3">

    </asp:GridView>
</div>
</asp:Content>
