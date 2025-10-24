Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Principal
Imports System.Text
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Reflection

Module Program
    ' ������ ��� ������� �������
    <DllImport("kernel32.dll")>
    Private Function GetConsoleWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Function ShowWindow(hWnd As IntPtr, nCmdShow As Integer) As Boolean
    End Function

    Private Const SW_HIDE As Integer = 0
    Private Const SW_SHOW As Integer = 5
    Private Const REGISTRY_PATH As String = "HKEY_CURRENT_USER\Software\Emailer"

    ' ��������� ���� ��� �������
    Private isDebugMode As Boolean = False
    Private commandLineSubject As String = Nothing

    Sub Main(args As String())
        ' ������������ ��������� ��������� ������
        ParseCommandLineArgs(args)

        If isDebugMode Then
            ShowConsoleWindow()
            Console.WriteLine("����� ������� �����������")
            If Not String.IsNullOrEmpty(commandLineSubject) Then
                Console.WriteLine($"���� �� ��������� ������: {commandLineSubject}")
            End If
        Else
            HideConsoleWindow()
        End If

        Try
            SendEmail()
        Catch ex As Exception
            LogError($"����������� ������: {ex.Message}")
        End Try

        If isDebugMode Then
            Console.WriteLine("������� ����� ������� ��� ������...")
            Console.ReadKey()
        End If
    End Sub

    Private Sub ParseCommandLineArgs(args As String())
        If args.Length > 0 Then
            For i As Integer = 0 To args.Length - 1
                Select Case args(i).ToLower()
                    Case "/debug", "-debug"
                        isDebugMode = True

                    Case "/subject", "-subject"
                        If i + 1 < args.Length Then
                            commandLineSubject = args(i + 1)
                            i += 1 ' ���������� ��������� ��������, ��� ��� �� ��������
                        Else
                            LogError("�������� /subject ������ ��� ��������")
                        End If

                    Case "/s", "-s" ' �������� ������ ��������� subject
                        If i + 1 < args.Length Then
                            commandLineSubject = args(i + 1)
                            i += 1
                        Else
                            LogError("�������� /s ������ ��� ��������")
                        End If
                End Select
            Next
        End If
    End Sub

    Private Sub HideConsoleWindow()
        Try
            Dim consoleHandle As IntPtr = GetConsoleWindow()
            If consoleHandle <> IntPtr.Zero Then
                ShowWindow(consoleHandle, SW_HIDE)
            End If
        Catch ex As Exception
            LogError($"������ ������� �������: {ex.Message}")
        End Try
    End Sub

    Private Sub ShowConsoleWindow()
        Try
            Dim consoleHandle As IntPtr = GetConsoleWindow()
            If consoleHandle <> IntPtr.Zero Then
                ShowWindow(consoleHandle, SW_SHOW)
            End If
        Catch ex As Exception
            ' ���������� ������ ��� ������ �������
        End Try
    End Sub

    Private Class EmailSettings
        Public Property Secret As String = ""
        Public Property Subject As String = "Subject_demo"
        Public Property Username As String = "DOMAIN\user"
        Public Property SmtpServer As String = "mail.domain.ru"
        Public Property SmtpPort As Integer = 587
        Public Property FromEmail As String = "account@domain.ru"
        Public Property ToEmail As String = "account@domain.ru"
        Public Property EnableSSL As Boolean = True
    End Class

    Private Function ReadSettings() As EmailSettings
        Dim settings As New EmailSettings()

        Try
            ' ������ ��������� �� �������
            settings.Secret = GetRegistryValue("Secret", "")
            settings.Username = GetRegistryValue("Username", "DOMAIN\user")
            settings.SmtpServer = GetRegistryValue("SmtpServer", "mail.domain.ru")
            settings.SmtpPort = Integer.Parse(GetRegistryValue("SmtpPort", "587"))
            settings.FromEmail = GetRegistryValue("FromEmail", "account@domain.ru")
            settings.ToEmail = GetRegistryValue("ToEmail", "account@domain.ru")
            settings.EnableSSL = Boolean.Parse(GetRegistryValue("EnableSSL", "True"))

            ' ���������� ����: ������� �� ��������� ������, ����� �� �����
            settings.Subject = DetermineSubject()

            ' ���� ��������� ���� ������, ������� �������� �� ���������
            If String.IsNullOrEmpty(settings.Secret) Then
                CreateDefaultRegistrySettings()
                settings.Secret = "yoursecret" ' ������������� �������� �� ���������
            End If

        Catch ex As Exception
            LogError($"������ ������ ��������: {ex.Message}")
            ' ������� ��������� �� ��������� ��� ������
            CreateDefaultRegistrySettings()
        End Try

        Return settings
    End Function

    Private Function DetermineSubject() As String
        ' ���������: ��������� ������ -> ���� -> �������� �� ���������
        If Not String.IsNullOrEmpty(commandLineSubject) Then
            If isDebugMode Then
                Console.WriteLine($"������������ ���� �� ��������� ������: {commandLineSubject}")
            End If
            Return commandLineSubject
        End If

        Dim fileSubject As String = ReadSubjectFromFile()
        If isDebugMode Then
            Console.WriteLine($"������������ ���� �� �����: {fileSubject}")
        End If
        Return fileSubject
    End Function

    Private Function ReadSubjectFromFile() As String
        Try
            ' ���������� ���������� ���� � �����
            Dim appDir As String = GetApplicationDirectory()
            Dim subjectFile As String = Path.Combine(appDir, "emailer.ini")
            Dim defaultSubject As String = "Subject_demo"

            If isDebugMode Then
                Console.WriteLine($"���� ���� ��������: {subjectFile}")
                Console.WriteLine($"������� ����������: {Directory.GetCurrentDirectory()}")
            End If

            If Not File.Exists(subjectFile) Then
                ' ������� ���� � ����� �� ���������
                File.WriteAllText(subjectFile, defaultSubject, Encoding.UTF8)
                LogMessage($"������ ���� ��������: {subjectFile}")

                If isDebugMode Then
                    Console.WriteLine($"������ ���� ��������: {subjectFile}")
                End If

                Return defaultSubject
            End If

            Dim subject As String = File.ReadAllText(subjectFile, Encoding.UTF8).Trim()

            If isDebugMode Then
                Console.WriteLine($"��������� ���� �� �����: {subject}")
            End If

            Return If(String.IsNullOrEmpty(subject), defaultSubject, subject)

        Catch ex As Exception
            LogError($"������ ������ ����: {ex.Message}")
            Return "Subject_demo"
        End Try
    End Function

    Private Function GetApplicationDirectory() As String
        Try
            ' �������� ����������, ��� ��������� ����������� ����
            Return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        Catch ex As Exception
            ' ���� �������� ������, ���������� ������� ����������
            Return Directory.GetCurrentDirectory()
        End Try
    End Function

    Private Function GetRegistryValue(keyName As String, defaultValue As String) As String
        Try
            Dim value As Object = Registry.GetValue(REGISTRY_PATH, keyName, defaultValue)
            Return If(value?.ToString(), defaultValue)
        Catch ex As Exception
            LogError($"������ ������ �� ������� ({keyName}): {ex.Message}")
            Return defaultValue
        End Try
    End Function

    Private Sub CreateDefaultRegistrySettings()
        Try
            ' ������� �������� �� ��������� � �������
            SaveRegistryValue("Secret", "yoursecret")
            SaveRegistryValue("Username", "DOMAIN\user")
            SaveRegistryValue("SmtpServer", "mail.domain.ru")
            SaveRegistryValue("SmtpPort", "587")
            SaveRegistryValue("FromEmail", "account@domain.ru")
            SaveRegistryValue("ToEmail", "account@domain.ru")
            SaveRegistryValue("EnableSSL", "True")

            LogMessage("������� ��������� �� ��������� � �������")

            If isDebugMode Then
                Console.WriteLine("������� ��������� �� ��������� � �������")
            End If
        Catch ex As Exception
            LogError($"������ �������� �������� � �������: {ex.Message}")
        End Try
    End Sub

    Private Sub SaveRegistryValue(keyName As String, value As String)
        Try
            Registry.SetValue(REGISTRY_PATH, keyName, value)
        Catch ex As Exception
            Throw New Exception($"������ ���������� {keyName} � ������: {ex.Message}")
        End Try
    End Sub

    Private Sub SendEmail()
        Dim settings As EmailSettings = Nothing

        Try
            settings = ReadSettings()

            ' ��������� ���������
            If String.IsNullOrEmpty(settings.Secret) OrElse settings.Secret = "yoursecret" Then
                LogError("������ �� �������� � �������. ����������� �������� �������� �� 'yoursecret'")
                Return
            End If

            If isDebugMode Then
                Console.WriteLine($"�������� ��������:")
                Console.WriteLine($"  SMTP ������: {settings.SmtpServer}:{settings.SmtpPort}")
                Console.WriteLine($"  ������������: {settings.Username}")
                Console.WriteLine($"  SSL: {settings.EnableSSL}")
                Console.WriteLine($"  ��: {settings.FromEmail}")
                Console.WriteLine($"  ����: {settings.ToEmail}")
                Console.WriteLine($"  ����: {settings.Subject}")
            End If

            ' �������� ��������� ����������
            Dim systemInfo = CollectSystemInfo()

            Using smtpClient As New SmtpClient(settings.SmtpServer, settings.SmtpPort)
                smtpClient.EnableSsl = settings.EnableSSL
                smtpClient.Credentials = New NetworkCredential(settings.Username, settings.Secret)
                smtpClient.Timeout = 30000 ' 30 ������ �������

                Dim mailMessage As New MailMessage()
                mailMessage.From = New MailAddress(settings.FromEmail)
                mailMessage.To.Add(settings.ToEmail)
                mailMessage.Subject = $"{settings.Subject}: {systemInfo.ComputerName}"
                mailMessage.Body = CreateEmailBody(systemInfo, settings)
                mailMessage.SubjectEncoding = Encoding.UTF8
                mailMessage.BodyEncoding = Encoding.UTF8
                mailMessage.IsBodyHtml = False

                If isDebugMode Then
                    Console.WriteLine("������� �������� email...")
                End If

                smtpClient.Send(mailMessage)

                LogMessage($"������ ����������: {settings.Subject}")

                If isDebugMode Then
                    Console.WriteLine("������ ������� ����������!")
                End If
            End Using

        Catch ex As Exception
            Dim errorMsg = $"������ ��������: {ex.Message}"
            LogError(errorMsg)

            If isDebugMode Then
                Console.WriteLine(errorMsg)
                If settings IsNot Nothing Then
                    Console.WriteLine($"��������� ��������� SMTP: {settings.SmtpServer}:{settings.SmtpPort}")
                End If
            End If
        End Try
    End Sub

    Private Class SystemInfo
        Public Property ComputerName As String
        Public Property CurrentUser As String
        Public Property CurrentTime As String
        Public Property OSVersion As String
        Public Property DomainName As String
    End Class

    Private Function CollectSystemInfo() As SystemInfo
        Return New SystemInfo() With {
            .ComputerName = Environment.MachineName,
            .CurrentUser = WindowsIdentity.GetCurrent().Name,
            .CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            .OSVersion = Environment.OSVersion.ToString(),
            .DomainName = Environment.UserDomainName
        }
    End Function

    Private Function CreateEmailBody(systemInfo As SystemInfo, settings As EmailSettings) As String
        Dim sb As New StringBuilder()

        sb.AppendLine("����������� �� Emailer")
        sb.AppendLine()
        sb.AppendLine($"���������: {systemInfo.ComputerName}")
        sb.AppendLine($"������������: {systemInfo.CurrentUser}")
        'sb.AppendLine($"�����: {systemInfo.DomainName}")
        sb.AppendLine($"�����: {systemInfo.CurrentTime}")
        'sb.AppendLine($"��: {systemInfo.OSVersion}")

        If isDebugMode Then
            sb.AppendLine()
            sb.AppendLine("--- ���������� ���������� ---")
            sb.AppendLine($"SMTP ������: {settings.SmtpServer}:{settings.SmtpPort}")
            sb.AppendLine($"SSL �������: {settings.EnableSSL}")
        End If

        Return sb.ToString()
    End Function

    Private Sub LogMessage(message As String)
        Try
            File.AppendAllText("emailer.log", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{vbCrLf}", Encoding.UTF8)
        Catch
            ' ���������� ������ �����������
        End Try
    End Sub

    Private Sub LogError(errorMessage As String)
        Try
            File.AppendAllText("emailer_error.log", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {errorMessage}{vbCrLf}", Encoding.UTF8)
        Catch
            ' ���������� ������ �����������
        End Try
    End Sub
End Module