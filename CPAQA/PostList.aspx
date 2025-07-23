<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PostList.aspx.vb" Inherits="CPAQA.PostList" %>
<%@ Import Namespace="System.Data" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

    <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-medal icon-gradient bg-mean-fruit"></i>
                        </div>
                        <div>การตรวจประเมินรักษาคุณภาพ
                            <div class="page-title-subheading">บันทึกการตรวจประเมินรักษาคุณภาพ</div>
                        </div>
                    </div>
                </div>
            </div>

    <section class="content"> 
         <div class="main-card mb-3 card">
        <div class="card-header"><i class="header-icon lnr-store icon-gradient bg-success">
            </i>ร้านยาและสถานะการตรวจ
            <div class="btn-actions-pane-right">             
            </div>
        </div>     
              <div class="card-body table-responsive">   
              <table id="tbaudit" class="table table-bordered">
                <thead>
                <tr> 
                 
                   <th class="text-center">เลขที่ใบอนุญาต ขย.5</th> 
                  <th class="text-left">ชื่อร้านยา</th>                         
                      <th class="text-center">เลขที่ใบรับรองร้านยาคุณภาพ</th> 
                      <th class="text-center">จังหวัด</th>
                      <th class="text-center">อำเภอ</th>
                      <th class="text-center">วันที่บันทึก</th>
                      <th class="text-center">ระบบร้านยาคุณภาพ</th>
                      <th class="text-center">Common illness</th>                    
                  <th class="sorting_asc_disabled sorting_desc_disabled text-center">ดู/แก้ไข</th>       
                </tr>
                </thead>
                <tbody>
            <% For Each row As DataRow In dtLoc.Rows %>
                <tr>               
                    <td class="text-center"><% =String.Concat(row("LicenseNo1")) %></td>
                    <td><a href="PostAudit?m=po&s=list&lid=<% =String.Concat(row("UID")) %>&id=<% =String.Concat(row("PostUID")) %>"><% =String.Concat(row("LocationName")) %> </a></td>
                    <td class="text-center"><% =String.Concat(row("AccLicense")) %></td>
                    <td class="text-center"><% =String.Concat(row("ProvinceName")) %> </td>
                    <td class="text-center"><% =String.Concat(row("DistrictName")) %> </td>
                    <td class="text-center"><% =String.Concat(row("SubmitDttm")) %></td>
                    <td class="text-center"><% =String.Concat(row("QAStatus")) %></td>
                    <td class="text-center"><% =String.Concat(row("CIStatus")) %></td>
                    <td width="80" class="text-center">
                        <a href="PostAudit?m=po&s=list&lid=<% =String.Concat(row("UID")) %>&id=<% =String.Concat(row("PostUID")) %>" class="btn btn-primary" data-toggle="tooltip" data-placement="top" data-original-title="บันทึกการตรวจ"><i class="fa fa-edit" aria-hidden="true"></i></a>
                    </td>
                </tr>
            <%  Next %>
                </tbody>               
              </table>                                    
            </div>
            
          </div>
 
  
    </section>
</asp:Content>
