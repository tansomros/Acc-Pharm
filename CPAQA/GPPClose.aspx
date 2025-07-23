<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="GPPClose.aspx.vb" Inherits="CPAQA.GPPClose" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="lnr-power-switch icon-gradient bg-danger"></i>
                </div>
                <div>ปิดการประเมิน GPP
                    <div class="page-title-subheading"></div>
                </div>
            </div>
        </div>
    </div>

    <section class="content">

        <div class="box box-solid">
            <div class="box-body">
                <div class="row">           
                    <div class="col-lg-3 col-md-6 col-xs-12">
                        <div class="form-group">
                            <label>ปี</label><br />
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>                  
                    <div class="col-lg-3 col-md-6 col-xs-12">
                        <div class="form-group">
                            <label>ภาค</label><br />
                            <asp:DropDownList ID="ddlProvinceGroup" runat="server" CssClass="form-control select2" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-xs-12">
                        <div class="form-group">
                            <label>จังหวัด</label><br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>                    
                    <div class="col-lg-3 col-md-6 col-xs-12">
                        <div class="form-group">
                            <label>คำค้นหา</label><br />
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="ชื่อร้าน / เลข ขย.5 /เลขที่ใบอนุญาต"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                        <br />
                        <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-primary" Width="100px"><i class="fa fa-desktop"></i>View</asp:LinkButton>
                        <asp:LinkButton ID="cmdExport" runat="server" CssClass="btn btn-success" Width="100px"><i class="fa fa-power-off"></i>Close</asp:LinkButton>
                    </div>
                </div>

            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>        
        <div class="main-card mb-3 card">
            <div class="card-header">
                รายการประเมิน GPP
            <div class="btn-actions-pane-right">
            </div>
            </div>
            <div class="card-body table-responsive">
                <table id="tbdata" class="table table-hover table-bordered">
                            <thead>
                                <tr> 
                                    <th class="text-center">No.</th>
                                    <th class="text-center">เลขที่ใบอนุญาต ขย.5</th>
                                    <th class="text-center">ชื่อร้านยา</th>
                                    <th class="text-center">สถานที่ตั้ง</th>
                                    <th class="text-center">ปี</th>
                                    <th class="text-center">วันที่</th>
                                    <th class="text-center">คะแนนรวม</th>
                                    <th class="text-center">คะแนนที่ได้</th>
                                    <th class="text-center">คิดเป็น(%)</th>                                    
                                    <th class="text-center">สรุปผล</th>
                                    <th class="text-center">Remark</th>               
                                </tr>
                            </thead>
                            <tbody>
                                <% For Each row As DataRow In dtGPP.Rows %>
                                <tr>
                                    <td class="text-center"><% =String.Concat(row("nRow")) %></td>
                                    <td><% =String.Concat(row("LicenseNo")) %></td>
                                    <td><% =String.Concat(row("LocationName")) %></td>
                                    <td><% =String.Concat(row("LocationAddress")) %></td>
                                    <td><% =String.Concat(row("GPPYear")) %></td>
                                    <td class="text-center"><% =String.Concat(row("AsmDate")) %></td>                            
                                    <td class="text-center"><% =String.Concat(row("TotalScore")) %></td>
                                    <td class="text-center"><% =String.Concat(row("FinalScore")) %></td>
                                    <td class="text-center"><% =String.Concat(row("PercentageScore")) %></td>                                   
                                    <td class="text-center"><% =IIf(String.Concat(row("FinalResult")) = "Y", "ผ่าน", "ไม่ผ่าน") %></td>
                                    <td class="text-center"><% =String.Concat(row("Remark")) %></td>                                     
                                </tr>
                                <%  Next %>
                            </tbody>
                        </table>
            </div>
        </div>   
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </section>
</asp:Content>
