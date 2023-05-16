Imports System.Net
Imports System.IO
Imports System.Net.Sockets

Public Class frmMain

    Private client As TcpClient
    Private sWriter As StreamWriter
    Private Const NickFrefix As Integer = 1
    Private Delegate Sub _xUpdate(ByVal str As String)
    Private Const ServerPort As Integer = 3818

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text &= " " & NickFrefix
    End Sub

    Private Sub xUpdate(ByVal str As String)
        If InvokeRequired Then
            Invoke(New _xUpdate(AddressOf xUpdate), str)
        Else
            txtReceive.Text = str
        End If
    End Sub

    Private Sub read(ByVal ar As IAsyncResult)
        Try
            xUpdate(New StreamReader(client.GetStream).ReadLine)
            client.GetStream.BeginRead(New Byte() {0}, 0, 0, AddressOf read, Nothing)
        Catch ex As Exception
            xUpdate("You are disconnected from the server.")
        End Try
    End Sub

    Private Sub send(ByVal str As String)
        Try
            sWriter = New StreamWriter(client.GetStream)
            sWriter.WriteLine(str)
            sWriter.Flush()
        Catch ex As Exception
            xUpdate("You're not server")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Connect" Then
            ConnectToServer()
        Else
            DisconnectFromServer()
        End If
    End Sub

    Private Sub ConnectToServer()
        Try
            client = New TcpClient(TextBox1.Text, ServerPort)
            client.GetStream.BeginRead(New Byte() {0}, 0, 0, New AsyncCallback(AddressOf read), Nothing)
            Button1.Text = "Disconnect"
            lblStatus.Text = "Client connected!"
            grpSlot.Enabled = False
            TextBox1.Enabled = False
        Catch ex As Exception
            xUpdate("Can't connect to the server!")
            lblStatus.Text = "Error: Cannot connect to server."
        End Try
    End Sub

    Private Sub DisconnectFromServer()
        lblStatus.Text = "Disconnecting..."
        client?.Client.Close()
        client = Nothing
        Button1.Text = "Connect"
        lblStatus.Text = "Client disconnected!"
        grpSlot.Enabled = True
        TextBox1.Enabled = True
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendMessage()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SendMessage()
    End Sub

    Private Sub SendMessage()
        send(NickFrefix & " - " & TextBox4.Text)
        TextBox4.Clear()
    End Sub

    Dim splits As String()
    Dim question As String
    Dim ansA As String
    Dim ansB As String
    Dim ansC As String
    Dim ansD As String

    Private Sub txtReceive_TextChanged(sender As Object, e As EventArgs) Handles txtReceive.TextChanged
        Dim cmd As String = txtReceive.Text

        Select Case cmd
            Case "/unlock"
                ResetButtonsText()
                grpAnswers.Enabled = True
                Button1.Enabled = False
            Case "/lock"
                Button1.Enabled = True
                grpAnswers.Enabled = False
            Case "/clear"
                ResetButtonsText()
                txtAnswer.Text = ""
            Case Else
                If cmd.Contains("#") Then
                    splits = cmd.Split("#")
                    If cmd.Contains("/q1#") Then
                        txtQuestion.Text = splits(1)
                    ElseIf cmd.Contains("/q2#") Then
                        btnA.Text = "A: " + splits(1)
                        btnB.Text = "B: " + splits(2)
                        btnC.Text = "C: " + splits(3)
                        btnD.Text = "D: " + splits(4)
                    End If
                End If
        End Select
    End Sub

    Private Sub ResetButtonsText()
        btnA.Text = "A"
        btnB.Text = "B"
        btnC.Text = "C"
        btnD.Text = "D"
    End Sub

    Private Sub btnFinal_Click(sender As Object, e As EventArgs) Handles btnFinal.Click
        send(Convert.ToString(nmrSlot.Value) + "-" + txtAnswer.Text)
        txtAnswer.AppendText(" - OK")
        grpAnswers.Enabled = False
    End Sub

    Private Sub btnAnswer_Click(sender As Object, e As EventArgs) Handles btnA.Click, btnB.Click, btnC.Click, btnD.Click
        If txtAnswer.TextLength < 4 Then
            txtAnswer.AppendText(CType(sender, Button).Text.Substring(0, 1))
        End If
    End Sub

    Private Sub btnAnswer_MouseEnter(sender As Object, e As EventArgs) Handles btnA.MouseEnter, btnB.MouseEnter, btnC.MouseEnter, btnD.MouseEnter
        CType(sender, Button).BackgroundImage = My.Resources.Final_Answer_Fill
    End Sub

    Private Sub btnAnswer_MouseLeave(sender As Object, e As EventArgs) Handles btnA.MouseLeave, btnB.MouseLeave, btnC.MouseLeave, btnD.MouseLeave
        CType(sender, Button).BackgroundImage = My.Resources.Normal_Answer_Fill
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAnswer.Clear()
    End Sub

End Class
