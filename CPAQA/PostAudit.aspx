<%@ Page Title="การตรวจรักษามาตรฐาน" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PostAudit.aspx.vb" Inherits="CPAQA.PostAudit" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">     
        function openModalUploadQA(sender, id) {
            $('#modal-window-qa').modal('show');
            return false;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-medal icon-gradient bg-success"></i>
                </div>
                <div>
                    <h2 class="text-primary text-bold">การตรวจมาตรฐานร้านยาคุณภาพ</h2>
                            <div class="page-title-subheading">
                                <asp:HiddenField ID="hdPostUID" runat="server" />
                                <asp:HiddenField ID="hdAssessmentUID" runat="server" />
                            </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Main content -->
    <section class="content">
        <div class="row">              
                <div class="box box-solid">
                    <div class="box-header">
                        <i class="header-icon lnr-store icon-gradient bg-primary"></i>เลขที่ :&nbsp;<asp:Label ID="lblCode" runat="server" Text="Auto ID"></asp:Label>      
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>ชื่อร้านยา</label>
                                    <asp:HiddenField ID="hdLocationUID" runat="server" />
                                    <asp:Label ID="lblLocationName" runat="server" CssClass="text-blue text-bold"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>จังหวัด</label>
                                    <asp:Label ID="lblProvince" runat="server" CssClass="text-blue text-bold"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>เลขที่ใบอนุญาต ขย.</label>
                                    <asp:Label ID="lblLicenseNo" runat="server" CssClass="text-bold"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>เลขที่เกียรติบัตร</label>
                                    <asp:Label ID="lblAccLicenseNo" runat="server" CssClass="text-bold"></asp:Label>
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

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>ชื่อผู้รับการตรวจ</label>
                                    <asp:TextBox ID="txtAssessee" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group mailbox-messages">
                                    <label>ตำแหน่งในร้าน</label>
                                    <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control" placeholder="เภสัชกรผู้มีหน้าที่ปฏิบัติการ หรือ เภสัชกรผู้รับอนุญาต"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>วันที่ดำเนินการตรวจ</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtAsmDate" runat="server" CssClass="form-control text-center"
                                            autocomplete="off" data-date-format="dd/mm/yyyy"
                                            data-date-language="th-th" data-provide="datepicker"
                                            onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>วิธีตรวจ</label>
                                    <asp:RadioButtonList ID="optAudit" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">On Site</asp:ListItem>
                                        <asp:ListItem Value="2">Online</asp:ListItem>
                                        <asp:ListItem Value="3">Hybrid</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>การตรวจมาตรฐาน</label><br />
                                        <asp:CheckBox ID="chkAccPharm" runat="server"  Text="ระบบร้านยาคุณภาพ" AutoPostBack="True" cssclass="text-bold text-primary" /><br />
                                        <asp:CheckBox ID="chkCI" runat="server" Text="บริการ Common illness" AutoPostBack="True" cssclass="text-bold text-success" />
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label><b>ผู้ตรวจประเมิน</b></label>

                                <asp:GridView ID="grdSurveyor" runat="server" AutoGenerateColumns="False" BorderStyle="None" ShowHeader="false" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "nRow") & ". " & DataBinder.Eval(Container.DataItem, "AssessorName")  %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div> 
           
        </div>

        <div class="row" id="pnQA" runat="server">
           
            
                 <h2 class="text-primary text-bold">การตรวจมาตรฐานร้านยาคุณภาพ</h2>

                <div class="box box-solid">
                    <div class="box-header">
                        <i class="fa fa-grear"></i>
                        <h3 class="box-title">(1) ข้อมูลการตรวจ ระบบร้านยาคุณภาพ</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">
                        <table>
                            <tr>
                                <td class="text-blue">1. หมวดสถานที่&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="optQA1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="ไม่พบสิ่งที่ไม่เป็นไปตามมาตรฐาน" Value="Y" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="พบสิ่งที่ไม่เป็นไปตามมาตรฐาน (กรุณาระบุเพิ่มรายการ ด้านล่าง)" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanelQA1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label></label>
                                            <asp:HiddenField ID="hdQA1UID" runat="server" />
                                            <asp:TextBox ID="txtQA1" runat="server" CssClass="form-control" placeholder="ระบุ สิ่งที่ไม่เป็นไปตามมาตรฐาน"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                            </label>
                                            <div class="file-upload">
                                                <asp:FileUpload ID="FileUploadQA1" runat="server" AllowMultiple="true" />
                                                <i class="fa fa-camera"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label></label>
                                            <br />
                                            <asp:Button ID="cmdSaveQA1" runat="server" Text="เพิ่ม" CssClass="btn btn-primary" />
                                            <asp:Button ID="cmdClearQA1" runat="server" Text="ยกเลิก" CssClass="btn btn-secondary" />
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                            <Triggers>

                                <asp:PostBackTrigger ControlID="cmdSaveQA1" />
                                <asp:AsyncPostBackTrigger ControlID="grdQA1" EventName="RowCommand" />

                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="row">

                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanelQA1List" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdQA1" CssClass="table table-hover" runat="server" CellPadding="2" GridLines="None" AutoGenerateColumns="False" Font-Bold="False">
                                            <RowStyle BackColor="#F7F7F7" />
                                            <Columns>
                                                <asp:BoundField DataField="nRow" HeaderText="No.">
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descriptions" HeaderText="สิ่งที่ไม่เป็นไปตามมาตรฐาน">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgFileQA1" runat="server" CssClass="btn btn-success" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'><i class="fa fa-image"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgEdit" runat="server" Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                        <asp:LinkButton ID="imgDel" runat="server" Text="ลบ" CssClass="btn btn-danger" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle HorizontalAlign="Center"
                                                CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle CssClass="th" Font-Bold="True" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="cmdSaveQA1" />
                                        <asp:AsyncPostBackTrigger ControlID="grdQA1" EventName="RowCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <table>
                            <tr>
                                <td class="text-blue">2. หมวดอุปกรณ์&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="optQA2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="ไม่พบสิ่งที่ไม่เป็นไปตามมาตรฐาน" Value="Y" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="พบสิ่งที่ไม่เป็นไปตามมาตรฐาน (กรุณาระบุเพิ่มรายการ ด้านล่าง)" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanelQA2" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label></label>
                                            <asp:HiddenField ID="hdQA2UID" runat="server" />
                                            <asp:TextBox ID="txtQA2" runat="server" CssClass="form-control" placeholder="ระบุ สิ่งที่ไม่เป็นไปตามมาตรฐาน"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                            </label>
                                            <div class="file-upload">
                                                <asp:FileUpload ID="FileUploadQA2" runat="server" AllowMultiple="true" />
                                                <i class="fa fa-camera"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label></label>
                                            <br />
                                            <asp:Button ID="cmdSaveQA2" runat="server" Text="เพิ่ม" CssClass="btn btn-primary" />
                                            <asp:Button ID="cmdClearQA2" runat="server" Text="ยกเลิก" CssClass="btn btn-secondary" />
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                            <Triggers>

                                <asp:PostBackTrigger ControlID="cmdSaveQA2" />
                                <asp:AsyncPostBackTrigger ControlID="grdQA2" EventName="RowCommand" />

                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="row">

                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanelQA2List" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdQA2" CssClass="table table-hover" runat="server" CellPadding="2" GridLines="None" AutoGenerateColumns="False" Font-Bold="False">
                                            <RowStyle BackColor="#F7F7F7" />
                                            <Columns>
                                                <asp:BoundField DataField="nRow" HeaderText="No.">
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descriptions" HeaderText="สิ่งที่ไม่เป็นไปตามมาตรฐาน">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgFileQA2" runat="server" CssClass="btn btn-success" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'><i class="fa fa-image"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgEdit" runat="server" Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                        <asp:LinkButton ID="imgDel" runat="server" Text="ลบ" CssClass="btn btn-danger" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle HorizontalAlign="Center"
                                                CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle CssClass="th" Font-Bold="True" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="cmdSaveQA2" />
                                        <asp:AsyncPostBackTrigger ControlID="grdQA2" EventName="RowCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <table>
                            <tr>
                                <td class="text-blue">3. หมวดบุคลากร&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="optQA3" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="ไม่พบสิ่งที่ไม่เป็นไปตามมาตรฐาน" Value="Y" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="พบสิ่งที่ไม่เป็นไปตามมาตรฐาน (กรุณาระบุเพิ่มรายการ ด้านล่าง)" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanelQA3" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label></label>
                                            <asp:HiddenField ID="hdQA3UID" runat="server" />
                                            <asp:TextBox ID="txtQA3" runat="server" CssClass="form-control" placeholder="ระบุ สิ่งที่ไม่เป็นไปตามมาตรฐาน"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                            </label>
                                            <div class="file-upload">
                                                <asp:FileUpload ID="FileUploadQA3" runat="server" AllowMultiple="true" />
                                                <i class="fa fa-camera"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label></label>
                                            <br />
                                            <asp:Button ID="cmdSaveQA3" runat="server" Text="เพิ่ม" CssClass="btn btn-primary" />
                                            <asp:Button ID="cmdClearQA3" runat="server" Text="ยกเลิก" CssClass="btn btn-secondary" />
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                            <Triggers>

                                <asp:PostBackTrigger ControlID="cmdSaveQA3" />
                                <asp:AsyncPostBackTrigger ControlID="grdQA3" EventName="RowCommand" />

                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="row">

                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanelQA3List" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdQA3" CssClass="table table-hover" runat="server" CellPadding="2" GridLines="None" AutoGenerateColumns="False" Font-Bold="False">
                                            <RowStyle BackColor="#F7F7F7" />
                                            <Columns>
                                                <asp:BoundField DataField="nRow" HeaderText="No.">
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descriptions" HeaderText="สิ่งที่ไม่เป็นไปตามมาตรฐาน">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgFileQA3" runat="server" CssClass="btn btn-success" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'><i class="fa fa-image"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgEdit" runat="server" Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                        <asp:LinkButton ID="imgDel" runat="server" Text="ลบ" CssClass="btn btn-danger" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle HorizontalAlign="Center"
                                                CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle CssClass="th" Font-Bold="True" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="cmdSaveQA3" />
                                        <asp:AsyncPostBackTrigger ControlID="grdQA3" EventName="RowCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <table>
                            <tr>
                                <td class="text-blue">4. หมวดการควบคุมคุณภาพยา&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="optQA4" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="ไม่พบสิ่งที่ไม่เป็นไปตามมาตรฐาน" Value="Y" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="พบสิ่งที่ไม่เป็นไปตามมาตรฐาน (กรุณาระบุเพิ่มรายการ ด้านล่าง)" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanelQA4" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label></label>
                                            <asp:HiddenField ID="hdQA4UID" runat="server" />
                                            <asp:TextBox ID="txtQA4" runat="server" CssClass="form-control" placeholder="ระบุ สิ่งที่ไม่เป็นไปตามมาตรฐาน"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                            </label>
                                            <div class="file-upload">
                                                <asp:FileUpload ID="FileUploadQA4" runat="server" AllowMultiple="true" />
                                                <i class="fa fa-camera"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label></label>
                                            <br />
                                            <asp:Button ID="cmdSaveQA4" runat="server" Text="เพิ่ม" CssClass="btn btn-primary" />
                                            <asp:Button ID="cmdClearQA4" runat="server" Text="ยกเลิก" CssClass="btn btn-secondary" />
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                            <Triggers>

                                <asp:PostBackTrigger ControlID="cmdSaveQA4" />
                                <asp:AsyncPostBackTrigger ControlID="grdQA4" EventName="RowCommand" />

                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="row">

                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanel1QA4List" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdQA4" CssClass="table table-hover" runat="server" CellPadding="2" GridLines="None" AutoGenerateColumns="False" Font-Bold="False">
                                            <RowStyle BackColor="#F7F7F7" />
                                            <Columns>
                                                <asp:BoundField DataField="nRow" HeaderText="No.">
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descriptions" HeaderText="สิ่งที่ไม่เป็นไปตามมาตรฐาน">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgFileQA4" runat="server" CssClass="btn btn-success" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'><i class="fa fa-image"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgEdit" runat="server" Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                        <asp:LinkButton ID="imgDel" runat="server" Text="ลบ" CssClass="btn btn-danger" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle HorizontalAlign="Center"
                                                CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle CssClass="th" Font-Bold="True" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="cmdSaveQA4" />
                                        <asp:AsyncPostBackTrigger ControlID="grdQA4" EventName="RowCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <table>
                            <tr>
                                <td class="text-blue">5. การปฏิบัติตามวิธีปฏิบัติทางเภสัชกรรมชุมชน&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="optQA5" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="ไม่พบสิ่งที่ไม่เป็นไปตามมาตรฐาน" Value="Y" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="พบสิ่งที่ไม่เป็นไปตามมาตรฐาน (กรุณาระบุเพิ่มรายการ ด้านล่าง)" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanelQA5" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label></label>
                                            <asp:HiddenField ID="hdQA5UID" runat="server" />
                                            <asp:TextBox ID="txtQA5" runat="server" CssClass="form-control" placeholder="ระบุ สิ่งที่ไม่เป็นไปตามมาตรฐาน"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                            </label>
                                            <div class="file-upload">
                                                <asp:FileUpload ID="FileUploadQA5" runat="server" AllowMultiple="true" />
                                                <i class="fa fa-camera"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label></label>
                                            <br />
                                            <asp:Button ID="cmdSaveQA5" runat="server" Text="เพิ่ม" CssClass="btn btn-primary" />
                                            <asp:Button ID="cmdClearQA5" runat="server" Text="ยกเลิก" CssClass="btn btn-secondary" />
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                            <Triggers>

                                <asp:PostBackTrigger ControlID="cmdSaveQA5" />
                                <asp:AsyncPostBackTrigger ControlID="grdQA5" EventName="RowCommand" />

                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="row">

                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanel1QA5List" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdQA5" CssClass="table table-hover" runat="server" CellPadding="2" GridLines="None" AutoGenerateColumns="False" Font-Bold="False">
                                            <RowStyle BackColor="#F7F7F7" />
                                            <Columns>
                                                <asp:BoundField DataField="nRow" HeaderText="No.">
                                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descriptions" HeaderText="สิ่งที่ไม่เป็นไปตามมาตรฐาน">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgFileQA5" runat="server" CssClass="btn btn-success" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'><i class="fa fa-image"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgEdit" runat="server" Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                        <asp:LinkButton ID="imgDel" runat="server" Text="ลบ" CssClass="btn btn-danger" Width="60"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle HorizontalAlign="Center"
                                                CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle CssClass="th" Font-Bold="True" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="cmdSaveQA5" />
                                        <asp:AsyncPostBackTrigger ControlID="grdQA5" EventName="RowCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>


                    </div>
                </div>


                <div class="box box-solid border mb-3 border-primary">
                    <div class="box-header">
                        <i class="fa fa-grear"></i>
                        <h3 class="box-title">(2) สรุปผลการตรวจ และ  ความเห็นของผู้ตรวจเยี่ยม ระบบร้านยาคุณภาพ</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>

                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:RadioButtonList ID="optQAResult" runat="server">
                                        <asp:ListItem Text="ผ่าน" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="แก้ไข (ระบุ)" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="อื่นๆ (ระบุ)" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                            </div>
                            <div class="col-md-10">
                                <div class="form-group">
                                    <label>ระบุ สิ่งที่ต้องแก้ไข หรือ อื่นๆ</label>
                                    <asp:TextBox ID="txtQARemark" runat="server" TextMode="MultiLine" Height="50" CssClass="form-control text-blue"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                          <div class="row">
      <div class="col-md-1">
          <div class="form-group">
              <label>
                  แนบรูป
                  <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
              </label>
              <div class="file-upload">
                  <asp:FileUpload ID="FileUploadQAResult" runat="server" name="FileUploadQAResult" AllowMultiple="true" />
                  <i class="fa fa-camera"></i>
              </div>
          </div>
      </div>
      <div class="col-md-3">
          <div class="form-group">
              <label></label>
              <br />
              <asp:Button ID="cmdUploadQAResult" CssClass="btn btn-success" runat="server" Text="Upload" />
          </div>
      </div>

  </div>

  <div class="row app-header-primary m-0 mb-3">
      <asp:UpdatePanel ID="UpdatePanelQAResult" runat="server">
          <ContentTemplate>
              <asp:DataList ID="dtlImgQAResult" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                  <ItemTemplate>
                      <div class="pl-0">
                          <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>' Height="30"></asp:ImageButton>
                      </div>
                      <div style="margin: -40px 0 0 0px">
                          <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                      </div>
                  </ItemTemplate>
              </asp:DataList>
          </ContentTemplate>
          <Triggers>
              <asp:PostBackTrigger ControlID="cmdUploadQAResult" />
              <asp:AsyncPostBackTrigger ControlID="dtlImgQAResult" EventName="ItemCommand" />
          </Triggers>
      </asp:UpdatePanel>
  </div>


                    </div>
                </div>


                <div class="box box-solid border mb-3 border-primary">
                    <div class="box-header">
                        <i class="fa fa-grear"></i>
                        <h3 class="box-title">(3) การดำเนินการ ระบบร้านยาคุณภาพ</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>

                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>ส่งเรื่องแจ้งร้าน เมื่อวันที่</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtQAInformDate" runat="server" CssClass="form-control text-center"
                                            autocomplete="off" data-date-format="dd/mm/yyyy"
                                            data-date-language="th-th" data-provide="datepicker"
                                            onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>
                                        แนบรูป
                         <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                    </label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUploadQAInform" runat="server" name="FileUploadQAInform" AllowMultiple="true" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:Button ID="cmdUploadQAInform" CssClass="btn btn-success" runat="server" Text="Upload" />
                                </div>
                            </div>

                        </div>

                        <div class="row app-header-primary m-0 mb-3">
                            <asp:UpdatePanel ID="UpdatePanelImgQAInform" runat="server">
                                <ContentTemplate>
                                    <asp:DataList ID="dtlImgQAInform" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                        <ItemTemplate>
                                            <div class="pl-0">
                                                <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>' Height="30"></asp:ImageButton>
                                            </div>
                                            <div style="margin: -40px 0 0 0px">
                                                <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="cmdUploadQAInform" />
                                    <asp:AsyncPostBackTrigger ControlID="dtlImgQAInform" EventName="ItemCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>ร้านแจ้งกลับการแก้ไข เมื่อวันที่</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtQAresponseDate" runat="server" CssClass="form-control text-center"
                                            autocomplete="off" data-date-format="dd/mm/yyyy"
                                            data-date-language="th-th" data-provide="datepicker"
                                            onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>
                                        แนบรูป
                        <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                    </label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUploadQAResponse" runat="server" name="FileUploadQAResponse" AllowMultiple="true" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:Button ID="cmdUploadQAResponse" CssClass="btn btn-success" runat="server" Text="Upload" />
                                </div>
                            </div>

                        </div>

                        <div class="row app-header-primary m-0 mb-3">
                            <asp:UpdatePanel ID="UpdatePanelQAResponse" runat="server">
                                <ContentTemplate>
                                    <asp:DataList ID="dtlImgQAResponse" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                        <ItemTemplate>
                                            <div class="pl-0">
                                                <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>' Height="30"></asp:ImageButton>
                                            </div>
                                            <div style="margin: -40px 0 0 0px">
                                                <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="cmdUploadQAResponse" />
                                    <asp:AsyncPostBackTrigger ControlID="dtlImgQAResponse" EventName="ItemCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>




                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>ผลการพิจารณาการแก้ไข</label>
                                    <asp:RadioButtonList ID="optQAComplete" runat="server">
                                        <asp:ListItem Text="เรียบร้อย" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="ไม่เรียบร้อย" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <div class="form-group">


                                    <label>ปิดผลการตรวจมาตรฐานร้านยาคุณภาพ   วันที่</label>
                                    <div class="input-group">
                                        <div class="button r" id="button-1">
                                            <input id="chkQAClose" type="checkbox" class="checkbox" runat="server">
                                            <div class="knobs"></div>
                                            <div class="layer"></div>
                                        </div>
                                        <asp:TextBox ID="txtQACloseDate" runat="server" CssClass="form-control text-center"
                                            autocomplete="off" data-date-format="dd/mm/yyyy"
                                            data-date-language="th-th" data-provide="datepicker"
                                            onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>โดย...</label>
                                    <asp:TextBox ID="txtQACloseRemark" runat="server" TextMode="MultiLine" Height="50" CssClass="form-control text-blue"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

             
            </div>
   <div class="row" id="pnCI" runat="server">
                <h2 class="text-primary text-bold">การตรวจมาตรฐานบริการ <span class="text-success">Common illness</span></h2>


                <div class="box box-solid">
                    <div class="box-header">
                        <i class="fa fa-grear"></i>
                        <h3 class="box-title">(1) มาตรฐานการบริการ <span class="text-success">Common illness</span></h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">


                        <div class="row">
                            <div class="col-md-12 table-responsive">

                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th class="text-center" width="10px"></th>
                                            <th class="text-left" width="300px">มาตรฐานการบริการ</th>
                                            <th class="text-left" width="120px">ตรงตามมาตรฐาน</th>
                                            <th class="text-left">ระบุ</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>1.</td>
                                            <td>การบริการโดยเภสัชกร</td>
                                            <td class="text-center">
                                                <div class="button r" id="button-c1">
                                                    <input id="chkC1" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>


                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI1" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2.</td>
                                            <td>การซักถามอาการ</td>
                                            <td>
                                                <div class="button r" id="button-c2">
                                                    <input id="chkC2" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3.</td>
                                            <td>การจ่ายยา</td>
                                            <td>
                                                <div class="button r" id="button-c3">
                                                    <input id="chkC3" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI3" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>4.</td>
                                            <td>การแนะนำการใช้ยา  </td>
                                            <td>
                                                <div class="button r" id="button-c4">
                                                    <input id="chkC4" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI4" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>5.</td>
                                            <td>การติดตาม  หลังจ่ายยา ( 72 ชั่วโมง )</td>
                                            <td>
                                                <div class="button r" id="button-c5">
                                                    <input id="chkC5" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI5" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>6.</td>
                                            <td>ไม่พบการรับยาแทน</td>
                                            <td>
                                                <div class="button r" id="button-c6">
                                                    <input id="chkC6" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI6" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>7.</td>
                                            <td>การประชาสัมพันธ์ถูกต้อง</td>
                                            <td>
                                                <div class="button r" id="button-c7">
                                                    <input id="chkC7" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI7" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>8.</td>
                                            <td>การเก็บรายงานการให้บริการ</td>
                                            <td>
                                                <div class="button r" id="button-c8">
                                                    <input id="chkC8" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI8" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>9.</td>
                                            <td>การจัดทำทะเบียน</td>
                                            <td>
                                                <div class="button r" id="button-c9">
                                                    <input id="chkC9" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI9" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>10.</td>
                                            <td>ไม่พบมีการจัดบริการ CI +PP แบบ Package</td>
                                            <td>
                                                <div class="button r" id="button-c10">
                                                    <input id="chkC10" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI10" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>11.</td>
                                            <td>มีเอกสารเพื่อการส่งต่อ ( Refer )</td>
                                            <td>
                                                <div class="button r" id="button-c11">
                                                    <input id="chkC11" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI11" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>12.</td>
                                            <td>การให้บริการภายในเวลาที่ระบุใน ขย 5 </td>
                                            <td>
                                                <div class="button r" id="button-c12">
                                                    <input id="chkC12" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCI12" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>13.</td>
                                            <td>อื่นๆ</td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtCI13" runat="server" CssClass="form-control" placeholder="" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="box box-solid">
                    <div class="box-header">
                        <i class="fa fa-grear"></i>
                        <h3 class="box-title">(2)  ความพึงพอใจการบริการ<span class="text-success">Common illness</span></h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>( ประเมินจากผู้มารับบริการ โดย สอบถามผู้มารอรับบริการ )</label>
                                    <asp:TextBox ID="txtSatisfaction" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="box box-solid border mb-3 border-success">
                    <div class="box-header">
                        <i class="fa fa-grear"></i>
                        <h3 class="box-title">(3) สรุปผลการตรวจ และ  ความเห็นของผู้ตรวจเยี่ยม มาตรฐานบริการ <span class="text-success">Common illness</span></h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>

                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:RadioButtonList ID="optCIResult" runat="server">
                                        <asp:ListItem Text="ผ่าน" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="แก้ไข (ระบุ)" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="อื่นๆ (ระบุ)" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                            </div>
                            <div class="col-md-9">
                                <div class="form-group">
                                    <label>ระบุ สิ่งที่ต้องแก้ไข หรือ อื่นๆ</label>
                                    <asp:TextBox ID="txtCIRemark" runat="server" TextMode="MultiLine" Height="50" CssClass="form-control text-blue"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label>
                                        แนบรูป
                                        <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                    </label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUploadCIResult" runat="server" name="FileUploadCIResult" AllowMultiple="true" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:Button ID="cmdUploadCIResult" CssClass="btn btn-success" runat="server" Text="Upload" />
                                </div>
                            </div>

                        </div>

                        <div class="row app-header-primary m-0 mb-3">
                            <asp:UpdatePanel ID="UpdatePanelCIResult" runat="server">
                                <ContentTemplate>
                                    <asp:DataList ID="dtlImgCIResult" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                        <ItemTemplate>
                                            <div class="pl-0">
                                                <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>' Height="30"></asp:ImageButton>
                                            </div>
                                            <div style="margin: -40px 0 0 0px">
                                                <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="cmdUploadCIResult" />
                                    <asp:AsyncPostBackTrigger ControlID="dtlImgCIResult" EventName="ItemCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>



                    </div>
                </div>


                <div class="box box-solid border mb-3 border-success">
                    <div class="box-header">
                        <i class="fa fa-grear"></i>
                        <h3 class="box-title">(4) การดำเนินการ มาตรฐานบริการ <span class="text-success">Common illness</span></h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>

                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>ส่งเรื่องแจ้งร้าน เมื่อวันที่</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtCIInformDate" runat="server" CssClass="form-control text-center"
                                            autocomplete="off" data-date-format="dd/mm/yyyy"
                                            data-date-language="th-th" data-provide="datepicker"
                                            onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label>
                                        แนบรูป
            <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                    </label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUploadCIInform" runat="server" name="FileUploadCIInform" AllowMultiple="true" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:Button ID="cmdUploadCIInform" CssClass="btn btn-success" runat="server" Text="Upload" />
                                </div>
                            </div>

                        </div>

                        <div class="row app-header-primary m-0 mb-3">
                            <asp:UpdatePanel ID="UpdatePanelCIInform" runat="server">
                                <ContentTemplate>
                                    <asp:DataList ID="dtlImgCIInform" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                        <ItemTemplate>
                                            <div class="pl-0">
                                                <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>' Height="30"></asp:ImageButton>
                                            </div>
                                            <div style="margin: -40px 0 0 0px">
                                                <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="cmdUploadCIInform" />
                                    <asp:AsyncPostBackTrigger ControlID="dtlImgCIInform" EventName="ItemCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>ร้านแจ้งกลับการแก้ไข เมื่อวันที่</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtCIResponseDate" runat="server" CssClass="form-control text-center"
                                            autocomplete="off" data-date-format="dd/mm/yyyy"
                                            data-date-language="th-th" data-provide="datepicker"
                                            onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label>
                                        แนบรูป
           <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                    </label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUploadCIResponse" runat="server" name="FileUploadCIResponse" AllowMultiple="true" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:Button ID="cmdUploadCIResponse" CssClass="btn btn-success" runat="server" Text="Upload" />
                                </div>
                            </div>

                        </div>

                        <div class="row app-header-primary m-0 mb-3">
                            <asp:UpdatePanel ID="UpdatePanelCIResponse" runat="server">
                                <ContentTemplate>
                                    <asp:DataList ID="dtlImgCIResponse" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                        <ItemTemplate>
                                            <div class="pl-0">
                                                <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>' Height="30"></asp:ImageButton>
                                            </div>
                                            <div style="margin: -40px 0 0 0px">
                                                <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="cmdUploadCIResponse" />
                                    <asp:AsyncPostBackTrigger ControlID="dtlImgCIResponse" EventName="ItemCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>ผลการพิจารณาการแก้ไข</label>
                                    <asp:RadioButtonList ID="optCIComplete" runat="server">
                                        <asp:ListItem Text="เรียบร้อย" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="ไม่เรียบร้อย" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>ปิดผลการตรวจมาตรฐาน <span class="text-success">Common illness</span> วันที่</label>
                                    <div class="input-group">
                                        <div class="button r" id="button-2">
                                            <input id="chkCIClose" type="checkbox" class="checkbox" runat="server">
                                            <div class="knobs"></div>
                                            <div class="layer"></div>
                                        </div>
                                        <asp:TextBox ID="txtCICloseDate" runat="server" CssClass="form-control text-center"
                                            autocomplete="off" data-date-format="dd/mm/yyyy"
                                            data-date-language="th-th" data-provide="datepicker"
                                            onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>โดย...</label>
                                    <asp:TextBox ID="txtCICloseRemark" runat="server" TextMode="MultiLine" Height="50" CssClass="form-control text-blue"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

         </div>     

     
          

        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="cmdCreate" CssClass="btn btn-success" runat="server" Text="Next" Width="120px" />
                <asp:Button ID="cmdSave" CssClass="btn btn-primary" runat="server" Text="Save" Width="120px" />
                <asp:Button ID="cmdDelete" CssClass="btn btn-danger" runat="server" Text="Delete" Width="120px" />
                <asp:Button ID="cmdBack" CssClass="btn btn-secondary" runat="server" Text="กลับหน้ารายการ" Width="120px" />
            </div>
        </div>

  <!-- Modal HTML > -->                 
                <div id="modal-window" class="modal fade modal-window" role="dialog" data-backdrop="static" tabindex="-1" style="display: none; z-index: 9999;" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header-window">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <h6 class="modal-title-window">&nbsp;<span id="spnTitle2"></span></h6>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <span id="spnMsg2"></span>
                                            <br />
                                            <img id="img1" src="" style="width: 100%; display: inline-block;" />
                                            <br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <button class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                 
                <div id="modal-window-qa" class="modal fade modal-window" role="dialog" data-backdrop="static" tabindex="-1" style="display: none;" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header-window">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <h6 class="modal-title-window">อัพโหลดไฟล์รูปภาพ/เอกสาร
                                </h6>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 200px">
                                                                <div class="file-upload-big">
                                                                    <asp:FileUpload ID="FileUploadQA" runat="server" AllowMultiple="true" /><i class="fa fa-camera"></i>
                                                                </div>
                                                            </td>
                                                            <td style="width: 100%" rowspan="2">
                                                                <div class="app-page-header">
                                                                    <div class="page-title-wrapper">
                                                                        <div class="page-title-heading">
                                                                            <div>
                                                                                <div class="page-title-subheading">คำแนะนำ</div>
                                                                                <asp:HiddenField ID="hdQAUID" runat="server" />
                                                                                <asp:HiddenField ID="hdImgCode" runat="server" />
                                                                                <br />
                                                                                - ไฟล์นามสกุล .jpg, .jpeg, .gif, .png,.pdf เท่านั้น   
                                                                                <br />
                                                                                - ขนาดไฟล์ไม่เกิน 1024 Kb.
                                                                                <br />
                                                                                - เพิ่มได้ไม่เกิน 4 รูป  
                                                                                <br />
                                                                                <br />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>


                                                                <asp:Button ID="cmdUpImgQA" runat="server" Text="Upload" CssClass="btn btn-success" Width="200" />

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="cmdUpImgQA" />
                                                    <asp:AsyncPostBackTrigger ControlID="grdImgQA" EventName="RowCommand" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <br />

                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblImgQA" runat="server" CssClass="text-red"></asp:Label>
                                                    <asp:GridView ID="grdImgQA" CssClass="table table-hover"
                                                        runat="server" CellPadding="2"
                                                        GridLines="None"
                                                        AutoGenerateColumns="False"
                                                        Font-Bold="False">
                                                        <RowStyle BackColor="#F7F7F7" />
                                                        <Columns>
                                                            <asp:BoundField DataField="nRow" HeaderText="No.">
                                                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                            </asp:BoundField>
                                                            <asp:ImageField HeaderText="ไฟล์/รูปภาพ" DataImageUrlField="filePathView">
                                                                <ControlStyle Height="50px" Width="50px" />
                                                            </asp:ImageField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgView" runat="server" ImageUrl="images/view.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePath") %>'></asp:ImageButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgDelFile" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/delete.png" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle HorizontalAlign="Center"
                                                            CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle CssClass="th" Font-Bold="True" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="cmdUpImgQA" />
                                                    <asp:AsyncPostBackTrigger ControlID="grdImgQA" EventName="RowCommand" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <button class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!--- End Modal --->


    </section>
</asp:Content>
