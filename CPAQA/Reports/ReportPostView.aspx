<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportPostView.aspx.vb" Inherits="CPAQA.ReportPostView" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>การตรวจรักษามาตรฐาน</title>
    <link href="https://fonts.googleapis.com/css?family=Sarabun:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link href="../css/main.css?v=001" rel="stylesheet" />
    <link href="../css/reportprint.css?v=001" rel="stylesheet" />
    <link rel="stylesheet" href="../assets/css/AdminLTE.min.css?v=001" />

    <script language="Javascript">
        function doprint() {
            document.all("cmdPrint").style.visibility = 'hidden';
            window.print();
            document.all("cmdPrint").style.visibility = 'visible';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <section class="content">
            <div class="report-header text-center">
                <span class="report-header-title">การตรวจรักษามาตรฐาน            
                </span>
            </div>
            <div class="report-body">            
                <div class="row">
                    <div class="col-md-6">
                        <label><b>ชื่อร้านยา</b></label>
                        <asp:Label ID="lblLocationName" runat="server" CssClass="text-blue text-bold report-text"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <label><b>เลขที่ใบอนุญาต</b></label>
                        <asp:Label ID="lblLicenseNo" runat="server" CssClass="text-blue text-bold report-text"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <label><b>เลขที่เกียรติบัตร</b></label>
                        <asp:Label ID="lblAccPharm" runat="server" CssClass="text-blue text-bold report-text"></asp:Label>
                    </div>
                     <div class="col-md-9">
     <label><b>ที่อยู่</b></label>
     <asp:Label ID="lblAddress" runat="server" CssClass="report-text"></asp:Label>
 </div>
            <div class="col-md-3">
                        <label><b>โทรศัพท์</b></label>
                        <asp:Label ID="lblTel" runat="server" CssClass="report-text"></asp:Label>
                    </div>             
        <div class="col-md-6">
            <label><b>วันที่ตรวจประเมิน</b></label>
            <asp:Label ID="lblDate" runat="server" CssClass="report-text"></asp:Label>
        </div>
           <div class="col-md-6">
                        <label><b>วิธีการตรวจ </b></label>
                        <asp:Label ID="lblMethod" runat="server" CssClass="report-text"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <label><b>ผู้รับการตรวจ</b></label>
                        <asp:Label ID="lblAssessee" runat="server" CssClass="report-text"></asp:Label>
                    </div>

                    <div class="col-md-6">
                        <label><b>ตำแหน่งในร้าน </b></label>
                        <asp:Label ID="lblPosition" runat="server" CssClass="report-text"></asp:Label>
                    </div>
                

                    <div class="col-md-6">
                        <label><b>ผู้รับอนุญาต</b></label>
                        <asp:Label ID="lblLicensee" runat="server" CssClass="report-text"></asp:Label>
                    </div>

                   
                   
                </div>
                <div class="row">
                      <div class="col-md-6">
      <label><b>ผู้ตรวจประเมิน</b></label>
      <table>
          <tbody>
              <% For Each row As DataRow In dtAs.Rows %>
              <tr>
                  <td><% =String.Concat(row("nRow")) %>.<% =String.Concat(row("AssessorName")) %></td>
              </tr>
              <%  Next %>
          </tbody>
      </table>
  </div>
                  
                    <div class="col-md-6">
                           <label><b>
                            มีผู้ปฏิบัติหน้าที่<asp:Label ID="lblPmCount" runat="server" CssClass="report-text"></asp:Label>
                            คน ได้แก่</b></label>
                        <table>
                            <tbody>
                                <% For Each row As DataRow In dtPm.Rows %>
                                <tr>
                                    <td><% =String.Concat(row("nRow")) %>.<% =String.Concat(row("PharmacistName")) %></td>
                                    <td width="100">&nbsp;&nbsp;ภ.<% =String.Concat(row("License")) %></td>
                                    <td>เวลาปฏิบัติการ <% =String.Concat(row("WorkTimeList")) %></td>
                                </tr>
                                <%  Next %>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 pt-2 pb-2">
                        <span class="text-blue text-bold">การตรวจมาตรฐานร้านยาคุณภาพ</span>                         
                    </div>

                    <div class="col-md-12">
                      
                                    <table class="table table-hover table-no-bordered">
                                        <thead>
                                            <tr>
                                                <th class="text-left">หมวด</th>
                                                <th class="text-left">ผลตรวจ</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1.หมวดสถานที่
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblQA1" runat="server"></asp:Label></td>
                                            </tr>

                                            <% If dtQA1.Rows.Count > 0 Then %>
                                            <tr>
                                                <td colspan="2">
                                                    <table class="table table-hover table-bordered">
                                                        <tr>
                                                            <th class="text-red"><i>สิ่งที่ไม่เป็นไปตามมาตรฐาน</i></th>
                                                        </tr>

                                                        <tbody>
                                                            <% For Each row As DataRow In dtQA1.Rows %>
                                                            <tr>
                                                                <td><% =String.Concat(row("nRow")) %>.<% =String.Concat(row("Descriptions")) %></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="7">
                                                                    <table class="table no-border" style="border: 0 !important">
                                                                        <tr>
                                                                            <td width="50%"><% If String.Concat(row("FilePath1")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath1")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td width="50%"><% If String.Concat(row("FilePath2")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath2")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><% If String.Concat(row("FilePath3")) <> "" Then %>

                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath3")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td><% If String.Concat(row("FilePath4")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath4")) %>" width="100%" />
                                                                                <% End If %>      

                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                            <%  Next %>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <% End If %>

                                            <tr>
                                                <td>2.หมวดอุปกรณ์</td>
                                                <td>
                                                    <asp:Label ID="lblQA2" runat="server"></asp:Label>
                                                </td>

                                            </tr>
                                            <% If dtQA2.Rows.Count > 0 Then %>
                                            <tr>
                                                <td colspan="2">
                                                    <table class="table table-hover table-bordered">
                                                        <tr>
                                                             <th class="text-red"><i>สิ่งที่ไม่เป็นไปตามมาตรฐาน</i></th>
                                                        </tr>

                                                        <tbody>
                                                            <% For Each row As DataRow In dtQA2.Rows %>
                                                            <tr>
                                                                <td><% =String.Concat(row("nRow")) %>.<% =String.Concat(row("Descriptions")) %></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="7">
                                                                    <table class="table no-border" style="border: 0 !important">
                                                                        <tr>
                                                                            <td width="50%"><% If String.Concat(row("FilePath1")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath1")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td width="50%"><% If String.Concat(row("FilePath2")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath2")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><% If String.Concat(row("FilePath3")) <> "" Then %>

                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath3")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td><% If String.Concat(row("FilePath4")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath4")) %>" width="100%" />
                                                                                <% End If %>      

                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                            <%  Next %>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <% End If %>
                                            <tr>
                                                <td>3.หมวดบุคลากร</td>
                                                <td>
                                                    <asp:Label ID="lblQA3" runat="server"></asp:Label></td>

                                            </tr>
                                            <% If dtQA3.Rows.Count > 0 Then %>
                                            <tr>
                                                <td colspan="2">
                                                    <table class="table table-hover table-bordered">
                                                        <tr>
                                                            <th class="text-red"><i>สิ่งที่ไม่เป็นไปตามมาตรฐาน</i></th>
                                                        </tr>

                                                        <tbody>
                                                            <% For Each row As DataRow In dtQA3.Rows %>
                                                            <tr>
                                                                <td><% =String.Concat(row("nRow")) %>.<% =String.Concat(row("Descriptions")) %></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="7">
                                                                    <table class="table no-border" style="border: 0 !important">
                                                                        <tr>
                                                                            <td width="50%"><% If String.Concat(row("FilePath1")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath1")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td width="50%"><% If String.Concat(row("FilePath2")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath2")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><% If String.Concat(row("FilePath3")) <> "" Then %>

                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath3")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td><% If String.Concat(row("FilePath4")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath4")) %>" width="100%" />
                                                                                <% End If %>      

                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                            <%  Next %>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <% End If %>
                                            <tr>
                                                <td>4.หมวดการควบคุมคุณภาพยา</td>
                                                <td>
                                                    <asp:Label ID="lblQA4" runat="server"></asp:Label>
                                                </td>

                                            </tr>
                                            <% If dtQA4.Rows.Count > 0 Then %>
                                            <tr>
                                                <td colspan="2">
                                                    <table class="table table-hover table-bordered">
                                                        <tr>
                                                            <th class="text-red"><i>สิ่งที่ไม่เป็นไปตามมาตรฐาน</i></th>
                                                        </tr>

                                                        <tbody>
                                                            <% For Each row As DataRow In dtQA4.Rows %>
                                                            <tr>
                                                                <td><% =String.Concat(row("nRow")) %>.<% =String.Concat(row("Descriptions")) %></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="7">
                                                                    <table class="table no-border" style="border: 0 !important">
                                                                        <tr>
                                                                            <td width="50%"><% If String.Concat(row("FilePath1")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath1")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td width="50%"><% If String.Concat(row("FilePath2")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath2")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><% If String.Concat(row("FilePath3")) <> "" Then %>

                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath3")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td><% If String.Concat(row("FilePath4")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath4")) %>" width="100%" />
                                                                                <% End If %>      

                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                            <%  Next %>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <% End If %>
                                            <tr>
                                                <td>5.หมวดการปฏิบัติตามวิธีปฏิบัติทางเภสัชกรรมชุมชน</td>
                                                <td>
                                                    <asp:Label ID="lblQA5" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <% If dtQA5.Rows.Count > 0 Then %>
                                            <tr>
                                                <td colspan="2">
                                                    <table class="table table-hover table-bordered">
                                                        <tr>
                                                           <th class="text-red"><i>สิ่งที่ไม่เป็นไปตามมาตรฐาน</i></th>
                                                        </tr>

                                                        <tbody>
                                                            <% For Each row As DataRow In dtQA5.Rows %>
                                                            <tr>
                                                                <td><% =String.Concat(row("nRow")) %>.<% =String.Concat(row("Descriptions")) %></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="7">
                                                                    <table class="table no-border" style="border: 0 !important">
                                                                        <tr>
                                                                            <td width="50%"><% If String.Concat(row("FilePath1")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath1")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td width="50%"><% If String.Concat(row("FilePath2")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath2")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><% If String.Concat(row("FilePath3")) <> "" Then %>

                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath3")) %>" width="100%" />
                                                                                <% End If %>

                                                                            </td>
                                                                            <td><% If String.Concat(row("FilePath4")) <> "" Then %>
                                                                                <img src="../imageUploads/POST/<% =String.Concat(row("LocationUID")) %>/<% =String.Concat(row("FilePath4")) %>" width="100%" />
                                                                                <% End If %>      

                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                            <%  Next %>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <% End If %>
                                        </tbody>
                                    </table>

                    </div>                 
                
               <div class="col-md-12">
                        <div class="main-card mb-3 card border border-success">
                            <div class="card-header">
                                 สรุปผลการตรวจ และ ความเห็นของผู้ตรวจเยี่ยม ระบบร้านยาคุณภาพ
                            </div>
                            <div class="card-body mb-0">
                                <div class="col-lg-12">
                                    <table class="table table-no-bordered">
                                        <tr>
                                            <td width="150">สรุปผล</td>
                                            <td colspan="2">
                                                <asp:Label ID="lblQAResult" runat="server" CssClass="text-bold"></asp:Label>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>สิ่งที่ต้องแก้ไข/อื่นๆ</td>
                                            <td colspan="2">
                                                <asp:Label ID="lblQARemark" runat="server"></asp:Label>
                                            </td>
                                        </tr>
 <tr>
                                            <td>
                                                   <asp:DataList ID="dtlImgQAResult" CssClass="table table-hover no-border" RepeatDirection="Horizontal" RepeatColumns="2" runat="server" CellPadding="5" CellSpacing="10" Height="100">
       <ItemTemplate>          
               <asp:Image ID="imgView" runat="server" ImageUrl='<%# "../" & DataBinder.Eval(Container.DataItem, "FilePathView") %>'  Height="300"></asp:Image>                  
       </ItemTemplate>
   </asp:DataList>
                                            </td>
     </tr>
                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="main-card mb-3 card border">
                            <div class="card-header">
                             การดำเนินการ ระบบร้านยาคุณภาพ
                            </div>
                            <div class="card-body">
                                <div class="col-lg-12">
                                    <table class="table table-hover table-no-bordered">                                        
                                        <tbody>
                                            <tr>
                                                <td>วันที่ส่งเรื่องแจ้งร้าน</td>
                                                <td>  <asp:Label ID="lblQAInformDate" runat="server" CssClass="text-bold"></asp:Label>
                                                </td>
                                                <td width="100" class="text-center">
                                                   </td>
                                            </tr>
                                            <tr>
                                                <td>วันที่ร้านแจ้งกลับการแก้ไข</td>
                                                <td><asp:Label ID="lblQAResponseDate" runat="server" CssClass="text-bold"></asp:Label></td>
                                                <td class="text-center">
                                                   
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>ผลการพิจารณาการแก้ไข</td>
                                                <td> <asp:Label ID="lblQAComplete" runat="server" CssClass="text-bold" Font-Size="20px"></asp:Label></td>
                                                <td class="text-center">
                                                   </td>

                                            </tr>
                                            <tr>
                                                <td>ปิดผลการตรวจมาตรฐานร้านยาคุณภาพ</td>
                                                <td><asp:Label ID="lblQACloseDate" runat="server" CssClass="text-bold"></asp:Label></td>
                                                <td class="text-center">                                                    
                                                </td>

                                            </tr>
                                            <tr>
                                                <td colspan="3">โดย...<asp:Label ID="lblQACloseRemark" runat="server" CssClass="text-bold"></asp:Label></td>
                                                
                                              
                                            </tr>                                         
                                        </tbody>
                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>
                 
     
                 
                 

                </div>
           
             <div class="row">
     <div class="col-md-12 pt-2 pb-2">
         <span class="text-success text-bold">การตรวจมาตรฐานบริการ Common illness</span>      

     </div>                
                   <div class="col-md-12">
                         <div class="main-card mb-3 card border">
      <div class="card-header">
      มาตรฐานการบริการ Common illness
      </div>
      <div class="card-body">
          <div class="col-lg-12">
              <table class="table table-hover table-no-bordered">     
                                       <thead>
    <tr>
        <th class="text-left">มาตรฐาน</th>
        <th class="text-left">ผลตรวจ</th>
        <th>Remark</th>
    </tr>
                                       </thead>
                  <tbody>
                      <tr>
                          <td>1.การบริการโดยเภสัชกร</td>
                          <td>
                              <asp:Label ID="lblCI1" runat="server" CssClass="text-bold"></asp:Label>
                          </td>
                          <td><asp:Label ID="lblCI1Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>2.การซักถามอาการ</td>
                          <td>
                              <asp:Label ID="lblCI2" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI2Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>3.การจ่ายยา</td>
                          <td>
                              <asp:Label ID="lblCI3" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI3Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>4.การติดตาม  หลังจ่ายยา ( 72 ชั่วโมง )</td>
                          <td>
                              <asp:Label ID="lblCI4" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI4Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>5.มีการติดตาม  หลังจ่ายยา ( 72 ชั่วโมง )</td>
                          <td>
                              <asp:Label ID="lblCI5" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI5Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>6.ไม่พบการรับยาแทน</td>
                          <td>
                              <asp:Label ID="lblCI6" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI6Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>7.การประชาสัมพันธ์ถูกต้อง</td>
                          <td>
                              <asp:Label ID="lblCI7" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI7Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>8.การเก็บรายงานการให้บริการ</td>
                          <td>
                              <asp:Label ID="lblCI8" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI8Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>9.การจัดทำทะเบียน</td>
                          <td>
                              <asp:Label ID="lblCI9" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI9Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>1.ไม่พบมีการจัดบริการ CI +PP แบบ Package</td>
                          <td>
                              <asp:Label ID="lblCI10" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI10Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>11.มีเอกสารเพื่อการส่งต่อ ( Refer )</td>
                          <td>
                              <asp:Label ID="lblCI11" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI11Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td>12.การให้บริการภายในเวลาที่ระบุใน ขย 5</td>
                          <td>
                              <asp:Label ID="lblCI12" runat="server" CssClass="text-bold"></asp:Label></td>
                          <td><asp:Label ID="lblCI12Remark" runat="server" CssClass="text-bold"></asp:Label></td>
                      </tr>
                      <tr>
                          <td colspan="4">13.อื่นๆ ระบุ...<asp:Label ID="lblCI13" runat="server" CssClass="text-bold"></asp:Label></td>                        
                      </tr>                                         
                  </tbody>
              </table>

          </div>
      </div>
  </div>
                       </div>
            
                 </div>
                <div class="row">
                                   <div class="col-md-12">
    <div class="main-card mb-3 card border border-success">
        <div class="card-header">
            ความพึงพอใจการบริการ Common illness ( ประเมินจากผู้มารับบริการ โดย สอบถามผู้มารอรับบริการ )
        </div>
        <div class="card-body mb-0">
            <div class="col-lg-12">
                <asp:Label ID="lblSatisfaction" runat="server" CssClass="text-bold"></asp:Label>    
                           </div>
        </div>
    </div>
