<%@ Page Title="รายการเอกสารดาวน์โหลด" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Knowledge.aspx.vb" Inherits="CPAQA.Knowledge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
      <div class="app-page-title">
                        <div class="page-title-wrapper">
                            <div class="page-title-heading">
                                <div class="page-title-icon">
                                    <i class="pe-7s-light icon-gradient bg-mean-fruit"></i>
                                </div>
                                <div>รายการคู่มือและบทความ
                                    <div class="page-title-subheading">จัดการเอกสารดาวน์โหลด</div>
                                </div>
                            </div>
                        </div>
                    </div>      

<section class="content">                        
     <div class="box box-success">
        <div class="box-header with-border">
          <h2 class="box-title">รายการคู่มือและบทความ</h2>   
          <div class="box-tools pull-right">
              <% If Request.Cookies("ROLE_ID").Value = 9 Then %>  
              <asp:Button ID="cmdAdd" runat="server" CssClass="btn btn-success" Text="เพิ่มใหม่" Width="120px" />  
                <% End If %> 
          </div>                       
        </div>
        <div class="box-body">
  <div class="form-group">            
                  <b>ค้นหา </b><asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox> &nbsp;<asp:Button ID="cmdSearch" runat="server" CssClass="btn btn-warning" Text="ค้นหา" Width="70px" /> 
</div>      
                 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                       <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" PageSize="20" CssClass="table table-hover">
                        <RowStyle BackColor="#F7F7F7" VerticalAlign="Top" />
                        <columns>
                             <asp:TemplateField HeaderText="เรื่อง">
                                 <ItemTemplate>
                                     <asp:HyperLink ID="hlnkNews" runat="server"  target="_blank" Text='<%# DataBinder.Eval(Container.DataItem, "NewsHead") %>'  NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "NewsLink") %>'></asp:HyperLink>
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                    <asp:BoundField DataField="MWhen" HeaderText="แก้ไขล่าสุด" >
                             <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Private">
              <itemtemplate>
                <asp:Image ID="imgMember" runat="server" ImageUrl="images/icon-ok.png" 
                                    Visible='<%# BigLion.ConvertYN2Boolean(DataBinder.Eval(Container.DataItem, "isMember")) %>' />                        </itemtemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />          
            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Active">
              <itemtemplate>
                <asp:Image ID="imgStatus" runat="server" ImageUrl="images/icon-ok.png" 
                                    Visible='<%# BigLion.ConvertStatusFlag2CHK(DataBinder.Eval(Container.DataItem, "StatusFlag")) %>' />                        </itemtemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />          
            </asp:TemplateField>
                             <asp:TemplateField HeaderText="แก้ไข">
                                <itemtemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NewsID") %>' ImageUrl="images/icon-edit.png" CssClass="gridbutton" />
                                </itemtemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="ลบ">
                                <itemtemplate>
                                    <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NewsID") %>' ImageUrl="images/icon-delete.png" CssClass="gridbutton" />
                                </itemtemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                            </asp:TemplateField>
                        </columns>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <pagerstyle ForeColor="White" HorizontalAlign="Center" CssClass="dc_pagination" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <headerstyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridheader" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cmdSearch" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
                                
    </div>
        <!-- /.box-body -->
        <div class="box-footer">
       
        </div>
        <!-- /.box-footer-->
      </div>
      <!-- /.box -->            

  </section>                  

</asp:Content>
