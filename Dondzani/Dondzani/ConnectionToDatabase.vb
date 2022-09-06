Imports MySql.Data.MySqlClient
Module ConnectionToDatabase
    Public Conexao As New MySqlConnection
    Public commandSql As MySqlCommand
    Public Adapter As New MySqlDataAdapter
    Public leitorDataReader As MySqlDataReader
    Public sql As String
    Public dados As New DataTable
    Public isDatabaseEmpty As Boolean = False
    Public Sub Connecting()
        Try
            Conexao = New MySqlConnection
            sql = "Server =localhost;database=FEP;user id=root"
            Conexao.ConnectionString = sql
            Conexao.Open()
            commandSql = New MySqlCommand
            commandSql.Connection = Conexao

        Catch ex As MySqlException
            MessageBox.Show("Connection faild! " & ex.Message)
        End Try
        Root()
    End Sub

    'MÉTODO RESPONSÁVEL POR CRIAR AS TABELAS NA BASE DE DADOS
    Private Sub Root()

        Try
            Try
                'Criacao das tabelas
                sql = "CREATE TABLE IF NOT EXISTS  CadastroDeUsuario (BI VARCHAR(255), NOME VARCHAR(255) NOT NULL, OUTROS_NOMES VARCHAR(255), APELIDO VARCHAR(255) NOT NULL,  IDADE DATE,GENERO VARCHAR(100) DEFAULT 'ANONINO',  MORADA VARCHAR(200), EMAIL VARCHAR(255), PROFISSAO VARCHAR (255), IMG MEDIUMBLOB, CONSTRAINT pk_Cadastrar PRIMARY KEY(BI))"

                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)
                sql = "CREATE TABLE IF NOT EXISTS Identidade(DATA_DE_EMISSAO DATE, DATA_DE_VALIDADE DATE, LOCAL_DE_EMISSAO VARCHAR(255), BI VARCHAR(255), CONSTRAINT fk_Identidade FOREIGN KEY(BI) REFERENCES CadastroDeUsuario(BI) ON UPDATE CASCADE ON DELETE SET NULL)"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "CREATE TABLE IF NOT EXISTS Contacto(CONT1 VARCHAR(30) DEFAULT 'NONE', CONT2 VARCHAR(30) DEFAULT 'NONE', CONT3 VARCHAR(30) DEFAULT 'NONE', CONT4 VARCHAR(30) DEFAULT 'NONE', CONT5 VARCHAR(30) DEFAULT 'NONE', BI VARCHAR(20), CONSTRAINT fk_Cont FOREIGN KEY(BI) REFERENCES CadastroDeUsuario(BI) ON UPDATE CASCADE ON DELETE SET NULL)"

                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "CREATE TABLE IF NOT EXISTS Login(ID VARCHAR(255), USERNAME VARCHAR(255), PASSWORD VARCHAR(255), CATEGORIA VARCHAR(255) NOT NULL, BI VARCHAR(20), CONSTRAINT pk_logar PRIMARY KEY(ID), CONSTRAINT fk_Log FOREIGN KEY(BI) REFERENCES CadastroDeUsuario(BI) ON UPDATE CASCADE ON DELETE SET NULL)"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "CREATE TABLE IF NOT EXISTS Recuperar (Q1 VARCHAR(200), Q2 VARCHAR(200), Q3 VARCHAR(200), R1 VARCHAR(100), R2 VARCHAR(100), R3 VARCHAR(100), ID VARCHAR(20), CONSTRAINT fk_Recuperar FOREIGN KEY(ID) REFERENCES Login(ID) ON UPDATE CASCADE ON DELETE SET NULL)"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "CREATE TABLE IF NOT EXISTS Estudante (ID VARCHAR(255) UNIQUE, NUMERO_DO_PROCESSO VARCHAR(255) UNIQUE, Nome_do_Estudante VARCHAR(255), IDADE DATE, TIPO_DE_ESTUDANTE VARCHAR(100), GENERO VARCHAR(100), MORADA VARCHAR(255), CATEGORIA VARCHAR(255), NIVEL SMALLINT, EMAIL VARCHAR(255), CONSTRAINT pk_Est PRIMARY KEY(NUMERO_DO_PROCESSO))"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "CREATE TABLE IF NOT EXISTS Contacto_Do_Estudante(CONT1 VARCHAR(30) DEFAULT 'NONE', CONT2 VARCHAR(30) DEFAULT 'NONE', CONT3 VARCHAR(30) DEFAULT 'NONE', CONT4 VARCHAR(30) DEFAULT 'NONE', CONT5 VARCHAR(30) DEFAULT 'NONE', NUMERO_DO_PROCESSO VARCHAR(20), CONSTRAINT fk_EstCont FOREIGN KEY(NUMERO_DO_PROCESSO) REFERENCES Estudante(NUMERO_DO_PROCESSO) ON UPDATE CASCADE ON DELETE SET NULL)"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                sql = "CREATE TABLE IF NOT EXISTS Identidade_Do_Estudante(DATA_DE_EMISSAO DATE, DATA_DE_VALIDADE DATE, LOCAL_DE_EMISSAO VARCHAR(255), NUMERO_DO_PROCESSO VARCHAR(255), CONSTRAINT fk_IdentidadeEst FOREIGN KEY(NUMERO_DO_PROCESSO) REFERENCES Estudante(NUMERO_DO_PROCESSO))"
                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)

                'Tabela de pagamentos
                sql = "CREATE TABLE IF NOT EXISTS  Pagamento(ID BIGINT AUTO_INCREMENT, NUMERO_DE_TALAO BIGINT UNIQUE, DATA_DE_EMISSAO_DO_TALAO DATE, DATA_DO_PAGAMENTO DATE, IMPORTANCIA DOUBLE, NUMERO_DO_PROCESSO VARCHAR(255), CONSTRAINT pk_Pag PRIMARY KEY(ID), CONSTRAINT fk_Pagamento FOREIGN KEY(NUMERO_DO_PROCESSO) REFERENCES Estudante(NUMERO_DO_PROCESSO))"

                commandSql.CommandText = sql
                Adapter.SelectCommand = commandSql
                Adapter.Fill(dados)
            Catch ex As MySqlException
                MessageBox.Show("Erro ao tentar criar tabelas " & ex.Message)
            End Try

            '----------------I M P O R T A N T E-------------
            '----------------S E G U R A N C A--------------

            'Busca pela base de dados
            sql = "SELECT  USERNAME, PASSWORD, CATEGORIA FROM Login"
            commandSql.CommandText = sql
            Dim leitorDataReader1 As MySqlDataReader = commandSql.ExecuteReader()

            If leitorDataReader1.Read() = False Then
                isDatabaseEmpty = True
                MessageBox.Show("crie uma conta de administrador")
            End If
            leitorDataReader1.Close()

        Catch ex As Exception
            MessageBox.Show("error! " & ex.Message)
        End Try
    End Sub
End Module
