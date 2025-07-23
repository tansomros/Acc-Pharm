<%@ Page Title="ข่าวประชาสัมพันธ์" Language="VB" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.vb" Inherits="CPA.NewsDetail" %>

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
                                            <div class="header-text">The Pharmacy council of Thailand
                                            </div>
                                        </td> 
                                    </tr>
                                </table>
                            </div>                           
                        </div>
                    </section>
                </div>
                <div class="row">               
                    <section class="col-lg-12 connectedSortable">
                    <div class="justify-content-center">
                            <div class="col-lg-12 my-4">   
                                <div class="main-card mb-3 card">  
         <div class="card-header"><asp:Label ID="lblSubject" runat="server"></asp:Label>           

         </div>
        <div class="card-body">             
           
    <table style="width:100%;">
        <tr>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left">
             
                <asp:Label ID="lblDetail" runat="server" style="color: #000000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;&nbsp;
                &nbsp;<br />
                <img alt="" src="Images/icon/attach.png" /> <asp:Label 
                    ID="lblAttach" runat="server" ForeColor="Black" Text="ไม่มีไฟล์แนบ" 
                    style="font-size: small"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <img  src="Images/icon/update.png" /> <asp:Label 
                    ID="lblTextUpdated" runat="server" Font-Italic="True" 
                    style="font-size: small">ปรับปรุงเมื่อ</asp:Label>
                &nbsp;<asp:Label ID="lblUpdated" runat="server" Font-Italic="True" 
                    style="font-size: small"></asp:Label>
                &nbsp;<asp:Label ID="lblTextRead" runat="server" Font-Italic="True" 
                    style="font-size: small">อ่านแล้ว</asp:Label>
                &nbsp;<asp:Label ID="lblRead" runat="server" Font-Italic="True" 
                    style="font-size: small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
    </table>
 
    
            

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