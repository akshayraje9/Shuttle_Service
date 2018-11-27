<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="WebApplication1.UserInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" 
  runat="server">
    
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
       
    <link href="Style/StyleSheet2.css" rel="stylesheet" />

    <div style="background-color:lightgrey">
        
    <div class="container" style="width:70%">
    
    <div style="clear:both; width:90%; text-align:center;">
        <asp:Label ID="lblType" runat="server"  Font-Bold="true" ForeColor="Tan" >Book a Ride</asp:Label>        
    </div>

    <div class="dvOuter">
        <div class="dvColumn">
            <asp:Label ID="lblPick" runat="server">Pickup Address</asp:Label>
        </div>
        <div class="dvDisplay">
            <asp:TextBox ID="txtPickup" runat="server" Width="270px"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="reqPickup" class="error" runat="server" ControlToValidate="txtPickup" ErrorMessage="Cannot be blank!" ValidationGroup="valCustomer"></asp:RequiredFieldValidator>--%>
        </div>
    </div>

    <div class="dvOuter">
        <div class="dvColumn">
            <asp:Label ID="lblDropoff" runat="server">Dropoff Address</asp:Label>
        </div>
        <div class="dvDisplay">
            <asp:TextBox ID="txtDropoff" runat="server" Width="270px"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="reqDropoff" class="error" runat="server" ControlToValidate="txtDropoff" ErrorMessage="Cannot be blank!" ValidationGroup="valCustomer"></asp:RequiredFieldValidator>--%>
        </div>
    </div>

    <div class="dvOuter">
        
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
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm Ride"  />
        </div>
        <div style="width:45%; float:none; color:red">
            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
        </div>
    </div>
    
    </div>

    </div>

    <script>

        $(document).ready(function () {

            $("[id*=btnConfirm]").click(function () {
                var val1 = $("[id*=txtPickup]").val();
                var val2 = $("[id*=txtDropoff]").val();
                var valTime = $("[id*=time]").val();
                var valDate = $("[id*=date]").val();

                if (val1.length == 0)
                {
                    alert("Pickup location cannot be blank");
                }
                else if (val2.length == 0)
                {
                    alert("Dropoff location cannot be blank");
                }
                else
                {
                    $.ajax({
                        type: "POST",
                        url: "UserInfo.aspx/AddUpdate",  
                        data:   JSON.stringify({pickup: val1 , dropoff:val2, datePickup: valDate, timePickup: valTime}),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response)
                        {
                            alert("Successful");
                            $("[id*=txtPickup]").val("");
                            $("[id*=txtDropoff]").val("");
                        }
                            ,
                        failure: function (response) {
                                alert(response.d);
                            }
                     });
                }               
            });

        });

    </script>

</asp:Content>
