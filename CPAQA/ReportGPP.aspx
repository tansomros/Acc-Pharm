<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportGPP.aspx.vb" Inherits="CPAQA.ReportGPP" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="lnr-pie-chart icon-gradient bg-primary"></i>
                </div>
                <div>
                    <asp:Label ID="lblReportTitle" runat="server" Text="รายงานสรุปผลการประเมิน GPP"></asp:Label>
                    <div class="page-title-subheading"></div>
                </div>
            </div>
        </div>
    </div>

    <section class="content">

        <div class="box box-solid">
            <div class="box-body" style="background-color: #14539a; color: white">
                <div class="row">           
                    <div class="col-lg-3 col-md-6 col-xs-12">
                        <div class="form-group">
                            <label>ปี</label><br />
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>                  
                    <div class="col-lg-3 col-md-6 col-xs-12">
                        <div class="form-group">
                            <label>ภาค</label><br />
                            <asp:DropDownList ID="ddlProvinceGroup" runat="server" CssClass="form-control select2" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-xs-12">
                        <div class="form-group">
                            <label>จังหวัด</label><br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>                    
                    <div class="col-lg-3 col-md-6 col-xs-12">
                        <div class="form-group">
                            <label>คำค้นหา</label><br />
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="ชื่อร้าน / เลข ขย.5 /เลขที่ใบอนุญาต"></asp:TextBox>
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

          
        <div id="pnView" runat="server" class="main-card mb-3 card">
            <div class="card-header">
                รายการคะแนนประเมิน GPP
            <div class="btn-actions-pane-right">
            </div>
            </div>
            <div class="card-body table-responsive">
                <table id="tbdata" class="table table-hover table-bordered">
                            <thead>
                                <tr>                                    
                                    <th class="text-center">No.</th>
                                    <th class="text-center">เลขที่ใบอนุญาต ขย.5</th>
                                    <th class="text-center">ชื่อร้านยา</th>
                                    <th class="text-center">สถานที่ตั้ง</th>
                                    <th class="text-center">ปี</th>
                                    <th class="text-center">วันที่</th>
                                    <th class="text-center">คะแนนรวม</th>
                                    <th class="text-center">คะแนนที่ได้</th>
                                    <th class="text-center">คิดเป็น(%)</th>                                    
                                    <th class="text-center">สรุปผล</th>
                                    <th class="text-center">Remark</th>     
                                    <th class="sorting_asc_disabled sorting_desc_disabled text-center"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <% For Each row As DataRow In dtGPP.Rows %>
                                <tr>                                    
                                    <td class="text-center"><% =String.Concat(row("nRow")) %></td>
                                    <td><% =String.Concat(row("LicenseNo")) %></td>
                                    <td><% =String.Concat(row("LocationName")) %></td>
                                    <td><% =String.Concat(row("LocationAddress")) %></td>
                                    <td><% =String.Concat(row("GPPYear")) %></td>
                                    <td class="text-center"><% =String.Concat(row("AsmDate")) %></td>                            
                                    <td class="text-center"><% =String.Concat(row("TotalScore")) %></td>
                                    <td class="text-center"><% =String.Concat(row("FinalScore")) %></td>
                                    <td class="text-center"><% =String.Concat(row("PercentageScore")) %></td>                                   
                                    <td class="text-center"><% =IIf(String.Concat(row("FinalResult")) = "Y", "<div class='badge badge-success'>ผ่าน</div>", "<div class='badge badge-danger'>ไม่ผ่าน</div>") %></td>
                                    <td class="text-center"><% =String.Concat(row("Remark")) %></td>     
                                    <td width="100" class="text-center">
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
