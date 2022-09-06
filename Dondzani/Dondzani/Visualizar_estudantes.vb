Public Class Visualizar_estudantes
    Private Sub voltarButton_Click(sender As Object, e As EventArgs) Handles voltarButton.Click
        Display.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'VISUALIZA TODOS
        If ComboBox1.SelectedIndex = 0 Then
            Visualizar()

        End If

        'VISUALIZA SOMENTE DE MESTRADO
        If ComboBox1.SelectedIndex = 1 Then
            VisualizarMestrado()
        End If

        'VISUALIZA SOMENTE DE DOUTORADO
        If ComboBox1.SelectedIndex = 2 Then
            VisualizarDoutoramento()
        End If


    End Sub

    Private Sub Visualizar_estudantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Todos estudantes")
        ComboBox1.Items.Add("Somente Mestrado")
        ComboBox1.Items.Add("Somente Doutorado")
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub Visualizar()
        Try
            'QUERY QUE BUSCA DADOS NA BASE DE DADOS

            sql = "SELECT estudante.ID, estudante.NUMERO_DO_PROCESSO, estudante.Nome_do_Estudante, estudante.IDADE, estudante.TIPO_DE_ESTUDANTE, identidade.DATA_DE_EMISSAO, identidade.DATA_DE_VALIDADE, identidade.LOCAL_DE_EMISSAO, estudante.GENERO, estudante.MORADA, estudante.CATEGORIA, estudante.NIVEL, estudante.EMAIL, contacto.CONT1, contacto.CONT2 FROM estudante INNER JOIN (identidade INNER JOIN contacto ON identidade.BI = contacto.BI)"

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

    Private Sub VisualizarMestrado()
        Try
            'QUERY QUE BUSCA SOMENTE ESTUDANTES DE MESTRADO

            sql = "SELECT estudante.ID, estudante.NUMERO_DO_PROCESSO, estudante.Nome_do_Estudante, estudante.IDADE, estudante.TIPO_DE_ESTUDANTE, identidade.DATA_DE_EMISSAO, identidade.DATA_DE_VALIDADE, identidade.LOCAL_DE_EMISSAO, estudante.GENERO, estudante.MORADA, estudante.CATEGORIA, estudante.NIVEL, estudante.EMAIL, contacto.CONT1, contacto.CONT2 FROM estudante INNER JOIN (identidade INNER JOIN contacto ON identidade.BI = contacto.BI) WHERE estudante.CATEGORIA = 'Mestrado'"

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

    Private Sub VisualizarDoutoramento()
        Try
            'QUERY QUE BUSCA SOMENTE ESTUDANTES DE DOUTORAMENTO

            sql = "SELECT estudante.ID, estudante.NUMERO_DO_PROCESSO, estudante.Nome_do_Estudante, estudante.IDADE, estudante.TIPO_DE_ESTUDANTE, identidade.DATA_DE_EMISSAO, identidade.DATA_DE_VALIDADE, identidade.LOCAL_DE_EMISSAO, estudante.GENERO, estudante.MORADA, estudante.CATEGORIA, estudante.NIVEL, estudante.EMAIL, contacto.CONT1, contacto.CONT2 FROM estudante INNER JOIN (identidade INNER JOIN contacto ON identidade.BI = contacto.BI) WHERE estudante.CATEGORIA = 'Doutorado'"

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

End Class