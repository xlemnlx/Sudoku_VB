Public Class Help

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim link As String = "http://www.instructables.com/id/Sudoku%3asolving-it-for-beginners-and-the-expirience/?ALLSTEPS"
        Process.Start(link)
    End Sub
    Private Sub butun1_next_Click(sender As Object, e As EventArgs) Handles butun1_next.Click
        butun2_next.Visible = True
        butun1_back.Visible = True
        GroupBox2.Visible = True
        GroupBox1.Visible = False
        butun1_next.Visible = False
    End Sub
    Private Sub butun1_back_Click(sender As Object, e As EventArgs) Handles butun1_back.Click
        butun1_next.Visible = True
        GroupBox1.Visible = True
        butun2_next.Visible = False
        butun1_back.Visible = False
        GroupBox2.Visible = False
    End Sub
    Private Sub butun2_next_Click(sender As Object, e As EventArgs) Handles butun2_next.Click
        GroupBox3.Visible = True
        butun3_next.Visible = True
        butun2_back.Visible = True
        butun1_back.Visible = False
        butun2_next.Visible = False
        GroupBox2.Visible = False
    End Sub
    Private Sub butun2_back_Click(sender As Object, e As EventArgs) Handles butun2_back.Click
        GroupBox2.Visible = True
        butun2_next.Visible = True
        butun1_back.Visible = True
        butun2_back.Visible = False
        butun3_next.Visible = False
        GroupBox3.Visible = False
    End Sub
    Private Sub butun3_next_Click(sender As Object, e As EventArgs) Handles butun3_next.Click
        GroupBox4.Visible = True
        butun3_back.Visible = True
        butun2_back.Visible = False
        butun3_next.Visible = False
        GroupBox3.Visible = False
    End Sub
    Private Sub butun3_back_Click(sender As Object, e As EventArgs) Handles butun3_back.Click
        GroupBox3.Visible = True
        butun3_next.Visible = True
        butun2_back.Visible = True
        butun3_back.Visible = False
        GroupBox4.Visible = False
    End Sub
End Class