<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home2.aspx.vb" Inherits="iLA.Home2" %>
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
      <section class="col-lg-8 connectedSortable">
        <div class="box box-nobg no-border">
          <div class="box-body no-padding">
        <!--h4 class="text-gray">Personal</h4 -->

  
        <div class="col-md-2">
         <a class="icon-menu1" href="PersonModify?ActionType=bio&t=m">
             <div class="icon-imenu1"><div><img src="images/menu/card_id.png" alt="" width="64"></div>
              <div class="icon-menu1-name1">Personal data</div>
          </div></a>

</div>       

             
          
      
          <div class="col-md-2">
            <a class="icon-menu1" href="PersonalHealth?ActionType=g&t=m"><div class="icon-imenu1"><div><img src="images/menu/checkup1.png" alt="" width="64" /></div>
            <div class="icon-menu1-name1">Health data</div>
          </div></a></div>

          <div class="col-md-2">
            <a class="icon-menu1" href="Evaluated?ActionType=agrpt&pid=<% =Request.Cookies("iLaw")("LoginPersonUID") %>">
                 <div class="icon-imenu1">
                <div><img src="images/menu/bench_over_head.png" alt="" width="64" /></div>
            <div class="icon-menu1-name1">Ergonomic<br />Report</div>
          </div></a></div>

          <div class="col-md-2">
            <a class="icon-menu1" href="HRAResult?ActionType=hrarpt&pid=<% =Request.Cookies("iLaw")("LoginPersonUID") %>"><div class="icon-imenu1"><div><img
                src="images/menu/hrar.png" alt="" width="64" /></div>
            <div class="icon-menu1-name1">HRA
              Report</div>
          </div></a></div>

          <div class="col-md-2">
            <a class="icon-menu1" href="#?ActionType=chg">
                <div class="icon-imenu1"><div><img src="images/menu/keepass.png" alt="" width="64" /></div>
            <div class="icon-menu1-name1">เปลี่ยนรหัสผ่าน</div>
          </div></a></div>

 
           
          <% If Request.Cookies("iLaw")("ROLE_ADM") = True Or Request.Cookies("iLaw")("ROLE_SPA") = True Or Request.Cookies("iLaw")("ROLE_APP") = True Then%>
 
        <!-- h4 class="text-gray">Employee</h4 -->
        
          
          <div class="col-md-2">
            <a class="icon-menu2" href="Person?ActionType=emp">
                <div class="icon-imenu1">
                    <div><img src="images/menu/person.png" width="64" alt="ข้อมูลบุคคล"></div>
            <div class="icon-menu1-name2">Person</div>
          </div></a>
              </div>
           

          <div class="col-md-2">
            <a class="icon-menu2" href="Users?ActionType=u"><div class="icon-imenu1"><div><img src="images/menu/user.png" alt="" width="64" /></div>
            <div class="icon-menu1-name2">User Account</div>
          </div></a></div>

          <div class="col-md-2">
            <a class="icon-menu2" href="PersonSelect?ActionType=health"><div class="icon-imenu1"><div><img src="images/menu/checkup.png" alt=""    width="64" /></div>
            <div class="icon-menu1-name2">Person<br />Health data</div>
          </div></a></div>
        

        <!-- h4 class="text-gray">Task & Evaluated</h4 -->

        
          <div class="col-md-2">
            <a class="icon-menu2" href="Task?ActionType=tsk"><div class="icon-imenu1"><div><img src="images/menu/task.png" alt="" width="64" /></div>
            <div class="icon-menu1-name2">Task</div>
          </div></a></div>
          <div class="col-md-2">
            <a class="icon-menu2" href="Evaluated?ActionType=asm&ItemType=ega"><div class="icon-imenu1"><div><img src="images/menu/asm.png" alt=""
                width="64" /></div>
            <div class="icon-menu1-name2">Ergonomic<br />Evaluated</div>
          </div></a></div>   

          <div class="col-md-2">
            <a class="icon-menu2" href="HRA?ActionType=hraresult"><div class="icon-imenu1"><div><img src="images/menu/hra.png" alt=""
                width="64" /></div>
            <div class="icon-menu1-name2">HRA Result</div>
          </div></a></div>


          <div class="col-md-2">
            <a class="icon-menu2" href="TaskAction?ActionType=atsk"><div class="icon-imenu1"><div><img src="images/menu/taskaction.png" alt=""            width="64" /></div>
            <div class="icon-menu1-name2">Action Tracking</div>
          </div></a></div>
         
         
        

    <% End If %>

 
        <!-- h4 class="text-gray">E-Learning</h4 -->

              
          <div class="col-md-2">
            <a class="icon-menu3" href="CoursePerson?ActionType=e"><div class="icon-imenu1"><div><img src="images/menu/video.png" alt="" width="64" /></div>
            <div class="icon-menu1-name3">My Course</div>
          </div></a></div>   

    <% If Request.Cookies("iLaw")("ROLE_ADM") = True Or Request.Cookies("iLaw")("ROLE_SPA") = True Then %>
          <div class="col-md-2">
            <a class="icon-menu3" href="Course?ActionType=eln&ItemType=cs"><div class="icon-imenu1"><div><img src="images/menu/courses.png" alt="" width="64" /></div>
            <div class="icon-menu1-name3">Course</div>
          </div></a></div>
  <% End If %>

    <% If Request.Cookies("iLaw")("ROLE_ADM") = True Or Request.Cookies("iLaw")("ROLE_SPA") = True Or Request.Cookies("iLaw")("ROLE_APP") = True Then%>
          <div class="col-md-2">
            <a class="icon-menu3" href="Person?ActionType=emp"><div class="icon-imenu1"><div><img src="images/menu/address_book.png" alt="" width="64" /></div>
            <div class="icon-menu1-name3">Course Assign</div>
          </div></a></div>
 <% End If %>

            
    <% If Request.Cookies("iLaw")("ROLE_ADM") = True Or Request.Cookies("iLaw")("ROLE_SPA") = True Then %>
          <div class="col-md-2">
            <a class="icon-menu3" href="EvaluationTopic?ActionType=eln&ItemType=eva"><div class="icon-imenu1"><div><img src="images/menu/abc.png" alt="" width="64" /></div>
            <div class="icon-menu1-name3">จัดการแบบทดสอบ</div>
          </div></a></div>
  <% End If %>
   
          <div class="col-md-2">
            <a class="icon-menu3" href="ReportPersonal?r=plearn"><div class="icon-imenu1"><div><img src="images/menu/motarboard.png" alt=""
                width="64" /></div>
            <div class="icon-menu1-name3">Personal <br />Learning Report</div>
          </div></a></div>
             

    <% If Request.Cookies("iLaw")("ROLE_ADM") = True Or Request.Cookies("iLaw")("ROLE_SPA") = True Or Request.Cookies("iLaw")("ROLE_APP") = True Then%>
          <div class="col-md-2">
            <a class="icon-menu3" href="ReportCompany?r=comprog"><div class="icon-imenu1"><div><img src="images/menu/bullish.png" alt=""
                width="64" /></div>
            <div class="icon-menu1-name3">Total <br />Progressing</div>
          </div></a></div>

          <div class="col-md-2">
            <a class="icon-menu3" href="ReportCourse?r=csprog"><div class="icon-imenu1"><div><img src="images/menu/police_station.png" alt="" width="64" /></div>
            <div class="icon-menu1-name3">Course <br />progressing</div>
          </div></a></div>


        <!-- h4 class="text-gray">Report</h4 -->

        
          <div class="col-md-2">
            <a class="icon-menu4" href="ReportTask"><div class="icon-imenu1"><div><img src="images/menu/doughnut_chart.png" alt="" width="64" /></div>
            <div class="icon-menu1-name4">Total Task</div>
          </div></a></div>

          <div class="col-md-2">
            <a class="icon-menu4" href="ReportPersonal"><div class="icon-imenu1"><div><img src="images/menu/personalreport.png" width="64"         alt=""></div>
            <div class="icon-menu1-name4">Personal Report</div>
          </div></a></div>

          <div class="col-md-2">
            <a class="icon-menu4" href="ReportCompany?r=hracomp"><div class="icon-imenu1"><div><img src="images/menu/graph2.png" width="64" alt=""></div>
            <div class="icon-menu1-name4" >HRA</div>
          </div></a></div>


             <div class="col-md-2">
            <a class="icon-menu4" href="ReportCompany1?r=msd"><div class="icon-imenu1"><div><img src="images/menu/hor_chart.png" width="64"
                alt=""></div>
            <div class="icon-menu1-name4">MSDs</div>
          </div></a></div>

          <div class="col-md-2">
            <a class="icon-menu4" href="ReportAction?r=acttask"><div class="icon-imenu1"><div><img src="images/menu/graph.png" alt=""
                width="64" /></div>
            <div class="icon-menu1-name4">Task Action<br /> by Job</div>
          </div></a></div>
          <div class="col-md-2">
            <a class="icon-menu4" href="ReportCompany?r=actdt"><div class="icon-imenu1"><div><img src="images/menu/graph3.png" width="64"
                alt=""></div>
            <div class="icon-menu1-name4">Task Action<br /> by Date</div>
          </div></a></div>
        

          <% End If %>
  
  

    <% If Request.Cookies("iLaw")("ROLE_SPA") = True Or Request.Cookies("iLaw")("ROLE_ADM") = True Or Request.Cookies("iLaw")("ROLE_APP") = True Then%>  
        
         

    <!-- h4 class="text-gray">Master data</h4 -->
        <div class="col-md-2">
            <a class="icon-menu5" href="Organization?ActionType=setup&ItemType=org"><div class="icon-imenu1"><div><img src="images/menu/org.png"
                alt="จัดการข้อมูลองค์กร" width="64" /></div>
            <div class="icon-menu1-name5">Organization</div>
            </div></a></div>
        <% If Request.Cookies("iLaw")("ROLE_SPA") = True Or Request.Cookies("iLaw")("ROLE_ADM") = True Then%>     
                  
          <div class="col-md-2">
            <a class="icon-menu5" href="Company?ActionType=setup&ItemType=comp"><div class="icon-imenu1"><div><img src="images/menu/company.png" alt=""     width="64" /></div>
            <div class="icon-menu1-name5">Customer <br />Company</div>
          </div></a></div>
           
            
            <div class="col-md-2">
            <a class="icon-menu5" href="Prefix?ActionType=setup&ItemType=pre"><div class="icon-imenu1"><div><img src="images/menu/medal.png"
                alt="" width="64" /></div>
            <div class="icon-menu1-name5">คำนำหน้าชื่อ</div>
            </div></a></div>
            <div class="col-md-2">
            <a class="icon-menu5" href="Position?ActionType=org&ItemType=pos"><div class="icon-imenu1"><div><img src="images/menu/pos.png"
                alt="ตำแหน่งงาน" width="64" /></div>
            <div class="icon-menu1-name5">Position</div>
            </div></a></div>
        <% End If %>

        <% If Request.Cookies("iLaw")("ROLE_SPA") = True Or Request.Cookies("iLaw")("ROLE_ADM") = True Or Request.Cookies("iLaw")("ROLE_APP") = True Then%>  
            <div class="col-md-2">
            <a class="icon-menu5" href="Division?ActionType=org&ItemType=div"><div class="icon-imenu1"><div><img src="images/menu/division.png"
                alt="ฝ่าย" width="64" /></div>
            <div class="icon-menu1-name5">Section</div>
            </div></a></div>
            <div class="col-md-2">
            <a class="icon-menu5" href="Department?ActionType=org&ItemType=dep"><div class="icon-imenu1"><div><img src="images/menu/dept.png"
                alt="แผนก" width="64" /></div>
            <div class="icon-menu1-name5">Department</div>
            </div></a></div> 
            
             <div class="col-md-2">
            <a class="icon-menu5" href="Machine?ActionType=mac"><div class="icon-imenu1"><div><img src="images/menu/robot.png" alt="" width="64" /></div>
            <div class="icon-menu1-name5">Machine</div>
          </div></a></div>

               <% If Request.Cookies("iLaw")("ROLE_SPA") = True Or Request.Cookies("iLaw")("ROLE_ADM") = True Then%>        
                       <div class="col-md-2">
            <a class="icon-menu5" href="ActionStatus?ActionType=t"><div class="icon-imenu1"><div><img src="images/menu/define_location.png" alt=""
                width="64" /></div>
            <div class="icon-menu1-name5">Actions<br /> Status</div>
          </div></a></div>
               <% End If %>
            
        <% End If %>
  <% End If %>
      </div>
        </div>    
      </section>
      <section class="col-lg-4 connectedSortable">
        <div class="box box-primary">
          <div class="box-body no-padding">
            <!-- THE CALENDAR -->
            <div id="calendar"></div>
          </div>
        </div>
      </section>
    </div>
</section>
</asp:Content>