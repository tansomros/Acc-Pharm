<%@ Page Title="จัดการข่าวประชาสัมพันธ์" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NewsAdd.aspx.vb" Inherits="CPA.NewsAdd" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %> 
<%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <div class="app-page-title">
                        <div class="page-title-wrapper">
                            <div class="page-title-heading">
                                <div class="page-title-icon">
                                    <i class="pe-7s-light icon-gradient bg-mean-fruit"></i>
                                </div>
                                <div>News & Article
                                    <div class="page-title-subheading">จัดการข่าวประชาสัมพันธ์ บนหน้าเพจเว็บไซต์</div>
                                </div>
                            </div>
                        </div>
                    </div>      

<section class="content"> 
                   
     <div class="main-card mb-3 card">
        <div class="card-header">
          จัดการข่าวประชาสัมพันธ์    
        </div>
        <div class="card-body"> 

             <div class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>News ID</label>
                                            <asp:Label ID="lblNewsID" CssClass="form-control text-center" runat="server"></asp:Label>
                                        </div>
                                    </div>
                  <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Category</label><br />
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control select2"  >
                                                <asp:ListItem Selected="True" Value="NEWS">ข่าวประชาสัมพันธ์</asp:ListItem>
                                             <asp:ListItem Value="ART">คู่มือการใช้งาน/บทความ</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
 <div class="col-md-4">
                                        <div class="form-group">
                                            <label>รูปแบบ</label> 
                                            <asp:RadioButtonList ID="optType" runat="server" RepeatDirection="Horizontal" 
                AutoPostBack="True">
                <asp:ListItem Value="URL">URL Link</asp:ListItem>
                <asp:ListItem Value="UPL">File Upload</asp:ListItem>
                <asp:ListItem Selected="True" Value="CON">เนื้อหาข่าว</asp:ListItem>
            </asp:RadioButtonList>  
                                        </div>
                                    </div>  
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>หัวข้อข่าว</label> 
                                            <asp:TextBox ID="txtHead" runat="server"   CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>    
                                </div>
             <div class="row">                   
        <asp:Panel ID="pnURL" runat="server" Width="100%">            
 <div class="col-md-12">
                                        <div class="form-group">
                                            <label>URL :</label> 
 <asp:TextBox ID="txtURL" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
                                    </div>
     </asp:Panel>
        <asp:Panel ID="pnFile" runat="server" Width="100%">
      <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Link File :</label> 
 <asp:HyperLink ID="hlnkNews" runat="server" Target="_blank">[hlnkNews]</asp:HyperLink>

                   </div>
                                    </div>   
 <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Upload File :</label> 
  
            <asp:FileUpload ID="FileUpload" runat="server" Width="300px" />
            &nbsp; (ชื่อไฟล์ต้องเป็นภาษาอังกฤษเท่านั้น) 
      
        </div>
                                    </div>     

  
       </asp:Panel>
        <asp:Panel ID="pnContent" runat="server" Width="100%">

                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>เนื้อหา</label>
                                           
                <dx:ASPxHtmlEditor ID="txtDetail" runat="server"   Width="100%" Theme="Default" Height="600px">  
                                            <SettingsDialogs>
                                                <InsertImageDialog>
                                                    <SettingsImageUpload>
                                                        <FileSystemSettings UploadFolder="~/images/news" />
                                                    </SettingsImageUpload>                                                   
                                                </InsertImageDialog>
                    </SettingsDialogs>
                                            </dx:ASPxHtmlEditor>
                                        </div>
                                    </div>
            </asp:Panel>

             </div>         
             <div class="row">
    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>ภาพหน้าปก</label>
                                               <asp:FileUpload ID="FileUploadImage" runat="server" />    
                                            <br />
                                            <asp:Image ID="imgCover" runat="server" Width="200" />
                                        </div>
                                    </div>

                 <asp:Panel ID="pnContentFile" runat="server">
                   <div class="col-md-6">
                                        <div class="form-group">
                                            <label>เอกสารแนบ</label>  
                                            <asp:FileUpload ID="FileUploadFile" runat="server" /><br />
                                           <asp:HyperLink ID="hlnkAttachs" runat="server" Target="_blank">ไม่มีเอกสารแนบ</asp:HyperLink>
&nbsp;<asp:Button ID="cmdDelFile" runat="server" CssClass="btn btn-danger" Text="ลบเอกสารแนบ" />
                <br />
              
                                        </div>
                                    </div>
             </asp:Panel>
                 </div>

            <div class="row">
                 <div class="col-md-3">
                        <div class="form-group">
                            <label>สำหรับสมาชิกเท่านั้น</label>  
        <div class="button r" id="button-1"> 
              <input id="chkIsMember" type="checkbox" class="checkbox" runat="server">          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
                   <div class="col-md-3">
                        <div class="form-group">
                            <label>Active</label>  
        <div class="button r" id="button-2"> 
              <input id="chkStatus" type="checkbox" class="checkbox" runat="server"  checked="checked" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
                 <div class="col-md-3">
                        <div class="form-group">
                            <label>ข่าวร้านยาสภาเภสัชกรรม</label>  
        <div class="button r" id="button-3"> 
              <input id="chkNews1" type="checkbox" class="checkbox" runat="server"  checked="checked" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
                 <div class="col-md-3">
                        <div class="form-group">
                            <label>ข่าวร้านยาคุณภาพ</label>  
        <div class="button r" id="button-4"> 
              <input id="chkNews2" type="checkbox" class="checkbox" runat="server" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>

                 </div>  

            
             </div> 
        <div class="card-footer justify-content-center">
       
                <asp:Button ID="bttSave" runat="server" CssClass="btn btn-success" 
                    Text="บันทึก" Width="120" />
            
              &nbsp;<asp:Button ID="cmdCancel" runat="server" CssClass="btn btn-warning" Text="&lt;&lt; กลับหน้ารายการ" />
                </div> 
      </div>
    </section>
</asp:Content>
