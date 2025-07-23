<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportGPP.aspx.vb" Inherits="CPAQA.ReportGPP1" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Good Pharmacy Practives</title>
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
                <span class="report-header-title">บันทึกการประเมินวิธีปฏิบัติทางเภสัชกรรมชุมชน
             <br />
                    ในสถานที่ขายยาแผนปัจจุบัน </span>
                <span class="report-header-subtitle">
                    <br />
                    ตามประกาศกระทรวงสาธารณสุขเรื่องการกำหนดเกี่ยวกับสถานที่ อุปกรณ์
             <br />
                    และวิธีปฏิบัติทางเภสัชกรรมชุมชน ในสถานที่ขายยาแผนปัจจุบัน
             <br />
                    ตามกฎหมายว่าด้วยยา พ.ศ.๒๕๕๗
                </span>
            </div>
            <div class="report-body">
                <div class="row">
                    <div class="col-md-6">
                        <label><b>วันที่ตรวจประเมิน</b></label>
                        <asp:Label ID="lblDate" runat="server" CssClass="report-text"></asp:Label>
                    </div>
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
                        <label><b>ชื่อร้านยา</b></label>
                        <asp:Label ID="lblLocationName" runat="server" CssClass="text-blue text-bold report-text"></asp:Label>
                    </div>
                       <div class="col-md-6">
                        <label><b>เลขที่ใบอนุญาต</b></label>
                        <asp:Label ID="lblLicenseNo" runat="server" CssClass="text-blue text-bold report-text"></asp:Label>

                    </div>
                    <div class="col-md-12">
                        <label><b>ผู้รับอนุญาต</b></label>
                        <asp:Label ID="lblLicensee" runat="server" CssClass="report-text"></asp:Label>
                    </div>
                    <div class="col-md-12">
                        <label><b>ที่อยู่</b></label>
                        <asp:Label ID="lblAddress" runat="server" CssClass="report-text"></asp:Label>
                    </div>
                    <div class="col-md-12">
                        <label><b>โทรศัพท์</b></label>
                        <asp:Label ID="lblTel" runat="server" CssClass="report-text"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 text-bold">
                        <label>มีผู้ปฏิบัติหน้าที่<asp:Label ID="lblPmCount" runat="server" CssClass="report-text"></asp:Label>
                            คน ได้แก่</label>
                    </div>
                    <div class="col-md-12">
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

                    <div class="col-md-12">
                        <table class="table table-hover table-bordered">
                            <tr>
                                <th class="text-center">ข้อกำหนดตามประกาศฯ เรื่อง การกำหนดเกี่ยวกับสถานที่ อุปกรณ์ และวิธีปฏิบัติทางเภสัชกรรมชุมชน ในร้านขายยาแผนปัจจุบัน</th>
                                <th class="text-left">ปรับปรุง (0)</th>
                                <th class="text-center">พอใช้ (1)</th>

                                <th class="text-center">ดี (2)</th>
                                <th class="text-center">ไม่ตรวจ</th>
                                <th class="text-center">ค่าถ่วงน้ำหนัก</th>
                                <th class="text-center">คะแนนที่ได้</th>

                            </tr>

                            <tbody>
                                <% For Each row As DataRow In dtGPP.Rows %>
                                <tr>
                                    <td <% If String.Concat(row("IsCritical")) = "Y" Then %>class="text-red"<% End If %>>
                                        <% =String.Concat(row("Code")) %>.<% =String.Concat(row("Descriptions")) %></td>                                   
                                    <td class="text-center"><% If String.Concat(row("Score")) = "0" Then %><i class="material-icons check">&#xe5ca;</i><% End If %></td>
                                    <td class="text-center"><% If String.Concat(row("Score")) = "1" Then %><i class="material-icons check_circle">&#xe5ca;</i><% End If %></td>
                                    <td class="text-center"><% If String.Concat(row("Score")) = "2" Then %><i class="material-icons check_circle">&#xe5ca;</i><% End If %></td>
                                    <td class="text-center"><% If String.Concat(row("Score")) < 0 Then %><i class="material-icons check_circle">&#xe5ca;</i><% End If %></td>
                                    <td class="text-center"><% =String.Concat(row("WScore")) %></td>
                                    <td class="text-center"><% =String.Concat(row("NetScore")) %></td>
                                </tr>
                                  <tr>
                                    <td colspan="7">
                                       <b>Remark :</b> <% =String.Concat(row("Remark")) %>
                                        </td>
                                      </tr>
                                <tr>
                                    <td colspan="7">
                                        <table class="table-no-bordered" style="border:0 !important">
                                            <tr>
                                                <td width="50%">  <% If String.Concat(row("Image1")) <> "" Then %>
                                        <img src="../imageUploads/<% =String.Concat(row("LocationUID")) %>/GPP/<% =String.Concat(row("Image1")) %>" width="100%" />
                                                    <% End If %>

                                                </td>
                                                <td width="50%">  <% If String.Concat(row("Image2")) <> "" Then %>
                                          <img src="../imageUploads/<% =String.Concat(row("LocationUID")) %>/GPP/<% =String.Concat(row("Image2")) %>" width="100%"/>
                                                    <% End If %>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>  <% If String.Concat(row("Image3")) <> "" Then %>   
                                     
                                        <img src="../imageUploads/<% =String.Concat(row("LocationUID")) %>/GPP/<% =String.Concat(row("Image3")) %>" width="100%" />
                                                    <% End If %>

                                                </td>
                                                <td> <% If String.Concat(row("Image4")) <> "" Then %>
                                           <img src="../imageUploads/<% =String.Concat(row("LocationUID")) %>/GPP/<% =String.Concat(row("Image4")) %>" width="100%" />
                                                    <% End If %>      

                                                </td>
                                            </tr>
                                        </table>     
                                                                           
                                    </td>
                                </tr>
                                <%  Next %>
                            </tbody>
                        </table>
                    </div>
                     <div class="col-md-12">
        <div class="main-card mb-3 card border">
                            <div class="card-header">
                                สรุปความคิดเห็น
                            </div>
                            <div class="card-body">
                                <div class="col-lg-12">
                                    <table class="table table-hover table-no-bordered">
                                         <thead>
                        <tr>
                            <th class="text-left">หมวดที่</th>
                            <th class="text-left">รายละเอียด</th>
                            <th>ความคิดเห็น</th>   
                        </tr>
                    </thead>
                                        <tbody>
                                        <tr>
                                            <td width="100">หมวดที่ 1</td>
                                            <td width="200">
                                               สถานที่
                                            </td>
                                            <td> 
                                                <asp:Label ID="lblRemark1" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>หมวดที่ 2</td>
                                            <td>อุปกรณ์</td>
                                            <td>
                                                <asp:Label ID="lblRemark2" runat="server"></asp:Label>
                                            </td>
                                           
                                        </tr>                                      
                                         <tr>
                                            <td>หมวดที่ 3</td> 
                                             <td>บุคลากร</td>
                                            <td>
                                                <asp:Label ID="lblRemark3" runat="server"></asp:Label></td>
                                          
                                        </tr>   
                                        <tr>
                                            <td>หมวดที่ 4</td>
                                            <td>การควบคุมคุณภาพยา</td>
                                            <td>
                                               <asp:Label ID="lblRemark4" runat="server"></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>หมวดที่ 5</td>
                                            <td>การปฏิบัติตามวิธีปฏิบัติทางเภสัชกรรมชุมชน</td>
                                             <td>
                                               <asp:Label ID="lblRemark5" runat="server"></asp:Label>
                                            </td>
                                        </tr>                                        
                                            </tbody>
                                    </table>

                                </div>
                            </div>
                        </div>
                           </div>

                       <div class="col-md-12">
      
                                            <asp:GridView ID="grdDocument" CssClass="table table-hover"
                                                runat="server" CellPadding="0"
                                                GridLines="None"
                                                AutoGenerateColumns="False" Width="100%">

                                                <Columns>
                                                    <asp:BoundField DataField="nRow" HeaderText="No.">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" Width="30px" />

                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="ชื่อเอกสาร">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "~/imageUploads/" & DataBinder.Eval(Container.DataItem, "LocationUID") & "/GPP/" & DataBinder.Eval(Container.DataItem, "FilePath") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Descriptions") %>'></asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle HorizontalAlign="Center"
                                                    CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle CssClass="th" Font-Bold="True"
                                                    VerticalAlign="Middle" HorizontalAlign="Left" />
                                            </asp:GridView>
                           </div>
  <div class="col-md-12">
        <div class="main-card mb-3 card border">
                            <div class="card-header">
                                สรุปคะแนนประเมิน
                            </div>
                            <div class="card-body">
                                <div class="col-lg-12">
                                    <table class="table table-hover table-no-bordered">
                                         <thead>
                        <tr>
                            <th class="text-left">หมวดที่</th>
                            <th class="text-left">รายละเอียด</th>
                            <th class="text-center">ร้อยละ</th>   
                        </tr>
                    </thead>
                                        <tbody>
                                        <tr>
                                            <td width="100">หมวดที่ 1</td>
                                            <td>
                                               สถานที่
                                            </td>
                                            <td width="100" class="text-center"> 
                                                <asp:Label ID="lblPercentGroup1" runat="server" CssClass="text-bold"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>หมวดที่ 2</td>
                                            <td>อุปกรณ์</td>
                                            <td class="text-center">
                                                <asp:Label ID="lblPercentGroup2" runat="server" CssClass="text-bold"></asp:Label>
                                            </td>
                                           
                                        </tr>                                      
                                         <tr>
                                            <td>หมวดที่ 3</td> 
                                             <td>บุคลากร</td>
                                            <td class="text-center">
                                                <asp:Label ID="lblPercentGroup3" runat="server" CssClass="text-bold"></asp:Label></td>
                                          
                                        </tr>   
                                        <tr>
                                            <td>หมวดที่ 4</td>
                                            <td>การควบคุมคุณภาพยา</td>
                                            <td class="text-center">
                                               <asp:Label ID="lblPercentGroup4" runat="server" CssClass="text-bold"></asp:Label>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>หมวดที่ 5</td>
                                            <td>การปฏิบัติตามวิธีปฏิบัติทางเภสัชกรรมชุมชน</td>
                                             <td class="text-center">
                                               <asp:Label ID="lblPercentGroup5" runat="server" CssClass="text-bold"></asp:Label>
                                            </td>
                                        </tr>
                                             <tr>                                         
                                            <td colspan="2" class="text-right">ร้อยละเฉลี่ย</td>
                                            <td class="text-center"><asp:Label ID="lblPercentage" runat="server" CssClass="text-center text-bold text-blue" Font-Size="16px"></asp:Label></td>
                                        </tr>
                                            </tbody>
                                    </table>

                                </div>
                            </div>
                        </div>
                           </div>
  <div class="col-md-12">
                     <div class="main-card mb-3 card border border-success">
                            <div class="card-header">
                                สรุปผลการประเมิน
                            </div>
                            <div class="card-body mb-0">
                                <div class="col-lg-12">
                                    <table class="table table-no-bordered">                                       
                                        <tr>
                                            <td width="100">สรุปผล</td>
                                            <td colspan="2">
                                               <asp:Label ID="lblResult" runat="server" CssClass="text-bold" Font-Size="20px"></asp:Label> &nbsp; <asp:Label ID="lblResultRemark" runat="server" CssClass="text-bold text-red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ความคิดเห็น</td>
                                            <td colspan="2">
                                                <asp:label ID="lblRemark" runat="server"></asp:label>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </div>
        </div>
  <div class="col-md-12 text-center">
                    <input  type="button" value="    Print    " id="cmdPrint" class="btn btn-success" onclick="doprint();" />
      </div>

                </div>
            </div>
        </section>
    </form>
</body>
</html>
