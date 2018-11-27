<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PastRides.aspx.cs" Inherits="WebApplication1.PastRides" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script src="Scripts/jquery-3.3.1.js"></script>
     <script src="Scripts/jquery-3.3.1.min.js"></script>
   
     <link href="Style/StyleSheet2.css" rel="stylesheet" />

    <div style="clear:both; width:90%; text-align:center; margin:15px">
        <asp:Label ID="lblType" runat="server"  Font-Bold="true" ForeColor="Tan" Text="Past Rides" ></asp:Label>        
    </div>


<div  id="dvCustomers" style="background-color:lightgrey; text-align:center">
    
    
 <asp:Repeater id="rptUser" runat="server" >    

 <ItemTemplate>

<%--<div class="container">--%>

     <table class="tblCustomer" border="1">

    <tr>

        <td colspan="2">        
           <%-- <asp:Label ID="lblDriverName" runat="server">Driver Name</asp:Label>  --%>  
             <span class="userT"><%#Eval("Type")%></span>
        </td>
        <td colspan="2">
              <%--<asp:TextBox ID="txtCustName" runat="server"  Enabled="False" Text='<%#Eval("Name")%>' ></asp:TextBox>--%>
            <span class="name">
                            <%#Eval("Name")%></span>
        </td>

    </tr>

    <tr>
        <td colspan="2">           
            <asp:Label ID="lblPick" runat="server">Pickup Address</asp:Label>
        </td>
        <td colspan="2">           
                <%--<asp:TextBox ID="txtPickup" runat="server"  Enabled="False" Text='<%#Eval("PickupAdd")%>'></asp:TextBox>--%> 
            <span class="pickup">
                            <%#Eval("PickupAdd")%></span>

        </td>  
    </tr>

    <tr>
        <td colspan="2">    
            <asp:Label ID="lblDropoff" runat="server">Dropoff Address</asp:Label>    
        </td>
        <td colspan="2">
               <%--<asp:TextBox ID="txtDropoff" runat="server" Enabled="False" Text='<%#Eval("DropoffAdd")%>'></asp:TextBox>--%>
            <span class="dropoff">
                            <%#Eval("DropoffAdd")%></span>         

        </td>    
    </tr>


    <tr>    
        <td>        
            <asp:Label ID="lblDate" runat="server" >Travel Date</asp:Label>
        </td>

        <td>    
            <%--<input id="date" runat="server" required maxlength="4" value='<%#Eval("TravelDate")%>' />--%> 
             <span class="date">0
                            <%#Eval("TravelDate")%></span>  
        </td>

        <td>    
            <asp:Label ID="lblTime" runat="server">Pickup Time</asp:Label>    
        </td>

        <td>    
            <span class="time">
                            <%#Eval("PickupTime")%></span> 
           <%-- <input id="time" runat="server" required  max="24:00" disabled="disabled" value='<%#Eval("PickupTime")%>' />--%>    
        </td>
    </tr>

         </table>
<%--</div>--%>    
</ItemTemplate>
                
 <SeparatorTemplate>
 <br />
 </SeparatorTemplate>

</asp:Repeater>
</div>
  
    <script>

        $(document).ready(function () {

           var userId= '<%=HttpContext.Current.Session["UserId"].ToString()%>';
           var userType = '<%=HttpContext.Current.Session["type"].ToString()%>';


            $.ajax({
                type: "POST",
                url: "WebService1.asmx/GetData1",
                data: JSON.stringify({id: userId,type: userType}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {


                var xmlDoc = $.parseXML(response.d);
                var xml = $(xmlDoc);
                var customers = xml.find("Table");
                var table = $("#dvCustomers table").eq(0).clone(true);
                $("#dvCustomers table").eq(0).remove();
                customers.each(function () {
                    var customer = $(this);
                    $(".name", table).html(customer.find("Name").text());
                    $(".pickup", table).html(customer.find("PickupAdd").text());
                    $(".dropoff", table).html(customer.find("DropoffAdd").text());
                    $(".date", table).html(customer.find("TravelDate").text());
                    $(".time", table).html(customer.find("PickupTime").text());
                    $(".userT", table).html(customer.find("Type").text());


                    $("#dvCustomers").append(table).append("<br />");
                    table = $("#dvCustomers table").eq(0).clone(true);
                })
            };  
        });
        
    </script>

</asp:Content>
