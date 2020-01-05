Public Class Ajustes


    Enum Key
        None
        Up
        Down
        Left
        Right
        Rec
    End Enum
    Dim thisKey As Key = Key.None

    Private Sub Button1_Click(sender As Button, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click
        thisKey = sender.Tag
        sender.Text = ""
        Label5.Visible = True

        GroupBox1.Enabled = False
        Me.Focus()

    End Sub

    Private Sub Ajustes_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        ' No se está cambiando de tecla, salir.
        If thisKey = Key.None Then Exit Sub
        ' Es una tecla reservada, salir.
        If e.KeyData = Keys.Escape Or e.KeyData = Keys.F11 Then Exit Sub


        Dim s = [Enum].GetName(GetType(Keys), e.KeyData)
        Select Case thisKey
            Case Key.Up
                Button1.Text = s
                Form1.Player1.KeyUp = e.KeyData
            Case Key.Down
                Button3.Text = s
                Form1.Player1.KeyDown = e.KeyData
            Case Key.Left
                Button2.Text = s
                Form1.Player1.KeyLeft = e.KeyData
            Case Key.Right
                Button4.Text = s
                Form1.Player1.KeyRight = e.KeyData
            Case Key.Rec
                Button5.Text = s
                Form1.Player1.KeyRec = e.KeyData
        End Select

        Label5.Visible = False
        GroupBox1.Enabled = True

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim ip = InputBox("Ingresa tu Nombre: " & vbCrLf & "Ejemplo: Admin", "Nombre", Form1.Player1.Nombre)
        If ip = Nothing Then Exit Sub


        Form1.Player1.Nombre = ip
        Form1.Label2.Text = "¡Hola, " & ip & "!"
        Form1.Label2.Left = Form1.Box.Width / 2 - Form1.Label2.Width / 2

        LinkLabel1.Text = "Nombre: " & ip

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim dg As New ColorDialog
        dg.Color = Form1.Player1.Color
        If dg.ShowDialog = DialogResult.OK Then
            Form1.Player1.Color = dg.Color
        End If
        Form1.LinkLabel4.LinkColor = Form1.Player1.Color


        LinkLabel2.Text = "Color: " & dg.Color.R & ", " & dg.Color.G & ", " & dg.Color.B

        dg.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button3.Click, Button2.Click, Button1.Click, Button5.Click

    End Sub
End Class

