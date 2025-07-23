<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegisterList.aspx.vb" Inherits="CPAQA.RegisterList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="app-page-title">
                        <div class="page-title-wrapper">
                            <div class="page-title-heading">
                                <div class="page-title-icon">
                                    <i class="pe-7s-user-female icon-gradient bg-primary"></i>
                                </div>
                                <div>Register List
                                    <div class="page-title-subheading">ข้อมูลผู้ลงทะเบียนขอใช้โปรแกรมกฎหมาย</div>
                                </div>
                            </div>
                        </div>
                    </div>    

<section class="content">
    <div class="row">
         <div class="col-md-12 text-right">
              <a href="RegisterModify.aspx" Class="btn btn-primary"> เพิ่มข้อมูลใหม่  </a>
          
        </div>
          </div>     <br /> 
    <div class="row">
     <div class="box box-success">
        <div class="box-header with-border">
          <h2 class="box-title">ค้นหา</h2>   
          <div class="box-tools pull-right">          
          </div>      
        </div>
        <div class="box-body">
             <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>ประเภท</label>
                                            <asp:DropDownList ID="ddlPersonType" runat="server" CssClass="form-control select2">
                 <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="P">บุคคลธรรมดา</asp:ListItem>
                    <asp:ListItem Value="C">บริษัท/หน่วยงาน</asp:ListItem> 
                  </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>ค้นหา</label> 
                                            <asp:TextBox ID="txtSearch" runat="server"   CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                  <div class="col-md-4">
                                        <div class="form-group">
                                              <label>&nbsp;</label> 
                                            <br /> 
                                                 <asp:Button ID="cmdSearch" runat="server" CssClass="btn btn-warning" Text="ค้นหา" Width="100px" />  
                                        </div>
                                    </div>

                                </div>                                     
    </div>
   
        <div class="box-footer text-center">
  
        </div>   
      </div>                 
     <div class="box box-success">
        <div class="box-header with-border">
          <h2 class="box-title">รายชื่อผู้ลงทะเบียน</h2>                                 
        </div>
        <div class="box-body">
      
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#34495E" GridLines="None" Width="100%"  BorderStyle="None" CssClass="table table-hover" AllowPaging="True">
                        <RowStyle BackColor="#FFFFFF" VerticalAlign="Top" CssClass="gridrow" />
                        <columns>
                            <asp:BoundField DataField="nRow" HeaderText="No." >
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ContactName" HeaderText="ชื่อผู้ติดต่อ">
                            </asp:BoundField>
                             <asp:BoundField DataField="CompanyName" HeaderText="บริษัท">
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="BusinessTypeName" HeaderText="ประเภทธุรกิจ" />
                             <asp:BoundField DataField="Tel" HeaderText="เบอร์โทร" >
                             <HeaderStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                           
                             <asp:BoundField DataField="Email" HeaderText="อีเมล" />
                            <asp:BoundField DataField="ProvinceName" HeaderText="จังหวัด" />
                           
                             <asp:TemplateField HeaderText="สถานะอนุมัติ">
                                 <ItemTemplate>
                                     <asp:Image ID="Image1" runat="server" ImageUrl="images/icon-ok.png" 
                                    Visible='<%# IIf(DataBinder.Eval(Container.DataItem, "ApproveStatus") = "Y", True, False) %>' />                                      
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" />
                                 <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="ดูรายละเอียด">
                                <itemtemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/view.png" CssClass="gridbutton" />
                                </itemtemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="ลบ">
                                <itemtemplate>
                                    <asp:ImageButton ID="imgDel" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' ImageUrl="images/icon-delete.png" CssClass="gridbutton" />
                                </itemtemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                                <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                            </asp:TemplateField>
                        </columns>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <pagerstyle  HorizontalAlign="Center" CssClass="dc_pagination" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <headerstyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="gridheader" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="gridalternatingrow" />
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
           
</div>
  </section>                  

</asp:Content>
