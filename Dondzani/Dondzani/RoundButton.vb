
Module RoundButton
    Public Sub roundButton(btn As Button)
        Dim radius As New Drawing2D.GraphicsPath
        radius.StartFigure()

        'left top corner
        radius.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        radius.AddLine(10, 0, btn.Width - 20, 0)

        'right top corner
        radius.AddArc(New Rectangle(btn.Width - 20, 0, 20, 20), -90, 90)
        radius.AddLine(btn.Width, 30, btn.Width, btn.Height - 10)

        'right corner bottom
        radius.AddArc(New Rectangle(btn.Width - 20, btn.Height - 20, 20, 20), 0, 90)

        'light corner bottom
        radius.AddLine(btn.Width - 10, btn.Width, 20, btn.Height)

        radius.AddArc(New Rectangle(0, btn.Height - 20, 20, 20), 90, 90)

        radius.CloseFigure()
        btn.Region = New Region(radius)

    End Sub
End Module
