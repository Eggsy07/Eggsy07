Imports MySql.Data.MySqlClient
Imports FontAwesome.Sharp
Class Login

    Public usuario, pass, categoria As String
    Public login As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        usuario = ""
        pass = ""
        categoria = ""
        login = False
        Connecting()
        Me.ActiveControl = PictureBox3
        'Esconder Lables
        invalidLoginLabel.Visible = False
        emptyLabel.Visible = False

        If isDatabaseEmpty Then
            Button1.Visible = True
        End If
    End Sub

    '------BOTAO DE SUBMISSAO-------
    Private Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click

        sql = "SELECT USERNAME, PASSWORD, CATEGORIA FROM Login WHERE USERNAME = '" & txtLogin.Text & "' AND PASSWORD  = '" & txtPassword.Text & "'"
        commandSql.CommandText = sql
        Dim leitorDataReader As MySqlDataReader = commandSql.ExecuteReader()

        '----------------I M P O R T A N T E-------------
        '----------------S E G U R A N C A---------------
        Try
            'Autenticacao no sistama
            If leitorDataReader.Read() Then
                invalidLoginLabel.Visible = False

                'Limpando campos apos o envio
                txtLogin.Text = ""
                txtPassword.Text = ""

                'Autorizacao
                If leitorDataReader.Item(2).ToString = "Admin" Then
                    Display.Show()
                    Me.Hide()

                End If

                'Formulario dos usuarios Comuns
                '-----PENDENTE----
            Else
                invalidLoginLabel.Visible = True
                invalidLoginLabel.Text = "Password ou username invalidos"
                invalidLoginLabel.Location = New Point(492, 231)
            End If
                leitorDataReader.Close()

        Catch ex As Exception
            MessageBox.Show("error! " & ex.Message)
        End Try

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text <> "" And txtPassword.Text.Length < 8 Then
            emptyLabel.Visible = True
            invalidLoginLabel.Visible = False
        Else
            emptyLabel.Visible = False
        End If
    End Sub

    Private Sub txtLogin_TextChanged(sender As Object, e As EventArgs) Handles txtLogin.TextChanged
        If txtLogin.Text <> "" And txtLogin.Text.Length <= 3 Then
            invalidLoginLabel.Visible = True
            invalidLoginLabel.Location = New Point(554, 170)
        Else
            invalidLoginLabel.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        CadastroDeUsuario.Show()
        Button1.Visible = False
        CadastroDeUsuario.voltarButton.Visible = False
    End Sub

    Private Sub txtLogin_Enter(sender As Object, e As EventArgs) Handles txtLogin.Enter
        PlaceholderEnter(txtLogin, "Username")
    End Sub

    Private Sub txtLogin_Leave(sender As Object, e As EventArgs) Handles txtLogin.Leave
        PlaceholderLeave(txtLogin, "Username")
    End Sub
End Class