<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="RegisterNew.aspx.vb" Inherits="CPA.RegisterNew" %>
 <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>Register - ลงทะเบียน</title>
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
         <!-- iCheck -->
  <link rel="stylesheet" href="plugins/iCheck/flat/blue.css">
      <link rel="stylesheet" href="plugins/iCheck/all.css">

            <!-- Select2 -->
  <link rel="stylesheet" href="bower_components/select2/assets/css/select2.min.css">
        <!-- Google Font -->
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">

      
        <link rel="stylesheet" href="bower_components/bootstrap/assets/css/bootstrap.min-login.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
        <script type="text/javascript">
            function openModalWarningAlert(sender, title, message) {
                $("#spnTitle").text(title);
                $("#spnMsg").text(message);
                $('#modal-warningalert').modal('show');
                $('#btnConfirm').attr('onclick', "$('#modal-warningalert').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
                return false;
            }        
        </script>

        <!-- End modal -->

        <script language="javascript">
            function AllowOnlyIntegers() {
                var keyCode = event.keyCode;
                if (keyCode >= 48 && keyCode <= 57) {
                    event.returnValue = true;
                } else {
                    event.returnValue = false;
                }
            }
            function AllowOnlyDouble() {
                var keyCode = event.keyCode;
                if (keyCode >= 48 && keyCode <= 57) {
                    event.returnValue = true;
                } else if (keyCode == 46) {
                    event.returnValue = true;
                } else {
                    event.returnValue = false;
                }
            }
            function AllowOnlyEnglishs() {
                var keyCode = event.keyCode;
                if (keyCode >= 58 && keyCode <= 122) {
                    event.returnValue = true;
                } else {
                    event.returnValue = false;
                }
            }
            function NotAllowOther() {
                var keyCode = event.keyCode;
                if (keyCode >= 128) {
                    event.returnValue = true;
                } else {
                    event.returnValue = false;
                }
            }
            function NotAllowThai() {
                var keyCode = event.keyCode;
                if (keyCode >= 45 && keyCode <= 57) {
                    event.returnValue = true;
                } else if (keyCode >= 64 && keyCode <= 90) {
                    event.returnValue = true;
                } else if (keyCode == 95) {
                    event.returnValue = true;
                } else if (keyCode >= 97 && keyCode <= 122) {
                    event.returnValue = true;
                } else if (keyCode == 127) {
                    event.returnValue = true;
                } else if (keyCode == 150) {
                    event.returnValue = true;
                } else {
                    event.returnValue = false;
                }
            }

        </script>
    </head>

    <body>
        <form id="form1" class="user" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                            <div class="header-text">The Pharmacy council of Thailand</div>
                                        </td> 
                                    </tr>
                                </table>
                            </div>

                              <div class="col-md-3 pull-right bottom">
                                 <br />  <br />  <br />
                                  <a href="Default.aspx" class="btn-transition btn btn-outline-success">เข้าสู่ระบบ</a>
                                   <a href="Register" class="btn btn-primary">ลงทะเบียน</a>                                   
                                  </div>
                        </div>
                    </section>
                </div>
                <div class="row">
                    <section class="col-lg-12 connectedSortable"> 
                        <div class="justify-content-center">
                            <div class="col-lg-12">
                                <div class="main-card mb-3 card">
                                                 <div class="card-header">
<i class="header-icon lnr-store icon-gradient bg-mixed-hopes"> </i><b>ข้อมูลร้านยา</b> 
<div class="btn-actions-pane-right actions-icon-btn pull-right">
 <asp:Label ID="lblNewCode" runat="server" CssClass="small"></asp:Label>
</div>
</div>
                                    <div class="card-body">
                                        <div class="row"> 
                                            <div class="col-lg-12">
                                                <div class="p-2">
                                                     
                                <div class="row">                                                              
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label>ชื่อร้านยา</label><small class="text-red"> *</small>
                                            <asp:TextBox ID="txtLocationName" runat="server" cssclass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
                                       <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เลขที่ใบอนุญาต ขย 5</label><small class="text-red"> *</small>
                                              <asp:TextBox ID="txtLicenseNo1" runat="server" CssClass="form-control text-blue text-bold text-center" BackColor="White" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <label>สถานที่ตั้งเลขที่</label><small class="text-red"> *</small>
                                            <asp:TextBox ID="txtAddressNo" runat="server" cssclass="form-control" placeholder="เลขที่/หมู่/ซอย/ถนน"></asp:TextBox>
                                        </div>
                                    </div>                                 
                                                                        <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label>หมู่ที่</label>
                                                        <asp:TextBox ID="txtMoo" runat="server" CssClass="form-control" placeholder="หมู่ที่"></asp:TextBox>
                                                    </div>
                                                </div>
                                                 <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>ถนน</label>
                                                        <asp:TextBox ID="txtRoad" runat="server" CssClass="form-control" placeholder="ถนน/ซอย"></asp:TextBox>
                                                    </div>
                                                </div>
                                     </div>
                                <div class="row">
  <div class="col-md-3">
                                        <div class="form-group">
                                            <label>แขวง/ตำบล</label><small class="text-red"> *</small>
                                            <asp:TextBox ID="txtSubDistict" runat="server" cssclass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label>เขต/อำเภอ</label><small class="text-red"> *</small>
                                            <asp:TextBox ID="txtDistrict" runat="server" cssclass="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                    </div>
 <div class="col-md-3">
                                        <div class="form-group">
                                            <label>จังหวัด</label>
                                            <asp:DropDownList CssClass="form-control select2"  ID="ddlProvince" runat="server"> </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label>รหัสไปรษณีย์</label><small class="text-red"> *</small>
                                            <asp:TextBox ID="txtZipCode" runat="server" cssclass="form-control" MaxLength="5"></asp:TextBox>
                                        </div>
                                    </div>
 </div>
                                <div class="row">
                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label>เบอร์โทร</label><small class="text-red"> *</small>
                                            <asp:TextBox ID="txtTel" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="col-md-3">
                                        <div class="form-group">
                                            <label>E-mail</label><small class="text-red"> *</small>
                                            <asp:TextBox ID="txtEmail" runat="server" cssclass="form-control special-letter"></asp:TextBox>                                            
                                        </div>
                                    </div>

                                      <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Line ID</label>
                                            <asp:TextBox ID="txtLineID" runat="server" cssclass="form-control special-letter"></asp:TextBox>
                                        </div>
                                    </div>

                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Facebook</label>
                                            <asp:TextBox ID="txtFacebook" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                     </div>
                                <div class="row">
                                     <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>ละติจูด,ลองจิจูด (ในรูปแบบองศาทศนิยมเท่านั้น และคั่นชุดข้อมูลด้วยคอมม่า (,)) </label><small class="text-red"> *</small>
                                                        <asp:TextBox ID="txtLat" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>   

                                      <div class="col-md-6">
                                        <div class="form-group">
                                            <label>เวลาทำการร้าน</label>
                                            <asp:TextBox ID="txtWorkTime" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                  
                    </div>
                                <div class="row">
                                 
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เลขที่ใบอนุญาตขายยาเสพติดให้โทษประเภท 3</label>
                                            <asp:TextBox ID="txtLicenseNo2" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
  <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เลขที่ใบอนุญาตจำหน่ายวัตถุออกฤทธิ์ต่อจิตประสาท</label>
                                            <asp:TextBox ID="txtLicenseNo3" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
 </div>
                         <div class="row">
                                     <div class="col-md-8">
                                        <div class="form-group">
                                            <label>ชื่อผู้รับอนุญาต</label><small class="text-red"> *</small>
                                            <asp:TextBox ID="txtLicensee" runat="server" cssclass="form-control"></asp:TextBox>
                                        </div>
                                    </div> 
                                     <div class="col-md-4">
                                        <div class="form-group mailbox-messages">
                                            <label>ประเภท</label>                                              
                                                      <asp:RadioButtonList ID="optLicenseeType" runat="server" 
                                                          RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="1">บุคคล</asp:ListItem>
                                                    <asp:ListItem Value="2">นิติบุคคล/บริษัท</asp:ListItem>
                                                  </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div> 

                                      
                <div class="row">
                      <div class="col-md-2">
                                        <div class="form-group">
                                            <label>จำนวนคูหา</label>
                                             <div class="input-group">                                             
                                                <asp:TextBox ID="txtArea1" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                                
                                            </div>


                                        </div>
                                    </div>
                       <div class="col-md-2">
                                        <div class="form-group">
                                            <label>พื้นที่ (ตร.ม.)</label>
                                             <div class="input-group">                                             
                                                <asp:TextBox ID="txtArea2" runat="server" CssClass="form-control text-center"></asp:TextBox>
                                                
                                            </div>


                                        </div>
                                    </div>                        
                      <div class="col-md-4">


                                        <div class="form-group">
                                            <label>กลุ่มร้านยา</label>
                                             <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True" CssClass="form-control select2" >                                                        </asp:DropDownList>  
                                        </div>     
                                    </div> 
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>ระบุ (กรณีร้านยา Chain/มีสาขา)</label>
                                            <asp:UpdatePanel ID="udpChain" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlChain" runat="server"  cssclass="form-control select2">
                                            </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                           

                                        </div>
                                    </div>   
                               
            </div>
<div class="row">
												<div class="col-md-12">
													<div class="form-group">
														<label>ประเภทร้านยา</label>													
                                     <asp:CheckBoxList ID="chkLocationType" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"></asp:CheckBoxList>

													</div>
												</div>        
                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>เป็นร้านยาคุณภาพ</label>
                                                        <div class="button r" id="button-1">
                                                            <input id="chkAccPharm" type="checkbox" class="checkbox" runat="server" />
                                                            <div class="knobs"></div>
                                                            <div class="layer"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                      <div class="col-md-4">
                                        <div class="form-group">
                                            <label>เป็นร้านยาคุณภาพตั้งแต่ปี พ.ศ.</label>
                                            <asp:TextBox ID="txtQAYear" runat="server" cssclass="form-control text-center" placeholder="ถ้ายังไม่เป็นร้านยาคุณภาพให้ว่างไว้หรือใส่ 0"></asp:TextBox>
                                        </div>
                                    </div> 
                                                     <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>รหัสหน่วยบริการ สปสช.(Dxxxx)</label>
                                                        <asp:textbox ID="txtNHSOCode" runat="server" CssClass="form-control text-center"></asp:textbox>
                                                    </div>
                                                </div>
                                                    </div>
 
<div class="row justify-content-center">
<asp:Button ID="cmdSave" runat="server" Width="120" CssClass="btn btn-primary btn-user btn-block" Text="ลงทะเบียน" /> 
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

                </div>
 <!-- Modal HTML -->                  
               <div id="modal-warningalert" class="modal fade" role="dialog" data-backdrop="static">
                    <div class="modal-dialog modal-warningalert">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="icon-box">
                                 <i class="material-icons warning">&#xe002;</i>
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
                <!--- End Modal --->
              
                <div class="footer text-center">
                    <footer class="main-footer-login">
                        <div class="text-center hidden-xs">
                            <strong>Copyright &copy; 2022-2024 <a href="https://pharmacycouncil.org">สภาเภสัชกรรม</a>.</strong> All rights reserved.
                            <br /> <b>Version</b>
                            <asp:Label ID="Label1" runat="server" Text="1.0.0"></asp:Label>&nbsp;&nbsp;<b>Release</b> 2022.06.01
                        </div>


                    </footer>
                </div></div>
            </form>
        <!-- Select2 -->
<script src="bower_components/select2/assets/js/select2.full.min.js"></script>
        
<!-- iCheck -->
<script src="plugins/iCheck/icheck.min.js"></script>
    
<script>
  $(function () {
    //Initialize Select2 Elements
    $('.select2').select2()      
   
    //iCheck for checkbox and radio inputs
    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
      checkboxClass: 'icheckbox_minimal-blue',
      radioClass   : 'iradio_minimal-blue'
    })
    //Red color scheme for iCheck
    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
      checkboxClass: 'icheckbox_minimal-red',
      radioClass   : 'iradio_minimal-red'
    })
    //Flat red color scheme for iCheck
    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
      checkboxClass: 'icheckbox_flat-green',
      radioClass   : 'iradio_flat-green'
    })
  })
</script> 
     
<script>
        $(document).ready(function () {
            $('input[type="radio"]').iCheck({
                checkboxClass: 'icheckbox_flat-blue',
                radioClass: 'iradio_flat-blue',
                increaseArea: '20%' // optional
            });
        });
</script>
        </body>
        </html>
 

