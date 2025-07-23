<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Download.aspx.vb" Inherits="CPAQA.Download" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title><%: Page.Title %> - ระบบประเมินร้านยาคุณภาพ</title>
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


    <!--
    <link href="css/sb-admin.min.css" rel="stylesheet" />
        -->
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
                                        <img src="images/logo.png" alt="" width="150" />
                                    </td>
                                    <td>
                                        <div class="header-logo">ระบบประเมินร้านยาคุณภาพ</div>
                                        <div class="header-appname">
                                        </div>
                                        <div class="header-text">
                                            สำนักงานรับรองร้านยาคุณภาพ สภาเภสัชกรรม
                                                <br />
                                            The Office of Community Pharmacy Accreditation (Thailand)
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
                            <a href="Register" class="btn btn-primary">ลงทะเบียน</a>
                        </div>
                    </div>
                </section>
            </div>
            <div class="row">
                <section class="col-lg-3 connectedSortable">
                    <div class="menu-box">
                        <div class="box-body">
                            <a href="DrugStoreMenu.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                                <span class="box-icon-menu"><i class="material-icons icon-menu add_business">&#xe729;</i></span>ตรวจสอบรายชื่อร้านยา<br />
                                Drug Store                             
                            </a>
                            <a href="News.aspx" class="btn btn-menu-main btn-menu btn-block-menu">
                                <span class="box-icon-menu"><i class="material-icons icon-menu campaign">&#xef49;</i></span>ข่าวประชาสัมพันธ์<br />
                                News                             
                            </a>
                             <a href="Regulations.aspx?p=r" class="btn btn-menu-main btn-menu btn-block-menu">
     <span class="box-icon-menu"><i class="material-icons icon-menu verified_user">&#xe8e8;</i></span>ระเบียบ/ ประกาศ / ข้อบังคับ<br />Regulations
 </a>
                            <a href="Download.aspx?p=d" class="btn btn-menu-main btn-menu btn-block-menu active">
                                <span class="box-icon-menu"><i class="material-icons icon-menu cloud_download">&#xe2c0;</i></span>ดาวน์โหลด<br />
                                Download                           
                            </a>
                            <a href="Manual.aspx?p=m" class="btn btn-menu-main btn-menu btn-block-menu">
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
                        <div class="col-lg-12">
                            <div class="box box-solid" style="margin-top: 10px">
                                <div class="box-header">
                                    <h3 class="text-bold">
                                        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h3>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <table id="tbdata2" class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th class="text-center"></th>
                                                <th class="text-left">ชื่อรายการเอกสาร</th>
                                                <th class="text-center">วันที่อัพเดท</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <% For Each row As DataRow In dtDoc.Rows %>
                                            <tr>
                                                <td class="text-center" width="30px">
                                                    <a href="documents/<% =String.Concat(row("filepath")) %>">
                                                        <img src="images/icon/<% =String.Concat(row("fileicon")) %>" height="20" /></a>
                                                </td>
                                                <td><a href="documents/<% =String.Concat(row("filepath")) %>" target="_blank"><% =String.Concat(row("Descriptions")) %></a></td>
                                                <td class="text-center"><a href="documents/<% =String.Concat(row("filepath")) %>" target="_blank"><small><% =String.Concat(row("LastUpdate")) %></small></a></td>
                                            </tr>
                                            <%  Next %>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                        </div>
                    </div>
                </section>
            </div>
            <div class="footer text-center">
                <footer class="main-footer-login">
                    <div class="text-center hidden-xs">
                        <strong>Copyright &copy; 2022-2024 <a href="https://papc.pharmacycouncil.org">สำนักงานรับรองร้านยาคุณภาพ</a>.</strong> All rights reserved.
                            <br />
                        <b>Version</b>
                        <asp:Label ID="Label1" runat="server" Text="1.0.0"></asp:Label>&nbsp;&nbsp;<b>Release</b> 2022.06.01
                    </div>
                </footer>
            </div>
        </div>

    </form>
    <!-- DataTables -->
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <!-- จำเป็นต่อการ ยุบ/ขยาย box-->
    <script src="assets/js/adminlte.min.js"></script>

    <!-- jQuery 3 ชนกันกับข้างบน 
        <script src="bower_components/jquery/assets/jquery.min.js"></script>-->
    <!-- Bootstrap 3.3.7
        <script src="bower_components/bootstrap/assets/js/bootstrap.min.js"></script> -->

    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js"></script>

    <script>
        $(function () {
            $('#tbdata').DataTable()
            $('#tbdata2').DataTable({
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
