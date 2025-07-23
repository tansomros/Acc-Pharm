<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Site.Master"  CodeBehind="UserInfo.aspx.vb" Inherits="CPA.UserInfo" %>
    <%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    namespace="DevExpress.Web" tagprefix="dx" %>
        <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
            <link href="css/DragAndDrop.css" rel="stylesheet" type="text/css" />
            <script lang="javascript">
                function onUploadControlFileUploadComplete(s, e) {
                    if (e.isValid)
                        document.getElementById("uploadedImage").src = "https://acc-pharm.com/images/users/" + e.callbackData;
                    setElementVisible("uploadedImage", e.isValid);
                    document.getElementById("uploadedImage").className = "profile-user-img img-responsive img-circle";
                }

                function onImageLoad() {
                    var externalDropZone = document.getElementById("externalDropZone");
                    var uploadedImage = document.getElementById("uploadedImage");
                    uploadedImage.style.left = (externalDropZone.clientWidth - uploadedImage.width) / 2 + "px";
                    uploadedImage.style.top = (externalDropZone.clientHeight - uploadedImage.height) / 2 + "px";
                    setElementVisible("dragZone", false);
                    document.getElementById("uploadedImage").className = "profile-user-img img-responsive img-circle";

                }

                function setElementVisible(elementId, visible) {
                    document.getElementById(elementId).className = visible ? "" : "hidden";
                }
            </script>

        </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-car icon-gradient bg-mean-fruit"></i>
                        </div>
                        <div>User Information
                            <div class="page-title-subheading">แก้ไขข้อมูลส่วนตัว ของผู้ใช้งาน</div>
                        </div>
                    </div>
                </div>
            </div>
            <section class="content">
                <div class="row">
                    <section class="col-lg-4 connectedSortable">
                        <div class="box box-success">
                            <div class="box-header with-border">
                                <h2 class="box-title">รูปประจำตัว</h2>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                    <i class="fa fa-minus"></i></button>
                                </div>
                            </div>
                            <div class="box-body" align="center">

                                <div id="externalDropZone" class="dropZoneExternal">
                                    <div id="dragZone">
                                        <span class="dragZoneText">ลากรูปมาวางที่นี่</span>
                                    </div>
                                    <img id="uploadedImage" src='<% Response.Write(CPA.WebURL & CPA.PictureUser & "/" & Session("userimg")) %>' width="150" height="150" class="profile-user-img img-responsive img-circle" alt="" onload="onImageLoad()" />
                                    <div id="dropZone" class="hidden">
                                        <span class="dropZoneText">Drop an image here</span>
                                    </div>
                                </div>
                                <dx:ASPxUploadControl ID="UploadControl" ClientInstanceName="UploadControl" runat="server" UploadMode="Auto" AutoStartUpload="True" Width="80%" ShowProgressPanel="True" CssClass="uploadControl" DialogTriggerID="externalDropZone" OnFileUploadComplete="UploadControl_FileUploadComplete">
                                    <AdvancedModeSettings EnableDragAndDrop="True" EnableFileList="False" EnableMultiSelect="False" ExternalDropZoneID="externalDropZone" DropZoneText="" />
                                    <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg, .jpeg, .gif, .png" ErrorStyle-CssClass="validationMessage" />
                                    <BrowseButton Text="เลือกรูปสำหรับอัพโหลด..." />
                                    <DropZoneStyle CssClass="uploadControlDropZone" />
                                    <ProgressBarStyle CssClass="uploadControlProgressBar" />
                                    <ClientSideEvents DropZoneEnter="function(s, e) { if(e.dropZone.id == 'externalDropZone') setElementVisible('dropZone', true); }" DropZoneLeave="function(s, e) { if(e.dropZone.id == 'externalDropZone') setElementVisible('dropZone', false); }" FileUploadComplete="onUploadControlFileUploadComplete">
                                    </ClientSideEvents>                                    
                                </dx:ASPxUploadControl>

                                <div class="pull-left"> </div>
                                <div class="pull-right"> </div>

                            </div>
                            <div class="box-footer">
                                <asp:Label ID="lblNoSuccess" runat="server" ForeColor="Red" Text="Upload รูปไม่สำเร็จ กรุณาตรวจสอบไฟล์ แล้วลองใหม่อีกครั้ง" Visible="False"></asp:Label>
                            </div>
                        </div>

                    </section>

                    <section class="col-lg-8 connectedSortable">
                        <div class="box box-success">
                            <div class="box-header with-border">
                                <h2 class="box-title">ข้อมูลทั่วไป</h2>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">         <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>User ID</label>
                                            <asp:Label ID="lblUserID" CssClass="form-control text-center" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Username</label>
                                            <asp:Label ID="lblUsername" CssClass="form-control text-center" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Display name</label>
                                            <asp:TextBox ID="txtFnameTH" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เบอร์โทร</label>
                                            <asp:TextBox ID="txtTel" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>อีเมล</label>
                                            <asp:TextBox ID="txtMail" runat="server" placeholder="" CssClass="form-control special-letter"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMail" ErrorMessage="รูปแบบอีเมลไม่ถูกต้อง" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer">
                                <asp:Panel ID="pnAlert" Visible="false" runat="server">   
                                    <div class="mbg-3 alert alert-danger alert-dismissible fade show">
                                        <h4><i class="icon fa fa-ban"></i> Alert!</h4>
                                        <p>
                                            <asp:Label ID="lblAlert" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </asp:Panel>

                                 <asp:Panel ID="pnSuccess" Visible="false" runat="server">   
                                    <div class="mbg-3 alert alert-success alert-dismissible fade show">
                                        <h4><i class="icon fa fa-ban"></i> Success.</h4>
                                        <p>บันทึกข้อมูลเรียบร้อย           </p>
                                    </div>
                                </asp:Panel>


                            </div>
                        </div>
                    </section>
                </div>
                <div align="center">
                    <asp:Button ID="cmdSave" runat="server" CssClass="btn btn-success" Text="บันทึก" Width="100px" />
                </div>
            </section>
        </asp:Content>