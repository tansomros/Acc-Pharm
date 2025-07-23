<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ComplainDetail.aspx.vb" Inherits="CPAQA.ComplainDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-home icon-gradient bg-green"></i>
                </div>
                <div>
                    ข้อมูลข้อร้องเรียน
					<div class="page-title-subheading">บันทึกรายละเอียดข้อร้องเรียน </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <section class="col-lg-6 connectedSortable">
                <div class="justify-content-center">
                    <div class="col-lg-12">
                        <div class="main-card mb-3 card">
                            <div class="card-header">
                                รายละเอียดข้อร้องเรียน
                                     <asp:HiddenField ID="hdUID" runat="server" />
                                <div class="btn-actions-pane-right actions-icon-btn">
                                   เลขที่ : <asp:Label ID="lblCMPNO" runat="server" CssClass="text-bold text-primary" Text="Auto ID"></asp:Label>
                                    <asp:HiddenField ID="hdRefCode" runat="server"></asp:HiddenField>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>1.ช่องทางการแจ้งเรื่องร้องเรียน</label><br />
                                            <asp:DropDownList ID="ddlChannel" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>2.ชื่อผู้ร้องเรียน / ผู้แจ้งปัญหา</label>
                                            <asp:TextBox ID="txtInformer" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>เบอร์โทร</label>
                                            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>E-mail</label>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control special-letter"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-9">
                                        <div class="form-group">
                                            <label>หน่วยงานผู้ร้องเรียน</label>
                                            <asp:TextBox ID="txtInformerAddress" runat="server" CssClass="form-control" placeholder="ระบุ ร้าน /หน่วยงาน"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>จังหวัด</label><br />
                                            <asp:DropDownList CssClass="form-control select2" ID="ddlProvince" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label>3.ร้านที่ถูกร้องเรียน</label>
                                            <small>เลือกค้นหาร้านจากชื่อ/ขย.5/เลขที่ใบอนุญาต</small>
                                            <asp:DropDownList ID="ddlPharmacy" CssClass="form-control select2 btn btn-outline-primary" runat="server" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                               
                                <asp:UpdatePanel ID="UpdatePanelPharmacy" runat="server">
                                        <ContentTemplate>


 <div id="pnPharm" runat="server" class="app-page-header">
                                            <div class="row">

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>เลขที่ใบอนุญาต</label>
                                                        <asp:Label ID="lblLicense" runat="server" CssClass="text-bold"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>เลขที่ร้านยาคุณภาพ</label>
                                                        <asp:Label ID="lblAccLicense" runat="server" CssClass="text-bold"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>รหัสหน่วยบริการ</label>
                                                        <asp:Label ID="lblNHSOCode" runat="server" CssClass="text-bold"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label>ที่ตั้ง</label>
                                                        <asp:Label ID="lblAddress" runat="server" CssClass="text-bold"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                     
                                        </div>                                           
                               
                                  <div id="pnLoc" runat="server"  class="row">
      <div class="col-md-9">
          <div class="form-group">
              <label>ระบุชื่อร้าน/คลินิก/อื่นๆ</label>
              <asp:TextBox ID="txtLocationName" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
      </div>
                <div class="col-md-3">
      <div class="form-group">
          <label>จังหวัด</label><br />
          <asp:DropDownList CssClass="form-control select2" ID="ddlProvinceLocation" runat="server"></asp:DropDownList>
      </div>
  </div>
      <div class="col-md-12">
          <div class="form-group">
              <label>ที่อยู่</label>
              <asp:TextBox ID="txtLocationAddress" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
      </div> 
