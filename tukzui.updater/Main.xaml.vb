Imports Ionic.Zip
Imports System.IO
Imports System.Collections
Imports System.Net



Class Main
    Dim WoWpath As String
    Dim over_config As Boolean
    Dim mod_dl As String



    Private Sub btn_settings_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_settings.Click
        My.Windows.options.Show()
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btn_update.Click
        Download()
    End Sub



    Private Sub Main_Initialized(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Initialized
        'Populate Variables Phase


        'Update Lables Phase
        'insert lable code here



    End Sub

    Public Sub Download()
        'Local Variables
        Dim Backup As Boolean
        Dim wc As New WebClient
        Dim Extracted As String
        Dim extfolder As String
        WoWpath = My.Settings.WoWPath & "\Interface\AddOns"
        mod_dl = My.Settings.mod_dl
        over_config = My.Settings.over_config


        'Save Config
        If File.Exists(WoWpath & "\Tukui\config\config.lua") = True And My.Settings.over_config = False Then
            File.Copy(WoWpath & "\Tukui\config\config.lua", "config.lua", True)
            Backup = True
        Else
            Backup = False
        End If

        'Download update
        wc.DownloadFile(My.Settings.mod_dl, "update.zip")

        'Clean Up old installation
        If IO.Directory.Exists(WoWpath & "\Tukui") Then
            Directory.Delete(WoWpath & "\Tukui", True)
        End If
        If IO.Directory.Exists(WoWpath & "\Tukui_dps_layout") Then
            Directory.Delete(WoWpath & "\Tukui_dps_layout", True)
        End If
        If IO.Directory.Exists(WoWpath & "\Tukui_heal_layout") Then
            Directory.Delete(WoWpath & "\Tukui_heal_layout", True)
        End If

        'Unzip new one
        Using Zip1 As ZipFile = ZipFile.Read("update.zip")
            Dim e As ZipEntry
            For Each e In Zip1
                e.Extract(WoWpath, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using

        Extracted = Directory.GetDirectories(WoWpath, "tukz-tukui-*")(0)
        extfolder = Extracted
        Directory.Move(extfolder & "\Tukui", WoWpath & "\Tukui")
        Directory.Move(extfolder & "\Tukui_heal_layout", WoWpath & "\Tukui_heal_layout")
        Directory.Move(extfolder & "\Tukui_dps_layout", WoWpath & "\Tukui_dps_layout")

        Directory.Delete(extfolder)
        'Move Config.lua back.
        If Backup = True Then
            File.Copy("config.lua", WoWpath & "\TukUI\config\config.lua", True)
        End If

        MsgBox("Update finished!", MsgBoxStyle.OkOnly, "TukUI Updater finished!")

    End Sub
End Class
