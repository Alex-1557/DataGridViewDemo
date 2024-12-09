Imports System.IO

Public Enum ColumnNum
    Name = 0
    Warehous = 1
    [Date] = 2
    Condition = 3
    Category = 4
    Accesibility = 5
    RfidState = 6
    RfidNum = 7
    RfidPrint = 8
End Enum


Public Class StartForm
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        DataGridView1.RowHeadersVisible = True
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridView1.AllowUserToAddRows = False
        Dim RND As New Random()
        For i As Integer = 1 To 100
            Dim OneRow As New DataGridViewRow()
            For j As Integer = 0 To DataGridView1.Columns.Count - 1
                If DataGridView1.Columns(j).GetType() Is GetType(DataGridViewLinkColumn) Then
                    'Name
                    Dim LinkLabel As DataGridViewLinkColumn = CType(DataGridView1.Columns(j), DataGridViewLinkColumn)
                    LinkLabel.UseColumnTextForLinkValue = False
                    Dim linkCell As New DataGridViewLinkCell
                    linkCell.UseColumnTextForLinkValue = False
                    linkCell.Value = RandomString(RND, 4)
                    OneRow.Cells.Add(linkCell)
                ElseIf j = 2 Then
                    'Warehous
                    Dim TxtCell2 As New DataGridViewTextBoxCell()
                    TxtCell2.Value = RandomString(RND, 1)
                    OneRow.Cells.Add(TxtCell2)
                ElseIf j = 3 Then
                    'Date
                    Dim TxtCell3 As New DataGridViewTextBoxCell()
                    TxtCell3.Value = RandomDateBetween(RND, New Date(2022, 1, 1), New Date(2022, 12, 31))
                    OneRow.Cells.Add(TxtCell3)
                ElseIf j = 4 Then
                    'Condition
                    Dim TxtCell4 As New DataGridViewTextBoxCell()
                    TxtCell4.Style.ForeColor = Color.Green
                    TxtCell4.Value = "Active"
                    OneRow.Cells.Add(TxtCell4)
                    TxtCell4.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                ElseIf j = 5 Then
                    'Category
                    Dim TxtCell5 As New DataGridViewTextBoxCell()
                    TxtCell5.Value = "Singeri"
                    TxtCell5.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    OneRow.Cells.Add(TxtCell5)
                ElseIf j = 6 Then
                    'Accesibility
                    Dim ImgCell6 As New DataGridViewImageCell
                    Dim randomImageIndex As Integer = RND.Next(0, ImageList1.Images.Count)
                    ImgCell6.Value = ImageList1.Images(randomImageIndex)
                    ImgCell6.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    OneRow.Cells.Add(ImgCell6)
                ElseIf j = 7 Then
                    'Rfid state
                    Dim ImgCell7 As New DataGridViewImageCell
                    Dim randomImageIndex As Integer = RND.Next(0, ImageList1.Images.Count)
                    ImgCell7.Value = ImageList1.Images(randomImageIndex)
                    ImgCell7.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    OneRow.Cells.Add(ImgCell7)
                ElseIf j = 8 Then
                    'Rfid Num
                    Dim TxtCell8 As New DataGridViewTextBoxCell()
                    TxtCell8.Value = RandomString(RND, 15)
                    TxtCell8.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    OneRow.Cells.Add(TxtCell8)
                ElseIf j = 9 Then
                    'Rfid print
                    Dim BtnCell1 As New DataGridViewButtonCell()
                    OneRow.Cells.Add(BtnCell1)
                End If
            Next
            DataGridView1.Rows.Add(OneRow)
        Next

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.ColumnIndex = ColumnNum.Name Then
            If TypeOf DataGridView1(e.ColumnIndex, e.RowIndex) Is DataGridViewLinkCell Then
                Dim cell As DataGridViewLinkCell = DataGridView1(e.ColumnIndex, e.RowIndex)
                System.Diagnostics.Process.Start("http://Store.MySilver.bg")
            End If
        End If
    End Sub

    Private Function RandomString(ByVal Rng As Random, ByVal Length As Integer) As String
        'Const chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Const Chars As String = "0123456789"
        Dim StringChars As Char() = New Char(Length - 1) {}
        For i As Integer = 0 To Length - 1
            StringChars(i) = Chars(Rng.Next(Chars.Length))
        Next
        Return New String(StringChars)
    End Function

    Public Function RandomDateBetween(ByVal Rng As Random, StartDate As Date, EndDate As Date) As Date
        Dim TimeDifferenceTicks As Long = (EndDate - StartDate).Ticks
        Dim RandomTicks As Long = CLng(Rng.NextDouble() * TimeDifferenceTicks)
        Return StartDate.AddTicks(RandomTicks)
    End Function

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim RowIdx As String = (e.RowIndex + 1).ToString()
        If DataGridView1.Rows(e.RowIndex).HeaderCell.Value?.ToString() <> RowIdx.ToString Then  ' Only update if different
            DataGridView1.Rows(e.RowIndex).HeaderCell.Value = RowIdx
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = ColumnNum.RfidPrint Then
            Me.Invoke(Sub() MsgBox("Function not ready", MsgBoxStyle.OkOnly, "Demo version"))
        End If
    End Sub

    Private Sub ReadButton_Click(sender As Object, e As EventArgs) Handles ReadButton.Click
        Me.Invoke(Sub() MsgBox("Function not ready", MsgBoxStyle.OkOnly, "Demo version"))
    End Sub

    Private Sub LoadButton_Click(sender As Object, e As EventArgs) Handles LoadButton.Click
        Me.Invoke(Sub() MsgBox("Function not ready", MsgBoxStyle.OkOnly, "Demo version"))
    End Sub

    Private Sub FindButton_Click(sender As Object, e As EventArgs) Handles FindButton.Click
        Me.Invoke(Sub() MsgBox("Function not ready", MsgBoxStyle.OkOnly, "Demo version"))
    End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        If e.ColumnIndex = ColumnNum.Name Or e.ColumnIndex = ColumnNum.RfidPrint Then
            DataGridView1.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        If e.ColumnIndex = ColumnNum.Name Or e.ColumnIndex = ColumnNum.RfidPrint Then
            DataGridView1.Cursor = Cursors.Default
        End If
    End Sub


End Class
