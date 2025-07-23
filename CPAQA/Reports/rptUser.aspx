<%@ Page Title="" Language="VB" AutoEventWireup="true" CodeBehind="rptUser.aspx.vb" Inherits="CPAQA.rptUser" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Export Legal to excell</title>
</head>
<body style="margin: 0; padding: 0;">
    <form id="form1" runat="server">
        <table id="tableExport" border="1" width="100%">
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Username</th>
                    <th>Password</th>
                    <th>ชื่อ-สกุล</th>           
                    <th>หน่วยงาน</th>
                    <th>อีเมล์</th>
                    <th>สิทธิ์การใช้งาน</th>
                    <th>สถานะ</th>
                </tr>                
            </thead>
            <tbody>
                <% For Each row As DataRow In dtUser.Rows %>
                <tr>
                    <td style="vertical-align:top;text-align:center;"><% =String.Concat(row("nRow")) %></td>
                    <td style="vertical-align:top;text-align:left;"><% =String.Concat(row("Username")) %></td>
                    <td style="vertical-align:top;text-align:left;"><% = enc2.DecryptString(String.Concat(row("Passwords")), True) %></td>
                    <td style="vertical-align:top;text-align:left;"><% =String.Concat(row("DisplayName")) %></td>                   
                    <td style="vertical-align:top;text-align:left;"><% =String.Concat(row("LocationName")) %></td>
                    <td style="vertical-align:top;text-align:left;"><% =String.Concat(row("Email")) %></td>                       
                    <td style="vertical-align:top;text-align:center;"><% =String.Concat(row("RoleName")) %></td> 
                     <td style="vertical-align:top;text-align:center;"><% =String.Concat(row("StatusFlag")) %></td>
                </tr>
                <%  Next %>
            </tbody>
        </table>
    </form>
</body>
</html>
