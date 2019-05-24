Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Math

''' <summary>
''' Trama que envia el EL-05B
''' estatus peso CR
''' estatus 1 byte
''' 7 6 5 4 3 2 1 0  N°  de bit (PESO)
''' 0 1 2 3 4 5 6 7  Orden en el vector statusBin
''' 0 1 0 · · · · X  0 = Peso Bruto / 1 = Peso Neto
''' 0 1 0 · · · X ·  1 = Centro de Cero ± ¼ división
''' 0 1 0 · · X · ·  0 = Peso en movimiento / 1 = Peso en Equilibrio
''' 0 1 0 · X · · ·  0 = Peso positivo / 1 = Peso negativo
''' 0 1 0 X · · · ·  0 = funcionamiento normal / 1 = Fuera de Rango
''' peso: 6 caracteres sin punto decimal, con ceros a la izquierda . 999999 kg = 999,999T
''' CR 0Dh
''' Este equipo manda datos todo el tiempo,a una velocidad fija, que no sabemos cual es, por lo tanto no podemos saber el tiempo de muestreo
''' 
''' Actualizacion 2019
''' Agregado lectura de sensor de temperatura
''' 
''' 
''' 
''' </summary>


Public Class main

    'INTERFACE
    'config puerto
    Public objPort As New SerialPort()
    Dim portName As String
    Dim portBaudRate As Integer
    Dim availablesPort As String()

    Dim constCalibracion As Double

    'config de dispositivos
    Const dirPC = 1
    Const dirRemota = &H7
    Dim currentDevice As Integer    'para seleccionar entre el mio (0) y el comprado (1), (2) sensor de temperatura

    'Medidor EL05B
    Dim tramaIn As String
    Dim status As String
    Dim statusByte() As Byte
    Dim statusBin(7) As Integer
    Dim peso As String
    Dim convenio As String


    'ref comunicación
    'config comandos
    Const cmdSaludo = &H73      's (saludo)
    Const cmdLectura = &H6C     'l(lectura)
    Const cmdEscala = &H65      'e (escala)
    Const cmdTarar = &H74       't (tarar)
    Const cmdConfig = &H43      'C (Config)
    Const cmdDesconectar = &H44 'D (Desconectar)
    Public Const cmdCalibrar = &H63 'c (calibrar)

    'ref manejo de archivos
    'config paths
    Const DEFAULT_PATH = "C:\"
    Const resultDir = "_Soft_Celda_Carga\"

    Dim ApplicationMainPath As String = Path.GetDirectoryName(Application.ExecutablePath)
    Private Const fileConfig = "\config\config.conf"

    'config archivos
    Dim sourceFile As String        'la direccion de donde esta leyendo el archivo que esta graficando
    Dim currentFile As String       'el archivo actual donde se van a guardar los datos adquiridos en tiempo real
    Dim prevFile As String

    'config grafico

    Dim currentSeriesName As String         'nombre de la serie en el grafico
    Const marcas = "marcas"

    Dim x_max As Integer


    'ENSAYO
    'config ensayo
    Dim tiempoMuestreo As Integer
    Dim medidaIn As Single          'los datos de mi medidor
    Dim vecTime As Integer

    Dim f_parpadeo As Boolean

    'actualizacion 2019
    Dim requestDato As String = "r"
    Dim valueIn As Double

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Control.CheckForIllegalCrossThreadCalls = False
        Size = New Size(965, 513)

        estadoInicialInterface()

        loadConfig()

        initBuff(dirPC)

        If listAllPorts() = False Then
            cbPorts.Text = "NO PORTS FOUND"
            btConect.Enabled = True
            btConect.Text = "Reintentar"
        End If

        configGraf()

        cbDispositivo.SelectedIndex = 0
        txNombreSerie.Text = "nombreSerie_" & getFecha() & getHora()

        lbEstado.BackColor = SystemColors.Control
        lbEstado.Text = "Estado: Desconectado"

    End Sub


    Private Sub btConect_Click(sender As Object, e As EventArgs) Handles btConect.Click
        If btConect.Text = "Conectar" Then

            lbEstado.BackColor = Color.Orange
            lbEstado.Text = "Estado: CONECTANDO..."

            currentDevice = cbDispositivo.SelectedIndex

            openPort()
            Espera(7)

            txNombreSerie.Enabled = True
            cTiempoMuestreo.Enabled = True
            btIniciar.Enabled = True
            btTarar.Enabled = True

            cbDispositivo.Enabled = False
            cbPorts.Enabled = False

            If currentDevice = 0 Then
                arrayDatos(0) = cmdSaludo
                SendNumByte(dirRemota, 1)
                objPort.Write(vectorEnviar, 0, 64)
            End If

            btConect.Text = "Desconectar"
            lbEstado.BackColor = Color.GreenYellow
            lbEstado.Text = "Estado: CONECTADO"

        ElseIf btConect.Text = "Desconectar" Then
            btConect.Text = "Conectar"

            lbEstado.BackColor = SystemColors.Control
            lbEstado.Text = "Estado: Desconectado"

            If currentDevice = 0 Then
                arrayDatos(0) = cmdDesconectar
                SendNumByte(dirRemota, 1)
                objPort.Write(vectorEnviar, 0, 64)
            End If

            objPort.Close()

            txNombreSerie.Enabled = False
            cTiempoMuestreo.Enabled = False
            btIniciar.Enabled = False
            btTarar.Enabled = False

            cbDispositivo.Enabled = True
            cbPorts.Enabled = True


        ElseIf btConect.Text = "Reintentar" Then
            If listAllPorts() = False Then
                btConect.Text = "Reintentar"
            Else
                btConect.Text = "Conectar"
                btConect.Enabled = False
                cbPorts.Text = "Seleccione..."
            End If

        End If

    End Sub


    Private Sub btIniciar_Click(sender As Object, e As EventArgs) Handles btIniciar.Click
        'inicia la adquisición en tiempo real
        configGraf()
        bloquearControles()

        btIniciar.Enabled = False
        btPausa.Enabled = True
        btDetener.Enabled = True
        btMarcaTemporal.Enabled = True

        tiempoMuestreo = CInt(cTiempoMuestreo.Value)

        currentFile = txNombreSerie.Text & ".txt"
        createHeader()

        If currentDevice = 0 Then
            Timer1.Interval = tiempoMuestreo * 1000
            Timer1.Enabled = True
        End If

        If currentDevice = 1 Then
            Timer3.Interval = tiempoMuestreo * 1000
            Timer3.Enabled = True
        End If

        If currentDevice = 2 Then
            'vemos
            Timer4.Interval = tiempoMuestreo * 1000
            Timer4.Enabled = True
        End If

    End Sub


    Private Sub btPausa_Click(sender As Object, e As EventArgs) Handles btPausa.Click
        'solo para el timer pero no borra nada ni libera ningun boton
        If f_parpadeo = False Then
            f_parpadeo = True
            Timer2.Enabled = True   'el del parpadeo

            Select Case currentDevice
                Case 0
                    Timer1.Enabled = False  'el principal
                Case 1
                    Timer3.Enabled = False
                Case 2
                    Timer4.Enabled = False
            End Select
            desbloquearControles()
        Else
            f_parpadeo = False
            Timer2.Enabled = False

            Select Case currentDevice
                Case 0
                    Timer1.Interval = tiempoMuestreo * 1000
                    Timer1.Enabled = True  'el principal
                Case 1
                    Timer3.Interval = tiempoMuestreo * 1000
                    Timer3.Enabled = False
                Case 2
                    Timer4.Interval = tiempoMuestreo * 1000
                    Timer4.Enabled = False
            End Select
            bloquearControles()
        End If

        btDetener.Enabled = True
        btPausa.BackColor = SystemColors.Control
    End Sub


    Private Sub btDetener_Click(sender As Object, e As EventArgs) Handles btDetener.Click
        desbloquearControles()

        btIniciar.Enabled = True
        btPausa.Enabled = False
        btDetener.Enabled = False
        btMarcaTemporal.Enabled = False

        Timer1.Enabled = False
        Timer3.Enabled = False

        vecTime = 0

        Timer2.Enabled = False
        btPausa.BackColor = SystemColors.Control

        lbTiempo.Text = 0
        lbValorInstantaneo.Text = 0

        Timer4.Enabled = False
    End Sub


    Private Sub btTarar_Click(sender As Object, e As EventArgs) Handles btTarar.Click
        arrayDatos(0) = cmdTarar
        SendNumByte(dirRemota, 1)
        objPort.Write(vectorEnviar, 0, 64)
    End Sub


    Private Sub openFolderLog_Click(sender As Object, e As EventArgs) Handles openFolderLog.Click
        'abrir carpeta de logs
        Process.Start("explorer.exe", DEFAULT_PATH & resultDir)
    End Sub

    Private Sub cbPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPorts.SelectedIndexChanged
        portName = cbPorts.SelectedItem
        btConect.Enabled = True
    End Sub

    Private Sub txNombreSerie_TextChanged(sender As Object, e As EventArgs) Handles txNombreSerie.TextChanged
        If txNombreSerie.Text = "" Then
            Exit Sub
        End If

        currentSeriesName = txNombreSerie.Text
    End Sub

    Private Sub cTiempoMuestreo_ValueChanged(sender As Object, e As EventArgs) Handles cTiempoMuestreo.ValueChanged
        tiempoMuestreo = CInt(cTiempoMuestreo.Value)
    End Sub




    Private Sub btCargarValores_Click(sender As Object, e As EventArgs) Handles btCargarValores.Click

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        sourceFile = OpenFileDialog1.FileName

        grafDatos()

    End Sub

    Private Sub chInvertAxis_CheckedChanged(sender As Object, e As EventArgs) Handles chInvertAxis.CheckedChanged
        If graf.ChartAreas(0).AxisY.IsReversed = True Then
            graf.ChartAreas(0).AxisY.IsReversed = False
        Else
            graf.ChartAreas(0).AxisY.IsReversed = True
        End If
    End Sub




    '///////////////////////////////////////////////////////
    '///////////////MANEJO DE PUERTO SERIE//////////////////
    '///////////////////////////////////////////////////////

    Public Function openPort() As Boolean

        objPort.PortName = portName

        Select Case currentDevice
            Case 0
                objPort.BaudRate = portBaudRate
                objPort.NewLine = vbCr
            Case 1
                objPort.BaudRate = 1200
                objPort.NewLine = vbCr

            Case 2
                objPort.BaudRate = 9600
                objPort.NewLine = "/"
        End Select

        objPort.ReceivedBytesThreshold = 1
        objPort.ReadBufferSize = 64
        objPort.ReadTimeout = 150

        Try
            objPort.Open()

            AddHandler objPort.DataReceived, AddressOf onCOM
            Debug.Print("Puerto abierto")
            openPort = True
        Catch ex As Exception
            Debug.Print("No se puede conectar")
            openPort = False
        End Try

        Return openPort

    End Function


    Private Sub onCOM(sender As Object, e As SerialDataReceivedEventArgs)

        Dim buffer(64) As Byte
        Dim readBytes As Integer
        Dim totalReadBytes As Integer
        Dim offset As Integer
        Dim remaining As Integer = 10

        If currentDevice = 0 Then
            Try
                Do
                    readBytes = objPort.Read(buffer, offset, remaining)
                    offset += readBytes
                    remaining -= readBytes
                    totalReadBytes += readBytes
                Loop While remaining > 0 AndAlso readBytes > 0

            Catch ex As TimeoutException
                ReDim Preserve buffer(totalReadBytes - 1)
            End Try

            For i = 0 To buffer.Length - 1
                pushByte(buffer(i))
            Next

        ElseIf currentDevice = 1 Then
            Try
                'el otro dispositivo tien otra forma de recibir los datos
                tramaIn = objPort.ReadLine
            Catch ex As Exception

            End Try

        ElseIf currentDevice = 2 Then
            'ponemos la forma en que vamos a manejar los datos
            Try
                Dim str As String = objPort.ReadLine

                valueIn = Convert.ToDouble(str)
            Catch ex As Exception

            End Try

        End If

    End Sub


    Private Function listAllPorts() As Boolean
        'Dim aux As String()
        Dim i As Integer

        availablesPort = SerialPort.GetPortNames()

        If availablesPort.Length <= 0 Then
            listAllPorts = False
        Else
            listAllPorts = True
            'si hay puerto, relleno el comboBox
            For i = 0 To availablesPort.Length - 1
                cbPorts.Items.Add(availablesPort(i))
            Next
        End If

        Return listAllPorts
    End Function


    '///////////////////////////////////////////////////////
    '///////////////////// TIMERS //////////////////////////
    '///////////////////////////////////////////////////////

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        arrayDatos(0) = cmdLectura
        SendNumByte(dirRemota, 1)
        objPort.Write(vectorEnviar, 0, 64)

        lbTiempo.Text = vecTime

        If hayDatoOk() = 1 Then
            medidaIn = BitConverter.ToSingle(datoin.RXbuff, 0)
            clearBuff()

            Debug.Print(medidaIn)

            grafTiempoReal(medidaIn)
            saveData(medidaIn)
            lbValorInstantaneo.Text = medidaIn.ToString

            vecTime = vecTime + tiempoMuestreo
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If btPausa.BackColor = SystemColors.Control Then
            btPausa.BackColor = Color.Orange
        Else
            btPausa.BackColor = SystemColors.Control
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim aux, signo As Integer
        lbTiempo.Text = vecTime
        getData()

        '0 = Peso positivo / 1 = Peso negativo
        If statusBin(4) Then
            aux = peso * (-1)
        Else
            aux = peso
        End If

        'esto depende de la convecion de signo que se use, se cambia en el archivo de configuracion
        If convenio = "positivo" Then
            signo = -1
        Else
            signo = 1
        End If
        aux = aux * signo

        '1 = Centro de Cero ± ¼ división
        If statusBin(6) Then
            lbCentroCero.BackColor = Color.Lime
        Else
            lbCentroCero.BackColor = Color.FromArgb(0, 64, 0)
        End If

        '0 = Peso en movimiento / 1 = Peso en Equilibrio
        If statusBin(5) Then
            lbMovEqui.BackColor = Color.Lime
        Else
            lbMovEqui.BackColor = Color.FromArgb(0, 64, 0)
        End If

        '0 = funcionamiento normal / 1 = Fuera de Rango
        If statusBin(3) Then
            lbNormalOutRange.BackColor = Color.FromArgb(0, 64, 0)
            lbNormalOutRange.Text = "Fuera de rango"
        Else
            lbNormalOutRange.BackColor = Color.Lime
            lbNormalOutRange.Text = "Normal"
        End If

        grafTiempoReal(aux)
        saveData(aux)

        lbValorInstantaneo.Text = aux
        vecTime = vecTime + tiempoMuestreo


    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick


        objPort.Write(requestDato)
        lbTiempo.Text = vecTime

        grafTiempoReal(valueIn / 100)
        saveData(valueIn / 100)
        lbValorInstantaneo.Text = valueIn / 100

        vecTime = vecTime + tiempoMuestreo
    End Sub

    '///////////////////////////////////////////////////////
    '//////////////////// GRAFICOS /////////////////////////
    '///////////////////////////////////////////////////////

    Private Sub btMarcaTemporal_Click(sender As Object, e As EventArgs) Handles btMarcaTemporal.Click
        Dim index As Integer
        index = vecTime
        insertMarca(index)

        File.AppendAllText(DEFAULT_PATH & resultDir & currentFile, "*marca en tiempo: " & index & vbCrLf)

    End Sub


    Private Sub btClearGraf_Click(sender As Object, e As EventArgs) Handles btClearGraf.Click
        configGraf()
    End Sub


    Private Sub configGraf()

        graf.Series.Clear()

        x_max = 20
        graf.ChartAreas(0).AxisX.Minimum = 0
        graf.ChartAreas(0).AxisX.Maximum = x_max

        graf.Series.Add(currentSeriesName)
        graf.Series(currentSeriesName).ChartType = DataVisualization.Charting.SeriesChartType.Line

        If chInvertAxis.Checked = True Then
            graf.ChartAreas(0).AxisY.IsReversed = True
        End If

    End Sub


    Private Sub grafTiempoReal(Val2Graf_ As Double)

        graf.Series(currentSeriesName).Points.AddXY(vecTime, Val2Graf_)
        graf.Series(currentSeriesName).BorderWidth = 5

        If vecTime >= graf.ChartAreas(0).AxisX.Maximum Then
            graf.ChartAreas(0).AxisX.Maximum = vecTime + 10
        End If
    End Sub


    Private Sub grafDatos()
        Dim lectura() As String = File.ReadAllLines(sourceFile) ''lei todas las lineas
        Dim aux() As String
        Dim seriesName_ As String
        Dim i As Integer
        Dim ejeX As Integer

        aux = Split(sourceFile, "\", -1)
        seriesName_ = aux(aux.Length - 1)       'obtengo solo el nombre del archivo

        If graf.Series.IndexOf(seriesName_) <> 1 Then 'miro si existe

            graf.Series.Add(seriesName_)

            graf.Series(seriesName_).ChartType = DataVisualization.Charting.SeriesChartType.Line

            For i = 0 To lectura.Length - 1
                If InStr(lectura(i), "#", Microsoft.VisualBasic.CompareMethod.Text) = 0 And InStr(lectura(i), "*", Microsoft.VisualBasic.CompareMethod.Text) = 0 Then
                    aux = Split(lectura(i), "/", -1, Microsoft.VisualBasic.CompareMethod.Text)
                    ejeX = aux(0)

                    graf.ChartAreas(0).AxisX.Minimum = 0
                    graf.ChartAreas(0).AxisX.Maximum = ejeX + 5

                    graf.Series(seriesName_).Points.AddXY(ejeX, CInt(aux(1)))
                    graf.Series(seriesName_).BorderWidth = 5
                End If

                If InStr(lectura(i), "*", Microsoft.VisualBasic.CompareMethod.Text) = 1 Then
                    aux = Split(lectura(i), " ", -1, Microsoft.VisualBasic.CompareMethod.Text)
                    insertMarca(aux(3))
                End If
            Next
        End If
    End Sub





    '///////////////////////////////////////////////////////
    '///////////////// FUNCIONES VARIAS/////////////////////
    '///////////////////////////////////////////////////////

    Private Function loadConfig() As Boolean
        Dim i As Integer
        Dim aux() As String

        Dim path_ As String = ApplicationMainPath & fileConfig
        Dim archivo() As String = File.ReadAllLines(path_)

        For i = 0 To archivo.Length - 1
            aux = Split(archivo(i), "=", -1)
            Select Case aux(0)
                Case "portBaudRate"
                    portBaudRate = CInt(aux(1))

                Case "convenio"
                    convenio = aux(1)

            End Select

        Next

        'crear el directorio si no existe
        If Not Directory.Exists(DEFAULT_PATH & "\" & resultDir) Then
            MkDir(DEFAULT_PATH & "\" & resultDir)
        Else

        End If

        Return loadConfig
    End Function


    Private Sub bloquearControles()
        cbDispositivo.Enabled = False
        cbPorts.Enabled = False
        btConect.Enabled = False

        txNombreSerie.Enabled = False
        cTiempoMuestreo.Enabled = False

        btTarar.Enabled = False

        btCargarValores.Enabled = False
    End Sub


    Private Sub desbloquearControles()
        cbDispositivo.Enabled = True
        cbPorts.Enabled = True
        btConect.Enabled = True

        txNombreSerie.Enabled = True
        cTiempoMuestreo.Enabled = True

        btTarar.Enabled = True

        btClearGraf.Enabled = True
        btCargarValores.Enabled = True

    End Sub


    Private Sub estadoInicialInterface()
        btConect.Enabled = False
        txNombreSerie.Enabled = False
        cTiempoMuestreo.Enabled = False

        btIniciar.Enabled = False
        btPausa.Enabled = False
        btDetener.Enabled = False
        btTarar.Enabled = False

        btMarcaTemporal.Enabled = False

        lbTiempo.Text = 0
        lbValorInstantaneo.Text = 0
    End Sub


    Public Function getFecha() As String

        getFecha = DateTime.Now.ToString("yyyyMMdd") 'decidir bien el formato

        Return getFecha
    End Function


    Public Function getHora() As String

        getHora = DateTime.Now.ToString("HHmmss")

        Return getHora
    End Function


    Private Sub saveData(val2save_ As String)
        'campos: vecTime    dato   marcaFecha      marcaHora
        Dim marcaFecha, marcaHora As String
        Dim str As String
        Dim datoStr As String
        Const separador = "/"

        datoStr = medidaIn.ToString

        marcaFecha = getFecha()
        marcaHora = getHora()

        str = vecTime & separador & val2save_ & separador & marcaFecha & separador & marcaHora & vbCrLf
        File.AppendAllText(DEFAULT_PATH & resultDir & currentFile, str)

    End Sub


    Private Sub createHeader()
        Dim header As String
        Dim str As String
        str = cbDispositivo.SelectedItem.ToString

        header = "#Tiempo (s) / Lectura (kg) / marcaFecha (aaaaMMdd) / marcaHora (hhmmss)" & vbCrLf
        header = header & "#Dispositivo utilizado: " & str & vbCrLf
        header = header & "#Nombre de serie de datos: " & currentSeriesName & vbCrLf

        File.AppendAllText(DEFAULT_PATH & resultDir & currentFile, header)
    End Sub


    Private Sub insertMarca(punto_ As Integer)

        Dim sl As New StripLine()

        sl.BackColor = Color.Red
        'sl.Interval = punto_ - 2
        sl.IntervalOffset = punto_
        sl.StripWidth = 0.2     'BUSCAR UNA FORMA DE AJUSTAR ESE ANCHO PARA CUANDO EL EJE X ES MUY GRANDE

        graf.ChartAreas(0).AxisX.StripLines.Add(sl)
    End Sub


    Private Sub getData()
        Dim result As Integer
        Dim f As Integer

        status = Mid(tramaIn, 1, 1)

        statusByte = Encoding.ASCII.GetBytes(status)   'obtengo el byte equivalente al string status
        'Debug.Print(Convert.ToString(statusByte(0), 2))
        result = CInt(statusByte(0))

        For f = 0 To 7
            statusBin(7 - f) = result Mod 2
            result = Truncate(result / 2)
        Next

        peso = Mid(tramaIn, 2, 6)

    End Sub







    '///////////////////////////////////////////////////////
    '/////////////// SECCION CALIBRACIÓN///////////////////
    '///////////////////////////////////////////////////////



    Private Sub btCal_Click(sender As Object, e As EventArgs) Handles btCal.Click
        If Size.Width < 1000 Then
            Size = New Size(1150, Size.Height)
        Else
            Size = New Size(965, Size.Height)
        End If
    End Sub

    Private Sub btInitCal_Click(sender As Object, e As EventArgs) Handles btInitCal.Click
        arrayDatos(0) = cmdCalibrar
        SendNumByte(dirRemota, 1)
        objPort.Write(vectorEnviar, 0, 64)
    End Sub

    Private Sub btCalcular_Click(sender As Object, e As EventArgs) Handles btCalcular.Click
        constCalibracion = CDbl(txRead.Text) / CDbl(txRef.Text)
        lbConstCal.Text = constCalibracion
    End Sub

    Private Sub btSet1_Click(sender As Object, e As EventArgs) Handles btSet1.Click
        Dim str As String
        str = constCalibracion.ToString
        arrayDatos(0) = cmdEscala
        arrayDatos(1) = cmdEscala
        SendNumByte(dirRemota, 1)
        objPort.Write(vectorEnviar, 0, 64)
    End Sub


End Class
