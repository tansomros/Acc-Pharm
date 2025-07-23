<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="QA.aspx.vb" Inherits="CPAQA.QA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">     
     <script type="text/javascript">
       function openModalUpload(sender,id) { 
           $('#modal-window-upl').modal('show');
           return false;
         }    
         function openModalUploadPJ(sender, id) {
             $('#modal-window-pj').modal('show');
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
                        <div>การประเมิน “ งานคุณภาพ ”  
                            <div class="page-title-subheading">ส่วนที่ 3 : การประเมิน “ งานคุณภาพ ”  </div>
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

                 <div class="main-card mb-3 card">
                            <div class="card-header"> 3.1   “งานคุณภาพ ”ในร้านของท่านมีอะไรบ้าง  ( 10  คะแนน )
                            <asp:HiddenField ID="hdLocationUID" runat="server" />
                                   <asp:HiddenField ID="hdQAUID" runat="server" />
                                   <asp:HiddenField ID="hdRequestUID" runat="server" />
                            </div>
                            <div class="card-body">
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>      
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>สิ่งที่ทำ / โครงการที่ร่วมงาน</label><asp:HiddenField ID="hdProjectUID" runat="server" />
                                             <asp:TextBox ID="txtProjectName" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>ทำอย่างไร</label> 
                                            <asp:TextBox ID="txtProjectAction" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>   
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>จำนวน /หลักฐานเชิงประจักษ์</label> 
                                            <asp:TextBox ID="txtProjectNumber" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="col-md-2">
                                        <div class="form-group">
                                            <label>รูปภาพ<button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                            <div class="file-upload"> 
                                                 <asp:FileUpload  ID="FileUploadA" runat="server" AllowMultiple="true" /> 
                                                  <i class="fa fa-camera"></i>
                                             </div> 
                                        </div>
                                    </div>         
                                      <div class="col-md-2">
                                        <div class="form-group">
                                           <br />
                                            <asp:Button ID="cmdAddProject" runat="server" Text="เพิ่มรายการ" CssClass="btn btn-primary" />  
                                             <asp:Button ID="cmdClearProject" runat="server" Text="ยกเลิก" CssClass="btn btn-secondary" /> 
                                        </div>
                                    </div>                                  
                                </div>  
                                   </ContentTemplate>
                                <Triggers> 
                                     <asp:PostBackTrigger ControlID="cmdAddProject" />
                                    <asp:AsyncPostBackTrigger ControlID="grdProject" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>   

                         <div class="row">  <hr />
                                    <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanelBusiness" runat="server">
                                <ContentTemplate>                                              
<asp:GridView ID="grdProject" CssClass="table table-hover"  
                             runat="server" CellPadding="2" 
                                                        GridLines="None" 
                      AutoGenerateColumns="False"  
                             Font-Bold="False">
                        <RowStyle BackColor="#F7F7F7" />
                        <columns>
                            <asp:BoundField DataField="nRow" HeaderText="No." >
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProjectName" HeaderText="สิ่งที่ทำ / โครงการที่ร่วมงาน" >
                            <HeaderStyle HorizontalAlign="Left" />  
                            </asp:BoundField>
                            <asp:BoundField DataField="Descriptions" HeaderText="ทำอย่างไร" >
                            <HeaderStyle HorizontalAlign="Left" /> 
                            </asp:BoundField>                           
                             <asp:BoundField DataField="ProjectNumber" HeaderText="จำนวน /หลักฐานเชิงประจักษ์" />
                             <asp:TemplateField HeaderText="">
                                 <ItemTemplate>    
                                     <asp:LinkButton ID="imgFilePJ" runat="server" CssClass="btn btn-success"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>'><i class="fa fa-image"></i></asp:LinkButton> 
                                 </ItemTemplate>
                                 <ItemStyle Width="50px" />
                            </asp:TemplateField>                           
                             <asp:TemplateField>
              <itemtemplate>
                    <asp:linkButton ID="imgEdit_PJ" runat="server"  Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  
                   <asp:linkButton ID="imgDel_PJ" runat="server"  Text="ลบ" CssClass="btn btn-danger" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  
                                 </itemtemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />          
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
                                    <asp:AsyncPostBackTrigger ControlID="grdProject" EventName="RowCommand" />
                                     <asp:PostBackTrigger ControlID="cmdAddProject" />
                                </Triggers>
                            </asp:UpdatePanel>           

                                    </div>
                             </div>
                        </div>
                     </div>

  <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then %>
              <div class="main-card mb-3 card-solid">  
        <div class="card-body app-page-header">  
              <div class="page-title-heading">ส่วนของผู้ประเมิน</div>                 
<div class="row">
				 <div class="col-md-2">
                                        <div class="form-group">
                                            <label>คะแนนที่ได้</label>
                                             <asp:TextBox ID="txtProjectScore" runat="server" cssclass="form-control text-center" ></asp:TextBox>
                                                                                     </div>     
                                    </div> 	
    

     <div class="col-md-6">
                                        <div class="form-group">
                                            <label>ความเห็นอื่นๆของผู้ประเมิน</label>
                                             <asp:TextBox ID="txtProjectComment" runat="server" cssclass="form-control" TextMode="MultiLine" Height="150" ></asp:TextBox>
                                        </div>     
                                    </div> 	
      <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="h5">เกณฑ์คะแนน</label> <br />
                                            
 1 =  มีแต่แบบฟอร์ม  แนวทาง<br />
 2 =  มีการทำ 1 เรื่อง แต่ไม่สม่ำเสมอ<br />
 5 =  มีการทำ 1 เรื่อง แบบสม่ำเสมอ<br />
 6  =  มีการทำมากกว่า 1 เรื่อง แบบไม่สม่ำเสมอ<br />
 8 =   มีการทำมากว่า 1 เรื่อง แบบสม่ำเสมอ<br />
10 =  มีการทำมากกว่า 1 เรื่อง สม่ำเสมอ และ
         สามารถสอนผู้อื่นได้
                                        </div>     
                                    </div> 	

    

</div> 
</div>
                  </div>
	<% End If %>


             <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-grear"></i>
              <h3 class="box-title">      3.2   การจัดการความเสี่ยง ( 10 คะแนน ) </h3>    
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                                 
            </div>
            <div class="box-body"> 
                <h6 class="text-blue">ในร้านของท่านมีวีธี หรือ ระบบ หรือ แนวทางในการจัดการความเสี่ยงต่อไปนี้ อย่างไร  
( ** การจัดการความเสี่ยง คือ การจัดให้มีแนวทางในการป้องกันเพื่อมิให้เกิดปัญหานั้นๆ เกิดขึ้น  )
&nbsp;  </h6>
                         
                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>1.  ความเสี่ยงในการที่เภสัชกรจะหยิบยาผิดจากปัญหาพ้องรูปพ้องเสียง LASA ( Look Alike  Sound Alike )  ระบุแนวทางในการป้องกัน</label>
                                             <asp:TextBox ID="txtRisk1" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ<button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                             <asp:LinkButton ID="imgRisk1" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
   

                                        </div>
                                    </div>       

                    </div>    
                  <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>2.  ความเสี่ยงในการจ่ายยาผิด นอกจากที่เกิดจากปัญหา LASA  ระบุแนวทางในการป้องกัน</label>
                                             <asp:TextBox ID="txtRisk2" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                            <asp:LinkButton ID="imgRisk2" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>                
   

                                        </div>
                                    </div>       

                    </div>                   
                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>3.  ความเสี่ยงในการมียาหมดอายุบนชั้นยา   ระบุแนวทางในการป้องกัน</label>
                                             <asp:TextBox ID="txtRisk3" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                             <asp:LinkButton ID="imgRisk3" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>                 
   

                                        </div>
                                    </div>       

                    </div>   
                 <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>4.  ความเสี่ยงในเรื่องอุณหภูมิในร้านที่ไม่เหมาะในการเก็บรักษายา  ระบุแนวทางในการป้องกัน </label>
                                             <asp:TextBox ID="txtRisk4" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                            <asp:LinkButton ID="imgRisk4" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
   

                                        </div>
                                    </div>       

                    </div>     
                  <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>5.  ความเสี่ยงในการป้องกันการแพร่เชื้อ Covid 19 ในร้าน( ระหว่างลูกค้า กับ ลูกค้า , ระหว่าง ลูกค้า กับ เภสัช) 
        ระบุแนวทางในการป้องกัน
 </label>
                                             <asp:TextBox ID="txtRisk5" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                            <asp:LinkButton ID="imgRisk5" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
   

                                        </div>
                                    </div>       

                    </div>     
                  <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>6.  ความเสี่ยงในการจ่ายยาที่ลูกค้าเคยแพ้  ระบุแนวทางในการป้องกัน </label>
                                             <asp:TextBox ID="txtRisk6" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                             <asp:LinkButton ID="imgRisk6" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>                 
   

                                        </div>
                                    </div>       

                    </div>     
                 <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>7. ความเสี่ยงที่เกิดกับคนไข้ที่มีโรคหรืออาการรุนแรงมาปรึกษาและท่านไม่สามารถให้คำแนะนำในการใช้ยาได้  ท่านมี
        แนวทางในการดำเนินการอย่างไร  
 </label>
                                             <asp:TextBox ID="txtRisk7" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                            <asp:LinkButton ID="imgRisk7" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
   

                                        </div>
                                    </div>       

                    </div>    
                 <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>8. ความเสี่ยงในการจ่ายยาให้ผู้ป่วยแล้วเกิด Drug Interaction  ท่านมี แนวทางในการป้องกันอย่างไร 
 </label>
                                             <asp:TextBox ID="txtRisk8" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                             <asp:LinkButton ID="imgRisk8" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>              
   

                                        </div>
                                    </div>       

                    </div>     
                 <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>9.   ท่านจะลดความเสี่ยงของที่ผู้ที่มารับบริการในการเกิดปัญหาจากการใช้ยา ท่านมีแนวทางในการป้องกันอย่างไร 
 </label>
                                             <asp:TextBox ID="txtRisk9" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                            <asp:LinkButton ID="imgRisk9" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>              
   

                                        </div>
                                    </div>       

                    </div>     
                   
                 <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>10.  ความเสี่ยงในการจัดการขยะที่เป็นยาเสีย ยาหมดอายุ ที่ทำให้เป็นพิษต่อสิ่งแวดล้อม ท่านมีแนวทางจัดการอย่างไร
 </label>
                                             <asp:TextBox ID="txtRisk10" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ<button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                            <asp:LinkButton ID="imgRisk10" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>                
   

                                        </div>
                                    </div>       

                    </div>     

                             
            </div> 
        </div>
      
              <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then %>
  <div class="main-card mb-3 card-solid">  
        <div class="card-body app-page-header">  
              <div class="page-title-heading">ส่วนของผู้ประเมิน</div>                         
<div class="row">
				 <div class="col-md-2">
                                        <div class="form-group">
                                            <label>คะแนนที่ได้ (เต็ม 10)</label>
                                             <asp:TextBox ID="txtRiskScore" runat="server" cssclass="form-control text-center" ></asp:TextBox>
                                        </div>     
                                    </div> 								
     <div class="col-md-10">
                                        <div class="form-group">
                                            <label>ความเห็นอื่นๆของผู้ประเมิน</label>
                                             <asp:TextBox ID="txtRiskComment" runat="server" cssclass="form-control"  TextMode="MultiLine" Height="150" ></asp:TextBox>
                                        </div>     
                                    </div> 	
  

</div>
								 
                </div>
            </div>
	<% End If %>
            <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-grear"></i>
              <h3 class="box-title">3.3  งานคุณภาพ ( ที่ควรได้รับการยกย่อง / ได้คะแนนเพิ่ม เป็นกรณีพิเศษ )   </h3>        
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                                 
            </div>
            <div class="box-body"> 
                   <div class="row">
                      <div class="col-md-12">
                                        <div class="form-group">
                                            <label>1.  ท่านมีระบบ Telepharmacy  หรือไม่ ทำอย่างไร       ( Telepharmacy  หมายถึง .... กระบวนการให้ข้อมูล คำแนะนำ คำปรึกษา จากเภสัชกรโดยผู้รับบริการไม่ต้องมาที่ร้าน  ) (2 คะแนน)</label> 
                                             <div class="input-group">                                             
                                                 <asp:RadioButtonList ID="optTelepharmacy" runat="server" RepeatDirection="Horizontal">
                                                     <asp:ListItem Value="Y">มี</asp:ListItem>
                                                     <asp:ListItem Value="N">ไม่มี</asp:ListItem>
                                                 </asp:RadioButtonList>

                                            </div>


                                        </div>
                                    </div>
                  <div class="col-md-12">
                                        <div class="form-group">
                                            <label>ถ้ามี ระบุ Platform     ระบุการใช้ระบบทางไกล  </label> 
                                             <div class="input-group">  
                                                 <table>
                                                     <tr>
                                                <!--          <td> <asp:CheckBoxList ID="chkTeleTools" runat="server" RepeatDirection="Horizontal">
                                                     <asp:ListItem Value="1">โทรศัพท์</asp:ListItem>
                                                     <asp:ListItem Value="2">Line</asp:ListItem>
                                                     <asp:ListItem Value="3">VDO Call</asp:ListItem>
                                                     <asp:ListItem Value="4">อื่นๆ</asp:ListItem>
                                                 </asp:CheckBoxList></td> -->
                                                         <td>ระบุชื่อ Platform </td>
                                                         <td><asp:TextBox ID="txtTeleOther" runat="server" Width="500" cssclass="form-control"></asp:TextBox></td>
                                                     </tr>                                                      
                                                 </table>
                                                

                                            </div>


                                        </div>
                                    </div>
                       </div>
                    <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>2.  ท่านมีกิจกรรม หรือ ทำอะไรตามมาตรฐาน 5  ( กิจกรรม / บริการสู่ชุมชนภายนอก ) อธิบาย (2 คะแนน)</label>
                                             <asp:TextBox ID="txtQ2" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                             <asp:LinkButton ID="imgQ2" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>        
                                           </div>
                                    </div>       

                    </div>                   
                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>3. ท่านมีระบบการส่งต่อ  กรณีที่จำเป็นหรือไม่...อธิบาย (2 คะแนน)</label>
                                             <asp:TextBox ID="txtQ3" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                             <asp:LinkButton ID="imgQ3" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>               
   

                                        </div>
                                    </div>       

                    </div>   
                 <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>4.  ท่านมีcase ที่ประทับใจในการเป็น “ เภสัชกรชุมชน “  ที่ผ่านมา ( Case Report ) (2 คะแนน)</label>
                                             <asp:TextBox ID="txtQ4" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ 
                                                <button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                              <asp:LinkButton ID="imgQ4" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>              
   

                                        </div>
                                    </div>       

                    </div>     
                  <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>5. กิจกรรมทางวิชาชีพเภสัชกรรมชุมชน เช่น  การเป็นพี่เลี้ยงร้านยาคุณภาพ  การเป็นอาจารย์แหล่งฝึก  
      หรือได้รับรางวัลทางวิชาชีพ  ( ย้อนหลังไม่เกิน 3 ปี ) (2 คะแนน)

 </label>
                                             <asp:TextBox ID="txtQ5" runat="server" TextMode="MultiLine" Height="150px" cssclass="form-control"></asp:TextBox>
                                        </div>     
                                    </div> 
                                   <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปภาพ<button class="btn-icon btn-icon-only btn-link no-border ico-info small" type="button" data-title="Note" data-toggle="popover-custom-bg" data-bg-class="text-white small bg-primary" data-content="ไฟล์นามสกุล .jpg, .jpeg, .gif, .png เท่านั้น ,ขนาดไฟล์ไม่เกิน 1024 Kb. เพิ่มได้ไม่เกิน 4 รูป" data-original-title="" title=""><i class="fa fa-info-circle btn-icon-wrapper"> </i></button>                                                
                                              </label> 
                                            <asp:LinkButton ID="imgQ5" runat="server" CssClass="file-upload btn btn-primary"><i class="fa fa-camera"></i></asp:LinkButton>           
   

                                        </div>
                                    </div>       

                    </div>    

            </div>
          </div> 
     
              <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then %>
  <div class="main-card mb-3 card-solid">  
        <div class="card-body app-page-header">  
              <div class="page-title-heading">ส่วนของผู้ประเมิน</div>                      
<div class="row">
				 <div class="col-md-2">
                                        <div class="form-group">
                                            <label>คะแนนที่ได้ (เต็ม 10)</label>
                                             <asp:TextBox ID="txtQAScore" runat="server" cssclass="form-control text-center" ></asp:TextBox>
                                        </div>     
                                    </div> 								
     <div class="col-md-10">
                                        <div class="form-group">
                                            <label>ความเห็นอื่นๆของผู้ประเมิน</label>
                                             <asp:TextBox ID="txtQAComment" runat="server" cssclass="form-control"  TextMode="MultiLine" Height="150" ></asp:TextBox>
                                        </div>     
                                    </div> 	
   
    

</div>


<div class="row">
				 <div class="col-md-12">
                        <div class="form-group">
                            <label>สรุป : การประเมินในส่วนงานคุณภาพ ผ่าน ใช่หรือไม่?</label>  
        <div class="button r" id="button-1"> 
              <input id="chkStatus" type="checkbox" class="checkbox" runat="server" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>

</div>
								 
                </div>
            </div>
	<% End If %>

     </section>
 </div>
     <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then %>

											<% End If %>

                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="cmdSave" CssClass="btn btn-primary" runat="server" Text="บันทึก" Width="120px" />
                              <asp:Button ID="cmdApprove" CssClass="btn btn-success" runat="server" Text="บันทึกผลการประเมิน" />
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
   <div class="col-md-12"> <asp:Label ID="lblTCode" runat="server" CssClass="h4 text-bold"></asp:Label>
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

                     
 <div id="modal-window-pj"  class="modal fade modal-window"  role="dialog" data-backdrop="static" tabindex="-1" style="display: none;" aria-hidden="true" >
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
                   <td style="width:200px"><div class="file-upload-big"><asp:FileUpload  ID="FileUploadProject" runat="server"   AllowMultiple="true" /><i class="fa fa-camera"></i></div></td>
                                <td style="width:100%" rowspan="2">
                                       <div class="app-page-header">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">                      
                        <div><div class="page-title-subheading">คำแนะนำ</div><asp:HiddenField ID="hdProjUID" runat="server" />
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

       
     <asp:Button ID="cmdUpImgPJ" runat="server" Text="Upload" CssClass="btn btn-success" Width="200" /> 
                            
                      </td>          
     </tr>
</table>
 </ContentTemplate>
                                <Triggers> 
                                    <asp:PostBackTrigger ControlID="cmdUpImgPJ" />                                    
                                    <asp:AsyncPostBackTrigger ControlID="grdImgPJ" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>      
              <br />
           
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate> 
                                              <asp:Label ID="lblImgPJ" runat="server" CssClass="text-red"></asp:Label>               
<asp:GridView ID="grdImgPJ" CssClass="table table-hover"  
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
                                    <asp:PostBackTrigger ControlID="cmdUpImgPJ" />
                                    <asp:AsyncPostBackTrigger ControlID="grdImgPJ" EventName="RowCommand" />
                                   

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
