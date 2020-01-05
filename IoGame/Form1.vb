Imports Winsock_Orcas


Public Class Form1

    Dim r As New Random

#Region " Form.Paint - Dibujo "

    Dim ColorNonClientArea As Color = Color.Black
    ' Form.Paint
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        If wsk.State <> WinsockStates.Connected Then Exit Sub


        With e.Graphics

            ' ------------------- Gráficos al Máximo  ----------------
            .CompositingMode = Drawing2D.CompositingMode.SourceOver
            .CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            .PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            .TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        End With



        ' Area Cliente, No Cliente y Jugadores Remotos
        DrawNonClientArea(e.Graphics)

        ' Chat
        DrawChat(e.Graphics)

        ' Jugador Local
        PaintPlayer(Player1, e.Graphics)

        ' Info de Arma Local
        PaintIngoGun(e.Graphics)

        ' Draw PauseSignal
        If Pausa Then e.Graphics.DrawString("Juego en Pausa", New Font(Me.Font.FontFamily, 16), Brushes.Red, 10, 10)




    End Sub

    ' Dibujar Chat
    Sub DrawChat(ByRef g As Graphics)
        With g

            g.ResetTransform()

            Dim s As String = ""
            For Each v As String In Chat
                s &= v & vbCrLf
            Next
            Dim sF = g.MeasureString(s, New Font(Me.Font.FontFamily, 12))
            Dim p As New Point
            p.X = 10
            p.Y = ClientSize.Height - 10 - sF.Height

            g.DrawString(s, New Font(Me.Font.FontFamily, 12), Brushes.White, p)

            'p = Nothing
            's = Nothing
            'sF = Nothing

        End With
    End Sub
    ' Dibujar Bordes
    Sub DrawNonClientArea(ByRef g As Graphics)
        With g

            ' Zona No Cliente
            g.Clear(ColorNonClientArea)


            Dim p As New Pen(Me.BackColor, 5)
            .TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2)

            ' Zona Cliente
            .FillRectangle(p.Brush, -Player1.X, -Player1.Y, Player1.GameSize.Width, Player1.GameSize.Height)




            ' Jugadores Remotos
            If Jugadores.Count <> 0 Then
                For Each z As R_MiniPlayer In Jugadores
                    PaintMiniPlayer(z, g)
                Next
            End If

            .TranslateTransform(-(ClientSize.Width / 2), -(ClientSize.Height / 2))



            p = Nothing
        End With
    End Sub
    ' Player.Paint
    Sub PaintPlayer(ByRef P As Player, ByRef G As Graphics)
        With G


            .TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2)
            Using pp As New Pen(P.Color, 1)

                If P.Angle > 180 Then
                    .DrawRectangle(pp, CSng(-P.W / 2) - 10, CSng(P.H / 2) + 30, P.W + 20, 10)
                    .FillRectangle(pp.Brush, CSng(-P.W / 2) - 10, CSng(P.H / 2) + 30, CSng((P.Vida * (P.W + 20)) / 100), 10)
                Else
                    .DrawRectangle(pp, CSng(-P.W / 2) - 10, CSng(-P.H / 2) - 30, P.W + 20, 10)
                    .FillRectangle(pp.Brush, CSng(-P.W / 2) - 10, CSng(-P.H / 2) - 30, CSng((P.Vida * (P.W + 20)) / 100), 10)
                End If

                pp.Width = 4
                .FillEllipse(pp.Brush, CSng(-P.W / 2), CSng(-P.H / 2), P.W, P.H)
                .DrawArc(pp, CSng(-P.W / 2) - 10, CSng(-P.H / 2) - 10, P.W + 20, P.H + 20, CSng(Player1.Angle - (Player1.Precision / 2)), Player1.Precision) ' CSng(P.Angle - (P.Precision / 2)), P.Precision)

            End Using


            .TranslateTransform(-Player1.X - (Player1.W / 2), -Player1.Y - (Player1.H / 2))
            PaintGun(G)
            PaintDisparos(Player1.Disparos, G)
            .TranslateTransform(Player1.X + (Player1.W / 2), Player1.Y + (Player1.H / 2))



            .TranslateTransform(-(ClientSize.Width / 2), -(ClientSize.Height / 2))






        End With
    End Sub
    Sub PaintMiniPlayer(ByRef P As R_MiniPlayer, ByRef G As Graphics)
        With G

            .TranslateTransform(-Player1.X - 15, -Player1.Y - 15)

            Using pp As New Pen(P.Color, 4)


                ' If P.Enabled = False Then pp.Color = ControlPaint.Light(Me.BackColor, 75)
                .FillEllipse(pp.Brush, P.X, P.Y, P.W, P.H) 'CSng(-P.W / 2), CSng(-P.H / 2), P.W, P.H)
                .DrawArc(pp, P.X - 10, P.Y - 10, P.W + 20, P.H + 20, CSng(P.Angle - (P.Precision / 2)), P.Precision)

            End Using


            ' Disparos Remotos
            PaintDisparos(Disparos, G)


            .TranslateTransform(Player1.X + 15, Player1.Y + 15)

        End With
    End Sub
    ' Disparos
    Sub PaintDisparos(ByRef L As List(Of R_Disparo), ByRef G As Graphics)
        If L.Count = 0 Then Exit Sub
        Try
            Dim p As New Pen(Color.Black)
            With G
                For Each D In L

                    p.Color = D.Color
                    .FillRectangle(p.Brush, D.X, D.Y, D.W, D.H)

                Next
            End With
            p = Nothing
        Catch ex As Exception
            'MsgBox("Error en Dibujo de Disparos. " & ex.Message)
        End Try
    End Sub
    ' Gun
    Sub PaintGun(ByRef G As Graphics)
        If GunOk = False Then Exit Sub

        Dim bmp As Bitmap = Nothing
        Select Case Gun.Gun
            Case TipoArma.M14 : bmp = My.Resources.M14
            Case TipoArma.M9 : bmp = My.Resources.M9
            Case TipoArma.R49 : bmp = My.Resources.R49
            Case TipoArma.Rifle : bmp = My.Resources.Rifle
            Case TipoArma.Sub55 : bmp = My.Resources.Sub55
            Case TipoArma.x99x : bmp = My.Resources.x99x
        End Select


        G.DrawImage(bmp, Gun.X, Gun.Y, 48, 48)
        ControlPaint.DrawBorder(G, New Rectangle(Gun.X - 5, Gun.Y - 5, 58, 58), Color.CadetBlue, ButtonBorderStyle.Solid)


    End Sub

    ' Info of Gun
    Sub PaintIngoGun(ByRef g As Graphics)

        Dim p As New Pen(Me.BackColor)

        g.ResetTransform()

        Dim x = ClientSize.Width - 200
        Dim y = ClientSize.Height - 100

        ' Mini-Fondo
        g.FillRectangle(p.Brush, x, y, 200, 100)



        Dim bmp As Bitmap = Nothing
        Select Case Player1.Gun
            Case TipoArma.M14 : bmp = My.Resources.M14
            Case TipoArma.M9 : bmp = My.Resources.M9
            Case TipoArma.R49 : bmp = My.Resources.R49
            Case TipoArma.Rifle : bmp = My.Resources.Rifle
            Case TipoArma.Sub55 : bmp = My.Resources.Sub55
            Case TipoArma.x99x : bmp = My.Resources.x99x
        End Select


        g.DrawImage(bmp, x + 25, y + 25, 48, 48)

        Dim s As String = "None"
        Select Case Player1.Gun
            Case TipoArma.M14 : s = "AK74"
            Case TipoArma.M9 : s = "Classic"
            Case TipoArma.R49 : s = "B-49"
            Case TipoArma.Rifle : s = "R23"
            Case TipoArma.Sub55 : s = "Sub 55"
            Case TipoArma.x99x : s = "x99x"
        End Select

        g.DrawString(s, New Font(Me.Font.FontFamily, 12), Brushes.WhiteSmoke, x + 75 + 10, y + 10)



        Dim percent As Integer
        percent = ((Now.TimeOfDay - Player1.D_LastTime).TotalSeconds * 100) / Player1.D_TimeForRecharge.TotalSeconds


        If Player1.D_Actual = 0 Then
            g.DrawString(percent & "%", New Font(Me.Font.FontFamily, 9), Brushes.WhiteSmoke, x + 75 + 10, y + 35)
        Else
            g.DrawString(Player1.D_Actual & " / " & Player1.D_Max & vbCrLf &
                         "Daño: " & Player1.D_MinDaño & "-" & Player1.D_MaxDaño, New Font(Me.Font.FontFamily, 9), Brushes.WhiteSmoke, x + 75 + 10, y + 35)
        End If




        ControlPaint.DrawBorder(g, New Rectangle(x, y, 202, 102), Color.WhiteSmoke, style:=ButtonBorderStyle.Dashed)


    End Sub




