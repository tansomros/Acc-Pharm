<%@ Page Title="รายชื่อร้านยา" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="LocationList.aspx.vb" Inherits="CPA.LocationList" %>
<%@ Import Namespace="System.Data" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

    <div class="app-page-title">
                <div class="page-title-wrapper">
                    <div class="page-title-heading">
                        <div class="page-title-icon">
                            <i class="pe-7s-home icon-gradient bg-mean-fruit"></i>
                        </div>
                        <div>ทะเบียนร้านยา
                            <div class="page-title-subheading">รายการทะเบียนร้านยา </div>
                        </div>
                    </div>
                </div>
            </div>

    <section class="content"> 
         <div class="main-card mb-3 card">
        <div class="card-header"><i class="header-icon fa fa-home icon-gradient bg-success">
            </i>Drug Store List
            <div class="btn-actions-pane-right">
                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 3 Then%>  
                <a href="LocationNew?m=l&s=reg"  class="btn btn-success pull-right"><i class="fa fa-plus-circle"></i> เพิ่มร้านยาใหม่</a>    
                <% End If %>
            </div>
        </div>     
              <div class="card-body table-responsive">   
              <table id="tbdata" class="table table-bordered">
                <thead>
                <tr>
                   <th class="text-center">เลขที่ใบอนุญาต ขย.5</th> 
                  <th class="text-left">ชื่อร้านยา</th>   
<th class="text-left">E-mail</th>              
                     <th class="text-center">กลุ่ม</th>                   
                      <th class="text-center">จังหวัด</th>
                    <th class="text-center">วันที่อนุญาต</th>
                      <th class="text-center">ปีที่หมดอายุ</th>
 <th class="text-center">วันที่ลงทะเบียน</th>   
                     <th class="text-center">Last Update</th>     
                   <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) > 1 Then%>  
                  <th class="sorting_asc_disabled sorting_desc_disabled text-center"></th>       
                       <% End If %>
                </tr>
                </thead>
                <tbody>
            <% For Each row As DataRow In dtLoc.Rows %>
                <tr>               
   <td class="text-center"><% =String.Concat(row("LicenseNo1")) %></td>
                  <td><a  href="LocationModify?m=l&s=reg&lid=<% =String.Concat(row("UID")) %>" ><% =String.Concat(row("LocationName")) %> </a>  </td>
<td class="text-left"><% =String.Concat(row("Email")) %></td>
 <td class="text-center"><% =String.Concat(row("LocationGroupName")) %></td>                      
                      
                      <td class="text-center"><% =String.Concat(row("ProvinceName")) %> </td>  
                   <td class="text-center"><% =String.Concat(row("LicenStartDtt")) %></td>
                       <td class="text-center"><% =String.Concat(row("LicenseExpireYear")) %></td>
       <td class="text-center"><% =String.Concat(row("Registerdate")) %></td>
                    <td class="text-center"><% =String.Concat(row("LastUpdate")) %></td>
                <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) > 1 Then%>  
                    <td width="160" class="text-center">  
                        <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) > 1 Then %>
                            <a href="LocationModify?m=l&lid=<% =String.Concat(row("UID")) %>" class="btn btn-primary" data-toggle="tooltip" data-placement="top" data-original-title="ข้อมูลร้านยา"><i class="fa fa-edit" aria-hidden="true"></i></a>

                        <a href="Pharmacist?m=l&lid=<% =String.Concat(row("UID")) %>" class="btn btn-success" data-toggle="tooltip" data-placement="top" data-original-title="ข้อมูลเภสัชกร"><i class="fa fa-user-md" aria-hidden="true"></i></a>

                         <a href="LocationHour?m=l&lid=<% =String.Concat(row("UID")) %>" class="btn btn-warning" data-toggle="tooltip" data-placement="top" data-original-title="จัดการเวลาเปิด/ปิดร้าน"><i class="fa fa-clock" aria-hidden="true"></i></a>

                        <% End If %>                         
                    </td>
                <% End If %>
                </tr>
            <%  Next %>
                </tbody>               
              </table>                                    
            </div>
            <!-- /.box-body    <a href="LocationDetail?m=v&id=< % =String.Concat(row("UID")) %>" class="font-icon-button"><i class="fa fa-file-pdf" aria-hidden="true"></i> ดูรายละเอียด</a> -->
          </div>
 
  
    </section>
</asp:Content>
