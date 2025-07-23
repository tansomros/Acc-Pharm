<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportComplain.aspx.vb" Inherits="CPAQA.ReportComplain" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="lnr-pie-chart icon-gradient bg-success"></i>
                </div>
                <div>
                    <asp:Label ID="lblTitle" runat="server" Text="รายงานข้อร้องเรียน"></asp:Label>
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
                    <div class="col-md-2">
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
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>มาตรฐานร้านยาคุณภาพ</label><br />
                            <asp:DropDownList ID="ddlEvidence" runat="server" CssClass="form-control select2">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="Y">มาตรฐานร้านยาคุณภาพ</asp:ListItem>
                                <asp:ListItem Value="X">ไม่ใช่มาตรฐานร้านยาคุณภาพ</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>ปัญหาที่ร้องเรียน</label>
                            <br />
                            <asp:DropDownList ID="ddlProblem" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>บริการ หรือ โครงการที่ร้องเรียน</label>
                            <br />
                            <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>                  

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>สถานะ</label>
                            <br />
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="Y">ปิด</asp:ListItem>
                                <asp:ListItem Value="N">ยังไม่ปิด</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>                   
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>จังหวัด</label>
                            <br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>ร้านยา</label>
                            <br />
                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>คำค้นหา</label>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="ชื่อร้าน / เลข ขย.5 /เลขที่ใบอนุญาต"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-md-12 text-center pt-0">
                        <asp:LinkButton ID="cmdExport" runat="server" CssClass="btn btn-success" Width="100px"><i class="fa fa-file-excel"></i>Export</asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>
    </section>
</asp:Content>