#End Region


#Region " Logica de Jugador Local "


    ' Click para Disparar
    Dim bfCursor As Point
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Player1.D_Disparar = True
    End Sub
    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.MouseUp
        Player1.D_Disparar = False
    End Sub

    ' Timer - Movimiento / Disparos / Colision 
    Dim tempX, tempY As Short
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles T.Tick

        If wsk.State = WinsockStates.Closed Then HayDesconexion() : Exit Sub

#Region " Mouse Angle "

        Try

            If Player1.UseMouseControls = False Or Me.Focused = False Then Exit Try

            Dim FINX As Integer = Cursor.Position.X
            Dim FINY As Integer = Cursor.Position.Y
            Dim CEROX As Integer = Me.Left + 8 + ClientSize.Width / 2
            Dim CEROY As Integer = Me.Top + 30 + ClientSize.Height / 2
            Dim ATAN As Single = Math.Round(Math.Atan((CEROY - FINY) / (FINX - CEROX)) * (180 / Math.PI), 1)
            If FINX = CEROX And FINY > CEROY Then : ATAN = 270
            ElseIf FINX < CEROX And FINY = CEROY Then : ATAN = 180
            ElseIf FINX > CEROX And FINY > CEROY Then : ATAN += 360
            ElseIf FINX < CEROX And FINY > CEROY Then : ATAN += 180
            ElseIf FINX < CEROX And FINY < CEROY Then : ATAN += 180
            End If




            If bfCursor <> Cursor.Position Then
                bfCursor = Cursor.Position
                Player1.Angle = 360 - ATAN
                Player1_ChangeAngle(Player1)
            End If




        Catch ex As Exception
        End Try

