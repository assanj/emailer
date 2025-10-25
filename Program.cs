
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace emailer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Emailer emailer = new Emailer();
            emailer.Run(args);
        }
    }

    public class Emailer
    {
        private bool _debug = false;
        private string _subject = "";
        private string _body = "";
        private string _iniPath = "";
        private string _logPath = "";
        private bool _enableSound = true;
        private string _attachmentPath = "";
        private readonly object _fileLock = new object();
        private bool _debugModeLogged = false;
        private bool _inFileLockNotification = false;
        private List<string> _fileLockWarnings = new List<string>();
        private bool _attachmentFailed = false;

        private string _cmdServer = "";
        private string _cmdPort = "";
        private string _cmdUsername = "";
        private string _cmdPassword = "";
        private string _cmdFrom = "";
        private string _cmdTo = "";
        private string _cmdSsl = "";
        private string _cmdCc = "";
        private string _cmdBcc = "";
        private string _cmdImportance = "normal";

        public void Run(string[] args)
        {
            try
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                _iniPath = Path.Combine(appDir, "emailer.ini");
                _logPath = Path.Combine(appDir, "emailer.log");

                if (args.Contains("--help") || args.Contains("-h") ||
                    args.Contains("/?") || args.Contains("-?") ||
                    args.Contains("--?") || args.Contains("?"))
                {
                    ShowHelp();
                    return;
                }

                if (args.Contains("--encrypt-password"))
                {
                    EncryptPasswordCommand(args);
                    return;
                }

                if (args.Contains("--reset-config"))
                {
                    ResetConfigurationCommand();
                    return;
                }

                ParseArguments(args);

                if (_debug && !_debugModeLogged)
                {
                    ShowConsole();
                    string debugMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [DEBUG MODE] {Environment.MachineName} | {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} | {AppDomain.CurrentDomain.BaseDirectory}";

                    WriteToLogFile(debugMessage);
                    Console.WriteLine(debugMessage);

                    _debugModeLogged = true;
                }

                SendEmail();
            }
            catch (Exception ex)
            {
                HandleException("CRITICAL ERROR in Main", ex);
                Environment.Exit(1);
            }
        }

        private void ShowHelp()
        {
            string helpText = @"
SMTP Email Sending Utility (OPEN SOURCE & CROSS-PLATFORM)
Full code available for inspection: https://github.com/assanj/emailer.git
USAGE:
  emailer [OPTIONS]
SMTP PARAMETERS (override INI file):
  --server HOST     SMTP server address
  --port NUMBER     SMTP server port
  --username USER   SMTP username  
  --password PASS   SMTP password
  --from EMAIL      From email address
  --to EMAIL        To email address (comma-separated for multiple)
  --ssl true|false  Enable SSL
OPTIONS:
  --debug           Enable debug mode with console output
  --subject TEXT    Email subject text
  --body TEXT       Email body text
  --attach FILE     Attach file to email
  --no-sound        Disable sound alerts
  --cc EMAILS       Carbon copy (comma-separated emails)
  --bcc EMAILS      Blind carbon copy (comma-separated emails)
  --importance LEVEL Set importance (high/normal/low)
UTILITIES:
  --help, -h, /?   Show this help
  --encrypt-password PASS  Encrypt password for INI file
  --reset-config    Reset configuration files  
TEMPLATE VARIABLES:
  {host} {user} {timestamp} {time} {date}
EXAMPLES:
  emailer --debug --subject ""Alert from {host}"" --body ""User {user} at {timestamp}""
  emailer --server smtp.domain.ru --port 587 --username user --password pass --from sender@domain.ru --to recipient@domain.ru --ssl true
  emailer --attach emailer.log --subject ""Log file from {host}"" --body ""Generated at {timestamp}""
  emailer --to ""user1@domain.com,user2@domain.com"" --cc ""manager@domain.com"" --bcc ""archive@domain.com"" --importance high
  emailer --no-sound --debug
";
            Console.WriteLine(helpText);
        }

        private void EncryptPasswordCommand(string[] args)
        {
            try
            {
                ShowConsole();

                int passwordIndex = Array.IndexOf(args, "--encrypt-password") + 1;
                if (passwordIndex < args.Length && !args[passwordIndex].StartsWith("--"))
                {
                    string password = args[passwordIndex];
                    string encrypted = EncryptPassword(password);

                    Console.WriteLine("Password encryption result:");
                    Console.WriteLine($"Original: {password}");
                    Console.WriteLine($"Encrypted: {encrypted}");
                    Console.WriteLine("");
                    Console.WriteLine("To use in emailer.ini:");
                    Console.WriteLine($"Password = {encrypted}");
                    Console.WriteLine("PasswordIsEncrypted = True");
                    Console.WriteLine("");
                    Console.WriteLine("WARNING: Base64 encoding provides basic obfuscation only.");
                    Console.WriteLine("For security, consider using proper encryption tools.");

                    UnifiedLog($"Password encryption command executed - encrypted {password.Length} characters safely", "INFO");
                }
                else
                {
                    Console.WriteLine("ERROR: No password provided for encryption");
                    Console.WriteLine(@"Usage: emailer --encrypt-password ""your_password""");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR during password encryption: {ex.Message}");
                UnifiedLog($"ERROR during password encryption: {ex.Message}", "ERROR");
            }
        }

        private void ResetConfigurationCommand()
        {
            try
            {
                ShowConsole();

                Console.WriteLine("Resetting configuration files...");

                if (File.Exists(_iniPath))
                {
                    File.Delete(_iniPath);
                    Console.WriteLine("Deleted: emailer.ini");
                }

                if (File.Exists(_logPath))
                {
                    File.Delete(_logPath);
                    Console.WriteLine("Deleted: emailer.log");
                }

                CreateDefaultIniFile();
                Console.WriteLine("Created: emailer.ini (default configuration)");

                File.WriteAllText(_logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [INFO] Configuration reset - new log file created{Environment.NewLine}");
                Console.WriteLine("Created: emailer.log (empty log file)");

                Console.WriteLine("");
                Console.WriteLine("Configuration reset completed successfully.");
                Console.WriteLine("You MUST edit emailer.ini and configure your SMTP settings before use.");

                UnifiedLog("Configuration reset command executed - all environment files recreated", "INFO");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR during configuration reset: {ex.Message}");
                UnifiedLog($"ERROR during configuration reset: {ex.Message}", "ERROR");
            }
        }

        private void ParseArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--debug":
                        _debug = true;
                        break;
                    case "--subject":
                        if (i + 1 < args.Length)
                            _subject = args[++i];
                        break;
                    case "--body":
                        if (i + 1 < args.Length)
                            _body = args[++i];
                        break;
                    case "--no-sound":
                        _enableSound = false;
                        break;
                    case "--attach":
                        if (i + 1 < args.Length)
                            _attachmentPath = args[++i];
                        break;
                    case "--server":
                        if (i + 1 < args.Length)
                            _cmdServer = args[++i];
                        break;
                    case "--port":
                        if (i + 1 < args.Length)
                            _cmdPort = args[++i];
                        break;
                    case "--username":
                        if (i + 1 < args.Length)
                            _cmdUsername = args[++i];
                        break;
                    case "--password":
                        if (i + 1 < args.Length)
                            _cmdPassword = args[++i];
                        break;
                    case "--from":
                        if (i + 1 < args.Length)
                            _cmdFrom = args[++i];
                        break;
                    case "--to":
                        if (i + 1 < args.Length)
                            _cmdTo = args[++i];
                        break;
                    case "--ssl":
                        if (i + 1 < args.Length)
                            _cmdSsl = args[++i];
                        break;
                    case "--cc":
                        if (i + 1 < args.Length)
                            _cmdCc = args[++i];
                        break;
                    case "--bcc":
                        if (i + 1 < args.Length)
                            _cmdBcc = args[++i];
                        break;
                    case "--importance":
                        if (i + 1 < args.Length)
                            _cmdImportance = args[++i].ToLower();
                        break;
                }
            }
        }

        private void ShowConsole()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    AllocConsole();
                }
            }
            catch { }
        }

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        private void PlayAlertSound()
        {
            if (!_enableSound)
                return;

            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Console.Beep(1000, 500);
                }
            }
            catch { }
        }

        private bool IsFileLocked(string filePath)
        {
            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsFileBusy(string filePath)
        {
            return IsFileLocked(filePath);
        }

        private void NotifyFileLock(string filePath, string fileType)
        {
            if (_inFileLockNotification)
                return;

            _inFileLockNotification = true;
            try
            {
                string warning = $"{fileType} file {filePath} is locked by another process!";
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string alarmMessage = $"[{timestamp}] [ALARM] {warning}";

                // Write to console
                if (_debug)
                {
                    Console.WriteLine(alarmMessage);
                }

                // Write to log file with direct file access to avoid recursion
                try
                {
                    using (var writer = new StreamWriter(_logPath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(alarmMessage);
                    }
                }
                catch
                {
                    // If we can't write to log, at least show console warning
                    ShowWarning(warning);
                }

                ShowWarning(warning);
                PlayAlertSound();

                // Store warning for potential email body inclusion
                _fileLockWarnings.Add(warning);
            }
            finally
            {
                _inFileLockNotification = false;
            }
        }

        private bool IsPasswordEncrypted(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Length % 4 == 0 &&
                Regex.IsMatch(password, @"^[a-zA-Z0-9\+/]*={0,3}$"))
            {
                try
                {
                    byte[] data = Convert.FromBase64String(password);
                    string decoded = Encoding.UTF8.GetString(data);
                    return decoded != password;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private string GetPasswordType(string password)
        {
            if (password == "yourpassword")
                return "default";

            return IsPasswordEncrypted(password) ? "encrypted" : "plain";
        }

        private bool ParseBool(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            string trimmed = value.Trim().ToLower();
            return trimmed == "true" || trimmed == "t" || trimmed == "1" || trimmed == "yes" || trimmed == "y";
        }

        private MailPriority ParseImportance(string importance)
        {
            if (string.IsNullOrEmpty(importance))
                return MailPriority.Normal;

            string trimmed = importance.Trim().ToLower();
            switch (trimmed)
            {
                case "high":
                    return MailPriority.High;
                case "low":
                    return MailPriority.Low;
                default:
                    return MailPriority.Normal;
            }
        }

        private List<string> ParseEmailList(string emailList)
        {
            var emails = new List<string>();
            if (string.IsNullOrEmpty(emailList))
                return emails;

            var parts = emailList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                var email = part.Trim();
                if (!string.IsNullOrEmpty(email) && IsValidEmail(email))
                {
                    emails.Add(email);
                }
            }
            return emails;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void UnifiedLog(string message, string level = "INFO")
        {
            if (_inFileLockNotification && level == "ALARM")
                return;

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string formattedMessage = $"[{timestamp}] [{level}] {message}";

            WriteToLogFile(formattedMessage);

            if (_debug)
            {
                Console.WriteLine(formattedMessage);
            }
        }

        private void SendEmail()
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            _iniPath = Path.Combine(appDir, "emailer.ini");

            if (File.Exists(_iniPath) && IsFileLocked(_iniPath))
            {
                NotifyFileLock(_iniPath, "INI");
                return;
            }

            if (File.Exists(_logPath) && IsFileLocked(_logPath))
            {
                NotifyFileLock(_logPath, "Log");
            }

            var settings = ReadSettings();
            if (settings == null)
            {
                UnifiedLog("Cannot read settings", "ERROR");
                return;
            }

            ApplyCommandLineOverrides(settings);

            if (settings.Password == "yourpassword" && string.IsNullOrEmpty(_cmdPassword))
            {
                string error = "Password not configured - you MUST edit emailer.ini and change 'yourpassword' to your actual password";
                UnifiedLog(error, "ERROR");
                ShowWarning("PASSWORD NOT CONFIGURED: Edit emailer.ini and change 'yourpassword'");
                PlayAlertSound();
                return;
            }

            string actualPassword = settings.Password;
            bool passwordWasEncrypted = IsPasswordEncrypted(settings.Password);
            string currentPasswordType = GetPasswordType(settings.Password);

            try
            {
                if (passwordWasEncrypted)
                {
                    try
                    {
                        actualPassword = DecryptPassword(settings.Password);
                        UnifiedLog("Password decrypted successfully for SMTP authentication", "INFO");
                    }
                    catch (Exception ex)
                    {
                        HandleException("ERROR decrypting password", ex);
                        return;
                    }
                }

                using (SmtpClient client = new SmtpClient(settings.SmtpServer, settings.SmtpPort))
                {
                    client.Credentials = new NetworkCredential(settings.Username, actualPassword);
                    client.EnableSsl = settings.EnableSSL;
                    client.Timeout = 30000;

                    using (MailMessage message = new MailMessage())
                    {
                        message.Priority = ParseImportance(_cmdImportance);

                        message.From = new MailAddress(settings.FromEmail);

                        var toEmails = ParseEmailList(settings.ToEmail);
                        if (toEmails.Count == 0)
                        {
                            UnifiedLog("No TO recipients specified", "ERROR");
                            return;
                        }

                        foreach (var email in toEmails)
                        {
                            message.To.Add(email);
                        }

                        var ccEmails = ParseEmailList(_cmdCc);
                        foreach (var email in ccEmails)
                        {
                            message.CC.Add(email);
                        }

                        var bccEmails = ParseEmailList(_cmdBcc);
                        foreach (var email in bccEmails)
                        {
                            message.Bcc.Add(email);
                        }

                        // Build body - add file lock warnings only if attachment failed
                        string baseBody = string.IsNullOrEmpty(_body) ? GetDefaultBody() : ProcessTemplateVariables(_body);
                        string finalBody = baseBody;

                        if (_attachmentFailed && _fileLockWarnings.Count > 0)
                        {
                            finalBody = baseBody + "\n\nFILE LOCK WARNINGS:\n" + string.Join("\n", _fileLockWarnings);
                        }

                        message.Body = finalBody;

                        string finalSubject = string.IsNullOrEmpty(_subject) ?
                            $"host: {Environment.MachineName}" :
                            ProcessTemplateVariables(_subject);
                        message.Subject = finalSubject;

                        // Reset attachment failure flag
                        _attachmentFailed = false;

                        if (!string.IsNullOrEmpty(_attachmentPath))
                        {
                            bool attachmentSuccess = HandleAttachment(message, _attachmentPath);
                            if (!attachmentSuccess)
                            {
                                _attachmentFailed = true;
                            }
                        }

                        client.Send(message);

                        if (!passwordWasEncrypted && string.IsNullOrEmpty(_cmdPassword))
                        {
                            if (!IsFileLocked(_iniPath))
                            {
                                if (EncryptPasswordInIniFile(actualPassword))
                                {
                                    UnifiedLog("Password successfully encrypted and saved to .ini file", "INFO");
                                    ShowNotification("Password successfully encrypted and saved to INI file");
                                    currentPasswordType = "encrypted";
                                }
                                else
                                {
                                    UnifiedLog("Failed to encrypt password in INI file", "ERROR");
                                }
                            }
                            else
                            {
                                NotifyFileLock(_iniPath, "INI");
                            }
                        }

                        string logSubject = string.IsNullOrEmpty(_subject) ? "<null>" : _subject;
                        string logBody = string.IsNullOrEmpty(_body) ? "<null>" : _body;
                        string attachmentInfo = string.IsNullOrEmpty(_attachmentPath) ? "" : $" | Attachment: {_attachmentPath}";

                        string ccInfo = string.IsNullOrEmpty(_cmdCc) ? "" : $" | CC: {_cmdCc}";
                        string bccInfo = string.IsNullOrEmpty(_cmdBcc) ? "" : $" | BCC: {_cmdBcc}";
                        string importanceInfo = _cmdImportance != "normal" ? $" | Importance: {_cmdImportance}" : "";

                        string successLog = $"SMTP-ok: {settings.SmtpServer}:{settings.SmtpPort} SSL:{settings.EnableSSL} {settings.Username} Pass:{currentPasswordType} | {settings.FromEmail} -> {settings.ToEmail}{ccInfo}{bccInfo}{importanceInfo} | Subject: {logSubject} | Body: {logBody}{attachmentInfo}";
                        UnifiedLog(successLog, "INFO");
                    }
                }
            }
            catch (SmtpException ex) when (IsAuthenticationError(ex))
            {
                if (passwordWasEncrypted && string.IsNullOrEmpty(_cmdPassword))
                {
                    if (!IsFileLocked(_iniPath))
                    {
                        if (RevertToUnencryptedPassword(actualPassword))
                        {
                            UnifiedLog("Password reverted to unencrypted format due to authentication failure", "INFO");
                            ShowWarning("Password reverted to unencrypted format due to authentication failure");
                        }
                        else
                        {
                            UnifiedLog("Failed to revert password to unencrypted format", "ERROR");
                        }
                    }
                    else
                    {
                        NotifyFileLock(_iniPath, "INI");
                    }
                }
                UnifiedLog("SMTP AUTHENTICATION - Invalid password", "ERROR");
                HandleException("SMTP AUTHENTICATION - Invalid password", ex);
                PlayAlertSound();
            }
            catch (SmtpException ex)
            {
                UnifiedLog("SMTP SERVER ERROR", "ERROR");
                HandleException("SMTP SERVER ERROR", ex);
                PlayAlertSound();
            }
            catch (Exception ex)
            {
                UnifiedLog("UNEXPECTED ERROR during email sending", "ERROR");
                HandleException("UNEXPECTED ERROR during email sending", ex);
                PlayAlertSound();
            }
        }

        private bool HandleAttachment(MailMessage message, string filePath)
        {
            try
            {
                string fullPath = Path.GetFullPath(filePath);

                if (!File.Exists(fullPath))
                {
                    UnifiedLog($"Attachment file not found: {fullPath}", "ERROR");
                    return false;
                }

                try
                {
                    Attachment attachment = new Attachment(fullPath);
                    message.Attachments.Add(attachment);
                    UnifiedLog($"Attachment added: {fullPath} ({new FileInfo(fullPath).Length} bytes)", "INFO");
                    return true;
                }
                catch (IOException ioEx) when (ioEx.Message.Contains("used by another process") || ioEx.Message.Contains("locked") || ioEx.Message.Contains("busy"))
                {
                    UnifiedLog($"File {fullPath} is busy/locked, creating temporary copy...", "INFO");

                    string tempFile = CreateTemporaryCopy(fullPath);
                    if (tempFile != null)
                    {
                        try
                        {
                            Attachment attachment = new Attachment(tempFile);
                            message.Attachments.Add(attachment);
                            UnifiedLog($"Temporary copy attached: {tempFile} ({new FileInfo(tempFile).Length} bytes)", "INFO");

                            ScheduleTempFileDeletion(tempFile);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            UnifiedLog($"Failed to attach temporary copy: {ex.Message}", "ERROR");
                            TryDeleteFile(tempFile);
                            return false;
                        }
                    }
                    else
                    {
                        UnifiedLog($"Failed to create temporary copy of {fullPath}", "ERROR");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    UnifiedLog($"Failed to attach file {fullPath}: {ex.Message}", "ERROR");
                    return false;
                }
            }
            catch (Exception ex)
            {
                UnifiedLog($"Error processing attachment {filePath}: {ex.Message}", "ERROR");
                return false;
            }
        }

        private string CreateTemporaryCopy(string originalPath)
        {
            try
            {
                string tempDir = Path.GetTempPath();
                string fileName = Path.GetFileName(originalPath);
                string tempFile = Path.Combine(tempDir, $"emailer_attach_{Guid.NewGuid()}_{fileName}");

                File.Copy(originalPath, tempFile, true);
                return tempFile;
            }
            catch (Exception ex)
            {
                UnifiedLog($"Failed to create temporary copy: {ex.Message}", "ERROR");
                return null;
            }
        }

        private void ScheduleTempFileDeletion(string tempFile)
        {
            try
            {
                Task.Run(async () =>
                {
                    await Task.Delay(5000);
                    TryDeleteFile(tempFile);
                });
            }
            catch (Exception ex)
            {
                UnifiedLog($"Failed to schedule temp file deletion: {ex.Message}", "DEBUG");
            }
        }

        private void TryDeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    UnifiedLog($"Temporary file deleted: {filePath}", "DEBUG");
                }
            }
            catch (Exception ex)
            {
                UnifiedLog($"Failed to delete temporary file {filePath}: {ex.Message}", "DEBUG");
            }
        }

        private void ApplyCommandLineOverrides(EmailSettings settings)
        {
            if (!string.IsNullOrEmpty(_cmdServer))
                settings.SmtpServer = _cmdServer;

            if (!string.IsNullOrEmpty(_cmdPort) && int.TryParse(_cmdPort, out int port))
                settings.SmtpPort = port;

            if (!string.IsNullOrEmpty(_cmdUsername))
                settings.Username = _cmdUsername;

            if (!string.IsNullOrEmpty(_cmdPassword))
                settings.Password = _cmdPassword;

            if (!string.IsNullOrEmpty(_cmdFrom))
                settings.FromEmail = _cmdFrom;

            if (!string.IsNullOrEmpty(_cmdTo))
                settings.ToEmail = _cmdTo;

            if (!string.IsNullOrEmpty(_cmdSsl))
                settings.EnableSSL = ParseBool(_cmdSsl);
        }

        private void ShowWarning(string message)
        {
            try
            {
                ShowConsole();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                Console.ResetColor();
            }
            catch { }
        }

        private void ShowNotification(string message)
        {
            try
            {
                ShowConsole();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                Console.ResetColor();
            }
            catch { }
        }

        private bool IsAuthenticationError(SmtpException ex)
        {
            return ex.Message.Contains("authentication") ||
                   ex.Message.Contains("password") ||
                   ex.Message.Contains("credential") ||
                   ex.StatusCode == SmtpStatusCode.MustIssueStartTlsFirst ||
                   ex.StatusCode == SmtpStatusCode.ClientNotPermitted;
        }

        private bool RevertToUnencryptedPassword(string password)
        {
            try
            {
                var lines = File.ReadAllLines(_iniPath);
                var newLines = new List<string>();
                bool passwordUpdated = false;
                bool encryptionDisabled = false;

                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    var parts = trimmedLine.Split(new[] { '=' }, 2);

                    if (parts.Length == 2)
                    {
                        var key = parts[0].Trim().ToLower();
                        var value = parts[1].Trim();

                        if (key == "password")
                        {
                            newLines.Add($"Password = {password}");
                            passwordUpdated = true;
                        }
                        else if (key == "passwordisencrypted")
                        {
                            newLines.Add("PasswordIsEncrypted = False");
                            encryptionDisabled = true;
                        }
                        else
                        {
                            newLines.Add(line);
                        }
                    }
                    else
                    {
                        newLines.Add(line);
                    }
                }

                if (passwordUpdated && encryptionDisabled)
                {
                    File.WriteAllLines(_iniPath, newLines);

                    var newSettings = ReadSettings();
                    return newSettings != null && !IsPasswordEncrypted(newSettings.Password);
                }
                return false;
            }
            catch (Exception ex)
            {
                HandleException("ERROR reverting password to unencrypted", ex);
                return false;
            }
        }

        private bool EncryptPasswordInIniFile(string password)
        {
            try
            {
                var lines = File.ReadAllLines(_iniPath);
                var newLines = new List<string>();
                bool passwordUpdated = false;
                bool encryptionEnabled = false;

                string encryptedPassword = EncryptPassword(password);

                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    var parts = trimmedLine.Split(new[] { '=' }, 2);

                    if (parts.Length == 2)
                    {
                        var key = parts[0].Trim().ToLower();
                        var value = parts[1].Trim();

                        if (key == "password")
                        {
                            newLines.Add($"Password = {encryptedPassword}");
                            passwordUpdated = true;
                        }
                        else if (key == "passwordisencrypted")
                        {
                            newLines.Add("PasswordIsEncrypted = True");
                            encryptionEnabled = true;
                        }
                        else
                        {
                            newLines.Add(line);
                        }
                    }
                    else
                    {
                        newLines.Add(line);
                    }
                }

                if (passwordUpdated && encryptionEnabled)
                {
                    File.WriteAllLines(_iniPath, newLines);

                    var newSettings = ReadSettings();
                    return newSettings != null && IsPasswordEncrypted(newSettings.Password);
                }
                return false;
            }
            catch (Exception ex)
            {
                HandleException("ERROR encrypting password in INI file", ex);
                return false;
            }
        }

        private string ProcessTemplateVariables(string text)
        {
            return text
                .Replace("{host}", Environment.MachineName)
                .Replace("{user}", Environment.UserName)
                .Replace("{timestamp}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("{time}", DateTime.Now.ToString("HH:mm:ss"))
                .Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private string GetDefaultBody()
        {
            return $"Notification from Your Emailer\nHost: {Environment.MachineName}\nUser: {Environment.UserName}\nTime: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        }

        private EmailSettings ReadSettings()
        {
            try
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                _iniPath = Path.Combine(appDir, "emailer.ini");

                if (!File.Exists(_iniPath))
                {
                    if (HasRequiredCommandLineParameters())
                    {
                        UnifiedLog("INI file not found, using command line parameters", "INFO");
                        return CreateSettingsFromCommandLine();
                    }

                    UnifiedLog("INI file not found, creating default configuration", "INFO");
                    CreateDefaultIniFile();
                    UnifiedLog("Default INI file created. You MUST edit emailer.ini and configure your SMTP settings before use.", "INFO");
                    ShowWarning("DEFAULT INI FILE CREATED - YOU MUST EDIT emailer.ini AND CONFIGURE SETTINGS");
                    return null;
                }

                var lines = File.ReadAllLines(_iniPath);
                var settings = new EmailSettings();
                int validSettings = 0;

                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith(";"))
                        continue;

                    var parts = trimmedLine.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        var key = parts[0].Trim().ToLower();
                        var value = parts[1].Trim();

                        switch (key)
                        {
                            case "username":
                                settings.Username = value;
                                validSettings++;
                                break;
                            case "password":
                                settings.Password = value;
                                validSettings++;
                                break;
                            case "passwordisencrypted":
                                settings.PasswordIsEncrypted = ParseBool(value);
                                validSettings++;
                                break;
                            case "smtpserver":
                                settings.SmtpServer = value;
                                validSettings++;
                                break;
                            case "smtpport":
                                if (int.TryParse(value, out int port))
                                {
                                    settings.SmtpPort = port;
                                    validSettings++;
                                }
                                break;
                            case "fromemail":
                                settings.FromEmail = value;
                                validSettings++;
                                break;
                            case "toemail":
                                settings.ToEmail = value;
                                validSettings++;
                                break;
                            case "enablessl":
                                settings.EnableSSL = ParseBool(value);
                                validSettings++;
                                break;
                        }
                    }
                }

                if (validSettings < 6 && !HasRequiredCommandLineParameters())
                {
                    UnifiedLog("Invalid INI file format - missing required settings", "ERROR");
                    return null;
                }

                return settings;
            }
            catch (Exception ex)
            {
                HandleException("ERROR reading configuration", ex);
                return null;
            }
        }

        private bool HasRequiredCommandLineParameters()
        {
            return !string.IsNullOrEmpty(_cmdServer) &&
                   !string.IsNullOrEmpty(_cmdPort) &&
                   !string.IsNullOrEmpty(_cmdUsername) &&
                   !string.IsNullOrEmpty(_cmdPassword) &&
                   !string.IsNullOrEmpty(_cmdFrom) &&
                   !string.IsNullOrEmpty(_cmdTo);
        }

        private EmailSettings CreateSettingsFromCommandLine()
        {
            var settings = new EmailSettings();

            settings.SmtpServer = _cmdServer;

            if (int.TryParse(_cmdPort, out int port))
                settings.SmtpPort = port;

            settings.Username = _cmdUsername;
            settings.Password = _cmdPassword;
            settings.FromEmail = _cmdFrom;
            settings.ToEmail = _cmdTo;
            settings.EnableSSL = ParseBool(_cmdSsl);

            return settings;
        }

        private string EncryptPassword(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(data);
        }

        private string DecryptPassword(string encryptedPassword)
        {
            try
            {
                byte[] data = Convert.FromBase64String(encryptedPassword);
                return Encoding.UTF8.GetString(data);
            }
            catch
            {
                throw new Exception("Failed to decrypt password - invalid format");
            }
        }

        private void CreateDefaultIniFile()
        {
            try
            {
                var defaultContent = @"
; Emailer Configuration Settings - OPEN SOURCE Application
; Update these values before using the application
; This is open source software: all functionality is publicly verifiable
Password = yourpassword
PasswordIsEncrypted = False
Username = DOMAIN\user
SmtpServer = mail.domain.ru
SmtpPort = 587
FromEmail = account@domain.ru
ToEmail = account@domain.ru
EnableSSL = True
".TrimStart();

                File.WriteAllText(_iniPath, defaultContent, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                HandleException("ERROR creating default INI file", ex);
            }
        }

        private void HandleException(string context, Exception ex)
        {
            if (!context.StartsWith("ERROR"))
            {
                UnifiedLog(context, "ERROR");
            }

            UnifiedLog($"EXCEPTION TYPE: {ex.GetType().FullName}", "DEBUG");
            UnifiedLog($"MESSAGE: {ex.Message}", "DEBUG");
            UnifiedLog($"STACK TRACE: {ex.StackTrace}", "DEBUG");

            if (ex.InnerException != null)
            {
                UnifiedLog($"INNER EXCEPTION: {ex.InnerException.GetType().FullName}", "DEBUG");
                UnifiedLog($"INNER MESSAGE: {ex.InnerException.Message}", "DEBUG");
                UnifiedLog($"INNER STACK TRACE: {ex.InnerException.StackTrace}", "DEBUG");
            }

            if (ex is SmtpException smtpEx)
            {
                UnifiedLog($"SMTP STATUS CODE: {smtpEx.StatusCode}", "DEBUG");
            }

            if (_debug)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n=== EXCEPTION DETAILS ===");
                Console.WriteLine($"Context: {context}");
                Console.WriteLine($"Type: {ex.GetType().FullName}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                Console.WriteLine("========================\n");
                Console.ResetColor();
            }
        }

        private void WriteToLogFile(string message)
        {
            if (_inFileLockNotification)
                return;

            try
            {
                if (File.Exists(_logPath) && IsFileLocked(_logPath))
                {
                    NotifyFileLock(_logPath, "Log");
                    return;
                }

                File.AppendAllText(_logPath, message + Environment.NewLine, Encoding.UTF8);
            }
            catch (IOException ioEx) when (ioEx.Message.Contains("locked") || ioEx.Message.Contains("being used"))
            {
                NotifyFileLock(_logPath, "Log");
            }
            catch { }
        }
    }

    public class EmailSettings
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public bool PasswordIsEncrypted { get; set; } = false;
        public string SmtpServer { get; set; } = "";
        public int SmtpPort { get; set; } = 587;
        public string FromEmail { get; set; } = "";
        public string ToEmail { get; set; } = "";
        public bool EnableSSL { get; set; } = true;
    }
}
