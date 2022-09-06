Imports System.IO
Imports MySql.Data.MySqlClient

Imports Dondzani.Login
Public Class CadastroDeUsuario
    Dim fs As FileStream
    Dim br As BinaryReader
    Dim nomeArquivoImagem As String
    Dim isPasswordValide, isUserValide, isPasswordVerifiedCorrectly, isMascTrue, isEmissionDateIdValide, isExpiryDateIdValide, isFemTrue, isNameValide, isDateOfBirthValide, isAddressValide, isAddressIdValide, isIdValide, isProfessionValide, isOutherNamesValide, isLastNameValide, isAdminTrue, isUserTrue, isEmailValide, isNumberPhoneValide, isAnswerValide, isLastLabel As Boolean
    Dim login As Boolean = False
    Dim bye As Boolean = False
    Private Pergunta, contacto As Integer
    Private PerfilImage As Image
    Private P1, P2, P3, P4, R4, R1, R2, R3, c1, c2, c3, c4, c5, genero, email, categoria As String

    Private Sub nomeTxt_TextChanged(sender As Object, e As EventArgs) Handles nomeTxt.TextChanged
        If (nomeTxt.Text <> "" And nomeTxt.Text <> "Outros Nomes") And nomeTxt.Text.Length >= 3 Then
            isOutherNamesValide = True
            sobrenomeLabel.Visible = False
        ElseIf nomeTxt.Text = "Outros Nomes" Then
            isOutherNamesValide = False
        ElseIf nomeTxt.Text <> "Outros Nomes" And nomeTxt.Text.Length < 3 Then
            isOutherNamesValide = False
            sobrenomeLabel.Visible = True
        End If
    End Sub

    Private Sub apelidoTxt_TextChanged(sender As Object, e As EventArgs) Handles apelidoTxt.TextChanged
        If (apelidoTxt.Text <> "" And apelidoTxt.Text <> "Apelido") And apelidoTxt.Text.Length >= 3 Then
            isLastNameValide = True
            apelidoLabel.Visible = False
        ElseIf apelidoTxt.Text = "Apelido" Then
            isLastNameValide = False
        ElseIf apelidoTxt.Text <> "Apelido" And apelidoTxt.Text.Length < 3 Then
            isLastNameValide = False
            apelidoLabel.Visible = True
        End If
    End Sub

    Private Sub dataNascimentoPicker_ValueChanged(sender As Object, e As EventArgs) Handles dataNascimentoPicker.ValueChanged
        If dataNascimentoPicker.Value.Year <= 2004 Then
            isDateOfBirthValide = True
            dataNascimentoPicker.CalendarMonthBackground = SystemColors.MenuHighlight
        ElseIf dataNascimentoPicker.Value.Year = 2022 Then
            isDateOfBirthValide = False
        Else
            isDateOfBirthValide = False
        End If
    End Sub

    Private Sub biTxt_TextChanged(sender As Object, e As EventArgs) Handles biTxt.TextChanged
        If (biTxt.Text <> "" And biTxt.Text <> "Numero de BI: 100100101102H") And biTxt.Text.Length >= 13 Then
            Try
                Convert.ToInt64(biTxt.Text.Substring(0, 12))
                Dim ABCDario() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", " U", "V", "W", "X", "Y", "Z"}


                For Each value As String In ABCDario
                    If value = biTxt.Text.Substring(12).ToUpper() Then
                        isLastLabel = True
                    End If

                Next

                If isLastLabel Then
                    biLabel.Visible = False
                    isIdValide = True
                Else
                    biLabel.Visible = True
                    isIdValide = False
                End If

            Catch ex As Exception
                isIdValide = False
            End Try

        ElseIf biTxt.Text = "Numero de BI: 100100101102H" Then
            isIdValide = False
        ElseIf biTxt.Text <> "Numero de BI: 100100101102H" And biTxt.Text.Length < 13 Then
            isIdValide = False
            biLabel.Visible = True
            biLabel.Text = "BI invalido ❌!"
            biLabel.ForeColor = Color.Red
        End If
    End Sub

    Private Sub biEmissaoPicker_ValueChanged(sender As Object, e As EventArgs) Handles biEmissaoPicker.ValueChanged
        If biEmissaoPicker.Value.Year <= 2022 Then
            isEmissionDateIdValide = True
        Else
            isEmissionDateIdValide = False
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
            genero = ""
        End If
    End Sub

    Private Sub radioFeminino_CheckedChanged(sender As Object, e As EventArgs) Handles radioFeminino.CheckedChanged
        If radioFeminino.Checked Then
            isFemTrue = True
            generoLabel.Visible = False
            genero = radioFeminino.Text
        Else
            isFemTrue = False
            genero = ""
        End If
    End Sub

    Private Sub moradaTxt_TextChanged(sender As Object, e As EventArgs) Handles moradaTxt.TextChanged
        If (moradaTxt.Text <> "" And moradaTxt.Text <> "Morada: Maputo, Matola, C700, Casa 233") And moradaTxt.Text.Length >= 3 Then
            isAddressValide = True
            moradaLabel.Visible = False
        ElseIf moradaTxt.Text = "Morada: Maputo, Matola, C700, Casa 233" Then
            isAddressValide = False
        ElseIf moradaTxt.Text <> "Morada: Maputo, Matola, C700, Casa 233" And moradaTxt.Text.Length < 3 Then
            isAddressValide = False
            moradaLabel.Visible = True
        End If
    End Sub

    Private Sub telefoneTxt_TextChanged(sender As Object, e As EventArgs) Handles telefoneTxt.TextChanged
        If (telefoneTxt.Text <> "" And telefoneTxt.Text <> "847123432") And telefoneTxt.Text.Length >= 9 Then
            Try
                Convert.ToInt64(telefoneTxt.Text)
                numeroLabel.Visible = False
                isNumberPhoneValide = True

            Catch ex As Exception
                numeroLabel.Visible = True
                isNumberPhoneValide = False
            End Try
        Else
            numeroLabel.Visible = True
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If (TextBox2.Text <> "" And TextBox2.Text <> "Profissao") And TextBox2.Text.Length >= 4 Then
            isProfessionValide = True
            profissaoLabel.Visible = False
        ElseIf TextBox2.Text = "Profissao" Then
            isProfessionValide = False
        ElseIf TextBox2.Text <> "Profissao" And TextBox2.Text.Length < 4 Then
            isProfessionValide = False
            profissaoLabel.Visible = True
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

    Private Sub radioMasculino_CheckedChanged(sender As Object, e As EventArgs) Handles radioMasculinio.CheckedChanged
        If radioMasculinio.Checked Then
            generoLabel.Visible = False
            isMascTrue = True
            genero = radioMasculinio.Text
        Else
            generoLabel.Visible = True
            isMascTrue = False
        End If
    End Sub

    Private Sub radioDoutorado_CheckedChanged(sender As Object, e As EventArgs) Handles radioDoutorado.CheckedChanged
        If radioDoutorado.Checked Then
            contaLabel.Visible = False
            isUserTrue = True
            categoria = radioDoutorado.Text
        Else
            isUserTrue = False
            categoria = ""
        End If
    End Sub

    Private Sub radioMestrado_CheckedChanged(sender As Object, e As EventArgs) Handles radioMestrado.CheckedChanged
        If radioMestrado.Checked Then
            contaLabel.Visible = False
            isAdminTrue = True
            categoria = radioMestrado.Text
        Else
            contaLabel.Visible = False
            isAdminTrue = False
            categoria = ""
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

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text <> "" Then
            isAnswerValide = True
            respostaLabel.Visible = False
        ElseIf TextBox3.Text = "" Then
            isAnswerValide = False
        End If
    End Sub

    Private Sub voltarButton_Click(sender As Object, e As EventArgs) Handles voltarButton.Click
        Display.Show()
        Display.userPanel.Visible = True
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Display.Show()
        Me.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged


        If DateTimePicker1.Value.Year >= 2022 Then
            isExpiryDateIdValide = True
        Else
            isExpiryDateIdValide = False
        End If
    End Sub


    Private Sub nrInscricaoTxt_TextChanged(sender As Object, e As EventArgs) Handles nrInscricaoTxt.TextChanged
        If (nrInscricaoTxt.Text <> "" And nrInscricaoTxt.Text <> "Nome") And nrInscricaoTxt.Text.Length >= 3 Then
            isNameValide = True
            nomeLabel.Visible = False

        ElseIf nrInscricaoTxt.Text = "Nome" Then
            isNameValide = False
        ElseIf nrInscricaoTxt.Text <> "Nome" And nrInscricaoTxt.Text.Length < 3 Then
            isNameValide = False
            nomeLabel.Visible = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If (TextBox6.Text <> "" And TextBox6.Text <> "Username") And TextBox6.Text.Length >= 3 Then
            isUserValide = True
            usernameLabel.Visible = False
        ElseIf TextBox6.Text = "Username" Then
            isUserValide = False
        ElseIf TextBox6.Text <> "Username" And TextBox6.Text.Length < 3 Then
            isUserValide = False
            usernameLabel.Visible = True
        End If
    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If (TextBox5.Text <> "" And TextBox5.Text <> "Password") And TextBox5.Text.Length >= 8 Then
            isPasswordValide = True
            senhaLabel.Visible = False
        ElseIf TextBox5.Text = "Password" Then
            isPasswordValide = False
        ElseIf TextBox5.Text <> "Password" And TextBox5.Text.Length < 8 Then
            isPasswordValide = False
            senhaLabel.Visible = True

        End If
    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If (TextBox4.Text <> "" And TextBox4.Text <> "Repetir Password") And TextBox4.Text.Length >= 8 Then
            isPasswordVerifiedCorrectly = True
            senhaConfirmLabel.Visible = False
        ElseIf TextBox4.Text = "Repetir Password" Then
            isPasswordVerifiedCorrectly = False
            TextBox4.BackColor = SystemColors.Window
        ElseIf TextBox4.Text <> "Repetir Password" And TextBox4.Text.Length < 8 Then
            isPasswordVerifiedCorrectly = False
            senhaConfirmLabel.Visible = True

        End If
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Using OFD As New OpenFileDialog With {.Filter = "Image File(*.jpg; *.jpeg; *.png; *.bmp; *.gif)| *.jpg; *.jpeg; *.png; *.bmp; *.gif"}
        Try
            Dim OFD As New OpenFileDialog()
            OFD.Filter = "Image File(*.jpg; *.jpeg; *.png; *.bmp; *.gif)| *.jpg; *.jpeg; *.png; *.bmp; *.gif"
            If OFD.ShowDialog() = DialogResult.OK Then
                nomeArquivoImagem = OFD.FileName
                CirclePictireBox1.Image = Image.FromFile(OFD.FileName)
                CirclePictireBox1.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Desabilitando as Labels
    Private Sub DesabilitarLables()
        nomeLabel.Visible = False
        sobrenomeLabel.Visible = False
        apelidoLabel.Visible = False
        biLabel.Visible = False
        emissaoLabel.Visible = False
        moradaLabel.Visible = False
        emailLabel.Visible = False
        numeroLabel.Visible = False
        profissaoLabel.Visible = False
        usernameLabel.Visible = False
        senhaLabel.Visible = False
        senhaConfirmLabel.Visible = False
        peguntaLabel.Visible = False
        respostaLabel.Visible = False


    End Sub

    Private Sub CadastroDeUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        DesabilitarLables()
        Pergunta = 3
        contacto = 5
        P1 = ""
        P2 = ""
        P3 = ""
        ComboBox1.Items.Add("Escolha uma pergunta de reuperaccao")
        c1 = "NONE"
        c2 = "NONE"
        c3 = "NONE"
        c4 = "NONE"
        c5 = "NONE"
        genero = ""
        ComboBox1.Items.Add("Onde fez o ensino basico?")
        ComboBox1.Items.Add("Qual e o seu animal de instimacao favorito?")
        ComboBox1.Items.Add("Quem foi o seu primeiro amor?")
        ComboBox1.Items.Add("Com que idade perdeu a sua virgindade?")
        ComboBox1.SelectedIndex = ComboBox1.FindStringExact("Escolha uma pergunta de reuperaccao")
        TextBox3.Enabled = False
        Button3.Enabled = False

        ComboBox2.Items.Add("@gmail.com")
        ComboBox2.Items.Add("@hotmail.com")
        ComboBox2.Items.Add("@outlook.com")
        ComboBox2.Items.Add("@yahoo.com")
        ComboBox2.Items.Add("@icloud.com")
        ComboBox2.Items.Add("@gamail.com")
        ComboBox2.SelectedIndex = ComboBox2.FindStringExact("@gmail.com")
        email = ""
        categoria = ""
        isUserValide = False = isPasswordVerifiedCorrectly = isMascTrue = isEmissionDateIdValide = isExpiryDateIdValide = isFemTrue = isNameValide = isDateOfBirthValide = isAddressValide = isAddressIdValide = isIdValide = isProfessionValide = isOutherNamesValide = isLastNameValide = isAdminTrue = isUserTrue = isEmailValide = isNumberPhoneValide = isAnswerValide = isLastLabel = isPasswordValide = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex <> ComboBox1.FindStringExact("Escolha uma pergunta de reuperaccao") Then
            TextBox3.Enabled = True
            Button3.Enabled = True
            TextBox3.Focus()
        Else
            TextBox3.Enabled = False
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Pergunta >= 0 Then
            Dim val As DialogResult
            val = MessageBox.Show("Tens certeza que deseja prosseguir?", "Confirmacao", MessageBoxButtons.YesNo)

            If val = DialogResult.Yes Then
                MessageBox.Show("Responda mais " & Pergunta - 1 & " perguntas!")

                If (Pergunta - 1) = 2 Then
                    P1 = ComboBox1.SelectedItem.ToString()
                    R1 = TextBox3.Text
                    ComboBox1.Items.RemoveAt(ComboBox1.SelectedIndex)
                    ComboBox1.FindStringExact("Escolha uma pergunta de reuperaccao")
                ElseIf (Pergunta - 1) = 1 Then
                    P2 = ComboBox1.SelectedItem.ToString()
                    R2 = TextBox3.Text
                    ComboBox1.Items.RemoveAt(ComboBox1.SelectedIndex)
                    ComboBox1.FindStringExact("Escolha uma pergunta de reuperaccao")
                ElseIf (Pergunta - 1) = 0 Then
                    P3 = ComboBox1.SelectedItem.ToString()
                    R3 = TextBox3.Text
                    ComboBox1.Items.RemoveAt(ComboBox1.SelectedIndex)
                    ComboBox1.FindStringExact("Escolha uma pergunta de reuperaccao")
                End If
                Pergunta = Pergunta - 1
            Else
                MessageBox.Show("Cancelado!")
            End If
        End If
        If Pergunta <= 0 Then
            ComboBox1.Enabled = False
            TextBox3.Text = ""
            TextBox3.Enabled = False
            Button3.Enabled = False
            isAnswerValide = True
        End If
    End Sub

    Private Sub nrInscricaoTxt_Enter(sender As Object, e As EventArgs) Handles nrInscricaoTxt.Enter
        PlaceholderEnter(nrInscricaoTxt, "Nome")
    End Sub

    Private Sub nrInscricaoTxt_Leave(sender As Object, e As EventArgs) Handles nrInscricaoTxt.Leave
        PlaceholderLeave(nrInscricaoTxt, "Nome")
    End Sub
    Private Sub nomeTxt_Enter(sender As Object, e As EventArgs) Handles nomeTxt.Enter
        PlaceholderEnter(nomeTxt, "Outros Nomes")
    End Sub

    Private Sub nomeTxt_Leave(sender As Object, e As EventArgs) Handles nomeTxt.Leave
        PlaceholderLeave(nomeTxt, "Outros Nomes")
    End Sub
    Private Sub apelidoTxt_Enter(sender As Object, e As EventArgs) Handles apelidoTxt.Enter
        PlaceholderEnter(apelidoTxt, "Apelido")
    End Sub

    Private Sub apelidoTxt_Leave(sender As Object, e As EventArgs) Handles apelidoTxt.Leave
        PlaceholderLeave(apelidoTxt, "Apelido")
    End Sub
    Private Sub biTxt_Enter(sender As Object, e As EventArgs) Handles biTxt.Enter
        PlaceholderEnter(biTxt, "Numero de BI: 100100101102H")
    End Sub

    Private Sub biTxt_Leave(sender As Object, e As EventArgs) Handles biTxt.Leave
        PlaceholderLeave(biTxt, "Numero de BI: 100100101102H")
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

    Private Sub limparButton_Click(sender As Object, e As EventArgs) Handles limparButton.Click
        TextBox5.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        telefoneTxt.Text = ""
        moradaTxt.Text = ""
        nomeTxt.Text = ""
        nrInscricaoTxt.Text = ""
        biTxt.Text = ""
        apelidoTxt.Text = ""
        emailTxt.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Escolha uma pergunta de reuperaccao")
        ComboBox1.Items.Add("Onde fez o ensino basico?")
        ComboBox1.Items.Add("Qual e o seu animal de instimacao favorito?")
        ComboBox1.Items.Add("Quem foi o seu primeiro amor?")
        ComboBox1.Items.Add("Com que idade perdeu a sua virgindade?")
        ComboBox1.SelectedIndex = ComboBox1.FindStringExact("Escolha uma pergunta de reuperaccao")
    End Sub

    Private Sub confirmarButton_Click(sender As Object, e As EventArgs) Handles confirmarButton.Click
        Dim leitorDataReader, leitorDataReader1, leitorDataReader2 As MySqlDataReader
        Dim isPasswordConfirmed As Boolean = False
        If isPasswordValide And isPasswordVerifiedCorrectly Then
            If TextBox5.Text = TextBox4.Text Then
                isPasswordConfirmed = True
            Else
                isPasswordConfirmed = False
                TextBox4.BackColor = Color.OrangeRed
                TextBox5.BackColor = Color.OrangeRed
            End If
        End If
        If isPasswordConfirmed And isUserValide And isEmissionDateIdValide And isExpiryDateIdValide And isNameValide And isDateOfBirthValide And isAddressValide And isAddressIdValide And isIdValide And isProfessionValide And isOutherNamesValide And isLastNameValide And isEmailValide And isNumberPhoneValide And isAnswerValide Then
            Dim val As DialogResult
            val = MessageBox.Show("Tens certeza que deseja prosseguir?", "Confirmacao", MessageBoxButtons.YesNo)

            If val = DialogResult.Yes Then
                Try
                    sql = "SELECT BI FROM CadastroDeUsuario WHERE BI = '" & biTxt.Text & "'"
                    commandSql.CommandText = sql
                    leitorDataReader = commandSql.ExecuteReader()

                    If leitorDataReader.Read() Then
                        MessageBox.Show("Usuario ja existe")
                    Else
                        leitorDataReader.Close()
                        Try

                            sql = "SELECT PASSWORD FROM Login WHERE PASSWORD = '" & TextBox5.Text & "'"
                            commandSql.CommandText = sql

                            leitorDataReader1 = commandSql.ExecuteReader()
                            If leitorDataReader1.Read() Then
                                login = True
                                MessageBox.Show("Password invalido")
                                TextBox4.BackColor = Color.OrangeRed
                                TextBox5.BackColor = Color.OrangeRed
                            Else
                                If P1 = "" Or P2 = "" Or P3 = "" Then
                                    MessageBox.Show("E obrigatorio responder a 3 perguntas de recuperacao")
                                Else
                                    leitorDataReader1.Close()
                                    Try
                                        Dim NomeArquivoFoto As String = nomeArquivoImagem
                                        Dim DadosImagem() As Byte
                                        fs = New FileStream(NomeArquivoFoto, FileMode.Open, FileAccess.Read)
                                        br = New BinaryReader(fs)
                                        DadosImagem = br.ReadBytes(CType(fs.Length, Integer))
                                        br.Close()
                                        fs.Close()
                                        sql = "INSERT INTO CadastroDeUsuario(BI, NOME, OUTROS_NOMES, APELIDO, IDADE, GENERO, MORADA, EMAIL, PROFISSAO) VALUES('" & biTxt.Text & "', '" & nrInscricaoTxt.Text & "', '" & nomeTxt.Text & "', '" & apelidoTxt.Text & "', '" & dataNascimentoPicker.Value.ToString & "', '" & genero & "','" & moradaTxt.Text & "', '" & email & "', '" & TextBox2.Text & "')"

                                        commandSql.CommandText = sql
                                        Adapter.SelectCommand = commandSql
                                        Adapter.Fill(dados)

                                        sql = "UPDATE CadastroDeUsuario SET IMG = @IMG WHERE BI =  '" & biTxt.Text & "'"

                                        '==========================================================================================
                                        '================================>| CONEXAO A BASE DE DADOS |==============================
                                        '==========================================================================================

                                        Dim conex As New MySqlConnection("Server =localhost;database=FEP;user id=root")
                                        Dim cmd As New MySqlCommand(sql, conex)

                                        cmd.Parameters.Add("@IMG", MySqlDbType.Blob)
                                        cmd.Parameters("@IMG").Value = DadosImagem
                                        conex.Open()
                                        Dim linhasAfetadas As Integer = cmd.ExecuteNonQuery()
                                        If (linhasAfetadas > 0) Then
                                            MessageBox.Show("A imagem foi salva com sucesso !", "Salvar Imagem", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If

                                        sql = "INSERT INTO Contacto(CONT1,CONT2,CONT3,CONT4,CONT5,BI) VALUES('" & c1 & "', '" & c2 & "', '" & c3 & "', '" & c4 & "','" & c5 & "','" & biTxt.Text & "')"
                                        commandSql.CommandText = sql

                                        Adapter.SelectCommand = commandSql
                                        Adapter.Fill(dados)
                                        sql = "INSERT INTO Identidade(DATA_DE_EMISSAO,DATA_DE_VALIDADE,LOCAL_DE_EMISSAO,BI) VALUES('" & biEmissaoPicker.Value.ToString & "', '" & DateTimePicker1.Value.ToString & "', '" & TextBox1.Text & "', '" & biTxt.Text & "')"
                                        commandSql.CommandText = sql

                                        Adapter.SelectCommand = commandSql
                                        Adapter.Fill(dados)



                                        sql = "SELECT ID FROM Login WHERE ID = (SELECT MAX(ID) FROM Login)"
                                        commandSql.CommandText = sql
                                        leitorDataReader2 = commandSql.ExecuteReader()
                                        Dim logId As String = "login0"
                                        If leitorDataReader2.Read() Then
                                            logId = leitorDataReader2.Item("ID").ToString
                                        End If
                                        logId = logId.Substring(0, 5) & "" & (CInt(logId.Substring(5)) + 1).ToString

                                        leitorDataReader2.Close()
                                        sql = "INSERT INTO Login(ID,USERNAME,PASSWORD,CATEGORIA,BI) VALUES('" & logId & "', '" & TextBox6.Text & "', '" & TextBox5.Text & "', '" & categoria & "', '" & biTxt.Text & "')"
                                        commandSql.CommandText = sql

                                        Adapter.SelectCommand = commandSql
                                        Adapter.Fill(dados)

                                        sql = "INSERT INTO Recuperar(Q1,Q2,Q3,R1,R2,R3,ID) VALUES('" & P1 & "', '" & P2 & "', '" & P3 & "', '" & R1 & "', '" & R2 & "', '" & R3 & "', '" & logId & "')"
                                        commandSql.CommandText = sql

                                        Adapter.SelectCommand = commandSql
                                        Adapter.Fill(dados)

                                        MessageBox.Show("Operação Com Exito!")
                                        leitorDataReader.Close()
                                        leitorDataReader1.Close()
                                        leitorDataReader2.Close()
                                        If login Then
                                        Else
                                            bye = True
                                            Dondzani.Login.Show()
                                            Me.Close()
                                        End If
                                    Catch ex As Exception
                                        MessageBox.Show("Operação sem exito 3" & ex.Message)
                                    End Try
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Operação sem exito 2" & ex.Message)
                        End Try
                    End If
                Catch ex As Exception
                    MessageBox.Show("Operação sem exito 1 " & ex.Message)
                End Try
            Else
                MessageBox.Show("Cancelado!")
            End If
        Else
            MessageBox.Show("Preencha correctamente os dados!")
        End If
    End Sub

    Private Sub moradaTxt_Leave(sender As Object, e As EventArgs) Handles moradaTxt.Leave
        PlaceholderLeave(moradaTxt, "Morada: Maputo, Matola, C700, Casa 233")
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
    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        PlaceholderEnter(TextBox2, "Profissao")
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        PlaceholderLeave(TextBox2, "Profissao")
    End Sub
    Private Sub TextBox6_Enter(sender As Object, e As EventArgs) Handles TextBox6.Enter
        PlaceholderEnter(TextBox6, "Username")
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        PlaceholderLeave(TextBox6, "Username")
    End Sub
    Private Sub TextBox5_Enter(sender As Object, e As EventArgs) Handles TextBox5.Enter
        PlaceholderEnter(TextBox5, "Password")
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        PlaceholderLeave(TextBox5, "Password")
    End Sub
    Private Sub TextBox4_Enter(sender As Object, e As EventArgs) Handles TextBox4.Enter
        PlaceholderEnter(TextBox4, "Repetir Password")
    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        PlaceholderLeave(TextBox4, "Repetir Password")
    End Sub
End Class