#End Region

#Region " Disparos"

        Player1.GoTime()
        If Player1.D_Disparar Then Player1.Disparar()

        ' Enemigos
        If Disparos.Count <> 0 Then

            Dim z As R_Disparo
            For i = Disparos.Count - 1 To 0 Step -1
                z = Disparos(i)
                z.X += z.xVel
                z.Y += z.yVel

                If z.X < z.W Or
                   z.X > Player1.GameSize.Width Or
                   z.Y < z.H Or
                   z.Y > Player1.GameSize.Height Then

                    Disparos.RemoveAt(i)

                End If
            Next
        End If
        ' Locales
        Player1.MoverDisparos()


        Colision()
        MEcolision()


#End Region

#Region " Movimiento "

        ' Jugador Local
        Player1.Move()
        If tempX <> Player1.X Or tempY <> Player1.Y Then
            tempX = Player1.X
            tempY = Player1.Y

            Send_Location()
        End If

        ' Jugador Remoto
        For Each x As R_MiniPlayer In Jugadores
            If x.Vel <> 0 Then

                x.X += x.Vel * Math.Cos((x.Angle) * (Math.PI / 180))
                x.Y += x.Vel * Math.Sin((x.Angle) * (Math.PI / 180))
                x.X = Math.Max(Player1.GameLocation.X, x.X)
                x.X = Math.Min(x.X, Player1.GameSize.Width - x.W)
                x.Y = Math.Max(Player1.GameLocation.Y, x.Y)
                x.Y = Math.Min(x.Y, Player1.GameSize.Height - x.H)

            End If
        Next






