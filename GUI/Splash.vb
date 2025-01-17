Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Public Class Splash
    Const timer_interval As Integer = 15 ' INTERVAL IN MILLISECONDS

    Protected current_gradient_shift As Integer = 10

    Protected gradiant_step As Integer = 5
    Private Sub Splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Interval = timer_interval
        Timer2.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        ProgressBar1.Visible = True
        ProgressBar1.Value = ProgressBar1.Value + 1
        If (ProgressBar1.Value = 10) Then
            Lbl3.Text = "Reading modules.."
        ElseIf (ProgressBar1.Value = 20) Then
            Lbl3.Text = "Turning on modules."
        ElseIf (ProgressBar1.Value = 40) Then
            Lbl3.Text = "Starting modules.."
        ElseIf (ProgressBar1.Value = 60) Then
            Lbl3.Text = "Loading modules.."
        ElseIf (ProgressBar1.Value = 80) Then
            Lbl3.Text = "Done Loading modules.."
        ElseIf (ProgressBar1.Value = 100) Then
            Login.Show()
            Timer2.Enabled = False
            Me.Hide()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'SET THE GRAPHICS OBJECT IN THE FORM
        Dim grafx As Graphics = CreateGraphics()
        'SET AND DETERMINE THE SIZE,FONT AND TEXT.
        Dim fnt As New Font("Segoe UI", 30,
        FontStyle.Regular, GraphicsUnit.Point)

        Dim start_text As String = "SAYMAN TEXTILE" 'APPEAR THE TEXT IN THE FIRST LOAD
        Dim fnt_size As New SizeF(grafx.MeasureString(start_text, fnt))



        'SET THE TEXT THAT TO BE CENTERED IN THE CLIENT AREA.

        Dim ptf_text_start As New PointF( _
        CSng(ClientSize.Width - fnt_size.Width) / 2, _
        CSng(ClientSize.Height - fnt_size.Height) / 2)

        'FOR THE ANIMATION EFFECT, SET THE GRADIENT START AND ITS END POINT.
        Dim ptf_gradient_start As New PointF(0, 0)
        Dim ptf_gradient_end As New PointF(current_gradient_shift, 130)

        'USE THE BRUSH FOR DRAWING THE TEXT.
        Dim gradient_brush As New LinearGradientBrush(ptf_gradient_start, _
        ptf_gradient_end, Color.Black, BackColor)
        'THE TEXT DRAW AT THE CENTERED OF THE CLIENT AREA.
        grafx.DrawString(start_text, fnt, gradient_brush, ptf_text_start)
        grafx.Dispose()

        'REVERSING THE GRADIENT WHEN IT GETS TO A CERTAIN VALUE
        current_gradient_shift += gradiant_step
        If current_gradient_shift = 500 Then
            gradiant_step = -5
        ElseIf current_gradient_shift = -50 Then
            gradiant_step = 5
        End If

    End Sub
End Class