Public Class Display
    Private Sub logoutButton_Click(sender As Object, e As EventArgs) Handles logoutButton.Click
        'Chamando o metodo para desabilitar botoes
        desabilitarButoes()

        'Start to progressbar
        Timer1.Start()

        'Habilitando o progressbar
        processLabel.Visible = True
        ProgressBar1.Visible = True



    End Sub

    Private Sub dashboardButton_Click(sender As Object, e As EventArgs) Handles dashboardButton.Click
        Me.Show()
        Panel3.Visible = False
        userPanel.Visible = False


    End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        Panel3.Visible = True
        userPanel.Visible = False

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Estudante.Show()
    End Sub

    'Pagamento button
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles pagamentoButton.Click
        Pagamento.Show()
        Me.Close()
    End Sub

    'Loud do formulario
    Private Sub Display_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.Visible = False
        userPanel.Visible = False

        'Desabilitar as propriedades do progressbar
        ProgressBar1.Visible = False
        processLabel.Visible = False

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 60 Then
            processLabel.Text = "Quase pronto..."
        End If


        If ProgressBar1.Value >= 100 Then
            Timer1.Stop()
            MessageBox.Show("Ate a proxima.")
            Login.Show()
            Me.Close()

        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If

    End Sub

    'Desabilitar botoes
    Public Sub desabilitarButoes()
        dashboardButton.Enabled = False
        addButton.Enabled = False
        Button2.Enabled = False
        usuarioButton.Enabled = False
        Button6.Enabled = False
        pagamentoButton.Enabled = False
        aboutButton.Enabled = False
        logoutButton.Enabled = False
        addUsuarioButton.Enabled = False
        viewButton.Enabled = False

    End Sub

    Private Sub aboutButton_Click(sender As Object, e As EventArgs) Handles aboutButton.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub usuarioButton_Click(sender As Object, e As EventArgs) Handles usuarioButton.Click
        userPanel.Visible = True
        Panel3.Visible = False
    End Sub

    Private Sub addUsuarioButton_Click(sender As Object, e As EventArgs) Handles addUsuarioButton.Click
        CadastroDeUsuario.Show()
        Me.Close()
    End Sub

    Private Sub viewButton_Click(sender As Object, e As EventArgs) Handles viewButton.Click
        BasicViewUser.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Visualizar_estudantes.Show()
        Me.Close()
    End Sub
End Class