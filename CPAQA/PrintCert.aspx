<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PrintCert.aspx.vb" Inherits="CPAQA.PrintCert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <section class="content-header">
      <h1>พิมพ์ใบเกียรติบัตร/รับรองฯ</h1>   
    </section>

<section class="content">  
    
        <div class="box box-solid">
            <div class="box-body" style="background-color: #14539a; color: white">
                <div class="row">
                      <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>ปี</label><br />
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                      <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>เลขที่</label><br />
                            <asp:TextBox ID="txtStartNo" runat="server" CssClass="form-control" PlaceHolder="เลขที่รับรองเริ่มต้น"></asp:TextBox>
                        </div>
                    </div>
                      <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>ถึงเลขที่</label><br />
                             <asp:TextBox ID="txtEndNo" runat="server" CssClass="form-control" PlaceHolder="เลขที่รับรองสุดท้าย"></asp:TextBox>
                        </div>
                    </div>
                     <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>วันที่คณะกรรมการรับรอง ตั้งแต่</label>
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
                    </div>
                <div class="row">
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>จังหวัด</label><br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>สถานะใบรับรอง</label><br />
                            <asp:DropDownList ID="ddlAccStatus" runat="server" CssClass="form-control select2">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="A">ปกติ</asp:ListItem>
                                <asp:ListItem Value="E">หมดอายุการรับรอง</asp:ListItem>
                                <asp:ListItem Value="X">ยกเลิกการรับรอง</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-lg-6 col-md-4 col-xl-4">
                        <div class="form-group">
                            <label>คำค้นหา</label><br />
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="ชื่อร้าน / เลข ขย.5 /เลขที่ใบอนุญาต"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:LinkButton ID="cmdSearch" runat="server" CssClass="btn btn-info" Width="120px"><i class="fa fa-search"></i>ค้นหา</asp:LinkButton>
                    </div>
                </div>

            </div>
        </div>

    <div class="box box-success">
            <div class="box-header">
              <i class="fa fa-list"></i>

              <h3 class="box-title">เลือกร้านยา</h3>
             
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
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                            </asp:TemplateField>
                               <asp:BoundField DataField="AccLicense" HeaderText="เลขที่ใบรับรอง" >
                            <ItemStyle Width="90px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField DataField="LocationName" HeaderText="ชื่อร้านยา" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LicenseNo1" HeaderText="เลขที่ ขย." >
                            <ItemStyle Width="90px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField DataField="ProvinceName" HeaderText="จังหวัด" /> 
                            <asp:BoundField DataField="PassDtt" HeaderText="วันที่ผ่านการรับรอง" />
                            <asp:BoundField DataField="BeginDtt" HeaderText="วันที่รับรองครั้งแรก" />
                            <asp:BoundField DataField="StartDtt" HeaderText="วันที่เริ่ม" />
                            <asp:BoundField DataField="ExpireDtt" HeaderText="วันที่หมดอายุ" />                            
                            <asp:BoundField>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                     </asp:GridView>                
</div>
            <div class="box-footer text-center">
           <asp:LinkButton ID="lnkPrintAll" runat="server" CssClass="btn btn-success">พิมพ์จากผลการค้นหาทั้งหมด</asp:LinkButton>
 <asp:LinkButton ID="lnkPrintSelect" runat="server" CssClass="btn btn-success">พิมพ์ที่เลือกทั้งหมด</asp:LinkButton>  
            </div>
          </div>
                       
    </section>  
</asp:Content>
