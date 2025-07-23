<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportCompany.aspx.vb" Inherits="CPAQA.ReportCompany" %>
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
                    <asp:Label ID="lblReportTitle" runat="server" Text="รายงานร้านยา"></asp:Label>
                    <div class="page-title-subheading">ระบบประเมินร้านยาคุณภาพ</div>
                </div>
            </div>
        </div>
    </div>

    <section class="content">

        <div class="box box-solid">
            <div class="box-body" style="background-color: #14539a; color: white">
                <div class="row">
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>กลุ่มร้านยา</label><br />
                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control select2" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>Chain/สาขา</label><br />
                            <asp:DropDownList ID="ddlChain" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>ประเภท</label><br />
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>เขต สปสช.</label><br />
                            <asp:DropDownList ID="ddlNHSO" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>ภาค</label><br />
                            <asp:DropDownList ID="ddlProvinceGroup" runat="server" CssClass="form-control select2" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>จังหวัด</label><br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>ร้านยาคุณภาพ</label><br />
                            <asp:DropDownList ID="ddlAccPharm" runat="server" CssClass="form-control select2">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="Y">ร้านยาคุณภาพ</asp:ListItem>
                                <asp:ListItem Value="N">ไม่ใช่ร้านยาคุณภาพ</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>สถานะใบรับรอง</label><br />
                            <asp:DropDownList ID="ddlAccStatus" runat="server" CssClass="form-control select2">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="A">ปกติ</asp:ListItem>
                                <asp:ListItem Value="E">หมดอายุการรับรอง</asp:ListItem>
                                <asp:ListItem Value="X">ยกเลิกการรับรอง</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-xl-12">
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

       
        <div id="pnData" runat="server" class="main-card mb-3 card">
            <div class="card-header">
                รายการร้านยาที่พบตามเงื่อนไข
            <div class="btn-actions-pane-right">
            </div>
            </div>
            <div class="card-body table-responsive">
                <table id="tbdata" class="table table-hover table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center">เลขที่ใบอนุญาต ขย.5</th>
                            <th class="text-center">เลขที่ใบรับรองร้านยาคุณภาพ</th>
                            <th class="text-left">ชื่อร้านยา</th>
                            <th class="text-center">รหัสหน่วยบริการ</th>
                            <th class="text-center">กลุ่ม</th>
                            <th class="text-center">Chain/สาขา</th>
                            <th class="text-center">เขต สปสช.</th>
                            <th class="text-center">ภาค</th>
                            <th class="text-center">จังหวัด</th>
                            <th class="text-center">เป็นร้านยาคุณภาพ</th>
                            <th class="text-center">สถานะใบรับรอง</th>
                            <th class="text-center">วันที่หมดอายุ</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% For Each row As DataRow In dtL.Rows %>
                        <tr>
                            <td class="text-center"><% =String.Concat(row("LicenseNo1")) %></td>
                            <td class="text-center"><% =String.Concat(row("AccLicense")) %></td>
                            <td><% =String.Concat(row("LocationName")) %></td>
                            <td class="text-center"><% =String.Concat(row("NHSOCode")) %></td>
                            <td class="text-left"><% =String.Concat(row("LocationGroupName")) %></td>
                            <td class="text-center"><% =String.Concat(row("LocationChainName")) %></td>
                            <td class="text-center"><% =String.Concat(row("NHSOGroup")) %> </td>
                            <td class="text-center"><% =String.Concat(row("ProvinceGroupName")) %> </td>
                            <td class="text-center"><% =String.Concat(row("ProvinceName")) %> </td>
                            <td class="text-center"><% =String.Concat(row("isAccPharm")) %></td>
                            <td class="text-center"><% =String.Concat(row("AccStatusName")) %></td>
                            <td class="text-center"><% =String.Concat(row("ExpireDtt")) %></td>
                        </tr>
                        <%  Next %>
                    </tbody>
                </table>
            </div>
        </div>   
          
    </section>
</asp:Content>
