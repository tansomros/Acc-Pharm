<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="A.aspx.vb" Inherits="CPAQA.A" %>


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

        <link href="css/sb-admin.min.css" rel="stylesheet">
        <link rel="stylesheet" href="css/rajchasistyles.css">

        <!-- iCheck -->
        <link rel="stylesheet" href="plugins/iCheck/square/blue.css">
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
        <form id="form2" class="user" runat="server">
            <div class="container-login">
                <div class="row">
                    <section class="col-lg-12 connectedSortable">
                        <div class="row">
                            <div class="col-md-12">
                                <table>
                                    <tr>
                                        <td class="logo">
                                            <img src="images/logo.png" alt="" width="150" />
                                        </td>
                                        <td>
                                            <div class="header-logo">ระบบประเมินร้านยาคุณภาพ (Acc-Pharm)</div>
                                            <div class="header-appname">
                                                
                                            </div>
                                            <div class="header-text">
                                               สำนักงานรับรองร้านยาคุณภาพ สภาเภสัชกรรม
                                                <br />The Office of Community Pharmacy Accreditation (Thailand)
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </section>
                </div>
                <div class="row">
                    <section class="col-lg-3 connectedSortable">
                        <div class="menu-box">
                            <div class="box-body">     
                                 <a href="DrugStoreMenu.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                                    <span class="box-icon-menu"><i class="material-icons icon-menu add_business">&#xe729;</i></span>ตรวจสอบรายชื่อร้านยา<br/>Drug Store                             
                                </a>
                                <a href="News.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                                    <span class="box-icon-menu"><i class="material-icons icon-menu campaign">&#xef49;</i></span>ข่าวประชาสัมพันธ์<br/>News                             
                                </a>
                                 <a href="Regulations.aspx?p=r" class="btn btn-menu-main btn-menu btn-block-menu">
     <span class="box-icon-menu"><i class="material-icons icon-menu verified_user">&#xe8e8;</i></span>ระเบียบ/ ประกาศ / ข้อบังคับ<br />Regulations
 </a>
                                <a href="Download.aspx?p=d" class="btn btn-menu-main btn-menu btn-block-menu">
                                    <span class="box-icon-menu"><i class="material-icons icon-menu cloud_download">&#xe2c0;</i></span>ดาวน์โหลด<br/>Download                           
                                </a>
                                <a href="Manual.aspx?p=m" class="btn btn-menu-main btn-menu btn-block-menu">
                                    <span class="box-icon-menu"><i class="material-icons icon-menu auto_stories">&#xe666;</i></span> คู่มือการใช้งาน<br/>User manual
                                </a>
                                  <a href="Contact.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                         
                                    <span class="box-icon-menu"><i class="material-icons icon-menu contact_support">&#xe94c;</i>
                                    </span>ติดต่อเรา<br/>Contact Us
                                </a>
                            </div>
                            <!-- /.login-box-body -->
                        </div>
                    </section>
                    <section class="col-lg-9 connectedSortable">
                        <!-- Outer Row -->
                        <div class="justify-content-center">
                            <div class="col-lg-12">
                                <div class="card o-hidden border-0 shadow-lg my-5">
                                    <div class="card-body p-0">
                                        <!-- Nested Row within Card Body -->
                                        <div class="row">
                                            <div class="col-lg-8 d-none d-lg-block bg-login-image"></div>
                                            <div class="col-lg-4"> 
        <div class="text-center justify-content-center">
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <asp:Button ID="cmdApprove" CssClass="btn btn-success" runat="server" Text="Approve" Width="120px" />
             <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
              <br />
 
   </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                </div>
            
                <!-- Modal HTML -->
                
<div id="modal-success" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog modal-confirm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="icon-box">
                                  <i class="material-icons check_circle">&#xe86c;</i>
                                </div>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body text-center">
                                <h4>Success</h4>
                                <p>บันทึกข้อมูลเรียบร้อย</p>
                                <button class="btn" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
   
   
     <div id="modal-warning" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog modal-warning">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="icon-box">
                                  <i class="material-icons cancel">&#xe5c9;</i>
                                </div>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body text-center">
                                <h4><span id="spnTitle">Success</span></h4>
                                <p><span id="spnMsg">บันทึกข้อมูลเรียบร้อย</span>.</p>
                                <button class="btn btn-success" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>  

                <!--- End Modal --->
              
                <div class="footer text-center">
                    <footer class="main-footer-login">
                        <div class="text-center hidden-xs">
                            <strong>Copyright &copy; 2022-2024 <a href="https://papc.pharmacycouncil.org">สำนักงานรับรองร้านยาคุณภาพ</a>.</strong> All rights reserved.
                            <br /> <b>Version</b>
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
