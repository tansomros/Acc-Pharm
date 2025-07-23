<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PharmacyDetail.aspx.vb" Inherits="CPAQA.PharmacyDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
     <script async defer  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBfMj6L9aj4d2o6a_vxYVLYC2nrwnCjXFg&callback=initMap"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="lnr-store icon-gradient bg-green"></i>
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
<i class="header-icon lnr-store icon-gradient bg-mixed-hopes"> </i>ข้อมูลร้านยา<asp:HiddenField ID="hdLocationUID" runat="server" />
<div class="btn-actions-pane-right actions-icon-btn">
 <asp:Label ID="lblNewCode" runat="server" CssClass="small"></asp:Label>
</div>
</div>

                            <div class="card-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="p-2">
                                            <div class="row">  
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>เลขที่ใบอนุญาต ขย 5</label>
                                                        <asp:textbox ID="txtLicenseNo1" runat="server" CssClass="form-control text-blue text-bold text-center" ReadOnly="true" Enabled="false" BackColor="White"></asp:textbox>
                                                    </div>
                                                </div>  
                                                 <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>เลขที่ใบรับรอง</label>
                                                        <asp:textbox ID="txtAccLicenseNo" runat="server" CssClass="form-control text-center"></asp:textbox>
                                                    </div>
                                                </div> 
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>รหัสหน่วยบริการ สปสช.(Dxxxx)</label>
                                                        <asp:textbox ID="txtNHSOCode" runat="server" CssClass="form-control text-center"></asp:textbox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label>ชื่อร้านยา</label>
                                                        <asp:TextBox ID="txtLocationName" runat="server" CssClass="form-control text-blue text-bold" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>
                                                                                              
                                            </div>
                                            <div class="row">
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
                                            <div class="row">

                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>แขวง/ตำบล</label>
                                                        <asp:TextBox ID="txtSubDistrict" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>เขต/อำเภอ</label>
                                                        <asp:TextBox ID="txtDistrict" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>จังหวัด</label><br />
                                                        <asp:DropDownList CssClass="form-control" ID="ddlProvince" style="background-color:#fff" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label>รหัสไปรษณีย์</label>
                                                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" MaxLength="5"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
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
                                                        <asp:TextBox ID="txtFacebook" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>ละติจูด,ลองติจูด</label>
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
                                            <div class="row">
                                              
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
                                          
                                            <div class="row">
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
                                            <div class="row">
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



                                            <div class="row">
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
                                                        <asp:DropDownList ID="ddlGroup" runat="server" style="background-color:#fff" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>Chain/มีสาขา</label>
                                                        <asp:UpdatePanel ID="udpChain" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlChain" runat="server" style="background-color:#fff" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>


                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label>ประเภทร้านยา</label>
                                                        <asp:CheckBoxList ID="chkLocationType" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"></asp:CheckBoxList>

                                                    </div>
                                                </div>  
                                            </div>                                         
                                          
                                              
                                        </div>
                                    </div>
                                </div>
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
                                <div class="row">
                                    <div class="col-md-12">
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
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="WorkTypeName" HeaderText="ประเภท">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="WorkTimeList" HeaderText="เวลาปฏิบัติงาน">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>                                                      
                                                    </Columns>
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle HorizontalAlign="Center"
                                                        CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle CssClass="th" Font-Bold="True" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                                                         </div>
                                </div>
                            </div>
                        </div>


                        <div id="pnDocument" runat="server" class="main-card mb-3 card">
                            <div class="card-header">
                                ไฟล์เอกสาร
                            </div>
                            <div class="card-body">
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
                    <div class="col-lg-12">

                        <div class="justify-content-center">
                             <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then %>
                              <div runat="server" class="box box-solid">
                                <div class="box-header">
                                    ข้อมูลประวัติปัญหา/คำร้องเรียน (ร้านยาไม่เห็น)
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
                            <label>วันที่</label>
                            <br />
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
                                         <div class="col-md-2">
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
                                            <asp:AsyncPostBackTrigger ControlID="cmdAddCCR" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="grdCCR" EventName="RowCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                    </div>

                                </div>
                            </div>
                             <% End If %>
                     
                            <div class="row justify-content-center">
                                <asp:Button ID="cmdSave" runat="server" Width="120" CssClass="btn btn-primary btn-user btn-block" Text="บันทึก" />
                                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 3 Then %>
                                <a href="PharmacyList.aspx?m=l2" class="btn btn-secondary">กลับหน้ารายการร้านยา</a>
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
                                                                    </td>
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
                            <div class="row justify-content-center"> 
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
                                                                </td>
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
                            </div>

                        </div>
                        <div class="box-footer">
                            <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Upload รูปไม่สำเร็จ กรุณาตรวจสอบไฟล์ แล้วลองใหม่อีกครั้ง" Visible="False"></asp:Label>
                            <br />
                        </div>
                    </div>
                </asp:Panel>
     
                       <div class="box box-solid">
                                <div class="box-header">
                                    ข้อมูลใบอนุญาตร้านยาคุณภาพ
                 <div class="box-tools pull-right">
                     <button type="button" class="btn btn-box-tool" data-widget="collapse">
                         <i class="fa fa-minus"></i>
                     </button>
                 </div>
                                </div>
                                <div class="box-body app-page-header">
                                    <div class="row">  
                                                  <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>เป็นร้านยาคุณภาพ</label>
                                                        <div class="button r" id="button-1">
                                                            <input id="chkAccPharm" type="checkbox" class="checkbox" runat="server">
                                                            <div class="knobs"></div>
                                                            <div class="layer"></div>
                                                        </div>
                                                    </div>
                                                </div> 
                                                 <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>ตั้งแต่ปี พ.ศ.</label>
                                                        <asp:TextBox ID="txtStartYear" runat="server" CssClass="form-control text-center" placeholder="ถ้าลงทะเบียนปีแรกให้ใส่ 0"></asp:TextBox>
                                                    </div>
                                                </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <label>วันที่รับรองครั้งแรก</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtBeginDate" runat="server" CssClass="form-control text-center"></asp:TextBox>      
                                                </div>
                                            </div>
                                        </div>
                                          <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>Remark</label>
                                                        <asp:TextBox ID="txtAccRemark" runat="server" CssClass="form-control text-center" placeholder="หมายเหตุ/Remark"></asp:TextBox>
                                                    </div>
                                                </div>

                                        </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>เลขที่ใบรับรอง</label>
                                                <asp:TextBox ID="txtAccLicense" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>สถานะใบรับรอง</label><br />
                                                <asp:DropDownList ID="ddlAccStatus" runat="server" style="background-color:#fff" CssClass="form-control">
                                                    <asp:ListItem Selected="True" Value="N">ยังไม่ได้รับการรับรอง</asp:ListItem>
                                                    <asp:ListItem Value="A">ปกติ</asp:ListItem>
                                                    <asp:ListItem Value="E">หมดอายุการรับรอง</asp:ListItem>
                                                    <asp:ListItem Value="X">ยกเลิกการรับรอง</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>วันที่อนุญาต</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                             <div class="form-group">
                                    <label>วันที่สิ้นสุด</label>                                  
                                                   <div class="input-group">
                                                    <asp:TextBox ID="txtExpireDate" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                                  
                                                </div>
                                </div>
                                  </div>
                                    </div>                                
                                </div>
                            </div>

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
                         <div id='map' style='width:100%; height:300px; '></div>

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
    </section>
</asp:Content>
