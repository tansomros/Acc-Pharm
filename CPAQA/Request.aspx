<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Request.aspx.vb"
    Inherits="CPAQA.Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-note icon-gradient bg-success"></i>
                </div>
                <div>
                    ยื่นคำขอใหม่
                            <div class="page-title-subheading">New Request</div>
                </div>
            </div>
        </div>
    </div>

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <section class="col-lg-6 connectedSortable">
                <div class="main-card mb-3 card">
                    <div class="card-header">
                        ยื่นคำขอรับรองใหม่/เปลี่ยนแปลงข้อมูล<asp:HiddenField ID="hdRequestUID" runat="server" />
                        <asp:HiddenField ID="hdLocationUID" runat="server" />
                    </div>
                    <div class="card-body">

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>เลขที่คำขอ</label>
                                    <asp:TextBox ID="txtCode" runat="server" CssClass="form-control text-center" ReadOnly="true" placeholder="Auto Running"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>เลือกประเภทคำขอ</label><br />
                                    <asp:CheckBox ID="chkType1" runat="server" AutoPostBack="true" Text="ขอรับรองใหม่" /><br />
                                    <asp:CheckBox ID="chkType7" runat="server" AutoPostBack="true" Text="ขอรับรองใหม่ แบบมีเงื่อนไข" /><br />
                                    <asp:CheckBox ID="chkType2" runat="server" AutoPostBack="true" Text="ต่ออายุ" /><br />
                                    <asp:CheckBox ID="chkType3" runat="server" Text="ย้าย หรือ เปลี่ยนสถานที่" />   <br />    
                                    <asp:CheckBox ID="chkType6" runat="server" Text="เปลี่ยนชื่อร้านยา (สถานที่,ผู้รับอนุญาต และ เภสัชกร คงเดิม)" /><br />
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:CheckBox ID="chkType4" runat="server" Text="เปลี่ยนผู้มีหน้าที่ปฏิบัติการ" /><br />
                                    <asp:CheckBox ID="chkType9" runat="server" Text="เพิ่มผู้มีหน้าที่ปฏิบัติการ" /><br />                                                            
                                    <asp:CheckBox ID="chkType8" runat="server" Text="เปลี่ยนแปลงเวลาผู้มีหน้าที่ปฏิบัติการ" /> <br />    
                                    <asp:CheckBox ID="chkType5" runat="server" AutoPostBack="true" Text="เปลี่ยนผู้ดำเนินกิจการ/ผู้รับอนุญาต (สถานที่เดิม)" /> <br />    
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="text-bold text-blue">
                                        <label>ผู้ยื่นคำขอ</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-lg-12 col-md-6 col-xl-6">
                                <div class="form-group">
                                    <label>ชื่อ</label>
                                    <asp:TextBox ID="txtFname" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-lg-12 col-md-6 col-xl-6">
                                <div class="form-group">
                                    <label>นามสกุล</label>
                                    <asp:TextBox ID="txtLname" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-xl-4">
                                <div class="form-group">
                                    <label>อีเมล</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control special-letter" placeholder="E-mail"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-xl-4">
                                <div class="form-group">
                                    <label>เบอร์โทร</label>
                                    <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" placeholder="Phone Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-xl-4">
                                <div class="form-group">
                                    <label>Line Id.</label>
                                    <asp:TextBox ID="txtLineID" runat="server" CssClass="form-control special-letter" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-6">
                                <div class="form-group">
                                    <label>ความเกี่ยวข้องกับร้านยา</label><br />
                                    <asp:DropDownList ID="ddlRequesterType" runat="server" CssClass="form-control select2">
                                        <asp:ListItem Value="1">ผู้ดำเนินกิจการ / ผู้รับอนุญาต</asp:ListItem>
                                        <asp:ListItem Value="2">ผู้รับอนุญาต + เภสัชกร</asp:ListItem>
                                        <asp:ListItem Value="3">เภสัชกร </asp:ListItem>
                                        <asp:ListItem Value="9">อื่นๆ</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-12 col-md-6">
                                <div class="form-group">
                                    <label>กรณีอื่นๆ (ระบุ)</label>
                                    <asp:TextBox ID="txtRequesterOther" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="col-lg-6 connectedSortable">   
                <div id="pnPolicy" runat="server" class="main-card mb-3 card">
                    <div class="card-body">
                        <h3 class="card-title text-blue text-center">คำรับรองของผู้ยื่นคำขอในการยื่นคำขอรับรองร้านยาคุณภาพ หรือ ต่ออายุ</h3>
                            <div class="txt-prg">
                              
                                <!--
                                ผู้ยื่นคำขอฯ ขอให้คำรับรองดังต่อไปนี้<br /><br />