#End Region

#Region " Arma "

        ChangeGun()

#End Region

        Invalidate()

    End Sub


    Sub Colision()


        ' Colision de disparos locales contra jugador remoto
        For Each v As R_Disparo In Player1.Disparos
            If v.Used Then Continue For
            Dim a As New Rectangle(v.X, v.Y, v.W, v.H)






            For Each i As R_MiniPlayer In Jugadores
                Dim b As New Rectangle(i.X, i.Y, i.W, i.H)

                If a.IntersectsWith(b) Then
                    v.Used = True
                    i.Vida = Math.Max(0, CInt(i.Vida) - CInt(v.Daño))
                    If i.Vida = 0 Then
                        i.Vida = 100
                        i.X = ClientSize.Width / 2 - i.W / 2
                        i.Y = ClientSize.Height / 2 - i.H / 2
                        Send_Muerte(Player1.Color, i.Color)
                        Chat.Add("Asesinaste a " & i.Nombre)
                    End If
                    Exit For
                End If
            Next
        Next


    End Sub
    Sub MEcolision()

        Dim a, b As Rectangle
        b = New Rectangle(Player1.X, Player1.Y, Player1.W, Player1.H)
        For Each z As R_Disparo In Disparos
            If z.Used Then Continue For
            a = New Rectangle(z.X, z.Y, z.W, z.H)

            If a.IntersectsWith(b) Then

                z.Used = True
                Player1.Vida = Math.Max(0, CInt(Player1.Vida) - CInt(z.Daño))

            End If

        Next

    End Sub

    Sub ChangeGun()
        If GunOk = False Then Exit Sub

        Dim a As New Rectangle(Gun.X, Gun.Y, 48, 48)
        Dim b As New Rectangle(Player1.X, Player1.Y, Player1.W, Player1.H)
        If a.IntersectsWith(b) Then

            Player1.Gun = Gun.Gun

            Select Case Gun.Gun
                Case TipoArma.M14
                    With Player1
                        .D_Actual = 0
                        .D_CantidadPer = 1
                        .D_Max = 20
                        .D_MaxDaño = 25
                        .D_MaxH = 10
                        .D_MaxVel = 10
                        .D_MaxW = 10
                        .D_MinDaño = 20
                        .D_MinH = 7
                        .D_MinVel = 7
                        .D_MinW = 7
                        .D_Presicion = 4
                        .D_TimeForRecharge = New TimeSpan(0, 0, 0, 3, 0)
                        .D_TimeForShot = New TimeSpan(0, 0, 0, 0, 500)
                    End With

                Case TipoArma.M9

                    With Player1
                        .D_Actual = 0
                        .D_CantidadPer = 1
                        .D_Max = 8
                        .D_MaxDaño = 7
                        .D_MinDaño = 5
                        .D_MaxH = 7
                        .D_MaxW = 7
                        .D_MinH = 5
                        .D_MinW = 5
                        .D_MaxVel = 15
                        .D_MinVel = 10
                        .D_Presicion = 3
                        .D_TimeForRecharge = New TimeSpan(0, 0, 0, 1, 0)
                        .D_TimeForShot = New TimeSpan(0, 0, 0, 0, 250)
                    End With


                Case TipoArma.R49

                    With Player1
                        .D_Actual = 0
                        .D_CantidadPer = 1
                        .D_Max = 2
                        .D_MaxDaño = 50
                        .D_MinDaño = 25
                        .D_MaxH = 25
                        .D_MaxW = 25
                        .D_MinH = 20
                        .D_MinW = 20
                        .D_MaxVel = 25
                        .D_MinVel = 15
                        .D_Presicion = 1
                        .D_TimeForRecharge = New TimeSpan(0, 0, 0, 2, 0)
                        .D_TimeForShot = New TimeSpan(0, 0, 0, 0, 500)
                    End With

                Case TipoArma.Rifle

                    With Player1
                        .D_Actual = 0
                        .D_CantidadPer = 1
                        .D_Max = 16
                        .D_MaxDaño = 15
                        .D_MinDaño = 10
                        .D_MaxH = 7
                        .D_MaxW = 7
                        .D_MinH = 5
                        .D_MinW = 5
                        .D_MaxVel = 15
                        .D_MinVel = 10
                        .D_Presicion = 1
                        .D_TimeForRecharge = New TimeSpan(0, 0, 0, 3, 0)
                        .D_TimeForShot = New TimeSpan(0, 0, 0, 0, 250)
                    End With

                Case TipoArma.Sub55

                    With Player1
                        .D_Actual = 0
                        .D_CantidadPer = 3
                        .D_Max = 50
                        .D_MaxDaño = 7
                        .D_MinDaño = 5
                        .D_MaxH = 5
                        .D_MaxW = 5
                        .D_MinH = 2
                        .D_MinW = 2
                        .D_MaxVel = 20
                        .D_MinVel = 15
                        .D_Presicion = 3
                        .D_TimeForRecharge = New TimeSpan(0, 0, 0, 3, 0)
                        .D_TimeForShot = New TimeSpan(0, 0, 0, 0, 200)
                    End With

                Case TipoArma.x99x

                    With Player1
                        .D_Actual = 0
                        .D_CantidadPer = 5
                        .D_Max = 120
                        .D_MaxDaño = 20
                        .D_MinDaño = 10
                        .D_MaxH = 15
                        .D_MaxW = 15
                        .D_MinH = 7
                        .D_MinW = 7
                        .D_MaxVel = 25
                        .D_MinVel = 20
                        .D_Presicion = 7
                        .D_TimeForRecharge = New TimeSpan(0, 0, 0, 5, 0)
                        .D_TimeForShot = New TimeSpan(0, 0, 0, 0, 100)
                    End With


            End Select

            Gun = Nothing
            GunOk = False

            Send_ResetGun()

        End If


    End Sub


