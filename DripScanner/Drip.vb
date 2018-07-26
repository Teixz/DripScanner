Module Drip
    ' Yes, It´s a base of the same dll of StringCleaner :/
    ' +-------------------+
    ' Coded By : Teix
    ' GitHub : https://github.com/Teixz
    ' Credits for SmoLL_ice
    ' Don´t Remove this!
    ' +-------------------
    Dim Scan As New DotNetScanMemory_SmoLL
    Dim Founds As IntPtr()
    Dim bytestr As String
    Dim str As String
    Dim proces As String
    Dim hexstr As String
    Sub Main()
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("
     _____           _            _____                                              
    |  __ \         (_)          / ____|                                             
    | |  | |  _ __   _   _ __   | (___     ___    __ _   _ __    _ __     ___   _ __ 
    | |  | | | '__| | | | '_ \   \___ \   / __|  / _` | | '_ \  | '_ \   / _ \ | '__|
    | |__| | | |    | | | |_) |  ____) | | (__  | (_| | | | | | | | | | |  __/ | |   
    |_____/  |_|    |_| | .__/  |_____/   \___|  \__,_| |_| |_| |_| |_|  \___| |_|   
                        | |                                                          
                        |_|                                                          
    Coded By Teix <3
")
        Console.WriteLine("Searching for javaw...")
        SearchJavaw()
    End Sub


    Public Sub SearchJavaw()
        Try
            Dim JavawMinecraft() As Process = Process.GetProcessesByName("javaw")
            If JavawMinecraft.Count > 0 and JavawMinecraft.Count < 2 Then
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("Javaw is running!")
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.White
                Console.WriteLine("Searching for Drip...")
                SearchDrip()
            Elseif JavawMinecraft.Count = 2 or JavawMinecraft.Count > 2 Then
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("There are two or more process with same name ( javaw ), kill the 'fakes'.")
                Console.ReadLine()
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Javaw is not running!")
                Console.ReadLine()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    Public Sub SearchDrip()
        Try
            str = "" 'Here do you put the string of client, I removed my string of drip :D
            proces = "javaw"
            Dim i As Long
            Dim abData() As Byte
            abData = System.Text.Encoding.Default.GetBytes(str)
            For i = 0 To UBound(abData)
                hexstr = hexstr & Hex(abData(i)) & " "
            Next
            bytestr = hexstr
            bytestr = bytestr.Substring(0, bytestr.Length - 1)
            Founds = Scan.ScanArray(Scan.GetPID(proces), bytestr)
            If (Founds.Count > 0) Then
                If Founds(0) = 0 Then
                    For ic As Integer = 0 To Founds.Count - 1
                        Console.ResetColor()
                        Console.ForegroundColor = ConsoleColor.Green
                        Console.WriteLine("[!] Drip Client Not Found!")
                        Console.ReadLine()
                    Next
                Else
                    For ic As Integer = 0 To Founds.Count - 1
                        Console.ResetColor()
                        Console.ForegroundColor = ConsoleColor.Red
                        Console.WriteLine("[!] Drip Client Found!")
                        Console.ReadLine()
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Module