</div>
 </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlPharmacy" EventName="SelectedIndexChanged" />
                                        </Triggers>

                                    </asp:UpdatePanel>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>4.ชื่อผู้รับคำร้องเรียน</label>
                                            <asp:TextBox ID="txtReceiver" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>ตำแหน่ง</label>
                                            <asp:TextBox ID="txtReceiverPos" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>วันที่</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtReceiveDate" runat="server" CssClass="form-control text-center"
                                                    autocomplete="off" data-date-format="dd/mm/yyyy"
                                                    data-date-language="th-th" data-provide="datepicker"
                                                    onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>ประเด็นปัญหา/ข้อร้องเรียน</label>
                                            <asp:TextBox ID="txtCCRDetail" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="4000" Height="50" placeholder="รายละเอียดปัญหา/ข้อร้องเรียน"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>
                                                5.หลักฐานประกอบคำร้องเรียน (ถ้ามี)
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                            </label>
                                            <div class="file-upload">
                                                <asp:FileUpload ID="FileUpload1" runat="server" name="FileUpload1" AllowMultiple="true" />
                                                <i class="fa fa-camera"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label></label>
                                            <br />
                                            <asp:Button ID="cmdUpload1" CssClass="btn btn-success" runat="server" Text="Upload" />
                                        </div>
                                    </div>
                                </div> 
                                    <div class="row app-header-primary">
                                        <asp:UpdatePanel ID="UpdatePanelImg1" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="dtlImg1" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                                    <ItemTemplate> 
                                                        <div class="pl-0">                                                    
                                                            <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>'  Height="30"></asp:ImageButton>
                                                  </div>
                                                        <div style="margin:-40px 0 0 0px">   
                                                            <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="cmdUpload1" />
                                                <asp:AsyncPostBackTrigger ControlID="dtlImg1" EventName="ItemCommand" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                               </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="col-lg-6 connectedSortable">

                <div class="box box-solid">
                    <div class="box-header">
                        เรื่องร้องเรียน
                 <div class="box-tools pull-right">
                     <button type="button" class="btn btn-box-tool" data-widget="collapse">
                         <i class="fa fa-minus"></i>
                     </button>
                 </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <label>6.1.มาตรฐานของร้านยาคุณภาพ</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>หลักฐานการร้องเรียน</label>
                                    <asp:RadioButtonList ID="optEvidence" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="Y">มีหลักฐาน</asp:ListItem>
                                        <asp:ListItem Value="N">ไม่มีหลักฐาน/บัตรสนเท่ห์</asp:ListItem>
                                         <asp:ListItem Value="X">ไม่ใช่มาตรฐานร้านยาคุณภาพ</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>รูปหลักฐาน</label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUpload2" runat="server" name="FileUpload2" AllowMultiple="true" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:Button ID="cmdUpload2" CssClass="btn btn-success" runat="server" Text="Upload" />
                                </div>

                            </div>
                        </div>
                              <div class="row app-header-primary m-0">
                                        <asp:UpdatePanel ID="UpdatePanelImg2" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="dtlImg2" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                                    <ItemTemplate> 
                                                        <div class="pl-0">                                                    
                                                            <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>'  Height="30"></asp:ImageButton>
                                                  </div>
                                                        <div style="margin:-40px 0 0 0px">   
                                                            <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="cmdUpload2" />
                                                <asp:AsyncPostBackTrigger ControlID="dtlImg2" EventName="ItemCommand" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>ปัญหาที่ร้องเรียน</label><br />
                                    <asp:DropDownList ID="ddlProblem" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>ระบุ</label>
                                    <asp:TextBox ID="txtProblemOther" runat="server" CssClass="form-control" placeholder="ระบุกรณี อื่นๆ" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>การส่งสำนักงานรับรองร้านยาคุณภาพ</label>
                                    <asp:RadioButtonList ID="optRefer" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="Y">ส่ง</asp:ListItem>
                                        <asp:ListItem Value="N">ไม่ส่ง/ปิดเรื่อง</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>เมื่อวันที่</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtReferDate" runat="server" CssClass="form-control text-center"
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
                                    <label>ระบุ</label>
                                    <asp:TextBox ID="txtReferRemark" runat="server" CssClass="form-control" placeholder="ระบุกรณี ไม่ส่ง/ปิดเรื่อง" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>


                        </div>

                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>6.2.ระบุบริการ หรือ โครงการที่ร้องเรียน</label>
                                    <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>ระบุบริการอื่นๆ</label>
                                    <asp:TextBox ID="txtProjectOther" runat="server" CssClass="form-control" placeholder="ระบุบริการ/โครงการอื่นๆ" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>6.3.	ระบุเรื่องร้องเรียนตามมาตรฐานและการบริการของร้านยา ดังนี้</label>
                                    <asp:CheckBoxList ID="chkComp" runat="server" RepeatColumns="1" RepeatDirection="Vertical"></asp:CheckBoxList>

                                </div>
                            </div>

                        </div>
                        <div class="row">

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>รายละเอียดอื่นๆ ประกอบคำร้องเรียน( เพิ่มเติม )</label>
                                    <asp:TextBox ID="txtComplaint" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>7.ส่งคณะทำงานแสวงหาฯ เมื่อวันที่</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtTeamDate" runat="server" CssClass="form-control text-center"
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
                                        <asp:FileUpload ID="FileUpload3" runat="server" name="FileUpload3" AllowMultiple="true" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:Button ID="cmdUpload3" CssClass="btn btn-success" runat="server" Text="Upload" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>รายละเอียดเพิ่มเติม</label>
                                    <asp:TextBox ID="txtTeamRemark" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="row app-header-primary m-0">
                                        <asp:UpdatePanel ID="UpdatePanelImg3" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="dtlImg3" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                                    <ItemTemplate> 
                                                        <div class="pl-0">                                                    
                                                            <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>'  Height="30"></asp:ImageButton>
                                                  </div>
                                                        <div style="margin:-40px 0 0 0px">   
                                                            <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="cmdUpload3" />
                                                <asp:AsyncPostBackTrigger ControlID="dtlImg3" EventName="ItemCommand" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>8.รายละเอียดการแสวงหา สืบค้น</label>
                                    <asp:TextBox ID="txtFindRemark" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-7">
                                <div class="form-group">
                                    <label>
                                        เลือกรูป
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                    </label>
                                    <div class="file-upload">
                                        <asp:FileUpload ID="FileUpload4" runat="server" AllowMultiple="true" />
                                        <i class="fa fa-camera"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:Button ID="cmdUpload4" runat="server" Text="Upload" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>
                         <div class="row app-header-primary m-0">
                                        <asp:UpdatePanel ID="UpdatePanelImg4" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="dtlImg4" CssClass="table table-hover no-border" RepeatDirection="Horizontal" runat="server" CellPadding="5" CellSpacing="10" Height="40px">
                                                    <ItemTemplate> 
                                                        <div class="pl-0">                                                    
                                                            <asp:ImageButton ID="imgView" runat="server" ImageUrl='<%# IIf(DataBinder.Eval(Container.DataItem, "FileType") = "img", DataBinder.Eval(Container.DataItem, "FilePathView"), "images/file.png") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>'  Height="30"></asp:ImageButton>
                                                  </div>
                                                        <div style="margin:-40px 0 0 0px">   
                                                            <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/cancel.png" Height="14" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="cmdUpload4" />
                                                <asp:AsyncPostBackTrigger ControlID="dtlImg4" EventName="ItemCommand" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                    </div>
                    <div class="box-footer">
                        <asp:Label ID="lblNoSuccess" runat="server" ForeColor="Red" Text="Upload รูปไม่สำเร็จ กรุณาตรวจสอบไฟล์ แล้วลองใหม่อีกครั้ง" Visible="False"></asp:Label>
                        <br />
                    </div>
                </div>
            </section>

        </div>
        <div class="row">
            <section class="col-lg-12 connectedSortable">

                <div class="main-card mb-3 card">
                    <div class="card-header">
                        สรุปผลการแสวงหาข้อเท็จจริง
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>9.วันที่คณะทำงานสรุป</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtResultDate" runat="server" CssClass="form-control text-center"
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
                                    <label>10.วันที่คณะอนุกรรมการฯสรุป</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSubCommDate" runat="server" CssClass="form-control text-center"
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
                                    <label>ผลการสรุป</label>
                                    <asp:RadioButtonList ID="optResult" runat="server">
                                        <asp:ListItem Value="0">ไม่มีมูลความจริง</asp:ListItem>
                                        <asp:ListItem Value="1">เป็นเรื่องจริงตามข้อร้องเรียน ระบุความรุนแรง / ผลกระทบ </asp:ListItem>
                                        <asp:ListItem Value="99">อื่น ๆ</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>ระดับความรุนแรง/ผลกระทบ</label>
                                    <asp:RadioButtonList ID="optLevel" runat="server" RepeatDirection="Vertical">
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>ระบุ</label>
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>11.การพิจารณาดำเนินการ</label><br />
                                    <asp:CheckBoxList ID="chkResult" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">จำหน่าย</asp:ListItem>
                                        <asp:ListItem Value="2">ตักเตือน  ด้วยวาจา</asp:ListItem>
                                        <asp:ListItem Value="3">ตักเตือน  ด้วยจดหมาย</asp:ListItem>
                                        <asp:ListItem Value="4">เสนอกรรมการสภาเภสัชกรรม</asp:ListItem>
                                        <asp:ListItem Value="5">แจ้งให้หยุดการบริการ</asp:ListItem>
                                        <asp:ListItem Value="6">ส่งเรื่อง สปสช. (ระบุหน่วยงาน)</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>ตักเตือนโดย</label>
                                    <asp:TextBox ID="txtCautionBy" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>หน่วยงาน สปสช.</label>
                                    <asp:TextBox ID="txtNHSORemark" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>วันที่ให้หยุดบริการ</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtStopDate" runat="server" CssClass="form-control text-center"
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
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>12.เข้าคณะกรรมการสภาฯ ครั้งที่</label>
                                    <asp:TextBox ID="txtRound" runat="server" CssClass="form-control text-center" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>วันที่เข้าคณะกรรมการสภาฯ</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtCommitteeDate" runat="server" CssClass="form-control text-center"
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
                                    <label>13.ผลการพิจารณา</label>
                                    <asp:RadioButtonList ID="optFinalResult" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">ดำเนินการจรรยาบรรณ</asp:ListItem>
                                        <asp:ListItem Value="2">แจ้งอนุกรรมการดำเนินการ</asp:ListItem>
                                        <asp:ListItem Value="99">อื่นๆ</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>ระบุ</label>
                                    <asp:TextBox ID="txtFinalRemark" runat="server" CssClass="form-control text-center" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>14.วันที่อนุกรรมการฯ ดำเนินการตามมติ</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtFinalDate" runat="server" CssClass="form-control text-center"
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
                                    <label>15.ปิดข้อร้องเรียน</label>
                                    <div class="button r" id="button-1">
                                        <input id="chkClose" type="checkbox" class="checkbox" runat="server">
                                        <div class="knobs"></div>
                                        <div class="layer"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>วันที่ปิด</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtCloseDate" runat="server" CssClass="form-control text-center"
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
                                    <label>ผู้ดำเนินการปิด</label><br />
                                    <asp:DropDownList ID="ddlCloseBy" runat="server" CssClass="form-control select2">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>ปิดโดย (ระบุ)</label><br />
                                    <asp:TextBox ID="txtCloseRemark" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="justify-content-center">
                    <div class="row justify-content-center">
                        <asp:Button ID="cmdSave" runat="server" Width="120" CssClass="btn btn-primary" Text="บันทึก" />
                        <asp:Button ID="cmdDelete" runat="server" Width="120" CssClass="btn btn-danger" Text="ลบ" />
                        <a href="Complain?m=cmp&s=list" class="btn btn-secondary">กลับหน้ารายการ</a>
                    </div>
                    <br />
                </div>
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
    </section>
</asp:Content>
