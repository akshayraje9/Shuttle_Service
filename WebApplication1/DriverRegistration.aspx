<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DriverRegistration.aspx.cs" Inherits="WebApplication1.DriverRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    

    <link href="Style/StyleSheet1.css" rel="stylesheet"  />

     <script type="text/javascript" >

        function validate()
        {
            var robot, tnc, sub;

            robot = document.getElementById('<%=chkRobot.ClientID%>').checked;
            tnc = document.getElementById('<%=chkTC.ClientID%>').checked; 

            if (Page_ClientValidate()) {
                if (robot == false) {
                    document.getElementById('<%=lblRobot.ClientID%>').innerHTML = "Verify that you are not a robot";
                    return false;
                }
                else {
                    document.getElementById('<%=lblRobot.ClientID%>').innerHTML = "";
                }


                if (tnc == false) {
                    document.getElementById('<%=lblTC.ClientID%>').innerHTML = "Please read the terms and conditions";
                    return false;
                }
                else {
                    document.getElementById('<%=lblTC.ClientID%>').innerHTML = "";
                }
                return true;
            }
        }

    </script>


        <div style=" margin:15px; background-color:lightgray; height:100%; clear:both ">

        <div style="margin-left:15px; padding-top:1px">
            <h2> Driver Registration </h2>
        </div>
        
        <div class="dvInput" style="text-align:center; overflow:hidden">
             <asp:Button ID="btnUpdate" runat="server"  Text="Update Profile" OnClick="btnUpdate_Click" />
        </div>

        <div style="margin-left:15px; clear:both">
            <h3> Personal Information </h3>
        </div>

        <div class="container" style="text-align:center; background-color:lightgray">
            <asp:Label ID="lblDup" runat="server" CssClass="error" ></asp:Label>
        </div>

        <div class="container">
            
            <div class="dvContainer">
            <div class="dvColumn" >
                <label class="txtColumn">First Name *</label>
            </div>
            <div class="dvInput">
                <asp:TextBox ID="txtFirstName" CssClass="txtInput" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator  CssClass="error" id="reqFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First name cannot be blank"   ValidationGroup="usrValid" SetFocusOnError="true" ></asp:RequiredFieldValidator>
            </div>
            </div>

            <div class="dvContainer">
                <div class="dvColumn" >
                    <label class="txtColumn">Last Name *</label>
                </div>
                <div class="dvInput">
                    <asp:TextBox ID="txtLastName" CssClass="txtInput" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator  CssClass="error" id="reqLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name cannot be blank" ValidationGroup="usrValid" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="dvContainer">
                <div class="dvColumn">
                    <label class="txtColumn">Phone Number</label>
                </div>
                <div class="dvInput">
                    <asp:TextBox id="txtPhoneNumber" CssClass="txtInput" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator  CssClass="error" id="reqPhoneNum" runat="server"  ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid Phone Number" ValidationGroup="usrValid" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" SetFocusOnError="true"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="dvContainer" style="margin-bottom:20px">
                <div class="dvColumn">
                    <label class="txtColumn">Date of Birth *</label>
                </div>
                <div class="dvInput">
                    <input class="txtInput" type="date" id="txtDOB" runat="server" required value="2018-10-09" />
                </div>
            </div>
        </div>

            
        <div style="margin-left:15px">
            <h3> Account Information </h3>
        </div>

        <div class="container">

            <div class="dvContainer">
                <div class="dvColumn">
                    <label class="txtColumn">Email *</label>
                </div>
                <div class="dvInput">
                    <asp:TextBox ID="txtEmail" CssClass="txtInput" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmailValidate" runat="server" CssClass="error" ControlToValidate="txtEmail"  ErrorMessage="Email cannot be blank" ValidationGroup="usrValid" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reqEmail" runat="server" CssClass="error" ErrorMessage="Invalid Email ID" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ValidationGroup="usrValid" SetFocusOnError="true"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="dvContainer">
                <div class="dvColumn">
                    <label class="txtColumn">Password *</label>
                </div>
                <div class="dvInput">
                
                    <asp:TextBox ID="txtPassword" CssClass="txtInput" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" CssClass="error" ControlToValidate="txtPassword" ErrorMessage="Password cannot be blank"  ValidationGroup="usrValid" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="dvContainer">
                <div class="dvColumn">
                    <label class="txtColumn">Confirm Password *</label>
                </div>
                <div class="dvInput">
                    <asp:TextBox ID="txtConfPass" CssClass="txtInput" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqConfPassword" runat="server" CssClass="error" ControlToValidate="txtConfPass" ErrorMessage="Confirm Password cannot be blank" ValidationGroup="usrValid" SetFocusOnError="true" ></asp:RequiredFieldValidator><br />
                    <asp:CompareValidator ID="cvConfPass" runat="server" CssClass="error" ControlToValidate="txtConfPass" ControlToCompare="txtPassword" ErrorMessage="Please check the password" ValidationGroup="usrValid" SetFocusOnError="true"></asp:CompareValidator>
                </div>
            </div>

            <div class="dvContainer">
                <div class="dvColumn">
                    <label class="txtColumn">Security Question *</label>
                </div>
                <div class="dvInput">                    
                    <asp:DropDownList ID="ddlSecurity" CssClass="txtInput"  runat ="server" Width="200px">
                       
                    </asp:DropDownList>
                </div>
            </div>

            <div class="dvContainer" style="margin-bottom:20px;">
                <div class="dvColumn">
                    <label class="txtColumn">Security Answer *</label>
                </div>
                <div class="dvInput">
                    <asp:TextBox ID="txtSecurity" CssClass="txtInput" runat="server">  </asp:TextBox>
                 
                    <asp:RequiredFieldValidator ID="reqSecurity" runat="server" CssClass="error" ControlToValidate="txtSecurity" ErrorMessage="Security answer cannot be blank" ValidationGroup="usrValid" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>


        <div style="margin-left:15px">
            <h3> Driver License and Vehicle Information </h3>
        </div>

        <div class="container">

            <div class="dvContainer">
                <div class="dvColumn">
                    <label class="txtColumn">Driver License # *</label>
                </div>
                <div class="dvInput">
                    <asp:TextBox ID="txtDriverLicense" CssClass="txtInput" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqDriverLicense" runat="server" CssClass="error" ControlToValidate="txtDriverLicense"  ErrorMessage="Driver License # cannot be blank" ValidationGroup="usrValid" SetFocusOnError="true"></asp:RequiredFieldValidator>                    
                </div>
            </div>

            
            <div class="dvContainer" >
                <div class="dvColumn">
                    <label class="txtColumn">Expiration Date *</label>
                </div>
                <div class="dvInput">
                    <input class="txtInput" type="date" id="dtExp" runat="server" required value="2018-10-09" />
                </div>
            </div>


            
            <div class="dvContainer">
                <div class="dvColumn">
                    <label class="txtColumn">License Type *</label>
                </div>
                <div class="dvInput">                    
                    <asp:DropDownList ID="ddLicenseType" CssClass="txtInput"  runat ="server" Width="200px">
                       
                    </asp:DropDownList>
                </div>
            </div>

            <div class="dvContainer" >
                <div class="dvColumn">
                    <label class="txtColumn">Vehicle Reg # *</label>
                </div>
                <div class="dvInput">
                    <asp:TextBox ID="txtVehReg" CssClass="txtInput" runat="server">  </asp:TextBox>                 
                    <asp:RequiredFieldValidator ID="reqVehicleReg" runat="server" CssClass="error" ControlToValidate="txtVehReg" ErrorMessage="Vehicle Reg # cannot be blank" ValidationGroup="usrValid" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="dvContainer" style="margin-bottom:20px;">
                <div class="dvColumn">
                    <label class="txtColumn">SSN *</label>
                </div>
                <div class="dvInput">
                    <asp:TextBox ID="txtSSN" CssClass="txtInput" runat="server">  </asp:TextBox>                 
                    <asp:RequiredFieldValidator ID="reqSSN" runat="server" CssClass="error" ControlToValidate="txtSSN" ErrorMessage="SSN # cannot be blank" ValidationGroup="usrValid" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rexpSSN" runat="server" CssClass="error" ControlToValidate="txtSSN" ErrorMessage="Invalid SSN"  ValidationGroup="usrValid" SetFocusOnError="true" ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>



        <div style="margin-left:15px">
            <h3> User Verification </h3>
        </div>

        <div class="container">

            <div class="dvContainer">
                <div style="width:50%; font-size:30px; float:left">
                     <asp:CheckBox ID="chkRobot" runat="server" Text="I'm not a robot"  />
                </div>
                <div style="width:50%; float:left">                  
                    <asp:Label ID="lblRobot" CssClass="error" AssociatedControlID="chkRobot" runat="server"></asp:Label>
                </div>
            </div>

            <div class="dvContainer" style="margin-bottom:30px">
                <div style="width:60%; font-size:15px; float:left">
                    <asp:CheckBox  ID="chkTC" runat="server" Text="I have read and accept the Terms and Conditions"/>
                </div>
                <div style="width:40%; float:left">
                    <asp:Label ID="lblTC"  CssClass="error" AssociatedControlID="chkTC" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <br/><br />

        <div style="margin-left:15px; margin-bottom:25px;" >
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CausesValidation="true"  ValidationGroup="usrValid" OnClientClick="return validate()"  OnClick="btnSubmit_Click" />
                        &nbsp&nbsp<asp:Button ID="btnValidate" runat="server" Text="Save Changes"  CausesValidation="true"  ValidationGroup="usrValid" OnClientClick="return validate()" OnClick="btnValidate_Click"/>
        </div>


 </div>

</asp:Content>
