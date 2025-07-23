<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="LocationModify.aspx.vb" Inherits="CPAQA.LocationModify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBfMj6L9aj4d2o6a_vxYVLYC2nrwnCjXFg&callback=initMap"></script>
    <script type="text/javascript">          
        function openModalUploadCCR(sender, id) {
            $('#modal-window-ccr').modal('show');
            return false;
        }
        function openModalUploadWarning(sender, id) {
            $('#modal-window-warning').modal('show');
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-home icon-gradient bg-green"></i>
                </div>
                <div>
                    ข้อมูลร้านยา
					<div class="page-title-subheading">จัดการรายละเอียดข้อมูลร้านยา </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <section class="col-lg-9 connectedSortable">
                <div class="justify-content-center">
                    <div class="col-lg-12">
                        <div class="main-card mb-3 card">
                            <div class="card-header">
                                <i class="header-icon lnr-store icon-gradient bg-mixed-hopes"></i>ข้อมูลร้านยา<asp:HiddenField ID="hdLocationUID" runat="server" />
                                <div class="btn-actions-pane-right actions-icon-btn">
                                    <asp:HyperLink ID="lnkFDA" runat="server" Target="_blank" CssClass="btn btn-primary small"><img src="images/fdalogo.png" width="20" /> คลิกดูข้อมูลใบอนุญาตจาก อย.</asp:HyperLink>
                                    <asp:HiddenField ID="hdNewCode" runat="server"></asp:HiddenField>
                                </div>
                            </div>
                            <div class="card-body p-0">                             
                                        <div class="bg-primary-light">
                                            <div class="row pl-2 pr-2 pt-2">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>เลขที่ใบอนุญาต ขย 5</label>
                                                        <asp:TextBox ID="txtLicenseNo1" runat="server" CssClass="form-control text-blue text-bold text-center" ReadOnly="true" Enabled="false" BackColor="White"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-9">
                                                    <div class="form-group">
                                                        <label>ชื่อร้านยา</label>
                                                        <asp:TextBox ID="txtLocationName" runat="server" CssClass="form-control text-blue text-bold" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>              
                                            </div>
                                            <div class="row pl-2 pr-2">
                                                <div class="col-md-5">
                                                    <div class="form-group">
                                                        <label>สถานที่ตั้งเลขที่</label>
                                                        <asp:TextBox ID="txtAddressNo" runat="server" CssClass="form-control" placeholder="เลขที่ตั้ง/บ้านเลขที่"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label>หมู่</label>
                                                        <asp:TextBox ID="txtMoo" runat="server" CssClass="form-control" placeholder="หมู่"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="form-group">
                                                        <label>ถนน</label>
                                                        <asp:TextBox ID="txtRoad" runat="server" CssClass="form-control" placeholder="ถนน/ซอย"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row pl-2 pr-2">

                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>แขวง/ตำบล</label>
                                                        <asp:TextBox ID="txtSubDistrict" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>เขต/อำเภอ</label>
                                                        <asp:Label ID="lblDistrict" runat="server" CssClass="text-blue"></asp:Label>
                                                        <asp:DropDownList CssClass="form-control select2" ID="ddlDistrict" runat="server"></asp:DropDownList>

                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>จังหวัด</label><br />
                                                        <asp:DropDownList CssClass="form-control select2" ID="ddlProvince" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>รหัสไปรษณีย์</label>
                                                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" MaxLength="5"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row pl-2 pr-2">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>ชื่อผู้ดำเนินกิจการ</label>
                                                        <asp:TextBox ID="txtAuthName" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
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
                                            <div class="row pl-2 pr-2">
                                                <div class="col-md-8">
                                                    <div class="form-group">
                                                        <label>ผู้มีหน้าที่ปฏิบัติการ</label>
                                                        <asp:TextBox ID="txtPharmacist" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group mailbox-messages">
                                                        <label>เลขใบประกอบฯ (เฉพาะตัวเลข)</label>
                                                        <asp:TextBox ID="txtPharmacistLicenseNo" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            </div>
                                            <div class="row pl-2 pr-2 pt-2">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>เบอร์โทร</label>
                                                        <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>E-mail</label>
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control special-letter"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label>Line ID</label>
                                                        <asp:TextBox ID="txtLineID" runat="server" CssClass="form-control special-letter"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>Facebook</label>
                                                        <asp:TextBox ID="txtFacebook" runat="server" CssClass="form-control special-letter"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row pl-2 pr-2">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>ละติจูด,ลองติจูด</label>
                                                        <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ละติจูด/ลองติจูด ในรูปแบบองศาทศนิยมเท่านั้น และคั่นชุดข้อมูลด้วยคอมม่า (,)" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper" data-toggle="tooltip" data-placement="top" data-original-title="ละติจูด/ลองติจูด ในรูปแบบองศาทศนิยมเท่านั้น และคั่นชุดข้อมูลด้วยคอมม่า (,)"></i></button>

                                                        <asp:TextBox ID="txtLat" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>เวลาทำการร้าน</label>
                                                        <asp:TextBox ID="txtWorkTime" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="row pl-2 pr-2">

                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>เลขที่ใบอนุญาตขายยาเสพติดให้โทษประเภท 3</label>
                                                        <asp:TextBox ID="txtLicenseNo2" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>เลขที่ใบอนุญาตจำหน่ายวัตถุออกฤทธิ์ต่อจิตประสาท</label>
                                                        <asp:TextBox ID="txtLicenseNo3" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row pl-2 pr-2">
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label>จำนวนคูหา</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtArea1" runat="server" CssClass="form-control text-center"></asp:TextBox>

                                                        </div>


                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label>พื้นที่ (ตร.ม.)</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtArea2" runat="server" CssClass="form-control text-center"></asp:TextBox>

                                                        </div>


                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>กลุ่มร้านยา</label><br />
                                                        <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True" CssClass="form-control select2"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>Chain/มีสาขา</label>
                                                        <asp:UpdatePanel ID="udpChain" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlChain" runat="server" CssClass="form-control select2">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>


                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row pl-2 pr-2">
                                                <div class="col-md-8">
                                                    <div class="form-group">
                                                        <label>ประเภทร้านยา</label>
                                                        <asp:CheckBoxList ID="chkLocationType" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>รหัสหน่วยบริการ สปสช.</label>
                                                        <asp:TextBox ID="txtNHSOCode" runat="server" CssClass="form-control text-center" placeholder="Dxxxx"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 3 Then %>
                                            <div class="row pl-2 pr-2">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>Active</label>
                                                        <div class="button r" id="button-2">
                                                            <input id="chkStatus" type="checkbox" class="checkbox" runat="server" checked="checked">
                                                            <div class="knobs"></div>
                                                            <div class="layer"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>อนุญาตให้ สสจ.เห็น</label>
                                                        <div class="button r" id="button-3">
                                                            <input id="chkPPH" type="checkbox" class="checkbox" runat="server">
                                                            <div class="knobs"></div>
                                                            <div class="layer"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <% End If %>
                                        </div>
                                
                            
                        </div>


                        <div id="pnPharmacist" runat="server" class="box box-solid">
                            <div class="box-header">
                                เภสัชกรประจำร้าน
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body">


                                <asp:UpdatePanel ID="UpdatePanelPharmacistAdd" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label>ชื่อ-นามสกุล</label>
                                                    <asp:HiddenField ID="hdPharmacistUID" runat="server" />
                                                    <asp:TextBox ID="txtPName" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>เลขใบประกอบโรคศิลปะ</label>
                                                    <asp:TextBox ID="txtPLicense" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-5">
                                                <div class="form-group">
                                                    <label>ประเภท (ร้านยาเพิ่มได้เฉพาะ Part Time เท่านั้น)</label><br />
                                                    <asp:DropDownList ID="ddlPType" runat="server" CssClass="form-control select2">
                                                        <asp:ListItem Value="1" Text="Full Time"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Part Time"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="app-page-header">
                                            <div class="row">
                                                <div class="col-md-12 text-blue text-bold">เวลาปฏิบัติการ</div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>วัน</label>
                                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" Text="ทุกวัน" />
                                                        <asp:CheckBox ID="chkNon" runat="server" Text="เฉพาะวันที่เภสัชกรหยุด/ไม่แน่นอน (Part time)" />
                                                        <asp:CheckBoxList ID="chkDay" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="อาทิตย์" Value="SUN"></asp:ListItem>
                                                            <asp:ListItem Text="จันทร์" Value="MON"></asp:ListItem>
                                                            <asp:ListItem Text="อังคาร" Value="TUE"></asp:ListItem>
                                                            <asp:ListItem Text="พุธ" Value="WED"></asp:ListItem>
                                                            <asp:ListItem Text="พฤหัสบดี" Value="THU"></asp:ListItem>
                                                            <asp:ListItem Text="ศุกร์" Value="FRI"></asp:ListItem>
                                                            <asp:ListItem Text="เสาร์" Value="SAT"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label>เริ่มเวลา</label>
                                                        <br />
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlStartHH" runat="server" Width="70" CssClass="form-control select2">
                                                                        <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                <td>&nbsp;:&nbsp;</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlStartMM" runat="server" Width="70" CssClass="form-control select2">
                                                                        <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                                                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                                                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                                                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                                                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                                        <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                                                        <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                                                        <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                                                        <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                                                        <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                                                        <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                                                        <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                                                        <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                                                        <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                                                        <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                                                        <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                                                        <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                                                        <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                                                        <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                                                        <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                                        <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                                                        <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                                                        <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                                                        <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                                        <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                                                        <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                                                        <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                                                        <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                                                        <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                                                        <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                                                        <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                                                        <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                                                        <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                        </table>


                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label>ถึงเวลา</label><br />
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEndHH" runat="server" Width="70" CssClass="form-control select2">
                                                                        <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                <td>&nbsp;:&nbsp;</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEndMM" runat="server" Width="70" CssClass="form-control select2">
                                                                        <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                                                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                                                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                                                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                                                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                                        <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                                                        <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                                                        <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                                                        <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                                                        <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                                                        <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                                                        <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                                                        <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                                                        <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                                                        <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                                                        <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                                                        <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                                                        <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                                                        <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                                                        <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                                        <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                                                        <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                                                        <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                                                        <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                                        <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                                                        <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                                                        <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                                                        <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                                                        <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                                                        <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                                                        <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                                                        <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                                                        <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <br />
                                                    <asp:Button ID="cmdSaveTime" runat="server" Text="เพิ่ม" Width="80" CssClass="btn btn-success mt-2" />
                                                </div>



                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <br />
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdTime" CssClass="table table-hover"
                                                                runat="server" CellPadding="2"
                                                                GridLines="None"
                                                                AutoGenerateColumns="False"
                                                                Font-Bold="False">
                                                                <RowStyle BackColor="#F7F7F7" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgDelT" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/delete.png" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="30px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="WorkDay" HeaderText="วัน">
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="WorkTime" HeaderText="เวลา"></asp:BoundField>
                                                                </Columns>
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle HorizontalAlign="Center"
                                                                    CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle Font-Bold="True" BackColor="White" />
                                                                <EditRowStyle BackColor="#2461BF" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>

                                                            <asp:AsyncPostBackTrigger ControlID="cmdSaveTime" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="grdTime" EventName="RowCommand" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <br />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>
                                                        รูปเภสัชกร
                                                        <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1 MB. เพิ่มได้ไม่เกิน 1 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                                        <span class="text-red">(ให้เพิ่มเวลาปฏิบัติการให้เรียบร้อยก่อนค่อย Browse เลือกรูปแล้วกดบันทึก)</span>
                                                    </label>
                                                    <div class="file-upload">
                                                        <asp:FileUpload ID="FileUploadP" runat="server" />
                                                        <i class="fa fa-camera"></i>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row justify-content-center">
                                            <div class="col-md-12 text-center">
                                                <div class="form-group">
                                                    <br />
                                                    <asp:Button ID="cmdAddPharmacist" runat="server" Text="บันทึก" Width="80" CssClass="btn btn-primary" />
                                                    <asp:Button ID="cmdClearPharmacist" runat="server" Text="ยกเลิก" Width="80" CssClass="btn btn-secondary" />
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>

                                        <asp:AsyncPostBackTrigger ControlID="cmdAddPharmacist" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="grdPharmacist" EventName="RowCommand" />

                                    </Triggers>
                                </asp:UpdatePanel>
                                <div class="row">

                                    <div class="col-md-12">
                                        <asp:UpdatePanel ID="UpdatePanelPharmacistList" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdPharmacist" CssClass="table table-hover" runat="server" CellPadding="2" GridLines="None" AutoGenerateColumns="False" Font-Bold="False">
                                                    <RowStyle BackColor="#F7F7F7" />
                                                    <Columns>
                                                        <asp:BoundField DataField="nRow" HeaderText="No.">
                                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="PharmacistName" HeaderText="ชื่อ-นามสกุล">
                                                            <HeaderStyle HorizontalAlign="Left" />

                                                            <ItemStyle Width="250px" />

                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="License" HeaderText="เลขใบประกอบโรคศิลปะ">
                                                            <HeaderStyle HorizontalAlign="Left" />

                                                            <ItemStyle Width="100px" />

                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="WorkTypeName" HeaderText="ประเภท">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle Width="85px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="WorkTimeList" HeaderText="เวลาปฏิบัติงาน">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="imgEdit" runat="server" Text="แก้ไข" CssClass="btn btn-primary" Width="50"
                                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                                <asp:LinkButton ID="imgDel" runat="server" Text="ลบ" CssClass="btn btn-danger" Width="40"
                                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="170px" />
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

                                                <asp:AsyncPostBackTrigger ControlID="cmdAddPharmacist" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="grdPharmacist" EventName="RowCommand" />
                                                <asp:AsyncPostBackTrigger ControlID="grdImgPharmacist" EventName="RowCommand" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>
                            </div>
                        </div>


                        <div id="pnDocument" runat="server" class="main-card mb-3 card">
                            <div class="card-header">
                                อัพโหลดไฟล์เอกสาร
                            </div>
                            <div class="card-body">
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
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                            </label>
                                            <div class="file-upload">
                                                <asp:FileUpload ID="FileUpload1" runat="server" name="FileUpload1" />
                                                <i class="fa fa-camera"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label></label>
                                            <br />
                                            <asp:Button ID="cmdAddFile" CssClass="btn btn-success" runat="server" Text="เพิ่มเอกสาร" />
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanelDocument" runat="server">
                                        <ContentTemplate>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="cmdAddFile" />
                                            <asp:AsyncPostBackTrigger ControlID="grdDocument" EventName="RowCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>


                            </div>

                        </div>

                    </div>
                    <div class="col-lg-12">

                        <div class="justify-content-center">

                            <div id="pnRisk" runat="server" class="box box-solid">
                                <div class="box-header bg-warning-light">
                                    ข้อมูลการเฝ้าระวัง/ความเสี่ยง (ร้านยาไม่เห็น)
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
                                                <label>ความเสี่ยง</label>
                                                <asp:DropDownList ID="ddlRiskLevel" runat="server" CssClass="form-control select2">
                                                    <asp:ListItem Selected="True" Value="0">ไม่เสี่ยง</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>วันที่</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtRiskDate" runat="server" CssClass="form-control text-center"
                                                        autocomplete="off" data-date-format="dd/mm/yyyy"
                                                        data-date-language="th-th" data-provide="datepicker"
                                                        onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                                    <div class="input-group-append">
                                                        <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                <label>รายละเอียด</label>
                                                <asp:TextBox ID="txtRiskDetail" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50" placeholder="ระบุรายละเอียด/Note"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2 pt-2">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button ID="cmdAddRisk" CssClass="btn btn-success" runat="server" Text="เพิ่มความเสี่ยง" />

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-md-12">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdRisk" CssClass="table table-hover"
                                                        runat="server" CellPadding="0"
                                                        GridLines="None"
                                                        AutoGenerateColumns="False" Width="100%">

                                                        <Columns>
                                                            <asp:BoundField DataField="nRow" HeaderText="No.">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="RiskDate" HeaderText="วันที่">
                                                                <ItemStyle Width="150px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="LevelNo" HeaderText="ระดับ" />
                                                            <asp:BoundField DataField="Descriptions" HeaderText="รายะละเอียด" />
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
                                                    <asp:AsyncPostBackTrigger ControlID="cmdAddRisk" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="grdRisk" EventName="RowCommand" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                </div>
                                <div class="box-footer bg-warning-light">
                                    ความเสี่ยง :  
                                    <br />
                                    1 = รุนแรงน้อย ควรตรวจ GPP ซ้ำบางประเด็น   
                                    <br />
                                    2 = ปานกลาง  อาจมีความผิดปกติ สงสัยเภสัชฯ แขวนป้าย / จ่ายยาอันตรายโดยพนักงาน  
                                     <br />
                                    3 = รุนแรงมาก   ค่อนข้างมั่นใจว่าเป็นร้านแขวนป้าย / จำหน่ายยากลุ่มเสี่ยง
                                </div>
                            </div>
                            <div id="pnCCR" runat="server" class="box box-solid">
                                <div class="box-header bg-danger-light">
                                    ข้อมูลประวัติปัญหา/คำร้องเรียน (ร้านยาไม่เห็น)
                 <div class="box-tools pull-right">
                     <button type="button" class="btn btn-box-tool" data-widget="collapse">
                         <i class="fa fa-minus"></i>
                     </button>
                 </div>
                                </div>
                                <div class="box-body">
                                    <div class="row" id="pnCCRInput" runat="server">

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label>วันที่</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtCCRDate" runat="server" CssClass="form-control text-center"
                                                        autocomplete="off" data-date-format="dd/mm/yyyy"
                                                        data-date-language="th-th" data-provide="datepicker"
                                                        onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                                    <div class="input-group-append">
                                                        <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="form-group">
                                                <label>รายละเอียดปัญหา/ข้อร้องเรียน</label>
                                                <asp:TextBox ID="txtCCRDetail" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50" placeholder="รายละเอียดปัญหา/ข้อร้องเรียน"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div class="form-group">
                                                <label>
                                                    ไฟล์ 
                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                                </label>
                                                <div class="file-upload">
                                                    <asp:FileUpload ID="FileUploadCCR" runat="server" name="FileUploadCCR" AllowMultiple="true" />
                                                    <i class="fa fa-camera"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2 pt-2">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button ID="cmdAddCCR" CssClass="btn btn-success" runat="server" Text="เพิ่มปัญหา/คำร้องเรียน" />

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdCCR" CssClass="table table-hover"
                                                        runat="server" CellPadding="0"
                                                        GridLines="None"
                                                        AutoGenerateColumns="False" Width="100%">

                                                        <Columns>
                                                            <asp:BoundField DataField="nRow" HeaderText="No.">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="CCRDate" HeaderText="วันที่">
                                                                <ItemStyle Width="150px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Descriptions" HeaderText="ปัญหา/คำร้องเรียน" />
                                                            <asp:TemplateField HeaderText="ไฟล์แนบ">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgCCR" runat="server" ImageUrl="images/view.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'></asp:ImageButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="80px" HorizontalAlign="Center" />
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
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="cmdAddCCR" />
                                                    <asp:AsyncPostBackTrigger ControlID="grdCCR" EventName="RowCommand" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                </div>
                            </div>



                            <div id="pnWarning" runat="server" class="box box-solid">
                                <div class="box-header bg-primary-light">
                                    ข้อมูลประวัติการตักเตือนจาก สรร. (ร้านยาไม่เห็น)
                 <div class="box-tools pull-right">
                     <button type="button" class="btn btn-box-tool" data-widget="collapse">
                         <i class="fa fa-minus"></i>
                     </button>
                 </div>
                                </div>
                                <div class="box-body">
                                    <div class="row" id="pnWarningInput" runat="server">

                                        <div class="col-md-1">
                                            <div class="form-group">
                                                <label>ครั้งที่</label>
                                                <asp:TextBox ID="txtWarnSeqNo" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label>วันที่</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtWarningDate" runat="server" CssClass="form-control text-center"
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
                                                 <label>ประเด็น</label>
                                                 <asp:DropDownList CssClass="form-control select2" ID="ddlWarningType" runat="server"></asp:DropDownList>
                                             </div>
                                         </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>อื่นๆ ระบุ</label>
                                                <asp:TextBox ID="txtWarningDesc" runat="server" CssClass="form-control" placeholder="เรื่องตักเตือนอื่นๆ โปรดระบุ"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>เลขที่หนังสือ</label>
                                                <asp:TextBox ID="txtWarningNo" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>หมายเหตู</label>
                                                <asp:TextBox ID="txtWarnRemark" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div class="form-group">
                                                <label>
                                                    ไฟล์ 
                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .docx,.pdf เท่านั้น ,ขนาดไฟล์ไม่เกิน 2 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                                </label>
                                                <div class="file-upload">
                                                    <asp:FileUpload ID="FileUploadWarning" runat="server" name="FileUploadWarning" AllowMultiple="true" />
                                                    <i class="fa fa-camera"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2 pt-2">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button ID="cmdAddWarning" CssClass="btn btn-success" runat="server" Text="เพิ่มเรื่องตักเตือน" />

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdWarning" CssClass="table table-hover"
                                                        runat="server" CellPadding="0"
                                                        GridLines="None"
                                                        AutoGenerateColumns="False" Width="100%">

                                                        <Columns>
                                                            <asp:BoundField DataField="SeqNo" HeaderText="No.">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="WarnDate" HeaderText="วันที่">
                                                                <ItemStyle Width="150px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="WarningTypeName" HeaderText="ประเด็น" />
                                                            <asp:BoundField DataField="DocNo" HeaderText="เลขที่หนังสือ" />
                                                            <asp:BoundField DataField="Remark" HeaderText="หมายเหตุ" />
                                                            <asp:TemplateField HeaderText="ไฟล์แนบ">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgWarning" runat="server" ImageUrl="images/view.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'></asp:ImageButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="80px" HorizontalAlign="Center" />
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
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="cmdAddWarning" />
                                                    <asp:AsyncPostBackTrigger ControlID="grdWarning" EventName="RowCommand" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                </div>
                            </div>


                            <div runat="server" class="box box-solid">
                                <div class="box-header bg-success-light">
                                    ข้อมูลใบอนุญาตร้านยาคุณภาพ
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
                                                <label>เป็นร้านยาคุณภาพ</label>
                                                <div class="button r" id="button-1">
                                                    <input id="chkAccPharm" type="checkbox" class="checkbox" runat="server">
                                                    <div class="knobs"></div>
                                                    <div class="layer"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>ตั้งแต่ปี พ.ศ.</label>
                                                <asp:TextBox ID="txtStartYear" runat="server" CssClass="form-control text-center" placeholder="ถ้าลงทะเบียนปีแรกให้ใส่ 0"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>วันที่รับรองครั้งแรก</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtBeginDate" runat="server" CssClass="form-control text-center"
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
                                                <label>Remark</label>
                                                <asp:TextBox ID="txtAccRemark" runat="server" CssClass="form-control text-center" placeholder="หมายเหตุ/Remark"></asp:TextBox>
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
                                                <label>สถานะใบรับรองร้านยาคุณภาพ</label><br />
                                                <asp:DropDownList ID="ddlAccStatus" runat="server" CssClass="form-control select2">
                                                    <asp:ListItem Selected="True" Value="N">ยังไม่ได้รับการรับรอง</asp:ListItem>
                                                    <asp:ListItem Value="A">ปกติ</asp:ListItem>
                                                    <asp:ListItem Value="E">หมดอายุการรับรอง</asp:ListItem>
                                                    <asp:ListItem Value="X">ยกเลิกการรับรอง</asp:ListItem>
                                                </asp:DropDownList>
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
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                                    <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 3 Then %>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>ชื่อร้านสำหรับออกใบรับรอง (บรรทัดที่ 1)</label>
                                                <asp:TextBox ID="txtCertName1" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>ชื่อร้านสำหรับออกใบรับรอง (บรรทัดที่ 2)</label>
                                                <asp:TextBox ID="txtCertName2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>ที่อยู่สำหรับออกใบรับรอง</label>
                                                <asp:TextBox ID="txtCertAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <% End If %>
                                </div>
                            </div>
                            <div class="row justify-content-center">
                                <asp:Button ID="cmdSave" runat="server" Width="120" CssClass="btn btn-primary btn-user btn-block" Text="บันทึก" />
                                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 3 Or Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 9 Then %>
                                <a href="LocationList.aspx?m=l" class="btn btn-secondary">กลับหน้ารายการร้านยา</a>
                                <% End If %>
                            </div>

                            <br />
                        </div>
                    </div>

                </div>
            </section>

            <section class="col-lg-3 connectedSortable">
                <asp:Panel ID="pnMember" runat="server">
                    <div class="box box-success">
                        <div class="box-header with-border">
                            <h2 class="box-title">รูปหน้าร้าน</h2>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                                    <i class="fa fa-minus"></i>
                                </button>

                            </div>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <label>
                                            เลือกรูป
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1 MB." data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
                                        </label>
                                        <div class="file-upload">
                                            <asp:FileUpload ID="FileUploadA" runat="server" AllowMultiple="true" />
                                            <i class="fa fa-camera"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label></label>
                                        <br />
                                        <asp:Button ID="cmdUpload" runat="server" Text="Upload" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center">

                                <asp:UpdatePanel ID="UpdatePanelImg" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label2" runat="server" CssClass="text-red"></asp:Label>
                                        <asp:GridView ID="grdImg" CssClass="table table-hover"
                                            runat="server" CellPadding="2"
                                            GridLines="None"
                                            AutoGenerateColumns="False"
                                            Font-Bold="False" ShowHeader="False">
                                            <RowStyle BackColor="#F7F7F7" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="text-center">
                                                                    <asp:Image ID="imgLocatoin" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>' runat="server" Height="150" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center">
                                                                    <asp:ImageButton ID="imgView" runat="server" ImageUrl="images/view.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>'></asp:ImageButton>
                                                                    <asp:ImageButton ID="imgDelFile" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/delete.png" /></td>
                                                            </tr>

                                                        </table>
                                                        <br />

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
                                        <asp:PostBackTrigger ControlID="cmdUpload" />
                                        <asp:AsyncPostBackTrigger ControlID="grdImg" EventName="RowCommand" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <div class="box-footer">
                            <asp:Label ID="lblNoSuccess" runat="server" ForeColor="Red" Text="Upload รูปไม่สำเร็จ กรุณาตรวจสอบไฟล์ แล้วลองใหม่อีกครั้ง" Visible="False"></asp:Label>
                            <br />
                        </div>
                    </div>

                    <div class="box box-success">
                        <div class="box-header with-border">
                            <h2 class="box-title">รูปเภสัชกร</h2>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                                    <i class="fa fa-minus"></i>
                                </button>

                            </div>
                        </div>
                        <div class="box-body">
                            <div>เพิ่มรูปเภสัชกรพร้อมกับการเพิ่มข้อมูลเภสัชกรผู้ปฏิบัติหน้าที่ในกรอบด้านซ้ายแล้วรูปจะแสดงที่นี่</div>
                            <div class="row justify-content-center">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdImgPharmacist" runat="server" CellPadding="2" Width="100%" GridLines="None" AutoGenerateColumns="False" Font-Bold="False" ShowHeader="False">
                                            <RowStyle BackColor="#F7F7F7" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <table style="width: 100%; padding: 2px; font-size: 12px">
                                                            <tr>
                                                                <td class="text-center" style="background-color: #0066cc; color: #fff; width: 50px;">
                                                                    <asp:Image ID="imgPerson" ImageUrl='<%#  DataBinder.Eval(Container.DataItem, "FilePathView") %>' runat="server" Height="50" />
                                                                    <br />
                                                                    <asp:Label ID="lblPLicense" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "License") %>'></asp:Label>
                                                                </td>
                                                                <td style="background-color: #0066cc; color: #fff;" valign="top">
                                                                    <asp:Label ID="Label5" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "PharmacistName") %>'></asp:Label><br />
                                                                    <asp:Label ID="Label4" runat="server" Text='<%#  "เวลาปฏิบัติการ " & DataBinder.Eval(Container.DataItem, "WorkTimeList") %>'></asp:Label>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" class="text-center">
                                                                    <asp:ImageButton ID="imgView" runat="server" ImageUrl="images/view.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FilePathView") %>'></asp:ImageButton>
                                                                    <asp:ImageButton ID="imgDelFile" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/delete.png" /></td>
                                                            </tr>

                                                        </table>
                                                        <br />

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
                                        <asp:AsyncPostBackTrigger ControlID="grdImgPharmacist" EventName="RowCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <div class="box-footer">
                            <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Upload รูปไม่สำเร็จ กรุณาตรวจสอบไฟล์ แล้วลองใหม่อีกครั้ง" Visible="False"></asp:Label>
                            <br />
                        </div>
                    </div>
                </asp:Panel>
                <% If lat > 0 Then %>
                <div class="box box-success">
                    <div class="box-header with-border">
                        <h2 class="box-title">แผนที่ตั้ง</h2>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                                <i class="fa fa-minus"></i>
                            </button>

                        </div>
                    </div>
                    <div class="box-body">
                        <div id='map' style='width: 100%; height: 300px;'></div>

                        <script>
                            var jsonObj = <%=json%>

                                function initMap() {
                                    var mapOptions = {
                                        center: { lat:  <%=lat%>, lng:  <%=lng%> },
                                        zoom: 15,
                                    }

                                    var maps = new google.maps.Map(document.getElementById("map"), mapOptions);

                                    var marker, info;

                                    $.each(jsonObj, function (i, item) {

                                        marker = new google.maps.Marker({
                                            position: new google.maps.LatLng(item.lat, item.lng),
                                            map: maps,
                                            title: item.name,
                                            icon: item.icon
                                        });

                                        info = new google.maps.InfoWindow();

                                        google.maps.event.addListener(marker, 'click', (function (marker, i) {
                                            return function () {
                                                info.setContent(item.name);
                                                info.open(maps, marker);
                                            }
                                        })(marker, i));

                                    });

                                }
                        </script>


                    </div>
                    <div class="box-footer">
                        <br />
                    </div>
                </div>
                <% End If %>
            </section>

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

        <div id="modal-window-ccr" class="modal fade modal-window" role="dialog" data-backdrop="static" tabindex="-1" style="display: none;" aria-hidden="true">
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
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td style="width: 200px">
                                                        <div class="file-upload-big">
                                                            <asp:FileUpload ID="FileUploadCCR2" runat="server" AllowMultiple="true" /><i class="fa fa-camera"></i>
                                                        </div>
                                                    </td>
                                                    <td style="width: 100%" rowspan="2">
                                                        <div class="app-page-header">
                                                            <div class="page-title-wrapper">
                                                                <div class="page-title-heading">
                                                                    <div>
                                                                        <div class="page-title-subheading">คำแนะนำ</div>
                                                                        <asp:HiddenField ID="hdCCRUID" runat="server" />
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


                                                        <asp:Button ID="cmdUpImgCCR" runat="server" Text="Upload" CssClass="btn btn-success" Width="200" />

                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="cmdUpImgCCR" />
                                            <asp:AsyncPostBackTrigger ControlID="grdImgCCR" EventName="RowCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />

                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblImgCCR" runat="server" CssClass="text-red"></asp:Label>
                                            <asp:GridView ID="grdImgCCR" CssClass="table table-hover"
                                                runat="server" CellPadding="2"
                                                GridLines="None"
                                                AutoGenerateColumns="False"
                                                Font-Bold="False">
                                                <RowStyle BackColor="#F7F7F7" />
                                                <Columns>
                                                    <asp:BoundField DataField="nRow" HeaderText="No.">
                                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="ไฟล์/รูปภาพ">
                                                        <ItemTemplate>
                                                            <a href='<%# DataBinder.Eval(Container.DataItem, "filePathView") %>' target="_blank" class="font-icon-button"><i class="fa fa-file-pdf" aria-hidden="true"></i></a>
                                                        </ItemTemplate>

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
                                            <asp:PostBackTrigger ControlID="cmdUpImgCCR" />
                                            <asp:AsyncPostBackTrigger ControlID="grdImgCCR" EventName="RowCommand" />

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


        <div id="modal-window-warning" class="modal fade modal-window" role="dialog" data-backdrop="static" tabindex="-1" style="display: none;" aria-hidden="true">
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
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td style="width: 200px">
                                                        <div class="file-upload-big">
                                                            <asp:FileUpload ID="FileUploadWarning2" runat="server" AllowMultiple="true" /><i class="fa fa-camera"></i>
                                                        </div>
                                                    </td>
                                                    <td style="width: 100%" rowspan="2">
                                                        <div class="app-page-header">
                                                            <div class="page-title-wrapper">
                                                                <div class="page-title-heading">
                                                                    <div>
                                                                        <div class="page-title-subheading">คำแนะนำ</div>
                                                                        <asp:HiddenField ID="hdWarningUID" runat="server" />
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


                                                        <asp:Button ID="cmdUpImgWarning" runat="server" Text="Upload" CssClass="btn btn-success" Width="200" />

                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="cmdUpImgWarning" />
                                            <asp:AsyncPostBackTrigger ControlID="grdImgWarning" EventName="RowCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />

                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblImgWarning" runat="server" CssClass="text-red"></asp:Label>
                                            <asp:GridView ID="grdImgWarning" CssClass="table table-hover"
                                                runat="server" CellPadding="2"
                                                GridLines="None"
                                                AutoGenerateColumns="False"
                                                Font-Bold="False">
                                                <RowStyle BackColor="#F7F7F7" />
                                                <Columns>
                                                    <asp:BoundField DataField="nRow" HeaderText="No.">
                                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="ไฟล์/รูปภาพ">
                                                        <ItemTemplate>
                                                            <a href='<%# DataBinder.Eval(Container.DataItem, "filePathView") %>' target="_blank" class="font-icon-button"><i class="fa fa-file-pdf" aria-hidden="true"></i></a>
                                                        </ItemTemplate>

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
                                            <asp:PostBackTrigger ControlID="cmdUpImgWarning" />
                                            <asp:AsyncPostBackTrigger ControlID="grdImgWarning" EventName="RowCommand" />

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

    </section>
</asp:Content>
