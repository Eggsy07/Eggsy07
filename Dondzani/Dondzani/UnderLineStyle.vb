Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Public Class UnderLineStyle

    Inherits TextBox
    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        MyBase.OnPaint(pe)
        Dim pen As New Pen(Color.Black, 2)
        pen.Alignment = PenAlignment.Inset
        Dim g As Graphics = pe.Graphics
        g.DrawLine(pen, 0, ClientSize.Height - 1, ClientSize.Width, ClientSize.Height - 1)
        'Me.Region = New Region(g)
    End Sub
End Class
