<%@ 
    Control Language="C#" AutoEventWireup="true" CodeBehind="Ride.ascx.cs" Inherits="WebApplication1.Ride" %>

<div style="clear:both; border-style:groove">

    <div style="clear:both; width:70%; text-align:center;">
        <asp:Label ID="lblType" runat="server"  Font-Bold="true" ForeColor="Tan"  >Book a Ride</asp:Label>        
    </div>
    <div style="clear:both;padding:20px">
        <div style="width:30%; float:left">
            <asp:Label ID="lblPick" runat="server">Pickup Address</asp:Label>
        </div>
        <div style="width:65%; float:left">
            <asp:TextBox ID="txtPickup" runat="server" Width="270px"></asp:TextBox>
        </div>
    </div>

    <div style="clear:both; padding:20px">
        <div style="width:30%; float:left">
            <asp:Label ID="lblDropoff" runat="server">Dropoff Address</asp:Label>
        </div>
        <div style="width:65%; float:left">
            <asp:TextBox ID="txtDropoff" runat="server" Width="270px"></asp:TextBox>
        </div>
    </div>


    <div style="clear:both; padding:20px; padding-bottom:25px">
        <div style="width:45%; float:left">
            <asp:Button ID="btnConfirm" Text="Confirm Ride" runat="server" OnClick="btnConfirm_Click" />
        </div>
        <div style="width:45%; float:none">
        </div>
    </div>
    
</div>
