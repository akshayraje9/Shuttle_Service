<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .dvInput {
            width:75%; 
            float:left; 
            margin-left:10px;
            padding-bottom:15px;
        }

        .txtInput {
            font-size: 15px;
        }

        .dvColumn {
            width: 20%;
            float: left;
            text-align: right;
            padding-bottom:15px;
        }

        .txtColumn{
            font-size:15px;
        }

        .error {
            font-size: 15px;
            color: red;
        }
</style>

</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div style="width:50%; border-radius:14px; border-color:blue; border:groove; border-bottom-color:black; margin:auto; margin-top:70px   ">
            <div style="text-align:center">
                <h2>My Shuttle</h2>
            </div>

            <div style="clear:both">
                 <div class="dvColumn">
                     <asp:Label ID="lblEmail" runat="server" CssClass="txtColumn">Email ID</asp:Label>
                 </div>
                 <div class="dvInput">
                    <asp:TextBox ID="txtEmail" runat="server" Width="234px" CssClass="txtInput"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email ID cannot be blank" CssClass="error"></asp:RequiredFieldValidator>
                 </div>
            </div>
             
            <div style="clear:both">
                <div class="dvColumn" >
                     <asp:Label ID="lblPassword" runat="server"  CssClass="txtColumn" >Password</asp:Label>
                 </div>
                 <div class="dvInput" >
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="234px" CssClass="txtInput" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="reqPass" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password cannot be blank" CssClass="error" ></asp:RequiredFieldValidator>
                     
                 </div>
            </div>

            <div style="clear:both; text-align:center; padding-bottom:15px; ">
                <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
            </div>

            <div style="clear:both; text-align:center; padding-bottom:15px; ">
                <asp:Button ID="btnLogin" Text="LOGIN" runat="server" OnClick="btnLogin_Click"  />
            </div>
            
            <div style="clear:both; text-align:center; padding-bottom:15px; ">
                <a id="CustReg" href="WebForm1.aspx">Click here to register as a Customer</a>
            </div>
           
             <div style="clear:both; text-align:center; padding-bottom:15px; margin-bottom:10px ">
                <a id="DriverReg"   href="DriverRegistration.aspx" >Click here to register as a Driver</a>
            </div>

        </div>
    </form>
</body>
</html>
