Imports BigLion
Imports DevExpress.Web.ASPxHtmlEditor.Internal

Public Class LocationHour
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Dim vs As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Request("lid") Is Nothing Then
                Response.Redirect("Home.aspx?m=h")
            Else
                chkMon.Checked = False
                chkTue.Checked = False
                chkWed.Checked = False
                chkThu.Checked = False
                chkFri.Checked = False
                chkSat.Checked = False
                chkSun.Checked = False
                vs = False
                hdLocationUID.Value = Request("lid")
                lblLocationName.Text = ctlL.Location_GetNameByUID(StrNull2Zero(hdLocationUID.Value))
                LoadBusinessHour()
            End If

        End If
        txtBeginSun.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEndSun.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")

        txtBeginMon.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEndMon.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")

        txtBeginTue.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEndTue.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")

        txtBeginWed.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEndWed.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")

        txtBeginThu.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEndThu.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")

        txtBeginFri.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEndFri.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")

        txtBeginSat.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEndSat.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
    End Sub
    Private Sub LoadBusinessHour()
        Dim dtH As New DataTable
        dtH = ctlL.LocationHour_Get(StrNull2Zero(hdLocationUID.Value))
        If dtH.Rows.Count > 0 Then
            For i = 0 To dtH.Rows.Count - 1
                With dtH.Rows(i)
                    Select Case .Item("DayCode")
                        Case "SUN"
                            chkSun.Checked = ConvertYN2Boolean(.Item("OpenStatus"))
                            txtBeginSun.Text = String.Concat(.Item("OpenTime"))
                            txtEndSun.Text = String.Concat(.Item("CloseTime"))
                        Case "MON"
                            chkMon.Checked = ConvertYN2Boolean(.Item("OpenStatus"))
                            txtBeginMon.Text = String.Concat(.Item("OpenTime"))
                            txtEndMon.Text = String.Concat(.Item("CloseTime"))
                        Case "TUE"
                            chkTue.Checked = ConvertYN2Boolean(.Item("OpenStatus"))
                            txtBeginTue.Text = String.Concat(.Item("OpenTime"))
                            txtEndTue.Text = String.Concat(.Item("CloseTime"))
                        Case "WED"
                            chkWed.Checked = ConvertYN2Boolean(.Item("OpenStatus"))
                            txtBeginWed.Text = String.Concat(.Item("OpenTime"))
                            txtEndWed.Text = String.Concat(.Item("CloseTime"))
                        Case "THU"
                            chkThu.Checked = ConvertYN2Boolean(.Item("OpenStatus"))
                            txtBeginThu.Text = String.Concat(.Item("OpenTime"))
                            txtEndThu.Text = String.Concat(.Item("CloseTime"))
                        Case "FRI"
                            chkFri.Checked = ConvertYN2Boolean(.Item("OpenStatus"))
                            txtBeginFri.Text = String.Concat(.Item("OpenTime"))
                            txtEndFri.Text = String.Concat(.Item("CloseTime"))
                        Case "SAT"
                            chkSat.Checked = ConvertYN2Boolean(.Item("OpenStatus"))
                            txtBeginSat.Text = String.Concat(.Item("OpenTime"))
                            txtEndSat.Text = String.Concat(.Item("CloseTime"))
                    End Select
                End With

            Next
        End If
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        SaveHour(1, "SUN", ConvertBoolean2YN(chkSun.Checked), txtBeginSun.Text, txtEndSun.Text)
        SaveHour(2, "MON", ConvertBoolean2YN(chkMon.Checked), txtBeginMon.Text, txtEndMon.Text)
        SaveHour(3, "TUE", ConvertBoolean2YN(chkTue.Checked), txtBeginTue.Text, txtEndTue.Text)
        SaveHour(4, "WED", ConvertBoolean2YN(chkWed.Checked), txtBeginWed.Text, txtEndWed.Text)
        SaveHour(5, "THU", ConvertBoolean2YN(chkThu.Checked), txtBeginThu.Text, txtEndThu.Text)
        SaveHour(6, "FRI", ConvertBoolean2YN(chkFri.Checked), txtBeginFri.Text, txtEndFri.Text)
        SaveHour(7, "SAT", ConvertBoolean2YN(chkSat.Checked), txtBeginSat.Text, txtEndSat.Text)

        If vs = False Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)
            LoadBusinessHour()
        End If

    End Sub

    Private Sub SaveHour(ByVal DayNo As Integer, DayCode As String, sOpenStatus As String, ByVal sBeginTime As String, ByVal sEndTime As String)
        Dim StartTime, EndTime As String
        StartTime = ""
        EndTime = ""
        If sOpenStatus = "Y" Then
            If sBeginTime = "" Or sEndTime = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนเวลาเปิด/ปิด วัน" & DisplayDayTH(DayCode) & "ให้ครบถ้วนก่อน');", True)
                vs = True
                Exit Sub
            End If
            Dim strB(), strE() As String
            strB = Split(sBeginTime, ":")
            strE = Split(sEndTime, ":")
            If StrNull2Zero(strB(0)) > 23 Or StrNull2Zero(strB(1)) >= 60 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านระบุเวลาเปิด/ปิด วัน" & DisplayDayTH(DayCode) & "ไม่ถูกต้อง');", True)
                vs = True
                Exit Sub
            End If
            If StrNull2Zero(strE(0)) > 23 Or StrNull2Zero(strE(1)) >= 60 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านระบุเวลาเปิด/ปิด วัน" & DisplayDayTH(DayCode) & "ไม่ถูกต้อง');", True)
                vs = True
                Exit Sub
            End If

            StartTime = sBeginTime
            EndTime = sEndTime
        End If
        ctlL.LocationHour_Save(StrNull2Zero(hdLocationUID.Value), DayNo, DayCode, sOpenStatus, StartTime, EndTime, StrNull2Zero(Request.Cookies("UserID").Value))
    End Sub
End Class