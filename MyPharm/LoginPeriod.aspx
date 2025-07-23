<%@ Page Title="Home Page" Language="VB" AutoEventWireup="true" CodeBehind="LoginPeriod.aspx.vb" Inherits="CPAQA.LoginPeriod" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">

        <title> Login</title>
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

        <style type="text/css">
            .modal-confirm {
                color: #434e65;
                width: 525px;
            }
            
            .modal-confirm .modal-content {
                padding: 20px;
                font-size: 16px;
                border-radius: 5px;
                border: none;
            }
            
            .modal-confirm .modal-header {
                background: #e85e6c;
                border-bottom: none;
                position: relative;
                text-align: center;
                margin: -20px -20px 0;
                border-radius: 5px 5px 0 0;
                padding: 35px;
            }
            
            .modal-confirm h4 {
                text-align: center;
                font-size: 36px;
                margin: 10px 0;
            }
            
            .modal-confirm .form-control,
            .modal-confirm .btn {
                min-height: 40px;
                border-radius: 3px;
            }
            
            .modal-confirm .close {
                position: absolute;
                top: 15px;
                right: 15px;
                color: #fff;
                text-shadow: none;
                opacity: 0.5;
            }
            
            .modal-confirm .close:hover {
                opacity: 0.8;
            }
            
            .modal-confirm .icon-box {
                color: #fff;
                width: 95px;
                height: 95px;
                display: inline-block;
                border-radius: 50%;
                z-index: 9;
                border: 5px solid #fff;
                padding: 15px;
                text-align: center;
            }
            
            .modal-confirm .icon-box i {
                font-size: 58px;
                margin: -2px 0 0 -2px;
            }
            
            .modal-confirm.modal-dialog {
                margin-top: 80px;
            }
            
            .modal-confirm .btn {
                color: #fff;
                border-radius: 4px;
                background: #eeb711;
                text-decoration: none;
                transition: all 0.4s;
                line-height: normal;
                border-radius: 30px;
                margin-top: 10px;
                padding: 6px 20px;
                min-width: 150px;
                border: none;
            }
            
            .modal-confirm .btn:hover,
            .modal-confirm .btn:focus {
                background: #eda645;
                outline: none;
            }
            
            .trigger-btn {
                display: inline-block;
                margin: 100px auto;
            }
        </style>
        <link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min-login.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <script type="text/javascript">
            function openModals(sender, title, message) {
                $("#spnTitle").text(title);
                $("#spnMsg").text(message);
                $('#modalPopUp').modal('show');
                $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
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
                            <div class="col-md-12">
                                <table>
                                    <tr>
                                        <td class="logo">
                                            <img src="images/lalogo3.png" alt="" width="150">
                                        </td>
                                        <td>
                                            <div class="header-logo">i-LA</div>
                                            <div class="header-appname">
                                                ระบบประเมินร้านยาคุณภาพ
                                            </div>
                                            <div class="header-text">
                                                บริษัท เอ็นพีซี เซฟตี้ แอนด์ เอ็นไวรอนเมนทอล เซอร์วิส จำกัด
                                                <br />และ บริษัท รักษาความปลอดภัย เอ็นพีซี เอสแอนด์อี จำกัด
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </section>
                </div>
                <div class="row justify-content-center">                  
                    <section class="col-lg-6 connectedSortable">              
                        <div class="justify-content-center">
                            <div class="col-lg-12">
                                <div class="card o-hidden border-0 shadow-lg my-5">
                                    <div class="card-body p-0">
                                        <div class="row">                                      
                                            <div class="col-lg-12 justify-content-center">
                                                <div class="p-5">
                                                    <div class="text-center">
                                                        <div class="login-logo">
                                                            <b>Period</b><br />
                                                        </div>
                                                    </div>
                                                    <div class="row justify-content-center">
                                                        <div class="col-xs-8 text-center">
                                                        <asp:DropDownList ID="ddlPeriod" cssclass="form-control select2" runat="server"></asp:DropDownList>  
                                                             <br />
                                                    </div>
                                                   </div>
                                                    <div class="row justify-content-center">
                                                        <div class="col-xs-6 text-center">
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="OK" />

                                                        </div>
                                                    </div>
   <br /> <br />
                                                    <hr />                                                

                                                 
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                </div>
                <div class="row">
                    <section class="col-lg-12 connectedSortable">
                        <div class="row text-center">
                            <div class="col-md-3">
                                <div>
                                    <a href="#"><img src="images/phone.png" alt="" width="64"></a>
                                </div>
                                <div class="header-text"><a href="#">038-977777<br /> 061-3454646</a></div>
                            </div>
                            <div class="col-md-3">
                                <div>
                                    <div>
                                        <a href="mailto:Narutchai.c@npc-se.co.th"><img src="images/message.png" alt="" width="64"></a>
                                    </div>
                                    <div class="header-text"><a href="mailto:Narutchai.c@npc-se.co.th">Narutchai.c@npc-se.co.th</a></div>
                                </div>
                                </a>
                            </div>
                            <div class="col-md-3">

                                <div>
                                    <div>
                                        <a href="#"><img src="images/user_manual.png" alt="" width="64"></a>
                                    </div>
                                    <div class="header-text"> <a href="#">คู่มือการใช้งาน</a></div>
                                </div>

                            </div>
                            <div class="col-md-3">

                                <div>
                                    <div>
                                        <a href="#"><img src="images/play_button.png" alt="" width="64"></a>
                                    </div>
                                    <div class="header-text"> <a href="#">VDO วิธีการใช้งาน</a></div>
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
                            <strong>Copyright &copy; 2021-2022 <a href="https://www.npc-se.co.th">NPC S&E</a>.</strong> All rights reserved.
                            <br /> <b>Version</b>
                            <asp:Label ID="Label1" runat="server" Text="1.0.0"></asp:Label>&nbsp;&nbsp;<b>Release</b> 2020.12.28
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