<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeBehind="Contact.aspx.vb" Inherits="CPA.Contact" %>
<%@ Import Namespace="System.Data" %>  
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>ติดต่อเรา</title>
        <link href="https://fonts.googleapis.com/css?family=Sarabun:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
        <!-- Bootstrap 3.3.7 
  < link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min.css">-->
        <!-- Font Awesome -->
        <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css" />
        <!-- Ionicons -->
        <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css" />
        <!-- Theme style -->
        <link rel="stylesheet" href="assets/css/AdminLTE.min.css" />

        <link href="css/sb-admin.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="css/rajchasistyles.css" />
        <!-- DataTables -->
	<link rel="stylesheet" href="bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css" />
        <!-- iCheck -->
        <link rel="stylesheet" href="plugins/iCheck/square/blue.css" />
        <!-- Google Font -->
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />
         
        <link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min-login.css" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
         
        
         
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
                              <div class="col-md-3 text-right pull-right bottom">
                                 <br />  <br />  <br />
                                  <a href="Default.aspx" class="btn-transition btn btn-outline-success">เข้าสู่ระบบ</a>
                                   <a href="Register" class="btn btn-primary">ลงทะเบียน</a>                                   
                                  </div>
                        </div>
                    </section>
                </div>
                <div class="row">
                      <section class="col-lg-3 connectedSortable">
                        <div class="menu-box">
                            <div class="box-body">             
                                 <a href="DrugStore.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                                    <span class="box-icon-menu"><i class="material-icons icon-menu add_business">&#xe729;</i></span>ตรวจสอบรายชื่อร้านยา<br/>Drug Store                             
                                </a>
                                 <a href="News.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                                    <span class="box-icon-menu"><i class="material-icons icon-menu campaign">&#xef49;</i></span>ข่าวประชาสัมพันธ์<br/>News                             
                                </a>
                                <a href="Download.aspx?p=d" class="btn btn-menu-main btn-menu btn-block-menu">
                                    <span class="box-icon-menu"><i class="material-icons icon-menu cloud_download">&#xe2c0;</i></span>ดาวน์โหลด<br/>Download                           
                                </a>
                                <a href="Download.aspx?p=m" class="btn btn-menu-main btn-menu btn-block-menu">
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
                        
                        <div class="justify-content-center">
                            <div class="col-lg-12 my-5">
                                  <div class="main-card mb-3 card">    
        <div class="card-body">
             <h3 class="card-title mt-0 text-bold">
                 สภาเภสัชกรรม
             </h3>
            <div class="row">                                                              
                                    <div class="col-md-5">
                                        <div class="form-group">
                                           <i class="fa fa-building px-3"></i>อาคารมหิตลาธิเบศร ชั้น 8 กระทรวงสาธารณสุข	 <br />
 	<span class="px-3"><span class="px-3"><span class="px-3">เลขที่ 88/19 หมู่ 4 ถนนติวานนท์ ตำบลตลาดขวัญ</span></span></span>
 <br />	<span class="px-3"><span class="px-3"><span class="px-3">อำเภอเมือง จังหวัดนนทบุรี 11000</span></span></span>
                                        </div>
                                    </div>
                       <div class="col-md-4">
                                        <div class="form-group">
                                           <i class="fa fa-mobile px-3"></i>0 2591 9992-5 กด 6 <br />	
 	<i class="fa fa-fax px-3"></i>0 2591 9996
 <br />	<i class="fa fa-envelope px-3"></i>xxxxx@pharmacycouncil.org
                                             <br />	<i class="fa fa-qrcode px-3"></i><a href="https://line.me/ti/g/B8JVsnP_QI">line.me/ti/g/B8JVsnP_QI</a>
                                        </div>
                                    </div>
                 <div class="col-md-2">
                                        <div class="form-group">
                                            <label>@Line group.</label><br />
                                            <img src="images/lineid.jpg" height="150" />
                                        </div>
                                    </div>


                        





                                        </div>
      <div class="row">                                                              
                                    <div class="col-md-12">

            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d5023.871376079183!2d100.52433256078683!3d13.84298036656766!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xb3aaa2c0ba72d485!2z4Liq4Lig4Liy4LmA4Lig4Liq4Lix4LiK4LiB4Lij4Lij4Lih!5e0!3m2!1sth!2sth!4v1655374416421!5m2!1sth!2sth" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                                        </div>
          </div>
                                    </div>
                                </div>
                            </div>
                        </div>                       
                    </section>

                </div>
                           
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
        <!-- DataTables -->
	<script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
	<script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>

        <!-- jQuery 3 -->
        <script src="bower_components/jquery/assets/jquery.min.js"></script>
        <!-- Bootstrap 3.3.7 -->
        <script src="bower_components/bootstrap/assets/js/bootstrap.min.js"></script>
        <!-- iCheck -->
        <script src="plugins/iCheck/icheck.min.js"></script>
      
        <script>
            $(function () {
                $('#tbdata').DataTable()
                $('#MainContent_grdData').DataTable()
                $('#grdData2').DataTable({
                    'paging': true,
                    'lengthChange': true,
                    'searching': true,
                    'ordering': true,
                    'info': true,
                    'autoWidth': false
                })
            })
        </script>
    </body>

    </html>