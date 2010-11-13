Partial Public Class options
    Dim WoWpath As String
    Dim over_config As Boolean
    Dim mod_dl As String

    Private Sub options_Initialized(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Initialized
        txtWoW.Text = My.Settings.WoWPath
        txtDL.Text = My.Settings.mod_dl
        chk.IsChecked = My.Settings.over_config
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_save.Click
        My.Settings.WoWPath = txtWoW.Text
        My.Settings.mod_dl = txtDL.Text
        My.Settings.over_config = chk.IsChecked
    End Sub

    Private Sub btn_cancel_click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

End Class
