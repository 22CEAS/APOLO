Public Sub Validar()
Dim nFilasCV As Integer, nFilasSis As Integer
Dim facturaCV As Variant
Dim  codigoOriginalSis As Variant, facturaSis As Variant 
Dim tipoFactSis As Variant
Dim fecFinFacCV As Date, fecIniFacSis As Date, fecFinFacSis As Date
Dim concatCodActCV As Variant, concatCodAntCV As Variant, concatCodSis As Variant
Dim ubicacionCV As Variant
Dim numDiasTrans As Integer

Dim flag As Integer
        nFilasCV = wsCV.Range("A4", wsCV.Range("A4").End(xlDown)).Cells.Count
        nFilasSis = wsSisgeco.Range("A2", wsSisgeco.Range("A2").End(xlDown)).Cells.Count
        
        For j = 1 To nFilasSis
            flag = 0
            concatCodSis = wsSisgeco.Cells(j + 1, 1).value
            tipoFactSis = wsSisgeco.Cells(j + 1, 3).value
            fecIniFacSis = CDate(wsSisgeco.Cells(j + 1, 6).value)
            fecFinFacSis = CDate(wsSisgeco.Cells(j + 1, 7).value)
            facturaSis = wsSisgeco.Cells(j + 1, 12).value
            
            For i = 1 To nFilasCV
                concatCodActCV = wsCV.Cells(i + 3, 1).value
                concatCodAntCV = wsCV.Cells(i + 3, 2).value
                facturaCV = wsCV.Cells(i + 3, 7).value
                fecFinFacCV = CDate(wsCV.Cells(i + 3, 9).value)
                ubicacionCV = wsCV.Cells(i + 3, 47).value
                
                If (((concatCodSis = concatCodActCV) Or (concatCodSis = concatCodAntCV)) And ubicacionCV = "Cliente") Then
                    If (Not (facturaCV = facturaSis)) Then
                        If ((tipoFactSis = "RENOVACION") Or (tipoFactSis = "ALQUILER")) Then
                            If (fecIniFacSis > fecFinFacCV) Then
                                If (fecIniFacSis >= fecFinFacSis) Then
                                    wsSisgeco.Cells(j + 1, 28) = "Error en las fechas, la fecha final de la factura de Sisgeco es menor o igual a la fecha inicial de la factura de Sisgeco"
                                Else
                                    If (fecFinFacCV = "00:00:00") Then
                                        wsSisgeco.Cells(j + 1, 28) = "Es la primera factura, no hay factura anterior"
                                    Else
                                        numDiasTrans = DateDiff("d", fecFinFacCV, fecIniFacSis)
                                        If (Not (numDiasTrans = 1)) Then
                                            wsSisgeco.Cells(j + 1, 28) = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " & numDiasTrans & " dias."
                                        Else
                                            wsSisgeco.Cells(j + 1, 28) = "Todo Bien"
                                        End If
                                    End If
                                End If
                            Else
                                wsSisgeco.Cells(j + 1, 28) = "Esta factura tiene errores en la fecha. La fecha inicial de Sisgeco es menor o igual que la fecha fin de la factura del CV"
                            End If
                        End If
                    Else
                        wsSisgeco.Cells(j + 1, 28) = "Esta factura ya esta registrada"
                    End If
                    flag = 1
                    Exit For
                End If
            Next i
            If (flag = 0) Then
                wsSisgeco.Cells(j + 1, 28) = "El código de la laptop relacionada a ese proveedor no está en el CV"
            End If
        Next j
        MsgBox "Se terminó las validaciones"
End Sub

