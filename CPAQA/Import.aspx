<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Import.aspx.vb" Inherits="CPAQA.Import" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
     <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-ribbon icon-gradient bg-mean-fruit"></i>
                        </div>
                        <div>Legal Import
                            <div class="page-title-subheading">Import กฎหมายใหม่</div>
                        </div>
                    </div>
                </div>
       </div>
    <section class="content">
     <div class="box box-primary">
            <div class="box-header">
              <i class="fa fa-upload"></i>
              <h3 class="box-title">Import New Legal from Excel file</h3>             
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>                                 
            </div>
            <div class="box-body">
                    <table border="0" class="table table-condensed">
       <tr>
         <td>         
                      <asp:FileUpload ID="FileUploadFile" runat="server" /> 
         </td>
         </tr>
       <tr>
         <td>
             <asp:Button ID="cmdImport" runat="server" CssClass="btn btn-primary" Text="import" Width="100px" />           </td>
         </tr>
       <tr>
         <td>
                   <asp:Label ID="lblAlert" runat="server" Text="" CssClass="alert alert-danger"  Width="100%"></asp:Label>
             <asp:Label ID="lblResult" runat="server" CssClass="alert alert-success" Width="100%"></asp:Label>           </td>
         </tr>
     </table>             
</div>
            <div class="box-footer clearfix">
             <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
             <ProgressTemplate>
                <img alt="" src="images/progress_bar.gif" height="25" />
             </ProgressTemplate>
         </asp:UpdateProgress>   
            </div>
          </div>      
        </section>
</asp:Content>
