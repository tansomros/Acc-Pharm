<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RequestPolicy.aspx.vb"
    Inherits="CPAQA.RequestPolicy" %>

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
            <section class="col-lg-12 connectedSortable">

                <div class="main-card mb-3 card">
                    <div class="card-body">
                        <h3 class="card-title text-center">คำรับรองของผู้ยื่นคำขอในการยื่นคำขอรับรองร้านยาคุณภาพ หรือ ต่ออายุ</h3>
                        <div class="scroll-area-lg">

                            <div class="txt-prg">
                                ผู้ยื่นคำขอฯ ขอให้คำรับรองดังต่อไปนี้<br />
1.	ทางร้านไม่มีการจำหน่ายยา Online<br />
                                2.	ทางร้านไม่เคยมีประวัติ หรือคดีความ หรือ การตักเตือน ในการจำหน่ายหรือเกี่ยวข้องกับยาที่ใช้ในทางมอมเมาหรือเสพติด  ยาลดความอ้วน ยาที่ออกฤทธิ์ต่อจิตประสาท ยาเสพติดทุกประเภท หรือยาที่ต้องห้ามต่างๆ  ( ข้อมูลจากตำรวจ หรือ กลุ่มงานคุ้มครองฯ หรือ หน่วยงานที่เกี่ยวข้อง ฯ )<br />
                                -	หากเคยมีประวัติ หรือ คดีความ  ให้ระบุรายละเอียด และเวลาของเหตุการณ์  ( โดยย่อ) 
รายละเอียด...........................................................................................................................................<br />
                                3.	ทางร้านจะต้องมีเภสัชกรอยู่ตลอดและตรงตามเวลาเปิดบริการ<br />
                                (  )  รับทราบ และ ให้คำรับรอง      
                                <br />
                                *** ทังนี้ หากตรวจสอบพบในภายหลัง หรือ พบการกระทำผิด  ทางสำนักรับรองร้านยาคุณภาพสามารถดำเนินการยกเลิก ( กรณีได้รับการรับรองแล้ว ) หรือ  ยกเว้นไม่รับการพิจารณา ( กรณีอยู่ในระหว่างการดำเนินการรับรอง ) เพื่อการการรับรองเป็นร้านยาคุณภาพได้***
                        <br />
                            </div>
                        </div>

                        <div class="text-center">
                            <asp:CheckBox ID="chkAllow" runat="server" Text="&nbsp;&nbsp;รับทราบ และ ให้คำรับรอง" />
                            <br />
                        </div>
                        <br />
                        <div class="row justify-content-center">
                            <asp:Button ID="cmdSubmit" runat="server" Text="ยินยอม" Width="120px" CssClass="btn btn-primary" />
                        </div>
                        <br />
                        <br />
                    </div>

                </div>
            </section>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <asp:Button ID="cmdSave" CssClass="btn btn-primary" runat="server" Text="Save" Width="120px" />
            </div>
        </div>

    </section>
</asp:Content>
