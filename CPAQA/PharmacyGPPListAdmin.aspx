<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PharmacyGPPListAdmin.aspx.vb" Inherits="CPAQA.PharmacyGPPListAdmin" %>

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
                <i class="header-icon lnr-magnifier icon-gradient bg-secondary"></i>ค้นหา      
                <div class="btn-actions-pane-right actions-icon-btn"></div>
            </div>
            <div class="card-body table-responsive">
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>ปี</label>
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" CssClass="form-control select2"></asp:DropDownList> 
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>จังหวัด</label>
                             <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="true" CssClass="form-control select2"></asp:DropDownList> 
                        </div>
                    </div>
                     <div class="col-md-2 pt-4">
                        <div class="form-group">
                            <label></label>
                                <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-warning" Width="100px"><i class="fa fa-search"></i>ค้นหา</asp:LinkButton>
                        </div>
                    </div>
                </div> 
            </div>
        </div>

        <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon lnr-spell-check icon-gradient bg-primary"></i>รายการการตรวจประเมิน
            <div class="btn-actions-pane-right">
               
            </div>
            </div>
            <div class="card-body table-responsive">
                <table id="tbdata" class="table table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center" aria-sort="descending">ปี</th>
                          
                             <th class="text-center">ขย.5</th>
                             <th class="text-center">ชื่อร้านยา</th>
                             <th class="text-center">จังหวัด</th>
                              <th class="text-center">วันที่ประเมิน</th>
                            <th class="text-center">คะแนน</th>
                            <th class="text-center">คิดเป็น %</th>
                            <th class="text-center">สรุป</th>
                            <th class="text-center">ที่มา</th>
                            <th class="text-center">หมายเหตุ</th>
                            <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 5 Then%>
                            <th class="sorting_asc_disabled sorting_desc_disabled text-center"></th>
                            <% End If %>
                        </tr>
                    </thead>
                    <tbody>
                        <% For Each row As DataRow In dtGPP.Rows %>
                        <tr>
                            <td class="text-center"><% =String.Concat(row("AsmYear")) %></td>
                        
                             <td class="text-center"><% =String.Concat(row("LicenseNo")) %></td>
                             <td><% =String.Concat(row("LocationName")) %></td>
                             <td class="text-center"><% =String.Concat(row("ProvinceName")) %></td>
                                <td class="text-center"><% =BigLion.ConvertDateToString(row("AsmDate")) %></td>
                            <td class="text-center"><% =String.Concat(row("FinalScore")) %></td>
                            <td class="text-center"><% =String.Concat(row("PercentageScore")) %></td>
                            <td class="text-center"><% =String.Concat(row("AsmResult")) %> </td>
                            <td class="text-center"><% =String.Concat(row("AsmBy")) %></td>
                            <td><% =String.Concat(row("Remark")) %></td>
                            <td width="180" class="text-center">                                                     
                                <a href="AsmGPP?m=g&y=<% =String.Concat(row("AsmYear")) %>&id=<% =String.Concat(row("UID")) %>" class="btn btn-primary" data-toggle="tooltip" data-placement="top" data-original-title="ดูรายละเอียด"><i class="fa fa-search" aria-hidden="true"></i></a>       

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
