Class Main
    Dim WoWpath As String
    Dim over_config As Boolean
    Dim mod_dl As String



    Private Sub btn_settings_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_settings.Click
        My.Windows.options.Show()
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_update.Click

    End Sub



    Private Sub Main_Initialized(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Initialized
        'Populate Variables
        WoWpath = My.Settings.WoWPath



        'Update Lables






    End Sub



End Class
