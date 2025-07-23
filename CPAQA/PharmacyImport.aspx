<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PharmacyImport.aspx.vb" Inherits="CPAQA.PharmacyImport" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
     <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-cloud-upload icon-gradient bg-mean-fruit"></i>
                        </div>
                        <div>Pharmacy Import
                            <div class="page-title-subheading">Import ร้านยาใหม่</div>
                        </div>
                    </div>
                </div>
       </div>
    <section class="content">
     <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-file-excel-o"></i>
              <h3 class="box-title">Import New Pharmacy from Excel file</h3>             
                 <div class="box-tools pull-right">  <a href="Documents/PharmacyImport.xls?v=01" class="btn btn-success pull-right"><i class="fa fa-file-excel"></i>Template file</a>   
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
    <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-upload"></i>
              <h3 class="box-title">ตรวจสอบรายการเตรียม Import</h3>             
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>                                 
            </div>
            <div class="box-body">
                  <asp:GridView ID="grdData" 
                             runat="server" CellPadding="0" ForeColor="#333333" 
                                                        GridLines="None" Width="100%" PageSize="20" CssClass="table table-hover">
            <RowStyle BackColor="#F7F7F7" HorizontalAlign="Center" />
            <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />          
            <pagerstyle ForeColor="White" HorizontalAlign="Center" CssClass="dc_pagination dc_paginationC dc_paginationC01" />          
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <headerstyle CssClass="th" Font-Bold="True"                  VerticalAlign="Middle" />          
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
            </div>
   </div>
        </section>
</asp:Content>
