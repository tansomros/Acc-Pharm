<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="LocationChain.aspx.vb" Inherits="CPA.LocationChain" %>
<%@ Import Namespace="System.Data" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function openModalMasterData(sender,uid) {	
            $('#modal-window').modal('show');
			return false;
        } 

    </script>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-home icon-gradient bg-primary"></i>
                        </div>
                        <div>กลุ่ม Chain ร้านยา
                            <div class="page-title-subheading">จัดการ เพิ่ม/แก้ไข กลุ่ม Chain ร้านยา </div>
                        </div>
                    </div>
                </div>
            </div> 

<section class="content">  

      <div class="main-card mb-3 card">
        <div class="card-header"><i class="header-icon fa fa-home icon-gradient bg-success">
            </i>กลุ่ม Chain ร้านยา
            <div class="btn-actions-pane-right">
                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 3 Then%>
                <asp:linkButton ID="cmdNew" runat="server"  CssClass="btn btn-primary pull-right" Width="100"><i class="fa fa-plus-circle"></i>เพิ่มใหม่</asp:linkButton>        
                <% End If %>
            </div>
        </div>     
              <div class="card-body">   
        <div class="row">                                              
                    <table border="0"  >
            <tr>
              <td width="50" >ค้นหา</td>
              <td >
                  <asp:TextBox ID="txtSearch" runat="server" cssclass="form-control"  Width="200px"></asp:TextBox>                </td>
              <td >
                   &nbsp;<asp:Button ID="cmdFind" runat="server" CssClass="btn btn-success" Width="70" Text="ค้นหา"></asp:Button>              
                </td>
            </tr>
           
          </table>     
                  </div>
<div class="row table-responsive">
<asp:GridView ID="grdData" CssClass="table table-hover"  
                             runat="server" CellPadding="2" 
                                                        GridLines="None" 
                      AutoGenerateColumns="False"  
                             Font-Bold="False">
                        <RowStyle BackColor="#F7F7F7" />
                        <columns>
                            <asp:BoundField DataField="UID" HeaderText="ID" >
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Code" HeaderText="Code" >
                            <HeaderStyle HorizontalAlign="Left" /> 
                            </asp:BoundField>                           
                            <asp:BoundField DataField="Name" HeaderText="Name" >
                            <HeaderStyle HorizontalAlign="Left" />  
                            </asp:BoundField>
                            <asp:BoundField DataField="Descriptions" HeaderText="Descriptions" />
                           <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <asp:Image ID="imgStatus" runat="server" ImageUrl="images/icon-ok.png" 
                                    Visible='<%# IIf(DataBinder.Eval(Container.DataItem, "StatusFlag") = "A", True, False) %>' />                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>                          
                             <asp:TemplateField>
              <itemtemplate>
                    <asp:linkButton ID="imgEdit" runat="server"  Text="แก้ไข" CssClass="btn btn-primary" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  
                   <asp:linkButton ID="imgDel" runat="server"  Text="ลบ" CssClass="btn btn-danger" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  
                                 </itemtemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />          
            </asp:TemplateField>
                        </columns>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />                     
                        <pagerstyle HorizontalAlign="Center" 
                             CssClass="dc_pagination dc_paginationC dc_paginationC11" />                     
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <headerstyle CssClass="th" Font-Bold="True" />                     
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                     </asp:GridView>                                 
    </div>        </div>
            <!-- /.box-body    <a href="LocationDetail?m=v&id=< % =String.Concat(row("UID")) %>" class="font-icon-button"><i class="fa fa-file-pdf" aria-hidden="true"></i> ดูรายละเอียด</a> -->
          </div>



   <div id="modal-window" class="modal fade modal-window"  role="dialog" data-backdrop="static" tabindex="-1" style="display: none;" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
               <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                <h6 class="modal-title">จัดการกลุ่ม Chain ร้านยา</h6>
          </div>
          <div class="modal-body">                  
      <div class="row">
   <div class="col-md-2">
          <div class="form-group">
            <label>ID</label>
              <asp:TextBox ID="txtUID" runat="server" cssclass="form-control text-center"  ReadOnly="True"></asp:TextBox>
          </div>

        </div>

           <div class="col-md-10">
          <div class="form-group">
            <label>Code</label>
              <asp:TextBox ID="txtCode" runat="server" cssclass="form-control text-center" placeholder="รหัส"></asp:TextBox>
          </div>

        </div>
</div>
 <div class="row">
             <div class="col-md-12">
          <div class="form-group">
            <label>Name</label>
              <asp:TextBox ID="txtName" runat="server" cssclass="form-control" placeholder="ชื่อ"></asp:TextBox>
          </div>

        </div>
     </div>
 <div class="row">
            <div class="col-md-12">
          <div class="form-group">
            <label>Descriptions</label>
              <asp:TextBox ID="txtDescriptions" runat="server" cssclass="form-control" placeholder="คำอธิบาย"></asp:TextBox>
          </div>

        </div>
     </div>
 <div class="row">
             <div class="col-md-2">
          <div class="form-group">
            <label>Status</label>
              <br />
              <asp:CheckBox ID="chkStatus" runat="server" Text="Active"       Checked="True" />
          </div>
        </div>
      </div>

  <div class="row">
   <div class="col-md-12 text-center">
               <asp:Button ID="cmdSave" runat="server" CssClass="btn btn-primary" Width="100" Text="บันทึก"></asp:Button>
          <asp:Button ID="cmdDelete" runat="server" CssClass="btn btn-danger" Width="100" Text="ลบ"></asp:Button>
  <asp:Button ID="cmdClear" runat="server" CssClass="btn btn-secondary" Width="100" Text="ยกเลิก"></asp:Button> 
       </div>
      </div>

</div>
            <div class="box-footer clearfix">
           
            </div>
          </div>
 </div>
 </div>
     
                           
</section>   
</asp:Content>
