<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Location.aspx.vb" Inherits="CPA.Location" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">   
    <script type="text/javascript">
       function openModalUpload(sender,id) { 
           $('#modal-window-upl').modal('show');
           return false;
        }      
        function openModalUploadSW(sender, id) {
            $('#modal-window-sw').modal('show');
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
                        <div>ข้อมูลร้านยา
                            <div class="page-title-subheading">จัดการรายละเอียดข้อมูลร้านยา </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Main content -->
<section class="content">
    <div class="row">
        <section class="col-lg-12 connectedSortable">

              <div class="box box-solid">
            <div class="box-header">ข้อมูลร้านยา<asp:HiddenField ID="hdLocationUID" runat="server" />
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                                 
            </div>
                  <div class="box-body">

                                <div class="row">                                                              
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>ชื่อร้านยา</label>
                                            <asp:TextBox ID="txtLocationName" runat="server" cssclass="form-control" placeholder="ชื่อร้านยา/สถานประกอบการ"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เลขที่ใบอนุญาต ขย 5</label>
                                            <asp:TextBox ID="txtLicenseNo1" runat="server" CssClass="form-control text-blue text-bold text-center" BackColor="White" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                     <div class="col-md-12">
                                        <div class="form-group">
                                            <label>สถานที่ตั้ง</label>
                                            <asp:TextBox ID="txtAddressNo" runat="server" cssclass="form-control" placeholder="บ้านเลขที่/หมู่/ซอย/ถนน"></asp:TextBox>
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
                                            <asp:TextBox ID="txtSubdistrict" runat="server" cssclass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label>เขต/อำเภอ</label>
                                            <asp:TextBox ID="txtDistrict" runat="server" cssclass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
 <div class="col-md-3">
                                        <div class="form-group">
                                            <label>จังหวัด</label>
                                            <asp:DropDownList CssClass="form-control select2"  ID="ddlProvince" runat="server"> </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label>รหัสไปรษณีย์</label>
                                            <asp:TextBox ID="txtZipCode" runat="server" cssclass="form-control text-center" MaxLength="5" ></asp:TextBox>
                                        </div>
                                    </div>
 </div>
                                <div class="row">
                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label>เบอร์โทร</label>
                                            <asp:TextBox ID="txtTel" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="col-md-3">
                                        <div class="form-group">
                                            <label>E-mail</label>
                                            <asp:TextBox ID="txtEmail" runat="server" cssclass="form-control special-letter"></asp:TextBox>
                                        </div>
                                    </div>

                                      <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Line ID</label>
                                            <asp:TextBox ID="txtLineID" runat="server" cssclass="form-control special-letter"></asp:TextBox>
                                        </div>
                                    </div>

                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Facebook</label>
                                            <asp:TextBox ID="txtFacebook" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                     </div>
                                <div class="row">
                                     <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>ละติจูด,ลองจิจูด</label><button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ละติจูด/ลองจิจูด ในรูปแบบองศาทศนิยมเท่านั้น และคั่นชุดข้อมูลด้วยคอมม่า (,)" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper" data-toggle="tooltip" data-placement="top" data-original-title="ละติจูด/ลองจิจูด ในรูปแบบองศาทศนิยมเท่านั้น และคั่นชุดข้อมูลด้วยคอมม่า (,)"></i></button><small class="text-red"> *</small>

                                                        <asp:TextBox ID="txtLat" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>   

                                      <div class="col-md-3">
                                        <div class="form-group">
                                            <label>เวลาทำการร้าน</label>
                                            <asp:TextBox ID="txtWorkTime" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>เป็นร้านยาคุณภาพตั้งแต่ปี พ.ศ.</label>
                                            <asp:TextBox ID="txtStartYear" runat="server" cssclass="form-control text-center" placeholder=""></asp:TextBox>
                                        </div>
                                    </div> 
                    </div>
                                <div class="row">
                                  
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เลขที่ใบอนุญาตขายยาเสพติดให้โทษประเภท 3</label>
                                            <asp:TextBox ID="txtLicenseNo2" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
  <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เลขที่ใบอนุญาตจำหน่ายวัตถุออกฤทธิ์ต่อจิตประสาท</label>
                                            <asp:TextBox ID="txtLicenseNo3" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
 </div>
                         <div class="row">
                                     <div class="col-md-8">
                                        <div class="form-group">
                                            <label>ชื่อผู้รับอนุญาต</label>
                                            <asp:TextBox ID="txtLicensee" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div> 
                                     <div class="col-md-4">
                                        <div class="form-group mailbox-messages">
                                            <label>ประเภท</label>
                                              
                                                      <asp:RadioButtonList ID="optLicenseeType" runat="server" 
                                                          RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="1">บุคคล</asp:ListItem>
                                                    <asp:ListItem Value="2">นิติบุคคล/บริษัท</asp:ListItem>
                                                  </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div> 
                            </div> 
             </div>

                  <div class="box box-solid">
            <div class="box-header">เภสัชกรประจำร้าน <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                                 
            </div>
                            <div class="box-body">
                                <asp:Panel ID="pnPharmacist"  runat="server">                     
                             
  <asp:UpdatePanel ID="UpdatePanelPharmacistAdd" runat="server">
                                <ContentTemplate>    
                                       <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>ชื่อ-นามสกุล</label>      <asp:HiddenField ID="hdPharmacistUID" runat="server" />
                                             <asp:TextBox ID="txtPName" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>เลขใบประกอบโรคศิลปะ</label> 
                                            <asp:TextBox ID="txtPLicense" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>   
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>เวลาปฏิบัติการ</label> 
                                            <asp:TextBox ID="txtPTime" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="col-md-2">
                                        <div class="form-group">
                                            <label>ประเภท</label>
                                            <asp:DropDownList ID="ddlPType" runat="server" cssclass="form-control select2">
                                                <asp:ListItem Value="1" Text="Full Time"></asp:ListItem>
                                                 <asp:ListItem Value="2" Text="Part Time"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                 
                                
                                      <div class="col-md-2">
                                        <div class="form-group">
                                           <br />
                                            <asp:Button ID="cmdAddPharmacist" runat="server" Text="เพิ่ม" CssClass="btn btn-primary" /> 
                                             <asp:Button ID="cmdClearPharmacist" runat="server" Text="ยกเลิก" CssClass="btn btn-secondary" />   
                                        </div>
                                    </div>                                  
                                </div>     

                                </ContentTemplate>
                                <Triggers> 
                                     <asp:AsyncPostBackTrigger ControlID="cmdAddPharmacist" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="grdPharmacist" EventName="RowCommand" />

                                </Triggers>
                            </asp:UpdatePanel>  
                    </asp:Panel>     
                                
                                <div class="row">
                              
                                    <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanelPharmacistList" runat="server">
                                <ContentTemplate>                                                     
<asp:GridView ID="grdPharmacist" CssClass="table table-hover"  runat="server" CellPadding="2"  GridLines="None" AutoGenerateColumns="False"  Font-Bold="False">
                        <RowStyle BackColor="#F7F7F7" />
                        <columns>
                            <asp:BoundField DataField="nRow" HeaderText="No." >
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                      
                            <asp:BoundField DataField="PharmacistName" HeaderText="ชื่อ-นามสกุล" >
                            <HeaderStyle HorizontalAlign="Left" />                            
                           
                            </asp:BoundField>
                            <asp:BoundField DataField="License" HeaderText="เลขใบประกอบโรคศิลปะ" >
                            <HeaderStyle HorizontalAlign="Left" />                            
                           
                            </asp:BoundField>
                            <asp:BoundField DataField="WorkTypeName" HeaderText="ประเภท">
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                              <asp:BoundField DataField="WorkTimeList" HeaderText="เวลาปฏิบัติงาน" >                            
                            <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                             <asp:TemplateField Visible="False">
              <itemtemplate>
                    <asp:linkButton ID="imgEdit" runat="server"  Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  

                   <asp:linkButton ID="imgDel" runat="server"  Text="ลบ" CssClass="btn btn-danger" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  
                                 </itemtemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />          
            </asp:TemplateField>
                        </columns>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />                     
                        <pagerstyle HorizontalAlign="Center" 
                             CssClass="dc_pagination dc_paginationC dc_paginationC11" />                     
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <headerstyle CssClass="th" Font-Bold="True" />                     
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                     </asp:GridView>
                            </ContentTemplate>
                                <Triggers> 

                                    <asp:AsyncPostBackTrigger ControlID="cmdAddPharmacist" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="grdPharmacist" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>           

                                    </div>
                             </div>
                        </div>
                     </div>
            <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-grear"></i>
              <h3 class="box-title">ลักษณะร้าน</h3>
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                                 
            </div>
            <div class="box-body"> 
                <div class="row">
                      <div class="col-md-2">
                                        <div class="form-group">
                                            <label>จำนวนคูหา</label> 
                                             <div class="input-group">                                             
                                                <asp:TextBox ID="txtArea1" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">คูหา</span>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                       <div class="col-md-2">
                                        <div class="form-group">
                                            <label>พื้นที่</label> 
                                             <div class="input-group">                                             
                                                <asp:TextBox ID="txtArea2" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">ตร.ม.</span>
                                                </div>
                                            </div>


                                        </div>
                                    </div>

                    
                      <div class="col-md-4">
                                        <div class="form-group">
                                            <label>กลุ่มร้านยา</label><br />
                                             <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True" CssClass="form-control select2" >                                                        </asp:DropDownList>  
                                        </div>     
                                    </div> 
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Chain/มีสาขา</label>
                                            <asp:UpdatePanel ID="udpChain" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlChain" runat="server"  cssclass="form-control select2">
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
                                     <asp:CheckBoxList ID="chkLocationType" runat="server" RepeatDirection="Horizontal" ></asp:CheckBoxList>

													</div>
												</div>
                </div>



            </div>
          </div>   
             <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-grear"></i>
              <h3 class="box-title">ระบบการจัดการในร้าน</h3>    
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                                 
            </div>
            <div class="box-body"> 
                <table>
                    <tr>
                        <td class="text-blue">ใช้ระบบ  / Platform / Software / POS / อื่นๆ ในร้านหรือไม่ (ถ้ามีให้เพิ่มรายการด้านล่าง) &nbsp;  </td>
                        <td>
                  <div class="button r" id="button-1"> 
                      <input id="chkIsSoftware" type="checkbox" class="checkbox" runat="server" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </td> 
                    </tr>                  
                </table> 
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>  
                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>ระบบ / โปรแกรม / Software ที่มีในร้าน</label><asp:HiddenField ID="hdSoftwareUID" runat="server" />
                                             <asp:TextBox ID="txtSname" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>การใช้ประโยชน์ / งานที่ทำ</label> 
                                            <asp:TextBox ID="txtSdesc" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>   
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label>  
                                             <div class="file-upload"> 
                                                 <asp:FileUpload  ID="FileUploadA" runat="server" AllowMultiple="true" /> 
                                                  <i class="fa fa-camera"></i>
                                             </div> 
                                        </div>
                                    </div>
                                      <div class="col-md-2">
                                        <div class="form-group">
                                            <label></label>  <br />                                               
                                            <asp:Button ID="cmdSaveSoftware" runat="server" Text="เพิ่ม" CssClass="btn btn-primary" />
                                              <asp:Button ID="cmdClearSoftware" runat="server" Text="ยกเลิก" CssClass="btn btn-secondary" /> 
                                        </div>
                                    </div>   
                                    
                                </div>  
  </ContentTemplate>
                                <Triggers> 

                                    <asp:PostBackTrigger ControlID="cmdSaveSoftware" />
                                    <asp:AsyncPostBackTrigger ControlID="grdSoftware" EventName="RowCommand" />

                                </Triggers>
                            </asp:UpdatePanel>  
            
                         <div class="row">
                              
                                    <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanelSoftwareList" runat="server">
                                <ContentTemplate>                                                     
<asp:GridView ID="grdSoftware" CssClass="table table-hover"  
                             runat="server" CellPadding="2" 
                                                        GridLines="None" 
                      AutoGenerateColumns="False"  
                             Font-Bold="False">
                        <RowStyle BackColor="#F7F7F7" />
                        <columns>
                            <asp:BoundField DataField="nRow" HeaderText="No." >
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SoftwareName" HeaderText="ระบบ / โปรแกรม / Software ที่มีในร้าน" >
                            <HeaderStyle HorizontalAlign="Left" />  
                            </asp:BoundField>
                            <asp:BoundField DataField="Descriptions" HeaderText="การใช้ประโยชน์ / งานที่ทำ" >
                            <HeaderStyle HorizontalAlign="Left" /> 
                            </asp:BoundField>                           
                             <asp:TemplateField HeaderText="">
                                 <ItemTemplate>    
                                     <asp:LinkButton ID="imgFileSW" runat="server" CssClass="btn btn-success"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'><i class="fa fa-image"></i></asp:LinkButton> 
                                 </ItemTemplate>
                                 <ItemStyle Width="50px" />
                            </asp:TemplateField>                           
                             <asp:TemplateField>
              <itemtemplate>
                    <asp:linkButton ID="imgEdit_SW" runat="server"  Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  
                   <asp:linkButton ID="imgDel_SW" runat="server"  Text="ลบ" CssClass="btn btn-danger" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  
                                 </itemtemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />          
            </asp:TemplateField>
                        </columns>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />                     
                        <pagerstyle HorizontalAlign="Center" 
                             CssClass="dc_pagination dc_paginationC dc_paginationC11" />                     
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <headerstyle CssClass="th" Font-Bold="True" />                     
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                     </asp:GridView>
                            </ContentTemplate>
                                <Triggers> 
                                    <asp:PostBackTrigger ControlID="cmdSaveSoftware" />
                                    <asp:AsyncPostBackTrigger ControlID="grdSoftware" EventName="RowCommand" />                               

                                </Triggers>
                            </asp:UpdatePanel>           

                                    </div>
                             </div>                                     
            </div> 
        </div>
             
        <!-- Modal HTML -->            
 <div id="modal-window" class="modal fade modal-window"  role="dialog" data-backdrop="static" tabindex="-1" style="display: none;z-index: 9999;" aria-hidden="true">
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
              <img id="img1" src="" style="width:100%;display: inline-block;" />
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

             <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-grear"></i>
              <h3 class="box-title">งานคุณภาพที่ต้องการให้ปรากฏแก่ประชาชน</h3>        
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                                 
            </div>
            <div class="box-body"> 

                เพื่อการประชาสัมพันธ์ และสื่อสารให้ประชาชนรู้ ( ในหมอพร้อม หรือใน Real Time Application หรือ ของสภาเภสัชกรรม ) ทั้งนี้...ขอให้เป็นงานที่ทำตลอดและต่อเนื่อง

                <div class="row">
                    <div class="col-md-12 table-responsive">
                        <table class="table table-hover">
                             <thead>
                <tr>
                   <th class="text-center" width="20px"></th>  
                  <th class="text-left" width="300px">กิจกรรม/งานคุณภาพ</th>
                  <th class="text-left">รูปภาพ <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>    </th>                
                                     
                  <th class="text-left">&nbsp;</th>                
                                     
                </tr>
                </thead>
                <tbody>
                    <tr>
                                <td>1.</td>
                                <td>การคัดกรองความเสี่ยง เบาหวาน ความดัน</td>
                                <td style="width:100px">
                                    <asp:LinkButton ID="imgQ1" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>                                 
                                    </td>
                                <td>
                                    <asp:Label ID="lblQ1" runat="server" CssClass="small text-success"></asp:Label>
                                   </td>
                            </tr>
                            <tr>
                                <td>2.</td>
                                <td>บริการเลิกสูบบุหรี่ </td>
                                <td><asp:LinkButton ID="imgQ2" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ2" runat="server" CssClass="small text-success"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>3.</td>
                                <td>บริการติดตามการใช้ยาในโรคเรื้อรัง </td>
                                <td><asp:LinkButton ID="imgQ3" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ3" runat="server" CssClass="small text-success"></asp:Label>
                                </td></tr>
                             <tr>
                                <td>4.</td>
                                <td>บริการเภสัชกรรมทางTelepharmacy  </td>
                                <td><asp:LinkButton ID="imgQ4" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ4" runat="server" CssClass="small text-success"></asp:Label>
                                 </td>
                            </tr>
                             <tr>
                                <td>5.</td>
                                <td>บริการปรึกษาปัญหาสุขภาพ การใช้ยา </td>
                                <td><asp:LinkButton ID="imgQ5" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ5" runat="server" CssClass="small text-success"></asp:Label>
                                 </td>
                            </tr>
                             <tr>
                                <td>6.</td>
                                <td>มีการออกนอกร้านเพื่อไปให้ความรู้ชุมชน โรงเรียน วัด ฯลฯ </td>
                                <td><asp:LinkButton ID="imgQ6" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ6" runat="server" CssClass="small text-success"></asp:Label>
                                 </td>
                            </tr>
                             <tr>
                                <td>7.</td>
                                <td>มี Page หรือ Facebook ให้ความรู้   </td>
                                <td><asp:LinkButton ID="imgQ7" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ7" runat="server" CssClass="small text-success"></asp:Label>
                                 </td>
                            </tr>
                             <tr>
                                <td>8.</td>
                                <td>มี Line OA ของร้าน </td>
                                <td><asp:LinkButton ID="imgQ8" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ8" runat="server" CssClass="small text-success"></asp:Label>
                                 </td>
                            </tr>
                             <tr>
                                <td>9.</td>
                                <td>มี Real Time  Application  </td>
                                <td><asp:LinkButton ID="imgQ9" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ9" runat="server" CssClass="small text-success"></asp:Label>
                                 </td>
                            </tr>
 <tr>
                                <td>10.</td>
                                <td>กิจกรรมอื่นๆ
                                    <br />
                                   
                                </td>
                                <td><asp:LinkButton ID="imgQ10" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton></td>
                                <td>
                                    <asp:Label ID="lblQ10" runat="server" CssClass="small text-success"></asp:Label>
                                </td>
                            </tr>                                                      
 <tr>
                                <td>&nbsp;</td>
                                <td colspan="3"><asp:TextBox ID="txtQ10" runat="server" TextMode="MultiLine" Height="120px" CssClass="form-control" placeholder="ระบุ/อธิบายกิจกรรมอื่นๆ" ></asp:TextBox></td>
                            </tr>                                                      
                    </tbody>
                        </table>
                        </div>  
                </div>
            </div>
          </div> 
  			<% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then %>     
               <div class="card-shadow-success border mb-3 card card-body border-success">
                  <h5 class="card-title">สรุปผลการตรวจประเมิน จากผู้ตรวจประเมิน</h5>
                    
   <div class="col-lg-12 app-page-header">      
                        <div class="form-group">
                            <label>ผ่านการประเมิน</label>  
        <div class="button r" id="button-2"> 
              <input id="chkStatus" type="checkbox" class="checkbox" runat="server" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>            

       </div>
                             </div>
                      <% End If %>
            
            <!-- Modal HTML > -->            
 <div id="modal-window-upl"  class="modal fade modal-window"  role="dialog" data-backdrop="static" tabindex="-1" style="display: none;" aria-hidden="true" >
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
        <asp:Label ID="lblTopic" runat="server" CssClass="h4 text-bold"></asp:Label>  

       </div>
      </div>

      <div class="row">
   <div class="col-md-12">
          <div class="form-group">
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>   
                                    <table>
               <tr>
                   <td style="width:200px"><div class="file-upload-big"><asp:FileUpload  ID="FileUpload1" runat="server"   AllowMultiple="true" /><i class="fa fa-camera"></i></div></td>
                                <td style="width:100%" rowspan="2">
                                       <div class="app-page-header">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">                      
                        <div><div class="page-title-subheading">คำแนะนำ</div><asp:HiddenField ID="hdAccID" runat="server" />
                            <br />
                            - ไฟล์นามสกุล .jpg, .jpeg, .gif, .png,.pdf เท่านั้น    <br />
                            - ขนาดไฟล์ไม่เกิน 1024 Kb. <br />
                            - เพิ่มได้ไม่เกิน 4 รูป   <br /> <br />
                        </div>
                    </div>
                </div>
            </div> </td>                             
                            </tr>
 <tr>   <td>

       
     <asp:Button ID="cmdUpImg" runat="server" Text="Upload" CssClass="btn btn-success" Width="200" /> 
                            
                      </td>          
     </tr>
</table>
 </ContentTemplate>
                                <Triggers> 
                                    <asp:PostBackTrigger ControlID="cmdUpImg" />
                                      <asp:AsyncPostBackTrigger ControlID="imgQ1"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ2"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ3"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ4"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ5"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ6"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ7"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ8"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ9"  EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="imgQ10"  EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>      
              <br />
           
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate> 
                                              <asp:Label ID="lblImg" runat="server" CssClass="text-red"></asp:Label>               
<asp:GridView ID="grdImg" CssClass="table table-hover"  
                             runat="server" CellPadding="2" 
                                                        GridLines="None" 
                      AutoGenerateColumns="False"  
                             Font-Bold="False">
                        <RowStyle BackColor="#F7F7F7" />
                        <columns>
                            <asp:BoundField DataField="nRow" HeaderText="No." >
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
                                     <asp:ImageButton ID="imgDelFile" runat="server"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/delete.png" />
                                 </ItemTemplate>
                                 <ItemStyle Width="30px" />
                            </asp:TemplateField>
                                                     
                        </columns>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />                     
                        <pagerstyle HorizontalAlign="Center" 
                             CssClass="dc_pagination dc_paginationC dc_paginationC11" />                     
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <headerstyle CssClass="th" Font-Bold="True" />                     
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                     </asp:GridView>
 </ContentTemplate>
                                <Triggers> 
                                    <asp:PostBackTrigger ControlID="cmdUpImg" />
                                    <asp:AsyncPostBackTrigger ControlID="grdImg" EventName="RowCommand" />
                                   

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

                     
 <div id="modal-window-sw"  class="modal fade modal-window"  role="dialog" data-backdrop="static" tabindex="-1" style="display: none;" aria-hidden="true" >
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
                   <td style="width:200px"><div class="file-upload-big"><asp:FileUpload  ID="FileUploadSW" runat="server"   AllowMultiple="true" /><i class="fa fa-camera"></i></div></td>
                                <td style="width:100%" rowspan="2">
                                       <div class="app-page-header">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">                      
                        <div><div class="page-title-subheading">คำแนะนำ</div><asp:HiddenField ID="hdSWUID" runat="server" />
                            <br />
                            - ไฟล์นามสกุล .jpg, .jpeg, .gif, .png,.pdf เท่านั้น    <br />
                            - ขนาดไฟล์ไม่เกิน 1024 Kb. <br />
                            - เพิ่มได้ไม่เกิน 4 รูป   <br /> <br />
                        </div>
                    </div>
                </div>
            </div> </td>                             
                            </tr>
 <tr>   <td>

       
     <asp:Button ID="cmdUpImgSW" runat="server" Text="Upload" CssClass="btn btn-success" Width="200" /> 
                            
                      </td>          
     </tr>
</table>
 </ContentTemplate>
                                <Triggers> 
                                    <asp:PostBackTrigger ControlID="cmdUpImgSW"  />
                                    <asp:AsyncPostBackTrigger ControlID="grdImgSW" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>      
              <br />
           
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate> 
                                              <asp:Label ID="lblImgSW" runat="server" CssClass="text-red"></asp:Label>               
<asp:GridView ID="grdImgSW" CssClass="table table-hover"  
                             runat="server" CellPadding="2" 
                                                        GridLines="None" 
                      AutoGenerateColumns="False"  
                             Font-Bold="False">
                        <RowStyle BackColor="#F7F7F7" />
                        <columns>
                            <asp:BoundField DataField="nRow" HeaderText="No." >
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
                                     <asp:ImageButton ID="imgDelFile" runat="server"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/delete.png" />
                                 </ItemTemplate>
                                 <ItemStyle Width="30px" />
                            </asp:TemplateField>
                                                     
                        </columns>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />                     
                        <pagerstyle HorizontalAlign="Center" 
                             CssClass="dc_pagination dc_paginationC dc_paginationC11" />                     
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <headerstyle CssClass="th" Font-Bold="True" />                     
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                     </asp:GridView>
 </ContentTemplate>
                                <Triggers>                                     
                                     <asp:PostBackTrigger ControlID="cmdUpImgSW" />
                                    <asp:AsyncPostBackTrigger ControlID="grdImgSW" EventName="RowCommand" />

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
 </div>
      <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="cmdSave" CssClass="btn btn-primary" runat="server" Text="Save" Width="120px" />
                         <asp:Button ID="cmdApprove" CssClass="btn btn-success" runat="server" Text="Approve" Width="120px" />
                        <asp:Button ID="cmdDelete" CssClass="btn btn-danger" runat="server" Text="Delete" Width="120px" />
                        <asp:Button ID="cmdBack" CssClass="btn btn-secondary" runat="server" Text="กลับหน้าหลัก" Width="120px" />
                    </div>
                </div>
     
            </section>   
</asp:Content>
