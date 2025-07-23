<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportWarning.aspx.vb" Inherits="CPAQA.ReportWarning" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-monitor icon-gradient bg-primary"></i>
                </div>
                <div>
                    <asp:Label ID="lblReportTitle" runat="server" Text=""></asp:Label>
                    <div class="page-title-subheading">ระบบประเมินร้านยาคุณภาพ</div>
                </div>
            </div>
        </div>
    </div>

    <section class="content">
        <div class="box box-solid">
            <div class="box-body" style="background-color: #14539a; color: white">
                <div class="row">
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>Start Date</label>
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
                            <label>End Date</label>
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
                    <div class="col-lg-6 col-md-4 col-xl-2">
                        <div class="form-group">
                            <label>ครั้งที่</label>
                            <br />
                            <asp:DropDownList ID="ddlSeq" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-xl-6">
                        <div class="form-group">
                            <label>ประเด็น</label>
                            <asp:DropDownList CssClass="form-control select2" ID="ddlWarningType" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    </DIV>
                <div class="row">

                    <div class="col-lg-6 col-md-2 col-xl-2">
                        <div class="form-group">
                            <label>ร้านยาคุณภาพ</label><br />
                            <asp:DropDownList ID="ddlAccPharm" runat="server" CssClass="form-control select2" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="Y">ร้านยาคุณภาพ</asp:ListItem>
                                <asp:ListItem Value="N">ไม่ใช่ร้านยาคุณภาพ</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-2 col-xl-2">
                        <div class="form-group">
                            <label>จังหวัด</label>
                            <br />
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control select2" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-4 col-xl-4">
                        <div class="form-group">
                            <label>ร้านยา</label>
                            <br />
                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control select2">
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-lg-12 col-md-4 col-xl-4">
       <div class="form-group">
           <label>คำค้นหา</label><br />
 <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="ประเด็น / อื่นๆ"></asp:TextBox>
       </div>
   </div>
                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                        <br />
                        <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-info" Width="120px"><i class="fa fa-desktop"></i>ดูรายงาน</asp:LinkButton>
                        <asp:LinkButton ID="cmdExport" runat="server" CssClass="btn btn-success" Width="120px"><i class="fa fa-file-excel"></i>Export</asp:LinkButton>

                    </div>
                </div>
            </div>
        </div>   
  
                <div id="pnData" runat="server" class="main-card mb-3 card">
                    <div class="card-header">
                        รายการคำตักเตือนที่พบตามเงื่อนไข
            <div class="btn-actions-pane-right">
            </div>
                    </div>
                    <div class="card-body table-responsive">
                        <table id="tbdata" class="table table-hover table-bordered">
                            <thead>
                                <tr>                                  
                                    <th class="text-center">ขย.5</th>
                                    <th class="text-center">ชื่อร้านยา</th>
                                    <th class="text-center">จังหวัด</th>
                                    <th class="text-center">ครั้งที่</th>
                                    <th class="text-center">วันที่</th> 
                                    <th class="text-center">เลขที่เอกสาร</th>
                                    <th class="text-center">ประเด็น</th>
                                    <th class="text-center">หมายเหตุ</th>                               
                                </tr>
                            </thead>
                            <tbody>
                                <% For Each row As DataRow In dtR.Rows %>
                                <tr>
                                    <td><% =String.Concat(row("LicenseNo1")) %></td>
                                    <td><% =String.Concat(row("LocationName")) %></td>
                                    <td><% =String.Concat(row("ProvinceName")) %></td>
                                    <td class="text-center"><% =String.Concat(row("SeqNo")) %></td> 
                                    <td class="text-center"><% =String.Concat(row("WarnDate")) %></td>
                                    <td class="text-center"><% =String.Concat(row("DocNo")) %></td>                            
                                    <td><% =String.Concat(row("WarningTypeName")) %></td>
                                    <td><% =String.Concat(row("Remark")) %></td>                               
                                </tr>
                                <%  Next %>
                            </tbody>
                        </table>
                    </div>
                </div>
          
    </section>
</asp:Content>
