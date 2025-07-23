<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Complain.aspx.vb" Inherits="CPAQA.Complain" %>

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
                <div>รายการข้อร้องเรียน 
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
                    <div class="col-md-2">
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
                    <div class="col-md-2">
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
                  <div class="col-md-3">
                        <div class="form-group">
                            <label>ปัญหา</label>
                            <br />
                            <asp:DropDownList ID="ddlProblem" runat="server" CssClass="form-control select2" Width="100%" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>สถานะ</label>
                            <br />
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2" Width="100%" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="0">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="Y">ปิด</asp:ListItem>
                                <asp:ListItem Value="N">ยังไม่ปิด</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div> 
                     <div class="col-md-2">
                                        <div class="form-group">
                                            <label>ค้นหา</label>
                                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="ชื่อร้าน / เลข ขย.5 /เลขที่ใบอนุญาต"></asp:TextBox>
                                        </div>
                                    </div>
                    <div class="col-md-1 pt-4"> 
                        <asp:LinkButton ID="cmdView" runat="server" CssClass="btn btn-warning" Width="100px"><i class="fa fa-search"></i>ค้นหา</asp:LinkButton>
                    </div>

                </div> 
            </div>
        </div>
        <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon lnr-list icon-gradient bg-success"></i>Complain List
            <div class="btn-actions-pane-right">              
                <a href="ComplainDetail?m=new" class="btn btn-success pull-right"><i class="fa fa-plus-circle"></i>เพิ่มคำร้องเรียนใหม่</a>          
            </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table id="tbrequest" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 50px">เลขที่</th> 
                                <th class="text-center">ปัญหาที่ร้องเรียน</th>
                                <th class="text-center">ชื่อร้านที่ถูกร้องเรียน</th>
                                <th class="text-center">เลขที่ ขย.5</th>
                                <th class="text-center">สถานที่ตั้ง</th>                               
                                <th class="text-center">วันที่ร้องเรียน</th> 
                                <th  width="90" class="text-center">สถานะ</th>   
                                <th class="text-center">ผู้บันทึก</th> 
                                <th class="sorting_asc_disabled sorting_desc_disabled text-center"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <% For Each row As DataRow In dtREQ.Rows %>
                            <tr>
                                <td class="text-center"><% =String.Concat(row("CMPNO")) %></td>
                                  <td><% =String.Concat(row("ProblemName")) %></td>
                                <td><a href="ComplainDetail?m=cmp&id=<% =String.Concat(row("UID")) %>" data-toggle="tooltip" data-placement="top" data-original-title="ดูรายละเอียด"><% =String.Concat(row("LocationName")) %></a></td>
                                <td class="text-center"><% =String.Concat(row("LicenseNo1")) %></td>
                                <td><% =String.Concat(row("LocationAddress")) %></td>                              
                                <td class="text-center"><% =String.Concat(row("ComplainDTT")) %></td>
                                <td class="text-center"><% =String.Concat(row("StatusName")) %></td>     
                                <td><% =String.Concat(row("CreateBy")) %></td>   
                                <td class="text-center" style="width: 50px">                                   
                                    <a href="ComplainDetail?m=cmp&id=<% =String.Concat(row("UID")) %>" class="btn btn-primary" data-toggle="tooltip" data-placement="top" data-original-title="ดูรายละเอียด"><i class="fa fa-edit" aria-hidden="true"></i></a>
                                </td>
                            </tr>
                            <%  Next %>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>


    </section>
</asp:Content>
