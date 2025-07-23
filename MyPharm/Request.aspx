<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Request.aspx.vb"
    Inherits="CPA.Request" %>

    <%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
        namespace="DevExpress.Web" tagprefix="dx" %>

        <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
   
        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-note icon-gradient bg-success"></i>
                        </div>
                        <div>ยื่นคำขอแก้ไขข้อมูล
                            <div class="page-title-subheading">New Request</div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Main content -->
<section class="content">
    <div class="row">
        <section class="col-lg-12 connectedSortable">
            <div class="main-card mb-3 card">
                            <div class="card-header">ยื่นคำขอเปลี่ยนแปลงข้อมูล<asp:HiddenField ID="hdRequestUID" runat="server" />
                            </div>
                            <div class="card-body">

                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>เลขที่คำขอ</label>
                                            <asp:TextBox ID="txtCode" runat="server" cssclass="form-control text-center" ReadOnly="true" placeholder="Auto Running"></asp:TextBox>
                                        </div>
                                    </div>    
                                    <!--
                                    <div class="col-md-10">
                                        <div class="form-group">
                                            <label>เลือกประเภทคำขอ</label>
                                              <asp:DropDownList ID="ddlType" runat="server"  cssclass="form-control select2">      
                                            </asp:DropDownList>
                                        </div>

                                    </div> -->
                                                           
                                    <div class="col-md-5">
                                        <div class="form-group">
                                            <label>ชื่อผู้ยื่นคำขอ</label>
                                            <asp:TextBox ID="txtFname" runat="server" cssclass="form-control" placeholder="First Name"></asp:TextBox>
                                          
                                        </div>
                                    </div> 
                                    <div class="col-md-5">
                                        <div class="form-group">
                                            <label>นามสกุล</label>
                                            <asp:TextBox ID="txtLname" runat="server" cssclass="form-control" placeholder="Last Name"></asp:TextBox>
                                        </div>     
                                    </div> 
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>อีเมล</label>
                                              <asp:TextBox ID="txtEmail" runat="server" cssclass="form-control special-letter" placeholder="E-mail"></asp:TextBox>
                                        </div>
                                    </div>   
                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เบอร์โทร</label>
                                              <asp:TextBox ID="txtTel" runat="server" cssclass="form-control" placeholder="Phone Number"></asp:TextBox>
                                        </div>
                                    </div>  
                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Line Id.</label>
                                              <asp:TextBox ID="txtLineID" runat="server" cssclass="form-control special-letter" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>  
                                        </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>ความเกี่ยวข้องกับร้านยา</label>
                                            <asp:DropDownList ID="ddlRequesterType" runat="server" cssclass="form-control select2">
                                                <asp:ListItem Value="1">ผู้ดำเนินกิจการ / ผู้รับอนุญาต</asp:ListItem>
                                                <asp:ListItem Value="2">ผู้รับอนุญาต + เภสัชกร</asp:ListItem>
                                                <asp:ListItem Value="3">เภสัชกร </asp:ListItem>
                                                <asp:ListItem Value="9">อื่นๆ</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <label>กรณีอื่นๆ (ระบุ)</label>
                                              <asp:TextBox ID="txtRequesterOther" runat="server" cssclass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>  
                                </div>           
                            </div> 
                        </div>
     </section>
 </div>

                <div class="row justify-content-center">                 
<!--
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Active</label>  
        <div class="button r" id="button-1"> 
              <input id="chkStatus" type="checkbox" class="checkbox" runat="server" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
-->
                    <div class="col-md-12 text-center">
                        <asp:Button ID="cmdSave" CssClass="btn btn-primary" runat="server" Text="บันทึกคำขอ" Width="120px" />
                    </div>
                </div>

            </section>
        </asp:Content>