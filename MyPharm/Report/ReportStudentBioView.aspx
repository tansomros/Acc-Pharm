<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportStudentBioView.aspx.vb" Inherits=".ReportStudentBioView" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>   
      
<table width="100%" border="0" cellspacing="2" cellpadding="0"> 
  <tr>
    <td align="center">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%" ProcessingMode="Remote" ShowParameterPrompts="False" ShowPrintButton="true" DocumentMapWidth="100%" ZoomMode="PageWidth">
    </rsweb:ReportViewer>
      </td>
  </tr>   
</table>
         
       
    </form>
</body>
</html>
