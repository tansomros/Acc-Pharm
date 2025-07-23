<%@ Page Title="รายการเอกสารดาวน์โหลด" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DocumentList.aspx.vb" Inherits="CPAQA.DocumentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
      <div class="app-page-title">
                        <div class="page-title-wrapper">
                            <div class="page-title-heading">
                                <div class="page-title-icon">
                                    <i class="lnr-file-add icon-gradient bg-primary"></i>
                                </div>
                                <div>จัดการเอกสารดาวน์โหลด
                                    <div class="page-title-subheading"></div>
                                </div>
                            </div>
                        </div>
                    </div>      

<section class="content">                        
     <div class="box box-success">
        <div class="box-header with-border">
          <h2 class="box-title">รายการเอกสาร</h2>   
          <div class="box-tools pull-right">
               <% If Request.Cookies("ROLE_ID").Value = 3 Or Request.Cookies("ROLE_ID").Value = 9 Then %>   
              <asp:Button ID="cmdAdd" runat="server" CssClass="btn btn-success" Text="อัพโหลดใหม่" Width="120px" />  
                <% End If %> 
          </div>                       
        </div>
        <div class="box-body">
  <div class="form-group">            
                  <b>ค้นหา </b><asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox> &nbsp;<asp:Button ID="cmdSearch" runat="server" CssClass="btn btn-warning" Text="ค้นหา" Width="70px" /> 
</div>      
                 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" PageSize="20" HorizontalAlign="Center" CssClass="table table-hover">
                        <RowStyle BackColor="#F7F7F7" VerticalAlign="Top" HorizontalAlign="Center" />
                        <columns>
                            <asp:BoundField HeaderText="No." DataField="nRow">
                            <HeaderStyle HorizontalAlign="Center" />
                            <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Descriptions" HeaderText="ชื่อเอกสาร" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CategoryName" HeaderText="ประเภท">
                            <ItemStyle HorizontalAlign="Left" />
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
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/icon-edit.png" CssClass="gridbutton" />
                                </itemtemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="ลบ">
                                <itemtemplate>
                                    <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/icon-delete.png" CssClass="gridbutton" />
                                </itemtemplate>
                                 <HeaderStyle HorizontalAlign="Center" />
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ดาวน์โหลด">
                                <ItemTemplate>
                                    <a href='<%# CPAQA.DownloadPath & DataBinder.Eval(Container.DataItem, "FilePath") %>' target="_blank"><i class="fa fa-download"></i></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                        </columns>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <pagerstyle ForeColor="White" HorizontalAlign="Center" CssClass="dc_pagination dc_paginationC dc_paginationC01" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <headerstyle Font-Bold="True"  VerticalAlign="Middle" CssClass="gridheader" />
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