#End Region


#Region " Form Events - Controls"

    ' Play Pausa
    Dim Pausa As Boolean = False
    Sub PlayPause()
        If wsk.State <> WinsockStates.Connected Then Exit Sub

        Pausa = Not Pausa
        T.Enabled = Not Pausa

        Send_PlayPausa()

        Invalidate()

    End Sub
    ' Pantalla Completa
    Dim full As Boolean = False
    Sub PantallaCompleta()
        If wsk.State <> WinsockStates.Connected Then Exit Sub
        full = Not full
        If full Then
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
        End If
        Me.BringToFront()
    End Sub
    ' Color
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        DG.Color = Player1.Color
        If DG.ShowDialog = DialogResult.OK Then
            Player1.Color = DG.Color
            LinkLabel4.LinkColor = Player1.Color
        End If
    End Sub


    ' Conectar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Box.Enabled = False
            wsk.Connect()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' Cambio de IP Remota de Servidor
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles LinkLabel1.LinkClicked
        Dim ip = InputBox("Ingresa la IP Remota: " & vbCrLf & "Ejemplo: 192.168.0.1", "IP Remota", wsk.RemoteHost)
        If ip <> Nothing Then wsk.RemoteHost = ip

        LinkLabel1.Text = "IP de Servidor: " & ip
        LinkLabel1.Left = Box.Width / 2 - LinkLabel1.Width / 2

    End Sub
    ' Cambio de Puerto de Servidor
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim ip = InputBox("Ingresa el Puerto de Servidor: " & vbCrLf & "Ejemplo: 8080", "Puerto", wsk.RemotePort)
        If (ip <> Nothing) And IsNumeric(ip) Then wsk.RemotePort = ip


        LinkLabel2.Text = "Puerto: " & ip
        LinkLabel2.Left = Box.Width / 2 - LinkLabel2.Width / 2
    End Sub
    ' Cambio de Nombre de Jugador
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim ip = InputBox("Ingresa tu Nombre: " & vbCrLf & "Ejemplo: Admin", "Nombre", Player1.Nombre)
        If ip = Nothing Then Exit Sub


        Player1.Nombre = ip
        Label2.Text = "¡Hola, " & ip & "!"
        Label2.Left = Box.Width / 2 - Label2.Width / 2


    End Sub



    ' Form Load, Form Close
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResizeRedraw = True

        Randomize()

        Player1.R = r
        Player1.Color = Color.FromArgb(255, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))

        LinkLabel4.LinkColor = Player1.Color

    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If wsk.State <> WinsockStates.Closed Then wsk.Close()
    End Sub

    ' Form.KeyDown - Form.KeyUp
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Player1.KeysDown(e)
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Player1.KeysUp(e)

        If e.KeyData = Keys.Escape Then PlayPause()
        If e.KeyData = Keys.F11 Then PantallaCompleta()

    End Sub




