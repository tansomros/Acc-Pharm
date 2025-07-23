<%@ Page Title="Home Page" Language="VB" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.vb" Inherits="CPAQA.ForgotPassword" %>
<%@ Import Namespace="System.Data" %>  
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>Forgot Password</title>
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
         
    <link href="assets/styles.css" rel="stylesheet" />

   

    <script>
      window.Promise ||
        document.write(
          '<script src="assets/polyfill.min.js"><\/script>'
        )
      window.Promise ||
        document.write(
          '<script src="assets/classList.min.js"><\/script>'
        )
      window.Promise ||
        document.write(
          '<script src="assets/findindex_polyfill_mdn.js"><\/script>'
        )
    </script>

    
    <script src="assets/apexcharts.js"></script>
    

    <script>
      // Replace Math.random() with a pseudo-random number generator to get reproducible results in e2e tests
      // Based on https://gist.github.com/blixt/f17b47c62508be59987b
      var _seed = 42;
      Math.random = function() {
        _seed = _seed * 16807 % 2147483647;
        return (_seed - 1) / 2147483646;
      };
    </script>
         <script>
    var colors = [
      '#008FFB',
      '#00E396',
      '#FEB019',
      '#FF4560',
      '#775DD0',
      '#546E7A',
      '#26a69a',
      '#D10CE8'
    ]
  </script>
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
                                            <img src="images/logo.png" alt="" width="150" />
                                        </td>
                                        <td>
                                            <div class="header-logo">ระบบประเมินร้านยาคุณภาพ</div>
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
      <section class="col-lg-12 connectedSortable">                                                  
         <div class="main-card mb-3 card">
        <div class="card-header"><i class="header-icon lnr-license icon-gradient bg-success">
            </i>  Forgot Your Password?
            <div class="btn-actions-pane-right">
              
            </div>
        </div>     
              <div class="card-body">    
                     <div class="row">
                         <div class="col-md-12">
          <div class="form-group">
            <label>ป้อน username หรือ เลขที่ใบอนุญาต ขย.5 แล้วกด request password จากนั้นระบบจะส่งรหัสผ่านให้ท่านทางอีเมลที่ได้ลงทะเบียนไว้กับเรา</label>              
          </div>
        </div>                            
                         </div>
                        <div class="row">                          
   <div class="col-md-3">
          <div class="form-group">
            <label></label>
              <asp:TextBox ID="txtUsername" runat="server" cssclass="form-control" placeholder="Username"></asp:TextBox>
          </div>
        </div>  
                              <div class="col-md-2">
          <div class="form-group">
            <label> </label>
              <br />
              <asp:Button ID="cmdSubmit" runat="server" CssClass="btn btn-primary" Text="Request Password" />
          </div>
        </div>  
                                </div>
                      
              </div>
            <div class="card-footer clearfix">
                 <asp:Label ID="lblAlert" runat="server" CssClass="alert alert-danger" Width="100%"></asp:Label>   
            <asp:Label ID="lblResult" runat="server" CssClass="alert alert-success" Width="100%"></asp:Label>   
<div class="text-center">    
                   <a href="Default.aspx" class="btn btn-warning">กลับหน้า Login</a>
 
              </div>  

            </div>
          </div>
             
         
 
</section>
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
            

    </body>

    </html>