</div>
                      <div class="col-md-12">
           <div class="main-card mb-3 card border border-success">
               <div class="card-header">
                    สรุปผลการตรวจ และ  ความเห็นของผู้ตรวจเยี่ยม มาตรฐานบริการ Common illness
               </div>
               <div class="card-body mb-0">
                   <div class="col-lg-12">
                       <table class="table table-no-bordered">
                           <tr>
                               <td width="150">สรุปผล</td>
                               <td colspan="2">
                                   <asp:Label ID="lblCIResult" runat="server" CssClass="text-bold"></asp:Label>                                                
                               </td>
                           </tr>
                           <tr>
                               <td>สิ่งที่ต้องแก้ไข/อื่นๆ</td>
                               <td colspan="2">
                                   <asp:Label ID="lblCIRemark" runat="server"></asp:Label>
                               </td>
                           </tr>
                            <tr>
                                            <td>
                                                   <asp:DataList ID="dtlImgCIResult" CssClass="table table-hover no-border" RepeatDirection="Horizontal" RepeatColumns="2" runat="server" CellPadding="5" CellSpacing="10" Height="100">
       <ItemTemplate>          
               <asp:Image ID="imgView" runat="server" ImageUrl='<%# "../" & DataBinder.Eval(Container.DataItem, "FilePathView") %>'  Height="300"></asp:Image>                  
       </ItemTemplate>
   </asp:DataList>
                                            </td>
     </tr>
                       </table>

                   </div>
               </div>
           </div>
       </div>
       <div class="col-md-12">
           <div class="main-card mb-3 card border">
               <div class="card-header">
                     การดำเนินการ มาตรฐานบริการ Common illness
               </div>
               <div class="card-body">
                   <div class="col-lg-12">
                       <table class="table table-hover table-no-bordered">                                        
                           <tbody>
                               <tr>
                                   <td>วันที่ส่งเรื่องแจ้งร้าน</td>
                                   <td>  <asp:Label ID="lblCIInformDate" runat="server" CssClass="text-bold"></asp:Label>
                                   </td>
                                   <td width="100" class="text-center">
                                      </td>
                               </tr>
                               <tr>
                                   <td>วันที่ร้านแจ้งกลับการแก้ไข</td>
                                   <td><asp:Label ID="lblCIResponseDate" runat="server" CssClass="text-bold"></asp:Label></td>
                                   <td class="text-center">
                                      
                                   </td>

                               </tr>
                               <tr>
                                   <td>ผลการพิจารณาการแก้ไข</td>
                                   <td> <asp:Label ID="lblCIComplete" runat="server" CssClass="text-bold" Font-Size="20px"></asp:Label></td>
                                   <td class="text-center">
                                      </td>

                               </tr>
                               <tr>
                                   <td>ปิดผลการตรวจมาตรฐานร้านยาคุณภาพ</td>
                                   <td><asp:Label ID="lblCICloseDate" runat="server" CssClass="text-bold"></asp:Label></td>
                                   <td class="text-center">                                                    
                                   </td>

                               </tr>
                               <tr>
                                   <td colspan="3">โดย...<asp:Label ID="lblCICloseRemark" runat="server" CssClass="text-bold"></asp:Label></td>
                                   
                                 
                               </tr>                                         
                           </tbody>
                       </table>

                   </div>
               </div>
           </div>
       </div>
                 
                </div>


                  <div class="row">
   <div class="col-md-12 text-center">
                        <input type="button" value="    Print    " id="cmdPrint" class="btn btn-success" onclick="doprint();" />
                    </div>
                        </div>
            </div>
        </section>
    </form>
</body>
</html>
