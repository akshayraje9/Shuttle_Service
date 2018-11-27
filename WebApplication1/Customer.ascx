<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Customer.ascx.cs" Inherits="WebApplication1.Customer" %>

<div style="clear:both; border-style:groove">

    <style>

        .Error
        {
            color:red;
        }

    </style>

    <div style="clear:both; width:70%; text-align:center;">
        <asp:Label ID="lblType" runat="server"  Font-Bold="true" ForeColor="Tan" >Book a Ride</asp:Label>        
    </div>
    <div style="clear:both;padding:20px">
        <div style="width:30%; float:left;">
            <asp:Label ID="lblPick" runat="server">Pickup Address</asp:Label>
        </div>
        <div style="width:65%; float:left">
            <asp:TextBox ID="txtPickup" runat="server" Width="270px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqPickup" CssClass="Error" runat="server" ControlToValidate="txtPickup" ErrorMessage="Cannot be blank!" ValidationGroup="valCustomer"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div style="clear:both; padding:20px">
        <div style="width:30%; float:left;">
            <asp:Label ID="lblDropoff" runat="server">Dropoff Address</asp:Label>
        </div>
        <div style="width:65%; float:left">
            <asp:TextBox ID="txtDropoff" runat="server" Width="270px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDropoff" CssClass="Error" runat="server" ControlToValidate="txtDropoff" ErrorMessage="Cannot be blank!" ValidationGroup="valCustomer"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div style="clear:both; padding:20px">

        <div style=" width:20%; float:left">
            <asp:Label ID="lblDate" runat="server" >Travel Date</asp:Label>
        </div>

        <div style="width:25%; float:left">
            <input id="date" runat="server"  required type="date" value="2018-10-10" max="2018-12-31" maxlength="4" />
        </div>

        <div style="width:20%; float:left">
            <asp:Label ID="lblTime" runat="server">Pickup Time</asp:Label>
        </div>

        <div style="width:25%; float:left">
            <input id="time" runat="server" required type="time" value="17:00"  max="24:00" />
        </div>
    </div>


    <div style="clear:both; padding:20px; padding-bottom:25px">
        <div style="width:45%; float:left">
            <asp:Button ID="btnConfirm" runat="server"  Text="Confirm Ride" CausesValidation="true" ValidationGroup="valCustomer" OnClick="btnConfirm_Click" />
        </div>
        <div style="width:45%; float:none; color:red">
            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
        </div>
    </div>
    
</div>
