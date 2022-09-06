Imports MySql.Data.MySqlClient
Imports System.IO
Public Class BasicViewUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Display.Show()
        Display.userPanel.Visible = True
        Me.Close()
    End Sub

    Private Sub BasicViewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Visualizar()
    End Sub
    Private Sub Visualizar()
        Try
            sql = "SELECT cadastrodeusuario.BI, CadastroDeUsuario.NOME, CadastroDeUsuario.OUTROS_NOMES, CadastroDeUsuario.Apelido, CadastroDeUsuario.IDADE, CadastroDeUsuario.GENERO, CadastroDeUsuario.MORADA, CadastroDeUsuario.PROFISSAO, Login.CATEGORIA, Contacto.CONT1, Contacto.CONT2, Contacto.CONT3, CadastroDeUsuario.EMAIL FROM CadastroDeUsuario INNER JOIN (Login INNER JOIN Contacto ON Login.BI = Contacto.BI) ON CadastroDeUsuario.BI = Login.BI"
            commandSql.CommandText = sql
            Adapter.SelectCommand = commandSql
            dados.Clear()
            Adapter.Fill(dados)
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = dados
        Catch ex As Exception
            MessageBox.Show("Operacao mal sucedida " & ex.Message)
        End Try
    End Sub

    Private Sub voltarButton_Click(sender As Object, e As EventArgs) Handles voltarButton.Click
        ViewUser.Show()
        Me.Close()
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

    End Sub
End Class