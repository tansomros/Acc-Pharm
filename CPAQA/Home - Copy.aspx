<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="Ergonomic.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <!-- Content Header (Page header) -->
  <section class="content-header">
    <h1>
      Dashboard
      <small></small>
    </h1>
    <ol class="breadcrumb">
      <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
      <li class="active">Dashboard</li>
    </ol>
  </section>

  <!-- Main content -->
  <section class="content">

    <div class="row">
      <section class="col-lg-7 connectedSortable">


        <h4 class="text-blue">Personal</h4>

        <ul class="icon-list clearfix">
          <li>
            <a class="icon-list-name" href="PersonModify?ActionType=bio&t=m"><img src="images/menu/employee_card.png"
                alt="" width="64"></a>
            <a class="icon-list-name" href="PersonModify?ActionType=bio&t=m">Personal data</a>
          </li>
          <li>
            <a class="icon-list-name" href="PersonalHealth?ActionType=g&t=m"><img src="images/menu/checkup.png" alt=""
                width="64" /></a>
            <a class="icon-list-name" href="PersonalHealth?ActionType=g&t=m">Health data</a>
          </li>

          <li>
            <a class="icon-list-name" href="Evaluated?ActionType=asm&pid=<% =Session("LoginPersonUID") %>"><img
                src="images/reba/reba1_01.jpg" alt="" width="64"></a>
            <a class="icon-list-name" href="Evaluated?ActionType=asm&pid=<% =Session("LoginPersonUID") %>">Ergonomic
              Report</a>
          </li>

          <li>
            <a class="icon-list-name" href="AsmPersonRisk?ActionType=asm&pid=<% =Session("LoginPersonUID") %>"><img
                src="images/menu/hra.jpg" alt="" width="64"></a>
            <a class="icon-list-name" href="AsmPersonRisk?ActionType=asm&&pid=<% =Session("LoginPersonUID") %>">HRA
              Report</a>
          </li>

          <li>
            <a class="icon-list-name" href="#?ActionType=u"><img src="images/menu/keepass.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#?ActionType=u">เปลี่ยนรหัสผ่าน</a>

          </li>

        </ul>

        <% If Session("ROLE_ADM") = True Or Session("ROLE_SPA") = True Or Session("ROLE_CAD") = True Then%>

        <h4 class="text-blue">Customer</h4>


        <ul class="icon-list clearfix">
          <li>
            <a class="icon-list-name" href="Company?ActionType=comp"><img src="images/menu/company.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="Company?ActionType=comp">Company</a>
          </li>
          <li>
            <a class="icon-list-name" href="Person?ActionType=emp"><img src="images/menu/person.png" width="64"
                alt="ข้อมูลบุคคล"></a>
            <a class="icon-list-name" href="Person?ActionType=emp">Person</a>
          </li>
          <li>
            <a class="icon-list-name" href="Users?ActionType=u"><img src="images/menu/user.png" alt="" width="64"></a>
            <a class="icon-list-name" href="Users?ActionType=u">User Account</a>

          </li>

          <li>
            <a class="icon-list-name" href="PersonSelect?ActionType=health"><img src="images/menu/checkup.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="PersonSelect?ActionType=health">Person Health data</a>

          </li>




        </ul>

        <h4 class="text-blue">Task & Evaluated</h4>


        <ul class="icon-list clearfix">



          <li>
            <a class="icon-list-name" href="Task?ActionType=t"><img src="images/menu/task.png" alt="" width="64"></a>
            <a class="icon-list-name" href="Task?ActionType=t">Task</a>
          </li>
          <li>
            <a class="icon-list-name" href="Evaluated?ActionType=asm&ItemType=ega"><img src="images/menu/asm.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="Evaluated?ActionType=asm&ItemType=ega">Ergonomic Evaluated</a>
          </li>
          <li>
            <a class="icon-list-name" href="HRA?ActionType=asm&ItemType=prisk"><img src="images/menu/hra.jpg" alt=""
                width="64"></a>
            <a class="icon-list-name" href="HRA?ActionType=asm&ItemType=prisk">HRA</a>
          </li>

          <li>
            <a class="icon-list-name" href="HRAResult?ActionType=hraresult"><img src="images/menu/hra.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="HRAResult?ActionType=hraresult">HRA Result</a>
          </li>


          <li>
            <a class="icon-list-name" href="TaskAction?ActionType=atsk"><img src="images/menu/taskaction.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="TaskAction?ActionType=atsk">Action Tracking</a>
          </li>
          <li>
            <a class="icon-list-name" href="#?ActionType=t"><img src="images/menu/robot.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#?ActionType=t">Machine</a>
          </li>
          <li>
            <a class="icon-list-name" href="#?ActionType=t"><img src="images/menu/define_location.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="#?ActionType=t">Actions Item</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/police_station.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/Attendance.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
        </ul>



        <h4 class="text-blue">E-Learning</h4>

        <ul class="icon-list clearfix">

          <li>
            <a class="icon-list-name" href="CoursePerson"><img src="images/menu/classroom.png" alt="" width="64"></a>
            <a class="icon-list-name" href="CoursePerson">My Course</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/doughnut_chart.png" width="64" alt=""></a>
            <a class="icon-list-name" href="#">Total progressing</a>
          </li>

          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/video.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#">Course</a>
          </li>
          <li>
            <a class="icon-list-name" href="Person?ActionType=emp"><img src="images/menu/address_book.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="Person?ActionType=emp">Course Assign</a>

          </li>
   <li>
            <a class="icon-list-name" href="ReportPersonal?r=plearn"><img src="images/menu/motarboard.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="ReportPersonal?r=plearn">Personal Learning Report</a>
          </li>
 <li>
            <a class="icon-list-name" href="ReportCompany?r=comprog"><img src="images/menu/bullish.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="ReportCompany?r=comprog">Total Progressing</a>
          </li>
          <li>
            <a class="icon-list-name" href="ReportCourse?r=csprog"><img src="images/menu/investment_portfolio.png" alt="" width="64"></a>
            <a class="icon-list-name" href="ReportCourse?r=csprog">Course progressing</a>
          </li>
       

           

        </ul>


        <h4 class="text-blue">Report</h4>

        <ul class="icon-list clearfix">
          <li>
            <a class="icon-list-name" href="ReportTask"><img src="images/menu/graph_report.png" alt="" width="64"></a>
            <a class="icon-list-name" href="ReportTask">Total Task</a>
          </li>
          <li>
            <a class="icon-list-name" href="ReportPersonal"><img src="images/menu/personalreport.png" width="64"
                alt=""></a>
            <a class="icon-list-name" href="ReportPersonal">Personal Report</a>
          </li>
          <li>
            <a class="icon-list-name" href="ReportCompany?r=hracomp"><img src="images/menu/graph2.png" width="64"
                alt=""></a>
            <a class="icon-list-name" href="ReportCompany?r=hracomp">HRA</a>
          </li>
          <li>
            <a class="icon-list-name" href="ReportAction?r=acttask"><img src="images/menu/cloud_bar_chart.png" alt=""
                width="64"></a>
            <a class="icon-list-name" href="ReportAction?r=acttask">Task Action by Job</a>
          </li>
          <li>
            <a class="icon-list-name" href="ReportCompany?r=actdt"><img src="images/menu/report_file.png" width="64"
                alt=""></a>
            <a class="icon-list-name" href="ReportCompany?r=actdt">Task Action by Date</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/graph3.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/doughnut_chart.png" width="64" alt=""></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/cert.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/presentation.png" width="64" alt=""></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/bullish.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/combo_chart.png" width="64" alt=""></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/courses.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/investment_portfolio.png" width="64" alt=""></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/new_presentation.png" alt="" width="64"></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>
          <li>
            <a class="icon-list-name" href="#"><img src="images/menu/graph.png" width="64" alt=""></a>
            <a class="icon-list-name" href="#">Coming soon</a>
          </li>

        </ul>

        <h4 class="text-blue">Master data</h4>

        <ul class="icon-list clearfix">
          <li>
            <a class="icon-list-name" href="Prefix?ActionType=setting&ItemType=pre"><img src="images/menu/prefix.png"
                alt="" width="64"></a>
            <a class="icon-list-name" href="Prefix?ActionType=setting&ItemType=pre">คำนำหน้าชื่อ</a>
          </li>

          <li>
            <a class="icon-list-name" href="Division?ActionType=org&ItemType=div"><img src="images/menu/division.png"
                alt="ฝ่าย" width="64"></a>
            <a class="icon-list-name" href="Division?ActionType=org&ItemType=div">Section</a>
          </li>
          <li>
            <a class="icon-list-name" href="Department?ActionType=org&ItemType=dep"><img src="images/menu/dept.png"
                alt="แผนก" width="64"></a>
            <a class="icon-list-name" href="Department?ActionType=org&ItemType=dep">Department</a>
          </li>
          <li>
            <a class="icon-list-name" href="Position?ActionType=org&ItemType=pos"><img src="images/menu/pos.png"
                alt="ตำแหน่งงาน" width="64"></a>
            <a class="icon-list-name" href="Position?ActionType=org&ItemType=pos">Position</a>
          </li>

          <li>
            <a class="icon-list-name" href="Organization?ActionType=org&ItemType=org"><img src="images/menu/npc.png"
                alt="จัดการข้อมูลองค์กร" width="64"></a>
            <a class="icon-list-name" href="Organization?ActionType=org&ItemType=org">Organization</a>
          </li>
        </ul>
        <% End If %>

      </section>
      <section class="col-lg-5 connectedSortable">
        <div class="box box-primary">
          <div class="box-body no-padding">
            <!-- THE CALENDAR -->
            <div id="calendar"></div>
          </div>
          <!-- /.box-body -->
        </div>




      </section>
    </div>


    <div class="row">
      <section class="col-lg-5 connectedSortable">


      </section>
    </div>

  </section>

</asp:Content>