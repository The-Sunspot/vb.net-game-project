Public Class Form1
    '积分
    Dim scores As Integer = 0
    '步数
    Dim stepCount As Integer = 0
    '时间
    Dim time As Integer = 0
    '难度
    Dim difficulty As String = "easy"
    '图片
    Dim photo As Integer = 2
    'easy模式全局变量
    Dim PicxEasy(2, 2) As PictureBox '控件数组
    Dim PicEasy(8) As Image '原图片数组
    Dim HelpHashEasy(2, 2) As Integer '帮助
    Dim PicHashEasy(2, 2) As Integer '判断胜利
    'medium模式全局变量
    Dim PicxMedium(3, 3) As PictureBox
    Dim PicMedium(15) As Image
    Dim HelpHashMedium(3, 3) As Integer
    Dim PicHashMedium(3, 3) As Integer
    'hard模式全局变量
    Dim PicxHard(4, 4) As PictureBox
    Dim PicHard(24) As Image
    Dim HelpHashHard(4, 4) As Integer
    Dim PicHashHard(4, 4) As Integer
    '四方向遍历数组
    Dim _move(3, 1) As Integer


    '开始
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _move = {{1, 0}, {0, 1}, {-1, 0}, {0, -1}}
        Init()
        Clear()
        Start()
    End Sub
    '生成（辅助开始函数）
    Function DrawGame(high As Integer)
        Randomize()
        Dim total = (high + 1) ^ 2
        Dim i, j As Integer
        For i = 0 To high
            For j = 0 To high
                Dim cnt As Integer = i * (high + 1) + j
                If difficulty = "easy" Then
                    PicxEasy(i, j).BackgroundImage = PicEasy(cnt)
                    PicHashEasy(i, j) = cnt
                ElseIf difficulty = "medium" Then
                    PicxMedium(i, j).BackgroundImage = PicMedium(cnt)
                    PicHashMedium(i, j) = cnt
                Else
                    PicxHard(i, j).BackgroundImage = PicHard(cnt)
                    PicHashHard(i, j) = cnt
                End If
            Next
        Next
        If difficulty = "easy" Then
            PicxEasy(high, high).BackgroundImage = Nothing
        ElseIf difficulty = "medium" Then
            PicxMedium(high, high).BackgroundImage = Nothing
        Else
            PicxHard(high, high).BackgroundImage = Nothing
        End If
        For i = 0 To 1000
            Dim ra As Integer = Rnd() * 3
            PlayerKeyDown(ra)
        Next
    End Function

    '开始新一轮
    Function Start()
        Select Case photo
            Case 1
                PicEasy = {My.Resources.easy1.e1_1, My.Resources.easy1.e1_2, My.Resources.easy1.e1_3, My.Resources.easy1.e1_4, My.Resources.easy1.e1_5, My.Resources.easy1.e1_6, My.Resources.easy1.e1_7, My.Resources.easy1.e1_8, My.Resources.easy1.e1_9}
                PicMedium = {My.Resources.easy1.e1_1, My.Resources.easy1.e1_2, My.Resources.easy1.e1_3, My.Resources.easy1.e1_4, My.Resources.easy1.e1_5, My.Resources.easy1.e1_6, My.Resources.easy1.e1_7, My.Resources.easy1.e1_8, My.Resources.easy1.e1_9, My.Resources.medium1.m1_10, My.Resources.medium1.m1_11, My.Resources.medium1.m1_12, My.Resources.medium1.m1_13, My.Resources.medium1.m1_14, My.Resources.medium1.m1_15, My.Resources.medium1.m1_16}
                PicHard = {My.Resources.easy1.e1_1, My.Resources.easy1.e1_2, My.Resources.easy1.e1_3, My.Resources.easy1.e1_4, My.Resources.easy1.e1_5, My.Resources.easy1.e1_6, My.Resources.easy1.e1_7, My.Resources.easy1.e1_8, My.Resources.easy1.e1_9, My.Resources.medium1.m1_10, My.Resources.medium1.m1_11, My.Resources.medium1.m1_12, My.Resources.medium1.m1_13, My.Resources.medium1.m1_14, My.Resources.medium1.m1_15, My.Resources.medium1.m1_16, My.Resources.hard1.h1_17, My.Resources.hard1.h1_18, My.Resources.hard1.h1_19, My.Resources.hard1.h1_20, My.Resources.hard1.h1_21, My.Resources.hard1.h1_22, My.Resources.hard1.h1_23, My.Resources.hard1.h1_24, My.Resources.hard1.h1_25}
            Case 2
                PicEasy = {My.Resources.easy2.e2_1, My.Resources.easy2.e2_2, My.Resources.easy2.e2_3, My.Resources.easy2.e2_4, My.Resources.easy2.e2_5, My.Resources.easy2.e2_6, My.Resources.easy2.e2_7, My.Resources.easy2.e2_8, My.Resources.easy2.e2_9}
                PicMedium = {My.Resources.medium2.m2_1, My.Resources.medium2.m2_2, My.Resources.medium2.m2_3, My.Resources.medium2.m2_4, My.Resources.medium2.m2_5, My.Resources.medium2.m2_6, My.Resources.medium2.m2_7, My.Resources.medium2.m2_8, My.Resources.medium2.m2_9, My.Resources.medium2.m2_10, My.Resources.medium2.m2_11, My.Resources.medium2.m2_12, My.Resources.medium2.m2_13, My.Resources.medium2.m2_14, My.Resources.medium2.m2_15, My.Resources.medium2.m2_16}
                PicHard = {My.Resources.hard2.h2_1, My.Resources.hard2.h2_2, My.Resources.hard2.h2_3, My.Resources.hard2.h2_4, My.Resources.hard2.h2_5, My.Resources.hard2.h2_6, My.Resources.hard2.h2_7, My.Resources.hard2.h2_8, My.Resources.hard2.h2_9, My.Resources.hard2.h2_10, My.Resources.hard2.h2_11, My.Resources.hard2.h2_12, My.Resources.hard2.h2_13, My.Resources.hard2.h2_14, My.Resources.hard2.h2_15, My.Resources.hard2.h2_16, My.Resources.hard2.h2_17, My.Resources.hard2.h2_18, My.Resources.hard2.h2_19, My.Resources.hard2.h2_20, My.Resources.hard2.h2_21, My.Resources.hard2.h2_22, My.Resources.hard2.h2_23, My.Resources.hard2.h2_24, My.Resources.hard2.h2_25}
            Case 3
                PicEasy = {My.Resources.easy3.e3_1, My.Resources.easy3.e3_2, My.Resources.easy3.e3_3, My.Resources.easy3.e3_4, My.Resources.easy3.e3_5, My.Resources.easy3.e3_6, My.Resources.easy3.e3_7, My.Resources.easy3.e3_8, My.Resources.easy3.e3_9}
                PicMedium = {My.Resources.medium3.m3_1, My.Resources.medium3.m3_2, My.Resources.medium3.m3_3, My.Resources.medium3.m3_4, My.Resources.medium3.m3_5, My.Resources.medium3.m3_6, My.Resources.medium3.m3_7, My.Resources.medium3.m3_8, My.Resources.medium3.m3_9, My.Resources.medium3.m3_10, My.Resources.medium3.m3_11, My.Resources.medium3.m3_12, My.Resources.medium3.m3_13, My.Resources.medium3.m3_14, My.Resources.medium3.m3_15, My.Resources.medium3.m3_16}
                PicHard = {My.Resources.hard3.h3_1, My.Resources.hard3.h3_2, My.Resources.hard3.h3_3, My.Resources.hard3.h3_4, My.Resources.hard3.h3_5, My.Resources.hard3.h3_6, My.Resources.hard3.h3_7, My.Resources.hard3.h3_8, My.Resources.hard3.h3_9, My.Resources.hard3.h3_10, My.Resources.hard3.h3_11, My.Resources.hard3.h3_12, My.Resources.hard3.h3_13, My.Resources.hard3.h3_14, My.Resources.hard3.h3_15, My.Resources.hard3.h3_16, My.Resources.hard3.h3_17, My.Resources.hard3.h3_18, My.Resources.hard3.h3_19, My.Resources.hard3.h3_20, My.Resources.hard3.h3_21, My.Resources.hard3.h3_22, My.Resources.hard3.h3_23, My.Resources.hard3.h3_24, My.Resources.hard3.h3_25}
            Case 4
                PicEasy = {My.Resources.easy4.e4_1, My.Resources.easy4.e4_2, My.Resources.easy4.e4_3, My.Resources.easy4.e4_4, My.Resources.easy4.e4_5, My.Resources.easy4.e4_6, My.Resources.easy4.e4_7, My.Resources.easy4.e4_8, My.Resources.easy4.e4_9}
                PicMedium = {My.Resources.medium4.m4_1, My.Resources.medium4.m4_2, My.Resources.medium4.m4_3, My.Resources.medium4.m4_4, My.Resources.medium4.m4_5, My.Resources.medium4.m4_6, My.Resources.medium4.m4_7, My.Resources.medium4.m4_8, My.Resources.medium4.m4_9, My.Resources.medium4.m4_10, My.Resources.medium4.m4_11, My.Resources.medium4.m4_12, My.Resources.medium4.m4_13, My.Resources.medium4.m4_14, My.Resources.medium4.m4_15, My.Resources.medium4.m4_16}
                PicHard = {My.Resources.hard4.h4_1, My.Resources.hard4.h4_2, My.Resources.hard4.h4_3, My.Resources.hard4.h4_4, My.Resources.hard4.h4_5, My.Resources.hard4.h4_6, My.Resources.hard4.h4_7, My.Resources.hard4.h4_8, My.Resources.hard4.h4_9, My.Resources.hard4.h4_10, My.Resources.hard4.h4_11, My.Resources.hard4.h4_12, My.Resources.hard4.h4_13, My.Resources.hard4.h4_14, My.Resources.hard4.h4_15, My.Resources.hard4.h4_16, My.Resources.hard4.h4_17, My.Resources.hard4.h4_18, My.Resources.hard4.h4_19, My.Resources.hard4.h4_20, My.Resources.hard4.h4_21, My.Resources.hard4.h4_22, My.Resources.hard4.h4_23, My.Resources.hard4.h4_24, My.Resources.hard4.h4_25}
            Case 5
                PicEasy = {My.Resources.easy5.e5_1, My.Resources.easy5.e5_2, My.Resources.easy5.e5_3, My.Resources.easy5.e5_4, My.Resources.easy5.e5_5, My.Resources.easy5.e5_6, My.Resources.easy5.e5_7, My.Resources.easy5.e5_8, My.Resources.easy5.e5_9}
                PicMedium = {My.Resources.medium5.m5_1, My.Resources.medium5.m5_2, My.Resources.medium5.m5_3, My.Resources.medium5.m5_4, My.Resources.medium5.m5_5, My.Resources.medium5.m5_6, My.Resources.medium5.m5_7, My.Resources.medium5.m5_8, My.Resources.medium5.m5_9, My.Resources.medium5.m5_10, My.Resources.medium5.m5_11, My.Resources.medium5.m5_12, My.Resources.medium5.m5_13, My.Resources.medium5.m5_14, My.Resources.medium5.m5_15, My.Resources.medium5.m5_16}
                PicHard = {My.Resources.hard5.h5_1, My.Resources.hard5.h5_2, My.Resources.hard5.h5_3, My.Resources.hard5.h5_4, My.Resources.hard5.h5_5, My.Resources.hard5.h5_6, My.Resources.hard5.h5_7, My.Resources.hard5.h5_8, My.Resources.hard5.h5_9, My.Resources.hard5.h5_10, My.Resources.hard5.h5_11, My.Resources.hard5.h5_12, My.Resources.hard5.h5_13, My.Resources.hard5.h5_14, My.Resources.hard5.h5_15, My.Resources.hard5.h5_16, My.Resources.hard5.h5_17, My.Resources.hard5.h5_18, My.Resources.hard5.h5_19, My.Resources.hard5.h5_20, My.Resources.hard5.h5_21, My.Resources.hard5.h5_22, My.Resources.hard5.h5_23, My.Resources.hard5.h5_24, My.Resources.hard5.h5_25}
            Case 6
                PicEasy = {My.Resources.easy6.e6_1, My.Resources.easy6.e6_2, My.Resources.easy6.e6_3, My.Resources.easy6.e6_4, My.Resources.easy6.e6_5, My.Resources.easy6.e6_6, My.Resources.easy6.e6_7, My.Resources.easy6.e6_8, My.Resources.easy6.e6_9}
                PicMedium = {My.Resources.medium6.m6_1, My.Resources.medium6.m6_2, My.Resources.medium6.m6_3, My.Resources.medium6.m6_4, My.Resources.medium6.m6_5, My.Resources.medium6.m6_6, My.Resources.medium6.m6_7, My.Resources.medium6.m6_8, My.Resources.medium6.m6_9, My.Resources.medium6.m6_10, My.Resources.medium6.m6_11, My.Resources.medium6.m6_12, My.Resources.medium6.m6_13, My.Resources.medium6.m6_14, My.Resources.medium6.m6_15, My.Resources.medium6.m6_16}
                PicHard = {My.Resources.hard6.h6_1, My.Resources.hard6.h6_2, My.Resources.hard6.h6_3, My.Resources.hard6.h6_4, My.Resources.hard6.h6_5, My.Resources.hard6.h6_6, My.Resources.hard6.h6_7, My.Resources.hard6.h6_8, My.Resources.hard6.h6_9, My.Resources.hard6.h6_10, My.Resources.hard6.h6_11, My.Resources.hard6.h6_12, My.Resources.hard6.h6_13, My.Resources.hard6.h6_14, My.Resources.hard6.h6_15, My.Resources.hard6.h6_16, My.Resources.hard6.h6_17, My.Resources.hard6.h6_18, My.Resources.hard6.h6_19, My.Resources.hard6.h6_20, My.Resources.hard6.h6_21, My.Resources.hard6.h6_22, My.Resources.hard6.h6_23, My.Resources.hard6.h6_24, My.Resources.hard6.h6_25}
            Case 7
                PicEasy = {My.Resources.easy7.e7_1, My.Resources.easy7.e7_2, My.Resources.easy7.e7_3, My.Resources.easy7.e7_4, My.Resources.easy7.e7_5, My.Resources.easy7.e7_6, My.Resources.easy7.e7_7, My.Resources.easy7.e7_8, My.Resources.easy7.e7_9}
                PicMedium = {My.Resources.medium7.m7_1, My.Resources.medium7.m7_2, My.Resources.medium7.m7_3, My.Resources.medium7.m7_4, My.Resources.medium7.m7_5, My.Resources.medium7.m7_6, My.Resources.medium7.m7_7, My.Resources.medium7.m7_8, My.Resources.medium7.m7_9, My.Resources.medium7.m7_10, My.Resources.medium7.m7_11, My.Resources.medium7.m7_12, My.Resources.medium7.m7_13, My.Resources.medium7.m7_14, My.Resources.medium7.m7_15, My.Resources.medium7.m7_16}
                PicHard = {My.Resources.hard7.h7_1, My.Resources.hard7.h7_2, My.Resources.hard7.h7_3, My.Resources.hard7.h7_4, My.Resources.hard7.h7_5, My.Resources.hard7.h7_6, My.Resources.hard7.h7_7, My.Resources.hard7.h7_8, My.Resources.hard7.h7_9, My.Resources.hard7.h7_10, My.Resources.hard7.h7_11, My.Resources.hard7.h7_12, My.Resources.hard7.h7_13, My.Resources.hard7.h7_14, My.Resources.hard7.h7_15, My.Resources.hard7.h7_16, My.Resources.hard7.h7_17, My.Resources.hard7.h7_18, My.Resources.hard7.h7_19, My.Resources.hard7.h7_20, My.Resources.hard7.h7_21, My.Resources.hard7.h7_22, My.Resources.hard7.h7_23, My.Resources.hard7.h7_24, My.Resources.hard7.h7_25}
        End Select
        If difficulty = "easy" Then
            DrawGame(2)
        ElseIf difficulty = "medium" Then
            DrawGame(3)
        Else
            DrawGame(4)
        End If
        scores = 0
        time = 0
        stepCount = 0
        Timer1.Enabled = True
        Return 0
    End Function
    '初始化
    Function Init()
        PicxEasy = {{PictureBox1, PictureBox2, PictureBox3}, {PictureBox4, PictureBox5, PictureBox6}, {PictureBox7, PictureBox8, PictureBox9}}
        PicxMedium = {{pm1, pm2, pm3, pm4}, {pm5, pm6, pm7, pm8}, {pm9, pm10, pm11, pm12}, {pm13, pm14, pm15, pm16}}
        PicxHard = {{ph1, ph2, ph3, ph4, ph5}, {ph6, ph7, ph8, ph9, ph10}, {ph11, ph12, ph13, ph14, ph15}, {ph16, ph17, ph18, ph19, ph20}, {ph21, ph22, ph23, ph24, ph25}}
        Return 0
    End Function
    '菜单栏
    '退出
    Private Sub 退出ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem1.Click
        Me.Close()
        Form2.Close()
    End Sub
    '重置
    Private Sub 重置ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 重置ToolStripMenuItem1.Click
        Start()
    End Sub
    '返回
    Private Sub 返回ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 返回ToolStripMenuItem.Click
        Me.Close()
        Form2.Show()
    End Sub
    '设置难度
    Function Clear()
        If difficulty <> "easy" Then
            For i = 0 To 2
                For j = 0 To 2
                    PicxEasy(i, j).BackgroundImage = Nothing
                    PicxEasy(i, j).Visible = False
                Next
            Next
        End If
        If difficulty <> "medium" Then
            For i = 0 To 3
                For j = 0 To 3
                    PicxMedium(i, j).BackgroundImage = Nothing
                    PicxMedium(i, j).Visible = False
                Next
            Next
        End If
        If difficulty <> "hard" Then
            For i = 0 To 4
                For j = 0 To 4
                    PicxHard(i, j).BackgroundImage = Nothing
                    PicxHard(i, j).Visible = False
                Next
            Next
        End If
        Return 0
    End Function
    Private Sub 简单ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 简单ToolStripMenuItem1.Click
        difficulty = "easy"
        For i = 0 To 2
            For j = 0 To 2
                PicxEasy(i, j).Visible = True
            Next
        Next
        Clear()
        Start()
    End Sub
    Private Sub 中等ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 中等ToolStripMenuItem1.Click
        difficulty = "medium"
        For i = 0 To 3
            For j = 0 To 3
                PicxMedium(i, j).Visible = True
            Next
        Next
        Clear()
        Start()
    End Sub
    Private Sub 困难ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 困难ToolStripMenuItem1.Click
        difficulty = "hard"
        For i = 0 To 4
            For j = 0 To 4
                PicxHard(i, j).Visible = True
            Next
        Next
        Clear()
        Start()
    End Sub
    '更换图片
    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        photo = 1
        Start()
    End Sub
    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        photo = 2
        Start()
    End Sub
    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        photo = 3
        Start()
    End Sub
    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        photo = 4
        Start()
    End Sub
    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        photo = 5
        Start()
    End Sub
    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        photo = 6
        Start()
    End Sub
    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        photo = 7
        Start()
    End Sub
    '胜负判断
    Function JudgeWin() As Boolean
        If difficulty = "easy" Then
            For i = 0 To 2
                For j = 0 To 2
                    If PicHashEasy(i, j) <> i * 3 + j And PicHashEasy(i, j) <> -1 Then
                        Return 0
                    End If
                Next
            Next
        ElseIf difficulty = "medium" Then
            For i = 0 To 3
                For j = 0 To 3
                    If PicHashMedium(i, j) <> i * 4 + j And PicHashMedium(i, j) <> -1 Then
                        Return 0
                    End If
                Next
            Next
        Else
            For i = 0 To 4
                For j = 0 To 4
                    If PicHashHard(i, j) <> i * 5 + j And PicHashHard(i, j) <> -1 Then
                        Return 0
                    End If
                Next
            Next
        End If


        Return 1
    End Function
    '帮助
    Function HelpBegin()
        If difficulty = "easy" Then
            For i = 0 To 2
                For j = 0 To 2
                    HelpHashEasy(i, j) = PicHashEasy(i, j)
                    PicxEasy(i, j).BackgroundImage = PicEasy(i * 3 + j)
                Next
            Next
        ElseIf difficulty = "medium" Then
            For i = 0 To 3
                For j = 0 To 3
                    HelpHashMedium(i, j) = PicHashMedium(i, j)
                    PicxMedium(i, j).BackgroundImage = PicMedium(i * 4 + j)
                Next
            Next
        Else
            For i = 0 To 4
                For j = 0 To 4
                    HelpHashHard(i, j) = PicHashHard(i, j)
                    PicxHard(i, j).BackgroundImage = PicHard(i * 5 + j)
                Next
            Next
        End If


    End Function
    Function HelpEnd()
        If difficulty = "easy" Then
            For i = 0 To 2
                For j = 0 To 2
                    PicHashEasy(i, j) = HelpHashEasy(i, j)
                    If PicHashEasy(i, j) <> -1 Then
                        PicxEasy(i, j).BackgroundImage = PicEasy(PicHashEasy(i, j))
                    Else
                        PicxEasy(i, j).BackgroundImage = Nothing
                    End If
                Next
            Next
        ElseIf difficulty = "medium" Then
            For i = 0 To 3
                For j = 0 To 3
                    PicHashMedium(i, j) = HelpHashMedium(i, j)
                    If PicHashMedium(i, j) <> -1 Then
                        PicxMedium(i, j).BackgroundImage = PicMedium(PicHashMedium(i, j))
                    Else
                        PicxMedium(i, j).BackgroundImage = Nothing
                    End If
                Next
            Next
        Else
            For i = 0 To 4
                For j = 0 To 4
                    PicHashHard(i, j) = HelpHashHard(i, j)
                    If PicHashHard(i, j) <> -1 Then
                        PicxHard(i, j).BackgroundImage = PicHard(PicHashHard(i, j))
                    Else
                        PicxHard(i, j).BackgroundImage = Nothing
                    End If
                Next
            Next
        End If

    End Function
    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        HelpBegin()
    End Sub
    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        HelpEnd()
    End Sub
    '结算
    Function GameOver()
        scores = (1000 - stepCount) * 5 + (500 - time) * 3 + 5000

        If difficulty = "hard" Then
            scores = scores * 10
        ElseIf difficulty = "medium" Then
            scores = scores * 5
        Else
            scores = scores * 2
        End If
        If Form3.JudgeUpdate(scores) Then
            Dim playerName = InputBox("恭喜！得分" & Str(scores) & “，刷新纪录，请输入你的名字！”)
            Form3.Add(scores, playerName)

        Else
            MsgBox("恭喜！得分" & Str(scores))
        End If
        Timer1.Enabled = False
        Dim result = MsgBox("是否重新开始？“, vbOKCancel)
        If result = 1 Then
            Start()
        Else
            Me.Close()
            Form2.Show()
        End If

        Return 0
    End Function
    '键盘事件
    Function PlayerKeyDown(w As Integer)
        stepCount = stepCount + 1
        Dim high As Integer
        Select Case difficulty
            Case "easy"
                high = 2
            Case "medium"
                high = 3
            Case "hard"
                high = 4
        End Select
        Dim x, y As Integer
        For i = 0 To high
            For j = 0 To high
                If difficulty = "easy" Then
                    If IsNothing(PicxEasy(i, j).BackgroundImage) Then
                        x = i
                        y = j
                    End If
                ElseIf difficulty = "medium" Then
                    If IsNothing(PicxMedium(i, j).BackgroundImage) Then
                        x = i
                        y = j
                    End If
                Else
                    If IsNothing(PicxHard(i, j).BackgroundImage) Then
                        x = i
                        y = j
                    End If
                End If
            Next
        Next
        Dim nx = x + _move(w, 0)
        Dim ny = y + _move(w, 1)
        If nx >= 0 And nx <= high And ny >= 0 And ny <= high Then
            If difficulty = "easy" Then
                PicxEasy(x, y).BackgroundImage = PicxEasy(nx, ny).BackgroundImage
                PicxEasy(nx, ny).BackgroundImage = Nothing
                Dim t As Integer = PicHashEasy(nx, ny)
                PicHashEasy(nx, ny) = PicHashEasy(x, y)
                PicHashEasy(x, y) = t
            ElseIf difficulty = "medium" Then
                PicxMedium(x, y).BackgroundImage = PicxMedium(nx, ny).BackgroundImage
                PicxMedium(nx, ny).BackgroundImage = Nothing
                Dim t As Integer = PicHashMedium(nx, ny)
                PicHashMedium(nx, ny) = PicHashMedium(x, y)
                PicHashMedium(x, y) = t
            Else
                PicxHard(x, y).BackgroundImage = PicxHard(nx, ny).BackgroundImage
                PicxHard(nx, ny).BackgroundImage = Nothing
                Dim t As Integer = PicHashHard(nx, ny)
                PicHashHard(nx, ny) = PicHashHard(x, y)
                PicHashHard(x, y) = t
            End If
        End If
        Return 0
    End Function
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.W Or e.KeyCode = Keys.Up Then
            PlayerKeyDown(0)
        End If
        If e.KeyCode = Keys.A Or e.KeyCode = Keys.Left Then
            PlayerKeyDown(1)
        End If
        If e.KeyCode = Keys.D Or e.KeyCode = Keys.Right Then
            PlayerKeyDown(3)
        End If
        If e.KeyCode = Keys.S Or e.KeyCode = Keys.Down Then
            PlayerKeyDown(2)
        End If
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    '鼠标事件
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        player_click(0, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Function player_click(x As Integer, y As Integer)
        stepCount = stepCount + 1
        If difficulty = "easy" Then
            For i = 0 To 3
                Dim nx = x + _move(i, 0)
                Dim ny = y + _move(i, 1)
                If nx >= 0 And nx <= 2 And ny >= 0 And ny <= 2 Then
                    If IsNothing(PicxEasy(nx, ny).BackgroundImage) Then
                        PicxEasy(nx, ny).BackgroundImage = PicxEasy(x, y).BackgroundImage
                        PicxEasy(x, y).BackgroundImage = Nothing
                        Dim t As Integer = PicHashEasy(nx, ny)
                        PicHashEasy(nx, ny) = PicHashEasy(x, y)
                        PicHashEasy(x, y) = t
                    End If
                End If
            Next
        ElseIf difficulty = "medium" Then
            For i = 0 To 3
                Dim nx = x + _move(i, 0)
                Dim ny = y + _move(i, 1)
                If nx >= 0 And nx <= 3 And ny >= 0 And ny <= 3 Then
                    If IsNothing(PicxMedium(nx, ny).BackgroundImage) Then
                        PicxMedium(nx, ny).BackgroundImage = PicxMedium(x, y).BackgroundImage
                        PicxMedium(x, y).BackgroundImage = Nothing
                        Dim t As Integer = PicHashMedium(nx, ny)
                        PicHashMedium(nx, ny) = PicHashMedium(x, y)
                        PicHashMedium(x, y) = t
                    End If
                End If
            Next
        Else
            For i = 0 To 3
                Dim nx = x + _move(i, 0)
                Dim ny = y + _move(i, 1)
                If nx >= 0 And nx <= 4 And ny >= 0 And ny <= 4 Then
                    If IsNothing(PicxHard(nx, ny).BackgroundImage) Then
                        PicxHard(nx, ny).BackgroundImage = PicxHard(x, y).BackgroundImage
                        PicxHard(x, y).BackgroundImage = Nothing
                        Dim t As Integer = PicHashHard(nx, ny)
                        PicHashHard(nx, ny) = PicHashHard(x, y)
                        PicHashHard(x, y) = t
                    End If
                End If
            Next
        End If

        Return 0
    End Function
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        player_click(0, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        player_click(0, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        player_click(1, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        player_click(1, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        player_click(1, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        player_click(2, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        player_click(2, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        player_click(2, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm1_Click(sender As Object, e As EventArgs) Handles pm1.Click
        player_click(0, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm2_Click(sender As Object, e As EventArgs) Handles pm2.Click
        player_click(0, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm3_Click(sender As Object, e As EventArgs) Handles pm3.Click
        player_click(0, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm4_Click(sender As Object, e As EventArgs) Handles pm4.Click
        player_click(0, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm5_Click(sender As Object, e As EventArgs) Handles pm5.Click
        player_click(1, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm6_Click(sender As Object, e As EventArgs) Handles pm6.Click
        player_click(1, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm7_Click(sender As Object, e As EventArgs) Handles pm7.Click
        player_click(1, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm8_Click(sender As Object, e As EventArgs) Handles pm8.Click
        player_click(1, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm9_Click(sender As Object, e As EventArgs) Handles pm9.Click
        player_click(2, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm10_Click(sender As Object, e As EventArgs) Handles pm10.Click
        player_click(2, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm11_Click(sender As Object, e As EventArgs) Handles pm11.Click
        player_click(2, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm12_Click(sender As Object, e As EventArgs) Handles pm12.Click
        player_click(2, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm13_Click(sender As Object, e As EventArgs) Handles pm13.Click
        player_click(3, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm14_Click(sender As Object, e As EventArgs) Handles pm14.Click
        player_click(3, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm15_Click(sender As Object, e As EventArgs) Handles pm15.Click
        player_click(3, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub pm16_Click(sender As Object, e As EventArgs) Handles pm16.Click
        player_click(3, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph1_Click(sender As Object, e As EventArgs) Handles ph1.Click
        player_click(0, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph2_Click(sender As Object, e As EventArgs) Handles ph2.Click
        player_click(0, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph3_Click(sender As Object, e As EventArgs) Handles ph3.Click
        player_click(0, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph4_Click(sender As Object, e As EventArgs) Handles ph4.Click
        player_click(0, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph5_Click(sender As Object, e As EventArgs) Handles ph5.Click
        player_click(0, 4)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph6_Click(sender As Object, e As EventArgs) Handles ph6.Click
        player_click(1, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph7_Click(sender As Object, e As EventArgs) Handles ph7.Click
        player_click(1, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph8_Click(sender As Object, e As EventArgs) Handles ph8.Click
        player_click(1, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph9_Click(sender As Object, e As EventArgs) Handles ph9.Click
        player_click(1, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph10_Click(sender As Object, e As EventArgs) Handles ph10.Click
        player_click(1, 4)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph11_Click(sender As Object, e As EventArgs) Handles ph11.Click
        player_click(2, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph12_Click(sender As Object, e As EventArgs) Handles ph12.Click
        player_click(2, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph13_Click(sender As Object, e As EventArgs) Handles ph13.Click
        player_click(2, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph14_Click(sender As Object, e As EventArgs) Handles ph14.Click
        player_click(2, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph15_Click(sender As Object, e As EventArgs) Handles ph15.Click
        player_click(2, 4)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph16_Click(sender As Object, e As EventArgs) Handles ph16.Click
        player_click(3, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph17_Click(sender As Object, e As EventArgs) Handles ph17.Click
        player_click(3, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph18_Click(sender As Object, e As EventArgs) Handles ph18.Click
        player_click(3, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph19_Click(sender As Object, e As EventArgs) Handles ph19.Click
        player_click(3, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph20_Click(sender As Object, e As EventArgs) Handles ph20.Click
        player_click(3, 4)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph21_Click(sender As Object, e As EventArgs) Handles ph21.Click
        player_click(4, 0)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph22_Click(sender As Object, e As EventArgs) Handles ph22.Click
        player_click(4, 1)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph23_Click(sender As Object, e As EventArgs) Handles ph23.Click
        player_click(4, 2)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph24_Click(sender As Object, e As EventArgs) Handles ph24.Click
        player_click(4, 3)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub
    Private Sub ph25_Click(sender As Object, e As EventArgs) Handles ph25.Click
        player_click(4, 4)
        If JudgeWin() Then
            GameOver()
        End If
    End Sub

    '计时器
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time = time + 1
        Label2.Text = "已用" & Str(time) & "秒"
        Label3.Text = "已用" & Str(stepCount) & "步"
    End Sub


End Class
