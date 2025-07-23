<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportPost.aspx.vb" Inherits="CPAQA.ReportPost" %>
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
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>ปี</label><br />
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>การตรวจมาตรฐาน</label><br />
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="Q">ระบบร้านยาคุณภาพ</asp:ListItem>
                                <asp:ListItem Value="C">บริการ Common illness</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>ภาค</label><br />
                            <asp:DropDownList ID="ddlProvinceGroup" runat="server" CssClass="form-control select2" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>จังหวัด</label><br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>                    
                    <div class="col-md-2">
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
                รายงานการตรวจรักษาคุณภาพ
            <div class="btn-actions-pane-right">
            </div>
            </div>
            <div class="card-body table-responsive">
                <table id="tbdata" class="table table-hover table-bordered">
                            <thead>
                                <tr>     
                                       <th class="text-center">Code</th> 
                                    <th class="text-center">เลข ขย.</th> 
                                     <th class="text-center">ร้านยา</th>
 <th class="text-center">จังหวัด</th>
 <th class="text-center">อำเภอ</th>
 <th class="text-center">วันที่บันทึก</th>
 <th class="text-center">ระบบร้านยาคุณภาพ</th>
 <th class="text-center">Common illness</th>     
                                    <th class="sorting_asc_disabled sorting_desc_disabled text-center">View</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% For Each row As DataRow In dtGPP.Rows %>
                                <tr>
                                    <td class="text-center"><% =String.Concat(row("Code")) %></td>
                                    <td class="text-center"><% =String.Concat(row("LicenseNo")) %></td>
                                    <td><a href="PostAudit?m=po&s=list&lid=<% =String.Concat(row("LocationUID")) %>&id=<% =String.Concat(row("PostUID")) %>"><% =String.Concat(row("LocationName")) %> </a></td> 
                                    <td class="text-center"><% =String.Concat(row("ProvinceName")) %> </td>
                                    <td class="text-center"><% =String.Concat(row("DistrictName")) %> </td>
                                    <td class="text-center"><% =String.Concat(row("AsmDate")) %></td>
                                    <td class="text-center"><% =String.Concat(row("QACompleteTXT")) %></td>
                                    <td class="text-center"><% =String.Concat(row("CICompleteTXT")) %></td>
                                    <td width="100" class="text-center">
                                        <a href="Reports/ReportPostView?m=po&s=rpa&id=<% =String.Concat(row("PostUID")) %>" target="_blank" class="btn btn-info" data-toggle="tooltip" data-placement="top" data-original-title="พิมพ์/ดูแบบละเอียด"><i class="fa fa-desktop" aria-hidden="true"></i></a>
                                    </td>
                                </tr>
                                <%  Next %>
                            </tbody>
                        </table>
            </div>
        </div>   
           
    </section>
</asp:Content>
