<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AsmTravelManage.aspx.vb" Inherits="CPAQA.AsmTravelManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-clock icon-gradient bg-green"></i>
                </div>
                <div>
                    บันทึกวันเวลาเดินทาง
					<div class="page-title-subheading">จัดการวันเวลาที่ท่านเดินทางออกตรวจประเมิน</div>
                </div>
            </div>
        </div>
    </div> 

<section class="content">  
    
        <div class="box box-solid">
            <div class="box-body">
                <div class="row">
                     <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>วันที่</label>
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control text-center"
                                    autocomplete="off" data-date-format="dd/mm/yyyy"
                                    data-date-language="th-th" data-provide="datepicker"
                                    onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>ถึง</label>
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control text-center"
                                    autocomplete="off" data-date-format="dd/mm/yyyy"
                                    data-date-language="th-th" data-provide="datepicker"
                                    onkeyup="chkstr(this,this.value)"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="fa lnr-calendar-full"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>         
                    <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>จังหวัด</label><br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2"> 
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-lg-6 col-md-4 col-xl-3">
                        <div class="form-group">
                            <label>Remark</label><br />
                            <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2 text-left"><br />
                        <asp:LinkButton ID="cmdSave" runat="server" CssClass="btn btn-primary" Width="120px"><i class="fa fa-save"></i>บันทึก</asp:LinkButton>
                    </div>
                </div>

            </div>
        </div>

    <div class="box box-success">
            <div class="box-header">
              <i class="fa fa-list"></i>

              <h3 class="box-title">รายการการเดินทางของท่าน</h3>
             
                 <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>                                 
            </div>
            <div class="box-body mailbox-messages"> 
                         <asp:GridView ID="grdData"  runat="server" CellPadding="0"                                                         GridLines="None" 
             AllowPaging="True" CssClass="table table-hover"                              Font-Bold="False" Width="100%" AutoGenerateColumns="False" DataKeyNames="UID">
                        <RowStyle BackColor="#F7F7F7" />
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />                     
                        <pagerstyle HorizontalAlign="Center" 
                             CssClass="dc_pagination dc_paginationC dc_paginationC01" />                     
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />                                            
                        <Columns>
                            <asp:BoundField DataField="StartDtt" HeaderText="ตั้งแต่วันที่" />
                            <asp:BoundField DataField="EndDtt" HeaderText="ถึง" /> 
                            <asp:BoundField DataField="ProvinceName" HeaderText="จังหวัด" />  
                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                             <asp:BoundField>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                                 <asp:TemplateField>
              <itemtemplate>                   
                   <asp:linkButton ID="imgDel" runat="server"  Text="ลบ" CssClass="btn btn-danger" Width="60"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UID") %>' />  
                                 </itemtemplate>
              <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />          
            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                     </asp:GridView>                
</div>
            <div class="box-footer text-center">
            </div>
          </div>
                       
    </section>  
</asp:Content>
