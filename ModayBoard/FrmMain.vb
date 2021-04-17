Public Class FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim k As New MondayAPI
        MsgBox(k.QueryMondayApiV2("{""query"": ""{boards(ids:  1216030866) {id name}}\""""").Result)
    End Sub
End Class