#End Region


#Region " -- Red -- "

    Dim Red As New List(Of String)

    Dim Jugadores As New List(Of R_MiniPlayer)
    Dim Disparos As New List(Of R_Disparo)
    Dim Chat As New List(Of String)

    Dim Gun As New S_Gun
    Dim GunOk As Boolean = False

#Region "        Connected - Disconnected - Error "

    ' Conectado
    Private Sub wsk_Connected(sender As Object, e As WinsockConnectedEventArgs) Handles wsk.Connected

        HayConexion()

    End Sub
    ' Desconectado
    Private Sub wsk_Disconnected(sender As Object, e As EventArgs) Handles wsk.Disconnected

        HayDesconexion()

    End Sub
    ' Error
    Private Sub wsk_ErrorReceived(sender As Object, e As WinsockErrorReceivedEventArgs) Handles wsk.ErrorReceived

        If wsk.State = WinsockStates.Closed Then HayDesconexion()

    End Sub

#End Region

#Region "        Receive Data "

    ' DataArrival
    Private Sub wsk_DataArrival(sender As Winsock, e As WinsockDataArrivalEventArgs) Handles wsk.DataArrival

        Red.Add(sender.Get(Of String)())

    End Sub



    ' Checkear datos de red.
    Private Sub RedCheck_Tick() Handles RedCheck.Tick

        If Red.Count = 0 Then Exit Sub

        For Each ww As String In Red
            Dim Converted = DataGet_Converter.dataFromString(ww)
            Select Case Converted.TipoDato
                Case TipoDato.Location : R_Location(Converted)
                Case TipoDato.ChangeAngle : R_ChangeAngle(Converted)

                Case TipoDato.Mensaje : R_Message(Converted)
                Case TipoDato.Pausa : R_Pausa(Converted)
                Case TipoDato.Muerte : R_Muerte(Converted)
                Case TipoDato.Nombre : R_Nombre(Converted)
                Case TipoDato.NewPlayer : R_NewPlayer(Converted)

                Case TipoDato.Disparo : R_Disparo(Converted)

                Case TipoDato.Gun : R_Gun(Converted)
                Case TipoDato.ResetGuns : R_ResetGuns(Converted)


            End Select
            Converted = Nothing


        Next

        Red.Clear()


    End Sub


    ' Usar datos de red
    Private Sub R_Gun(c As Data_Get)

        Gun = c.Value
        GunOk = True
        Invalidate()

    End Sub
    Private Sub R_ResetGuns(c As Data_Get)

        Gun = Nothing
        GunOk = False
        Invalidate()

    End Sub
    Private Sub R_Location(c As Data_Get)
        Dim encontrado As Boolean = False
        Dim k As S_Location = c.Value
        For Each z As R_MiniPlayer In Jugadores
            If k.Color = z.Color Then
                z.X = k.X
                z.Y = k.Y
                encontrado = True
                Exit For
            End If
        Next
        If Not encontrado Then
            Jugadores.Add(New R_MiniPlayer)
            Jugadores.Last.X = k.X
            Jugadores.Last.Y = k.Y
        End If
        k = Nothing
    End Sub
    Private Sub R_ChangeAngle(c As Data_Get)
        Dim encontrado As Boolean = False
        Dim k As S_ChangeAngle = c.Value
        For Each z As R_MiniPlayer In Jugadores
            If k.Color = z.Color Then
                z.Angle = k.Angle
                encontrado = True
                Exit For
            End If
        Next
        If Not encontrado Then
            Jugadores.Add(New R_MiniPlayer)
            Jugadores.Last.Color = k.Color
            Jugadores.Last.Angle = k.Angle
        End If
        k = Nothing
    End Sub
    Private Sub R_Muerte(C As Data_Get)
        Disparos.Clear()
        Player1.Disparos.Clear()



        Dim k As S_Muerte = C.Value
        Dim s As String = ""

        If k.Victima = Player1.Color Then
            For Each v In Jugadores
                If v.Color = k.Asesino Then
                    s = v.Nombre & " te asesinó."

                    Player1.X = Player1.GameSize.Width / 2 - Player1.W / 2
                    Player1.Y = Player1.GameSize.Height / 2 - Player1.H / 2
                    Player1.Vida = 100

                    Exit For
                End If
            Next

        Else

            For Each v In Jugadores
                If v.Color = k.Asesino Then
                    s = v.Nombre & " asesinó a "
                    Exit For
                End If
            Next
            For Each v In Jugadores
                If v.Color = k.Victima Then
                    s &= v.Nombre & "."

                    v.X = Player1.GameSize.Width / 2 - v.W / 2
                    v.Y = Player1.GameSize.Height / 2 - v.H / 2
                    v.Vida = 100

                    Exit For
                End If
            Next


        End If

        k = Nothing

        Chat.Add(s)
        Invalidate()
    End Sub
    Private Sub R_Message(c As Data_Get)
        Dim k As S_Mensaje = c.Value
        For Each z As R_MiniPlayer In Jugadores
            If k.Color = z.Color Then

                Chat.Add(z.Nombre & ": " & k.Msg)

                Exit For
            End If
        Next
        k = Nothing
        Invalidate()
    End Sub
    Private Sub R_Pausa(c As Data_Get)
        Dim k As S_Pausa = c.Value
        Pausa = k.Pausa
        For Each z As R_MiniPlayer In Jugadores


            If k.Color = z.Color Then
                If Pausa Then
                    Chat.Add(z.Nombre & " detuvo el Juego.")
                Else
                    Chat.Add(z.Nombre & " renaudó el Juego.")
                End If
                Exit For
            End If
        Next
        k = Nothing
        T.Enabled = Not Pausa
        Invalidate()
    End Sub
    Private Sub R_Nombre(c As Data_Get)
        Dim k As S_Nombre = c.Value
        For Each z As R_MiniPlayer In Jugadores
            If k.Color = z.Color Then
                z.Nombre = k.Nombre
                Exit For
            End If
        Next
        k = Nothing
    End Sub
    Private Sub R_NewPlayer(c As Data_Get)
        Jugadores.Add(CType(c.Value, R_MiniPlayer))
        Invalidate()
    End Sub
    Private Sub R_Disparo(c As Data_Get)
        Dim z = CType(c.Value, R_Disparo)

        Disparos.Add(z)

        For Each i As R_MiniPlayer In Jugadores
            If i.Color = z.Color Then
                i.X = z.X
                i.Y = z.Y
            End If
        Next

        Invalidate()
    End Sub


