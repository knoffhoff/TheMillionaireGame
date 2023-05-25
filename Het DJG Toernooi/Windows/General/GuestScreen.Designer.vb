Private ColorBlack As System.Drawing.Color = System.Drawing.Color.Black
Private ColorWhite As System.Drawing.Color = System.Drawing.Color.White
Private FontStyleRegular As System.Drawing.FontStyle = System.Drawing.FontStyle.Regular

<System.Diagnostics.DebuggerStepThrough()>
Private Sub InitializeComponent()
    InitializePictureBoxes()
    InitializeTextBoxes()
    InitializeLabels()
    InitializePanels()
    InitializeOtherComponents()
    AddAllControlsToForm()
End Sub

Private Sub InitializePictureBoxes()
    Me.picVO = New PictureBox()
    InitializePictureBox(Me.picVO, New System.Drawing.Point(964, 11), New System.Drawing.Size(94, 65), 73, False, Global.MillionaireGame.My.Resources.Resources.lifeline_2, System.Windows.Forms.PictureBoxSizeMode.StretchImage)

    Me.picSW = New PictureBox()
    InitializePictureBox(Me.picSW, New System.Drawing.Point(1064, 11), New System.Drawing.Size(94, 65), 70, False, Global.MillionaireGame.My.Resources.Resources.lifeline_4, System.Windows.Forms.PictureBoxSizeMode.StretchImage)

    Me.picPO = New PictureBox()
    InitializePictureBox(Me.picPO, New System.Drawing.Point(764, 11), New System.Drawing.Size(94, 65), 71, False, Global.MillionaireGame.My.Resources.Resources.lifeline_3, System.Windows.Forms.PictureBoxSizeMode.StretchImage)

    Me.pic50 = New PictureBox()
    InitializePictureBox(Me.pic50, New System.Drawing.Point(864, 11), New System.Drawing.Size(94, 65), 69, False, Global.MillionaireGame.My.Resources.Resources.lifeline_1, System.Windows.Forms.PictureBoxSizeMode.StretchImage)

    Me.picTree = New PictureBox()
    InitializePictureBox(Me.picTree, New System.Drawing.Point(351, -51), New System.Drawing.Size(921, 501), 67, False, Global.MillionaireGame.My.Resources.Resources._0_tree_0, System.Windows.Forms.PictureBoxSizeMode.StretchImage)
End Sub

