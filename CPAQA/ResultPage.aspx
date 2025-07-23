<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ResultPage.aspx.vb" Inherits="CPAQA.ResultPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content">
        <div id="pnBlue" runat="server" class="error-page">
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

          <div id="pnWarning" runat="server" class="error-page">
              <table>
                  <tr>
                      <td style="font-size:60px"><i class="fa fa-exclamation-triangle text-danger"></i>
                      </td>
                          <td> <h3 class="text-danger">
                        <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
                  </h3> 

    </td>
                  </tr>
              </table>
      
  </div>
    </section>


</asp:Content>
