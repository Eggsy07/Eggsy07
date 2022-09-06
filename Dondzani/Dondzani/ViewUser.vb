Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net.Mail

Public Class ViewUser
    Dim fs As FileStream
    Dim br As BinaryReader
    Dim nomeArquivoImagem As String
    Private PerfilImage As Image
    Dim isNumber2PhoneValide, isNumber1PhoneValide, isTypeSet, isEmissionDateIdValide, isExpiryDateIdValide, isNameValide, isAddressValide, isAddressIdValide, isProfessionValide, isLastNameValide, isEmailValide, isNumberPhoneValide As Boolean
    Private Sub pgInicialButton_Click(sender As Object, e As EventArgs) Handles pgInicialButton.Click
        Display.Show()
        Me.Close()
    End Sub

    Private Sub voltarButton_Click(sender As Object, e As EventArgs) Handles voltarButton.Click
        BasicViewUser.Show()
        Me.Close()

    End Sub

    Private Sub imagemButton_Click(sender As Object, e As EventArgs) Handles imagemButton.Click
        Using OFD As New OpenFileDialog With {.Filter = "Image File(*.jpg; *.jpeg; *.png; *.bmp; *.gif)| *.jpg; *.jpeg; *.png; *.bmp; *.gif"}
            If OFD.ShowDialog = DialogResult.OK Then
                PerfilImage = Image.FromFile(OFD.FileName)
                CirclePictireBox1.Image = PerfilImage
                CirclePictireBox1.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        End Using
    End Sub

    Private Sub ViewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Visualizar()
        emissaoDataLabel.Visible = False
        apelidoLabel.Visible = False
        validadeLabel.Visible = False
        alertaValidadeLabel.Visible = False
        emissaoLabel.Visible = False
        moradaLabel.Visible = False
        emailLabel.Visible = False
        profissaoLabel.Visible = False
        isTypeSet = False
        numero1Label.Visible = False
        numero2Label.Visible = False
        numeroLabel.Visible = False
        nameLabel.Visible = False

        isEmissionDateIdValide = False = isExpiryDateIdValide = isNameValide = isAddressValide = isAddressIdValide = isProfessionValide = isLastNameValide = isEmailValide = isNumberPhoneValide = isNumber2PhoneValide = isNumber1PhoneValide = False
    End Sub

    Private Sub Visualizar()
        Try
            'QUERY QUE BUSCA DADOS NA BASE DE DADOS

            sql = "SELECT cadastrodeusuario.BI, CadastroDeUsuario.NOME, CadastroDeUsuario.OUTROS_NOMES, CadastroDeUsuario.Apelido, CadastroDeUsuario.IDADE, CadastroDeUsuario.GENERO, CadastroDeUsuario.MORADA, CadastroDeUsuario.PROFISSAO, Login.CATEGORIA, Identidade.DATA_DE_EMISSAO, Identidade.DATA_DE_VALIDADE, Identidade.LOCAL_DE_EMISSAO, Contacto.CONT1, Contacto.CONT2, Contacto.CONT3, CadastroDeUsuario.EMAIL FROM CadastroDeUsuario INNER JOIN (Login INNER JOIN (Contacto INNER JOIN Identidade ON Contacto.BI = Identidade.BI) ON Login.BI = Contacto.BI) ON CadastroDeUsuario.BI = Login.BI"
            commandSql.CommandText = sql
            Adapter.SelectCommand = commandSql

            Dim datas As New DataTable
            Adapter.Fill(datas)
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = datas
        Catch ex As Exception
            MessageBox.Show("Operacao mal sucedida " & ex.Message)
        End Try
    End Sub

    Private Sub DirectUpload()
        Dim leitorDataReader As MySqlDataReader

        Try
            '====================================|ALERTA|=========================================
            '=========================> | CONEXAO A BASE DE DADOS | <=============================
            '=====================================================================================
            sql = "SELECT IMG FROM CadastroDeUsuario WHERE BI = '" & TextBox1.Text & "' OR EMAIL = '" & TextBox1.Text & "'"
            Dim conex As New MySqlConnection("Server =localhost;database=FEP;user id=root")
            Dim cmd As New MySqlCommand(sql, conex)
            conex.Open()
            Dim tempImage As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            Dim strArquivo As String = Convert.ToString(DateTime.Now.ToFileTime())
            Dim fs As New FileStream(strArquivo, FileMode.CreateNew, FileAccess.Write)
            fs.Write(tempImage, 0, tempImage.Length)
            fs.Flush()
            fs.Close()
            nomeArquivoImagem = strArquivo
            CirclePictireBox1.Image = Image.FromFile(strArquivo)
            CirclePictireBox1.SizeMode = PictureBoxSizeMode.StretchImage
            conex.Close()
            'QUERY QUE BUSCA DADOS NA BASE DE DADOS

            sql = "SELECT cadastrodeusuario.BI, CadastroDeUsuario.NOME, CadastroDeUsuario.OUTROS_NOMES, CadastroDeUsuario.Apelido, CadastroDeUsuario.IDADE, CadastroDeUsuario.GENERO, CadastroDeUsuario.MORADA, CadastroDeUsuario.PROFISSAO, Login.CATEGORIA, Identidade.DATA_DE_EMISSAO, Identidade.DATA_DE_VALIDADE, Identidade.LOCAL_DE_EMISSAO, Contacto.CONT1, Contacto.CONT2, Contacto.CONT3, CadastroDeUsuario.EMAIL FROM CadastroDeUsuario INNER JOIN (Login INNER JOIN (Contacto INNER JOIN Identidade ON Contacto.BI = Identidade.BI) ON Login.BI = Contacto.BI) ON CadastroDeUsuario.BI = Login.BI WHERE CadastroDeUsuario.BI = '" & TextBox1.Text & "' OR EMAIL = '" & TextBox1.Text & "'"
            commandSql.CommandText = sql
            leitorDataReader = commandSql.ExecuteReader()

            If leitorDataReader.Read() Then
                TextBox2.Text = leitorDataReader.Item("NOME").ToString
                TextBox3.Text = leitorDataReader.Item("OUTROS_NOMES").ToString
                TextBox4.Text = leitorDataReader.Item("APELIDO").ToString
                TextBox5.Text = leitorDataReader.Item("IDADE").ToString
                TextBox6.Text = leitorDataReader.Item("BI").ToString
                TextBox7.Text = leitorDataReader.Item("LOCAL_DE_EMISSAO").ToString
                TextBox8.Text = leitorDataReader.Item("GENERO").ToString
                TextBox9.Text = leitorDataReader.Item("MORADA").ToString
                TextBox10.Text = leitorDataReader.Item("EMAIL").ToString
                LinkLabel1.Text = leitorDataReader.Item("EMAIL").ToString
                TextBox11.Text = leitorDataReader.Item("DATA_DE_EMISSAO").ToString
                TextBox12.Text = leitorDataReader.Item("CONT3").ToString.Substring(4)
                TextBox13.Text = leitorDataReader.Item("PROFISSAO").ToString
                TextBox14.Text = leitorDataReader.Item("CATEGORIA").ToString
                TextBox15.Text = leitorDataReader.Item("DATA_DE_VALIDADE").ToString
                TextBox16.Text = leitorDataReader.Item("CONT2").ToString.Substring(4)
                TextBox17.Text = leitorDataReader.Item("CONT1").ToString.Substring(4)
                leitorDataReader.Close()
            End If
            leitorDataReader.Close()
        Catch ex As Exception
            MessageBox.Show("Operacao mal sucedida " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim id As String = DataGridView1.CurrentRow().Cells(0).Value.ToString

        '====================================|ALERTA|=========================================
        '=========================> | CONEXAO A BASE DE DADOS | <=============================
        '=====================================================================================
        sql = "SELECT IMG FROM CadastroDeUsuario WHERE BI = '" & id & "'"
        Dim conex As New MySqlConnection("Server =localhost;database=FEP;user id=root")
        Dim cmd As New MySqlCommand(sql, conex)
        conex.Open()
        Dim tempImage As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
        Dim strArquivo As String = Convert.ToString(DateTime.Now.ToFileTime())
        Dim fs As New FileStream(strArquivo, FileMode.CreateNew, FileAccess.Write)
        fs.Write(tempImage, 0, tempImage.Length)
        fs.Flush()
        fs.Close()
        CirclePictireBox1.Image = Image.FromFile(strArquivo)
        CirclePictireBox1.SizeMode = PictureBoxSizeMode.StretchImage
        conex.Close()

        TextBox2.Text = DataGridView1.CurrentRow().Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow().Cells(2).Value.ToString
        TextBox4.Text = DataGridView1.CurrentRow().Cells(3).Value.ToString
        TextBox5.Text = DataGridView1.CurrentRow().Cells(4).Value.ToString
        TextBox6.Text = DataGridView1.CurrentRow().Cells(0).Value.ToString
        TextBox7.Text = DataGridView1.CurrentRow().Cells(11).Value.ToString
        TextBox8.Text = DataGridView1.CurrentRow().Cells(5).Value.ToString
        TextBox9.Text = DataGridView1.CurrentRow().Cells(6).Value.ToString
        TextBox10.Text = DataGridView1.CurrentRow().Cells(15).Value.ToString
        TextBox11.Text = DataGridView1.CurrentRow().Cells(9).Value.ToString
        TextBox12.Text = DataGridView1.CurrentRow().Cells(14).Value.ToString
        TextBox13.Text = DataGridView1.CurrentRow().Cells(7).Value.ToString
        TextBox14.Text = DataGridView1.CurrentRow().Cells(8).Value.ToString
        TextBox15.Text = DataGridView1.CurrentRow().Cells(10).Value.ToString
        TextBox16.Text = DataGridView1.CurrentRow().Cells(13).Value.ToString
        TextBox17.Text = DataGridView1.CurrentRow().Cells(12).Value.ToString

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim leitorDataReader As MySqlDataReader
        Dim cmd As New MySqlCommand
        Dim isText, isNumber As Boolean

        If TextBox1.Text.Length >= 4 Then
            If TextBox1.Text.Length <= 12 Then
                Try
                    Dim number As Long = CLng(TextBox1.Text)
                    isNumber = True
                    isText = False
                Catch ex As Exception
                    isNumber = False
                    isText = True
                End Try
            End If
            sql = "SELECT BI, EMAIL FROM CadastroDeUsuario WHERE  BI LIKE '" & TextBox1.Text & "%' OR EMAIL LIKE '" & TextBox1.Text & "%'"
            Dim conex As New MySqlConnection("Server = localhost;Database = FEP; User id = root")
            conex.Open()
            cmd.Connection = conex
            cmd.CommandText = sql
            leitorDataReader = cmd.ExecuteReader()

            While leitorDataReader.Read()
                If isNumber Then
                    TextBox1.Text = leitorDataReader.Item("BI").ToString
                ElseIf isText Then
                    TextBox1.Text = leitorDataReader.Item("EMAIL").ToString
                End If
            End While
            leitorDataReader.Close()
            conex.Close()


        End If
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        PlaceholderEnter(TextBox1, "Busca por bi ou email")
        If TextBox1.Text <> "" And TextBox1.Text <> "Busca por bi ou email" Then
            DirectUpload()
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        PlaceholderLeave(TextBox1, "Busca por bi ou email")
    End Sub

    Private Sub pesquisaButton_Click(sender As Object, e As EventArgs) Handles pesquisaButton.Click
        DirectUpload()
    End Sub

    Private Sub actualizarButton_Click(sender As Object, e As EventArgs) Handles actualizarButton.Click
        If isNumber2PhoneValide And isNumber1PhoneValide And isTypeSet And isEmissionDateIdValide And isExpiryDateIdValide And isNameValide And isAddressValide And isAddressIdValide And isProfessionValide And isLastNameValide And isEmailValide And isNumberPhoneValide Then
            Dim val As DialogResult
            val = MessageBox.Show("Tens certeza que deseja prosseguir?", "Confirmacao", MessageBoxButtons.YesNo)

            If val = DialogResult.Yes Then
                Try
                    Dim NomeArquivoFoto As String = nomeArquivoImagem
                    Dim DadosImagem() As Byte
                    fs = New FileStream(NomeArquivoFoto, FileMode.Open, FileAccess.Read)
                    br = New BinaryReader(fs)
                    DadosImagem = br.ReadBytes(CType(fs.Length, Integer))
                    br.Close()
                    fs.Close()
                    sql = "UPDATE CadastroDeUsuario SET NOME = '" & TextBox2.Text & "', OUTROS_NOMES = '" & TextBox3.Text & "', APELIDO = '" & TextBox4.Text & "', MORADA = '" & TextBox9.Text & "', EMAIL = '" & TextBox10.Text & "', PROFISSAO = '" & TextBox13.Text & "' WHERE BI = '" & TextBox6.Text & "'"
                    commandSql.CommandText = sql
                    Adapter.SelectCommand = commandSql
                    Adapter.Fill(dados)
                    sql = "UPDATE CadastroDeUsuario SET IMG = @IMG WHERE BI =  '" & TextBox6.Text & "'"

                    '==========================================================================================
                    '================================>| CONEXAO A BASE DE DADOS |==============================
                    '==========================================================================================

                    Dim conex As New MySqlConnection("Server =localhost;database=FEP;user id=root")
                    conex.Open()
                    Dim cmd As New MySqlCommand(sql, conex)
                    cmd.Parameters.Add("@IMG", MySqlDbType.Blob)
                    cmd.Parameters("@IMG").Value = DadosImagem

                    Dim linhasAfetadas As Integer = cmd.ExecuteNonQuery()
                    If (linhasAfetadas > 0) Then
                        MessageBox.Show("A imagem foi salva com sucesso !", "Salvar Imagem", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    sql = "UPDATE Identidade SET DATA_DE_EMISSAO = '" & TextBox11.Text & "', DATA_DE_VALIDADE = '" & TextBox15.Text & "', LOCAL_DE_EMISSAO = '" & TextBox7.Text & "' WHERE BI = '" & TextBox6.Text & "'"
                    commandSql.CommandText = sql
                    Adapter.SelectCommand = commandSql
                    Adapter.Fill(dados)

                    sql = "UPDATE Contacto SET CONT1 = '+258" & TextBox17.Text & "', CONT2 = '+258" & TextBox16.Text & "', CONT3 = '+258" & TextBox12.Text & "' WHERE BI = '" & TextBox6.Text & "'"
                    commandSql.CommandText = sql

                    Adapter.SelectCommand = commandSql
                    Adapter.Fill(dados)

                    sql = "UPDATE Login SET CATEGORIA = '" & TextBox14.Text & "' WHERE BI = '" & TextBox6.Text & "'"
                    commandSql.CommandText = sql

                    Adapter.SelectCommand = commandSql
                    Adapter.Fill(dados)
                    DataGridView1.ClearSelection()
                    Visualizar()
                    MessageBox.Show("Dados atualizados com sucesso!")
                Catch ex As Exception
                    MessageBox.Show("Falha na base de dados! " & ex.Message)
                End Try
            Else
                MessageBox.Show("Operacao cancelada!")

            End If
        Else
            MessageBox.Show("Preencha os dados corretamente")
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text <> "" And TextBox2.Text.Length >= 3 Then
            isNameValide = True
            nameLabel.Visible = False
        Else
            isNameValide = False
            nameLabel.Visible = True
        End If
    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text <> "" And TextBox4.Text.Length >= 3 Then
            isLastNameValide = True
            apelidoLabel.Visible = False
        Else
            isLastNameValide = False
            apelidoLabel.Visible = True
        End If
    End Sub

    Private Sub apagarButton_Click(sender As Object, e As EventArgs) Handles apagarButton.Click
        Dim val As DialogResult
        val = MessageBox.Show("Tens certeza que deseja prosseguir?", "Confirmacao", MessageBoxButtons.YesNo)

        If val = DialogResult.Yes Then
            Try
                sql = "SELECT ID FROM LOGIN WHERE BI = '" & TextBox6.Text & "'"
                commandSql.CommandText = sql
                Dim leitorDataReader As MySqlDataReader = commandSql.ExecuteReader()
                Dim id As String = ""
                If leitorDataReader.Read() Then
                    id = leitorDataReader.Item("ID").ToString
                    leitorDataReader.Close()
                End If
                leitorDataReader.Close()
                sql = "DELETE FROM Recuperar WHERE ID = '" & id & "'"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "DELETE FROM Login WHERE BI = '" & TextBox6.Text & "'"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "DELETE FROM Contacto WHERE BI = '" & TextBox6.Text & "'"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "DELETE FROM Identidade WHERE BI = '" & TextBox6.Text & "'"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "DELETE FROM CadastroDeUsuario WHERE BI = '" & TextBox6.Text & "'"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)
                Visualizar()
                MessageBox.Show("Usuario eliminado com sucesso")
            Catch ex As Exception
                MessageBox.Show("Erro ao tentar apagar usuario " & ex.Message)
            End Try
        Else
            MessageBox.Show("Operacao Cancelada")
        End If
    End Sub

    Private Sub limparButton_Click(sender As Object, e As EventArgs) Handles limparButton.Click
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        Try
            If CInt(TextBox11.Text.Substring(0, 4)) <= 2022 Then
                isEmissionDateIdValide = True
                emissaoDataLabel.Visible = False
            Else
                isEmissionDateIdValide = False
                emissaoDataLabel.Visible = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox15_Leave(sender As Object, e As EventArgs) Handles TextBox15.Leave
        alertaValidadeLabel.Visible = False
    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        If CInt(TextBox15.Text.Substring(0, 4)) >= 2022 Then
            isExpiryDateIdValide = True
            validadeLabel.Visible = False
            alertaValidadeLabel.Visible = False
        Else
            isExpiryDateIdValide = False
            validadeLabel.Visible = True
            alertaValidadeLabel.Visible = True
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text <> "" And TextBox7.Text.Length >= 3 Then
            isAddressIdValide = True
            emissaoLabel.Visible = False
        Else
            isAddressIdValide = False
            emissaoLabel.Visible = True
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text <> "" And TextBox9.Text.Length >= 3 Then
            isAddressValide = True
            moradaLabel.Visible = False
        Else
            isAddressValide = False
            moradaLabel.Visible = True
        End If
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        If TextBox17.Text <> "" And TextBox17.Text.Length >= 9 Then
            Try
                Convert.ToInt64(TextBox17.Text)
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

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        If TextBox16.Text <> "" And TextBox16.Text.Length >= 9 Then
            Try
                Convert.ToInt64(TextBox16.Text)
                numero1Label.Visible = False
                isNumber1PhoneValide = True

            Catch ex As Exception
                numero1Label.Visible = True
                isNumber1PhoneValide = False
            End Try
        Else
            numero1Label.Visible = True
        End If
    End Sub
    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        If TextBox12.Text <> "" And TextBox12.Text.Length >= 9 Then
            Try
                Convert.ToInt64(TextBox12.Text)
                numero2Label.Visible = False
                isNumber2PhoneValide = True

            Catch ex As Exception
                numero2Label.Visible = True
                isNumber2PhoneValide = False
            End Try
        Else
            numero2Label.Visible = True
        End If
    End Sub


    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text <> "" And TextBox2.Text.Length >= 4 Then
            isProfessionValide = True
            profissaoLabel.Visible = False
        Else
            isProfessionValide = False
            profissaoLabel.Visible = True
        End If
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        If TextBox10.Text <> "" And TextBox10.Text.Length >= 3 Then
            isEmailValide = True
            emailLabel.Visible = False
        Else
            isEmailValide = False
            emailLabel.Visible = True
        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        If TextBox14.Text.ToUpper = "USER" Or TextBox14.Text.ToUpper = "ADMIN" Then
            contaLabel.Visible = False
            isTypeSet = True
        ElseIf TextBox14.Text <> "" And (TextBox14.Text.ToUpper = "USER" Or TextBox14.Text.ToUpper = "ADMIN") Then
            contaLabel.Visible = True
            isTypeSet = False
        End If
    End Sub
End Class