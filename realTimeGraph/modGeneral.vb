Module modGeneral
    Public timer_Espera As System.Timers.Timer = New System.Timers.Timer()        'cree la variable y ya la inicialice
    Public f_ExpiredEspera As Boolean = False


    Public Sub Espera(ByVal miliseg_ As Double)

        'f_ExpiredEspera = False
        timer_Espera.Interval = miliseg_
        timer_Espera.Enabled = True
        timer_Espera.Start()

        AddHandler timer_Espera.Elapsed, AddressOf TimerEventEspera

        Do Until f_ExpiredEspera = True
            Application.DoEvents()
        Loop

    End Sub

    'EVENTOS DE TIMERS
    Private Sub TimerEventEspera(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        timer_Espera.Stop()
        f_ExpiredEspera = True
    End Sub
End Module
