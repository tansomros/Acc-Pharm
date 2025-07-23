<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PrintCert2.aspx.vb" Inherits="CPAQA.PrintCert2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    <section class="content-header">
      <h1>พิมพ์ใบประกาศนียบัตร</h1>   
    </section>

<section class="content">  
    
        <div class="box box-solid">
            <div class="box-body" style="background-color: #14539a; color: white">
                <div class="row">
                      <div class="col-lg-6 col-md-4 col-xl-4">
                        <div class="form-group">
                            <label>ประเภท</label><br />
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>   
              
                    <div class="col-lg-6 col-md-4 col-xl-4">
                        <div class="form-group">
                            <label>จังหวัด</label><br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>                
                     <div class="col-lg-6 col-md-4 col-xl-4">
                        <div class="form-group">
                            <label>คำค้นหา</label><br />
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="ชื่อร้าน / เลข ขย.5 /ชื่อเภสัชกร"></asp:TextBox>
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
                               <asp:BoundField DataField="PharmacistName" HeaderText="ชื่อเภสัชกร" >
                            <ItemStyle HorizontalAlign="Left" />                            </asp:BoundField>
                            <asp:BoundField DataField="LocationName" HeaderText="ชื่อร้านยา" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LicenseNo1" HeaderText="เลขที่ ขย." >
                            <ItemStyle Width="90px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField DataField="ProvinceName" HeaderText="จังหวัด" /> 
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
