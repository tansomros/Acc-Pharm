<%@ Page Title="อัพโหลดเอกสาร" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DownloadAdd.aspx.vb" Inherits="CPAQA.DownloadAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
      <div class="app-page-title">
                        <div class="page-title-wrapper">
                            <div class="page-title-heading">
                                <div class="page-title-icon">
                                    <i class="pe-7s-download icon-gradient bg-mean-fruit"></i>
                                </div>
                                <div>อัพโหลดเอกสาร
                                    <div class="page-title-subheading">จัดการเอกสารดาวน์โหลด</div>
                                </div>
                            </div>
                        </div>
                    </div>      


      <section class="content">

        <div class="box box-success">
        <div class="box-header with-border">
          <h2 class="box-title">อัพโหลดเอกสาร</h2>

          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip"
                    title="Collapse">
              <i class="fa fa-minus"></i></button>
           
          </div>
        </div>
        <div class="box-body">
              <div class="row"> 
           <div class="col-md-1">
          <div class="form-group">
            <label>ID</label>
              <asp:Label ID="lblUID" runat="server" CssClass="form-control text-center"></asp:Label> 
          </div>
        </div>      
           <div class="col-md-6">
          <div class="form-group">
                    <label>ประเภท</label> <br />
              <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control select2">                      </asp:DropDownList> 
          </div>
        </div>  
                  </div>
                   <div class="row"> 
         <div class="col-md-12">
          <div class="form-group">
                    <label>ชื่อเอกสาร</label>
              <asp:TextBox ID="txtDescriptions" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
          </div>
        </div>  
                  </div>
              <div class="row">   
                    <div class="col-md-3">
          <div class="form-group">
                    <label>ไฟล์เอกสาร</label>
   <asp:FileUpload ID="FileUpload1" runat="server" Width="80%" />
          </div>
        </div>  

                    <div class="col-md-3">
          <div class="form-group">
                    <label></label><asp:HyperLink ID="hlnkDoc" runat="server" Target="_blank">[hlnkDoc]</asp:HyperLink>
             
          </div>
        </div>  
                   <div class="col-md-3">
                        <div class="form-group">
                            <label>สำหรับสมาชิกเท่านั้น</label>  
        <div class="button r" id="button-1"> 
              <input id="chkIsMember" type="checkbox" class="checkbox" runat="server" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
                   <div class="col-md-3">
                        <div class="form-group">
                            <label>Active</label>  
        <div class="button r" id="button-2"> 
              <input id="chkStatus" type="checkbox" class="checkbox" checked="checked" runat="server" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
                   <div class="col-md-3">
                        <div class="form-group">
                            <label>สำหรับร้านยาสภาเภสัชกรรม</label>  
        <div class="button r" id="button-3"> 
              <input id="chkNews1" type="checkbox" class="checkbox" runat="server">          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
                 <div class="col-md-3">
                        <div class="form-group">
                            <label>สำหรับร้านยาคุณภาพ</label>  
        <div class="button r" id="button-4"> 
              <input id="chkNews2" type="checkbox" class="checkbox" runat="server" checked="checked">          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
                  </div>

             

 </div>
        <!-- /.box-body -->
        <div class="box-footer justify-content-center">
         <asp:Button ID="cmdSave" runat="server" CssClass="btn btn-primary" Text="บันทึก" Width="100px" />
              &nbsp;<asp:Button ID="cmdCancel" runat="server" CssClass="btn btn-warning" Text="&lt;&lt; กลับหน้ารายการ" />
        </div>
        <!-- /.box-footer-->
      </div>
      <!-- /.box -->   

          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />

  </section>                  



</asp:Content>
