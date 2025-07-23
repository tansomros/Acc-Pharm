<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PharmacyGPPList.aspx.vb" Inherits="CPAQA.PharmacyGPPList" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="lnr-store icon-gradient bg-primary"></i>
                </div>
                <div>
                    ทะเบียนร้านยา
                            <div class="page-title-subheading">สำหรับ สสจ. ตรวจ GPP</div>
                </div>
            </div>
        </div>
    </div>

    <section class="content"> 
       <div class="row justify-content-center">
                          <div class="col-md-3">
          <div class="form-group">
            <label>เลือกปี </label>
               <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" CssClass="select2" Width="200"></asp:DropDownList> 
          </div>
        </div>  
            
        </div> 

        <div class="main-card mb-3 card">
            <div class="card-header">
                <i class="header-icon lnr-store icon-gradient bg-primary"></i>รายการร้านยาสำหรับ สสจ. ตรวจ GPP
            <div class="btn-actions-pane-right">               
            </div>
            </div>
            <div class="card-body table-responsive">
               <table id="tbdata" class="table table-bordered">
                    <thead>
                        <tr>
                            <th class="text-center">เลขที่ใบอนุญาต ขย.5</th>
                            <th class="text-left">ชื่อร้านยา</th>
                            <th class="text-center">เขต/อำเภอ</th>                            
                            <th class="text-center">จังหวัด</th>
                            <th class="text-center">สถานะ</th>
                            <th class="text-center">วันที่อนุญาต</th>
                            <th class="text-center">ปีที่หมดอายุ</th>
                            <th class="text-center">Assign ผู้ตรวจ</th>
                            <th class="text-center">ประเมิน</th>
                            <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 Then%>
                            <th class="sorting_asc_disabled sorting_desc_disabled text-center"></th>
                            <% End If %>
                        </tr>
                    </thead>
                    <tbody>
                        <% For Each row As DataRow In dtGPP.Rows %>
                        <tr>
                            <td class="text-center"><% =String.Concat(row("LicenseNo1")) %></td>
                            <td><a href="PharmacyGPP?m=g&lid=<% =String.Concat(row("LocationUID")) %>" data-toggle="tooltip" data-placement="top" data-original-title="ประเมิน GPP"><% =String.Concat(row("LocationName")) %> </a></td>
                            <td class="text-center"><% =String.Concat(row("District")) %></td>                            
                            <td class="text-center"><% =String.Concat(row("ProvinceName")) %> </td>
                            <td class="text-center"><% =String.Concat(row("LicenseStatusName")) %></td>
                            <td class="text-center"><% =String.Concat(row("StartDtt")) %></td>
                            <td class="text-center"><% =String.Concat(row("ExpYear")) %></td>
                            <td><% =String.Concat(row("DCName")) %></td>
                              <td class="text-center"><% if String.Concat(row("AsmSatus")) ="Y" Then %>
                                    <img src="images/icon-ok.png" />
                                  <% End If %>
                              </td>

                            <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 Then%>
                            <td width="160" class="text-center">
                                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 Then %>
                                <a href="LocationModify?m=l2&lid=<% =String.Concat(row("LocationUID")) %>" class="btn btn-primary" data-toggle="tooltip" data-placement="top" data-original-title="ข้อมูลร้านยา"><i class="fa fa-search" aria-hidden="true"></i></a>                             
                                <a href="PharmacyGPP?m=g&lid=<% =String.Concat(row("LocationUID")) %>" class="btn btn-success" data-toggle="tooltip" data-placement="top" data-original-title="ประเมิน GPP"><i class="fa fa-edit" aria-hidden="true"></i></a>
                                <% End If %>                         
                            </td>
                            <% End If %>
                        </tr>
                        <%  Next %>
                    </tbody>
                </table>
            </div>
            
        </div>


    </section>
</asp:Content>