1.	ทางร้านไม่มีการจำหน่ายยา Online<br />
                                2.	ทางร้านไม่เคยมีประวัติ หรือคดีความ หรือ การตักเตือน ในการจำหน่ายหรือเกี่ยวข้องกับยาที่ใช้ในทางมอมเมาหรือเสพติด  ยาลดความอ้วน ยาที่ออกฤทธิ์ต่อจิตประสาท ยาเสพติดทุกประเภท หรือยาที่ต้องห้ามต่างๆ  ( ข้อมูลจากตำรวจ หรือ กลุ่มงานคุ้มครองฯ หรือ หน่วยงานที่เกี่ยวข้อง ฯ ) 
                                <br /> หากเคยมีประวัติ หรือ คดีความ  ให้ระบุรายละเอียด และเวลาของเหตุการณ์ (โดยย่อ)<br />
                                
                                3.	ผู้ยื่นคำขอ รับรองการมีเภสัชกรปฏิบัติหน้าที่ตลอดเวลาปฏิบัติการ (ตามใบอนุญาต / ขย.5 )<br />
                                4.  ผู้ยื่นคำขอรับทราบที่จะปฏิบัติและให้บริการต่างๆ แก่ประชาชนเป็นไปตาม พรย.ยา <br />
                              
                           
                                <br />  <br />
                              <span class="text-bold"> *** ทังนี้ หากตรวจสอบพบในภายหลัง หรือ พบการกระทำผิด  ทางสำนักรับรองร้านยาคุณภาพสามารถดำเนินการยกเลิก ( กรณีได้รับการรับรองแล้ว ) หรือ  ยกเว้นไม่รับการพิจารณา ( กรณีอยู่ในระหว่างการดำเนินการรับรอง ) เพื่อการการรับรองเป็นร้านยาคุณภาพได้*** </span> 
                                -->
                                                               <b>คุณสมบัติผู้ยื่นคำขอ</b>  <br />
1. เป็นเภสัชกร ผู้รับอนุญาต หรือเป็นผู้มีหน้าที่ปฏิบัติการ <br />
2. เป็นผู้ที่ไม่มีประวัติการกระทำผิดทางอาญาในลักษณะฉ้อโกง ผิดศีลธรรม หรือเป็นคดีอาญา หรือ ผิดพรบ.วิชาชีพเภสัชกรรม   พรบ.ยา เรื่องการไม่อยู่ปฏิบัติการที่ร้านยา หรือ  ต้องคดีจำหน่ายยาเพื่อใช้เสพติดหรือมอมเมา   ย้อนหลัง  3  ปี จนถึงวันยื่นคำขอ <br />
3. กรณีเป็นร้านเปิดใหม่ ให้ผ่านการประเมิน GPP หลังเปิดบริการ จาก อย. หรือ สสจ. ก่อน  (ยกเว้น สสจ. มีความเห็นชอบให้ สรร. ดำเนินการได้)<br /> <br />
                                 <b> คำรับรองของผู้ยื่นคำขอ </b> <br />
