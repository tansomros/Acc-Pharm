Public Class RegisterComplete
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lblUsername.Text = Request("u")
        lblPassword.Text = Request("p")
    End Sub
End Class