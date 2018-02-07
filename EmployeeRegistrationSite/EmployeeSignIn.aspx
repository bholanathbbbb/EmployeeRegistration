<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeSignIn.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee SignIn</title>
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>SIGN IN</h2>
            <p>
                <label for="employeeNumber" class="floatLabel" id="employeeNumberLabel">Employee Number</label>
                <input id="employeeNumber" runat="server" name="Employee Number" type="text" />
            </p>
            <p>
                <label for="password" class="floatLabel" id="passwordLabel">Password</label>
                <input id="password" name="password" runat="server" type="password" />
                <span id="errorMsg" runat="server" style="display:none">Incorrect Employee Number or Password</span>
            </p>
        <p>
            <asp:Button ID="SignIn" EnableViewState="false" runat="server" Text="SIGN IN"
                            CssClass="submit" OnClientClick="javascript:return Validate();" OnClick="SignIn_Click" ></asp:Button>
        </p>
        <div style="text-align:right;cursor:pointer;font-size:12px">
            <a href="EmployeeSignUp.aspx"><u>New User</u></a>
        </div>
    </form>
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/validate.js"></script>
</body>
</html>
