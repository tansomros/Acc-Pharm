<%@ Page Title="" Language="VB" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CPA._Default" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>ระบบฐานข้อมูลร้านยาสภาเภสัชกรรม</title>
        <link href="https://fonts.googleapis.com/css?family=Sarabun:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <!-- Bootstrap 3.3.7 
  < link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min.css?v=001">-->
        <!-- Font Awesome -->
        <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css?v=001">
        <!-- Ionicons -->
        <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css?v=001">
        <!-- Theme style -->
        <link rel="stylesheet" href="assets/css/AdminLTE.min.css?v=001">

        <link href="css/sb-admin.min.css?v=001" rel="stylesheet">
        <link rel="stylesheet" href="css/rajchasistyles.css?v=001">

        <!-- iCheck -->
        <link rel="stylesheet" href="plugins/iCheck/square/blue.css?v=001">
        <!-- Google Font -->
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">

        
        <link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min-login.css?v=001">
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
                    <section class="col-lg-4 connectedSortable">
                       
                    </section>
                    <section class="col-lg-4 connectedSortable">                      
                        <div class="justify-content-center">
                            <div class="col-lg-12">
                                <div class="box box-solid my-5">
                                    <div class="card-body p-0">
                                        <div class="row">                                        
                                            <div class="col-lg-12">
                                                <div class="p-5">
                                                    <div class="text-center">
                                                        <div class="login-logo">
                                                            <b>ร้านยาสภาเภสัชกรรม</b><br />
                                                        </div>
                                                    </div>
                                                    <div class="form-group has-feedback">
                                                        <label>เลขที่ใบอนุญาต ขย. หรือ Username</label>
                                                        <span class="glyphicon glyphicon-user form-control-feedback"></span>
                                                        <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" ToolTip="Username" type="login" cssclass="form-control form-control-user"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group has-feedback">
                                                        <label>รหัสผ่าน</label>
                                                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                                                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" cssclass="form-control form-control-user" TextMode="Password" ToolTip="Password" type="login">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-xs-12 text-center">
                                                            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success btn-user btn-block" Text="Login" />

                                                        </div>
                                                    </div>
                                                    <hr/>
                                                    <div class="text-center">
                                                        <a class="text-success" href="Register.aspx">ลงทะเบียน</a> หรือ 
                                                        <a class="text-success" href="ForgotPassword.aspx">ลืมรหัสผ่าน?</a>
                                                    </div>

                                                    <br /> <br /> 
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                     <section class="col-lg-4 connectedSortable">
                       
                    </section>
                </div>
                <div class="row">
                      <section class="col-lg-12 connectedSortable">                          

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
                               <h4><span id="spnTitle"></span></h4>
                                <p><span id="spnMsg"></span></p>
                                <button class="btn" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
   
    <div id="modal-warningalert" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog modal-warningalert">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="icon-box">
                                  <i class="material-icons cancel">&#xe5c9;</i>
                                </div>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body text-center">
                                <h4><span id="spnTitleW"></span></h4>
                                <p><span id="spnMsgW"></span>.</p>
                                <button class="btn" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div> 
   
    <div id="modal-warninginfo" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog modal-warninginfo">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="icon-box">
                                 <i class="material-icons warning">&#xe002;</i>
                                </div>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body text-center">
                                 <h4><span id="spnTitleInfo"></span></h4>
                                <p><span id="spnMsgInfo"></span></p>
                                <button class="btn" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>  
   
    
               
                <!--- End Modal --->
              
                <div class="footer text-center">
                    <footer class="main-footer-login">
                        <div class="text-center hidden-xs">
                            <strong>Copyright &copy; 2022-2024 <a href="https://pharmacycouncil.org">สภาเภสัชกรรม</a>.</strong> All rights reserved.
                            <br /> <b>Version</b>
                            <asp:Label ID="Label1" runat="server" Text="1.0.0"></asp:Label>&nbsp;&nbsp;<b>Release</b> 2022.06.01
                        </div>


                    </footer>
                </div>
            </div>

        </form>

        <!-- jQuery 3 -->
        <script src="bower_components/jquery/assets/jquery.min.js?v=001"></script>
        <!-- Bootstrap 3.3.7 -->
        <script src="bower_components/bootstrap/assets/js/bootstrap.min.js?v=001"></script>
        <!-- iCheck -->
        <script src="plugins/iCheck/icheck.min.js?v=001"></script>
        <script>
            $(function() {
                $('input').iCheck({
                    checkboxClass: 'icheckbox_square-blue',
                    radioClass: 'iradio_square-blue',
                    increaseArea: '20%' /* optional */
                });
            });
        </script>
    </body>

    </html>