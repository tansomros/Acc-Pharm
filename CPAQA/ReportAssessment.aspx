<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportAssessment.aspx.vb" Inherits="CPAQA.ReportAssessment" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-monitor icon-gradient bg-primary"></i>
                </div>
                <div>
                    <asp:Label ID="lblReportTitle" runat="server" Text="รายงานคำขอ"></asp:Label>
                    <div class="page-title-subheading">ระบบประเมินร้านยาคุณภาพ</div>
                </div>
            </div>
        </div>
    </div>

    <section class="content">
        <div class="box box-solid">
            <div class="box-body" style="background-color: #14539a; color: white">
                <div class="row">
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>Start Date</label>
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control text-center"
                                    autocomplete="off" data-date-format="dd/mm/yyyy"
                                    data-date-language="th-th" data-provide="datepicker"
                                    onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>End Date</label>
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control text-center"
                                    autocomplete="off" data-date-format="dd/mm/yyyy"
                                    data-date-language="th-th" data-provide="datepicker"
                                    onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                </div>
                            </div>
                        </div>

                    </div> 
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>ประเภท</label>
                            <br />
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>สถานะ</label>
                            <br />
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-6 col-xl-4">
                        <div class="form-group">
                            <label>ร้านยา</label>
                            <br />
                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control select2" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>
                  
                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                        <br />
                        <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-info" Width="120px"><i class="fa fa-desktop"></i>ดูรายงาน</asp:LinkButton>
                        <asp:LinkButton ID="cmdExport" runat="server" CssClass="btn btn-success" Width="120px"><i class="fa fa-file-excel"></i>Export</asp:LinkButton>

                    </div>
                </div>
            </div>
        </div>   
  
                <div id="pnData" runat="server" class="main-card mb-3 card">
                    <div class="card-header">
                        รายการคำขอที่พบตามเงื่อนไข
            <div class="btn-actions-pane-right">
            </div>
                    </div>
                    <div class="card-body table-responsive">
                        <table id="tbdata" class="table table-hover table-bordered">
                            <thead>
                                <tr> 
                                    <th class="text-center">เลขที่คำขอ</th>
                                    <th class="text-center">เลขที่ใบอนุญาต ขย.5</th>
                                    <th class="text-center">ชื่อร้านยา</th>
                                    <th class="text-center">สถานที่ตั้ง</th>
                                    <th class="text-center">ประเภท</th>
                                    <th class="text-center">วันที่ยื่นขอ</th>
                                    <th class="text-center">สถานะ</th>
                                <% If Request("s") = "A1" Then %>
                                    <th class="text-center">คะแนน GPP</th>
                                    <th class="text-center">GPP(%)</th>
                                    <th class="text-center">สรุป GPP</th>
                                    <th class="text-center">QA3.1</th>
                                    <th class="text-center">QA3.2</th>
                                    <th class="text-center">QA3.3</th>
                                    <th class="text-center">QA Total</th>
                                    <th class="text-center">QA(%)</th>
                                    <th class="text-center">สรุป QA</th>
                                    <th class="text-center">คะแนนรวม</th>
                                        <% End If %>
<% If Request("s") = "A2" Then %>
                                    <th class="text-center">สิ่งที่ต้องปรับปรุง แก้ไข</th>
                                    <th class="text-center">ข้อเสนอแนะเพื่อการพัฒนา</th>
                                    <th class="text-center">สิ่งที่ทำได้ดีเกินมาตรฐาน</th>
                                    <th class="text-center">การสอบถาม สสจ.ในพื้นที่ (บางกรณี)</th>
                                    <th class="text-center">งานที่ดีเด่นของร้าน</th>
                                    <th class="text-center">S</th>
                                    <th class="text-center">W</th>
                                    <th class="text-center">O</th>
                                    <th class="text-center">T</th>
                                <% End If %>
                                </tr>
                            </thead>
                            <tbody>
                                <% For Each row As DataRow In dtR.Rows %>
                                <tr>
                                    <td class="text-center"><% =String.Concat(row("Code")) %></td>
                                    <td><% =String.Concat(row("LicenseNo1")) %></td>
                                    <td><% =String.Concat(row("LocationName")) %></td>
                                    <td><% =String.Concat(row("LocationAddress")) %></td>
                                    <td><% =String.Concat(row("RequestTypeName")) %></td>
                                    <td class="text-center"><% =String.Concat(row("RequestDate")) %></td>
                                    <td><% =String.Concat(row("AsmStatusName")) %></td>
                               <% If Request("s") = "A1" Then %>
                                    <td class="text-center"><% =String.Concat(row("GPP_Score")) %></td>
                                    <td class="text-center"><% =String.Concat(row("GPP_Percentage")) %></td>
                                    <td class="text-center"><% =IIf(String.Concat(row("GPPStatus")) = "Y", "ผ่าน", "") %></td>
                                    <td class="text-center"><% =String.Concat(row("QA_Score1")) %></td>
                                    <td class="text-center"><% =String.Concat(row("QA_Score2")) %></td>
                                    <td class="text-center"><% =String.Concat(row("QA_Score3")) %></td>
                                    <td class="text-center"><% =String.Concat(row("QA_Score")) %></td>
                                    <td class="text-center"><% =String.Concat(row("QA_Percentage")) %></td>
                                    <td class="text-center"><% =IIf(String.Concat(row("QAStatus")) = "Y", "ผ่าน", "") %></td>                                    
                                    <td class="text-center"><% =BigLion.StrNull2Double(String.Concat(row("GPP_Score"))) + BigLion.StrNull2Double(String.Concat(row("QA_Score"))) %></td>
                                        <% End If %>
                                <% If Request("s") = "A2" Then %>
                                    <td><% =String.Concat(row("AuditorComment1")) %></td>
                                    <td><% =String.Concat(row("AuditorComment2")) %></td>
                                    <td><% =String.Concat(row("AuditorComment3")) %></td>
                                    <td><% =String.Concat(row("AuditorComment4")) %></td>
                                    <td><% =String.Concat(row("AuditorComment5")) %></td>
                                    <td><% =String.Concat(row("S")) %></td>
                                    <td><% =String.Concat(row("W")) %></td>
                                    <td><% =String.Concat(row("O")) %></td>
                                    <td><% =String.Concat(row("T")) %></td>
                                <% End If %>
                                </tr>
                                <%  Next %>
                            </tbody>
                        </table>
                    </div>
                </div>
          
    </section>
</asp:Content>
