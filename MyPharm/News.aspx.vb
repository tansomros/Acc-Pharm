Imports BigLion
Public Class News
    Inherits Page
    Dim ctlN As New NewsController
    Public dtNew As New DataTable
    Dim pds As New PagedDataSource
    Dim PageCount As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        LoadNews()
    End Sub
    Private Sub LoadNews()
        If CurrentPage = 0 Then
            CurrentPage = 1
        End If

        PageCount = ctlN.News_GetPageCountBySearch("NEWS", "1", txtFind.Text)
        dtNew = ctlN.News_GetSearch("NEWS", "1", txtFind.Text, CurrentPage)


        pds.DataSource = dtNew.DefaultView
        pds.AllowPaging = True
        pds.PageSize = 12
        pds.CurrentPageIndex = CurrentPage

        If PageCount <= 1 Then
            lnkbtnNext.Visible = False
            lnkbtnPrevious.Visible = False
            dlPaging.Visible = False
        Else
            lnkbtnNext.Visible = True
            lnkbtnPrevious.Visible = True
            dlPaging.Visible = True
            If CurrentPage = 1 Then
                lnkbtnPrevious.Visible = False
            End If
            If CurrentPage = PageCount Then
                lnkbtnNext.Visible = False
            End If
            doPaging()
        End If
    End Sub

    Public Property CurrentPage() As Integer
        Get
            If Me.ViewState("CurrentPage") Is Nothing Then
                Return 1
            Else
                Return Convert.ToInt16(Me.ViewState("CurrentPage").ToString())
            End If
        End Get
        Set(value As Integer)
            Me.ViewState("CurrentPage") = value
        End Set
    End Property

    Private Sub doPaging()
        Dim dt As New DataTable()
        dt.Columns.Add("PageIndex")
        dt.Columns.Add("PageText")
        For i As Integer = 0 To PageCount - 1
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i
            dr(1) = i + 1
            dt.Rows.Add(dr)
        Next
        dlPaging.DataSource = dt
        dlPaging.DataBind()
    End Sub

    Protected Sub lnkbtnPrevious_Click(sender As Object, e As System.EventArgs) Handles lnkbtnPrevious.Click
        CurrentPage -= 1
        LoadNews()
    End Sub

    Protected Sub lnkbtnNext_Click(sender As Object, e As System.EventArgs) Handles lnkbtnNext.Click
        CurrentPage += 1
        LoadNews()
    End Sub

    Protected Sub dlPaging_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlPaging.ItemDataBound
        Dim lnkbtnPage As LinkButton = DirectCast(e.Item.FindControl("lnkbtnPaging"), LinkButton)
        If lnkbtnPage.CommandArgument.ToString() = CurrentPage.ToString() Then
            lnkbtnPage.Enabled = False
            lnkbtnPage.Font.Bold = True
        End If
    End Sub

    Protected Sub dlPaging_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlPaging.ItemCommand
        If e.CommandName.Equals("lnkbtnPaging") Then
            CurrentPage = Convert.ToInt16(e.CommandArgument.ToString())

            LoadNews()
        End If

    End Sub

    Protected Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        CurrentPage = 1
        LoadNews()
    End Sub

End Class