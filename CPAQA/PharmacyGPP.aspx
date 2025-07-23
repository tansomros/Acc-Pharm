<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PharmacyGPP.aspx.vb" Inherits="CPAQA.PharmacyGPP" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="lnr-spell-check icon-gradient bg-primary"></i>
                </div>
                <div>
                    รายการประเมิน GPP
                            <div class="page-title-subheading">สำหรับ สสจ.</div>
                </div>
            </div>
        </div>
    </div>

    <section class="content">
        <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon lnr-store icon-gradient bg-primary"></i>ข้อมูลร้านยา
      
                <div class="btn-actions-pane-right actions-icon-btn">
    <asp:HyperLink ID="lnkFDA" runat="server" Target="_blank" CssClass="btn btn-primary small"><img src="images/fdalogo.png" width="20" /> คลิกดูข้อมูลใบอนุญาตจาก อย.</asp:HyperLink> 
 
</div>
            </div>
            <div class="card-body table-responsive">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>ชื่อร้านยา</label>
                            <asp:Label ID="lblLocationName" runat="server" CssClass="text-blue text-bold"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>เลขที่ใบอนุญาต ขย.</label>
                            <asp:Label ID="lblLicenseNo" runat="server" CssClass="text-bold"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-9">
                        <div class="form-group">
                            <label>สถานที่ตั้งเลขที่</label>
                            <asp:Label ID="lblAddress" runat="server" CssClass="text-bold"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>เบอร์โทร</label>
                            <asp:Label ID="lblTel" runat="server" CssClass="text-bold"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>ชื่อผู้ดำเนินกิจการ</label>
                            <asp:Label ID="lblLicensee" runat="server" CssClass="text-bold"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="form-group">
                            <label>สถานะใบอนุญาต</label>
                            <asp:Label ID="lblLicenseStatus" runat="server" CssClass="text-bold"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>วันที่อนุญาต</label>
                            <asp:Label ID="lblStartDate" runat="server" CssClass="text-bold"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>วันที่หมดอายุ</label>
                            <asp:Label ID="lblExpireDate" runat="server" CssClass="text-bold"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon lnr-spell-check icon-gradient bg-primary"></i>รายการร้านยาสำหรับ สสจ. ตรวจ GPP
            <div class="btn-actions-pane-right">
                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 Then%>
                <asp:LinkButton ID="lnkAddNew" runat="server" cssclass="btn btn-primary pull-right"><i class="fa fa-plus-circle"></i>ประเมินใหม่</asp:LinkButton>
                <% End If %>
            </div>
            </div>
            <div class="card-body table-responsive">
                <table id="tbdata" class="table table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center" aria-sort="descending">ปี</th>
                            <th class="text-center">วันที่ประเมิน</th>
                            <th class="text-center">คะแนน</th>
                            <th class="text-center">คิดเป็น %</th>
                            <th class="text-center">สรุป</th>
                            <th class="text-center">ที่มา</th>
                            <th class="text-center">หมายเหตุ</th>
                            <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) > 3 Then%>
                            <th class="sorting_asc_disabled sorting_desc_disabled text-center"></th>
                            <% End If %>
                        </tr>
                    </thead>
                    <tbody>
                        <% For Each row As DataRow In dtGPP.Rows %>
                        <tr>
                            <td class="text-center"><% =String.Concat(row("AsmYear")) %></td>
                            <td class="text-center"><% =BigLion.ConvertDateToString(row("AsmDate")) %></td>
                            <td class="text-center"><% =String.Concat(row("FinalScore")) %></td>
                            <td class="text-center"><% =String.Concat(row("PercentageScore")) %></td>
                            <td class="text-center"><% =String.Concat(row("AsmResult")) %> </td>
                            <td class="text-center"><% =String.Concat(row("AsmBy")) %></td>
                            <td><% =String.Concat(row("Remark")) %></td>
                            <td width="180" class="text-center">
                               <% If String.Concat(row("AsmBy")) = "สสจ." Then %>
                                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) > 3 And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) < 6 Then %>
                                <% If String.Concat(row("CloseStatus")) = "Y" Or row("RequestUID") > 0 Then %>
                                <a href="AsmGPP?m=g&y=<% =String.Concat(row("AsmYear")) %>&id=<% =String.Concat(row("UID")) %>" class="btn btn-primary" data-toggle="tooltip" data-placement="top" data-original-title="ดูรายละเอียด"><i class="fa fa-search" aria-hidden="true"></i></a>
                                <% Else %>
                                <a href="AsmGPP?m=g&y=<% =String.Concat(row("AsmYear")) %>&id=<% =String.Concat(row("UID")) %>" class="btn btn-success" data-toggle="tooltip" data-placement="top" data-original-title="แก้ไข"><i class="fa fa-edit" aria-hidden="true"></i></a>
                                <% End If %> 
                                <% End If %>
                               <% End If %>
                                <a href="Reports/ReportGPP?m=g&id=<% =String.Concat(row("UID")) %>" target="_blank" class="btn btn-info" data-toggle="tooltip" data-placement="top" data-original-title="ดูแบบละเอียด"><i class="fa fa-desktop" aria-hidden="true"></i></a>
                                <a href="ReportViewer?R=gpnt&RPTTYPE=PDF&id=<% =String.Concat(row("UID")) %>&lid=<% =String.Concat(row("LocationUID")) %>" target="_blank" class="btn btn-alternate" data-toggle="tooltip" data-placement="top" data-original-title="พิมพ์"><i class="lnr-printer" style="font-size:16px" aria-hidden="true"></i></a>
                                                      
                            </td>
                        </tr>
                        <%  Next %>
                    </tbody>
                </table>
            </div>

        </div>


    </section>
</asp:Content>