Private Sub InitializeTextBoxes()
    Me.txtATAd = New TextBox()
    InitializeTextBox(Me.txtATAd, ColorBlack, ColorWhite, New System.Drawing.Font("Copperplate Gothic Bold", 24.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(776, 157), "txtATAd", System.Windows.Forms.RightToLeft.Yes, New System.Drawing.Size(182, 36), 75, System.Windows.Forms.HorizontalAlignment.Right)

    Me.txtATAc = New TextBox()
    InitializeTextBox(Me.txtATAc, ColorBlack, ColorWhite, New System.Drawing.Font("Copperplate Gothic Bold", 24.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(776, 116), "txtATAc", System.Windows.Forms.RightToLeft.Yes, New System.Drawing.Size(182, 36), 76, System.Windows.Forms.HorizontalAlignment.Right)

    Me.txtATAb = New TextBox()
    InitializeTextBox(Me.txtATAb, ColorBlack, ColorWhite, New System.Drawing.Font("Copperplate Gothic Bold", 24.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(776, 75), "txtATAb", System.Windows.Forms.RightToLeft.Yes, New System.Drawing.Size(182, 36), 74, System.Windows.Forms.HorizontalAlignment.Right)

    Me.txtATAa = New TextBox()
    InitializeTextBox(Me.txtATAa, ColorBlack, ColorWhite, New System.Drawing.Font("Copperplate Gothic Bold", 24.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(776, 34), "txtATAa", System.Windows.Forms.RightToLeft.Yes, New System.Drawing.Size(182, 36), 72, System.Windows.Forms.HorizontalAlignment.Right)
End Sub

Private Sub InitializeLabels()
    Me.lblTime = New Label()
    InitializeLabel(Me.lblTime, False, ColorWhite, New System.Drawing.Font("Copperplate Gothic Bold", 72.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(777, 245), "30", "lblTime", New System.Drawing.Size(181, 107), 68, System.Drawing.ContentAlignment.MiddleRight)

    me.txtD = New Label()
    InitializeLabel(Me.txtD, ColorTransparent, ColorWhite, New System.Drawing.Font("Calibri", 24.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(123, 6), "D:", "txtD", New System.Drawing.Size(476, 45), 20, System.Drawing.ContentAlignment.MiddleLeft)

    Me.txtC = New Label()
    InitializeLabel(Me.txtC, ColorTransparent, ColorWhite, New System.Drawing.Font("Calibri", 24.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(123, 6), "C:", "txtC", New System.Drawing.Size(476, 45), 18, System.Drawing.ContentAlignment.MiddleLeft)

    Me.txtB = New Label()
    InitializeLabel(Me.txtB, ColorTransparent, ColorWhite, New System.Drawing.Font("Calibri", 24.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(123, 6), "B:", "txtB", New System.Drawing.Size(476, 45), 19, System.Drawing.ContentAlignment.MiddleLeft)

    Me.txtA = New Label()
    InitializeLabel(Me.txtA, ColorTransparent, ColorWhite, New System.Drawing.Font("Calibri", 24.0!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(123, 6), "A:", "txtA", New System.Drawing.Size(476, 45), 17, System.Drawing.ContentAlignment.MiddleLeft)

    Me.txtQuestion = New Label()
    InitializeLabel(Me.txtQuestion, ColorTransparent, ColorWhite, New System.Drawing.Font("Calibri", 20.25!, FontStyleRegular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), New System.Drawing.Point(132, 13), "", "txtQuestion", New System.Drawing.Size(1016, 69), 13, System.Drawing.ContentAlignment.MiddleCenter)

    Me.txtWinningStrap = New Label()
    InitializeLabel(Me.txtWinningStrap, ColorTransparent, ColorWhite, New System.Drawing.Font("Copperplate Gothic Bold", 38.0!), New System.Drawing.Point(421, 84), "1.000.000", "txtWinningStrap", New System.Drawing.Size(438, 55), 0, System.Drawing.ContentAlignment.MiddleCenter)
End Sub

Private Sub InitializePanels()
    Me.pnlD = New Panel()
    InitializePanel(Me.pnlD, Global.MillionaireGame.My.Resources.Resources.Normal_Answer_Fill_r, System.Windows.Forms.ImageLayout.None, New System.Drawing.Point(-9, 612), "pnlD", New System.Drawing.Size(641, 57), 78)

    Me.pnlB = New Panel()
    InitializePanel(Me.pnlB, Global.MillionaireGame.My.Resources.Resources.Normal_Answer_Fill_l, System.Windows.Forms.ImageLayout.None, New System.Drawing.Point(-9, 612), "pnlB", New System.Drawing.Size(641, 57), 78)

    Me.pnlC = New Panel()
    InitializePanel(Me.pnlC, Global.MillionaireGame.My.Resources.Resources.Normal_Answer_Fill_r, System.Windows.Forms.ImageLayout.None, New System.Drawing.Point(-9, 612), "pnlC", New System.Drawing.Size(641, 57), 78)

    Me.pnlA = New Panel()
    InitializePanel(Me.pnlA, Global.MillionaireGame.My.Resources.Resources.Normal_Answer_Fill_l, System.Windows.Forms.ImageLayout.None, New System.Drawing.Point(-9, 612), "pnlA", New System.Drawing.Size(641, 57), 78)

    Me.picQuestion = New Panel()
    InitializePanel(Me.picQuestion, Global.MillionaireGame.My.Resources.Resources.Large_Strap_Fill, System.Windows.Forms.ImageLayout.None, New System.Drawing.Point(-9, 453), "picQuestion", New System.Drawing.Size(1280, 93), 81)

    Me.pnlStrap = New Panel()
    InitializePanel(Me.pnlStrap, Global.MillionaireGame.My.Resources.Resources.winning_strap, System.Windows.Forms.ImageLayout.Center, New System.Drawing.Point(-8, 453), "pnlStrap", New System.Drawing.Size(1280, 225), 82, False)
End Sub

Private Sub InitializeOtherComponents()
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = ColorBlack
    Me.ClientSize = New System.Drawing.Size(1264, 681)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.Name = "GuestScreen"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Guest Screen"
End Sub

Private Sub AddAllControlsToForm()
    Me.Controls.Add(Me.pnlStrap)
    Me.Controls.Add(Me.picVO)
    Me.Controls.Add(Me.picSW)
    Me.Controls.Add(Me.picPO)
    Me.Controls.Add(Me.pic50)
    Me.Controls.Add(Me.picTree)
    Me.Controls.Add(Me.txtATAd)
    Me.Controls.Add(Me.txtATAc)
    Me.Controls.Add(Me.txtATAb)
    Me.Controls.Add(Me.txtATAa)
    Me.Controls.Add(Me.lblTime)
    Me.Controls.Add(Me.txtD)
    Me.Controls.Add(Me.txtC)
    Me.Controls.Add(Me.txtB)
    Me.Controls.Add(Me.txtA)
    Me.Controls.Add(Me.txtQuestion)
    Me.Controls.Add(Me.txtWinningStrap)
    Me.Controls.Add(Me.pnlD)
    Me.Controls.Add(Me.pnlC)
    Me.Controls.Add(Me.pnlB)
    Me.Controls.Add(Me.pnlA)
    Me.Controls.Add(Me.picQuestion)
    Me.SuspendLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()
End Sub


Private Sub InitializePictureBox(pictureBox As PictureBox, location As System.Drawing.Point, size As System.Drawing.Size, tabIndex As Integer, visible As Boolean, backgroundImage As Image, backgroundLayout As PictureBoxSizeMode)
    pictureBox.Location = location
    pictureBox.Name = pictureBox.Name
    pictureBox.Size = size
    pictureBox.TabIndex = tabIndex
    pictureBox.Visible = visible
    pictureBox.BackgroundImage = backgroundImage
    pictureBox.BackgroundImageLayout = backgroundLayout
End Sub

Private Sub InitializeTextBox(textBox As TextBox, backColor As System.Drawing.Color, foreColor As System.Drawing.Color, font As System.Drawing.Font, location As System.Drawing.Point, name As String, rightToLeft As System.Windows.Forms.RightToLeft, size As System.Drawing.Size, tabIndex As Integer, textAlign As System.Windows.Forms.HorizontalAlignment)
    textBox.BackColor = backColor
    textBox.Font = font
    textBox.ForeColor = foreColor
    textBox.Location = location
    textBox.Name = name
    textBox.RightToLeft = rightToLeft
    textBox.Size = size
    textBox.TabIndex = tabIndex
    textBox.TextAlign = textAlign
End Sub

Private Sub InitializeLabel(label As Label, autoSize As Boolean, foreColor As System.Drawing.Color, font As System.Drawing.Font, location As System.Drawing.Point, text As String, name As String, size As System.Drawing.Size, tabIndex As Integer, textAlign As System.Drawing.ContentAlignment)
    label.AutoSize = autoSize
    label.ForeColor = foreColor
    label.Font = font
    label.Location = location
    label.Text = text
    label.Name = name
    label.Size = size
    label.TabIndex = tabIndex
    label.TextAlign = textAlign
End Sub

Private Sub InitializePanel(panel As Panel, backgroundImage As Image, backgroundLayout As System.Windows.Forms.ImageLayout, location As System.Drawing.Point, name As String, size As System.Drawing.Size, tabIndex As Integer)
    panel.BackgroundImage = backgroundImage
    panel.BackgroundImageLayout = backgroundLayout
    panel.Location = location
    panel.Name = name
    panel.Size = size
    panel.TabIndex = tabIndex
End Sub