#End Region

#Region "        Send Data"

    Private Sub Player1_Disparo(ByRef sender As Player, ByRef e As R_Disparo) Handles Player1.Disparo

        If wsk.State = WinsockStates.Connected Then

            ' Create data to send
            Dim k As New Data_Get
            k.TipoDato = TipoDato.Disparo
            k.Value = e

            ' Send
            wsk.Send(DataGet_Converter.dataToString(k))

            ' Clear 
            k = Nothing

        End If

    End Sub

    Private Sub Player1_ChangeAngle(ByRef sender As Player) Handles Player1.ChangeAngle

        If wsk.State = WinsockStates.Connected Then

            ' Create data to send
            Dim z As New S_ChangeAngle
            z.Angle = Player1.Angle
            z.Color = Player1.Color
            Dim k As New Data_Get
            k.TipoDato = TipoDato.ChangeAngle
            k.Value = z

            ' Send
            wsk.Send(DataGet_Converter.dataToString(k))

            ' Clear 
            k = Nothing
            z = Nothing

        End If

    End Sub

    Private Sub Send_PlayPausa()
        If wsk.State = WinsockStates.Connected Then

            ' Create data to send
            Dim z As New S_Pausa
            z.Color = Player1.Color
            z.Pausa = Pausa
            Dim k As New Data_Get
            k.TipoDato = TipoDato.Pausa
            k.Value = z

            ' Send
            wsk.Send(DataGet_Converter.dataToString(k))

            ' Clear 
            k = Nothing
            z = Nothing

        End If
    End Sub

    Private Sub Send_Nombre()
        If wsk.State = WinsockStates.Connected Then

            ' Create data to send
            Dim z As New S_Nombre
            z.Color = Player1.Color
            z.Nombre = Player1.Nombre
            Dim k As New Data_Get
            k.TipoDato = TipoDato.Nombre
            k.Value = z

            ' Send
            wsk.Send(DataGet_Converter.dataToString(k))

            ' Clear 
            k = Nothing
            z = Nothing

        End If
    End Sub

    Private Sub Send_Location()
        If wsk.State = WinsockStates.Connected Then

            ' Create data to send
            Dim z As New S_Location
            z.Color = Player1.Color
            z.X = Player1.X
            z.Y = Player1.Y
            Dim k As New Data_Get
            k.TipoDato = TipoDato.Location
            k.Value = z

            ' Send
            wsk.Send(DataGet_Converter.dataToString(k))

            ' Clear 
            k = Nothing
            z = Nothing

        End If
    End Sub

    Private Sub Send_Muerte(ase As Color, vic As Color)
        If wsk.State = WinsockStates.Connected Then

            ' Create data to send
            Dim z As New S_Muerte
            z.Asesino = ase
            z.Victima = vic
            Dim k As New Data_Get
            k.TipoDato = TipoDato.Muerte
            k.Value = z

            ' Send
            wsk.Send(DataGet_Converter.dataToString(k))

            ' Clear 
            k = Nothing
            z = Nothing

        End If
    End Sub

    Private Sub Send_ResetGun()

        If wsk.State = WinsockStates.Connected Then

            Dim k As New Data_Get
            k.TipoDato = TipoDato.ResetGuns
            k.Value = Nothing

            ' Send
            wsk.Send(DataGet_Converter.dataToString(k))

            ' Clear 
            k = Nothing

        End If

    End Sub




#End Region

    Private Sub RegularData_Tick(sender As Object, e As EventArgs) Handles RegularData.Tick
        Send_Nombre()
        Send_Location()
    End Sub


    Sub HayConexion()


        Jugadores.Clear()
        Disparos.Clear()
        Chat.Clear()


        Box.Visible = False
        T.Start()

        If full = False Then PantallaCompleta()

        Send_Nombre()

        Me.Focus()
        Invalidate()



    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Ajustes.ShowDialog()
    End Sub

    Sub HayDesconexion()


        Jugadores.Clear()
        Disparos.Clear()
        Chat.Clear()

        Box.Enabled = True
        Box.Visible = True

        If full Then PantallaCompleta()

        Invalidate()

    End Sub









#End Region






End Class
