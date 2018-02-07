<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeSignUp.aspx.cs" Inherits="_Default" EnableViewState="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee SignUp</title>
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>SIGN UP</h2>
        <div id="panelSignUp">
            <p>
                <label for="employeeName" id="employeeNameLabel" class="floatLabel">Employee Name</label>
                <input id="employeeName" runat="server" name="EmployeeName" type="text" />
            </p>
            <p>
                <label for="employeeNumber" id="employeeNumberLabel" class="floatLabel">Employee Number</label>
                <input id="employeeNumber" runat="server" name="Employee Number" type="text" />
            </p>
            <p>
                <label for="password" id="passwordLabel" class="floatLabel">Password</label>
                <input id="password" runat="server" name="password" type="password" />
                <span>Enter a password longer than 8 characters</span>
            </p>
            <p>
                <label for="confirm_password" class="floatLabel">Confirm Password</label>
                <input id="confirm_password" runat="server" name="confirm_password" type="password" />
                <span>Your passwords do not match</span>
            </p>
            <p>
                <label for="designation" id="designationLabel" class="floatLabel">Designation</label>
                <select id="designation" enableviewstate="true" runat="server" name="designation">
                </select>
            </p>
            <p>
                <label for="serviceline" id="servicelineLabel" class="floatLabel">Service Line</label>
                <select id="serviceline" enableviewstate="true" runat="server" name="serviceline">
                    <option value="volvo">Volvo</option>
                    <option value="saab">Saab</option>
                    <option value="mercedes">Mercedes</option>
                    <option value="audi">Audi</option>
                </select>
            </p>
            <p>
                <label for="role" id="roleLabel" class="floatLabel">Role</label>
                <select id="role" enableviewstate="true" runat="server" name="role">
                    <option value="volvo">Volvo</option>
                    <option value="saab">Saab</option>
                    <option value="mercedes">Mercedes</option>
                    <option value="audi">Audi</option>
                </select>
            </p>
        </div>
        <p>
            <asp:Button ID="SignUpNewEmployee" EnableViewState="false" runat="server" Text="SIGN UP"
                CssClass="submit" OnClientClick="javascript:return Validate();" OnClick="SignUpNewEmployee_Click"></asp:Button>
        </p>
    </form>
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/index.js"></script>
</body>
</html>
