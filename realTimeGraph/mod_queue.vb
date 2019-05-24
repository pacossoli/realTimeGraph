Module mod_queue
    'en este modulo vamos a tratar de definir todas las funciones y estructuras asociadas a todo lo q es comunicacion:
    'Calculo de CRC, armado y desarmado de tramas y comunicacion en si

    Public ultimaCantBytes As Long

    Dim fStuf As Byte

    Public Const STX = 2
    Public Const ETX = 3
    Public Const ESC = 16
    Public Const ACK = 4
    Public Const NACK = 5

    Public arrayDatos(64) As Byte       'este vector es para los datos en si
    Public vectorEnviar(64) As Byte

    'maquina de estado para pushByte()
    Const mst_wait_stx = 0
    Const mst_wait_dir = 1
    Const mst_byte = 2
    Const mst_esc = 3
    Const mst_wait_crc = 4
    Const mst_dato_ok = 5





    Public Structure stRx
        Public size As Long
        Public dir As Long
        Public RXbuff() As Byte
        Public ptrPush As Long
        Public ComState As Byte
    End Structure
    Public datoin As stRx







    Public Sub pushByte(dato As Byte)

        If datoin.ptrPush >= 64 Or (dato = STX And datoin.ComState <> mst_dato_ok And fStuf = 0) Then
            clearBuff()
        End If

        Select Case datoin.ComState
            Case mst_wait_stx
                If dato = STX Then
                    datoin.ComState = mst_wait_dir
                End If

            Case mst_wait_dir
                If dato = datoin.dir Then
                    datoin.ComState = mst_byte
                End If

            Case mst_byte
                If dato = ETX Then
                    datoin.ComState = mst_wait_crc
                ElseIf dato = ESC Then
                    datoin.ComState = mst_esc
                    fStuf = 1
                Else
                    datoin.RXbuff(datoin.ptrPush) = dato
                    datoin.ptrPush = datoin.ptrPush + 1
                End If

            Case mst_esc
                fStuf = 0
                datoin.ComState = mst_byte
                If (dato = STX Or dato = ETX Or dato = ESC) Then
                    datoin.RXbuff(datoin.ptrPush) = dato
                    datoin.ptrPush = datoin.ptrPush + 1
                Else
                    clearBuff()
                End If

            Case mst_wait_crc
                Dim i As Integer, CRC As Byte
                CRC = 0
                For i = 0 To datoin.ptrPush - 1
                    CRC = CRC Xor datoin.RXbuff(i)
                Next
                If CRC = dato Then
                    datoin.ComState = mst_dato_ok
                Else
                    clearBuff()
                End If

            Case mst_dato_ok
                'nada
        End Select

    End Sub





    Public Sub clearBuff()
        Dim i As Integer
        ReDim datoin.RXbuff(64)
        For i = 0 To 64
            datoin.RXbuff(i) = 0
        Next
        datoin.ptrPush = 0
        datoin.ComState = mst_wait_stx

    End Sub


    Function hayDatoOk() As Integer
        If datoin.ComState = mst_dato_ok Then
            hayDatoOk = 1
        Else
            hayDatoOk = 0
        End If
    End Function


    Public Sub initBuff(dir_buffer_ As Byte)
        datoin.dir = dir_buffer_
        clearBuff()
        datoin.ComState = mst_wait_stx
    End Sub





    Public Sub SendNumByte(destino As Byte, numBytes As Long)
        ultimaCantBytes = numBytes

        'Dim vector(64) As Byte
        vectorEnviar(0) = STX
        vectorEnviar(1) = destino

        Dim CRC As Byte
        Dim i, x As Integer
        x = 0

        For i = 0 To numBytes - 1
            If arrayDatos(i) = STX Or arrayDatos(i) = ETX Or arrayDatos(i) = ESC Then
                vectorEnviar(i + 2 + x) = ESC
                x = x + 1
            End If
            CRC = CRC Xor arrayDatos(i)
            vectorEnviar(i + 2 + x) = arrayDatos(i)
        Next

        vectorEnviar(i + 2 + x) = ETX
        vectorEnviar(i + 3 + x) = CRC

    End Sub
End Module
