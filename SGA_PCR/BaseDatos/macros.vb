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

