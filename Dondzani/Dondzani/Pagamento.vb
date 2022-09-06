Imports MySql.Data.MySqlClient
Public Class Pagamento
    Dim isProcessNumber As Boolean = False
    Private Sub Pagamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value.AddDays(6)
    End Sub

    Private Sub paginaButton_Click(sender As Object, e As EventArgs) Handles paginaButton.Click
        Display.Show()
        Me.Close()
    End Sub

    Private Sub voltarButton_Click(sender As Object, e As EventArgs) Handles voltarButton.Click
        Display.Show()
        Display.Panel3.Visible = True
        Me.Close()
    End Sub

    Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
        Fatura.Show()
    End Sub
    Private Sub calcultoDePropinas()
        If (DateTimePicker1.Value.Day >= 25 And DateTimePicker1.Value.Day <= 31) Or (DateTimePicker1.Value.Day >= 1 And DateTimePicker1.Value.Day <= 5) Then
            If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "10000"
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "0"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "15000"
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "0"
            End If

            If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "15000"
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "0"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "20000"
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "0"
            End If
        ElseIf (DateTimePicker1.Value.Day > 5 And DateTimePicker1.Value.Day <= 10) Then
            MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
            If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (10000 + (10000 * 0.1))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "10"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.1))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "10"
            End If

            If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.1))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "10"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (20000 + (20000 * 0.1))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "10"
            End If
        ElseIf (DateTimePicker1.Value.Day > 10 And DateTimePicker1.Value.Day <= 20) Then
            MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
            If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (10000 + (10000 * 0.15))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "15"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.15))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "15"
            End If

            If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.15))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "15"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (20000 + (20000 * 0.15))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "15"
            End If
        ElseIf DateTimePicker1.Value.Day > 20 Then
            MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
            If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (10000 + (10000 * 0.25))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "25"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.25))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "25"
            End If

            If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.25))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "25"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (20000 + (20000 * 0.25))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "25"
            End If
        End If
    End Sub

    Private Sub calcultoDePropinasMultosas()
        If (DateTimePicker1.Value.Day >= 25 And DateTimePicker1.Value.Day <= 31) Or (DateTimePicker1.Value.Day >= 1 And DateTimePicker1.Value.Day <= 5) Then
            If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "10000"
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "0"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "15000"
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "0"
            End If

            If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "15000"
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "0"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "20000"
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "0"
            End If
        ElseIf DateTimePicker1.Value.Day < 25 Then
            MessageBox.Show("Serviço indisponivel!")
        ElseIf (DateTimePicker1.Value.Day > 5 And DateTimePicker1.Value.Day <= 10) Then
            MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
            If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (10000 + (10000 * 0.1))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "10"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.1))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "10"
            End If

            If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.1))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "10"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (20000 + (20000 * 0.1))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "10"
            End If
        ElseIf (DateTimePicker1.Value.Day > 10 And DateTimePicker1.Value.Day <= 20) Then
            MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
            If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (10000 + (10000 * 0.15))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "15"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.15))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "15"
            End If

            If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.15))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "15"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (20000 + (20000 * 0.15))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "15"
            End If
        ElseIf DateTimePicker1.Value.Day > 20 Then
            MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
            If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (10000 + (10000 * 0.25))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "25"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.25))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "25"
            End If

            If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (15000 + (15000 * 0.25))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "25"
            ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                txtNrTalao.Text = "" & (20000 + (20000 * 0.25))
                txtValor.Text = txtNrTalao.Text
                TextBox8.Text = "25"
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If (TextBox1.Text <> "" And TextBox1.Text <> "Numero do processo") And TextBox1.Text.Length = 5 Then
            Try
                Convert.ToInt64(TextBox1.Text)
                isProcessNumber = True
                nrProcessoLabel.Visible = False
                pesquisaButton.Enabled = True
            Catch ex As Exception
                nrProcessoLabel.Visible = True
                nrProcessoLabel.Text = "Use apenas numeros"
            End Try
        ElseIf TextBox1.Text = "Numero do processo" Then
            nrProcessoLabel.Visible = False
        ElseIf TextBox1.Text <> "Numero do processo" And TextBox4.Text.Length < 5 And TextBox1.Text <> "" Then
            isProcessNumber = False
            nrProcessoLabel.Visible = True
            nrProcessoLabel.Text = "Numero invalido!"
        End If
    End Sub
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        PlaceholderEnter(TextBox1, "Numero do processo")
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        PlaceholderLeave(TextBox1, "Numero do processo")
    End Sub

    Private Sub pesquisaButton_Click(sender As Object, e As EventArgs) Handles pesquisaButton.Click
        Dim leitorDataReader, leitorDataReader1 As MySqlDataReader
        Dim cmd As New MySqlCommand
        If isProcessNumber Then
            Try
                sql = "SELECT * FROM Estudante WHERE Numero_do_Processo = '" & TextBox1.Text & "'"
                Dim conex As New MySqlConnection("Server = localhost;Database = FEP; User id = root")
                conex.Open()
                cmd.Connection = conex
                cmd.CommandText = sql
                leitorDataReader = cmd.ExecuteReader()

                If leitorDataReader.Read() Then
                    TextBox2.Text = leitorDataReader.Item("NUMERO_DO_PROCESSO").ToString
                    TextBox3.Text = leitorDataReader.Item("NOME_DO_ESTUDANTE").ToString
                    TextBox4.Text = leitorDataReader.Item("TIPO_DE_ESTUDANTE").ToString
                    TextBox5.Text = leitorDataReader.Item("CATEGORIA").ToString
                    TextBox7.Text = leitorDataReader.Item("NIVEL").ToString

                    printButton.Enabled = True
                    payButton.Enabled = True
                End If
                leitorDataReader.Close()
                conex.Close()

                sql = "SELECT DATA_DO_PAGAMENTO FROM Pagamento INNER JOIN Estudante ON Pagamento.NUMERO_DO_PROCESSO = Estudante.NUMERO_DO_PROCESSO WHERE (Pagamento.NUMERO_DO_PROCESSO = '" & TextBox1.Text & "' AND DATA_DO_PAGAMENTO = (SELECT MAX(DATA_DO_PAGAMENTO) FROM Pagamento))"
                Dim con As New MySqlConnection("Server = localhost;Database = FEP; User id = root")
                con.Open()
                cmd.Connection = con
                cmd.CommandText = sql
                leitorDataReader1 = cmd.ExecuteReader()
                Dim strData As String = ""
                If leitorDataReader1.Read() Then
                    strData = leitorDataReader.Item("DATA_DO_PAGAMENTO").ToString
                    printButton.Enabled = True
                End If
                leitorDataReader1.Close()
                con.Close()
                If strData <> "" Then
                    'VERIFICA SE O ANO ACTUAL É SUPERIOR OU IGUAL AO ANO DO ULTIMO PAGAMENTO REGISTADO
                    If (DateTimePicker1.Value.Year - CInt(strData.Substring(0, 4))) = 0 Then
                        If (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) = 1 Or (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) = 0 Then
                            calcultoDePropinas()
                        ElseIf (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) > 1 Then
                            If (DateTimePicker1.Value.Day >= 25 And DateTimePicker1.Value.Day <= 31) Or (DateTimePicker1.Value.Day >= 1 And DateTimePicker1.Value.Day <= 5) Then
                                If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                                    txtNrTalao.Text = "" & (10000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + (10000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))))
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                                    txtNrTalao.Text = ((15000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + (15000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                End If

                                If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                                    txtNrTalao.Text = ((15000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + (15000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                                    txtNrTalao.Text = ((20000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + (20000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                End If
                            ElseIf (DateTimePicker1.Value.Day > 5 And DateTimePicker1.Value.Day <= 10) Then
                                MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
                                If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                                    txtNrTalao.Text = "" & (10000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + ((10000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))) + (10000 * 0.1)))
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                                    txtNrTalao.Text = ((15000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + ((15000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))) + (15000 * 0.1)))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                End If
                                MessageBox.Show("Serviço indisponivel!")
                                If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                                    txtNrTalao.Text = ((15000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + ((15000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))) + (15000 * 0.1)))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                                    txtNrTalao.Text = ((20000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + ((20000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))) + (20000 * 0.1)))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                End If
                            ElseIf (DateTimePicker1.Value.Day > 10 And DateTimePicker1.Value.Day <= 20) Then
                                MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
                                If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                                    txtNrTalao.Text = "" & (10000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + ((10000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))) + (10000 * 0.15)))
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                                    txtNrTalao.Text = ((15000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + ((15000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))) + (15000 * 0.15)))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                End If
                                MessageBox.Show("Serviço indisponivel!")
                                If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                                    txtNrTalao.Text = ((15000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + ((15000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))) + (15000 * 0.15)))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                                    txtNrTalao.Text = ((20000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + ((20000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7)) - 1))) + (20000 * 0.15)))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                End If
                            ElseIf DateTimePicker1.Value.Day > 20 Then
                                MessageBox.Show("Excedeu o prazo normal de pagamento, esta operacão esta sujeita a multas adicionais")
                                If TextBox4.Text = "Nacional" And TextBox5.Text = "Mestrado" Then
                                    txtNrTalao.Text = "" & (10000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + (10000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))))))
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Mestrado" Then
                                    txtNrTalao.Text = ((15000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + (15000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))))))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                End If

                                If TextBox4.Text = "Nacional" And TextBox5.Text = "Doutorado" Then
                                    txtNrTalao.Text = ((15000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + (15000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))))))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                ElseIf TextBox4.Text = "Estrageiro" And TextBox5.Text = "Doutorado" Then
                                    txtNrTalao.Text = ((20000 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))) + (20000 * (0.25 * (DateTimePicker1.Value.Month - CInt(strData.Substring(6, 7))))))).ToString
                                    txtValor.Text = txtNrTalao.Text
                                    TextBox8.Text = "25"
                                End If
                            End If
                        End If
                    ElseIf (DateTimePicker1.Value.Year - CInt(strData.Substring(0, 4))) > 0 Then
                        calcultoDePropinas()
                    Else
                        MessageBox.Show("Erro ao executar a operação. Por favor verifique a data e hora do seu computador e volte a tentar")
                    End If
                Else
                    calcultoDePropinas()
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Numero incorrecto!")
        End If
    End Sub
End Class