<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.cbPorts = New System.Windows.Forms.ComboBox()
        Me.btConect = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.graf = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cTiempoMuestreo = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbEstado = New System.Windows.Forms.Label()
        Me.cbDispositivo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txNombreSerie = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btIniciar = New System.Windows.Forms.Button()
        Me.btDetener = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbValorInstantaneo = New System.Windows.Forms.Label()
        Me.btTarar = New System.Windows.Forms.Button()
        Me.btMarcaTemporal = New System.Windows.Forms.Button()
        Me.btClearGraf = New System.Windows.Forms.Button()
        Me.btCargarValores = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btPausa = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbTiempo = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.lbBrutoNeto = New System.Windows.Forms.Label()
        Me.lbMovEqui = New System.Windows.Forms.Label()
        Me.lbNormalOutRange = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbCentroCero = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.openFolderLog = New System.Windows.Forms.Button()
        Me.chInvertAxis = New System.Windows.Forms.CheckBox()
        Me.btAbout = New System.Windows.Forms.Button()
        Me.btHelp = New System.Windows.Forms.Button()
        Me.btCal = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txRef = New System.Windows.Forms.TextBox()
        Me.txRead = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btCalcular = New System.Windows.Forms.Button()
        Me.btSet1 = New System.Windows.Forms.Button()
        Me.btInitCal = New System.Windows.Forms.Button()
        Me.lbConstCal = New System.Windows.Forms.Label()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.graf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cTiempoMuestreo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbPorts
        '
        Me.cbPorts.FormattingEnabled = True
        Me.cbPorts.Location = New System.Drawing.Point(74, 53)
        Me.cbPorts.Name = "cbPorts"
        Me.cbPorts.Size = New System.Drawing.Size(119, 21)
        Me.cbPorts.TabIndex = 0
        Me.cbPorts.Text = "Seleccione..."
        '
        'btConect
        '
        Me.btConect.AutoSize = True
        Me.btConect.Location = New System.Drawing.Point(9, 80)
        Me.btConect.Name = "btConect"
        Me.btConect.Size = New System.Drawing.Size(184, 25)
        Me.btConect.TabIndex = 2
        Me.btConect.Text = "Conectar"
        Me.btConect.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(181, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Registrador de Sensores"
        '
        'graf
        '
        ChartArea5.CursorX.IsUserSelectionEnabled = True
        ChartArea5.CursorY.IsUserSelectionEnabled = True
        ChartArea5.Name = "ChartArea1"
        Me.graf.ChartAreas.Add(ChartArea5)
        Legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend5.Name = "Legend1"
        Me.graf.Legends.Add(Legend5)
        Me.graf.Location = New System.Drawing.Point(12, 98)
        Me.graf.Name = "graf"
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "Series1"
        Me.graf.Series.Add(Series5)
        Me.graf.Size = New System.Drawing.Size(724, 327)
        Me.graf.TabIndex = 5
        Me.graf.Text = "Chart1"
        '
        'cTiempoMuestreo
        '
        Me.cTiempoMuestreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cTiempoMuestreo.Location = New System.Drawing.Point(115, 193)
        Me.cTiempoMuestreo.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.cTiempoMuestreo.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.cTiempoMuestreo.Name = "cTiempoMuestreo"
        Me.cTiempoMuestreo.Size = New System.Drawing.Size(78, 20)
        Me.cTiempoMuestreo.TabIndex = 6
        Me.cTiempoMuestreo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbEstado)
        Me.GroupBox1.Controls.Add(Me.cbDispositivo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txNombreSerie)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cTiempoMuestreo)
        Me.GroupBox1.Controls.Add(Me.cbPorts)
        Me.GroupBox1.Controls.Add(Me.btConect)
        Me.GroupBox1.Location = New System.Drawing.Point(742, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(199, 219)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuraciones"
        '
        'lbEstado
        '
        Me.lbEstado.Location = New System.Drawing.Point(9, 108)
        Me.lbEstado.Name = "lbEstado"
        Me.lbEstado.Size = New System.Drawing.Size(184, 13)
        Me.lbEstado.TabIndex = 13
        Me.lbEstado.Text = "lbEstado"
        '
        'cbDispositivo
        '
        Me.cbDispositivo.FormattingEnabled = True
        Me.cbDispositivo.Items.AddRange(New Object() {"Modelo GLPC-2000", "Modelo EL-05B", "Sensor de Temperatura"})
        Me.cbDispositivo.Location = New System.Drawing.Point(74, 26)
        Me.cbDispositivo.Name = "cbDispositivo"
        Me.cbDispositivo.Size = New System.Drawing.Size(119, 21)
        Me.cbDispositivo.TabIndex = 12
        Me.cbDispositivo.Text = "Selecciones..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Dispositivo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Puerto COM"
        '
        'txNombreSerie
        '
        Me.txNombreSerie.Location = New System.Drawing.Point(9, 167)
        Me.txNombreSerie.Name = "txNombreSerie"
        Me.txNombreSerie.Size = New System.Drawing.Size(184, 20)
        Me.txNombreSerie.TabIndex = 9
        Me.txNombreSerie.Text = "fecha Actual"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nombre de Serie"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tiempo de muestreo"
        '
        'btIniciar
        '
        Me.btIniciar.Location = New System.Drawing.Point(742, 323)
        Me.btIniciar.Name = "btIniciar"
        Me.btIniciar.Size = New System.Drawing.Size(85, 30)
        Me.btIniciar.TabIndex = 8
        Me.btIniciar.Text = "Iniciar"
        Me.btIniciar.UseVisualStyleBackColor = True
        '
        'btDetener
        '
        Me.btDetener.Enabled = False
        Me.btDetener.Location = New System.Drawing.Point(856, 359)
        Me.btDetener.Name = "btDetener"
        Me.btDetener.Size = New System.Drawing.Size(85, 30)
        Me.btDetener.TabIndex = 9
        Me.btDetener.Text = "Detener"
        Me.btDetener.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Valor instanténeo:"
        '
        'lbValorInstantaneo
        '
        Me.lbValorInstantaneo.BackColor = System.Drawing.Color.White
        Me.lbValorInstantaneo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbValorInstantaneo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbValorInstantaneo.Location = New System.Drawing.Point(149, 65)
        Me.lbValorInstantaneo.Name = "lbValorInstantaneo"
        Me.lbValorInstantaneo.Size = New System.Drawing.Size(111, 24)
        Me.lbValorInstantaneo.TabIndex = 11
        Me.lbValorInstantaneo.Text = "1450,5"
        '
        'btTarar
        '
        Me.btTarar.Enabled = False
        Me.btTarar.Location = New System.Drawing.Point(742, 359)
        Me.btTarar.Name = "btTarar"
        Me.btTarar.Size = New System.Drawing.Size(85, 30)
        Me.btTarar.TabIndex = 12
        Me.btTarar.Text = "Tarar"
        Me.btTarar.UseVisualStyleBackColor = True
        '
        'btMarcaTemporal
        '
        Me.btMarcaTemporal.AutoSize = True
        Me.btMarcaTemporal.Location = New System.Drawing.Point(12, 441)
        Me.btMarcaTemporal.Name = "btMarcaTemporal"
        Me.btMarcaTemporal.Size = New System.Drawing.Size(90, 26)
        Me.btMarcaTemporal.TabIndex = 13
        Me.btMarcaTemporal.Text = "Marca temporal"
        Me.btMarcaTemporal.UseVisualStyleBackColor = True
        '
        'btClearGraf
        '
        Me.btClearGraf.AutoSize = True
        Me.btClearGraf.Location = New System.Drawing.Point(109, 441)
        Me.btClearGraf.Name = "btClearGraf"
        Me.btClearGraf.Size = New System.Drawing.Size(85, 26)
        Me.btClearGraf.TabIndex = 14
        Me.btClearGraf.Text = "Limpiar grafico"
        Me.btClearGraf.UseVisualStyleBackColor = True
        '
        'btCargarValores
        '
        Me.btCargarValores.Location = New System.Drawing.Point(201, 441)
        Me.btCargarValores.Name = "btCargarValores"
        Me.btCargarValores.Size = New System.Drawing.Size(82, 26)
        Me.btCargarValores.TabIndex = 15
        Me.btCargarValores.Text = "Cargar Valores"
        Me.btCargarValores.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btPausa
        '
        Me.btPausa.BackColor = System.Drawing.SystemColors.Control
        Me.btPausa.Location = New System.Drawing.Point(856, 323)
        Me.btPausa.Name = "btPausa"
        Me.btPausa.Size = New System.Drawing.Size(85, 30)
        Me.btPausa.TabIndex = 17
        Me.btPausa.Text = "Pausar"
        Me.btPausa.UseVisualStyleBackColor = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(266, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 20)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Tiempo:"
        '
        'lbTiempo
        '
        Me.lbTiempo.BackColor = System.Drawing.Color.White
        Me.lbTiempo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTiempo.Location = New System.Drawing.Point(337, 64)
        Me.lbTiempo.Name = "lbTiempo"
        Me.lbTiempo.Size = New System.Drawing.Size(105, 24)
        Me.lbTiempo.TabIndex = 19
        '
        'Timer3
        '
        '
        'lbBrutoNeto
        '
        Me.lbBrutoNeto.AutoSize = True
        Me.lbBrutoNeto.BackColor = System.Drawing.Color.Lime
        Me.lbBrutoNeto.Location = New System.Drawing.Point(656, 448)
        Me.lbBrutoNeto.Name = "lbBrutoNeto"
        Me.lbBrutoNeto.Size = New System.Drawing.Size(60, 13)
        Me.lbBrutoNeto.TabIndex = 20
        Me.lbBrutoNeto.Text = "Bruto/Neto"
        Me.lbBrutoNeto.Visible = False
        '
        'lbMovEqui
        '
        Me.lbMovEqui.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbMovEqui.Location = New System.Drawing.Point(51, 12)
        Me.lbMovEqui.Name = "lbMovEqui"
        Me.lbMovEqui.Size = New System.Drawing.Size(15, 15)
        Me.lbMovEqui.TabIndex = 21
        '
        'lbNormalOutRange
        '
        Me.lbNormalOutRange.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNormalOutRange.Location = New System.Drawing.Point(177, 13)
        Me.lbNormalOutRange.Name = "lbNormalOutRange"
        Me.lbNormalOutRange.Size = New System.Drawing.Size(102, 13)
        Me.lbNormalOutRange.TabIndex = 22
        Me.lbNormalOutRange.Text = "Normal/Fuera rango"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Estable"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(128, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Estado:"
        '
        'lbCentroCero
        '
        Me.lbCentroCero.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCentroCero.Location = New System.Drawing.Point(107, 12)
        Me.lbCentroCero.Name = "lbCentroCero"
        Me.lbCentroCero.Size = New System.Drawing.Size(15, 15)
        Me.lbCentroCero.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(72, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Cero"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lbCentroCero)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lbNormalOutRange)
        Me.GroupBox2.Controls.Add(Me.lbMovEqui)
        Me.GroupBox2.Location = New System.Drawing.Point(448, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 31)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        '
        'openFolderLog
        '
        Me.openFolderLog.Location = New System.Drawing.Point(742, 395)
        Me.openFolderLog.Name = "openFolderLog"
        Me.openFolderLog.Size = New System.Drawing.Size(85, 30)
        Me.openFolderLog.TabIndex = 28
        Me.openFolderLog.Text = "Abrir Logs"
        Me.openFolderLog.UseVisualStyleBackColor = True
        '
        'chInvertAxis
        '
        Me.chInvertAxis.AutoSize = True
        Me.chInvertAxis.Checked = True
        Me.chInvertAxis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chInvertAxis.Location = New System.Drawing.Point(297, 447)
        Me.chInvertAxis.Name = "chInvertAxis"
        Me.chInvertAxis.Size = New System.Drawing.Size(85, 17)
        Me.chInvertAxis.TabIndex = 29
        Me.chInvertAxis.Text = "Invertir eje Y"
        Me.chInvertAxis.UseVisualStyleBackColor = True
        '
        'btAbout
        '
        Me.btAbout.Location = New System.Drawing.Point(856, 12)
        Me.btAbout.Name = "btAbout"
        Me.btAbout.Size = New System.Drawing.Size(85, 30)
        Me.btAbout.TabIndex = 30
        Me.btAbout.Text = "Acerca de..."
        Me.btAbout.UseVisualStyleBackColor = True
        '
        'btHelp
        '
        Me.btHelp.Location = New System.Drawing.Point(856, 48)
        Me.btHelp.Name = "btHelp"
        Me.btHelp.Size = New System.Drawing.Size(85, 30)
        Me.btHelp.TabIndex = 31
        Me.btHelp.Text = "Ayuda"
        Me.btHelp.UseVisualStyleBackColor = True
        '
        'btCal
        '
        Me.btCal.Enabled = False
        Me.btCal.Location = New System.Drawing.Point(856, 395)
        Me.btCal.Name = "btCal"
        Me.btCal.Size = New System.Drawing.Size(85, 30)
        Me.btCal.TabIndex = 32
        Me.btCal.Text = "Cal"
        Me.btCal.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(965, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Punto 1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(966, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Peso Ref"
        '
        'txRef
        '
        Me.txRef.Location = New System.Drawing.Point(1015, 86)
        Me.txRef.Name = "txRef"
        Me.txRef.Size = New System.Drawing.Size(66, 20)
        Me.txRef.TabIndex = 36
        Me.txRef.Text = "1000"
        '
        'txRead
        '
        Me.txRead.Location = New System.Drawing.Point(1015, 124)
        Me.txRead.Name = "txRead"
        Me.txRead.Size = New System.Drawing.Size(66, 20)
        Me.txRead.TabIndex = 38
        Me.txRead.Text = "1000"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(966, 127)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Lectura"
        '
        'btCalcular
        '
        Me.btCalcular.Location = New System.Drawing.Point(1005, 154)
        Me.btCalcular.Name = "btCalcular"
        Me.btCalcular.Size = New System.Drawing.Size(75, 33)
        Me.btCalcular.TabIndex = 44
        Me.btCalcular.Text = "Calcular"
        Me.btCalcular.UseVisualStyleBackColor = True
        '
        'btSet1
        '
        Me.btSet1.Location = New System.Drawing.Point(991, 249)
        Me.btSet1.Name = "btSet1"
        Me.btSet1.Size = New System.Drawing.Size(90, 24)
        Me.btSet1.TabIndex = 45
        Me.btSet1.Text = "setCal"
        Me.btSet1.UseVisualStyleBackColor = True
        '
        'btInitCal
        '
        Me.btInitCal.Location = New System.Drawing.Point(991, 31)
        Me.btInitCal.Name = "btInitCal"
        Me.btInitCal.Size = New System.Drawing.Size(89, 27)
        Me.btInitCal.TabIndex = 47
        Me.btInitCal.Text = "Iniciar Cal"
        Me.btInitCal.UseVisualStyleBackColor = True
        '
        'lbConstCal
        '
        Me.lbConstCal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbConstCal.Location = New System.Drawing.Point(991, 205)
        Me.lbConstCal.Name = "lbConstCal"
        Me.lbConstCal.Size = New System.Drawing.Size(104, 30)
        Me.lbConstCal.TabIndex = 48
        Me.lbConstCal.Text = "constCal"
        '
        'Timer4
        '
        Me.Timer4.Interval = 1000
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 479)
        Me.Controls.Add(Me.lbConstCal)
        Me.Controls.Add(Me.btInitCal)
        Me.Controls.Add(Me.btSet1)
        Me.Controls.Add(Me.btCalcular)
        Me.Controls.Add(Me.txRead)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txRef)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btCal)
        Me.Controls.Add(Me.btHelp)
        Me.Controls.Add(Me.btAbout)
        Me.Controls.Add(Me.chInvertAxis)
        Me.Controls.Add(Me.openFolderLog)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbBrutoNeto)
        Me.Controls.Add(Me.lbTiempo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btPausa)
        Me.Controls.Add(Me.btCargarValores)
        Me.Controls.Add(Me.btClearGraf)
        Me.Controls.Add(Me.btMarcaTemporal)
        Me.Controls.Add(Me.btTarar)
        Me.Controls.Add(Me.lbValorInstantaneo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btDetener)
        Me.Controls.Add(Me.btIniciar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.graf)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DTLog©"
        CType(Me.graf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cTiempoMuestreo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbPorts As ComboBox
    Friend WithEvents btConect As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents graf As DataVisualization.Charting.Chart
    Friend WithEvents cTiempoMuestreo As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btIniciar As Button
    Friend WithEvents btDetener As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lbValorInstantaneo As Label
    Friend WithEvents btTarar As Button
    Friend WithEvents btMarcaTemporal As Button
    Friend WithEvents btClearGraf As Button
    Friend WithEvents btCargarValores As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txNombreSerie As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbDispositivo As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btPausa As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Label7 As Label
    Friend WithEvents lbTiempo As Label
    Friend WithEvents Timer3 As Timer
    Friend WithEvents lbBrutoNeto As Label
    Friend WithEvents lbMovEqui As Label
    Friend WithEvents lbNormalOutRange As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbCentroCero As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents openFolderLog As Button
    Friend WithEvents chInvertAxis As CheckBox
    Friend WithEvents lbEstado As Label
    Friend WithEvents btAbout As Button
    Friend WithEvents btHelp As Button
    Friend WithEvents btCal As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txRef As TextBox
    Friend WithEvents txRead As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btCalcular As Button
    Friend WithEvents btSet1 As Button
    Friend WithEvents btInitCal As Button
    Friend WithEvents lbConstCal As Label
    Friend WithEvents Timer4 As Timer
End Class
