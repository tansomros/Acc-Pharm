Public Class ResultPage
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        pnBlue.Visible = False
        pnWarning.Visible = False
        Select Case Request("p")
            Case "request"
                pnBlue.Visible = True
                If Request("t") = "cancel" Then
                    lblResult.Text = "ยกเลิกคำขอเรียบร้อยแล้ว"
                ElseIf Request("t") = "del" Then
                    lblResult.Text = "ลบคำขอเรียบร้อยแล้ว"
                ElseIf Request("t") = "alive" Then
                    lblResult.Text = "ไม่สามารถยื่นคำขอใหม่ได้ เนื่องจากท่านยังมีคำขอที่ยังดำเนินการไม่สิ้นสุดค้างอยู่"
                End If
            Case "NotAllow"
                pnWarning.Visible = True
                lblWarning.Text = "ปี " & Request("y") & " ท่านไม่มีสิทธิ์ประเมิน"
            Case Else
                pnWarning.Visible = True
                lblWarning.Text = "Under Construction"
                hlkBack.Visible = False
        End Select
    End Sub
End Class