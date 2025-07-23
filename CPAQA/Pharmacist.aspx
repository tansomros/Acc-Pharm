<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Pharmacist.aspx.vb" Inherits="CPAQA.Pharmacist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">     
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="fa fa-user-md icon-gradient bg-green"></i>
                </div>
                <div>Pharmacist
                    <div class="page-title-subheading">จัดการข้อมูลเภสัชกรผู้ปฏิบัติการ </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Main content -->
    <section class="content">
        <div class="row">
                  <section class="col-lg-12">                          
             <div class="app-page-header">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">                      
                        <div>
                            <asp:HiddenField ID="hdLocationUID" runat="server" />
                            <asp:label ID="lblLocationName" runat="server"></asp:label>
                            <div class="page-title-subheading">ที่ตั้ง : <asp:label ID="lblAddress" runat="server"></asp:label></div>
                        </div>
                    </div>
                </div>
            </div>
     </section>
            </div>
                 <div class="row">
            <section class="col-lg-9 connectedSortable">
                <div class="justify-content-center">
                    <div class="col-lg-12"> 
                        <div class="box box-solid">
                            <div class="box-header">
                                เภสัชกรผู้ปฏิบัติการ
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
                                                    <asp:TextBox ID="txtPLicense" runat="server" CssClass="form-control text-center"></asp:TextBox>
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
                                                        <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 1 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"></i></button>
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
                                      
                                          <asp:PostBackTrigger ControlID="cmdAddPharmacist" />
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
                                           
                                                  <asp:PostBackTrigger ControlID="cmdAddPharmacist" />
                                                <asp:AsyncPostBackTrigger ControlID="grdPharmacist" EventName="RowCommand" />
                                                <asp:AsyncPostBackTrigger ControlID="grdImgPharmacist" EventName="RowCommand" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="justify-content-center">

                            <div class="row justify-content-center"> 
                                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 3 Then %>
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
                                                                    <asp:Image ID="imgLocatoin" ImageUrl='<%#  DataBinder.Eval(Container.DataItem, "FilePathView") %>' runat="server" Height="50" />
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
    </section>
</asp:Content>
