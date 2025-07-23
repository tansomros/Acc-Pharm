<%@ Page Title="Home Page" Language="VB" AutoEventWireup="true" CodeBehind="PDPAPolicy.aspx.vb" Inherits="CPAQA.PDPAPolicy" %>

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
                background: #eeb711;
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
                                            <img src="images/cpalogo.png" alt="" width="150" />
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
                  
                        <div class="justify-content-center">
                            <div class="col-lg-12">
                                <div class="main-card mb-3 card">
<div class="card-body">
<h3 class="card-title text-center">การแสดงความยินยอมการเก็บรวบรวม ใช้ เปิดเผย หรือสำเนาข้อมูลส่วนบุคคล</h3>
    <br /> <br />
<div class="scroll-area-lg">
<div class="scrollbar-container ps--active-y ps">
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ข้าพเจ้า <b>ให้ความยินยอม</b> กับ สำนักงานรับรองร้านยาคุณภาพ ในการเก็บรวบรวม ใช้ เปิดเผย หรือ สำเนาข้อมูลส่วนบุคคลเพื่อวัตถุประสงค์ต่างๆ ดังนี้</p>    
        <p>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 100px;">&nbsp;</td>
                    <td>1.เพื่อให้บริการการออกใบรับรองร้านยาคุณภาพ</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>2.เพื่อการศึกษา วิเคราะห์ และพัฒนาคุณภาพการให้บริการงานรับรองร้านยาคุณภาพ และด้านเภสัชกรรมอื่นๆ</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>3.เพื่อการเชื่อมโยงข้อมูลอิเล็คทรอนิคด้านเวชระเบียนระหว่าง สรร.กับ อย. ผ่านทางแอพพลิเคชั่นและเว็บไซต์</td>
                </tr>
            </table>
        </p>   
     <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; เอกสารชี้แจงข้อมูลเพิ่มเติม </p>
    <table style="width: 100%;">
                <tr>
                    <td style="width: 100px;">&nbsp;</td>
                    <td><a href="#">1.นโยบายการคุ้มครองข้อมูลส่วนบุคคล (Privacy Policy)</a>  </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><a href="#">2.คำประกาศเกี่ยวกับความเป็นส่วนตัว (Privacy Notice)</a> </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><a href="#">3.นโยบายคุกกี้ (Cookies Policy)</a> </td>
                </tr>
            </table>
    <br />
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ทั้งนี้ ก่อนการแสดงเจตนา ข้าพเจ้าได้อ่านรายละเอียดจากเอกสารชี้แจงข้อมูล หรือได้รับคำอธิบายจากสำนักงานรับรองร้านยาคุณภาพ ถึง<b>วัตถุประสงค์</b>ในการเก็บรวบรวม ใช้หรือเปิดเผย (“ประมวลผล”) ข้อมูลส่วนบุคคล และมีความเข้าใจดีแล้ว</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ข้าพเจ้าให้ความยินยอมหรือปฏิเสธไม่ให้ความยินยอมในเอกสารนี้ด้วยความสมัครใจ ปราศจากการบังคับหรือชักจูง และข้าพเจ้าทราบว่าข้าพเจ้าสามารถถอนความยินยอมนี้เสียเมื่อใดก็ได้เว้นแต่ในกรณีมีข้อจำกัดสิทธิตามกฎหมายหรือยังมีสัญญาระหว่างข้าพเจ้ากับสำนักงานรับรองร้านยาคุณภาพ ที่ให้ประโยชน์แก่ข้าพเจ้าอยู่ 
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; กรณีที่ข้าพเจ้าประสงค์จะขอถอนความยินยอม ข้าพเจ้าทราบว่าการถอนความยินยอมจะมีผลทำให้.....(ระบุผลกระทบจากการถอนความยินยอม เช่น ข้าพเจ้าอาจได้รับความสะดวกในการใช้บริการน้อยลง หรือ ไม่สามารถเข้าถึงฟังก์ชันการใช้งานบางอย่างได้ เป็นต้น)..... และข้าพเจ้าทราบว่าการถอนความยินยอมดังกล่าว ไม่มีผลกระทบต่อการประมวลผลข้อมูลส่วนบุคคลที่ได้ดำเนินการเสร็จสิ้นไปแล้วก่อนการถอนความยินยอม</p>
 
    <p></p>
</div>
</div>

    <div class="text-center">
    <asp:CheckBox ID="chkAllow" runat="server" Text="&nbsp;&nbsp;ข้าพเจ้า <b>ให้ความยินยอม</b> กับ สำนักงานรับรองร้านยาคุณภาพ ในการเก็บรวบรวม ใช้ เปิดเผย หรือ สำเนาข้อมูลส่วนบุคคลเพื่อวัตถุประสงค์ข้างต้น" /></div>
    <br />
     <div class="row justify-content-center">
        <asp:Button ID="cmdSubmit" runat="server" Text="ยินยอม" Width="120px" CssClass="btn btn-primary" />
         </div>

</div>
                                    <div class="card-footer">

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
                                    <i class="material-icons">&#xf083;</i>
                                </div>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body text-center">
                                <h4><span id="spnTitle"></h4>
                                <p><span id="spnMsg">.</p>
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