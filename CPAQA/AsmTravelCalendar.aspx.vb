Imports BigLion
Imports Newtonsoft.Json

Public Class AsmTravelCalendar
    Inherits System.Web.UI.Page


    Dim ctlU As New UserController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblEventHeader.Text = "รายการการเดินทางออกตรวจ"

            ASPxCalendar1.HighlightToday = True
            ASPxCalendar1.HighlightWeekends = True
            ASPxCalendar1.ShowClearButton = True
            ASPxCalendar1.ShowTodayButton = True
            ASPxCalendar1.ShowDayHeaders = True
            ASPxCalendar1.ShowHeader = True
            ASPxCalendar1.ShowWeekNumbers = True

            ASPxCalendar1.Width = 200

            LoadEvent(Request("d"))
            LoadCalendarData()
        End If

    End Sub
    Private Sub LoadEvent(pDate As String)
        Dim dtA As New DataTable
        Dim dtP As New DataTable
        dtA = ctlU.AssessorTravel_GetByDate(pDate)
        grdAM.DataSource = dtA
        grdAM.DataBind()
    End Sub
    Dim dtCalendar As New DataTable
    Public Shared jsonTravel As String
    Private Sub LoadCalendarData()
        dtCalendar = ctlU.AssessorTravel_GetSchedule
        jsonTravel = JsonConvert.SerializeObject(dtCalendar, Formatting.Indented)
    End Sub


    Private Sub ASPxCalendar1_ValueChanged(sender As Object, e As EventArgs) Handles ASPxCalendar1.ValueChanged

        lblEventHeader.Text = "ผู้ประเมินที่ออกตรวจ On site วันที่ <span class='text-blue text-bold'>" & BigLion.DisplayLongDateTH(ASPxCalendar1.SelectedDate) & "</span>"
        LoadEvent(BigLion.ConvertFormateDate(ASPxCalendar1.SelectedDate))
    End Sub
End Class