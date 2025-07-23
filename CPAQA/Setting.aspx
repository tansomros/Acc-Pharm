<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Setting.aspx.vb" Inherits="CPAQA.Setting" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-settings icon-gradient bg-primary"></i>
                </div>
                <div>
                    Setting
                            <div class="page-title-subheading"></div>
                </div>
            </div>
        </div>
    </div>

    <section class="content">
         <div id="pnSuccess" runat="server" class="alert alert-success">
             <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
        </div>
         <div id="pnDanger" runat="server" class="alert alert-danger">
             <asp:Label ID="lblDanger" runat="server" Text=""></asp:Label>
        </div>
        <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon fa fa-cog icon-gradient bg-success"></i> 
            <div class="btn-actions-pane-right">
            </div>
            </div>
            <div class="card-body">
                <div class="row"> 
                  
                    <div class="col-md-3">
                        <div class="form-group">
                            <label></label>
                            <asp:Button ID="cmdRequestNewFDA" runat="server" CssClass="btn btn-primary" Text="Get New Pharmacy from FDA" Width="200" />
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="form-group">
                            <label></label>
                            <asp:Button ID="cmdLicenseUpdate" runat="server" CssClass="btn btn-primary" Text="Get ชื่อผู้ได้รับอนุญาต 1" width="200"/>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label></label>
                            <asp:Button ID="cmdLicenseUpdate2" runat="server" CssClass="btn btn-primary" Text="Get ชื่อผู้ได้รับอนุญาต 2" Width="200" />
                        </div>
                    </div>
                       <div class="col-md-3">
       <div class="form-group">
           <label></label>
           <asp:Button ID="cmdPharmacist" runat="server" CssClass="btn btn-primary" Text="Get ชื่อผู้มีหน้าที่ปฏิบัติการ" Width="200" />
       </div>
   </div>
                      <div class="col-md-3">
      <div class="form-group">                     
          <asp:Button ID="cmdCertName" runat="server" CssClass="btn btn-success" Text="Update ชื่อและที่อยู่ร้านยาสำหรับใบรับรอง" />
      </div>
  </div>

                     <div class="col-md-3">
                        <div class="form-group">
                            <label></label>
                            <asp:Button ID="cmdUpdateLicenseLast" runat="server" CssClass="btn btn-primary" Text="Update License Last" width="200"/>
                            
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="form-group"> 
                            <asp:Button ID="cmdUpdateNewCode" runat="server" CssClass="btn btn-primary" Text="Update FDA NewCode" width="200"/>
                        </div>
                    </div>
                      <div class="col-md-3">
                        <div class="form-group"> 
                            
                        </div>
                    </div>
                </div>
                <div class="row table-responsive">
                </div>          
            
        </div>
            </div>
    </section>
</asp:Content>
