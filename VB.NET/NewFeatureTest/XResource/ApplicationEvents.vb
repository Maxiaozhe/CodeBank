Imports System.Globalization

Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。 
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication
        Private _IsCultureChanged As Boolean = False
        Public Shadows Sub ChangeUICulture(ByVal cultureName As String)
            My.Settings.CurrentLanguage = cultureName
            _IsCultureChanged = True
            System.Windows.Forms.Application.Exit()
        End Sub

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            If _IsCultureChanged Then
                _IsCultureChanged = False
                Process.Start(Reflection.Assembly.GetExecutingAssembly().CodeBase)
            End If
        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(My.Settings.CurrentLanguage)
        End Sub

    End Class

End Namespace

