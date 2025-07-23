<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="LocationNew.aspx.vb" Inherits="CPAQA.LocationNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="lnr-store icon-gradient bg-green"></i>
                </div>
                <div>
                    ลงทะเบียนร้านยาใหม่
					<div class="page-title-subheading">ตรวจสอบร้านยาจากฐานข้อมูล อย. และลงทะเบียนใหม่ </div>
                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <asp:Panel ID="pnReg" runat="server">
            <div class="row">
                <section class="col-lg-12 connectedSortable">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="p-2">
                                        <div class="text-left">
                                            <h3 class="card-title"><b>ลงทะเบียนร้านยาใหม่</b></h3>
                                            <br />
                                        </div>
                                        <div class="form-group has-feedback">
                                            <label>เลขที่ใบอนุญาตขายยา (ตัวอย่าง กท.28/2565)</label>
                                            <asp:TextBox ID="txtLicenseNo" runat="server" placeholder="" ToolTip="" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-6 text-center">
                                                <div class="p-2">
                                                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Next" Width="120px" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnDetail" runat="server">
            <div class="row">
                <section class="col-lg-12 connectedSortable">
                    <div class="box box-solid">
                        <div class="box-header">
                            <img src="images/fdalogo.png" width="26" />&nbsp; ข้อมูลจากฐานข้อมูล อย.
                 <div class="box-tools pull-right">
                     <asp:Label ID="lblLastUpdate" runat="server" CssClass="small"></asp:Label>
                     <button type="button" class="btn btn-box-tool" data-widget="collapse">
                         <i class="fa fa-minus"></i>
                     </button>
                 </div>
                        </div>

                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>ชื่อร้านยา</label>
                                        <asp:Label ID="lblthanm" runat="server" CssClass="text-blue text-bold"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>รหัสผู้ประกอบการ</label>
                                        <asp:Label ID="lblLcnsid" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>เลขที่ใบอนุญาต</label>
                                        <asp:Label ID="lblLcnno" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>รหัส Newcode</label>
                                        <asp:Label ID="lblNewCode" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>สถานที่ตั้งเลขที่</label>
                                        <asp:Label ID="lblAddress" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                                  
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>เบอร์โทร</label>
                                        <asp:Label ID="lblTel" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>เวลาทำการร้าน</label>
                                        <asp:Label ID="lblLicenTime" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>สถานะใบอนุญาต</label>
                                        <asp:Label ID="lblLicenStatus" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>วันที่อนุญาต</label>
                                        <asp:Label ID="lblAppdate" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>ปีที่หมดอายุ</label>
                                        <asp:Label ID="lblExpyear" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>ชื่อผู้ดำเนินกิจการ</label>
                                        <asp:Label ID="lblGrannm" runat="server" CssClass="text-bold"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 text-center">
                                    <asp:Button ID="cmdConfirm" runat="server" Text="Confirm" CssClass="btn btn-primary" Width="120" />
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </asp:Panel>
    </section>
</asp:Content>
