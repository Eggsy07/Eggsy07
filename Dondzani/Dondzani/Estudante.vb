Imports MySql.Data.MySqlClient
Public Class Estudante
    Dim currentYear As Integer
    Dim isMascTrue, isEmissionDateIdValide, isProcessNumberValide, isExpiryDateIdValide, isFemTrue, isNameValide, isDateOfBirthValide, isAddressValide, isAddressIdValide, isIdValide, isProfessionValide, isLastNameValide, isEmailValide, isNumberPhoneValide, isLastLabel, isFirstLabel, isSecondLabel, isNationalTrue, isForeignTrue As Boolean

    Private c1, c2, c3, c4, c5 As String

    Private genero As String = ""

    Private email As String = ""

    Private tipoDeEstudante As String = ""
    Private categoria As String = ""
    Private contacto As Integer = 5
    Private Sub Estudante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'So eh habiltado se o nivel de mestrado tambem o for
        Me.ActiveControl = PictureBox3
        setAllBooleanVariablesAsFalse()
        setFalseAllAlertLabelsOnLoad()
        ComboBoxInicializer()
        nivelPicker.Enabled = False
        currentYear = biEmissaoPicker.Value.Year
        c1 = "NONE"
        c2 = "NONE"
        c3 = "NONE"
        c4 = "NONE"
        c5 = "NONE"
    End Sub
    'MÉTODO RESPONSÁVEL POR INICIALIZAR A COMBOBOX DOS EMAIL'S
    Private Sub ComboBoxInicializer()
        ComboBox2.Items.Add("@gmail.com")
        ComboBox2.Items.Add("@hotmail.com")
        ComboBox2.Items.Add("@outlook.com")
        ComboBox2.Items.Add("@yahoo.com")
        ComboBox2.Items.Add("@icloud.com")
        ComboBox2.Items.Add("@gamail.com")
        ComboBox2.SelectedIndex = ComboBox2.FindStringExact("@gmail.com")
    End Sub
    'MÉTODO RESPONSÁVEL POR INICIALIZAR COMO FALSO TODAS AS VARIÁVEIS BOOLEANAS
    Private Sub setAllBooleanVariablesAsFalse()
        isMascTrue = False = isProcessNumberValide = isEmissionDateIdValide = isExpiryDateIdValide = isFemTrue = isNameValide = isDateOfBirthValide = isAddressValide = isAddressIdValide = isIdValide = isProfessionValide = isLastNameValide = isEmailValide = isNumberPhoneValide = isLastLabel = isFirstLabel = isSecondLabel = isNationalTrue = isForeignTrue = False
    End Sub
    'MÉTODO RESPONSÁVEL POR INVIZIBILIZAR AS LABEL'S DE ALERTA AO CARREGAR O FORMULÁRIO
    Private Sub setFalseAllAlertLabelsOnLoad()
        Label15.Visible = False
        Label16.Visible = False
        emissaoLabel.Visible = False
        moradaLabel.Visible = False
        numeroLabel.Visible = False
        Label14.Visible = False
        emailLabel.Visible = False
        nomeLabel.Visible = False
        Label17.Visible = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Display.Show()
        Me.Close()
    End Sub

    Private Sub voltarButton_Click(sender As Object, e As EventArgs) Handles voltarButton.Click
        Me.Close()
        Display.Show()
        'Funcao do back que permite que o painel do submenu esteja visivel
        Display.Panel3.Visible = True
    End Sub

    'Habilita a escolha do nivel se o mestrado for selecionado
    'O mestrado eh que tem dois anos, por isso essa intervecao
    Private Sub radioMestrado_CheckedChanged(sender As Object, e As EventArgs) Handles radioMestrado.CheckedChanged
        If radioMestrado.Checked = True Then
            nivelPicker.Enabled = True
            Label12.Visible = False
            categoria = radioMestrado.Text
        End If
    End Sub

    'GERENCIANDO OS PLACEHOLDERS DOS COMPOS TEXBOS'S
    Private Sub nrInscricaoTxt_Enter(sender As Object, e As EventArgs) Handles nrInscricaoTxt.Enter
        PlaceholderEnter(nrInscricaoTxt, "Numero do processo")
    End Sub

    Private Sub nrInscricaoTxt_Leave(sender As Object, e As EventArgs) Handles nrInscricaoTxt.Leave
        PlaceholderLeave(nrInscricaoTxt, "Numero do processo")
    End Sub

    Private Sub nomeTxt_Enter(sender As Object, e As EventArgs) Handles nomeTxt.Enter
        PlaceholderEnter(nomeTxt, "Nome proprio")
    End Sub

    Private Sub nomeTxt_Leave(sender As Object, e As EventArgs) Handles nomeTxt.Leave
        PlaceholderLeave(nomeTxt, "Nome proprio")
    End Sub

    Private Sub apelidoTxt_Enter(sender As Object, e As EventArgs) Handles apelidoTxt.Enter
        PlaceholderEnter(apelidoTxt, "Apelido")
    End Sub

    Private Sub apelidoTxt_Leave(sender As Object, e As EventArgs) Handles apelidoTxt.Leave
        PlaceholderLeave(apelidoTxt, "Apelido")
    End Sub

    Private Sub biTxt_Enter(sender As Object, e As EventArgs) Handles biTxt.Enter
        PlaceholderEnter(biTxt, "Numero de BI ou Passaporte")
    End Sub

    Private Sub biTxt_Leave(sender As Object, e As EventArgs) Handles biTxt.Leave
        PlaceholderLeave(biTxt, "Numero de BI ou Passaporte")
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        PlaceholderEnter(TextBox1, "Local de emissao")
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        PlaceholderLeave(TextBox1, "Local de emissao")
    End Sub


    Private Sub moradaTxt_Enter(sender As Object, e As EventArgs) Handles moradaTxt.Enter
        PlaceholderEnter(moradaTxt, "Morada: Maputo, Matola, C700, Casa 233")
    End Sub

    Private Sub moradaTxt_Leave(sender As Object, e As EventArgs) Handles moradaTxt.Leave
        PlaceholderLeave(moradaTxt, "Morada: Maputo, Matola, C700, Casa 233")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If contacto >= 0 Then
            If contacto = 5 Then
                c1 = "+258" & telefoneTxt.Text
                MessageBox.Show("Podes adicionar ate no maximo 5 contactos")
            End If
            If contacto = 4 Then
                c2 = "+258" & telefoneTxt.Text
            End If
            If contacto = 3 Then
                c3 = "+258" & telefoneTxt.Text
            End If
            If contacto = 2 Then
                c4 = "+258" & telefoneTxt.Text
            End If
            If contacto = 1 Then
                c5 = "+258" & telefoneTxt.Text
            End If
            contacto = contacto - 1
            telefoneTxt.Text = ""
            numeroLabel.Visible = False
        End If
        If contacto <= 0 Then
            telefoneTxt.Enabled = False
            Button4.Enabled = False
            isNumberPhoneValide = True
        End If
    End Sub

    Private Sub limparButton_Click(sender As Object, e As EventArgs) Handles limparButton.Click
        telefoneTxt.Text = ""
        TextBox1.Text = ""
        emailTxt.Text = ""
        nomeTxt.Text = ""
        apelidoTxt.Text = ""
        radioDoutorado.Checked = False
        radioEstrangeiro.Checked = False
        radioFeminino.Checked = False
        radioMasculinio.Checked = False
        nivelPicker.Value = 0
        nrInscricaoTxt.Text = ""
        moradaTxt.Text = ""
        biTxt.Text = ""
        radioMestrado.Checked = False
        radioNacional.Checked = False
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("@gmail.com")
        ComboBox2.Items.Add("@hotmail.com")
        ComboBox2.Items.Add("@outlook.com")
        ComboBox2.Items.Add("@yahoo.com")
        ComboBox2.Items.Add("@icloud.com")
        ComboBox2.Items.Add("@gamail.com")
        ComboBox2.SelectedIndex = ComboBox2.FindStringExact("@gmail.com")
    End Sub

    Private Sub confirmarButton_Click(sender As Object, e As EventArgs) Handles confirmarButton.Click
        ValidacaoParaBaseDeDados()
    End Sub

    Private Sub emailTxt_Enter(sender As Object, e As EventArgs) Handles emailTxt.Enter
        PlaceholderEnter(emailTxt, "Email: exemplo")
    End Sub

    Private Sub emailTxt_Leave(sender As Object, e As EventArgs) Handles emailTxt.Leave
        PlaceholderLeave(emailTxt, "Email: exemplo")
    End Sub

    Private Sub telefoneTxt_Enter(sender As Object, e As EventArgs) Handles telefoneTxt.Enter
        PlaceholderEnter(telefoneTxt, "847123432")
    End Sub

    Private Sub telefoneTxt_Leave(sender As Object, e As EventArgs) Handles telefoneTxt.Leave
        PlaceholderLeave(telefoneTxt, "847123432")
    End Sub



    Private Sub radioDoutorado_CheckedChanged(sender As Object, e As EventArgs) Handles radioDoutorado.CheckedChanged
        If radioDoutorado.Checked = True Then
            nivelPicker.Enabled = True
            Label12.Visible = False
            categoria = radioDoutorado.Text
        End If
    End Sub

    '======================================================================================================================
    '=====================================>| Primeira camada de verificação dos campos|<===================================
    '======================================================================================================================

    Private Sub apelidoTxt_TextChanged(sender As Object, e As EventArgs) Handles apelidoTxt.TextChanged
        If (apelidoTxt.Text <> "" And apelidoTxt.Text <> "Apelido") And apelidoTxt.Text.Length >= 3 Then
            isLastNameValide = True
            apelidoLabel.Visible = False
        ElseIf apelidoTxt.Text = "Apelido" Or apelidoTxt.Text = "" Then
            isLastNameValide = False
            apelidoLabel.Visible = False
        ElseIf apelidoTxt.Text <> "Apelido" And apelidoTxt.Text.Length < 3 Then
            isLastNameValide = False
            apelidoLabel.Visible = True
        End If
    End Sub

    Private Sub dataNascimentoPicker_ValueChanged(sender As Object, e As EventArgs) Handles dataNascimentoPicker.ValueChanged
        If dataNascimentoPicker.Value.Year <= (currentYear - 18) Then
            isDateOfBirthValide = True
            Label15.Visible = False
        ElseIf dataNascimentoPicker.Value.Year = currentYear Then
            isDateOfBirthValide = False
            Label15.Visible = True
        Else
            isDateOfBirthValide = False
            Label15.Visible = True
        End If
    End Sub

    Private Sub biTxt_TextChanged(sender As Object, e As EventArgs) Handles biTxt.TextChanged
        If (biTxt.Text <> "" And biTxt.Text <> "Numero de BI ou Passaporte") And biTxt.Text.Length >= 9 Then
            Try
                Dim ABCDario() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", " U", "V", "W", "X", "Y", "Z"}
                If biTxt.Text.Length = 9 Then
                    Convert.ToInt64(biTxt.Text.Substring(2))
                    For Each value As String In ABCDario
                        If value = biTxt.Text.Substring(0, 1).ToUpper() Then
                            isFirstLabel = True
                        End If
                        If value = biTxt.Text.Substring(1, 2).ToUpper() Then
                            isSecondLabel = True
                        End If

                    Next
                ElseIf biTxt.Text.Length = 13 Then

                    Convert.ToInt64(biTxt.Text.Substring(0, 12))
                    For Each value As String In ABCDario
                        If value = biTxt.Text.Substring(12).ToUpper() Then
                            isLastLabel = True
                        End If

                    Next
                End If

                If isLastLabel Or (isFirstLabel And isSecondLabel) Then
                    biLabel.Visible = False
                    isIdValide = True
                Else
                    biLabel.Visible = True
                    isIdValide = False
                End If

            Catch ex As Exception
                isIdValide = False
                biLabel.Visible = True
            End Try

        ElseIf biTxt.Text = "Numero de BI ou Passaporte" Or biTxt.Text = "" Then
            isIdValide = False
            biLabel.Visible = False
        ElseIf biTxt.Text <> "Numero de BI ou Passaporte" And biTxt.Text.Length < 9 Then
            isIdValide = False
            biLabel.Visible = True
        End If
    End Sub

    Private Sub biEmissaoPicker_ValueChanged(sender As Object, e As EventArgs) Handles biEmissaoPicker.ValueChanged
        If biEmissaoPicker.Value.Year <= currentYear Then
            isEmissionDateIdValide = True
            Label16.Visible = False
        Else
            isEmissionDateIdValide = False
            Label16.Text = "Data invalida ❌!"
            Label16.Visible = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If (TextBox1.Text <> "" And TextBox1.Text <> "Local de emissao") And TextBox1.Text.Length >= 3 Then
            isAddressIdValide = True
            emissaoLabel.Visible = False

        ElseIf TextBox1.Text = "Local de emissao" Then
            isAddressIdValide = False
        ElseIf TextBox1.Text <> "Local de emissao" And TextBox1.Text.Length < 3 Then
            isAddressIdValide = False
            emissaoLabel.Visible = True
        End If
    End Sub

    Private Sub radioFeminino_CheckedChanged(sender As Object, e As EventArgs) Handles radioFeminino.CheckedChanged
        If radioFeminino.Checked Then
            isFemTrue = True
            generoLabel.Visible = False
            genero = radioFeminino.Text
        Else
            isFemTrue = False
        End If
    End Sub
    Private Sub moradaTxt_TextChanged(sender As Object, e As EventArgs) Handles moradaTxt.TextChanged
        If (moradaTxt.Text <> "" And moradaTxt.Text <> "Morada: Maputo, Matola, C700, Casa 233") And moradaTxt.Text.Length >= 3 Then
            isAddressValide = True
            moradaLabel.Visible = False
        ElseIf moradaTxt.Text = "Morada: Maputo, Matola, C700, Casa 233" Then
            moradaLabel.Visible = False
            isAddressValide = False
        ElseIf moradaTxt.Text <> "Morada: Maputo, Matola, C700, Casa 233" And moradaTxt.Text.Length < 3 Then
            isAddressValide = False
            moradaLabel.Visible = True
        End If
    End Sub

    Private Sub telefoneTxt_TextChanged(sender As Object, e As EventArgs) Handles telefoneTxt.TextChanged
        If (telefoneTxt.Text <> "" And telefoneTxt.Text <> "847123432") And telefoneTxt.Text.Length = 9 Then
            Try
                Convert.ToInt64(telefoneTxt.Text)
                numeroLabel.Text = "Click no botao para adicionar"
                numeroLabel.Location = New Point(100, 224)
                isNumberPhoneValide = True

            Catch ex As Exception
                numeroLabel.Visible = True
                isNumberPhoneValide = False
            End Try

        ElseIf telefoneTxt.Text.Length > 9 Or telefoneTxt.Text.Length < 9 Then

            numeroLabel.Visible = True
            numeroLabel.Text = "numero invalido ❌!"
            numeroLabel.Location = New Point(100, 180)
        Else
            numeroLabel.Visible = True
            numeroLabel.Text = "Digita o contacto!"
            numeroLabel.Location = New Point(100, 180)
        End If
    End Sub

    Private Sub emailTxt_TextChanged(sender As Object, e As EventArgs) Handles emailTxt.TextChanged
        If (emailTxt.Text <> "" And emailTxt.Text <> "Email: exemplo") And emailTxt.Text.Length >= 3 Then
            isEmailValide = True
            emailLabel.Visible = False
            email = emailTxt.Text & "" & ComboBox2.SelectedItem.ToString
        ElseIf emailTxt.Text = "Email: exemplo" Then
            isEmailValide = False
        ElseIf emailTxt.Text <> "Email: exemplo" And emailTxt.Text.Length < 3 Then
            isEmailValide = False
            emailLabel.Visible = True
        End If
    End Sub


    Private Sub radioNacional_CheckedChanged(sender As Object, e As EventArgs) Handles radioNacional.CheckedChanged
        If radioNacional.Checked Then
            isNationalTrue = True
            Label13.Visible = False
            tipoDeEstudante = radioNacional.Text
        Else
            isNationalTrue = False
            tipoDeEstudante = ""
        End If
    End Sub


    Private Sub radioEstrangeiro_CheckedChanged(sender As Object, e As EventArgs) Handles radioEstrangeiro.CheckedChanged
        If radioNacional.Checked Then
            isForeignTrue = True
            Label13.Visible = False
            tipoDeEstudante = radioNacional.Text
        Else
            isForeignTrue = False
            tipoDeEstudante = ""
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value.Year > currentYear Then
            isExpiryDateIdValide = True
            Label17.Visible = False
        ElseIf DateTimePicker1.Value.Year = currentYear Then
            Label17.Visible = False
        Else

            isExpiryDateIdValide = False
            Label17.Text = "Data invalida ❌!"
            Label17.Visible = True
        End If
    End Sub

    Private Sub nrInscricaoTxt_TextChanged(sender As Object, e As EventArgs) Handles nrInscricaoTxt.TextChanged
        If (nrInscricaoTxt.Text <> "" And nrInscricaoTxt.Text <> "Informe do numero do precesso ❌!") And nrInscricaoTxt.Text.Length >= 4 Then
            Try
                Convert.ToInt32(nrInscricaoTxt.Text)
                isProcessNumberValide = True
                Label14.Visible = False
            Catch ex As Exception
                Label14.Visible = True
                isProcessNumberValide = False
            End Try

        ElseIf nrInscricaoTxt.Text = "" Then
            Label14.Visible = False
            isProcessNumberValide = False
        ElseIf nrInscricaoTxt.Text <> "Informe o numero do precesso ❌!" And nrInscricaoTxt.Text.Length < 4 Then
            Label14.Visible = True
            isProcessNumberValide = False
        Else
            Label14.Visible = False
        End If
    End Sub

    Private Sub nomeTxt_TextChanged(sender As Object, e As EventArgs) Handles nomeTxt.TextChanged
        If (nomeTxt.Text <> "" And nomeTxt.Text <> "Nome") And nomeTxt.Text.Length >= 3 Then
            isNameValide = True
            nomeLabel.Visible = False

        ElseIf nomeTxt.Text = "Nome" Then
            isNameValide = False
        ElseIf nomeTxt.Text <> "Nome" And nomeTxt.Text.Length < 3 Then
            isNameValide = False
            nomeLabel.Visible = True
        End If
    End Sub

    Private Sub radioMasculinio_CheckedChanged(sender As Object, e As EventArgs) Handles radioMasculinio.CheckedChanged
        If radioMasculinio.Checked Then
            generoLabel.Visible = False
            isMascTrue = True
            genero = radioMasculinio.Text
        Else
            generoLabel.Visible = True
            isMascTrue = False
        End If
    End Sub
    Public Sub ValidacaoParaBaseDeDados()
        If isEmissionDateIdValide And isExpiryDateIdValide And isNameValide And isDateOfBirthValide And isAddressValide And isAddressIdValide And isIdValide And isLastNameValide And isEmailValide And isNumberPhoneValide Then
            Dim val As DialogResult
            val = MessageBox.Show("Tens certeza que deseja prosseguir?", "Confirmacao", MessageBoxButtons.YesNo)

            If val = DialogResult.Yes Then
                Try
                    sql = "SELECT NUMERO_DO_PROCESSO FROM Estudante WHERE NUMERO_DO_PROCESSO = '" & nrInscricaoTxt.Text & "'"
                    commandSql.CommandText = sql
                    Dim leitorDataReader As MysqlDataReader = commandSql.ExecuteReader()

                    If leitorDataReader.Read() Then
                        MessageBox.Show("Estudanteo ja esta resgistado")
                    Else
                        leitorDataReader.Close()
                        Try
                            sql = "INSERT INTO Estudante(ID, NUMERO_DO_PROCESSO, Nome_do_Estudante, IDADE, TIPO_DE_ESTUDANTE, GENERO, MORADA, CATEGORIA, NIVEL, EMAIL) VALUES('" & biTxt.Text & "', '" & nrInscricaoTxt.Text & "', '" & nomeTxt.Text & " " & apelidoTxt.Text & "', '" & dataNascimentoPicker.Value.ToString & "', '" & tipoDeEstudante & "', '" & genero & "','" & moradaTxt.Text & "', '" & categoria & "', '" & CInt(nivelPicker.Value) & "', '" & emailTxt.Text & "')"

                            commandSql.CommandText = sql
                            Adapter.SelectCommand = commandSql
                            Adapter.Fill(dados)

                            sql = "INSERT INTO Contacto_Do_Estudante(CONT1, CONT2, CONT3, CONT4, CONT5, NUMERO_DO_PROCESSO) VALUES('" & c1 & "', '" & c2 & "', '" & c3 & "', '" & c4 & "','" & c5 & "','" & nrInscricaoTxt.Text & "')"
                            commandSql.CommandText = sql

                            Adapter.SelectCommand = commandSql
                            Adapter.Fill(dados)

                            sql = "INSERT INTO Identidade_Do_Estudante(DATA_DE_EMISSAO, DATA_DE_VALIDADE, LOCAL_DE_EMISSAO, NUMERO_DO_PROCESSO) VALUES('" & biEmissaoPicker.Value.ToString & "', '" & DateTimePicker1.Value.ToString & "', '" & TextBox1.Text & "', '" & nrInscricaoTxt.Text & "')"
                            commandSql.CommandText = sql

                            Adapter.SelectCommand = commandSql
                            Adapter.Fill(dados)

                            MessageBox.Show("Operação Com Exito!")
                            leitorDataReader.Close()


                        Catch ex As Exception
                            MessageBox.Show("Operação sem exito 3" & ex.Message)
                        End Try
                    End If

                Catch ex As Exception
                    MessageBox.Show("Erro ao tentar pesquisar ID " & ex.Message)

                End Try

            Else
                MessageBox.Show("Cancelado!")
            End If
        Else
            MessageBox.Show("Preencha os campos corretamente!")
        End If
    End Sub
End Class