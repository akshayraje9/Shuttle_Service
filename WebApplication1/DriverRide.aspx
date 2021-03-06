﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DriverRide.aspx.cs" Inherits="WebApplication1.DriverRide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Style/StyleSheet2.css" rel="stylesheet" />

       <asp:Panel id="pnlLogin1" runat="server">                        
       </asp:Panel>       
   
<div style="background-color:lightgrey">
     
 <asp:Repeater id="rptUserSchedule" runat="server" >    

 <ItemTemplate>


   
<div class="container">

    <div style="clear:both; width:90%; text-align:center;">
        <asp:Label ID="lblType" runat="server"  Font-Bold="true" ForeColor="Tan" >Accept Ride Request</asp:Label>        
    </div>

    <div class="dvOuter">
        <div class="dvColumn" >
            <asp:Label ID="lblCustName" runat="server">Customer Name</asp:Label>
        </div>
        <div class="dvDisplay">
            <asp:TextBox ID="txtCustName" runat="server" Width="270px" Enabled="False" Text='<%#Eval("CustName")%>'></asp:TextBox>
        </div>
    </div>

    <div class="dvOuter" >
        <div class="dvColumn">
            <asp:Label ID="lblPick" runat="server">Pickup Address</asp:Label>
        </div>
        <div class="dvDisplay" >
            <asp:TextBox ID="txtPickup" runat="server" Width="270px" Enabled="False" Text='<%#Eval("PickupAdd")%>'></asp:TextBox>
        </div>
    </div>

    <div class="dvOuter" >
        <div class="dvColumn" >
            <asp:Label ID="lblDropoff" runat="server">Dropoff Address</asp:Label>
        </div>
        <div class="dvDisplay" >
            <asp:TextBox ID="txtDropoff" runat="server" Width="270px" Enabled="False" Text='<%#Eval("DropoffAdd")%>'></asp:TextBox>
        </div>
    </div>

    <div class="dvOuter" >

        <div style=" width:20%; float:left">
            <asp:Label ID="lblDate" runat="server" >Travel Date</asp:Label>
        </div>

        <div style="width:25%; float:left">
            <input id="date" runat="server" disabled="disabled"  required  max="2018-12-31" maxlength="4" value='<%#Eval("TravelDt")%>'/>
        </div>

        <div style="width:20%; float:left">
            <asp:Label ID="lblTime" runat="server">Pickup Time</asp:Label>
        </div>

        <div style="width:25%; float:left">
            <input id="time" runat="server" required   max="24:00" disabled="disabled" value='<%#Eval("PickupTime")%>' />
        </div>
    </div>

    <div style="clear:both; padding:20px; padding-bottom:25px">
        <div style="width:45%; float:left">
            <asp:Button ID="btnAccept" Text="Accept Ride" runat="server"   OnClick="btnAccept_Click" />&nbsp&nbsp&nbsp
            <asp:Button ID="btnReject" Text="Reject Ride" runat="server" OnClick="btnReject_Click" />
        </div>
        <div style="width:45%; float:none">
        </div>
    </div>
    
</div>

</ItemTemplate>

 <SeparatorTemplate>
 <br />
 </SeparatorTemplate>


</asp:Repeater>

</div>

</asp:Content>
