<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SolveButton = New System.Windows.Forms.Button()
        Me.ClearAll = New System.Windows.Forms.Button()
        Me.GenerateButton = New System.Windows.Forms.Button()
        Me.Combo_Diff = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SolveButton
        '
        Me.SolveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SolveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SolveButton.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SolveButton.Location = New System.Drawing.Point(6, 84)
        Me.SolveButton.Name = "SolveButton"
        Me.SolveButton.Size = New System.Drawing.Size(156, 25)
        Me.SolveButton.TabIndex = 0
        Me.SolveButton.Text = "SHOW ANSWER"
        Me.SolveButton.UseVisualStyleBackColor = False
        '
        'ClearAll
        '
        Me.ClearAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearAll.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearAll.Location = New System.Drawing.Point(6, 115)
        Me.ClearAll.Name = "ClearAll"
        Me.ClearAll.Size = New System.Drawing.Size(156, 25)
        Me.ClearAll.TabIndex = 1
        Me.ClearAll.Text = "CLEAR"
        Me.ClearAll.UseVisualStyleBackColor = False
        '
        'GenerateButton
        '
        Me.GenerateButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GenerateButton.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GenerateButton.Location = New System.Drawing.Point(6, 53)
        Me.GenerateButton.Name = "GenerateButton"
        Me.GenerateButton.Size = New System.Drawing.Size(156, 25)
        Me.GenerateButton.TabIndex = 2
        Me.GenerateButton.Text = "GENERATE PUZZLE"
        Me.GenerateButton.UseVisualStyleBackColor = False
        '
        'Combo_Diff
        '
        Me.Combo_Diff.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_Diff.FormattingEnabled = True
        Me.Combo_Diff.Items.AddRange(New Object() {"Easy", "Normal", "Hard", "Insane"})
        Me.Combo_Diff.Location = New System.Drawing.Point(6, 24)
        Me.Combo_Diff.Name = "Combo_Diff"
        Me.Combo_Diff.Size = New System.Drawing.Size(156, 23)
        Me.Combo_Diff.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Combo_Diff)
        Me.GroupBox1.Controls.Add(Me.SolveButton)
        Me.GroupBox1.Controls.Add(Me.ClearAll)
        Me.GroupBox1.Controls.Add(Me.GenerateButton)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(341, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 149)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Difficulty"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(403, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 100)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(540, 364)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SolveButton As System.Windows.Forms.Button
    Friend WithEvents ClearAll As System.Windows.Forms.Button
    Friend WithEvents GenerateButton As System.Windows.Forms.Button
    Friend WithEvents Combo_Diff As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
