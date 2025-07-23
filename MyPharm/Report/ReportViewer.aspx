<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportViewer.aspx.vb" Inherits="CPA.ReportViewer" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-874" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      
     <section class="content-header">
      <h1><asp:Label ID="lblReportTitle" runat="server" Text="Report"></asp:Label>
          <small></small>
              
      </h1>
     
    </section>

<section class="content">
             
 <div class="box box-primary">
            <div class="box-header">
              <i class="fa fa-print"></i>
              <h3 class="box-title">Report</h3>             
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                 
            </div>
            <div class="box-body">
<table width="100%" border="0" cellspacing="2" cellpadding="0">
  <tr>
    <td align="center">
        <asp:Panel ID="Panel1" runat="server">
        <table border="0" cellspacing="2" cellpadding="0"> <tr>
    <td align="center" class="text11b_blue">&nbsp;</td>
  </tr>
  <tr>
    <td class="text11b_blue">Browser นี้ไม่สนับสนุนระบบแสดงผลรายงาน กรุณาเปลี่ยนไปใช้ 
        Chrome เพื่อประสิทธิภาพของรายงาน </td>
  </tr>
  <tr>
    <td align="center" class="text11b_blue"> ขออภัยในความไม่สะดวก</td>
  </tr>
 <tr>
    <td class="text11b_blue">Browser does not support display reports. Please switch to Google Chrome Browser for performance reports.</td>
  </tr>
  <tr>
    <td align="center" class="text11b_blue"> Sorry for the inconvenience</td>
  </tr>
</table>
</asp:Panel>
      </td>
  </tr>
  <tr>
    <td align="center">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%" ProcessingMode="Remote" ShowParameterPrompts="False" ShowPrintButton="true" BackColor="White" DocumentMapWidth="100%" ZoomMode="PageWidth">
    </rsweb:ReportViewer>
      </td>
  </tr>
   
</table>
</div>
            <div class="box-footer clearfix">
           
            </div>
          </div>
    </section>     
</asp:Content>
