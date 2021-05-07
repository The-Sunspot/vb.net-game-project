Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form3.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    '初次进入游戏创建排行榜
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form3.NewRanking()
        Dim music As New Media.SoundPlayer
        music.SoundLocation = "music.wav"
        music.PlayLooping()
    End Sub
End Class