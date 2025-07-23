Imports BigLion
Public Class PrivacyPolicy
    Inherits Page
    Dim ctlU As New UserController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("CPAQA")) Then
        '    Response.Redirect("Default.aspx")
        'End If
        If Not IsPostBack Then
            If Request("p") = "reg" Then
                'Response.Redirect("RegisterNew.aspx")
            Else
                If ctlU.User_CheckPolicyAccept2(StrNull2Zero(Request.Cookies("userid").Value)) = "Y" Then
                    If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <= 5 Then
                        Response.Redirect("Dashboard.aspx?m=h")
                    Else
                        Response.Redirect("Home.aspx?m=h")
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        If chkAllow.Checked = False Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'Warning!','กรุณาเลือก Checkbox เพื่อแสดงความยินยอมให้ สรร. ในการเก็บรวบรวม ใช้ เปิดเผย หรือ สำเนาข้อมูลส่วนบุคคล ก่อน.');", True)
            Exit Sub
        End If

        If Request("p") = "reg" Then
            Response.Redirect("RegisterNew.aspx")
        Else
            ctlU.User_AcceptPolicy2(StrNull2Zero(Request.Cookies("userid").Value))
            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <= 5 Then
                Response.Redirect("Dashboard.aspx?m=h")
            Else
                Response.Redirect("Home.aspx?m=h")
            End If

        End If
    End Sub

End Class