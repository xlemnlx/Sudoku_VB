Public Class Form1
    Dim TimeOut As Integer = 0
    Dim LastEmptyBoxes As Integer = 0
    Dim FirstTry As Integer = 0
    Dim SecondTry As Integer = 0
    Dim var As New Dictionary(Of String, String)()
    Dim Occurances As Integer = 0
    Dim random1 As Integer = 0
    Dim random2 As Integer = 0

    Function CheckColumn(box As Integer, val As String) As Boolean
        Dim errorFound As Boolean = True
        Dim columnIndex As Integer = box.ToString.Substring(1, 1)
        For i = 1 To 9
            If var("var" & i & columnIndex) = val And (i & columnIndex) <> box Then
                errorFound = False
            End If
        Next
        Return errorFound
    End Function
    Function CheckRow(box As Integer, val As String) As Boolean
        Dim errorFound As Boolean = True
        Dim rowIndex As Integer = box.ToString.Substring(0, 1)
        For i = 1 To 9
            If var("var" & rowIndex & i) = val And (rowIndex & i) <> box Then
                errorFound = False
            End If
        Next
        Return errorFound
    End Function
    Function CheckGrid(box As Integer, val As String) As Boolean
        Dim errorFound As Boolean = True
        Dim x As Integer = box.ToString.Substring(0, 1)
        Dim y As Integer = box.ToString.Substring(1, 1)

        x = Math.Ceiling(x / 3) - 1
        y = Math.Ceiling(y / 3) - 1

        x = 11 + (30 * x)
        y = (y * 3)
        For i1 = 0 To 2
            For i = 0 To 2
                If var("var" & (x + (i1 * 10)) + y + i) = val And (x + (i1 * 10) + y + i) <> box Then
                    errorFound = False
                End If
            Next
        Next
        Return errorFound
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim txtBox As New System.Windows.Forms.TextBox
        Dim xLen As Integer = 0
        Dim yLen As Integer = 0
        Dim BoxHeight As Integer = 31
        Dim BoxGridPosition As Integer = 1
        For i1 = 1 To 9
            If i1 > 3 And i1 < 7 Then
                yLen = 10
            ElseIf i1 > 6 Then
                yLen = 20
            End If
            For i2 = 1 To 9
                txtBox.Name = "txt" & i1 & i2
                var("var" & i1 & i2) = ""
                var("var" & i1 & i2 & "tag") = ""
                If i2 > 3 And i2 < 7 Then
                    xLen = 10
                ElseIf i2 > 6 Then
                    xLen = 20
                End If
                txtBox.Location = New Point((BoxHeight * i2) + xLen, (BoxHeight * i1) + yLen)
                txtBox.Size = New Size(BoxHeight, BoxHeight)
                txtBox.Font = New Font("Times New Roman", 15.75)
                txtBox.MaxLength = 1
                txtBox.TextAlign = HorizontalAlignment.Center
                txtBox.BorderStyle = BorderStyle.FixedSingle
                Me.Controls.Add(txtBox)

                AddHandler txtBox.KeyPress, AddressOf txtBox_KeyPress
                AddHandler txtBox.TextChanged, AddressOf txtBox_TextChanged

                txtBox = New System.Windows.Forms.TextBox
            Next
            xLen = 0
        Next
    End Sub

    Private Sub txtBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Or e.KeyChar = "0" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBox_TextChanged(sender As Object, e As EventArgs)
        var(sender.Name.ToString.Replace("txt", "var")) = sender.Text
        If CheckRow(sender.Name.ToString.Replace("txt", ""), sender.text) = False Then
            sender.clear()
            sender.Tag = ""
            var(sender.Name.ToString.Replace("txt", "var")) = ""
            var(sender.Name.ToString.Replace("txt", "var") & "tag") = ""
        ElseIf CheckColumn(sender.Name.ToString.Replace("txt", ""), sender.text) = False Then
            sender.clear()
            sender.Tag = ""
            var(sender.Name.ToString.Replace("txt", "var")) = ""
            var(sender.Name.ToString.Replace("txt", "var") & "tag") = ""
        ElseIf CheckGrid(sender.Name.ToString.Replace("txt", ""), sender.text) = False Then
            sender.clear()
            sender.Tag = ""
            var(sender.Name.ToString.Replace("txt", "var")) = ""
            var(sender.Name.ToString.Replace("txt", "var") & "tag") = ""
        End If
    End Sub
    Private Sub txtBoxChanges(varName As String, txt As String)
        var(varName) = txt.ToString
        If CheckRow(varName.ToString.Replace("var", ""), txt) = False Then
            var(varName) = ""
        ElseIf CheckColumn(varName.ToString.Replace("var", ""), txt) = False Then
            var(varName) = ""
        ElseIf CheckGrid(varName.ToString.Replace("var", ""), txt) = False Then
            var(varName) = ""
        End If
    End Sub
    Public Sub SolveStep1()
        Dim EmptyBoxes As Integer = 0
        For i2 = 11 To 99
            If i2.ToString.Substring(1, 1) = "0" Then
                i2 += 1
            End If
            If var("var" & i2).Length = 1 Then

            Else
                EmptyBoxes += 1
                Dim numberToTest As Integer = 1
                Dim PossibleNumber As Integer = 0
                Dim LastSuccess As String
                For i = 0 To 9
                    If var("var" & i2) = "" Then
                        var("var" & i2) = numberToTest + i
                        var("var" & i2 & "tag") = "TESTED"
                        txtBoxChanges("var" & i2, numberToTest + i)
                    ElseIf var("var" & i2 & "tag") = "TESTED" Then
                        PossibleNumber += 1
                        LastSuccess = var("var" & i2)
                        var("var" & i2) = numberToTest + i
                        var("var" & i2 & "tag") = "TESTED"
                        txtBoxChanges("var" & i2, numberToTest + i)
                    End If
                Next
                If PossibleNumber = "1" Then
                    var("var" & i2) = LastSuccess
                    var("var" & i2 & "tag") = "rndm"
                    txtBoxChanges("var" & i2, LastSuccess)
                Else
                    var("var" & i2) = ""
                    var("var" & i2 & "tag") = ""

                End If
            End If
        Next
        If LastEmptyBoxes <> EmptyBoxes Then
            If EmptyBoxes > 0 Then
                TimeOut += 1
                If TimeOut < 81 Then
                    LastEmptyBoxes = EmptyBoxes
                    SolveStep2()
                    SolveStep1()
                End If
            End If
        End If
    End Sub
    Private Sub SolveStep2()
        Dim squareNumber() As Integer = {11, 14, 17, 31, 34, 37, 61, 64, 67}
        For square = 1 To 9
            Dim box As Integer = squareNumber(square - 1)
            Dim x As Integer = box.ToString.Substring(0, 1)
            Dim y As Integer = box.ToString.Substring(1, 1)
            x = Math.Ceiling(x / 3) - 1
            y = Math.Ceiling(y / 3) - 1
            x = 11 + (30 * x)
            y = (y * 3)
            Dim success As Integer = 0
            Dim lastCellWorked As String = ""
            Dim lastSuccNum As String = ""
            For num = 1 To 9
                For i1 = 0 To 2
                    For i = 0 To 2
                        If var("var" & (x + (i1 * 10)) + y + i) = "" Then
                            var("var" & (x + (i1 * 10)) + y + i) = num

                            txtBoxChanges("var" & (x + (i1 * 10)) + y + i, num)

                            If var("var" & (x + (i1 * 10)) + y + i) <> "" Then
                                success += 1
                                lastCellWorked = ((x + (i1 * 10)) + y + i)
                                lastSuccNum = num
                            End If
                            var("var" & (x + (i1 * 10)) + y + i) = ""
                        End If
                    Next
                Next
                If success = 1 Then
                    var("var" & lastCellWorked) = lastSuccNum
                    var("var" & lastCellWorked & "tag") = "rndm"
                End If
                success = 0
                lastCellWorked = ""
                lastSuccNum = ""
            Next
        Next
    End Sub
    Public Sub Generate()
        Dim Number As String = 1
        For i = 11 To 99
            Randomize()
            If i.ToString.Substring(1, 1) = "0" Then
                i += 1
            End If
            If var("var" & i) = "" Then
                For i2 = 1 To 9
                    var("var" & i) = Number
                    var("var" & i & "tag") = "rndm"
                    txtBoxChanges("var" & i, Number)
                    Randomize()
                    Number += CInt(Int((9 * Rnd()) + 1))
                    If Number > 9 Then
                        Number = 1
                    End If
                Next
            End If
            If var("var" & i) = "" Then
                var("var" & i & "tag") = ""
            End If
        Next
        SolveStep1()
    End Sub
    Function CheckIfSolves() As Integer
        Dim Solved As Boolean = False
        Dim EmptyBoxes As Integer = 0
        For Each cntl In Me.Controls
            If TypeOf (cntl) Is System.Windows.Forms.TextBox Then

                If var(cntl.Name.ToString.Replace("txt", "var")).Length = 1 Then
                    EmptyBoxes += 1
                End If
            End If
        Next
        Return EmptyBoxes
    End Function
    Public Sub Solve()
        Do Until CheckIfSolves() = 81
            SolveStep1()
            Occurances = 0
            If CheckIfSolves() > 62 Then
                For i = 1 To 9
                    Dim cnt As Integer = 0
                    For Each cntl In Me.Controls
                        If TypeOf (cntl) Is System.Windows.Forms.TextBox Then
                            If var(cntl.Name.ToString.Replace("txt", "var")) = i.ToString Then
                                cnt += 1
                            End If
                        End If
                    Next
                    If cnt <> 9 Then
                        Occurances += 1
                        For Each cntl In Me.Controls
                            If TypeOf (cntl) Is System.Windows.Forms.TextBox Then
                                If var(cntl.Name.ToString.Replace("txt", "var")) = i.ToString And var(cntl.Name.ToString.Replace("txt", "var") & "tag") = "rndm" Then
                                    ' cntl.Text = ""
                                    var(cntl.Name.ToString.Replace("txt", "var")) = ""
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            Generate()
            If CheckIfSolves() = 81 Then
                For Each cntl In Me.Controls
                    If TypeOf (cntl) Is System.Windows.Forms.TextBox Then
                        cntl.Text = var(cntl.Name.ToString.Replace("txt", "var"))
                    End If
                Next
            Else
                If FirstTry < 100 Then
                    FirstTry += 1
                Else
                    random1 += 3
                    If random1 > 9 Then
                        random1 = 3
                        random2 += 3
                    End If
                    If random2 > 9 Then
                        random2 = 3
                    End If
                    For i2 = 1 To random1
                        For i = 1 To random2
                            If var("var" & i2 & i & "tag") = "rndm" Then
                                var("var" & i2 & i) = ""
                            End If
                        Next
                    Next
                    Generate()
                    FirstTry = 0
                End If
            End If
        Loop
    End Sub
    Private Sub SolveButton_Click(sender As System.Object, e As System.EventArgs) Handles SolveButton.Click
        Solve()
    End Sub
    Private Sub ClearAll_Click(sender As Object, e As EventArgs) Handles ClearAll.Click
        For Each cntl In Me.Controls
            If TypeOf (cntl) Is System.Windows.Forms.TextBox Then
                cntl.clear()
                cntl.Tag = ""
                var(cntl.Name.ToString.Replace("txt", "var")) = ""
                var(cntl.Name.ToString.Replace("txt", "var") & "tag") = ""
            End If
        Next
    End Sub
    Public Sub GeneratePuzzleEASY()
        If CheckIfSolves() = 81 Then
            For Each cntl In Me.Controls
                If TypeOf (cntl) Is System.Windows.Forms.TextBox Then
                    cntl.Tag = ""
                    var(cntl.Name.ToString.Replace("txt", "var") & "tag") = ""
                End If
            Next

            For i = 1 To 20 ' change 50 to any number between 1 and 81. The lower the easier
                Randomize()
                Dim part1 As Integer = CInt(Int((9 * Rnd()) + 1))
                Randomize()
                Dim part2 As Integer = CInt(Int((9 * Rnd()) + 1))

                If Me.Controls("txt" & part1 & part2).Text = "" Then
                    i -= 1
                Else
                    Me.Controls("txt" & part1 & part2).Text = ""
                    var("var" & part1 & part2) = ""
                End If

            Next

        Else
            MsgBox("Please try again")
        End If
    End Sub
    Public Sub GeneratePuzzleNORMAL()
        If CheckIfSolves() = 81 Then
            For Each cntl In Me.Controls
                If TypeOf (cntl) Is System.Windows.Forms.TextBox Then
                    cntl.Tag = ""
                    var(cntl.Name.ToString.Replace("txt", "var") & "tag") = ""
                End If
            Next

            For i = 1 To 40 ' change 50 to any number between 1 and 81. The lower the easier
                Randomize()
                Dim part1 As Integer = CInt(Int((9 * Rnd()) + 1))
                Randomize()
                Dim part2 As Integer = CInt(Int((9 * Rnd()) + 1))

                If Me.Controls("txt" & part1 & part2).Text = "" Then
                    i -= 1
                Else
                    Me.Controls("txt" & part1 & part2).Text = ""
                    var("var" & part1 & part2) = ""
                End If

            Next

        Else
            MsgBox("Please try again")
        End If
    End Sub
    Public Sub GeneratePuzzleHARD()
        If CheckIfSolves() = 81 Then
            For Each cntl In Me.Controls
                If TypeOf (cntl) Is System.Windows.Forms.TextBox Then
                    cntl.Tag = ""
                    var(cntl.Name.ToString.Replace("txt", "var") & "tag") = ""
                End If
            Next

            For i = 1 To 60 ' change 50 to any number between 1 and 81. The lower the easier
                Randomize()
                Dim part1 As Integer = CInt(Int((9 * Rnd()) + 1))
                Randomize()
                Dim part2 As Integer = CInt(Int((9 * Rnd()) + 1))

                If Me.Controls("txt" & part1 & part2).Text = "" Then
                    i -= 1
                Else
                    Me.Controls("txt" & part1 & part2).Text = ""
                    var("var" & part1 & part2) = ""
                End If

            Next

        Else
            MsgBox("Please try again")
        End If
    End Sub
    Public Sub GeneratePuzzleINSANE()
        If CheckIfSolves() = 81 Then
            For Each cntl In Me.Controls
                If TypeOf (cntl) Is System.Windows.Forms.TextBox Then
                    cntl.Tag = ""
                    var(cntl.Name.ToString.Replace("txt", "var") & "tag") = ""
                End If
            Next

            For i = 1 To 70 ' change 50 to any number between 1 and 81. The lower the easier
                Randomize()
                Dim part1 As Integer = CInt(Int((9 * Rnd()) + 1))
                Randomize()
                Dim part2 As Integer = CInt(Int((9 * Rnd()) + 1))

                If Me.Controls("txt" & part1 & part2).Text = "" Then
                    i -= 1
                Else
                    Me.Controls("txt" & part1 & part2).Text = ""
                    var("var" & part1 & part2) = ""
                End If

            Next

        Else
            MsgBox("Please try again")
        End If
    End Sub
    Private Sub GenerateButton_Click(sender As Object, e As EventArgs) Handles GenerateButton.Click
        If Combo_Diff.Text = "Easy" Then
            Solve()
            GeneratePuzzleEASY()
        ElseIf Combo_Diff.Text = "Normal" Then
            Solve()
            GeneratePuzzleNORMAL()
        ElseIf Combo_Diff.Text = "Hard" Then
            Solve()
            GeneratePuzzleHARD()
        ElseIf Combo_Diff.Text = "Insane" Then
            Solve()
            GeneratePuzzleINSANE()
        ElseIf Combo_Diff.Text = "" Then
            MessageBox.Show("Please Select Difficulty First!")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Help.Show()
    End Sub
End Class
