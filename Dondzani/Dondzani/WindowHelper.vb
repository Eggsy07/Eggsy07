Module WindowHelper
    <Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)>
    Public Structure Rect
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer

        Public Function ToRectangle() As System.Drawing.Rectangle
            Return System.Drawing.Rectangle.FromLTRB(Left, Top, Right, Bottom)
        End Function
    End Structure

    <System.Runtime.InteropServices.DllImport("dwmapi.dll")>
    Public Function DwmGetWindowAttribute(hwnd As IntPtr, dwAttribute As Integer, ByRef pvAttribute As Rect, cbAttribute As Integer) As Integer
    End Function

    Public Enum Dwmwindowattribute
        DwmwaExtendedFrameBounds = 9
    End Enum

End Module
