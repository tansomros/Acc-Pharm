<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AsmTravelCalendar.aspx.vb" Inherits="CPAQA.AsmTravelCalendar" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script>
        $(function () {

            /* initialize the external events
             -----------------------------------------------------------------*/
            function init_events(ele) {
                ele.each(function () {

                    var eventObject = {
                        title: $.trim($(this).text()) // use the element's text as the event title
                    }

                    // store the Event Object in the DOM element so we can get to it later
                    $(this).data('eventObject', eventObject)

                    // make the event draggable using jQuery UI
                    $(this).draggable({
                        zIndex: 1070,
                        revert: true, // will cause the event to go back to its
                        revertDuration: 0 //  original position after the drag
                    })

                })
            }

            init_events($('#external-events div.external-event'))

            /* initialize the calendar
             -----------------------------------------------------------------*/

            var date = new Date()
            var d = date.getDate(),
                m = date.getMonth(),
                y = date.getFullYear()
            $('#calendar3').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                buttonText: {
                    today: 'today',
                    month: 'month',
                    week: 'week',
                    day: 'day'
                },
                //Random default events
                events: <%= jsonTravel %>,
                editable: true,
                droppable: true, // this allows things to be dropped onto the calendar !!!
                drop: function (date, allDay) { // this function is called when something is dropped

                    // retrieve the dropped element's stored Event Object
                    var originalEventObject = $(this).data('eventObject')

                    // we need to copy it, so that multiple events don't have a reference to the same object
                    var copiedEventObject = $.extend({}, originalEventObject)

                    // assign it the date that was reported
                    copiedEventObject.start = date
                    copiedEventObject.allDay = allDay
                    copiedEventObject.backgroundColor = $(this).css('background-color')
                    copiedEventObject.borderColor = $(this).css('border-color')
                    copiedEventObject.color = '#666'

                    $('#calendar3').fullCalendar('renderEvent', copiedEventObject, true)

                    // is the "remove after drop" checkbox checked?
                    if ($('#drop-remove').is(':checked')) {
                        // if so, remove the element from the "Draggable Events" list
                        $(this).remove()
                    }

                }
            })

            /* ADDING EVENTS */
            var currColor = '#3c8dbc' //Red by default
            //Color chooser button
            var colorChooser = $('#color-chooser-btn')
            $('#color-chooser > li > a').click(function (e) {
                e.preventDefault()
                //Save color
                currColor = '#666' // $(this).css('color')
                //Add color effect to button
                $('#add-new-event').css({
                    'background-color': currColor,
                    'border-color': currColor,
                    'color': '#666'
                })
            })
            $('#add-new-event').click(function (e) {
                e.preventDefault()
                //Get value and make sure it is not null
                var val = $('#new-event').val()
                if (val.length == 0) {
                    return
                }

                //Create events
                var event = $('<div />')
                event.css({
                    'background-color': currColor,
                    'border-color': currColor,
                    'color': '#666'
                }).addClass('external-event')
                event.html(val)
                $('#external-events').prepend(event)

                //Add draggable funtionality
                init_events(event)

                //Remove event from text input
                $('#new-event').val('')
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div class="page-title-icon">
                    <i class="pe-7s-clock icon-gradient bg-secondary"></i>
                </div>
                <div>
                    ตารางวันเดินทางออกตรวจประเมิน
                    <div class="page-title-subheading">แสดงผู้ตรวจประเมินว่าออกตรวจอยู่จังหวัดไหน</div>
                </div>
            </div>
        </div>
    </div>
    <section class="content">

        <div class="row">
            <section class="col-lg-3 connectedSortable">
                <div class="col-md-12">
                    <dx:ASPxCalendar ID="ASPxCalendar1" runat="server" Theme="Material" AutoPostBack="true" Width="100%"></dx:ASPxCalendar>
                </div>
            </section>
            <section class="col-lg-9 connectedSortable">
                <div class="row">

                    <div class="col-md-12">

                        <div class="box box-success">
                            <div class="box-header">
                                <h2 class="box-title">
                                    <asp:Label ID="lblEventHeader" runat="server"></asp:Label></h2>
                            </div>
                            <div class="box-body">
                                <asp:GridView ID="grdAM" runat="server" AutoGenerateColumns="False" Width="98%" Font-Bold="False" PageSize="20" ShowHeader="False" BorderStyle="None" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" CssClass="table table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="AssessorName"></asp:BoundField>
                                        <asp:BoundField DataField="ProvinceName"></asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle Font-Bold="True" Height="25px" BackColor="#333333" BorderStyle="None" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>


                </div>

            </section>
        </div>
        <br />
        <div class="row">
            <section class="col-lg-12 connectedSortable">
                <div class="main-card mb-3 card">
                    <div class="card-header">
                        <i class="header-icon lnr-calendar-full icon-gradient bg-plum-plate"></i>ตารางวันเดินทางออกตรวจ  
                     
                    </div>
                    <div class="card-body no-padding">
                        <div id="calendar3"></div>
                    </div>
                </div>
            </section>
        </div>
    </section>

</asp:Content>
