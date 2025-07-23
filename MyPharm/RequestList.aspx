<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RequestList.aspx.vb" Inherits="CPA.RequestList" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-ribbon icon-gradient bg-success"></i>
                </div>
                <div>
                    <asp:Label ID="lblTitle" runat="server" Text="รายการคำขอ"></asp:Label>
                </div>
            </div>
        </div>
    </div>
     
    <section class="content">        
        <div class="box box-solid">
             <div class="box-header">
              <i class="fa fa-filter"></i>
              <h3 class="box-title">ค้นหา</h3>   
                  <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-6 col-md-3 col-xl-3">
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
                    <div class="col-lg-6 col-md-3 col-xl-3">
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
                  <div class="col-lg-6 col-md-3 col-xl-3">
                        <div class="form-group">
                            <label>ประเภท</label>
                            <br />
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2" Width="100%" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="1">ขอแก้ไขข้อมูลร้านยา</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-3 col-xl-3">
                        <div class="form-group">
                            <label>สถานะ</label>
                            <br />
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2" Width="100%" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div> 
                </div>
                <div class="row">
                    <div class="col-md-12 text-center"> 
                        <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-success" Width="120px"><i class="fa fa-search"></i>ค้นหา</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon lnr-list icon-gradient bg-success"></i>Request List
            <div class="btn-actions-pane-right">
                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then%>
                <a href="Request?m=new" class="btn btn-success pull-right"><i class="fa fa-plus-circle"></i>ยื่นคำขอใหม่</a>
                <% End If %>
            </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table id="tbdata" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 140px">เลขที่คำขอ</th>
                                <th class="text-center">ชื่อร้านยา</th>
                                <th class="text-center">เลขที่ ขย.5</th>
                                <th class="text-center">สถานที่ตั้ง</th>
                                <th class="text-center">วันที่ส่งคำขอ</th>
                                <th class="text-center">วันที่อนุมัติ</th>
                                <th class="text-center">วันที่สิ้นสุด</th>
                                <th  width="100" class="text-center">สถานะ</th>                             
                            </tr>
                        </thead>
                        <tbody>
                            <% For Each row As DataRow In dtREQ.Rows %>
                            <tr>
                                <td class="text-center"><% =String.Concat(row("Code")) %></td>
                                <td><% =String.Concat(row("LocationName")) %></td>
                                <td><% =String.Concat(row("LicenseNo1")) %></td>
                                <td><% =String.Concat(row("LocationAddress")) %></td> 
                                <td class="text-center"><% =String.Concat(row("CreateDate")) %></td>
                                <td class="text-center"><% =String.Concat(row("RequestDate")) %></td>
                                 <td class="text-center"><% =String.Concat(row("RequestDate")) %></td>
                                <td><% =String.Concat(row("AsmStatusName")) %></td>                              
                             

                            </tr>
                            <%  Next %>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>


    </section>
</asp:Content>
