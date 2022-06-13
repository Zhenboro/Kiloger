Public Class Main
    Dim filePath As String = Nothing
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text <> Nothing Then
                filePath = TextBox1.Text
            End If
            If filePath = Nothing Then
                Dim openFile As New OpenFileDialog
                openFile.Filter = "All file types (*.*)|*.*"
                openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                openFile.Title = "Open file..."
                If openFile.ShowDialog() = DialogResult.OK Then
                    filePath = openFile.FileName
                    TextBox1.Text = filePath
                End If
            End If
            Intepretar()
        Catch ex As Exception
            AddToLog("Button1_Click@Main", "Error: " & ex.Message, True)
        End Try
    End Sub

    Dim registro As String
    Dim charInicio, charFinal As Integer
    Dim longitudRegistro As Integer
    Dim longitudAnalisis As Integer
    Sub Intepretar()
        Try
            'registro = My.Computer.FileSystem.ReadAllText(filePath)
            'longitudRegistro = registro.Length
            'longitudAnalisis = 0

            'For Each caracter As Char In registro
            '    Select Case caracter
            '        Case "{"
            '            charInicio = longitudAnalisis
            '        Case "}"
            '            charFinal = longitudAnalisis
            '        Case Else
            '            longitudAnalisis += 1
            '            Console.WriteLine(caracter)
            '    End Select
            'Next

            Dim contenido As String = My.Computer.FileSystem.ReadAllText(filePath)
            contenido = contenido.Trim()
            contenido = contenido.TrimStart()
            contenido = contenido.TrimEnd()

            contenido = contenido.Replace("{OEM1}", "´")
            contenido = contenido.Replace("{OEM5}", "|")
            contenido = contenido.Replace("{OEM6}", "¿")
            contenido = contenido.Replace("{OEM7}", "{")
            contenido = contenido.Replace("{OEMQUESTION}", "}")
            contenido = contenido.Replace("{OEMCOMMA}", ",")
            contenido = contenido.Replace("{OEMPERIOD}", ".")
            contenido = contenido.Replace("{OEMMINUS}", "-")
            contenido = contenido.Replace("{OEMTILDE}", "ñ")
            contenido = contenido.Replace("{OEMPLUS}", "+")
            contenido = contenido.Replace("{OEMOPENBRACKETS}", "'")
            contenido = contenido.Replace("{OEMBACKSLASH}", "<")
            contenido = contenido.Replace("{D1}", "1")
            contenido = contenido.Replace("{D2}", "2")
            contenido = contenido.Replace("{D3}", "3")
            contenido = contenido.Replace("{D4}", "4")
            contenido = contenido.Replace("{D5}", "5")
            contenido = contenido.Replace("{D6}", "6")
            contenido = contenido.Replace("{D7}", "7")
            contenido = contenido.Replace("{D8}", "8")
            contenido = contenido.Replace("{D9}", "9")
            contenido = contenido.Replace("{D0}", "0")
            contenido = contenido.Replace("{RETURN}", vbCrLf)
            contenido = contenido.Replace("{SPACE}", " ")
            contenido = contenido.Replace("{DIVIDE}", "/")
            contenido = contenido.Replace("{MULTIPLY}", "*")
            contenido = contenido.Replace("{SUBSTRACT}", "-")
            contenido = contenido.Replace("{ADD}", "+")
            contenido = contenido.Replace("{DECIMAL}", ".")
            contenido = contenido.Replace("{NUMPAD0}", "0")
            contenido = contenido.Replace("{NUMPAD1}", "1")
            contenido = contenido.Replace("{NUMPAD2}", "2")
            contenido = contenido.Replace("{NUMPAD3}", "3")
            contenido = contenido.Replace("{NUMPAD4}", "4")
            contenido = contenido.Replace("{NUMPAD5}", "5")
            contenido = contenido.Replace("{NUMPAD6}", "6")
            contenido = contenido.Replace("{NUMPAD7}", "7")
            contenido = contenido.Replace("{NUMPAD8}", "8")
            contenido = contenido.Replace("{NUMPAD9}", "9")

            RichTextBox1.Text = contenido

        Catch ex As Exception
            AddToLog("Intepretar@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
End Class