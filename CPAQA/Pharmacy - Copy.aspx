<%@ Page Title="" Language="vb" AutoEventWireup="true"   CodeBehind="Pharmacy.aspx.vb" Inherits="CPAQA.Pharmacy" %>
<%@ Import Namespace="System.Data" %>  
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>ร้านยาสภาเภสัชกรรม</title>
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

        <link rel="stylesheet" href="css/rajchasistyles.css" />
        
	<link href="css/main.css" rel="stylesheet">
	<link href="css/rajchasistyles.css" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="css/pagestyles.css" />

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
                                            <div class="header-logo">ระบบค้นหาร้านยา</div>
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
                              <div class="col-md-3 text-right pull-right bottom">
                                                               
                                  </div>
                        </div>
                    </section>
                </div>
                <div class="row">                  
    <section class="col-lg-12 connectedSortable">   
          <div class="justify-content-center">
                            <div class="col-lg-12 my-3">                                
        <div class="box box-solid">
            <div class="box-body" style="background-color: #bbe0e3;">
                <div class="row">
                      <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>กลุ่ม</label><br />
                            <asp:DropDownList ID="ddlAccPharm" runat="server" CssClass="form-control select2" AutoPostBack="true">
                                <asp:ListItem Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="Y" Selected="True">ร้านยาคุณภาพ</asp:ListItem>
                                <asp:ListItem Value="N">ไม่ใช่ร้านยาคุณภาพ</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                      <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>สถานะการรับรอง</label><br />
                            <asp:DropDownList ID="ddlAccStatus" runat="server" CssClass="form-control select2">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="A">ปกติ</asp:ListItem>
                                <asp:ListItem Value="E">หมดอายุการรับรอง</asp:ListItem>
                                <asp:ListItem Value="X">ยกเลิกการรับรอง</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>ภาค</label><br />
                            <asp:DropDownList ID="ddlProvinceGroup" runat="server" CssClass="form-control select2" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>จังหวัด</label><br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                   
                     <div class="col-lg-6 col-md-4 col-xl-12">
                        <div class="form-group">
                            <label>คำค้นหา</label><br />
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="ชื่อร้าน / เลข ขย.5 / เลขที่ใบรับรองร้านยาคุณภาพ"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-success" Width="120px"><i class="fa fa-search"></i>ค้นหา</asp:LinkButton>
                    </div>
                </div>

            </div>
        </div>

                                  <div class="main-card mb-3 card">    
        <div class="card-body">
             <h3 class="mt-0 text-bold">
                รายชื่อร้านยา</h3>
       <div class="table-responsive">  
            <table id="tbdata" class="table table-hover table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center">ชื่อร้านยา</th>
                            <th class="text-center">ที่อยู่</th>
                            <th class="text-center">จังหวัด</th>
                            <th class="text-center">กลุ่ม</th>                            
                            <th class="text-center">สถานะการรับรอง</th> 
                            <th class="text-center"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% For Each row As DataRow In dtLoc.Rows %>
                        <tr>
                            <td><% =String.Concat(row("LocationName")) %></td>
                            <td><% =String.Concat(row("LocationAddress")) %></td>
                            <td class="text-center"><% =String.Concat(row("ProvinceName")) %> </td>
                            <td class="text-center" width="120"><% =String.Concat(row("AccPharmName")) %></td>                            
                            <td class="text-center" width="120"><% =String.Concat(row("AccStatusName")) %> </td> 
                            <td class="text-center">
                                <% if String.Concat(row("Lat")) <> "" Then %>
                                <a href="https://www.google.com/maps/search/?api=1&query=<% =String.Concat(row("Lat")) & "," & String.Concat(row("Lng"))  %>" target="_blank" class="text-success" data-toggle="tooltip" data-placement="top" data-original-title="แผนที่ตั้ง"><i class="fa fa-map" aria-hidden="true"></i></a>
                                <% End If %>
                            </td>
                        </tr>
                        <%  Next %>
                    </tbody>
                </table>                              
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
                            <strong>Copyright &copy; 2022-2024 <a href="https://papc.pharmacycouncil.org">สำนักงานรับรองร้านยาคุณภาพ</a>.</strong> All rights reserved.
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


        <!-- jQuery 3 
        <script src="bower_components/jquery/assets/jquery.min.js"></script>-->
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