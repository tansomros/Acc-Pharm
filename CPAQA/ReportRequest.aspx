<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportRequest.aspx.vb" Inherits="CPAQA.ReportRequest" %>

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
                    <div class="col-lg-6 col-md-4 col-xl-4">
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
                    <div class="col-lg-6 col-md-4 col-xl-4">
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
                    <% If Request("s") = "R1" Then %>
                    <div class="col-lg-6 col-md-4 col-xl-4">
                        <div class="form-group">
                            <label>สถานะ</label>
                            <br />
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <% End If %>
                    <% If Request("s") = "R2" Then %>

                    <div class="col-lg-6 col-md-4 col-xl-4">
                        <div class="form-group">
                            <label>ประเภท</label>
                            <br />
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <% End If %>
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
                                    <th class="text-left">ผู้ตรวจประเมิน</th> 
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
                                    <td><% =String.Concat(row("SupervisorName")) %></td>
                                </tr>
                                <%  Next %>
                            </tbody>
                        </table>
                    </div>
                </div>
         
    </section>
</asp:Content>
