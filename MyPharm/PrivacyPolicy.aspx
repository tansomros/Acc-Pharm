<%@ Page Title="Privacy Policy" Language="VB" AutoEventWireup="true" CodeBehind="PrivacyPolicy.aspx.vb" Inherits="CPA.PrivacyPolicy" %>

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
          <link rel="stylesheet" href="css/style-privacy.css">
       
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
                            <div class="col-md-12">
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
                            <div class="col-lg-12">
                                <div class="main-card mb-3 card">
<div class="card-body">
<h3 class="card-title text-center">แบบฟอร์มการขอความยินยอมให้เก็บรวบรวมและประมวลผลข้อมูลส่วนบุคคล </h3>
<div class="scroll-area-lg">

					<div class="txt-prg">
						1. ภายใต้พระราชบัญญัติคุ้มครองข้อมูลส่วนบุคคล พ.ศ. 2562 สภาเภสัชกรรมถือเป็นผู้ควบคุมข้อมูลส่วนบุคคลที่มีหน้าที่ตามกฎหมายในการคุ้มครองข้อมูลส่วนบุคคลที่อยู่ในการครอบครองหรือควบคุมของบริษัท ท่านสามารถดูนโยบายการคุ้มครองข้อมูลส่วนบุคคลของมูลนิธิเภสัชกรรมชุมชน ได้ที่<a href="https://pharmacycouncil.org" target="_blank">https://pharmacycouncil.org</a>  <br />


                        2. ข้อมูลส่วนบุคคล ได้แก่ ข้อมูลเกี่ยวกับบุคคลซึ่งทำให้สามารถระบุตัวบุคคลนั้นได้ ไม่ว่าทางตรงหรือ ทางอ้อม แต่ไม่รวมถึงข้อมูลของผู้ถึงแก่กรรมโดยเฉพาะ<br />

                        3. การเก็บรวบรวม ใช้ หรือเปิดเผยข้อมูลส่วนบุคคลของท่านจะเป็นไปเพื่อวัตถุประสงค์ในการขอเป็นสมาชิกของร้านยาสภาเภสัชกรรมเท่านั้น <br />
4. ข้อมูลส่วนบุคคลดังกล่าวจะถูกประมวลผลโดยบุคคลที่มีอำนาจที่เกี่ยวข้องกับวัตถุประสงค์ที่กล่าวไว้เท่านั้น<br />
5. การไม่ยินยอมให้ข้อมูลส่วนบุคคลดังกล่าวจะทำให้สภาเภสัชกรรมไม่สามารถดำเนินการตามวัตถุประสงค์ดังกล่าวกับท่านและทำให้ท่านไม่สามารถได้รับประโยชน์จากการดำเนินการดังกล่าว<br />
6. ท่านมีสิทธิที่จะถอนการยินยอมในการให้เก็บรวบรวม ใช้ หรือเปิดเผยข้อมูลส่วนบุคคล โดยท่านสามารถติดต่อเจ้าหน้าที่คุ้มครองข้อมูลส่วนบุคคลที่ <a href="pharmacycouncil.org" target="_blank"> pharmacycouncil.org</a><br />
7. สภาเภสัชกรรม รับรองว่ามีการดำเนินการรักษาความปลอดภัยที่มีมาตรฐาน และจัดให้มีมาตรการด้านเทคนิคและการจัดการเพื่อป้องกันการเข้าถึงข้อมูลส่วนบุคคลของท่านโดยมิชอบ<br />

                        <br />
                        รายละเอียดเพิ่มเติมอื่นๆ  <br />
                        	<div class="txt-indent">
                        - <a href="cookieprivacy.pdf" target="_blank">การประมวลผลข้อมูลส่วนบุคคลสำหรับผู้รับบริการและผู้เยี่ยมชมเว็บไซต์ </a>
                                </div>
                         
					 
					</div>  <!-- End txt-prg -->
</div>

    <div class="text-center">
    <asp:CheckBox ID="chkAllow" runat="server" Text="&nbsp;&nbsp;โดยข้าพเจ้าได้อ่านประกาศฉบับนี้และ <b>ให้ความยินยอม</b> ในการให้ข้อมูลส่วนบุคคลกับ สภาเภสัชกรรม เพื่อการดำเนินการตามวัตถุประสงค์ข้างต้น" />
        <br />
    </div>
    <br />
     <div class="row justify-content-center">
        <asp:Button ID="cmdSubmit" runat="server" Text="ยินยอม" Width="120px" CssClass="btn btn-primary" />
         </div>
      <br />  <br /> 
</div>
                                    
</div>
                                
                            </div>
                        </div>
                    </section>

                </div>
            
                <!-- Modal HTML --> 
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