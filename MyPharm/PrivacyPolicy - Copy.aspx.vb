
Public Class PrivacyPolicy
    Inherits Page
    Dim ctlU As New UserController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            If ctlU.User_CheckPolicyAccept(StrNull2Zero(Request.Cookies("userid").Value)) = "Y" Then
                Response.Redirect("Home")
            End If
        End If
    End Sub

    Protected Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        If chkAllow.Checked = False Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'Warning!','กรุณาเลือก Checkbox เพื่อแสดงความยินยอมให้ สรร. ในการเก็บรวบรวม ใช้ เปิดเผย หรือ สำเนาข้อมูลส่วนบุคคล ก่อน.');", True)
            Exit Sub
        End If
        ctlU.User_AcceptPolicy(StrNull2Zero(Request.Cookies("userid").Value))
        Response.Redirect("Home")
    End Sub

End Class