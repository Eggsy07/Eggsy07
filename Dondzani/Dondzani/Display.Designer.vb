<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Display
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Display))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.logoutButton = New System.Windows.Forms.Button()
        Me.usuarioButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.dashboardButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.aboutButton = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.pagamentoButton = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.processLabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.userPanel = New System.Windows.Forms.Panel()
        Me.viewButton = New System.Windows.Forms.Button()
        Me.addUsuarioButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.userPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.logoutButton)
        Me.Panel1.Controls.Add(Me.usuarioButton)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.addButton)
        Me.Panel1.Controls.Add(Me.dashboardButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(229, 461)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(54, 430)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Sair"
        '
        'logoutButton
        '
        Me.logoutButton.BackgroundImage = CType(resources.GetObject("logoutButton.BackgroundImage"), System.Drawing.Image)
        Me.logoutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.logoutButton.FlatAppearance.BorderSize = 0
        Me.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.logoutButton.Location = New System.Drawing.Point(3, 417)
        Me.logoutButton.Name = "logoutButton"
        Me.logoutButton.Size = New System.Drawing.Size(63, 42)
        Me.logoutButton.TabIndex = 12
        Me.logoutButton.UseVisualStyleBackColor = True
        '
        'usuarioButton
        '
        Me.usuarioButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.usuarioButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.usuarioButton.FlatAppearance.BorderSize = 0
        Me.usuarioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.usuarioButton.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usuarioButton.ForeColor = System.Drawing.Color.White
        Me.usuarioButton.Image = CType(resources.GetObject("usuarioButton.Image"), System.Drawing.Image)
        Me.usuarioButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.usuarioButton.Location = New System.Drawing.Point(0, 250)
        Me.usuarioButton.Name = "usuarioButton"
        Me.usuarioButton.Size = New System.Drawing.Size(229, 52)
        Me.usuarioButton.TabIndex = 11
        Me.usuarioButton.Text = "Usuarios"
        Me.usuarioButton.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button2.Location = New System.Drawing.Point(-1, 169)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(229, 52)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Visualizar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'addButton
        '
        Me.addButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.addButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.addButton.FlatAppearance.BorderSize = 0
        Me.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addButton.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addButton.ForeColor = System.Drawing.Color.White
        Me.addButton.Image = CType(resources.GetObject("addButton.Image"), System.Drawing.Image)
        Me.addButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.addButton.Location = New System.Drawing.Point(0, 85)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(229, 52)
        Me.addButton.TabIndex = 9
        Me.addButton.Text = "Adicionar"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'dashboardButton
        '
        Me.dashboardButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.dashboardButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dashboardButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.dashboardButton.FlatAppearance.BorderSize = 0
        Me.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.dashboardButton.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dashboardButton.ForeColor = System.Drawing.Color.White
        Me.dashboardButton.Image = CType(resources.GetObject("dashboardButton.Image"), System.Drawing.Image)
        Me.dashboardButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.dashboardButton.Location = New System.Drawing.Point(0, 0)
        Me.dashboardButton.Name = "dashboardButton"
        Me.dashboardButton.Size = New System.Drawing.Size(229, 52)
        Me.dashboardButton.TabIndex = 8
        Me.dashboardButton.Text = "Dashboard"
        Me.dashboardButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(262, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(397, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Faculdade de Educacao e Psicologia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(619, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Admin"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(431, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 24)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "FEP"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(419, 12)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(64, 50)
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(373, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 24)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Bem vindo/a"
        '
        'aboutButton
        '
        Me.aboutButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.aboutButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.aboutButton.FlatAppearance.BorderSize = 0
        Me.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aboutButton.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aboutButton.ForeColor = System.Drawing.Color.White
        Me.aboutButton.Location = New System.Drawing.Point(377, 267)
        Me.aboutButton.Name = "aboutButton"
        Me.aboutButton.Size = New System.Drawing.Size(139, 23)
        Me.aboutButton.TabIndex = 25
        Me.aboutButton.Text = "Sobre nos"
        Me.aboutButton.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(229, 442)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(455, 19)
        Me.Panel2.TabIndex = 26
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(165, -4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(122, 23)
        Me.Button5.TabIndex = 27
        Me.Button5.Text = "copyright -2022"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(21, 49)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(204, 33)
        Me.Button6.TabIndex = 0
        Me.Button6.Text = "Estudante"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'pagamentoButton
        '
        Me.pagamentoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pagamentoButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pagamentoButton.FlatAppearance.BorderSize = 0
        Me.pagamentoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pagamentoButton.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pagamentoButton.ForeColor = System.Drawing.Color.White
        Me.pagamentoButton.Image = CType(resources.GetObject("pagamentoButton.Image"), System.Drawing.Image)
        Me.pagamentoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.pagamentoButton.Location = New System.Drawing.Point(21, 100)
        Me.pagamentoButton.Name = "pagamentoButton"
        Me.pagamentoButton.Size = New System.Drawing.Size(204, 35)
        Me.pagamentoButton.TabIndex = 1
        Me.pagamentoButton.Text = "Pagamento"
        Me.pagamentoButton.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pagamentoButton)
        Me.Panel3.Controls.Add(Me.Button6)
        Me.Panel3.Location = New System.Drawing.Point(321, 151)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(247, 185)
        Me.Panel3.TabIndex = 29
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(248, 396)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(424, 10)
        Me.ProgressBar1.TabIndex = 30
        '
        'processLabel
        '
        Me.processLabel.AutoSize = True
        Me.processLabel.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.processLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.processLabel.Location = New System.Drawing.Point(390, 374)
        Me.processLabel.Name = "processLabel"
        Me.processLabel.Size = New System.Drawing.Size(129, 16)
        Me.processLabel.TabIndex = 31
        Me.processLabel.Text = "Salavando arquivos..."
        '
        'Timer1
        '
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(266, 123)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(393, 1)
        Me.Panel4.TabIndex = 32
        '
        'userPanel
        '
        Me.userPanel.BackColor = System.Drawing.Color.White
        Me.userPanel.Controls.Add(Me.viewButton)
        Me.userPanel.Controls.Add(Me.addUsuarioButton)
        Me.userPanel.Location = New System.Drawing.Point(286, 151)
        Me.userPanel.Name = "userPanel"
        Me.userPanel.Size = New System.Drawing.Size(333, 201)
        Me.userPanel.TabIndex = 34
        '
        'viewButton
        '
        Me.viewButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.viewButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.viewButton.FlatAppearance.BorderSize = 0
        Me.viewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.viewButton.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.viewButton.ForeColor = System.Drawing.Color.White
        Me.viewButton.Image = CType(resources.GetObject("viewButton.Image"), System.Drawing.Image)
        Me.viewButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.viewButton.Location = New System.Drawing.Point(52, 99)
        Me.viewButton.Name = "viewButton"
        Me.viewButton.Size = New System.Drawing.Size(229, 35)
        Me.viewButton.TabIndex = 11
        Me.viewButton.Text = "Visualizar"
        Me.viewButton.UseVisualStyleBackColor = False
        '
        'addUsuarioButton
        '
        Me.addUsuarioButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.addUsuarioButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.addUsuarioButton.FlatAppearance.BorderSize = 0
        Me.addUsuarioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addUsuarioButton.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.addUsuarioButton.ForeColor = System.Drawing.Color.White
        Me.addUsuarioButton.Image = CType(resources.GetObject("addUsuarioButton.Image"), System.Drawing.Image)
        Me.addUsuarioButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.addUsuarioButton.Location = New System.Drawing.Point(52, 52)
        Me.addUsuarioButton.Name = "addUsuarioButton"
        Me.addUsuarioButton.Size = New System.Drawing.Size(229, 36)
        Me.addUsuarioButton.TabIndex = 10
        Me.addUsuarioButton.Text = "Usuario"
        Me.addUsuarioButton.UseVisualStyleBackColor = False
        '
        'Display
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(684, 461)
        Me.Controls.Add(Me.userPanel)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.processLabel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.aboutButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Display"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.userPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dashboardButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents logoutButton As Button
    Friend WithEvents usuarioButton As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents addButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents aboutButton As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents pagamentoButton As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents processLabel As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel4 As Panel
    Friend WithEvents userPanel As Panel
    Friend WithEvents viewButton As Button
    Friend WithEvents addUsuarioButton As Button
End Class
