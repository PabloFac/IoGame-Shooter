<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.wsk = New Winsock_Orcas.Winsock()
        Me.T = New System.Windows.Forms.Timer(Me.components)
        Me.DG = New System.Windows.Forms.ColorDialog()
        Me.Box = New System.Windows.Forms.Panel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.RedCheck = New System.Windows.Forms.Timer(Me.components)
        Me.RegularData = New System.Windows.Forms.Timer(Me.components)
        Me.Player1 = New IoGame.Player(Me.components)
        Me.Box.SuspendLayout()
        Me.SuspendLayout()
        '
        'wsk
        '
        Me.wsk.BufferSize = 8192
        Me.wsk.LegacySupport = False
        Me.wsk.LocalPort = 8080
        Me.wsk.MaxPendingConnections = 5
        Me.wsk.Protocol = Winsock_Orcas.WinsockProtocol.Tcp
        Me.wsk.RemoteHost = "localhost"
        Me.wsk.RemotePort = 8080
        '
        'T
        '
        Me.T.Enabled = True
        Me.T.Interval = 50
        '
        'DG
        '
        Me.DG.AnyColor = True
        Me.DG.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.DG.FullOpen = True
        Me.DG.SolidColorOnly = True
        '
        'Box
        '
        Me.Box.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Box.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Box.Controls.Add(Me.LinkLabel4)
        Me.Box.Controls.Add(Me.Label1)
        Me.Box.Controls.Add(Me.LinkLabel3)
        Me.Box.Controls.Add(Me.Label2)
        Me.Box.Controls.Add(Me.Button5)
        Me.Box.Controls.Add(Me.LinkLabel2)
        Me.Box.Controls.Add(Me.LinkLabel1)
        Me.Box.Location = New System.Drawing.Point(72, 40)
        Me.Box.Name = "Box"
        Me.Box.Size = New System.Drawing.Size(640, 480)
        Me.Box.TabIndex = 2
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(297, 234)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(46, 20)
        Me.LinkLabel4.TabIndex = 8
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Color"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(193, 456)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Diseño y Programación by Pablo Facha Software"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(268, 424)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(109, 13)
        Me.LinkLabel3.TabIndex = 6
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Abrir Configuración"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(197, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 50)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "¡Hola, Admin!"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(186, 277)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(269, 139)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Jugar"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkArea = New System.Windows.Forms.LinkArea(8, 10)
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(271, 196)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(98, 27)
        Me.LinkLabel2.TabIndex = 2
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Puerto: 8080"
        Me.LinkLabel2.UseCompatibleTextRendering = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkArea = New System.Windows.Forms.LinkArea(16, 20)
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(228, 169)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(184, 27)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "IP de Servidor: Localhost"
        Me.LinkLabel1.UseCompatibleTextRendering = True
        '
        'RedCheck
        '
        Me.RedCheck.Enabled = True
        '
        'RegularData
        '
        Me.RegularData.Enabled = True
        Me.RegularData.Interval = 2000
        '
        'Player1
        '
        Me.Player1.Aceleracion = CType(2, Short)
        Me.Player1.Angle = CType(45, Short)
        Me.Player1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Player1.D_Actual = CType(15, Byte)
        Me.Player1.D_CantidadPer = CType(1, Byte)
        Me.Player1.D_Disparar = False
        Me.Player1.D_LastTime = System.TimeSpan.Parse("00:00:00")
        Me.Player1.D_Max = CType(15, Byte)
        Me.Player1.D_MaxDaño = CType(10, Byte)
        Me.Player1.D_MaxH = CType(15, Byte)
        Me.Player1.D_MaxVel = CType(25, Byte)
        Me.Player1.D_MaxW = CType(15, Byte)
        Me.Player1.D_MinDaño = CType(5, Byte)
        Me.Player1.D_MinH = CType(7, Byte)
        Me.Player1.D_MinVel = CType(15, Byte)
        Me.Player1.D_MinW = CType(7, Byte)
        Me.Player1.D_Presicion = CType(1, Byte)
        Me.Player1.D_TimeForRecharge = System.TimeSpan.Parse("00:00:02")
        Me.Player1.D_TimeForShot = System.TimeSpan.Parse("00:00:00.5000000")
        Me.Player1.Desaceleracion = CType(1, Short)
        Me.Player1.Freno = CType(5, Short)
        Me.Player1.GameLocation = New System.Drawing.Point(30, 50)
        Me.Player1.GameSize = New System.Drawing.Size(800, 600)
        Me.Player1.Gun = IoGame.TipoArma.M9
        Me.Player1.H = CType(30US, UShort)
        Me.Player1.KeyDown = System.Windows.Forms.Keys.S
        Me.Player1.KeyLeft = System.Windows.Forms.Keys.A
        Me.Player1.KeyRec = System.Windows.Forms.Keys.R
        Me.Player1.KeyRight = System.Windows.Forms.Keys.D
        Me.Player1.KeyUp = System.Windows.Forms.Keys.W
        Me.Player1.MaxVel = CType(10, Short)
        Me.Player1.MinVel = CType(-10, Short)
        Me.Player1.Nombre = "<Unkown>"
        Me.Player1.Precision = CType(30, Byte)
        Me.Player1.Puntaje = CType(0US, UShort)
        Me.Player1.RotVel = CType(5, Short)
        Me.Player1.UseMouseControls = True
        Me.Player1.Vel = CType(0, Short)
        Me.Player1.Vida = CType(100US, UShort)
        Me.Player1.W = CType(30US, UShort)
        Me.Player1.X = CType(185, Short)
        Me.Player1.Y = CType(185, Short)
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.Box)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IoGame - Pablo Facha Software"
        Me.Box.ResumeLayout(False)
        Me.Box.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wsk As Winsock_Orcas.Winsock
    Friend WithEvents T As Timer
    Friend WithEvents DG As ColorDialog
    Friend WithEvents Player1 As IoGame.Player
    Friend WithEvents Box As Panel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Button5 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents RedCheck As Timer
    Friend WithEvents RegularData As Timer
    Friend WithEvents LinkLabel4 As LinkLabel
End Class