ผู้ยื่นคำขอฯ ขอให้คำรับรองดังต่อไปนี้ <br />
1. ไม่มีการจำหน่ายยา Online <br />
2. จัดให้มีเภสัชกรปฏิบัติหน้าที่ตลอดเวลาปฏิบัติการ (ตามใบอนุญาต ขย.5 ) <br />
3. ปฏิบัติหน้าที่และให้บริการต่างๆ แก่ผู้มารับบริการ ตาม พรย.ยา และ พรบ.วิชาชีพเภสัชกรรม <br />
4. ร้านจะจำหน่ายเฉพาะยาสามัญประจำบ้านให้แก่ร้านชำ<br />   <br /> 

 <span class="text-bold">*** ทั้งนี้ หากตรวจสอบพบในภายหลัง กรณีคุณสมบัติไม่เป็นไปตามที่กำหนด  หรือ ไม่ปฏิบัติตามคำรับรอง ทางสำนักรับรองร้านยาคุณภาพสามารถดำเนินการยกเลิก ( กรณีได้รับการรับรองแล้ว ) หรือ ขอคืนคำขอโดยไม่รับการพิจารณา ( กรณีอยู่ในระหว่างการดำเนินการรับรอง ) ในการรับรองเป็นร้านยาคุณภาพได้*** </span>  <br />

  <br /><asp:CheckBox ID="chkAllow" runat="server" CssClass="text-bold text-blue" Text="&nbsp;&nbsp;รับทราบ และ ให้คำรับรอง" />
                                   <br />  <br />  <br />  <br />  <br /> <br />  <br />
                                <asp:TextBox ID="txtLitigation" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100" Visible="false" placeholder="รายละเอียดประวัติหรือคดีความ"></asp:TextBox>
                            </div>
                        
                                             
                    </div>

        </div>
        <div id="pnChange" runat="server" class="main-card mb-3 card">
            <div class="card-body">
                <h3 class="card-title text-blue text-center">ขอเปลี่ยนผู้ดำเนินกิจการ/ผู้รับอนุญาต (สถานที่เดิม)</h3>
                <div class="txt-prg">
                    เลือกประเภท<br />
                    <br />
                    <asp:RadioButtonList ID="optChange" runat="server" CssClass="text-bold text-blue">
                        <asp:ListItem Selected="True" Value="1">จาก บุคคล เป็น บุคคล</asp:ListItem>
                        <asp:ListItem Value="2">จาก บุคล เป็น นิติบุคคล/บริษัท</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <br />
                </div>

                <div class="col-md-12 alert alert-danger">
                    <span class="text-bold">โปรดอ่าน</span>
                    <br />

                    1.  กรณี ขอเปลี่ยนจาก บุคคล เป็น นิติบุคคล/บริษัท ให้ใช้ Username ที่เป็น เลข ขย.ใหม่ ในการสร้างคำขอ หากยังไม่มี User ให้ทำการลงทะเบียนร้านยาใหม่ด้วยเลข ขย.5 เลขใหม่
                    <br />

                    2.	หากท่านมั่นใจแล้วว่า Login เข้าระบบด้วยเลข ขย. ใหม่ ให้กด Save ต่อไปได้<br />
                    <br />
                    ***  หากมีข้อสงสัยเพิ่มเติม กรุณาสอบถาม สรร. หรือ admin ใน Line Group ก่อน ***
                </div>

            </div>

        </div>

    </section>
    </div>

                <div class="row justify-content-center">
                    <!--
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Active</label>  
        <div class="button r" id="button-1"> 
              <input id="chkStatus" type="checkbox" class="checkbox" runat="server" >          
          <div class="knobs"></div>
          <div class="layer"></div>
        </div>
                            </div>
                    </div>
-->
    <div class="col-md-12 text-center">
                        <asp:Button ID="cmdSave" CssClass="btn btn-primary" runat="server" Text="Save" Width="120px" />
                    </div>
                </div>

            </section>
</asp:Content>
