Imports System.Threading

Public Class Form2
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Opacity > 0.6 Then

            Timer1.Enabled = False
            Form1.Visible = True
            Me.Hide()
        Else
            Me.Opacity = Me.Opacity + 0.01
        End If
    End Sub
    Public Sub S()
        Dim t As Thread '定义全局线程变量
        t = New Thread(AddressOf SC) '创建线程，使它指向test过程，注意该过程不能带有参数
        t.Start() '启动线程

    End Sub
    Public Sub SC()

    End Sub
    Private Sub SkinLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Form1.Show()
        Form1.Visible = False
        Form1.Visible = False
        Form1.Visible = False

    End Sub
End Class