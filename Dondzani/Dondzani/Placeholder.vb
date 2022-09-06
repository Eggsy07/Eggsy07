Module Placeholder
    Private textBoxColor = Color.Black

    Public Sub PlaceholderEnter(txtBox As TextBox, msg As String)
        If txtBox.Text = msg Then
            txtBox.Text = ""
            txtBox.ForeColor = textBoxColor
        End If
    End Sub

    Public Sub PlaceholderLeave(txtBox As TextBox, msg As String)
        If txtBox.Text = "" Then
            txtBox.Text = msg
            txtBox.ForeColor = SystemColors.ActiveCaption
        End If
    End Sub
End Module
