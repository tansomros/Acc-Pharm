<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AllocateProvince.aspx.vb" Inherits="CPAQA.AllocateProvince" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">       
</asp:Content>    
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-home icon-gradient bg-green"></i>
                        </div>
                        <div>Assign สิทธิ์ดูรายงานรายจังหวัด
                            <div class="page-title-subheading">กำหนดจังหวัดเพื่อสิทธิ์ดูรายงานร้านยาในจังหวัดที่กำหนด</div>
                        </div>
                    </div>
                </div>
            </div>
<section class="content">  
  <div class="row"> 
        <section class="col-lg-12 connectedSortable">            
              <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-grear"></i>
              <h3 class="box-title">เลือกผู้ใช้งาน</h3>
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>                                 
            </div>
            <div class="box-body"> 
                   <div class="row">                      
        <div class="col-md-4">
          <div class="form-group">
            <label>User</label>
              <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="True" CssClass="form-control select2"></asp:DropDownList>     
          </div>
        </div>              
       </div>  
</div>
            <div class="box-footer clearfix">           
            </div>
          </div>    
</section>
  </div>
      <div class="row"> 

<section class="col-lg-6 connectedSortable">   
 
    <div class="box box-primary">
            <div class="box-header">
              <i class="fa fa-list"></i>
              <h3 class="box-title">รายชื่อจังหวัดที่ Assign ปัจจุบัน ทั้งหมด&nbsp; <asp:Label ID="lblCount" runat="server"></asp:Label>
           &nbsp;จังหวัด</h3>             
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>                                 
            </div>
            <div class="box-body">     
        <table border="0" >
            <tr>
              <td>ค้นหา</td>
              <td width="150">
                  <asp:TextBox ID="txtSearchAllocate" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                  </td>
              <td><asp:Button ID="cmdFindAlocate" runat="server" CssClass="btn btn-warning" Width="70" Text="ค้นหา"></asp:Button>              </td>
            </tr>           
          </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>                       
                  
 <asp:GridView ID="grdProvince" CssClass="table table-hover"
                             runat="server" CellPadding="0" 
                                                        GridLines="None" 
                      AutoGenerateColumns="False" Width="100%" AllowPaging="True">
            <RowStyle BackColor="#F7F7F7" />
            <columns>
            <asp:BoundField DataField="nRow" HeaderText="No.">                      
                <HeaderStyle HorizontalAlign="Center" />
              <itemstyle HorizontalAlign="Center" Width="120px"/>

            </asp:BoundField>

                <asp:BoundField DataField="ProvinceName" HeaderText="จังหวัด">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:BoundField>
                <asp:BoundField DataField="ProvinceName" HeaderText="จังหวัด" />
            <asp:TemplateField HeaderText="ลบ">
              <itemtemplate>
                <asp:ImageButton ID="imgDel" runat="server" ImageUrl="images/delete.png"     CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />                        </itemtemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />          
            </asp:TemplateField>
            </columns>
            <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />          
            <pagerstyle HorizontalAlign="Center" 
                      CssClass="dc_pagination dc_paginationC dc_paginationC01" />          
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <headerstyle CssClass="th" Font-Bold="True" 
                      VerticalAlign="Middle" HorizontalAlign="Left" />          
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
  </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlUser" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdFindAlocate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grdData" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="cmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSubmitDel" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
<asp:Label ID="lblNo" runat="server" CssClass="alert alert-error show" Text="ยังไม่พบจังหวัดตามเงื่อนไข" Width="100%"></asp:Label>
  <table border="0">
            <tr>
              <td>หรือ</td>
              <td><asp:LinkButton ID="lnkSubmitDel" runat="server"  CssClass="btn btn-danger">ลบทั้งหมด</asp:LinkButton></td>
            </tr>
         </table>  
</div> 
        <div class="box-footer clearfix">           
                
            </div>
          </div>
</section>
<section class="col-lg-6 connectedSortable">
     <div class="box box-success">
            <div class="box-header">
              <i class="fa fa-search-plus"></i>

              <h3 class="box-title">เพิ่มจังหวัด</h3>
             
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>                                 
            </div>
            <div class="box-body"> 
           <table border="0"  width="100%">   
    <tr>
          <td valign="top" > 
  <table border="0" >
            <tr>
              <td width="50" >ค้นหา</td>
                <td>
                    <asp:RadioButtonList ID="optCond" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="A">ทั้งหมด</asp:ListItem>
                        <asp:ListItem Value="O">เฉพาะจังหวัดที่ยังไม่ Assign</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
              <td ><asp:TextBox ID="txtSearchProvince" runat="server"  CssClass="form-control" Width="150px"></asp:TextBox>              </td>
              <td > <asp:Button ID="cmdFindProvince" runat="server" CssClass="btn btn-warning" Width="70" Text="ค้นหา"></asp:Button>            </td>
            </tr>
            </table>         </td>
        </tr>
    <tr>
          <td align="center" valign="top" class="mailbox-messages">
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

              <asp:GridView ID="grdData" 
                             runat="server" CellPadding="0" ForeColor="#333333" 
                                                        GridLines="None" 
                      AutoGenerateColumns="False" Width="100%" 
                  DataKeyNames="ProvinceID" CssClass="table table-hover" AllowPaging="True">
            <RowStyle BackColor="#F7F7F7" HorizontalAlign="Center" />
            <columns>
            <asp:TemplateField HeaderText="เพิ่ม">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />                </ItemTemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />          
            </asp:TemplateField>
          
                <asp:BoundField DataField="ProvinceID" HeaderText="ID" >
          
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
          
                <asp:BoundField DataField="ProvinceName" HeaderText="ชื่อจังหวัด">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left"/>
                </asp:BoundField>            
            </columns>
            <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />          
            <pagerstyle HorizontalAlign="Center" 
                      CssClass="dc_pagination dc_paginationC dc_paginationC01" />          
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <headerstyle CssClass="th" Font-Bold="True"  
                      VerticalAlign="Middle" />          
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
                         </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlUser" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmdFindProvince" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grdData" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="grdProvince" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="cmdSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="cmdClear" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                        </td>
      </tr> 
    <tr>
        <td align="center" valign="top">
            <asp:Label ID="lblNotic" runat="server" CssClass="alert alert-error show" Text="กรุณาเลือกเงื่อนไขเพื่อค้นหาข้อมูลก่อน" Width="99%"></asp:Label>
        </td>
    </tr>
    <tr>    
          <td valign="top">
              <table border="0" >
            <tr>
              <td></td>             
              <td><asp:LinkButton ID="lnkSubmitAdd" runat="server"  CssClass="buttonModal" Visible="False">เพิ่มทั้งหมด</asp:LinkButton></td>
            </tr>
          </table></td>
      </tr>       
    <tr>
          <td align="center" valign="top">
         <asp:Button ID="cmdSave" runat="server" CssClass="btn btn-primary" Width="100" Text="บันทึก"></asp:Button>
    <asp:Button ID="cmdClear" runat="server" CssClass="btn btn-secondary" Width="100" Text="ยกเลิก"></asp:Button>         </td>
        </tr>
  
    
</table>                             
</div>
            <div class="box-footer clearfix">
           <div class="text-blue">แสดงเฉพาะจังหวัดที่ยังไม่ถูกจัดสรรให้ และสามารถเลือกเพิ่มได้ทีละหน้าเท่านั้น</div>
            </div>
          </div>
</section>
</div> 
    </section>    
</asp:Content>
