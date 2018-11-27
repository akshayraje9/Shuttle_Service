<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DriverUC.ascx.cs" Inherits="WebApplication1.DriverUC" %>


<script type="text/javascript">

    function func1()
    {
        return true;
    }

</script>

<div style="clear:both; border-style:groove; padding:10px; margin:10px">

    <div style="clear:both; width:70%; text-align:center;">
        <asp:Label ID="lblType" runat="server"  Font-Bold="true" ForeColor="Tan" >Accept Ride Request</asp:Label>        
    </div>


    <div style="clear:both;padding:20px">
        <div style="width:30%; float:left">
            <asp:Label ID="lblCustName" runat="server">Customer Name</asp:Label>
        </div>
        <div style="width:65%; float:left">
            <asp:TextBox ID="txtCustName" runat="server" Width="270px" Enabled="False"></asp:TextBox>
        </div>
    </div>


    <div style="clear:both;padding:20px">
        <div style="width:30%; float:left">
            <asp:Label ID="lblPick" runat="server">Pickup Address</asp:Label>
        </div>
        <div style="width:65%; float:left">
            <asp:TextBox ID="txtPickup" runat="server" Width="270px" Enabled="False"></asp:TextBox>
        </div>
    </div>

    <div style="clear:both; padding:20px">
        <div style="width:30%; float:left">
            <asp:Label ID="lblDropoff" runat="server">Dropoff Address</asp:Label>
        </div>
        <div style="width:65%; float:left">
            <asp:TextBox ID="txtDropoff" runat="server" Width="270px" Enabled="False"></asp:TextBox>
        </div>
    </div>

    <div style="clear:both; padding:20px">

        <div style=" width:20%; float:left">
            <asp:Label ID="lblDate" runat="server" >Travel Date</asp:Label>
        </div>

        <div style="width:25%; float:left">
            <input id="date" runat="server" disabled="disabled"  required type="date" value="2018-10-10" max="2018-12-31" maxlength="4" />
        </div>

        <div style="width:20%; float:left">
            <asp:Label ID="lblTime" runat="server">Pickup Time</asp:Label>
        </div>

        <div style="width:25%; float:left">
            <input id="time" runat="server" required type="time"  value="17:00"  max="24:00" disabled="disabled"  />
        </div>
    </div>


    <div style="clear:both; padding:20px; padding-bottom:25px">
        <div style="width:45%; float:left">
            <asp:Button ID="btnAccept" Text="Accept Ride" runat="server"  OnClientClick="return func1()" OnClick="btnAccept_Click" />&nbsp&nbsp&nbsp
            <asp:Button ID="btnReject" Text="Reject Ride" runat="server" OnClick="btnReject_Click" />
        </div>
        <div style="width:45%; float:none">
        </div>
    </div>
    
</div>

