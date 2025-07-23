<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Self.aspx.vb" Inherits="CPAQA.Self" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">     
     <script type="text/javascript">
       function openModalUpload(sender,id) { 
           $('#modal-window-upl').modal('show');
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
                        <div> การประเมิน “ ส่วนบริการตนเอง ”  
                            <div class="page-title-subheading">ส่วนที่พิเศษ  : “ ส่วนบริการตนเอง  ”  </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Main content -->
<section class="content">
    <div class="row">
        <section class="col-lg-12 connectedSortable">     
               <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon lnr-store icon-gradient bg-primary"></i>ข้อมูลร้านยา      
            </div>
            <div class="card-body table-responsive">
                                <div class="row">
                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label>ปีที่ประเมิน</label>
                                            <asp:Label ID="lblYear" runat="server" CssClass="text-red text-bold"></asp:Label>
                                        </div>
                                    </div>  
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>ชื่อร้านยา</label>
                                            <asp:Label ID="lblLocationName" runat="server" CssClass="text-blue text-bold"></asp:Label>
                                        </div>
                                    </div>                            
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>เลขที่ใบอนุญาต ขย.</label>
                                            <asp:Label ID="lblLicenseNo" runat="server" CssClass="text-bold"></asp:Label>
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
                            </div>
                        </div>

             <div class="box box-solid">
                    <div class="box-header"> 
                         <h3 class="box-title">        ข้อพิเศษในการตรวจ " ส่วนบริการตนเอง " </h3>    
    <div class="box-tools pull-right">
   <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
   </button>
 </div>          
                    
   <asp:HiddenField ID="hdLocationUID" runat="server" />
          <asp:HiddenField ID="hdRequestUID" runat="server" />
          <asp:HiddenField ID="hdSelfUID" runat="server" />
   </div> 
            <div class="box-body"> 
                     <div class="row">
                         <div class="col-md-12 text-blue">ให้ใส่ภาพที่แสดงการจัดวางผลิตภัณฑ์ในมุมบริการตนเอง “ Self Service “  โดยแสดงการจัดวางเป็นหมวดหมู่  มีการระบุกลุ่มผลิตภัณ์ชัดเจน   ( ข้อละ 1-4 ภาพ )

                      <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button> 

                         </div>
                     </div>
                <div class="row">
                                   <div class="col-md-12">
                                        <div class="form-group">
                                            <label>1. สมุนไพร                                               
                                              </label> 
                                             <asp:LinkButton ID="imgRisk1" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
   

                                        </div>
                                    </div>       

                    </div>    
                  <div class="row">
                                   <div class="col-md-12">
                                        <div class="form-group">
                                            <label>2. ยาสามัญประจำบ้าน                                                                                              
                                              </label> 
                                            <asp:LinkButton ID="imgRisk2" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>                
   

                                        </div>
                                    </div>       

                    </div>                   
                <div class="row">
                                   <div class="col-md-12">
                                        <div class="form-group">
                                            <label>3. ยาบรรจุเสร็จ (บางรายการ) 
                                                                                           
                                              </label> 
                                             <asp:LinkButton ID="imgRisk3" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>                 
   

                                        </div>
                                    </div>       

                    </div>   
                 <div class="row">
                                   <div class="col-md-12">
                                        <div class="form-group">
                                            <label>4. ผลิตภัณฑ์ที่มิใช่ยา อุปกรณ์  วัสดุการแพทย์ 
                                                                                            
                                              </label> 
                                            <asp:LinkButton ID="imgRisk4" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
   

                                        </div>
                                    </div>       

                    </div>     
                  <div class="row">
                                   <div class="col-md-12">
                                        <div class="form-group">
                                            <label>5. ยาแผนโบราณ 
                                                                                           
                                              </label> 
                                            <asp:LinkButton ID="imgRisk5" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
   

                                        </div>
                                    </div>       

                    </div>     
                  <div class="row">
                                   <div class="col-md-12">
                                        <div class="form-group">
                                            <label>6. อาหารเสริม 
                                                                                             
                                              </label> 
                                             <asp:LinkButton ID="imgRisk6" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>                 
   

                                        </div>
                                    </div>       

                    </div>     
                 <div class="row">
                                
                                   <div class="col-md-12">
                                        <div class="form-group">
                                            <label>7. อื่นๆ 
                                                                                            
                                              </label> 
                                            <asp:LinkButton ID="imgRisk7" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
                                          </div>
                                    </div> 
                    </div>                             
            </div> 
        </div>

     </section>
 </div>
    
                <div class="row">
                    <div class="col-md-12 text-center">                       
                        <asp:Button ID="cmdBack" CssClass="btn btn-secondary" runat="server" Text="กลับหน้าหลัก" Width="120px" />
                    </div>
                </div>
     
            </section>   
      <!-- Modal HTML > -->            
 <div id="modal-window-upl"  class="modal fade modal-window"  role="dialog" data-backdrop="static" tabindex="-1" style="display: none;" aria-hidden="true" >
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header-window">             
               <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h6 class="modal-title-window">อัพโหลดไฟล์รูปภาพ/เอกสาร<asp:HiddenField ID="hdAccID" runat="server" />
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
                        <div><div class="page-title-subheading">คำแนะนำ</div>
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
                                </Triggers>
                            </asp:UpdatePanel>      
              <br />
           
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate> 
                                              <asp:Label ID="Label2" runat="server" CssClass="text-red"></asp:Label>               
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
                             CssClass="dc_pagination dc_paginationC dc_paginationC01" />                     
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

	<!--- End Modal --->

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


</asp:Content>
