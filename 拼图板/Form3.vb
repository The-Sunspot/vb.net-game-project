Imports System.Xml
Public Class Form3
    Dim ranking(6) As Integer
    Dim player(6) As String
    Dim Textbx(10) As TextBox
    Dim key As Integer = 1004196120
    '给排行榜赋一个初值
    Function DefaultRank()
        ranking = ｛100000, 10000, 1000, 100, 10, 1, 0｝
        player = ｛"无名氏"， "路人甲", "孔乙己"， “张三”， "李四"， “王二麻子”， “李大壮”｝
        Return 0
    End Function
    '第一次进入游戏创建新排行榜
    Function NewRanking()
        'vb的orelse才是真正c中||的逻辑，如果用or的话第一个真了还会判断第二个
        If Dir("Rank.xml") = "" OrElse My.Computer.FileSystem.GetFileInfo("Rank.xml").Length < 50 Then
            DefaultRank()
            SaveRank()
        End If
        Return 0
    End Function
    '检测排行榜文件是否存在，以及读入数据
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Textbx = {TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12, TextBox13}
        NewRanking()
        LoadRank()
        ShowRank()
    End Sub
    '加入新数据
    Function Add(a As Integer, b As String)
        LoadRank()
        ranking(6) = a
        player(6) = b
        Dim index = 5
        While index > 0
            If ranking(index) < ranking(index + 1) Then
                a = ranking(index + 1)
                ranking(index + 1) = ranking(index)
                ranking(index) = a
                b = player(index + 1)
                player(index + 1) = player(index)
                player(index) = b
            Else
                Exit While
            End If
            index -= 1
        End While
        SaveRank()
        Return 0
    End Function
    '用于游戏界面调用，判断是否打破记录
    Function JudgeUpdate(a As Integer)
        LoadRank()
        If a > ranking(5) Then
            Return True
        Else
            Return False
        End If
    End Function
    '数据展示
    Function ShowRank()
        For i = 2 To 6
            Textbx(i * 2 - 4).Text = ranking(i - 1)
            Textbx(i * 2 - 3).Text = player(i - 1)
        Next
        Return 0
    End Function
    '数据存储
    Function SaveRank()
        Dim xmlWS As New XmlWriterSettings
        xmlWS.Indent = True
        xmlWS.NewLineOnAttributes = True
        Using xmlW As XmlWriter = XmlWriter.Create(Application.StartupPath & "\rank.xml", xmlWS)
            xmlW.WriteStartElement("Rank")
            xmlW.WriteAttributeString(player(1), ranking(1) Xor key)
            xmlW.WriteAttributeString(player(2), ranking(2) Xor key)
            xmlW.WriteAttributeString(player(3), ranking(3) Xor key)
            xmlW.WriteAttributeString(player(4), ranking(4) Xor key)
            xmlW.WriteAttributeString(player(5), ranking(5) Xor key)
            xmlW.WriteEndElement()
            xmlW.Flush() '强行推入设备（文档）
        End Using
        Return 0
    End Function
    '读入数据
    Function LoadRank()
        Dim xmlRS As New XmlReaderSettings
        Dim strXml As String = ""
        Dim index As Integer = 1
        Using xmlR As XmlReader = XmlReader.Create(Application.StartupPath & "\rank.xml", xmlRS)
            While xmlR.Read
                If xmlR.Name = "Rank" Then
                    While xmlR.MoveToNextAttribute
                        ranking(index) = Val(xmlR.Value Xor key)
                        player(index) = xmlR.Name
                        index += 1
                    End While
                End If
            End While
        End Using
        Return 0
    End Function
    '返回
    Private Sub 返回ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 返回ToolStripMenuItem.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Form3_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            LoadRank()
            ShowRank()
        End If
    End Sub
End Class