Public Sub buscarV()
'Definimos variables
Dim lookupRange As Range
Dim nFilasCV As Integer, nFilasSis As Integer
Dim codigoCV As Variant, codigoOriginalCV As Variant, razonSocialCV As String, facturaCV As Variant, fechaInicioFacCV As Variant, fechaFinFacCV As Variant
Dim fechaInicioPlazoCV As Variant, fechaFinPlazoCV As Variant
Dim codigoSis As Variant, codigoOriginalSis As Variant, razonSocialSis As Variant, facturaSis As Variant, fechaInicioFacSis As Variant, fechaFinFacSis As Variant
Dim tipoFactSis As Variant
Dim fecIniFacCV As Date, fecFinFacCV As Date, fecIniPlaCV As Date, fecFinPlaCV As Date, fecIniFacSis As Date, fecFinFacSis As Date
Dim concatCodActCV As Variant, concatCodAntCV As Variant, concatCodSis As Variant
Dim ubicacionCV As Variant
Dim numDiasTrans As Integer
Dim montoDolares As Variant, montoSoles As Variant



        nFilasCV = wsCV.Range("A4", wsCV.Range("A4").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV
            ubicacionCV = wsCV.Cells(i + 3, 47).value 'celda con el valor que buscamos, en este caso Ubicacion
            If (ubicacionCV = "Cliente") Then
            
                concatCodActCV = wsCV.Cells(i + 3, 1).value 'celda con el valor que buscamos, en este caso Proveedor y Codigo Actual
                concatCodAntCV = wsCV.Cells(i + 3, 2).value 'celda con el valor que buscamos, en este caso Proveedor y Codigo Anterior
                
                razonSocialCV = wsCV.Cells(i + 3, 5).value 'celda con el valor que buscamos, en este caso RazonSocial
                facturaCV = wsCV.Cells(i + 3, 7).value 'celda con el valor que buscamos, en este caso RazonSocial
                
                Set lookupRange = wsSisgeco.Range("A2:BA40000") 'rango donde buscar, en la hoja de Sisgeco, el rango de los codigos
                
                codigoSis = Application.VLookup(concatCodActCV, lookupRange, 1, False) 'se obtiene el valor del codigo de la LP
                razonSocialSis = Application.VLookup(concatCodActCV, lookupRange, 8, False) 'se obtiene la razon social
                fechaInicioFacSis = Application.VLookup(concatCodActCV, lookupRange, 6, False) 'se obtiene la fechaInicioFacSis
                fechaFinFacSis = Application.VLookup(concatCodActCV, lookupRange, 7, False) 'se obtiene la fechaFinFacSis
                facturaSis = Application.VLookup(concatCodActCV, lookupRange, 12, False) 'se obtiene la facturaSis
                tipoFactSis = Application.VLookup(concatCodActCV, lookupRange, 3, False) 'se obtiene el tipo de Facturacion
                montoDolares = Application.VLookup(concatCodActCV, lookupRange, 14, False) 'se obtiene el monto en Dolares
                montoSoles = Application.VLookup(concatCodActCV, lookupRange, 13, False) 'se obtiene el monto en Soles
                
                
                codigoOriginalSis = Application.VLookup(concatCodAntCV, lookupRange, 1, False) 'se obtiene el valor del codigoOriginal antes del cambio de la LP
                
                fecIniFacCV = CDate(wsCV.Cells(i + 3, 8).value)
                fecFinFacCV = CDate(wsCV.Cells(i + 3, 9).value)
                fecIniPlaCV = CDate(wsCV.Cells(i + 3, 3).value)
                fecFinPlaCV = CDate(wsCV.Cells(i + 3, 4).value)
                
                If Not (IsError(codigoSis)) Then
                    fecIniFacSis = CDate(fechaInicioFacSis)
                    fecFinFacSis = CDate(fechaFinFacSis)
                    If (razonSocialCV = razonSocialSis) Then
                        'MsgBox "Si coinciden los códigos de la LP y su RS"
                        wsCV.Cells(i + 3, 53) = "Si coinciden los códigos de la LP y su RS con la laptop Actual, pero no se actualizó"
                        If (Not (facturaCV = facturaSis)) Then
                            If ((tipoFactSis = "RENOVACION") Or (tipoFactSis = "ALQUILER")) Then
                                If (fecIniFacSis > fecFinFacCV) Then
                                    If (fecIniFacSis >= fecFinFacSis) Then
                                        wsCV.Cells(i + 3, 53) = "Error en las fechas, la fecha final de la factura de Sisgeco es menor o igual a la fecha inicial de la factura de Sisgeco"
                                    Else
                                        If (fecFinFacCV = "00:00:00") Then
                                            wsCV.Cells(i + 3, 7) = facturaSis
                                            wsCV.Cells(i + 3, 8) = fecIniFacSis
                                            wsCV.Cells(i + 3, 9) = fecFinFacSis
                                            wsCV.Cells(i + 3, 13) = montoDolares
                                            wsCV.Cells(i + 3, 16) = montoSoles
                                            wsCV.Cells(i + 3, 53) = "Se actualizó, si coinciden los códigos de la LP y su RS con la laptop Actual, es la primera factura, no hay factura anterior"
                                        Else
                                            numDiasTrans = DateDiff("d", fecFinFacCV, fecIniFacSis)
                                            If (numDiasTrans = 1) Then
                                                wsCV.Cells(i + 3, 7) = facturaSis
                                                wsCV.Cells(i + 3, 8) = fecIniFacSis
                                                wsCV.Cells(i + 3, 9) = fecFinFacSis
                                                wsCV.Cells(i + 3, 13) = montoDolares
                                                wsCV.Cells(i + 3, 16) = montoSoles
                                                wsCV.Cells(i + 3, 53) = "Se actualizó, si coinciden los códigos de la LP y su RS con la laptop Actual."
                                            Else
                                                wsCV.Cells(i + 3, 53) = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " & numDiasTrans & " dias."
                                            End If
                                        End If
                                    End If
                                Else
                                    wsCV.Cells(i + 3, 53) = "Esta factura tiene errores en la fecha. La fecha inicial de Sisgeco es menor o igual que la fecha fin de la factura del CV"
                                End If
                            End If
                        Else
                            wsCV.Cells(i + 3, 53) = "Esta factura ya esta registrada"
                        End If
                    Else
                        wsCV.Cells(i + 3, 53) = "Se encontro pero en proveedores distintos"
                    End If
                ElseIf Not (IsError(codigoOriginalSis)) Then
                    razonSocialSis = Application.VLookup(concatCodAntCV, lookupRange, 8, False) 'se obtiene la razon social
                    fechaInicioFacSis = Application.VLookup(concatCodAntCV, lookupRange, 6, False) 'se obtiene la fechaInicioFacSis
                    fechaFinFacSis = Application.VLookup(concatCodAntCV, lookupRange, 7, False) 'se obtiene la fechaFinFacSis
                    facturaSis = Application.VLookup(concatCodAntCV, lookupRange, 12, False) 'se obtiene la facturaSis
                    tipoFactSis = Application.VLookup(concatCodAntCV, lookupRange, 3, False) 'se obtiene el tipo de Facturacion
                    montoDolares = Application.VLookup(concatCodAntCV, lookupRange, 14, False) 'se obtiene el monto en Dolares
                    montoSoles = Application.VLookup(concatCodAntCV, lookupRange, 13, False) 'se obtiene el monto en Soles
                
                    fecIniFacSis = CDate(fechaInicioFacSis)
                    fecFinFacSis = CDate(fechaFinFacSis)
                    If (razonSocialCV = razonSocialSis) Then
                        'MsgBox "Si coinciden los códigos de la LP y su RS"
                        wsCV.Cells(i + 3, 53) = "Si coinciden los códigos de la LP y su RS con el código Original antes del cambio, pero no se actualizó"
                        If (Not (facturaCV = facturaSis)) Then
                            If ((tipoFactSis = "RENOVACION") Or (tipoFactSis = "ALQUILER")) Then
                                If (fecIniFacSis > fecFinFacCV) Then
                                    If (fecIniFacSis >= fecFinFacSis) Then
                                        wsCV.Cells(i + 3, 53) = "Error en las fechas, la fecha final de la factura de Sisgeco es menor o igual a la fecha inicial de la factura de Sisgeco"
                                    Else
                                        If (fecFinFacCV = "00:00:00") Then
                                            wsCV.Cells(i + 3, 7) = facturaSis
                                            wsCV.Cells(i + 3, 8) = fecIniFacSis
                                            wsCV.Cells(i + 3, 9) = fecFinFacSis
                                            wsCV.Cells(i + 3, 13) = montoDolares
                                            wsCV.Cells(i + 3, 16) = montoSoles
                                            wsCV.Cells(i + 3, 53) = "Se actualizó, si coinciden los códigos de la LP y su RS con el código Original antes del cambio, es la primera factura, no hay factura anterior"
                                        Else
                                            numDiasTrans = DateDiff("d", fecFinFacCV, fecIniFacSis)
                                            If (numDiasTrans = 1) Then
                                                wsCV.Cells(i + 3, 7) = facturaSis
                                                wsCV.Cells(i + 3, 8) = fecIniFacSis
                                                wsCV.Cells(i + 3, 9) = fecFinFacSis
                                                wsCV.Cells(i + 3, 13) = montoDolares
                                                wsCV.Cells(i + 3, 16) = montoSoles
                                                wsCV.Cells(i + 3, 53) = "Se actualizó, si coinciden los códigos de la LP y su RS con el código Original antes del cambio."
                                            Else
                                                wsCV.Cells(i + 3, 53) = "Esta factura tiene errores en la fecha. Hay un Salto de fechas de " & numDiasTrans & " dias."
                                            End If
                                        End If
                                    End If
                                Else
                                    wsCV.Cells(i + 3, 53) = "Esta factura tiene errores en la fecha. La fecha inicial de Sisgeco es menor o igual que la fecha fin de la factura del CV"
                                End If
                            End If
                        Else
                            wsCV.Cells(i + 3, 53) = "Esta factura ya esta registrada el código Original antes del cambio"
                        End If
                    Else
                        wsCV.Cells(i + 3, 53) = "Se encontro pero en proveedores distintos el código Original antes del cambio"
                    End If
                Else
                    wsCV.Cells(i + 3, 53) = "No se encuentra el producto"
                End If
            End If
        Next i
        MsgBox "Se terminó con éxito la Migracion"

End Sub

Public Sub actualizar()
Dim nFilasCV As Integer
Dim fecFinFacCV As Date, fecFinPlaCV As Date, fecActual As Date
        
        fecActual = Now
        nFilasCV = wsCV.Range("A4", wsCV.Range("A4").End(xlDown)).Cells.Count
		
        For i = 1 To nFilasCV

            fecFinFacCV = CDate(wsCV.Cells(i + 3, 9).value)
            fecFinPlaCV = CDate(wsCV.Cells(i + 3, 4).value)
            
            If ((fecActual <= fecFinPlaCV)) Then
                'puede que haya pendiente de facturar como no haya nada
                If ((fecFinFacCV < fecActual)) Then
                    wsCV.Cells(i + 3, 54) = "Pendiente Facturar"
                Else
                    wsCV.Cells(i + 3, 54) = "Todo ok"
                End If
            Else
            'Fijo va a ver pendiente de recoger pero tmb puede haber por recoger y facturar
                If ((fecFinFacCV < fecActual) And (fecFinFacCV < fecFinPlaCV)) Then
                    wsCV.Cells(i + 3, 54) = "Pendiente Facturar y Recoger"
                Else
                    wsCV.Cells(i + 3, 54) = "Pendiente Recoger"
                End If
            End If
			
        Next i
        MsgBox "Se terminó con éxito la Actualización"

End Sub





Dim mCn As New ADODB.Connection
Dim rs As New ADODB.Recordset
Dim sql As String

Public Sub Abrir_Conexion(Optional ByVal BD As String = "", _
                          Optional ByVal SrvBD As String = "")
    Dim strCnx As String, User As String, Pswd As String
    'Dim BD As String, SrvBD As String
    
    User = "custom"
    Pswd = ""
    If BD = "" Then BD = "BD_LUCET" ' por default la BD que se abre es BD_DERI
    '======================================
    If SrvBD = "" Then SrvBD = "sga"    ' Produccion
    '======================================
    
    strCnx = "DSN=mysql;" & _
            "DRIVER={MySQL ODBC 8.0 ANSI Driver};" & _
            "SERVER=localhost;" & _
            "DATABASE=bd_leasein;" & _
            "USER=root;" & _
            "PASSWORD=;" & _
            "OPTION=3;"
                               
    Set mCn = New ADODB.Connection
    mCn.Open strCnx
    
    'Timeout en segundos para ejecutar la SQL completa antes de reportar un error
    mCn.CommandTimeout = 900

End Sub

Public Sub Insert(ByVal sql As String)

Dim lRs As ADODB.Recordset

    Call Abrir_Conexion(gBDLUCET, gServDes)

    If lRs Is Nothing Then Set lRs = New ADODB.Recordset
    
    lRs.Open sql, mCn
    
End Sub

'Public Sub Insert(ByVal FechaConsolidacion As Date, ByVal FechaProcConsolidacion As Date, _
'                                ByVal NumOP As Long, ByVal TipoPrograma As String, ByVal Estado As String, ByVal NombrePC As String)

'Dim sql As String
'Dim lRs As ADODB.Recordset

'    Call Abrir_Conexion(gBDLUCET, gServDes)


    
'    sql = "INSERT INTO ControlConsolid(FechaConsolidacion, FechaProcConsolidacion, CodNumPedido,NomTipoProgram,Estado,NombrePC)" & vbCrLf
'    sql = sql & "VALUES  (' " & Format(FechaConsolidacion, "YYYY/MM/DD") & "'" & vbCrLf
'    sql = sql & ", '" & Format(FechaProcConsolidacion, "YYYY/MM/DD HH:MM:SS") & "'" & vbCrLf 'SE MODIFICO ESTO LUEGO DE QUE SE CAYO EL SERVIDOR, AL INICIO ERA YYYY/MM/DD
'    sql = sql & "," & NumOP & vbCrLf
'    sql = sql & ", '" & TipoPrograma & "'" & vbCrLf
'    sql = sql & ", '" & Estado & "'" & vbCrLf
'    sql = sql & ", '" & NombrePC & "')" & vbCrLf
    
'    If lRs Is Nothing Then Set lRs = New ADODB.Recordset
'    lRs.Open sql, mCn
    
'End Sub

Public Sub Update(ByVal FechaConsolidacion As Date)
Dim sql As String
Dim lRs As ADODB.Recordset
    Call Abrir_Conexion(gBDLUCET, gServDes)

        
    sql = "UPDATE pedido" & vbCrLf
    sql = sql & "SET  cod_estado = '0001' " & vbCrLf
    sql = sql & "Where operacion IN (Select CodNumPedido from ControlConsolid where FechaConsolidacion='" & Format(FechaConsolidacion, "YYYY-MM-DD") & "');" & vbCrLf
        
    If lRs Is Nothing Then Set lRs = New ADODB.Recordset
    lRs.Open sql, mCn
    
End Sub









Public Sub auxiliar()
Dim nFilasCV As Integer
Dim idAuxiliar, estado As Integer
Dim cod_tabla, descripcion As String
Dim sql As String

        nFilasCV = wsAuxiliar.Range("A2", wsAuxiliar.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idAuxiliar = CInt(wsAuxiliar.Cells(i + 1, 1).Value)
            cod_tabla = CStr(wsAuxiliar.Cells(i + 1, 2).Value)
            descripcion = CStr(wsAuxiliar.Cells(i + 1, 3).Value)
            estado = CInt(wsAuxiliar.Cells(i + 1, 4).Value)
            
            sql = "INSERT INTO auxiliar (idAuxiliar,cod_tabla,descripcion,activo) VALUES "
            sql = sql & "(" & idAuxiliar & ",'" & cod_tabla & "','" & descripcion & "'," & estado & ")"
        
            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub

Public Sub cliente()
Dim nFilasCV As Integer
Dim idCliente, idTipoDocumento, idKAM, estado As Integer
Dim nroDocumento, nombre_razonSocial, telefono, email, nombreKam As String
Dim sql As String

        nFilasCV = wsCliente.Range("A2", wsCliente.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idCliente = CInt(wsCliente.Cells(i + 1, 1).Value)
            idTipoDocumento = CInt(wsCliente.Cells(i + 1, 2).Value)
            nroDocumento = CStr(wsCliente.Cells(i + 1, 3).Value)
            nombre_razonSocial = CStr(wsCliente.Cells(i + 1, 4).Value)
            telefono = CStr(wsCliente.Cells(i + 1, 5).Value)
            email = CStr(wsCliente.Cells(i + 1, 6).Value)
            idKAM = CInt(wsCliente.Cells(i + 1, 7).Value)
            nombreKam = CStr(wsCliente.Cells(i + 1, 8).Value)
            estado = CInt(wsCliente.Cells(i + 1, 9).Value)
            
            sql = "INSERT INTO cliente (idCliente,tipoDocumento,nroDocumento,nombre_razonSocial,telefono,email,idKAM,nombreKam,estado) values "
            sql = sql & "(" & idCliente & "," & idTipoDocumento & ",'" & nroDocumento & "','" & nombre_razonSocial & "','" & telefono & "','" & email & "'," & idKAM & ",'" & nombreKam & "'," & estado & ")"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub sucursal()
Dim nFilasCV As Integer
Dim idSucursal, idCliente, estado As Integer
Dim nroDocumento, nombreContacto, direccion, telefono, email As String
Dim sql As String

        nFilasCV = wsSucursal.Range("A2", wsSucursal.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idSucursal = CInt(wsSucursal.Cells(i + 1, 1).Value)
            idCliente = CInt(wsSucursal.Cells(i + 1, 2).Value)
            nroDocumento = CStr(wsSucursal.Cells(i + 1, 3).Value)
            nombreContacto = CStr(wsSucursal.Cells(i + 1, 4).Value)
            direccion = CStr(wsSucursal.Cells(i + 1, 5).Value)
            telefono = CStr(wsSucursal.Cells(i + 1, 6).Value)
            email = CStr(wsSucursal.Cells(i + 1, 7).Value)
            estado = CInt(wsSucursal.Cells(i + 1, 8).Value)
            
            sql = "INSERT INTO cliente_sucursal (idSucursal,idCliente,nroDocumento,nombreContacto,direccion,telefono,email,estado) VALUES  "
            sql = sql & "(" & idSucursal & "," & idCliente & ",'" & nroDocumento & "','" & nombreContacto & "','" & direccion & "','" & telefono & "','" & email & "'," & estado & ")"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub proveedor()
Dim nFilasCV As Integer
Dim idProveedor, estado As Integer
Dim ruc, razonSocial, nombreComercial, abreviacion, direccion, telefono, email, nombreContacto, telefonoContacto, emailContacto As String
Dim sql As String

        nFilasCV = wsProveedor.Range("A2", wsProveedor.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idProveedor = CInt(wsProveedor.Cells(i + 1, 1).Value)
            ruc = CStr(wsProveedor.Cells(i + 1, 2).Value)
            razonSocial = CStr(wsProveedor.Cells(i + 1, 3).Value)
            nombreComercial = CStr(wsProveedor.Cells(i + 1, 4).Value)
            abreviacion = CStr(wsProveedor.Cells(i + 1, 5).Value)
            direccion = CStr(wsProveedor.Cells(i + 1, 6).Value)
            telefono = CStr(wsProveedor.Cells(i + 1, 7).Value)
            email = CStr(wsProveedor.Cells(i + 1, 8).Value)
            nombreContacto = CStr(wsProveedor.Cells(i + 1, 9).Value)
            telefonoContacto = CStr(wsProveedor.Cells(i + 1, 10).Value)
            emailContacto = CStr(wsProveedor.Cells(i + 1, 11).Value)
            estado = CInt(wsProveedor.Cells(i + 1, 12).Value)
            
            sql = "INSERT INTO proveedor (idProveedor,ruc,razonSocial,nombreComercial,abreviacion,direccion,telefono,email,nombreContacto,telefonoContacto,emailContacto,estado) VALUES "
            
            sql = sql & "(" & idProveedor & ",'" & ruc & "','" & razonSocial & "','" & nombreComercial & "','" & abreviacion & "','" & direccion & "','" & telefono & "','" & email & "','" & nombreContacto & "','" & telefonoContacto & "','" & emailContacto & "'," & estado & ")"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub usuario()
Dim nFilasCV As Integer
Dim idUsuario, perfil, estado As Integer
Dim dni, nombre, usuario, PASSWORD, email As String
Dim sql As String

        nFilasCV = wsUsuario.Range("A2", wsUsuario.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idUsuario = CInt(wsUsuario.Cells(i + 1, 1).Value)
            dni = CStr(wsUsuario.Cells(i + 1, 2).Value)
            nombre = CStr(wsUsuario.Cells(i + 1, 3).Value)
            usuario = CStr(wsUsuario.Cells(i + 1, 4).Value)
            PASSWORD = CStr(wsUsuario.Cells(i + 1, 5).Value)
            perfil = CInt(wsUsuario.Cells(i + 1, 6).Value)
            email = CStr(wsUsuario.Cells(i + 1, 7).Value)
            
            sql = "INSERT INTO usuario (idUsuario,dni,nombre,usuario,PASSWORD,perfil,email,estado)  VALUES "
            sql = sql & "(" & idUsuario & ",'" & dni & "','" & nombre & "','" & usuario & "','" & PASSWORD & "'," & perfil & ",'" & email & "',1)"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub marca()
Dim nFilasCV As Integer
Dim idMarca, idCategoria, estado As Integer
Dim nombre As String
Dim sql As String

        nFilasCV = wsMarca.Range("A2", wsMarca.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idMarca = CInt(wsMarca.Cells(i + 1, 1).Value)
            nombre = CStr(wsMarca.Cells(i + 1, 2).Value)
            idCategoria = CInt(wsMarca.Cells(i + 1, 3).Value)
            estado = CInt(wsMarca.Cells(i + 1, 4).Value)
            
            sql = "INSERT INTO marca (idMarca,nombre,idCategoria,estado) VALUES "
            sql = sql & "(" & idMarca & ",'" & nombre & "'," & idCategoria & "," & estado & ")"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub modelo()
Dim nFilasCV As Integer
Dim idModelo, idMarca, estado As Integer
Dim nombre As String
Dim sql As String

        nFilasCV = wsModelo.Range("A2", wsModelo.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idModelo = CInt(wsModelo.Cells(i + 1, 1).Value)
            nombre = CStr(wsModelo.Cells(i + 1, 2).Value)
            idMarca = CInt(wsModelo.Cells(i + 1, 3).Value)
            estado = CInt(wsModelo.Cells(i + 1, 4).Value)
            
            sql = "INSERT INTO modelo (idModelo,nombre,idMarca,estado) VALUES"
            sql = sql & "(" & idModelo & ",'" & nombre & "'," & idMarca & "," & estado & ")"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub procesador()
Dim nFilasCV As Integer
Dim idProcesador, idModelo, idGeneracion, generacion, idVelocidad, idVelocidadMax, estado As Integer
Dim codigo, velocidad As String
Dim velocidadMax Double
Dim sql As String

        nFilasCV = wsProcesador.Range("A2", wsProcesador.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idProcesador = CInt(wsProcesador.Cells(i + 1, 1).Value)
            codigo = CStr(wsProcesador.Cells(i + 1, 2).Value)
            idModelo = CInt(wsProcesador.Cells(i + 1, 3).Value)
            idGeneracion = CInt(wsProcesador.Cells(i + 1, 4).Value)
            generacion = CInt(wsProcesador.Cells(i + 1, 5).Value)
            idVelocidad = CInt(wsProcesador.Cells(i + 1, 6).Value)
            velocidad = CStr(wsProcesador.Cells(i + 1, 7).Value)
            idVelocidadMax = CInt(wsProcesador.Cells(i + 1, 8).Value)
            velocidadMax = CDbl(wsProcesador.Cells(i + 1, 9).Value)
            
            sql = "INSERT INTO procesador (idProcesador,codigo,idModelo,idGeneracion,generacion,idVelocidad,velocidad,idVelocidadMax,velocidadMax,estado) VALUES "
            sql = sql & "(" & idProcesador & ",'" & codigo & "'," & idModelo & "," & idGeneracion & "," & generacion & "," & idVelocidad & ",'" & velocidad & "'," & idVelocidadMax & "," & velocidadMax & ",1)"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub video()
Dim nFilasCV As Integer
Dim idVideo, idModelo, idCapacidad, capacidad, idTipo As Integer
Dim codigo, tipo As String
Dim sql As String

        nFilasCV = wsVideo.Range("A2", wsVideo.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idVideo = CInt(wsVideo.Cells(i + 1, 1).Value)
            codigo = CStr(wsVideo.Cells(i + 1, 2).Value)
            idModelo = CInt(wsVideo.Cells(i + 1, 3).Value)
            idCapacidad = CInt(wsVideo.Cells(i + 1, 4).Value)
            capacidad = CInt(wsVideo.Cells(i + 1, 5).Value)
            idTipo = CInt(wsVideo.Cells(i + 1, 6).Value)
            tipo = CStr(wsVideo.Cells(i + 1, 7).Value)
            
            sql = "INSERT INTO video (idVideo,codigo,idModelo,idCapacidad,capacidad,idTipo,tipo,cantidad,ubicacion,estado) VALUES "
            sql = sql & "(" & idVideo & ",'" & codigo & "'," & idModelo & "," & idCapacidad & ",'" & capacidad & "'," & idTipo & ",'" & tipo & "',1,'ALMACEN',1)"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub disco()
Dim nFilasCV As Integer
Dim idDisco, idModelo, idTamano, idCapacidad, capacidad, cantidad As Integer
Dim codigo As String
Dim tamano As Double
Dim sql As String

        nFilasCV = wsDisco.Range("A2", wsDisco.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idDisco = CInt(wsDisco.Cells(i + 1, 1).Value)
            codigo = CStr(wsDisco.Cells(i + 1, 2).Value)
            idModelo = CInt(wsDisco.Cells(i + 1, 3).Value)
            idTamano = CInt(wsDisco.Cells(i + 1, 4).Value)
            tamano = CDbl(wsDisco.Cells(i + 1, 5).Value)
            idCapacidad = CInt(wsDisco.Cells(i + 1, 6).Value)
            capacidad = CInt(wsDisco.Cells(i + 1, 7).Value)
            cantidad = CInt(wsDisco.Cells(i + 1, 8).Value)
            
            sql = "INSERT INTO disco_duro (idDisco,codigo,idModelo,idTamano,tamano,idCapacidad,capacidad,cantidad,ubicacion,estado) VALUES "
            sql = sql & "(" & idDisco & ",'" & codigo & "'," & idModelo & "," & idTamano & "," & tamano & "," & idCapacidad & "," & capacidad & "," & cantidad & ",'ALMACEN',1)"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub memoria()
Dim nFilasCV As Integer
Dim idMemoria, idModelo, idBusFrecuencia, busFrecuencia, idCapacidad, capacidad, idTipo, cantidad As Integer
Dim codigo, tipo As String
Dim sql As String

        nFilasCV = wsMemoria.Range("A2", wsMemoria.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idMemoria = CInt(wsMemoria.Cells(i + 1, 1).Value)
            codigo = CStr(wsMemoria.Cells(i + 1, 2).Value)
            idModelo = CInt(wsMemoria.Cells(i + 1, 3).Value)
            idBusFrecuencia = CInt(wsMemoria.Cells(i + 1, 4).Value)
            busFrecuencia = CInt(wsMemoria.Cells(i + 1, 5).Value)
            idCapacidad = CInt(wsMemoria.Cells(i + 1, 6).Value)
            capacidad = CInt(wsMemoria.Cells(i + 1, 7).Value)
            idTipo = CInt(wsMemoria.Cells(i + 1, 8).Value)
            tipo = CStr(wsMemoria.Cells(i + 1, 9).Value)
            cantidad = CInt(wsMemoria.Cells(i + 1, 10).Value)
            
            sql = "INSERT INTO memoria (idMemoria,codigo,idModelo,idBusFrecuencia,busFrecuencia,idCapacidad,capacidad,idTipo,tipo,cantidad,ubicacion,estado) VALUES "
            sql = sql & "(" & idMemoria & ",'" & codigo & "'," & idModelo & "," & idBusFrecuencia & "," & busFrecuencia & "," & idCapacidad & "," & capacidad & "," & idTipo & ",'" & tipo & "'," & cantidad & ",'ALMACEN',1)"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub laptop()
Dim nFilasCV As Integer
Dim idLC, idModelo, idProcesador, garantia, estado, compraSubarriendo As Integer
Dim tamanoPantalla As Double
Dim codigo, partNumber, serieFabrica, ubicacion, observacion, idVideo As String
Dim fecInicioSeguro, fecFinSeguro As String
Dim sql As String

        nFilasCV = wsLaptops.Range("A2", wsLaptops.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idLC = CInt(wsLaptops.Cells(i + 1, 1).Value)
            codigo = CStr(wsLaptops.Cells(i + 1, 2).Value)
            idModelo = CInt(wsLaptops.Cells(i + 1, 3).Value)
            tamanoPantalla = CDbl(wsLaptops.Cells(i + 1, 4).Value)
            idProcesador = CInt(wsLaptops.Cells(i + 1, 5).Value)
            idVideo = CStr(wsLaptops.Cells(i + 1, 6).Value)
            If (Len(idVideo) = 0) Then
                idVideo = "null"
            End If
            partNumber = CStr(wsLaptops.Cells(i + 1, 7).Value)
            serieFabrica = CStr(wsLaptops.Cells(i + 1, 8).Value)
            garantia = CInt(wsLaptops.Cells(i + 1, 9).Value)
            fecInicioSeguro = wsLaptops.Cells(i + 1, 10).Value
            fecFinSeguro = wsLaptops.Cells(i + 1, 11).Value
            ubicacion = CStr(wsLaptops.Cells(i + 1, 12).Value)
            observacion = CStr(wsLaptops.Cells(i + 1, 13).Value)
            estado = CInt(wsLaptops.Cells(i + 1, 14).Value)
            compraSubarriendo = CInt(wsLaptops.Cells(i + 1, 15).Value)
            
            
            sql = "INSERT INTO laptop_cpu (idLC,codigo,idModelo,tamanoPantalla,idProcesador,idVideo,partNumber,serieFabrica,garantia,fecInicioSeguro,fecFinSeguro,ubicacion,observacion,estado,compraSubarriendo) VALUES  "
            If (Len(fecInicioSeguro) = 0) Or (Len(fecFinSeguro) = 0) Then
                sql = sql & "(" & idLC & ",'" & codigo & "'," & idModelo & "," & tamanoPantalla & "," & idProcesador & "," & idVideo & ",'" & partNumber & "','" & serieFabrica & "'," & garantia & ", null, null,'" & ubicacion & "','" & observacion & "'," & estado & "," & compraSubarriendo & ")"
            Else
                fecInicioSeguro = Format(fecInicioSeguro, "YYYY/MM/DD")
                fecFinSeguro = Format(fecFinSeguro, "YYYY/MM/DD")
                sql = sql & "(" & idLC & ",'" & codigo & "'," & idModelo & "," & tamanoPantalla & "," & idProcesador & "," & idVideo & ",'" & partNumber & "','" & serieFabrica & "'," & garantia & ",'" & fecInicioSeguro & "','" & fecFinSeguro & "','" & ubicacion & "','" & observacion & "'," & estado & "," & compraSubarriendo & ")"
            End If
            
            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub memoriaLC()
Dim nFilasCV As Integer
Dim idMemoria, idLC, cantidad As Integer
Dim sql As String

        nFilasCV = wsMemoriaLC.Range("A2", wsMemoriaLC.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idMemoria = CInt(wsMemoriaLC.Cells(i + 1, 1).Value)
            idLC = CInt(wsMemoriaLC.Cells(i + 1, 2).Value)
            cantidad = CInt(wsMemoriaLC.Cells(i + 1, 3).Value)
            
            sql = "INSERT INTO memoria_lc (idMemoria,idLC,cantidad) VALUES "
            sql = sql & "(" & idMemoria & "," & idLC & "," & cantidad & ")"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub discoLC()
Dim nFilasCV As Integer
Dim idDisco, idLC, cantidad As Integer
Dim sql As String

        nFilasCV = wsDiscoLC.Range("A2", wsDiscoLC.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idDisco = CInt(wsDiscoLC.Cells(i + 1, 1).Value)
            idLC = CInt(wsDiscoLC.Cells(i + 1, 2).Value)
            cantidad = CInt(wsDiscoLC.Cells(i + 1, 3).Value)
            
            sql = "INSERT INTO disco_lc (idDisco,idLC,cantidad) VALUES "
            sql = sql & "(" & idDisco & "," & idLC & "," & cantidad & ")"

            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub


Public Sub licencia()
Dim nFilasCV As Integer
Dim idLicencia, idModelo, estado As Integer
Dim codigo, clave, observacion, idLC As String
Dim fechaActivacion As String
Dim sql As String

        nFilasCV = wsLicencia.Range("A2", wsLicencia.Range("A2").End(xlDown)).Cells.Count
        
        For i = 1 To nFilasCV

            idLicencia = CInt(wsLicencia.Cells(i + 1, 1).Value)
            codigo = CStr(wsLicencia.Cells(i + 1, 2).Value)
            idModelo = CInt(wsLicencia.Cells(i + 1, 3).Value)
            idLC = wsLicencia.Cells(i + 1, 4).Value
            If (Len(idLC) = 0) Then
                idLC = "null"
            End If
            clave = CStr(wsLicencia.Cells(i + 1, 5).Value)
            fechaActivacion = wsLicencia.Cells(i + 1, 6).Value
            observacion = CStr(wsLicencia.Cells(i + 1, 7).Value)
            estado = CInt(wsLicencia.Cells(i + 1, 8).Value)
            
            sql = "INSERT INTO licencia (idLicencia,codigo,idModelo,idLC,clave,fechaActivacion,ubicacion,observacion,estado) VALUES "
            If (Len(fechaActivacion) = 0) Then
                sql = sql & "(" & idLicencia & ",'" & codigo & "'," & idModelo & "," & idLC & ",'" & clave & "',null,'ALMACEN','" & observacion & "'," & estado & ")"
            Else
                fechaActivacion = Format(fechaActivacion, "YYYY/MM/DD")
                sql = sql & "(" & idLicencia & ",'" & codigo & "'," & idModelo & "," & idLC & ",'" & clave & "','" & fechaActivacion & "','ALMACEN','" & observacion & "'," & estado & ")"
            End If
            
            Insert (sql)

        Next i
        MsgBox "Se terminó con éxito la inserción"
End Sub













INSERT INTO auxiliar (idAuxiliar,cod_tabla,descripcion,activo) 
VALUES  (1,'INGRESO_TIPO_2','COMPRA',1)

INSERT INTO cliente 
(idCliente,tipoDocumento,nroDocumento,nombre_razonSocial,telefono,email,idKAM,nombreKam,estado) 
values (5, 2, '20601329256', 'LUCET SAC', '', 'correo@lucet.com.pe', 2, 'ANDRES', 1)

INSERT INTO cliente_sucursal 
(idSucursal,idCliente,nroDocumento,nombreContacto,direccion,telefono,email,estado) 
VALUES (1, 1, '71337110', 'CARLOS ENRIQUE', 'Avenida Universitaria 1801', '1234546312', 'enrique@correo.pucp.edu.pe', 1, '2020-07-13 14:49:24', '2020-07-16 13:14:24', 'CEAS', 'CEAS')

INSERT INTO proveedor 
(idProveedor,ruc,razonSocial,nombreComercial,abreviacion,direccion,telefono,email,nombreContacto,telefonoContacto,emailContacto,estado)
VALUES  (1, '20601329255', 'PROVEEDOR 1', 'PROVEEDOR 1', 'PROV1', '123456', '123456', 'corre@gmail.com', 'Carlos', '123456', 'corre@gmail.com', 1)

INSERT INTO usuario 
(idUsuario,dni,nombre,usuario,PASSWORD,perfil,email,estado)  
VALUES (1,'71337110','CARLOS ARANGO','CEAS','123456789',1,'',1)


INSERT INTO marca (idMarca,nombre,idCategoria,estado) 
VALUES (1, 'APPLE', 1, 1)

INSERT INTO marca (idMarca,nombre,idCategoria,estado) 
VALUES  (1,'APPLE',1,1)

INSERT INTO modelo (idModelo,nombre,idMarca,estado) 
VALUES (1, 'MACK BOOK PRO', 1, 1)

INSERT INTO procesador (idProcesador,codigo,idModelo,idGeneracion,generacion,idVelocidad,velocidad,idVelocidadMax,velocidadMax,observacion,estado,fec_ins,fec_mod,usuario_ins,usuario_mod) VALUES (1, 'PRO-1', 15, 4, 10, 1, '1.00 - 1.60', 1, 3.5, NULL, 1, '2020-07-05 00:50:19', '2020-07-05 00:50:19', 'CEAS', 'CEAS')

INSERT INTO video (idVideo,codigo,idModelo,idCapacidad,capacidad,idTipo,tipo,cantidad,ubicacion,observacion,estado,fec_ins,fec_mod,usuario_ins,usuario_mod) VALUES (1, 'VID-1', 22, 3, 4, 2, 'EXTERNA', 5, 'ALMACEN', NULL, 1, '2020-07-05 01:46:37', '2020-07-05 01:46:37', NULL, NULL)

INSERT INTO disco_duro (idDisco,codigo,idModelo,idTamano,tamano,idCapacidad,capacidad,cantidad,ubicacion,observacion,estado,fec_ins,fec_mod,usuario_ins,usuario_mod) VALUES (1, 'DIS-1', 19, 1, 2.5, 3, 250, 3, 'ALMACEN', NULL, 1, '2020-07-05 00:40:59', '2020-07-05 00:40:59', NULL, NULL)

INSERT INTO memoria (idMemoria,codigo,idModelo,idBusFrecuencia,busFrecuencia,idCapacidad,capacidad,idTipo,tipo,cantidad,ubicacion,observacion,estado,fec_ins,fec_mod,usuario_ins,usuario_mod) VALUES (1, 'MEM-1', 10, 2, 1333, 3, 8, 1, 'DIMM', 10, 'ALMACEN', NULL, 1, '2020-07-05 01:30:29', '2020-07-05 01:30:29', NULL, NULL)

INSERT INTO laptop_cpu (idLC,codigo,idModelo,descripcion,tamanoPantalla,idProcesador,idVideo,partNumber,serieFabrica,garantia,fecInicioSeguro,fecFinSeguro,ubicacion,observacion,estado,fec_ins,fec_mod,usuario_ins,usuario_mod) VALUES (1, 'PCR-LAP1', 1, '', 14, 1, 1, '123456', 'YB06087415', '1', NULL, NULL, 'ALMACEN', NULL, 2, '2020-07-05 09:05:52', '2020-07-05 09:05:52', NULL, NULL)

INSERT INTO memoria_lc (idMemoria,idLC,cantidad,fec_ins,fec_mod,usuario_ins,usuario_mod) VALUES (1, 1, 2, '2020-07-05 09:59:24', '2020-07-05 09:59:24', NULL, NULL)

INSERT INTO disco_lc (idDisco,idLC,cantidad,fec_ins,fec_mod,usuario_ins,usuario_mod) VALUES (1, 1, 2, '2020-07-05 09:51:17', '2020-07-05 09:51:17', NULL, NULL)

INSERT INTO licencia (idLicencia,codigo,idModelo,idLC,clave,fechaActivacion,ubicacion,observacion,estado,fec_ins,fec_mod,usuario_ins,usuario_mod) VALUES (1, 'LIC-1', 26, NULL, '28C9P-PHX4D-42H7T-DHXVV-M776G', '0000-00-00 00:00:00', 'ALMACEN', NULL, 2, '2020-07-05 01:56:53', '2020-07-05 01:56:53', NULL, NULL)


