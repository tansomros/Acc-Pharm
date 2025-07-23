<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportRisk.aspx.vb" Inherits="CPAQA.ReportRisk" %>

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
                    <asp:Label ID="lblReportTitle" runat="server" Text="รายงานการเฝ้าระวัง/ความเสี่ยง"></asp:Label>
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
                            <label>ปี</label>
                            <br />
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control select2" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>ความเสี่ยง</label>
                            <br />
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2" Width="100%">
                                <asp:ListItem Text="ทั้งหมด" Value="9" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="ไม่เสี่ยง" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                
                    <div class="col-lg-6 col-md-4 col-xl-8 pt-2">
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
                            <th class="text-center">No.</th>
                            <th class="text-center">เลขที่ ขย.5</th>
                            <th class="text-center">ชื่อร้านยา</th>
                            <th class="text-center">สถานที่ตั้ง</th>
                            <th class="text-center">จังหวัด</th>
                            <th class="text-center">วันที่</th>
                            <th class="text-center">ความเสี่ยง</th>
                            <th class="text-center">รายละเอียดการเฝ้าระวัง/ความเสี่ยง</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% For Each row As DataRow In dtR.Rows %>
                        <tr>
                            <td class="text-center"><% =String.Concat(row("nRow")) %></td>
                            <td><% =String.Concat(row("LicenseNo1")) %></td>
                            <td><% =String.Concat(row("LocationName")) %></td>
                            <td><% =String.Concat(row("LocationAddress")) %></td>
                            <td class="text-center"><% =String.Concat(row("ProvinceName")) %></td>
                            <td class="text-center"><% =String.Concat(row("RiskDate")) %></td>
                            <td class="text-center"><% =String.Concat(row("LevelName")) %></td>                         
                            <td><% =String.Concat(row("Descriptions")) %></td>
                        </tr>
                        <%  Next %>
                    </tbody>
                </table>
            </div>
        </div>

    </section>
</asp:Content>
