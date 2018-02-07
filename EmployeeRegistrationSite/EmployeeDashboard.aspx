<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeDashboard.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Dashboard</title>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="css/responsive.bootstrap.min.css" rel="stylesheet" />
    <link href="css/dashboard.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>DASHBOARD</h2>
        <table id="signOut">
            <tbody>
                <tr>
                    <td>
                        <label class="floatLabel">EMPLOYEE INFORMATION</label>
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="SignOut" EnableViewState="false" runat="server" Text="SIGN OUT"
                CssClass="submit" OnClick="SignOut_Click"></asp:Button>
                    </td>
                </tr>
            </tbody>
        </table>

        <br />
        <br />
        <table id="employeeDashboard" runat="server" class="table table-striped table-bordered dt-responsive nowrap" width="100%" cellspacing="0">
        </table>

        <asp:HiddenField ID="hdnData" runat="server" />
       </form>
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/jquery.dataTables.min.js"></script>
    <script src="js/dataTables.bootstrap.min.js"></script>
    <script src="js/dataTables.responsive.min.js"></script>
    <script src="js/responsive.bootstrap.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#employeeDashboard").DataTable({
                "aaData": JSON.parse($("#hdnData").val()),
                "columns": [
                           { "title": "Employee Number", "data": "UserInfo.EmployeeNumber" },
                           { "title": "Employee Name", "data": "EmployeeName" },
                           { "title": "Designation", "data": "Designation" },
                           { "title": "Service Line", "data": "ServiceLine" },
                           { "title": "Role", "data": "Role" }
                ]
            });
        });
    </script>
</body>
</html>
