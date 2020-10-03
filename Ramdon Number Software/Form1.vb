Imports System.Threading
Imports System.IO
Imports System.ComponentModel
Imports System.Management
Public Class Form1
    Public Declare Function PlaySound Lib "winmm.dll" (ByVal lpszSoundName As String, ByVal hModule As Integer, ByVal dwFlags As Integer) As Integer
    Const SND_FILENAME As Integer = &H20000 ' 文件模式
    Const SND_ALIAS As Integer = &H10000    '自己查查
    Const SND_SYNC As Integer = &H0  '同步
    Const SND_ASYNC As Integer = &H1  '异步
    Const SND_LOOP As Integer = &H8  '循环
    Private oldx, oldy As Int16
    Dim KNM As Integer
    Public X, Y As Integer
    Private Sub ListView1_DragEnter(sender As Object, e As DragEventArgs) Handles ListView1.DragEnter
        If Timer1.Enabled = True Or Timer2.Enabled = True Then
            MsgBox("抽取模块正在运行，请等待停止后重试。", vbExclamation, "错误")
        Else
            ListView1.Items.Clear()
            Beep()
            Dim PT As String
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim files As String()
                Try
                    files = CType(e.Data.GetData(DataFormats.FileDrop), String())
                    PT = files(files.Length - 1)
                    Try
                        My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/HistorialDataBase.json", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)

                    Catch ex As Exception

                    End Try
                    System.IO.File.Copy(PT, Application.StartupPath + "/HistorialDataBase.json")
                    Dim filecontents As String
                    filecontents = My.Computer.FileSystem.ReadAllText(PT, System.Text.Encoding.Default)
                    TextBox2.Text = filecontents
                    Dim s() As String
                    s = Split(TextBox2.Text, vbCrLf)
                    For i = 0 To UBound(s)
                        Dim item As New ListViewItem
                        item = ListView1.Items.Add(Mid（s(i), 1, 4）) '添加第一条，第一列数据
                        item.SubItems.Add(Mid（s(i), 6, Len（s(i)） - 5）)
                        'ListBox1.Items.Add(s(i))
                    Next i
                    NoticeSound()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Return
                End Try
            End If
        End If
        CountListAmount()
    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim a As Integer
        Dim r As New Random
        a = r.Next(0, Val(ListView1.Items.Count))
        Label9.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        a = r.Next(0, Val(ListView1.Items.Count))
        Label8.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        a = r.Next(0, Val(ListView1.Items.Count))
        Label7.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        a = r.Next(0, Val(ListView1.Items.Count))
        Label6.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        a = r.Next(0, Val(ListView1.Items.Count))
        Label5.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        a = r.Next(0, Val(ListView1.Items.Count))
        Label3.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        a = r.Next(0, Val(ListView1.Items.Count))
        Label2.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text

        '----------------------------------------------------------------------------------------------------

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Timer1.Enabled = True Or Timer2.Enabled = True Then
            MsgBox("抽取模块正在运行，请等待停止后重试。", vbExclamation, "错误")
        Else
            ListView1.Items.Clear()
            Beep()
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        NoticeSound()

        If Label9.ForeColor = Color.White Then
            Label9.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label9.Text, 1, 4） & "  姓名:" & Mid（Label9.Text, 6, Len（Label9.Text） - 5）, False)
            Exit Sub
        End If
        If Label8.ForeColor = Color.White Then
            Label8.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label8.Text, 1, 4） & "  姓名:" & Mid（Label8.Text, 6, Len（Label8.Text） - 5）, False)
            Exit Sub
        End If
        If Label7.ForeColor = Color.White Then
            Label7.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label7.Text, 1, 4） & "  姓名:" & Mid（Label7.Text, 6, Len（Label7.Text） - 5）, False)
            Exit Sub
        End If
        If Label6.ForeColor = Color.White Then
            Label6.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label6.Text, 1, 4） & "  姓名:" & Mid（Label6.Text, 6, Len（Label6.Text） - 5）, False)
            Exit Sub
        End If
        If Label5.ForeColor = Color.White Then
            Label5.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label5.Text, 1, 4） & "  姓名:" & Mid（Label5.Text, 6, Len（Label5.Text） - 5）, False)
            Exit Sub
        End If
        If Label3.ForeColor = Color.White Then
            Label3.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label3.Text, 1, 4） & "  姓名:" & Mid（Label3.Text, 6, Len（Label3.Text） - 5）, False)
            Exit Sub
        End If
        If Label2.ForeColor = Color.White Then
            Label2.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label2.Text, 1, 4） & "  姓名:" & Mid（Label2.Text, 6, Len（Label2.Text） - 5）, False)
            Exit Sub
        End If




        '-------------------------------------------------------------------------------------------------------------------------
        SelectAmount(Int(SkinButton4.Text))
        '-----------------------------------------------------------------------------------------------------------------------------------
        SkinButton1.Enabled = True
        SkinButton5.Enabled = True
        SkinButton6.Enabled = True
        Timer4.Enabled = True

        NumericUpDown1.Enabled = True

        Label4.Visible = False
        If ListBox1.Items.Item(KNM) = "<time>" Or ListBox1.Items.Item(KNM) = "<logo>" Then
            If ListBox1.Items.Item(KNM) = "<time>" Then
                Label4.Text = "Time: " & Format(DateTime.Now, "yyyy-MM-dd hh:dd")
            End If
            If ListBox1.Items.Item(KNM) = "<logo>" Then
                Label4.Text = "Random Call (ES2)"
            End If
        Else
            Label4.Text = ListBox1.Items.Item(KNM)
        End If
        If KNM = ListBox1.Items.Count - 1 Then
            KNM = 0
        Else
            KNM = KNM + 1
        End If
        Delaration()
        Label27.Hide()
        Label27.TextAlign = ContentAlignment.MiddleLeft
        Label27.Text = "Random Lottery"
        Animator.Show(Label27)
        Timer3.Enabled = False
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value = 1 Then
            Label8.ForeColor = Color.DarkGray
            Label7.ForeColor = Color.DarkGray
            Label6.ForeColor = Color.White
            Label5.ForeColor = Color.DarkGray
            Label3.ForeColor = Color.DarkGray

        End If
        If NumericUpDown1.Value = 2 Then
            Label8.ForeColor = Color.DarkGray
            Label7.ForeColor = Color.White
            Label6.ForeColor = Color.DarkGray
            Label5.ForeColor = Color.White
            Label3.ForeColor = Color.DarkGray
        End If
        If NumericUpDown1.Value = 3 Then
            Label8.ForeColor = Color.DarkGray
            Label7.ForeColor = Color.White
            Label6.ForeColor = Color.White
            Label5.ForeColor = Color.White
            Label3.ForeColor = Color.DarkGray
        End If
        If NumericUpDown1.Value = 4 Then
            Label8.ForeColor = Color.White
            Label7.ForeColor = Color.White
            Label6.ForeColor = Color.DarkGray
            Label5.ForeColor = Color.White
            Label3.ForeColor = Color.White
        End If
        If NumericUpDown1.Value = 5 Then
            Label8.ForeColor = Color.White
            Label7.ForeColor = Color.White
            Label6.ForeColor = Color.White
            Label5.ForeColor = Color.White
            Label3.ForeColor = Color.White
        End If
    End Sub

    Private Sub SkinGroupBox2_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

        Label4.Visible = False
        If ListBox1.Items.Item(KNM) = "<time>" Or ListBox1.Items.Item(KNM) = "<logo>" Then
            If ListBox1.Items.Item(KNM) = "<time>" Then
                Label4.Text = "Time: " & Format(DateTime.Now, "yyyy-MM-dd hh:dd")
            End If
            If ListBox1.Items.Item(KNM) = "<logo>" Then
                Label4.Text = "© 2018-2020 Thunder Software Corporation. All Rights Reserved."
            End If
        Else
            Label4.Text = ListBox1.Items.Item(KNM)
        End If

        If KNM = ListBox1.Items.Count - 1 Then
            KNM = 0
        Else
            KNM = KNM + 1
        End If


        Animator.Show(Label4)
    End Sub
    Public Sub sd()
        Threading.Thread.Sleep(500)
        SkinTabControl1.SelectedTab = SkinTabPage1
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Dir(Application.StartupPath + "/EDB.lock") <> "" Then '判断是否存在
            EnableDoubleBuffering()
        Else
            Label30.Text = "软件已经开源" & vbCrLf & "详情请访问Github搜索RandomLottery"
        End If

        If Dir(Application.StartupPath + "/DisabledAnimation.lock") <> "" Then '判断是否存在
            SkinTabControl1.AnimationStart = False
        Else
            SkinTabControl1.AnimationStart = True
        End If
        SkinTabControl1.AnimatorType = CCWin.SkinControl.AnimationType.Transparent

        Threading.Thread.Sleep(1000)
        KNM = 0
        Call sd()
        Release_Resource()
        If Dir(Application.StartupPath + "/HistorialDataBase.json") <> "" Then '判断是否存在
            Try
                Dim filecontents As String
                filecontents = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "/HistorialDataBase.json", System.Text.Encoding.Default)
                TextBox2.Clear()
                TextBox2.Text = filecontents
                Dim s() As String
                s = Split(TextBox2.Text, vbCrLf)
                ListView1.Items.Clear()
                For i = 0 To UBound(s)
                    Dim item As New ListViewItem
                    If s(i) = "" Then
                    Else
                        item = ListView1.Items.Add(Mid（s(i), 1, 4）) '添加第一条，第一列数据
                        item.SubItems.Add(Mid（s(i), 6, Len（s(i)） - 5）)
                        'ListBox1.Items.Add(s(i))
                    End If
                Next i
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try
        End If
        CountListAmount()

        Try
            If My.Computer.FileSystem.FileExists(AppDomain.CurrentDomain.SetupInformation.ApplicationBase & "BackGround.png") Then
                Me.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.SetupInformation.ApplicationBase & "BackGround.png")
            End If
        Catch ex As Exception

        End Try '

    End Sub

    Private Sub SkinButton2_Click(sender As Object, e As EventArgs)
        If SkinTextBox1.Text = "" Then
            MsgBox("空白公告无效，请输入公告", vbExclamation, "错误")
        Else
            ListBox1.Items.Add(SkinTextBox1.Text)
        End If

    End Sub

    Private Sub SkinButton3_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        If ListBox1.Items.Item(ListBox1.SelectedItem) = "<logo>" Or ListBox1.Items.Item(ListBox1.SelectedItem) = "<time>" Then
            MsgBox("系统公告，不能删除", vbExclamation, "错误")
        Else
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        End If

    End Sub
    Private Sub NumericUpDown4_ValueChanged_1(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged
        Timer4.Interval = NumericUpDown4.Value * 1000
    End Sub

    Private Sub NumericUpDown3_ValueChanged_1(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        Timer3.Interval = NumericUpDown3.Value * 1000
    End Sub

    Private Sub NumericUpDown5_ValueChanged_1(sender As Object, e As EventArgs) Handles NumericUpDown5.ValueChanged
        Timer1.Interval = NumericUpDown5.Value * 1000
    End Sub

    Private Sub NumericUpDown2_ValueChanged_1(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        Timer2.Interval = NumericUpDown2.Value
    End Sub



    Private Sub SkinGroupBox1_Enter(sender As Object, e As EventArgs) Handles SkinGroupBox1.Enter

    End Sub

    Private Sub SkinButton1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub SkinTabPage2_Click(sender As Object, e As EventArgs) Handles SkinTabPage2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub SkinButton1_Click_2(sender As Object, e As EventArgs) Handles SkinButton1.Click
        If Val(ListView1.Items.Count) > 6 Then
            Timer1.Enabled = True
            Timer2.Enabled = True
            Timer4.Enabled = False
            Label4.Visible = False
            Label4.Text = "In Processing..."
            displaynotice("正在摇号中，请勿操作软件", False)
            SkinButton1.Enabled = False
            SkinButton5.Enabled = False
            SkinButton6.Enabled = False
            NumericUpDown1.Enabled = False
            NoticeSound()
            Animator.Show(Label4)
        Else
            MsgBox("未识别到名单或者名单人数不足7人无法开始，请检查重试！", vbExclamation, "错误")
        End If
    End Sub

    Private Sub SkinTabPage3_Click(sender As Object, e As EventArgs) Handles SkinTabPage3.Click

    End Sub


    Private Sub SkinButton11_Click(sender As Object, e As EventArgs) Handles SkinButton11.Click
        If Timer1.Enabled = True Or Timer2.Enabled = True Then
            MsgBox("抽取模块正在运行，请等待停止后重试。", vbExclamation, "错误")
        Else
            ListView1.Items.Clear()
            Try
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/HistorialDataBase.json", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)

            Catch ex As Exception

            End Try
            NoticeSound()
        End If
    End Sub

    Private Sub SkinTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SkinTabControl1.SelectedIndexChanged

    End Sub
    Public Sub Release_Resource()
        Dim b() As Byte = My.Resources.Tips
        Dim s As IO.Stream = File.Create(Application.StartupPath & "/Tip.wav")   '设定文件创建位置
        s.Write(b, 0, b.Length)    '文件写入
        s.Close()     '关闭文件
    End Sub






    Public Sub NoticeSound()
        Dim nologin As String = Application.StartupPath & "/Tip.wav"


        PlaySound(nologin, 0, SND_ASYNC)

    End Sub

    Private Sub SkinButton9_Click(sender As Object, e As EventArgs)
        NoticeSound()
    End Sub

    Private Sub SkinButton8_Click(sender As Object, e As EventArgs)
        NoticeSound()
    End Sub

    Private Sub SkinButton12_Click(sender As Object, e As EventArgs)
        NoticeSound()
    End Sub
    Public Sub checksample()
        Dim files As String()
        Try
            Dim PT As String
            System.IO.File.Copy(PT, Application.StartupPath + "/Rules.json")
            Dim filecontents As String
            filecontents = My.Computer.FileSystem.ReadAllText(PT, System.Text.Encoding.Default)

            Dim s() As String
            s = Split(filecontents, vbCrLf)
            For i = 0 To UBound(s)

                If IsExistStr(s(i), s(i)) = True Then

                End If
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try
    End Sub
    Public Function IsExistStr(ByVal Str As String, ByVal Dst As String) As Boolean
        Dim Res As Boolean = False
        Dim n As Integer
        n = InStr(Str, Dst)
        If n >= 0 Then
            Res = True
        End If
        Return Res
    End Function
    Public Sub detectsign()
        'MsgBox("!")
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim s() As String
        Try
            Dim filecontents As String
            filecontents = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "/Rules.json", System.Text.Encoding.Default)


            s = Split(filecontents, vbCrLf)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try

        Dim ProtectString As String = "看你马私人信息" '忽略信息
        Timer2.Enabled = False
        Dim a As Integer
        Dim r As New Random
        Do
            a = r.Next(0, Val(ListView1.Items.Count))
            '------------------------------------------------------------------------后门程序
            For i = 0 To UBound(s)
                If IsExistStr(s(i), ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text) = True Then
                    If s(i).Contains("<disappear=7>") Or s(i).Contains("<disappear=6>") Or s(i).Contains("<disappear=all>") And Label9.ForeColor = Color.White Then
                        a = r.Next(0, Val(ListView1.Items.Count))
                        detectsign()
                    End If

                End If
            Next i
            '------------------------------------------------------------------------后门程序

            Label9.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        Loop Until ProtectString <> Label9.Text
        Do
            a = r.Next(0, Val(ListView1.Items.Count))
            '------------------------------------------------------------------------后门程序
            For i = 0 To UBound(s)
                If IsExistStr(s(i), ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text) = True Then
                    If s(i).Contains("<disappear=7>") Or s(i).Contains("<disappear=6>") Or s(i).Contains("<disappear=4>") Or s(i).Contains("<disappear=5>") Or s(i).Contains("<disappear=all>") And Label8.ForeColor = Color.White Then
                        a = r.Next(0, Val(ListView1.Items.Count))
                        detectsign()
                    End If
                End If
            Next i
            '------------------------------------------------------------------------后门程序
            Label8.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        Loop Until Label9.Text <> Label8.Text And ProtectString <> Label8.Text
        Do
            a = r.Next(0, Val(ListView1.Items.Count))
            '------------------------------------------------------------------------后门程序
            For i = 0 To UBound(s)
                If IsExistStr(s(i), ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text) = True Then
                    If s(i).Contains("<disappear=7>") Or s(i).Contains("<disappear=6>") Or s(i).Contains("<disappear=4>") Or s(i).Contains("<disappear=2>") Or s(i).Contains("<disappear=3>") Or s(i).Contains("<disappear=5>") Or s(i).Contains("<disappear=all>") And Label7.ForeColor = Color.White Then
                        a = r.Next(0, Val(ListView1.Items.Count))
                        detectsign()
                    End If
                End If
            Next i
            '------------------------------------------------------------------------后门程序
            Label7.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        Loop Until Label9.Text <> Label7.Text And Label8.Text <> Label7.Text And ProtectString <> Label7.Text
        Do
            a = r.Next(0, Val(ListView1.Items.Count))
            '------------------------------------------------------------------------后门程序
            For i = 0 To UBound(s)
                If IsExistStr(s(i), ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text) = True Then
                    If s(i).Contains("<disappear=7>") Or s(i).Contains("<disappear=6>") Or s(i).Contains("<disappear=4>") Or s(i).Contains("<disappear=2>") Or s(i).Contains("<disappear=3>") Or s(i).Contains("<disappear=1>") Or s(i).Contains("<disappear=5>") Or s(i).Contains("<disappear=all>") And Label6.ForeColor = Color.White Then
                        a = r.Next(0, Val(ListView1.Items.Count))
                        detectsign()
                    End If
                End If
            Next i
            '------------------------------------------------------------------------后门程序
            Label6.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        Loop Until Label9.Text <> Label6.Text And Label8.Text <> Label6.Text And Label7.Text <> Label6.Text And ProtectString <> Label6.Text
        Do
            a = r.Next(0, Val(ListView1.Items.Count))
            '------------------------------------------------------------------------后门程序
            For i = 0 To UBound(s)
                If IsExistStr(s(i), ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text) = True Then
                    If s(i).Contains("<disappear=7>") Or s(i).Contains("<disappear=6>") Or s(i).Contains("<disappear=4>") Or s(i).Contains("<disappear=2>") Or s(i).Contains("<disappear=3>") Or s(i).Contains("<disappear=5>") Or s(i).Contains("<disappear=all>") And Label5.ForeColor = Color.White Then
                        a = r.Next(0, Val(ListView1.Items.Count))
                        detectsign()
                    End If
                End If
            Next i
            '------------------------------------------------------------------------后门程序
            Label5.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        Loop Until Label9.Text <> Label5.Text And Label8.Text <> Label5.Text And Label7.Text <> Label5.Text And Label6.Text <> Label5.Text And ProtectString <> Label5.Text
        Do
            a = r.Next(0, Val(ListView1.Items.Count))
            '------------------------------------------------------------------------后门程序
            For i = 0 To UBound(s)
                If IsExistStr(s(i), ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text) = True Then
                    If s(i).Contains("<disappear=7>") Or s(i).Contains("<disappear=6>") Or s(i).Contains("<disappear=4>") Or s(i).Contains("<disappear=5>") Or s(i).Contains("<disappear=all>") And Label3.ForeColor = Color.White Then
                        a = r.Next(0, Val(ListView1.Items.Count))
                        detectsign()
                    End If
                End If
            Next i
            '------------------------------------------------------------------------后门程序
            Label3.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        Loop Until Label9.Text <> Label3.Text And Label8.Text <> Label3.Text And Label7.Text <> Label3.Text And Label6.Text <> Label3.Text And Label5.Text <> Label3.Text And ProtectString <> Label3.Text
        Do
            a = r.Next(0, Val(ListView1.Items.Count))
            '------------------------------------------------------------------------后门程序
            For i = 0 To UBound(s)
                If IsExistStr(s(i), ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text) = True Then
                    If s(i).Contains("<disappear=7>") Or s(i).Contains("<disappear=6>") Or s(i).Contains("<disappear=all>") And Label2.ForeColor = Color.White Then
                        a = r.Next(0, Val(ListView1.Items.Count))
                        detectsign()
                    End If
                End If
            Next i
            '------------------------------------------------------------------------后门程序
            Label2.Text = ListView1.Items(a).SubItems(0).Text & "-" & ListView1.Items(a).SubItems(1).Text
        Loop Until Label9.Text <> Label2.Text And Label8.Text <> Label2.Text And Label7.Text <> Label2.Text And Label6.Text <> Label2.Text And Label5.Text <> Label2.Text And Label3.Text <> Label2.Text And ProtectString <> Label2.Text

        Timer3.Enabled = True
        Timer1.Enabled = False
        NoticeSound()

        If Label9.ForeColor = Color.White Then
            Label9.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label9.Text, 1, 4） & "  姓名:" & Mid（Label9.Text, 6, Len（Label9.Text） - 5）, False)
            Exit Sub
        End If
        If Label8.ForeColor = Color.White Then
            Label8.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label8.Text, 1, 4） & "  姓名:" & Mid（Label8.Text, 6, Len（Label8.Text） - 5）, False)
            Exit Sub
        End If
        If Label7.ForeColor = Color.White Then
            Label7.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label7.Text, 1, 4） & "  姓名:" & Mid（Label7.Text, 6, Len（Label7.Text） - 5）, False)
            Exit Sub
        End If
        If Label6.ForeColor = Color.White Then
            Label6.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label6.Text, 1, 4） & "  姓名:" & Mid（Label6.Text, 6, Len（Label6.Text） - 5）, False)
            Exit Sub
        End If
        If Label5.ForeColor = Color.White Then
            Label5.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label5.Text, 1, 4） & "  姓名:" & Mid（Label5.Text, 6, Len（Label5.Text） - 5）, False)
            Exit Sub
        End If
        If Label3.ForeColor = Color.White Then
            Label3.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label3.Text, 1, 4） & "  姓名:" & Mid（Label3.Text, 6, Len（Label3.Text） - 5）, False)
            Exit Sub
        End If
        If Label2.ForeColor = Color.White Then
            Label2.ForeColor = Color.DarkGray
            displaynotice("编号:" & Mid（Label2.Text, 1, 4） & "  姓名:" & Mid（Label2.Text, 6, Len（Label2.Text） - 5）, False)
            Exit Sub
        End If
    End Sub

    Private Sub SkinTabPage4_Click(sender As Object, e As EventArgs) Handles SkinTabPage4.Click

    End Sub

    Public Sub Read(ByVal Text As String)
        Ax.Ctlcontrols.stop()
        Ax.URL = "http://tts.baidu.com/text2audio?lan=zh&ie=UTF-8&spd=5&text=" & Text
        Ax.Ctlcontrols.play()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        End
    End Sub

    Private Sub SkinTabPage1_Click(sender As Object, e As EventArgs) Handles SkinTabPage1.Click

    End Sub

    Private Sub Label4_MouseMove(sender As Object, e As MouseEventArgs) Handles Label4.MouseMove
        If X = e.X And Y = e.Y Then Exit Sub
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Left = Me.Left + e.X - X
            Me.Top = Me.Top + e.Y - Y
        End If
    End Sub


    Public Sub Delaration()
        Label4.Text = "为确保软件随机性，许可源码检查，详情登陆官网下载"
    End Sub
    Private Sub Label4_MouseDown(sender As Object, e As MouseEventArgs) Handles Label4.MouseDown
        X = e.X : Y = e.Y
    End Sub
    Private Sub SkinButton5_Click(sender As Object, e As EventArgs) Handles SkinButton5.Click
        Dim SelectIndex As Integer = Int(SkinButton4.Text)
        If SelectIndex <= 1 Then
            NoticeSound()
        Else
            SelectIndex = SelectIndex - 1
            SelectAmount(SelectIndex)
            SkinButton4.Text = "0" & SelectIndex
        End If
    End Sub

    Private Sub SkinButton6_Click(sender As Object, e As EventArgs) Handles SkinButton6.Click
        Dim SelectIndex As Integer = Int(SkinButton4.Text)
        If SelectIndex >= 7 Then
            NoticeSound()
        Else
            SelectIndex = SelectIndex + 1
            SelectAmount(SelectIndex)
            SkinButton4.Text = "0" & SelectIndex
        End If
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        End
    End Sub

    Private Sub Label27_MouseDown(sender As Object, e As MouseEventArgs) Handles Label27.MouseDown
        X = e.X : Y = e.Y
    End Sub

    Private Sub Label27_MouseMove(sender As Object, e As MouseEventArgs) Handles Label27.MouseMove
        If X = e.X And Y = e.Y Then Exit Sub
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Left = Me.Left + e.X - X
            Me.Top = Me.Top + e.Y - Y
        End If
    End Sub
    '选择一次抽取的人数
    Public Sub SelectAmount(ByVal Amount As Integer)
        Select Case Amount
            Case 1
                Label9.ForeColor = Color.DarkGray
                Label8.ForeColor = Color.DarkGray
                Label7.ForeColor = Color.DarkGray
                Label6.ForeColor = Color.White
                Label5.ForeColor = Color.DarkGray
                Label3.ForeColor = Color.DarkGray
                Label2.ForeColor = Color.DarkGray
            Case 2
                Label9.ForeColor = Color.DarkGray
                Label8.ForeColor = Color.DarkGray
                Label7.ForeColor = Color.White
                Label6.ForeColor = Color.DarkGray
                Label5.ForeColor = Color.White
                Label3.ForeColor = Color.DarkGray
                Label2.ForeColor = Color.DarkGray
            Case 3
                Label9.ForeColor = Color.DarkGray
                Label8.ForeColor = Color.DarkGray
                Label7.ForeColor = Color.White
                Label6.ForeColor = Color.White
                Label5.ForeColor = Color.White
                Label3.ForeColor = Color.DarkGray
                Label2.ForeColor = Color.DarkGray
            Case 4
                Label9.ForeColor = Color.DarkGray
                Label8.ForeColor = Color.White
                Label7.ForeColor = Color.White
                Label6.ForeColor = Color.DarkGray
                Label5.ForeColor = Color.White
                Label3.ForeColor = Color.White
                Label2.ForeColor = Color.DarkGray
            Case 5
                Label9.ForeColor = Color.DarkGray
                Label8.ForeColor = Color.White
                Label7.ForeColor = Color.White
                Label6.ForeColor = Color.White
                Label5.ForeColor = Color.White
                Label3.ForeColor = Color.White
                Label2.ForeColor = Color.DarkGray
            Case 6
                Label9.ForeColor = Color.White
                Label8.ForeColor = Color.White
                Label7.ForeColor = Color.White
                Label6.ForeColor = Color.DarkGray
                Label5.ForeColor = Color.White
                Label3.ForeColor = Color.White
                Label2.ForeColor = Color.White
            Case 7
                Label9.ForeColor = Color.White
                Label8.ForeColor = Color.White
                Label7.ForeColor = Color.White
                Label6.ForeColor = Color.White
                Label5.ForeColor = Color.White
                Label3.ForeColor = Color.White
                Label2.ForeColor = Color.White
        End Select
    End Sub
    '标题栏
    Public Sub displaynotice(ByVal Message As String, ByVal EnabledBack As Boolean)
        Label27.Hide()
        Label27.TextAlign = ContentAlignment.MiddleCenter
        Label27.Text = Message
        Animator.Show(Label27)
        If EnabledBack = True Then
            Dim t As Thread
            t = New Thread(AddressOf displaynotice_1)
            t.Start()
        End If
    End Sub
    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        System.Diagnostics.Process.Start("https://github.com/sonaradar")
        NoticeSound()
    End Sub
    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click
        SkinTabControl1.SelectedIndex = 1
        NoticeSound()
    End Sub

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click
        SkinTabControl1.SelectedIndex = 1
        NoticeSound()
    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click
        SkinTabControl1.SelectedIndex = 1
        NoticeSound()
    End Sub

    Private Sub Label42_Click(sender As Object, e As EventArgs) Handles Label42.Click
        SkinTabControl1.SelectedIndex = 2
        NoticeSound()
    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label41.Click
        SkinTabControl1.SelectedIndex = 2
        NoticeSound()
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        SkinTabControl1.SelectedIndex = 2
        NoticeSound()
    End Sub

    Private Sub Label44_Click(sender As Object, e As EventArgs) Handles Label44.Click
        SkinTabControl1.SelectedIndex = 3
        NoticeSound()
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        SkinTabControl1.SelectedIndex = 3
        NoticeSound()
    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click
        SkinTabControl1.SelectedIndex = 3
        NoticeSound()
    End Sub


    '标题栏
    Public Sub displaynotice_1()

        Threading.Thread.Sleep(3000)
        Label27.Hide()
        Label27.TextAlign = ContentAlignment.MiddleLeft
        Label27.Text = "Random Lottery"
        Animator.Show(Label27)
    End Sub

    Private Sub SkinButton8_Click_1(sender As Object, e As EventArgs) Handles SkinButton8.Click
        If Dir(Application.StartupPath + "/Rules.json") <> "" Then '判断是否存在
        Else
            writein("[Sample]" & vbCrLf & "<String:1600-XXX><disappear=1><disappear=2><disappear=3><disappear=4><disappear=5><disappear=6><disappear=7><disappear=all><doubleprobability=true>", Application.StartupPath + "/Rules.json")
        End If
        Try
            Shell("notepad " + Application.StartupPath + "/Rules.json", AppWinStyle.NormalFocus)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CountListAmount()
        SkinButton7.Text = "共" & ListView1.Items.Count & "人已载入"
        Label36.Text = "共" & ListView1.Items.Count & "人被载入到软件"
    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs) Handles PictureBox19.Click
        SkinTabControl1.SelectedIndex = 1
        NoticeSound()
    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub

    Public Sub EnableDoubleBuffering()
        ' Set the value of the double-buffering style bits to true.
        Me.SetStyle(ControlStyles.DoubleBuffer _
          Or ControlStyles.UserPaint _
          Or ControlStyles.AllPaintingInWmPaint,
          True)
        Me.UpdateStyles()
    End Sub

    Private Sub PictureBox20_Click(sender As Object, e As EventArgs) Handles PictureBox20.Click

    End Sub

    Private Sub SkinButton9_Click_1(sender As Object, e As EventArgs) Handles SkinButton9.Click

        NoticeSound()
    End Sub

    Private Sub SkinButton10_Click(sender As Object, e As EventArgs) Handles SkinButton10.Click
        MsgBox("数据库操作须知" & vbCrLf & "数据库格式为：4位编号-姓名" & vbCrLf & "导入数据时请勿插入空格行，否则会读取错误" & vbCrLf & "批量导入时可使用excel的替换功能更改为上述格式后复制文本到数据库"， vbExclamation, "数据库导入须知")
        If Dir(Application.StartupPath + "/HistorialDataBase.json") <> "" Then '判断是否存在
        Else
            writein("1600-XXX", Application.StartupPath + "/HistorialDataBase.json")
        End If
        Try
            Shell("notepad " + Application.StartupPath + "/HistorialDataBase.json", AppWinStyle.NormalFocus)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub writein(ByVal message As String, ByVal path As String)
        Try
            Dim MyStream As New System.IO.FileStream(path, System.IO.FileMode.Create)
            Dim MyWriter As New System.IO.StreamWriter(MyStream, System.Text.Encoding.Default)
            MyWriter.WriteLine(message)
            MyWriter.Flush()
            MyWriter.Close()
            MyStream.Close()
        Catch
        End Try
    End Sub

    Private Sub Panel8_Click(sender As Object, e As EventArgs) Handles Panel8.Click
        SkinTabControl1.SelectedIndex = 1
        NoticeSound()
    End Sub
End Class
