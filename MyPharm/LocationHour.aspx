<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="LocationHour.aspx.vb" Inherits="CPA.LocationHour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-clock icon-gradient bg-secondary"></i>
                </div>
                <div>
                    Business Hour
                    <div class="page-title-subheading">จัดการเวลาทำการของร้านยา</div>
                </div>
            </div>
        </div>
    </div>
    <section class="content">
        <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon lnr lnr-clock icon-gradient bg-success"></i>จัดการเวลาทำการของร้านยา : <asp:Label ID="lblLocationName" runat="server" CssClass="text-blue text-bold" Text=""></asp:Label>
                <asp:HiddenField ID="hdLocationUID" runat="server" />
                <div class="btn-actions-pane-right">
                </div>
            </div>
            <div class="card-body table-responsive">
                <table class="table table-hover table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center">วัน</th>
                            <th class="text-center">เปิด/ปิด</th>
                            <th class="text-center">เวลาเปิด</th>
                            <th class="text-center">เวลาปิด</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="text-center">จันทร์</td>
                            <td class="text-center">
                                <div class="button_tg r" id="button-t1">
                                    <input id="chkMon" type="checkbox" class="checkbox" runat="server" checked="checked">
                                    <div class="knobs"></div>
                                    <div class="layer"></div>
                                </div>
                            </td>
                            <td class="text-center">
                                <asp:TextBox ID="txtBeginMon" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                            <td class="text-center">
                                <asp:TextBox ID="txtEndMon" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text-center">อังคาร</td>
                            <td class="text-center">
                                <div class="button_tg r" id="button-t2">
                                    <input id="chkTue" type="checkbox" class="checkbox" runat="server" checked="checked">
                                    <div class="knobs"></div>
                                    <div class="layer"></div>
                                </div>
                            </td>
                            <td class="text-center">
                                <asp:TextBox ID="txtBeginTue" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                            <td class="text-center">
                                <asp:TextBox ID="txtEndTue" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text-center">พุธ</td>
                            <td class="text-center">
                                <div class="button_tg r" id="button-t3">
                                    <input id="chkWed" type="checkbox" class="checkbox" runat="server" checked="checked">
                                    <div class="knobs"></div>
                                    <div class="layer"></div>
                                </div>
                            </td>
                            <td class="text-center">
                                <asp:TextBox ID="txtBeginWed" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                            <td class="text-center">
                                <asp:TextBox ID="txtEndWed" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text-center">พฤหัสบดี</td>
                            <td class="text-center">
                                <div class="button_tg r" id="button-t4">
                                    <input id="chkThu" type="checkbox" class="checkbox" runat="server" checked="checked">
                                    <div class="knobs"></div>
                                    <div class="layer"></div>
                                </div>
                            </td>
                            <td class="text-center">
                                <asp:TextBox ID="txtBeginThu" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                            <td class="text-center">
                                <asp:TextBox ID="txtEndThu" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text-center">ศุกร์</td>
                            <td class="text-center">
                                <div class="button_tg r" id="button-t5">
                                    <input id="chkFri" type="checkbox" class="checkbox" runat="server" checked="checked">
                                    <div class="knobs"></div>
                                    <div class="layer"></div>
                                </div>
                            </td>
                            <td class="text-center">
                                <asp:TextBox ID="txtBeginFri" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                            <td class="text-center">
                                <asp:TextBox ID="txtEndFri" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text-center">เสาร์</td>
                            <td class="text-center">
                                <div class="button_tg r" id="button-t6">
                                    <input id="chkSat" type="checkbox" class="checkbox" runat="server" checked="checked">
                                    <div class="knobs"></div>
                                    <div class="layer"></div>
                                </div>
                            </td>
                            <td class="text-center">
                                <asp:TextBox ID="txtBeginSat" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                            <td class="text-center">
                                <asp:TextBox ID="txtEndSat" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text-center">อาทิตย์</td>
                            <td class="text-center">
                                <div class="button_tg r" id="button-t7">
                                    <input id="chkSun" type="checkbox" class="checkbox" runat="server" checked="checked">
                                    <div class="knobs"></div>
                                    <div class="layer"></div>
                                </div>
                            </td>
                            <td class="text-center">
                                <asp:TextBox ID="txtBeginSun" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                            <td class="text-center">
                                <asp:TextBox ID="txtEndSun" runat="server" CssClass="form-control special-letter text-center" data-inputmask="'mask': '99:99'" MaxLength="5"></asp:TextBox></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="d-block text-center card-footer">
                <asp:Button ID="cmdSave" runat="server" Width="120" CssClass="btn btn-primary" Text="บันทึก" />
            </div>
        </div>
    </section>
</asp:Content>
