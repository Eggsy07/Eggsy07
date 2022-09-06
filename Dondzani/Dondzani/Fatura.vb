Public Class Fatura
    Dim g, mg As Graphics
    Dim bmp As Bitmap

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        e.Graphics.DrawImage(bmp, 20, 20)

    End Sub

    Private Sub imprimirButton_Click(sender As Object, e As EventArgs) Handles imprimirButton.Click
        imprimirButton.Visible = False
        CapturarForm()
        PrintDocument1.Print()
    End Sub

    Private Sub CapturarForm()
        Dim FormBorderStyleAnterior = Me.FormBorderStyle

        Try
            Me.FormBorderStyle = FormBorderStyle.None

            Dim Rect As WindowHelper.Rect
            WindowHelper.DwmGetWindowAttribute(Me.Handle, CInt(WindowHelper.Dwmwindowattribute.DwmwaExtendedFrameBounds),
                                       Rect, System.Runtime.InteropServices.Marshal.SizeOf(GetType(WindowHelper.Rect)))
            Dim Rectangle = Rect.ToRectangle()

            bmp = New Bitmap(Rectangle.Width, Rectangle.Height)
            Dim Graphics = System.Drawing.Graphics.FromImage(bmp)
            Graphics.CopyFromScreen(Rectangle.Left, Rectangle.Top, 0, 0, Rectangle.Size)
        Finally
            Me.FormBorderStyle = FormBorderStyleAnterior

        End Try


    End Sub
End Class