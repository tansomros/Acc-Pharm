<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportAction.aspx.vb" Inherits="CPAQA.ReportAction" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
      <h1>Task Action Report<small></small></h1>   
</section>

<section class="content">  

         <div class="box box-solid">
            <div class="box-header">           
            </div>
            <div class="box-body"> 
 <div class="col-lg-2"></div>

<div class="col-lg-8 row" style="background-color:#14539a;color: white">
      <br />   <br />   <br />      
      <div class="row">
   <div class="col-md-6">
          <div class="form-group">
            <label>Company</label>
              <asp:DropDownList ID="ddlCompany" runat="server" cssclass="form-control select2" Width="100%">                   
            </asp:DropDownList>
          </div>

        </div>

           <div class="col-md-6">
          <div class="form-group">
            <label>Task</label>
                <asp:DropDownList ID="ddlTask" runat="server" cssclass="form-control select2" Width="100%">
            </asp:DropDownList>
          </div>

        </div>
         </div>
                <div class="row">      

            <div class="col-md-3">
          <div class="form-group">
            <label>Start Date</label>
              <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                  </div>
                  <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" autocomplete="off" data-date-format="dd/mm/yyyy" data-date-language="th-th" data-provide="datepicker" onkeyup="chkstr(this,this.value)"></asp:TextBox>
                </div>

            
          </div>

        </div>
        <div class="col-md-3">
          <div class="form-group">
            <label>End Date</label>
              <div class="input-group">
                  <div class="input-group-addon">
                    <i class="fa fa-calendar"></i>
                  </div>
                  <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" autocomplete="off" data-date-format="dd/mm/yyyy" data-date-language="th-th" data-provide="datepicker" onkeyup="chkstr(this,this.value)"></asp:TextBox>
                </div>
          </div>

        </div>

          </div>
                <div class="row"> 
                    <div class="col-md-2">
          <div class="form-group">           
              <asp:CheckBox ID="chkExcel" runat="server" Text="Excel"  />
          </div>

        </div>
     
      
      </div>

  <div class="row">
   <div class="col-md-12 text-center">
       <asp:Button ID="cmdPrint" runat="server" CssClass="btn btn-info" Width="120px"   Text="Print Preview" />
   
      
       </div>
      </div>

       <br />   <br />   <br />
    </div>
 <div class="col-lg-2"></div>
</div>
            <div class="box-footer clearfix">
           
            </div>
          </div>

</section>   
</asp:Content>
