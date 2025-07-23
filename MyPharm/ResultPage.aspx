<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ResultPage.aspx.vb" Inherits="CPA.ResultPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content">
        <div class="error-page">
            <h2 class="headline"><i class="fa fa-info-circle text-blue"></i></h2>
            <div class="tab-success">
                <p></p>
                    <div class="text-center">
                        <h3 class="text-blue">
                            <asp:Label ID="lblResult" runat="server" Text="บันทึกข้อมูลสำเร็จ"></asp:Label>
                        </h3>
                        <br />
                        <asp:HyperLink ID="hlkBack" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx"> <i class="fa fa-backward text-primary"></i>กลับหน้าแรก</asp:HyperLink>
                    </div>              
                <p>
                </p>


            </div>
        </div>
    </section>


</asp:Content>
