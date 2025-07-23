<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RequestDetail.aspx.vb"    Inherits="CPAQA.RequestDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function openModalSend(sender, title, message) {
            $("#spnHeader").text(title);
            $("#spnBodyMsg").text(message);
            $('#modal-window-send').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
        function openModalCancel(sender, title, message) {
            $("#spnHeaderCancel").text(title);
            $("#spnBodyMsgCancel").text(message);
            $('#modal-window-cancel').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
        function openModalChangeType(sender, title, message) {
            $("#spnHeaderChangeType").text(title);
            $("#spnBodyMsgChangeType").text(message);
            $('#modal-window-changetype').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
        function openModalOverview(sender, title, message) {
            $("#spnHeaderOverview").text(title);
            $("#spnBodyMsgOverview").text(message);
            $('#modal-window-overview').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
        function openModalAlert(sender, title, message) {
            $("#spnHeaderAlert").text(title);
            $("#spnBodyMsgAlert").text(message);
            $('#modal-window-alert').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-note icon-gradient bg-success"></i>
                </div>
                <div>
                    รายละเอียดคำขอประเมินรับรอง
                            <div class="page-title-subheading"></div>
                </div>
            </div>
        </div>
    </div>

    <!-- Main content -->
    <section class="content">
        <div id="pnCancel" runat="server" class="alert alert-danger">
            <h3>รายการคำร้องนี้มีสถานะ <b>ยกเลิกคำขอ</b> แล้ว ท่านไม่สามารถดำเนินการใดๆได้อีก</h3>
        </div>

        <div class="row">
            <section class="col-lg-6 connectedSortable">
                <div class="main-card mb-3 card">
                    <div class="card-header">
                        ข้อมูลคำขอ<asp:HiddenField ID="hdRequestUID" runat="server" />
                        <asp:HiddenField ID="hdLocationUID" runat="server" />
                        <asp:HiddenField ID="hdAssessmentUID" runat="server" />
                    </div>
                    <div class="card-body">

                        <table class="table table-bordered">
                            <tr>
                                <td width="150">เลขที่คำขอ</td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" CssClass="h6 text-bold text-success"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>ประเภทคำขอ</td>
                                <td>
                                    <asp:Label ID="lblRequestType" runat="server" Text=""></asp:Label>&nbsp;<asp:Button ID="cmdChangeType" CssClass="btn btn-primary" runat="server" Text="เปลี่ยนประเภทคำขอ" />
                                </td>
                            </tr>
                            <tr>
                                <td>ร้านยา</td>
                                <td>
                                    <asp:Label ID="lblLocationName" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>สถานที่ตั้ง</td>
                                <td>
                                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>ผู้ยื่นคำขอ</td>
                                <td>
                                    <asp:Label ID="lblRequesterName" runat="server" Text=""></asp:Label>&nbsp;(<asp:Label ID="lblRequesterMail" runat="server"></asp:Label>)</td>
                            </tr>
                            <tr>
                                <td>ความเกี่ยวข้องกับร้านยา</td>
                                <td>
                                    <asp:Label ID="lblRequesterType" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>สถานะคำขอ</td>
                                <td>
                                    <asp:Label ID="lblAssessmentStatus" runat="server" CssClass="text-bold text-blue" Text="รอดำเนินการ"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblStatusRemark" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>



                    </div>
                    <div class="card-footer">
                        <asp:Button ID="cmdWorkFlow" CssClass="btn btn-primary" runat="server" Text="Work Flow Overview" />
                        <asp:Button ID="cmdEdit" CssClass="btn btn-primary" runat="server" Text="แก้ไขข้อมูลผู้ขอ" />
                    </div>
                </div>

                <div id="pnAssignment" runat="server" class="main-card mb-3 card">
                    <div class="card-header">
                        Assign ผู้ตรวจประเมิน
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-10">
                                <div class="form-group">
                                    <label>เลือกผู้ตรวจประเมิน</label><br />
                                    <asp:DropDownList ID="ddlSupervisor" runat="server" CssClass="form-control select2"></asp:DropDownList>


                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <br />
                                    <asp:Button ID="cmdAssign" CssClass="btn btn-success" runat="server" Text="เพิ่ม" Width="60px" />
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>

                                        <asp:GridView ID="grdSupervisor" CssClass="table table-hover"
                                            runat="server" CellPadding="0"
                                            GridLines="None"
                                            AutoGenerateColumns="False" Width="100%" AllowPaging="True">

                                            <Columns>
                                                <asp:BoundField DataField="nRow" HeaderText="No.">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />

                                                </asp:BoundField>

                                                <asp:BoundField DataField="SupervisorName" HeaderText="ผู้ตรวจประเมิน">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="ลบ">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgDel" runat="server" ImageUrl="images/delete.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle HorizontalAlign="Center"
                                                CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle CssClass="th" Font-Bold="True"
                                                VerticalAlign="Middle" HorizontalAlign="Left" />

                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="grdSupervisor" EventName="RowCommand" />
                                        <asp:AsyncPostBackTrigger ControlID="cmdAssign" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                    </div>
                    <div class="box-footer clearfix">
                        <asp:Button ID="cmdConfirmAssign" CssClass="btn btn-success" runat="server" Text="ส่งแจ้งผู้ตรวจประเมิน" />

                    </div>
                </div>

                <div id="pnDocument" runat="server" class="main-card mb-3 card">
                    <div class="card-header">
                        แนบไฟล์เอกสาร
                    </div>
                    <div class="card-body">
                        <div class="alert alert-primary text-center">
                               เอกสารที่ <b>ต้องแนบ</b> เพื่อการตรวจประเมิน  1.ใบอนุญาตขายยาประเภทต่างๆ ( ขย 5 / ยส./ วอ.) และเอกสารอื่นๆ เช่น ผลการประเมิน GPP ครั้งล่าสุด ( ถ้ามี )
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>ประเภทเอกสาร</label>
                                    <asp:DropDownList ID="ddlDocument" runat="server" CssClass="form-control select2">
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>
                                        ไฟล์ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2048 Kb." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                    </label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUploadA" runat="server" name="FileUpload1" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label></label>

                                    <asp:Button ID="cmdAddFile" CssClass="btn btn-success" runat="server" Text="เพิ่มเอกสาร" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:GridView ID="grdDocument" CssClass="table table-hover"
                                runat="server" CellPadding="0"
                                GridLines="None"
                                AutoGenerateColumns="False" Width="100%">

                                <Columns>
                                    <asp:BoundField DataField="nRow" HeaderText="No.">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Width="30px" />

                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="ชื่อเอกสาร">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# CPAQA.DocumentLocation & "/" & DataBinder.Eval(Container.DataItem, "LocationUID") & "/" & DataBinder.Eval(Container.DataItem, "FilePath") %>' Text='<%# DataBinder.Eval(Container.DataItem, "DocumentName") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ลบ">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDel" runat="server" ImageUrl="images/delete.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle HorizontalAlign="Center"
                                    CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle CssClass="th" Font-Bold="True"
                                    VerticalAlign="Middle" HorizontalAlign="Left" />


                            </asp:GridView>

                        </div>


                    </div>

                </div>
                <div id="pnPayment" runat="server" class="main-card mb-3 card">
                    <div class="card-header">
                        แนบหลักฐานการโอนเงิน
                    </div>
                    <div class="card-body">
                        <div class="alert alert-primary text-center">
                            โอนค่าธรรมเนียมเข้าบัญชี ธนาคารไทยพาณิชย์ เลขที่บัญชี <b>3402014548</b> ชื่อบัญชี สภาเภสัชกรรม&nbsp;
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>จำนวนเงิน</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control text-bold text-center text-primary"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text">฿</span>
                                        </div>
                                    </div>
                                </div>


                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>
                                        ไฟล์สลิปโอนเงิน 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                    </label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUpload1" runat="server" name="FileUpload1" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label></label>

                                    <asp:Button ID="cmdAddSlip" CssClass="btn btn-success pull-right" runat="server" Text="บันทึก" Width="100px" />
                                </div>

                            </div>

                            <div class="col-md-12">
                                <asp:GridView ID="grdSlip" CssClass="table table-hover"
                                    runat="server" CellPadding="0"
                                    GridLines="None"
                                    AutoGenerateColumns="False" Width="100%">

                                    <Columns>
                                        <asp:BoundField DataField="nRow" HeaderText="No.">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="30px" />

                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="หลักฐานการโอนเงิน">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# CPAQA.DocumentLocation & "/" & DataBinder.Eval(Container.DataItem, "LocationUID") & "/" & DataBinder.Eval(Container.DataItem, "FilePath") %>' Text='<%# DataBinder.Eval(Container.DataItem, "DocumentName") %>' Target="_blank"></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ลบ">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDel" runat="server" ImageUrl="images/delete.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle HorizontalAlign="Center"
                                        CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle CssClass="th" Font-Bold="True"
                                        VerticalAlign="Middle" HorizontalAlign="Left" />


                                </asp:GridView>

                            </div>
                        </div>
                    </div>

                </div>
            </section>
            <section class="col-lg-6 connectedSortable">
                <div class="main-card mb-3 card">
                    <div class="card-header">
                        ส่วนที่ต้องประเมิน/ขอเปลี่ยนแปลงข้อมูล
                    </div>
                    <div class="card-body">
                        <div id="pnAsmAll" runat="server" class="pb-2">
                            <table class="table table-bordered">
                                <tr>
                                    <th class="text-center">รายการประเมิน</th>
                                    <th class="text-center">คะแนนที่ได้</th>
                                    <th class="text-center">สถานะ</th>
                                    <th class="text-center"></th>
                                </tr>
                                <tr>
                                    <td>ส่วนที่ 1 : ข้อมูลร้านยา           </td>
                                    <td class="text-center">
                                        <asp:Label ID="lblLocScore" runat="server">ไม่มีคะแนน</asp:Label>
                                    </td>
                                    <td class="text-center">
                                        <asp:Label ID="lblLocStatus" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="text-center">
                                        <asp:HyperLink ID="btnAsmLocation" runat="server" class="btn btn-success" NavigateUrl="~/Location.aspx" Width="100px"><i class="fa fa-edit"></i>ประเมิน</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>ส่วนที่ 2 : การตรวจ  GPP</td>
                                    <td class="text-center">
                                        <asp:Label ID="lblGPPScore" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="text-center">
                                        <asp:Label ID="lblGPPStatus" runat="server" Text=""></asp:Label></td>
                                    <td class="text-center">
                                        <asp:HyperLink ID="btnAsmGPP" runat="server" class="btn btn-success" NavigateUrl="~/GPP.aspx" Width="100px"><i class="fa fa-edit"></i>ประเมิน</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>ส่วนที่ 3 : การประเมิน “ งานคุณภาพ ”</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">
                                        <asp:HyperLink ID="btnAsmQA" runat="server" class="btn btn-success" NavigateUrl="~/QA2.aspx" Width="100px"><i class="fa fa-edit"></i>ประเมิน</asp:HyperLink></td>
                                </tr>

                                <tr>
                                    <td style="padding-left: 30px;">3.1. สิ่งที่ทำ/โครงการที่ร่วมงาน (เต็ม 10 คะแนน)</td>
                                    <td class="text-center">
                                        <asp:Label ID="lblQAScore1" runat="server"></asp:Label>
                                    </td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 30px;">3.2. การจัดการความเสี่ยง (เต็ม 10 คะแนน)</td>
                                    <td class="text-center">
                                        <asp:Label ID="lblQAScore2" runat="server"></asp:Label>
                                    </td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 30px;">3.3. งานคุณภาพ (เพิ่มพิเศษ 5 คะแนน)</td>
                                    <td class="text-center">
                                        <asp:Label ID="lblQAScore3" runat="server"></asp:Label>
                                    </td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                </tr>

                                <tr>
                                    <td style="float: right;">สรุปคะแนนส่วนที่ 3 คิดเป็น</td>
                                    <td class="text-center">
                                        <asp:Label ID="lblQAScore" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="text-center">
                                        <asp:Label ID="lblQAStatus" runat="server" Text=""></asp:Label></td>
                                    <td class="text-center">&nbsp;</td>
                                </tr>
                                <tr>
    <td>ส่วนพิเศษ : ส่วนบริการตนเอง</td>
    <td class="text-center">&nbsp;</td>
    <td class="text-center">&nbsp;</td>
    <td class="text-center">
        <asp:HyperLink ID="btnAsmSelf" runat="server" class="btn btn-success" NavigateUrl="~/Self.aspx" Width="100px"><i class="fa fa-edit"></i>ประเมิน</asp:HyperLink></td>
</tr>

                                <tr>
                                    <td class="text-right text-bold">คะแนนรวม</td>
                                    <td class="text-center">
                                        <asp:Label ID="lblTotalAsmScore" runat="server" CssClass="text-success text-bold"></asp:Label>
                                    </td>
                                    <td class="text-center">&nbsp;</td>
                                    <td class="text-center">&nbsp;</td>
                                </tr>

                            </table>

                        </div>
                        <div id="pnAsmChange" runat="server">
                             <asp:Label ID="lblOld" runat="server" CssClass="text-blue text-bold" Text="ข้อมูลปัจจุบัน"></asp:Label>                    
                            <div id="pnAsmChangeNameO" runat="server" class="row">
                                <div class="col-md-12">
                                    <label>ชื่อร้านยา (เดิม) : </label>
                                    <asp:Label ID="lblLocationNameOld" runat="server" CssClass="text-bold" Text=""></asp:Label>
                                </div>
                            </div>
                            <div id="pnAsmChange4O" runat="server" class="row">
                                <div class="col-md-12">
                                    <label>ชื่อผู้มีหน้าที่ปฏิบัติการ (เดิม) : </label>
                                    <asp:Label ID="lblPharmacistLicenseOld" runat="server" CssClass="text-bold"></asp:Label>-
                                    <asp:Label ID="lblPharmacistOld" runat="server" CssClass="text-bold"></asp:Label>
                                </div>
                            </div>

                            <div id="pnAsmChange5O" runat="server" class="row">
                                <div class="col-md-6">
                                    <label>ชื่อผู้รับอนุญาต (เดิม) : </label>
                                    <asp:Label ID="lblLicenseeOld" runat="server" CssClass="text-bold"></asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <label>ประเภท (เดิม) : </label>
                                    <asp:Label ID="lblLicenseeTypeOld" runat="server" CssClass="text-bold"></asp:Label>

                                </div>
                            </div>
                              <asp:Label ID="lblNew" runat="server" CssClass="text-blue text-bold" Text="ขอเปลี่ยนใหม่เป็น"></asp:Label>                           
                            <div id="pnAsmChangeNameN" runat="server" class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>ชื่อร้านยา</label>
                                        <asp:TextBox ID="txtLocationName" runat="server" CssClass="form-control text-blue text-bold" placeholder=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="pnAsmChange4N" runat="server" class="row">
                                <div class="col-md-9">
                                    <label>ชื่อผู้มีหน้าที่ปฏิบัติการ (ใหม่) : </label>
                                    <asp:TextBox ID="txtPharmacistNew" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>เลขที่ใบอนุญาต: </label>
                                    <asp:TextBox ID="txtPharmacistLicenseNew" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div id="pnAsmChange9" runat="server" class="row">
                                <div class="col-md-9">
                                    <label>ชื่อผู้มีหน้าที่ปฏิบัติการ (เพิ่มใหม่) : </label>
                                    <asp:TextBox ID="txtPharmacistNewAdd" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>เลขที่ใบอนุญาต: </label>
                                    <asp:TextBox ID="txtPharmacistLicenseNewAdd" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <label>เวลาปฏิบัติการ: </label>
                                    <asp:TextBox ID="txtPharmacistTimeNew" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div id="pnAsmChange5N" runat="server" class="row">
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label>ชื่อผู้รับอนุญาต</label>
                                        <asp:TextBox ID="txtLicensee" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group mailbox-messages">
                                        <label>ประเภท</label>

                                        <asp:RadioButtonList ID="optLicenseeType" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">บุคคล</asp:ListItem>
                                            <asp:ListItem Value="2">นิติบุคคล/บริษัท</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center mt-2">
                                <asp:Button ID="cmdSaveUpdate" runat="server" CssClass="btn btn-success" Text="บันทึกรายการขอเปลี่ยนแปลง" />
                            </div>
                        </div>
                    </div>
                </div>

                <div id="pnCommentBack" runat="server" class="box box-solid">
                    <div class="box-header">
                        ส่งข้อความตอบกลับร้านยา
                 <div class="box-tools pull-right">
                     <button type="button" class="btn btn-box-tool" data-widget="collapse">
                         <i class="fa fa-minus"></i>
                     </button>
                 </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="scroll-area-sm">
                                    <asp:GridView ID="grdTemplate" CssClass="table table-hover"
                                        runat="server" CellPadding="0" GridLines="None" AutoGenerateColumns="False" Width="100%">

                                        <Columns>
                                            <asp:BoundField DataField="Descriptions" HeaderText="Template ข้อความ">
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />

                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="เลือก">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgSelect" runat="server" ImageUrl="images/select.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Descriptions") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle HorizontalAlign="Center" CssClass="dc_pagination dc_paginationC dc_paginationC01" />

                                        <HeaderStyle CssClass="th" Font-Bold="True" VerticalAlign="Middle" HorizontalAlign="Left" />

                                    </asp:GridView>
                                </div>
                            </div>


                        </div>


                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>ข้อความ</label>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grdTemplate" EventName="RowCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>สถานะคำขอ/การประเมิน</label>
                                    <asp:DropDownList ID="ddlStatusBack" runat="server" CssClass="form-control selectd2">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="box-footer text-center">
                        <asp:Button ID="cmdSendBack" CssClass="btn btn-primary" runat="server" Text="บันทึกข้อความตอบกลับ" />
                    </div>

                </div>

                 <div id="pnLitigation" runat="server" class="alert alert-danger">
                     <div class="text-bold">ประวัติคดีความ</div> <br />
            <asp:Label ID="lblLitigation" runat="server" Text="ไม่มี"></asp:Label>
        </div>

                <!-- Modal HTML -->
                <div id="modal-window-send" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <div class="modal-title"><span id="spnHeader"></span></div>
                            </div>
                            <div class="modal-body">
                                <h4>
                                    <p><span id="spnBodyMsg"></span>.</p>

                                </h4>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="cmdConfirm" runat="server" class="btn btn-primary" Text="ยืนยัน" Width="100" />
                                <button type="button" class="btn btn-secondary pull-right" data-dismiss="modal" width="100">ปิด</button>
                            </div>
                        </div>
                    </div>
                </div>

                 <div id="modal-window-changetype" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <div class="modal-title"><span id="spnHeaderChangeType"></span></div>
                            </div>
                            <div class="modal-body">                                
                                    <p><span id="spnBodyMsgChangeType"></span>  </p>  
                                
                                 <div class="row">
     <div class="col-md-12">
         <div class="form-group">
             <label>เลือกประเภทคำขอ</label><br />
             <asp:CheckBox ID="chkType1" runat="server" Text="ขอรับรองใหม่" /><br />
             <asp:CheckBox ID="chkType7" runat="server" Text="ขอรับรองใหม่ แบบมีเงื่อนไข" /><br />
             <asp:CheckBox ID="chkType2" runat="server" Text="ต่ออายุ" /><br />
             <asp:CheckBox ID="chkType3" runat="server" Text="ย้าย หรือ เปลี่ยนสถานที่" /><br />
             <asp:CheckBox ID="chkType6" runat="server" Text="เปลี่ยนชื่อร้านยา (สถานที่,ผู้รับอนุญาต และ เภสัชกร คงเดิม)" /><br />       
              <asp:CheckBox ID="chkType4" runat="server" Text="เปลี่ยนผู้มีหน้าที่ปฏิบัติการ" /><br />
              <asp:CheckBox ID="chkType9" runat="server" Text="เพิ่มผู้มีหน้าที่ปฏิบัติการ" /><br />                  
              <asp:CheckBox ID="chkType8" runat="server" Text="เปลี่ยนแปลงเวลาผู้มีหน้าที่ปฏิบัติการ" /><br />
              <asp:CheckBox ID="chkType5" runat="server" Text="เปลี่ยนผู้ดำเนินกิจการ/ผู้รับอนุญาต (สถานที่เดิม)" /><br />
         </div>
     </div>

 </div>


                                
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="cmdSaveChangeType" runat="server" class="btn btn-primary" Text="ยืนยัน" Width="100" />
                                <button type="button" class="btn btn-secondary pull-right" data-dismiss="modal" width="100">ปิด</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="modal-window-overview" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <div class="modal-title"><span id="spnHeaderOverview"></span></div>
                            </div>
                            <div class="modal-body">                                
                                    <p><span id="spnBodyMsgOverview"></span></p>  
                       <asp:GridView ID="grdOverview" CssClass="table table-hover"   runat="server" CellPadding="2"  GridLines="None"  AutoGenerateColumns="False"    Font-Bold="False">  
                        <columns>
                            <asp:BoundField DataField="CWhen" HeaderText="Date/time" >
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remark" HeaderText="Remark" ></asp:BoundField>
                            <asp:BoundField DataField="StatusName" HeaderText="Status" ></asp:BoundField>
                           <asp:BoundField DataField="DisplayName" HeaderText="User" ></asp:BoundField>                          
                        </columns>                                          
                        <pagerstyle HorizontalAlign="Center" 
                             CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                        <headerstyle Font-Bold="True" />
                     </asp:GridView>                                
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary pull-right" data-dismiss="modal" width="100">ปิด</button>
                            </div>
                        </div>
                    </div>
                </div>

                 <div id="modal-window-cancel" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <div class="modal-title"><span id="spnHeaderCancel"></span></div>
                            </div>
                            <div class="modal-body">                                
                                    <p><span id="spnBodyMsgCancel"></span> โปรดระบุเหตุผลในการยกเลิก </p>                            
                                <asp:TextBox ID="txtCancelRemark" runat="server" CssClass="form-control" placeholder="ระบุเหตุผล"></asp:TextBox>
                               
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="cmdConfirmCancel" runat="server" class="btn btn-primary" Text="ยืนยัน" Width="100" />
                                <button type="button" class="btn btn-secondary pull-right" data-dismiss="modal" width="100">ปิด</button>
                            </div>
                        </div>
                    </div>
                </div>
                 <div id="modal-window-alert" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <div class="modal-title"><span id="spnHeaderAlert"></span></div>
                            </div>
                            <div class="modal-body">                                
                                    <p><span id="spnBodyMsgAlert"></span> </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary pull-right" data-dismiss="modal" width="100">ปิด</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--- End Modal --->


            </section>
        </div>

        <div class="row">
            <section class="col-lg-12 connectedSortable">

                <div id="pnAudit" runat="server" class="box box-solid">
                    <div class="box-header">
                        บันทึกผลการตรวจเยี่ยมประเมิน (โดยผู้เยี่ยมประเมิน)
                 <div class="box-tools pull-right">
                     <button type="button" class="btn btn-box-tool" data-widget="collapse">
                         <i class="fa fa-minus"></i>
                     </button>
                 </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>สิ่งที่ต้องปรับปรุง แก้ไข</label>
                                    <asp:TextBox ID="txtAuditorComment1" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>ข้อเสนอแนะเพื่อการพัฒนา</label>
                                    <asp:TextBox ID="txtAuditorComment2" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>สิ่งที่ทำได้ดีเกินมาตรฐาน</label>
                                    <asp:TextBox ID="txtAuditorComment3" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>การสอบถาม สสจ.ในพื้นที่ (บางกรณี)</label>
                                    <asp:TextBox ID="txtAuditorComment4" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>งานที่ดีเด่นของร้าน ที่เป็นตัวอย่างที่ดี หรือ เป็นรูปแบบ / ต้นแบบ  หรือ นวัตกรรม (ร้านบอกเอง หรือ สรุปจากผู้ประเมิน )</label>
                                    <asp:TextBox ID="txtAuditorComment5" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12 text-bold">SWOT ของร้าน (โดย ผู้เยี่ยมประเมิน) </div>
                            <br />
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>S</label>
                                    <asp:TextBox ID="txtS" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>W</label>
                                    <asp:TextBox ID="txtW" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>O</label>
                                    <asp:TextBox ID="txtO" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>T</label>
                                    <asp:TextBox ID="txtT" runat="server" CssClass="form-control" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>


                <div id="pnFinal" runat="server" class="box box-solid">
                    <div class="box-header">
                        สถานะคำขอ/ผลการตรวจประเมิน
                 <div class="box-tools pull-right">
                     <button type="button" class="btn btn-box-tool" data-widget="collapse">
                         <i class="fa fa-minus"></i>
                     </button>
                 </div>
                    </div>
                    <div class="box-body app-page-header">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>สถานะคำขอ/การประเมิน</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control btn btn-primary selectd2">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>วันที่นัดสัมภาษณ์</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control text-center"
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
                                    <label>วันที่ผ่านการประเมินโดยผู้ตรวจประเมิน</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSupervisorDate" runat="server" CssClass="form-control text-center"
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
                                    <label>วันที่ผ่านคณะกรรมการรับรอง</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtPassDate" runat="server" CssClass="form-control text-center"
                                            autocomplete="off" data-date-format="dd/mm/yyyy"
                                            data-date-language="th-th" data-provide="datepicker"
                                            onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                         </div>
                            <div class="row">                         
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>เลขที่ใบรับรองร้านยาคุณภาพ</label>
                                    <asp:TextBox ID="txtAccLicense" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>Remark/รุ่น</label>
                                                        <asp:TextBox ID="txtAccRemark" runat="server" CssClass="form-control text-center" placeholder="หมายเหตุ/รุ่น/Remark"></asp:TextBox>
                                                    </div>
                              </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>วันที่อนุญาต</label>
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
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>วันที่สิ้นสุด</label>
                                    <div class="input-group">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtExpireDate" runat="server" CssClass="form-control text-center"
                                                    autocomplete="off" data-date-format="dd/mm/yyyy"
                                                    data-date-language="th-th" data-provide="datepicker"
                                                    onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="cmdAdd3Year" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                        <div class="input-group-append">
                                            <asp:Button ID="cmdAdd3Year" runat="server" class="input-group-text btn btn-success" Text="+3y" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                     <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) > 1 Then %>
                         <div class="row">
 <div class="col-md-2">
         <div class="form-group">
             <label>วิธีตรวจ</label>
             <asp:RadioButtonList ID="optAudit" runat="server" RepeatDirection="Vertical">
                  <asp:ListItem Value="1">On Site</asp:ListItem>
                  <asp:ListItem Value="2">Online</asp:ListItem>
                  <asp:ListItem Value="3">Hybrid</asp:ListItem>
             </asp:RadioButtonList>
         </div>
     </div>

                                <div class="col-md-10">
                                <div class="form-group">
                                    <label>หมายเหตุ</label>
                                    <asp:TextBox ID="txtAsmRemark" runat="server" TextMode="MultiLine" Height="80" CssClass="form-control" ></asp:TextBox>
                                </div>
                            </div>
                       
        
   </div>
                    <% End If %>
                    </div>
                </div>
                                
                <div class="box box-solid">                  
                    <div class="box-body alert alert-danger">
                        <div class="row">
                            <div class="col-md-12">
                                <span class="text-bold">โปรดอ่าน</span>
                                <br />
                                1. เมื่อร้านส่งคำขอเพื่อพิจารณา ร้านยาต้องพร้อมให้ตรวจได้ทันที <br />
                                2. กรณีผู้ประเมินขอข้อมูลเพิ่ม ให้รีบนำส่งเพิ่มทันที (ไม่เกิน 2 วัน)<br />
                                3. กรณีแก้ไข ให้ดำเนินการให้แล้วเสร็จใน 2 วัน<br /><br />

                               *** เนื่องจากเป็นกรณีเร่งด่วนของการตรวจประเมินคำขอ "ร้านยาคุณภาพ " ที่ต้องการให้ผ่านการตรวจประเมินเพื่อการสมัคร " ร้านยาจ่ายยาดูแล ผป. Common illness
                            </div>
                         </div>
                    </div>
                </div>

            </section>
        </div>
        <div class="row justify-content-center">

            <div class="col-md-12 text-center">
                <asp:Button ID="cmdSend" CssClass="btn btn-primary" runat="server" Text="ส่งเรื่องพิจารณา" />
                <asp:Button ID="cmdApprove" CssClass="btn btn-success" runat="server" Text="บันทึกผลการตรวจประเมิน" />
                <asp:Button ID="cmdCancel" CssClass="btn btn-danger" runat="server" Text="ยกเลิกคำขอ" Width="120px" />
                <asp:Button ID="cmdDelete" CssClass="btn btn-danger" runat="server" Text="Delete" Width="120px" />

            </div>
        </div>

    </section>
</asp:Content>
