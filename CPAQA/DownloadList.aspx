<%@ Page Title="รายการเอกสารดาวน์โหลด" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DownloadList.aspx.vb" Inherits="CPAQA.DownloadList" %>
<%@ Import Namespace="System.Data" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
      <div class="app-page-title">
                        <div class="page-title-wrapper">
                            <div class="page-title-heading">
                                <div class="page-title-icon">
                                    <i class="lnr-star icon-gradient bg-primary"></i>
                                </div>
                                <div>
                                    <asp:Label ID="lblPageTitle" runat="server" Text="รายการเอกสารดาวน์โหลด"></asp:Label>
                                    <div class="page-title-subheading"></div>
                                </div>
                            </div>
                        </div>
                    </div>      

<section class="content">                        
     <div class="box box-success">
        <div class="box-header with-border">
          <h2 class="box-title">รายการเอกสาร</h2>   
          <div class="box-tools pull-right">
               <% If Request.Cookies("ROLE_ID").Value = 3 Or Request.Cookies("ROLE_ID").Value = 9 Then %>   
              <asp:Button ID="cmdAdd" runat="server" CssClass="btn btn-success" Text="อัพโหลดใหม่" Width="120px" />  
                <% End If %> 
          </div>                       
        </div>
        <div class="box-body table-responsive">

                         <table id="tbdata" class="table table-hover table-bordered">
               <thead>
               <tr>
                  <th class="text-center" width="30">No.</th> 
                 <th class="text-left">รายการเอกสาร</th> 
                 <% If Request.Cookies("ROLE_ID").Value = 3 Or Request.Cookies("ROLE_ID").Value = 9 Then %>  
                 <th class="sorting_asc_disabled sorting_desc_disabled text-center">แก้ไข</th>       
                  <% End If %>
               </tr>
               </thead>
               <tbody>
           <% For Each row As DataRow In dtDoc.Rows %>
               <tr>               
  <td class="text-center"><% =String.Concat(row("nRow")) %></td>
                 <td>
                      <a href='<%= CPAQA.DownloadPath & String.Concat(row("FilePath")) %>' target="_blank"><% =String.Concat(row("Descriptions")) %> </a>
                 </td>    

               <% If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) > 8 Then%>  
                   <td width="50" class="text-center">  
                     <% If Request.Cookies("ROLE_ID").Value = 3 Or Request.Cookies("ROLE_ID").Value = 9 Then %>  
                           <a href="DownloadAdd?m=doc&id=<% =String.Concat(row("UID")) %>" class="btn btn-primary" data-toggle="tooltip" data-placement="top" data-original-title="แก้ไข"><i class="fa fa-edit" aria-hidden="true"></i></a>
                       <% End If %>                         
                   </td>
               <% End If %>
               </tr>
           <%  Next %>
               </tbody>               
             </table>                                        
    </div>
        <!-- /.box-body -->
        <div class="box-footer">
       
        </div>
        <!-- /.box-footer-->
      </div>
      <!-- /.box -->            

  </section>                  

</asp:Content>
