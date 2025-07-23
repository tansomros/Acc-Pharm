<%@ Page Title="News - ข่าวประชาสัมพันธ์" Language="VB" AutoEventWireup="true" CodeBehind="News.aspx.vb" Inherits="CPA.News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Sarabun:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <!-- Bootstrap 3.3.7 
  < link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min.css">-->
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="assets/css/AdminLTE.min.css">

    <!--   <link href="css/sb-admin.min.css" rel="stylesheet"> -->

    <link rel="stylesheet" href="css/rajchasistyles.css">

    <link href="css/style.css" rel="stylesheet" />


    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">

    <link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min-login.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function openModalWarningAlert(sender, title, message) {
            $("#spnTitleW").text(title);
            $("#spnMsgW").text(message);
            $('#modal-warningalert').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modal-warningalert').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
        function openModalWarningInfo(sender, title, message) {
            $("#spnTitleInfo").text(title);
            $("#spnMsgInfo").text(message);
            $('#modal-warninginfo').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modal-warninginfo').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
        function openModalSuccess(sender, title, message) {
            $("#spnTitleS").text(title);
            $("#spnMsgS").text(message);
            $('#modal-success').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modal-success').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
    </script>

    <!-- End modal -->
</head>

<body>
    <form id="form1" class="user" runat="server">
        <div class="container-login">
            <div class="row">
                <section class="col-lg-12 connectedSortable">
                    <div class="row">
                        <div class="col-md-9">

                            <table>
                                <tr>
                                    <td class="logo">
                                        <img src="images/logo.png" alt="" height="80" />
                                    </td>
                                    <td>
                                        <div class="header-logo">ระบบฐานข้อมูลร้านยา สภาเภสัชกรรม</div>
                                        <div class="header-appname">
                                        </div>
                                        <div class="header-text">
                                            The Pharmacy council of Thailand
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div class="col-md-3 text-right pull-right bottom">
                            <br />
                            <br />
                            <br />
                            <a href="Default.aspx" class="btn-transition btn btn-outline-success">เข้าสู่ระบบ</a>
                            <a href="Register.aspx" class="btn btn-primary">ลงทะเบียน</a>
                        </div>
                    </div>
                </section>
            </div>
            <div class="row">
                <section class="col-lg-3 connectedSortable">
                    <div class="menu-box">
                        <div class="box-body">
                            <a href="DrugStore.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                                <span class="box-icon-menu"><i class="material-icons icon-menu add_business">&#xe729;</i></span>ตรวจสอบรายชื่อร้านยา<br />
                                Drug Store                             
                            </a>
                            <a href="News.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                                <span class="box-icon-menu"><i class="material-icons icon-menu campaign">&#xef49;</i></span>ข่าวประชาสัมพันธ์<br />
                                News                             
                            </a>
                            <a href="Download.aspx?p=d" class="btn btn-menu-main btn-menu btn-block-menu">
                                <span class="box-icon-menu"><i class="material-icons icon-menu cloud_download">&#xe2c0;</i></span>ดาวน์โหลด<br />
                                Download                           
                            </a>
                            <a href="Download.aspx?p=m" class="btn btn-menu-main btn-menu btn-block-menu">
                                <span class="box-icon-menu"><i class="material-icons icon-menu auto_stories">&#xe666;</i></span> คู่มือการใช้งาน<br />
                                User manual
                            </a>
                            <a href="Contact.aspx" class="btn btn-menu-main btn-menu btn-block-menu">

                                <span class="box-icon-menu"><i class="material-icons icon-menu contact_support">&#xe94c;</i>
                                </span>ติดต่อเรา<br />
                                Contact Us
                            </a>
                        </div>
                    </div>
                </section>
                <section class="col-lg-9 connectedSortable">
                    <div class="justify-content-center">
                        <div class="col-lg-12 my-4">
   
                                <div class="main-card mb-3 card-solid">  
         <div class="card-header h3">   ข่าวประชาสัมพันธ์
              <div class="box-tools pull-right">
                 <table class="table table-no-bordered">
                <tr>                    
                    <td class="no-border">
                        <asp:TextBox ID="txtFind" runat="server" CssClass="form-control inline pull-right" Width="200px"></asp:TextBox>
                    </td>
                    <td  class="no-border justify-content-end">                
                        <asp:Button ID="cmdSearch" runat="server" CssClass="btn btn-primary pull-right" Text="ค้นหา" />    
                    </td>                  
                </tr>
            </table>
              </div>  
 

         </div>
        <div class="card-body">             
            <div class="row">
           <div class="grid-post grid-template-col-3 grid-template-list-xs grid-gap-post"> 
           
<% For i = 0 To dtNew.Rows.Count - 1 %>
               <div id="post-<% Response.Write(i) %>"  class="grid-post-item">  
            <div class="card card-sm card-post h-100">
                <div class="card-media">
                    <a target="_blank" href='<% Response.Write(dtNew.Rows(i)("NewsLink")) %>' title='<% Response.Write(dtNew.Rows(i)("NewsHead")) %>' rel="bookmark">
                            <img src="<% Response.Write(CPA.ImageCoverNews + dtNew.Rows(i)("CoverimagePath")) %>" class="attachment-post-thumbnail size-post-thumbnail wp-post-image" width="150" alt=""/>
                    </a>  
                </div>
                <div class="card-body p-2 px-sm-6 py-sm-0">
                    <div class="display-posttitle mb-2">
                        <a target="_blank" href='<% Response.Write(dtNew.Rows(i)("NewsLink")) %>'  title='<% Response.Write(dtNew.Rows(i)("NewsHead")) %>' rel="bookmark"><% Response.Write(dtNew.Rows(i)("NewsHead")) %></a>
                    </div>                  
                </div>              
            </div>       
</div>
       
<% Next %>  

           </div>
</div>
    
        <div class="row">
          <center>
                <table id="tblPaging" runat="server">
                    <tr>
                        <td style="padding-right: 7px" valign="top">
                            <asp:LinkButton ID="lnkbtnPrevious" runat="server" 
                                OnClick="lnkbtnPrevious_Click">ก่อนหน้า</asp:LinkButton>
                        </td>
                        <td valign="top">
                            <asp:DataList ID="dlPaging" runat="server" OnItemCommand="dlPaging_ItemCommand" 
                                OnItemDataBound="dlPaging_ItemDataBound" RepeatDirection="Horizontal" CssClass="dc_pagination dc_paginationC dc_paginationC11">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnPaging" runat="server" 
                                        CommandArgument='<%# Eval("PageIndex") %>' CommandName="lnkbtnPaging" 
                                        Text='<%# Eval("PageText") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td style="padding-left: 7px" valign="top">
                            <asp:LinkButton ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click">ต่อไป</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </center>
        </div>         

                        </div>
               </div>

                            <div class="main-card mb-3 card-solid">
                                <div class="card-body">
                                    <video id="studyVid" autoplay="autoplay" controls="controls" width="100%">
                                        <source src="Documents/VDO1.mp4" type="video/mp4" />
                                    </video>
                                </div>
                            </div>
                    </div>
                    </div>
                </section>

            </div>

            <!-- Modal HTML -->
            <div id="modalPopUp" class="modal fade" role="dialog" data-backdrop="static">
                <div class="modal-dialog modal-confirm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="icon-box">
                                <i class="material-icons">&#xE5CD;</i>
                            </div>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body text-center">
                            <h4><span id="spnTitle"></span></h4>
                            <p><span id="spnMsg"></span>.</p>
                            <button class="btn btn-success" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <!--- End Modal --->

            <div class="footer text-center">
                <footer class="main-footer-login">
                    <div class="text-center hidden-xs">
                        <strong>Copyright &copy; 2022-2024 <a href="https://pharmacycouncil.org">สภาเภสัชกรรม</a>.</strong> All rights reserved.
                            <br />
                        <b>Version</b>
                        <asp:Label ID="Label1" runat="server" Text="1.0.0"></asp:Label>&nbsp;&nbsp;<b>Release</b> 2022.06.01
                    </div>


                </footer>
            </div>
        </div>

    </form>

    <!-- jQuery 3 -->
    <script src="bower_components/jquery/assets/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="bower_components/bootstrap/assets/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' /* optional */
            });
        });
    </script>
</body>

</html>
