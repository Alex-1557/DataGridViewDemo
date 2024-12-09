Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Public Module Startup

    <DllImport("user32.dll")>
    Private Function SetProcessDPIAware() As Boolean
    End Function
    Public Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(True)
        Application.Run(New Global.WindowsTstApp1.StartForm())
    End Sub

End Module
