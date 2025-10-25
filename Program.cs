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
using System.Threading.Tasks;

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

        // Constants for application version
        private const string APP_VERSION = "1.10";
        private const string APP_NAME = "SMTP Email Sending Utility";

        public void Run(string[] args)
        {
            try // Main execution block start
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                _iniPath = Path.Combine(appDir, "emailer.ini");
                _logPath = Path.Combine(appDir, "emailer.log");

                // Handle help and version parameters first
                if (IsHelpRequested(args)) // Help request check start
                {
                    ShowHelp();
                    return;
                } // Help request check end

                if (IsVersionRequested(args)) // Version request check start
                {
                    ShowVersion();
                    return;
                } // Version request check end

                if (args.Contains("--encrypt-password")) // Encrypt password command check start
                {
                    EncryptPasswordCommand(args);
                    return;
                } // Encrypt password command check end

                if (args.Contains("--reset-config")) // Reset config command check start
                {
                    ResetConfigurationCommand();
                    return;
                } // Reset config command check end

                ParseArguments(args);

                if (_debug && !_debugModeLogged) // Debug mode initialization check start
                {
                    ShowConsole();
                    string debugMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [DEBUG MODE] {Environment.MachineName} | {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} | {AppDomain.CurrentDomain.BaseDirectory}";

                    WriteToLogFile(debugMessage);
                    Console.WriteLine(debugMessage);

                    _debugModeLogged = true;
                } // Debug mode initialization check end

                SendEmail();
            } // Main execution block end
            catch (Exception ex) // Main exception handling start
            {
                HandleException("CRITICAL ERROR in Main", ex);
                Environment.Exit(1);
            } // Main exception handling end
        }

        /// <summary>
        /// Check if help was requested via any supported parameter
        /// </summary>
        private bool IsHelpRequested(string[] args)
        {
            string[] helpParams = { "--help", "-h", "/?", "-?", "--?", "?" };
            return args.Any(arg => helpParams.Contains(arg.ToLower()));
        }

        /// <summary>
        /// Check if version was requested via any supported parameter
        /// </summary>
        private bool IsVersionRequested(string[] args)
        {
            string[] versionParams = { "--version", "-version", "--v", "-v", "/v" };
            return args.Any(arg => versionParams.Contains(arg.ToLower()));
        }

        /// <summary>
        /// Display application version information
        /// </summary>
        private void ShowVersion()
        {
            ShowConsole();
            Console.WriteLine($"{APP_NAME} v{APP_VERSION}");
            Console.WriteLine("Open Source SMTP Email Utility");
            Console.WriteLine("Full code available: https://github.com/assanj/emailer.git");
        }

        private void ShowHelp()
        {
            string helpText = $@"
{APP_NAME} v{APP_VERSION} - OPEN SOURCE & CROSS-PLATFORM
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
  --version, -v    Show version information
  --encrypt-password PASS  Encrypt password for INI file
  --reset-config    Reset configuration files  

TEMPLATE VARIABLES:
  {{host}} {{user}} {{timestamp}} {{time}} {{date}}

EXAMPLES:
  emailer --debug --subject ""Alert from {{host}}"" --body ""User {{user}} at {{timestamp}}""
  emailer --server smtp.domain.ru --port 587 --username user --password pass --from sender@domain.ru --to recipient@domain.ru --ssl true
  emailer --attach emailer.log --subject ""Log file from {{host}}"" --body ""Generated at {{timestamp}}""
  emailer --to ""user1@domain.com,user2@domain.com"" --cc ""manager@domain.com"" --bcc ""archive@domain.com"" --importance high
  emailer --no-sound --debug
  emailer --version
";
            Console.WriteLine(helpText);
        }

        private void EncryptPasswordCommand(string[] args)
        {
            try // Password encryption command start
            {
                ShowConsole();

                int passwordIndex = Array.IndexOf(args, "--encrypt-password") + 1;
                if (passwordIndex < args.Length && !args[passwordIndex].StartsWith("--")) // Valid password parameter check start
                {
                    string password = args[passwordIndex];
                    string encrypted = EncryptPassword(password);

                    Console.WriteLine("Password encryption result:");
                    Console.WriteLine($"Original: {new string('*', password.Length)}");
                    Console.WriteLine($"Encrypted: {encrypted}");
                    Console.WriteLine("");
                    Console.WriteLine("To use in emailer.ini:");
                    Console.WriteLine($"Password = {encrypted}");
                    Console.WriteLine("PasswordIsEncrypted = True");
                    Console.WriteLine("");
                    Console.WriteLine("WARNING: Base64 encoding provides basic obfuscation only.");
                    Console.WriteLine("For security, consider using proper encryption tools.");

                    UnifiedLog($"Password encryption command executed - encrypted {password.Length} characters safely", "INFO");
                } // Valid password parameter check end
                else // Invalid password parameter start
                {
                    Console.WriteLine("ERROR: No password provided for encryption");
                    Console.WriteLine(@"Usage: emailer --encrypt-password ""your_password""");
                } // Invalid password parameter end
            } // Password encryption command end
            catch (Exception ex) // Password encryption exception handling start
            {
                Console.WriteLine($"ERROR during password encryption: {ex.Message}");
                UnifiedLog($"ERROR during password encryption: {ex.Message}", "ERROR");
            } // Password encryption exception handling end
        }

        private void ResetConfigurationCommand()
        {
            try // Reset configuration command start
            {
                ShowConsole();

                Console.WriteLine("Resetting configuration files...");

                if (File.Exists(_iniPath)) // INI file deletion check start
                {
                    File.Delete(_iniPath);
                    Console.WriteLine("Deleted: emailer.ini");
                } // INI file deletion check end

                if (File.Exists(_logPath)) // Log file deletion check start
                {
                    File.Delete(_logPath);
                    Console.WriteLine("Deleted: emailer.log");
                } // Log file deletion check end

                CreateDefaultIniFile();
                Console.WriteLine("Created: emailer.ini (default configuration)");

                File.WriteAllText(_logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [INFO] Configuration reset - new log file created{Environment.NewLine}");
                Console.WriteLine("Created: emailer.log (empty log file)");

                Console.WriteLine("");
                Console.WriteLine("Configuration reset completed successfully.");
                Console.WriteLine("You MUST edit emailer.ini and configure your SMTP settings before use.");

                UnifiedLog("Configuration reset command executed - all environment files recreated", "INFO");
            } // Reset configuration command end
            catch (Exception ex) // Reset configuration exception handling start
            {
                Console.WriteLine($"ERROR during configuration reset: {ex.Message}");
                UnifiedLog($"ERROR during configuration reset: {ex.Message}", "ERROR");
            } // Reset configuration exception handling end
        }

        private void ParseArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++) // Arguments parsing loop start
            {
                switch (args[i]) // Argument switch start
                {
                    case "--debug":
                        _debug = true;
                        break;
                    case "--subject":
                        if (i + 1 < args.Length) // Subject parameter check start
                            _subject = args[++i];
                        break; // Subject parameter check end
                    case "--body":
                        if (i + 1 < args.Length) // Body parameter check start
                            _body = args[++i];
                        break; // Body parameter check end
                    case "--no-sound":
                        _enableSound = false;
                        break;
                    case "--attach":
                        if (i + 1 < args.Length) // Attachment parameter check start
                            _attachmentPath = args[++i];
                        break; // Attachment parameter check end
                    case "--server":
                        if (i + 1 < args.Length) // Server parameter check start
                            _cmdServer = args[++i];
                        break; // Server parameter check end
                    case "--port":
                        if (i + 1 < args.Length) // Port parameter check start
                            _cmdPort = args[++i];
                        break; // Port parameter check end
                    case "--username":
                        if (i + 1 < args.Length) // Username parameter check start
                            _cmdUsername = args[++i];
                        break; // Username parameter check end
                    case "--password":
                        if (i + 1 < args.Length) // Password parameter check start
                            _cmdPassword = args[++i];
                        break; // Password parameter check end
                    case "--from":
                        if (i + 1 < args.Length) // From parameter check start
                            _cmdFrom = args[++i];
                        break; // From parameter check end
                    case "--to":
                        if (i + 1 < args.Length) // To parameter check start
                            _cmdTo = args[++i];
                        break; // To parameter check end
                    case "--ssl":
                        if (i + 1 < args.Length) // SSL parameter check start
                            _cmdSsl = args[++i];
                        break; // SSL parameter check end
                    case "--cc":
                        if (i + 1 < args.Length) // CC parameter check start
                            _cmdCc = args[++i];
                        break; // CC parameter check end
                    case "--bcc":
                        if (i + 1 < args.Length) // BCC parameter check start
                            _cmdBcc = args[++i];
                        break; // BCC parameter check end
                    case "--importance":
                        if (i + 1 < args.Length) // Importance parameter check start
                            _cmdImportance = args[++i].ToLower();
                        break; // Importance parameter check end
                } // Argument switch end
            } // Arguments parsing loop end
        }

        private void ShowConsole()
        {
            try // Console allocation start
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // Windows platform check start
                {
                    AllocConsole();
                } // Windows platform check end
            } // Console allocation end
            catch { } // Console allocation exception handling
        }

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        private void PlayAlertSound()
        {
            if (!_enableSound) // Sound enabled check start
                return;
            // Sound enabled check end

            try // Sound playback start
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // Windows sound check start
                {
                    Console.Beep(1000, 500);
                } // Windows sound check end
            } // Sound playback end
            catch { } // Sound playback exception handling
        }

        /// <summary>
        /// Check if file is locked by another process
        /// </summary>
        private bool IsFileLocked(string filePath)
        {
            try // File lock check start
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            } // File lock check end
            catch (IOException) // File IO exception handling start
            {
                return true;
            } // File IO exception handling end
            catch // Other exceptions handling start
            {
                return false;
            } // Other exceptions handling end
        }

        private bool IsFileBusy(string filePath)
        {
            return IsFileLocked(filePath);
        }

        /// <summary>
        /// Notify about file lock with protection against recursive calls
        /// </summary>
        private void NotifyFileLock(string filePath, string fileType)
        {
            if (_inFileLockNotification) // Recursion protection check start
                return;
            // Recursion protection check end

            _inFileLockNotification = true;
            try // File lock notification start
            {
                string warning = $"{fileType} file {filePath} is locked by another process!";
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string alarmMessage = $"[{timestamp}] [ALARM] {warning}";

                // Write to console
                if (_debug) // Debug mode check start
                {
                    Console.WriteLine(alarmMessage);
                } // Debug mode check end

                // Write to log file with direct file access to avoid recursion
                try // Direct log write start
                {
                    using (var writer = new StreamWriter(_logPath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(alarmMessage);
                    }
                } // Direct log write end
                catch // Direct log write exception handling start
                {
                    // If we can't write to log, at least show console warning
                    ShowWarning(warning);
                } // Direct log write exception handling end

                ShowWarning(warning);
                PlayAlertSound();

                // Store warning for potential email body inclusion
                _fileLockWarnings.Add(warning);
            } // File lock notification end
            finally // File lock notification cleanup start
            {
                _inFileLockNotification = false;
            } // File lock notification cleanup end
        }

        /// <summary>
        /// Check if password is encrypted using Base64 encoding
        /// </summary>
        private bool IsPasswordEncrypted(string password)
        {
            if (string.IsNullOrEmpty(password)) // Empty password check start
                return false;
            // Empty password check end

            // Check if string has valid Base64 format
            if (password.Length % 4 == 0 &&
                Regex.IsMatch(password, @"^[a-zA-Z0-9\+/]*={0,3}$")) // Base64 format check start
            {
                try // Base64 decoding attempt start
                {
                    byte[] data = Convert.FromBase64String(password);
                    string decoded = Encoding.UTF8.GetString(data);
                    // Check if decoded content is different from original
                    return !string.Equals(decoded, password, StringComparison.Ordinal);
                } // Base64 decoding attempt end
                catch // Base64 decoding exception handling start
                {
                    return false;
                } // Base64 decoding exception handling end
            } // Base64 format check end
            return false;
        }

        private string GetPasswordType(string password)
        {
            if (password == "yourpassword") // Default password check start
                return "default";
            // Default password check end

            return IsPasswordEncrypted(password) ? "encrypted" : "plain";
        }

        private bool ParseBool(string value)
        {
            if (string.IsNullOrEmpty(value)) // Empty value check start
                return false;
            // Empty value check end

            string trimmed = value.Trim().ToLower();
            return trimmed == "true" || trimmed == "t" || trimmed == "1" || trimmed == "yes" || trimmed == "y";
        }

        private MailPriority ParseImportance(string importance)
        {
            if (string.IsNullOrEmpty(importance)) // Empty importance check start
                return MailPriority.Normal;
            // Empty importance check end

            string trimmed = importance.Trim().ToLower();
            switch (trimmed) // Importance switch start
            {
                case "high":
                    return MailPriority.High;
                case "low":
                    return MailPriority.Low;
                default:
                    return MailPriority.Normal;
            } // Importance switch end
        }

        private List<string> ParseEmailList(string emailList)
        {
            var emails = new List<string>();
            if (string.IsNullOrEmpty(emailList)) // Empty email list check start
                return emails;
            // Empty email list check end

            var parts = emailList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts) // Email parts processing loop start
            {
                var email = part.Trim();
                if (!string.IsNullOrEmpty(email) && IsValidEmail(email)) // Valid email check start
                {
                    emails.Add(email);
                } // Valid email check end
            } // Email parts processing loop end
            return emails;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) // Empty email check start
                return false;
            // Empty email check end

            try // Email validation start
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            } // Email validation end
            catch // Email validation exception handling start
            {
                return false;
            } // Email validation exception handling end
        }

        private void UnifiedLog(string message, string level = "INFO")
        {
            if (_inFileLockNotification && level == "ALARM") // File lock notification check start
                return;
            // File lock notification check end

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string formattedMessage = $"[{timestamp}] [{level}] {message}";

            WriteToLogFile(formattedMessage);

            if (_debug) // Debug mode check start
            {
                Console.WriteLine(formattedMessage);
            } // Debug mode check end
        }

        private void SendEmail()
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            _iniPath = Path.Combine(appDir, "emailer.ini");

            if (File.Exists(_iniPath) && IsFileLocked(_iniPath)) // INI file lock check start
            {
                NotifyFileLock(_iniPath, "INI");
                return;
            } // INI file lock check end

            if (File.Exists(_logPath) && IsFileLocked(_logPath)) // Log file lock check start
            {
                NotifyFileLock(_logPath, "Log");
            } // Log file lock check end

            var settings = ReadSettings();
            if (settings == null) // Settings validation check start
            {
                UnifiedLog("Cannot read settings", "ERROR");
                return;
            } // Settings validation check end

            ApplyCommandLineOverrides(settings);

            if (settings.Password == "yourpassword" && string.IsNullOrEmpty(_cmdPassword)) // Default password check start
            {
                string error = "Password not configured - you MUST edit emailer.ini and change 'yourpassword' to your actual password";
                UnifiedLog(error, "ERROR");
                ShowWarning("PASSWORD NOT CONFIGURED: Edit emailer.ini and change 'yourpassword'");
                PlayAlertSound();
                return;
            } // Default password check end

            string actualPassword = settings.Password;
            bool passwordWasEncrypted = IsPasswordEncrypted(settings.Password);
            string currentPasswordType = GetPasswordType(settings.Password);

            try // Email sending start
            {
                if (passwordWasEncrypted) // Encrypted password handling start
                {
                    try // Password decryption start
                    {
                        actualPassword = DecryptPassword(settings.Password);
                        UnifiedLog("Password decrypted successfully for SMTP authentication", "INFO");
                    } // Password decryption end
                    catch (Exception ex) // Password decryption exception handling start
                    {
                        HandleException("ERROR decrypting password", ex);
                        return;
                    } // Password decryption exception handling end
                } // Encrypted password handling end

                using (SmtpClient client = new SmtpClient(settings.SmtpServer, settings.SmtpPort)) // SMTP client using start
                {
                    client.Credentials = new NetworkCredential(settings.Username, actualPassword);
                    client.EnableSsl = settings.EnableSSL;
                    client.Timeout = 30000;

                    using (MailMessage message = new MailMessage()) // Mail message using start
                    {
                        message.Priority = ParseImportance(_cmdImportance);

                        message.From = new MailAddress(settings.FromEmail);

                        var toEmails = ParseEmailList(settings.ToEmail);
                        if (toEmails.Count == 0) // Recipients validation check start
                        {
                            UnifiedLog("No TO recipients specified", "ERROR");
                            return;
                        } // Recipients validation check end

                        foreach (var email in toEmails) // To emails loop start
                        {
                            message.To.Add(email);
                        } // To emails loop end

                        var ccEmails = ParseEmailList(_cmdCc);
                        foreach (var email in ccEmails) // CC emails loop start
                        {
                            message.CC.Add(email);
                        } // CC emails loop end

                        var bccEmails = ParseEmailList(_cmdBcc);
                        foreach (var email in bccEmails) // BCC emails loop start
                        {
                            message.Bcc.Add(email);
                        } // BCC emails loop end

                        // Build body - add file lock warnings only if attachment failed
                        string baseBody = string.IsNullOrEmpty(_body) ? GetDefaultBody() : ProcessTemplateVariables(_body);
                        string finalBody = baseBody;

                        if (_attachmentFailed && _fileLockWarnings.Count > 0) // Attachment failure check start
                        {
                            finalBody = baseBody + "\n\nFILE LOCK WARNINGS:\n" + string.Join("\n", _fileLockWarnings);
                        } // Attachment failure check end

                        message.Body = finalBody;

                        string finalSubject = string.IsNullOrEmpty(_subject) ?
                            $"host: {Environment.MachineName}" :
                            ProcessTemplateVariables(_subject);
                        message.Subject = finalSubject;

                        // Reset attachment failure flag
                        _attachmentFailed = false;

                        if (!string.IsNullOrEmpty(_attachmentPath)) // Attachment processing check start
                        {
                            bool attachmentSuccess = HandleAttachment(message, _attachmentPath);
                            if (!attachmentSuccess) // Attachment failure check start
                            {
                                _attachmentFailed = true;
                            } // Attachment failure check end
                        } // Attachment processing check end

                        client.Send(message);

                        if (!passwordWasEncrypted && string.IsNullOrEmpty(_cmdPassword)) // Password encryption opportunity check start
                        {
                            if (!IsFileLocked(_iniPath)) // INI file accessibility check start
                            {
                                if (EncryptPasswordInIniFile(actualPassword)) // Password encryption success check start
                                {
                                    UnifiedLog("Password successfully encrypted and saved to .ini file", "INFO");
                                    ShowNotification("Password successfully encrypted and saved to INI file");
                                    currentPasswordType = "encrypted";
                                } // Password encryption success check end
                                else // Password encryption failure start
                                {
                                    UnifiedLog("Failed to encrypt password in INI file", "ERROR");
                                } // Password encryption failure end
                            } // INI file accessibility check end
                            else // INI file locked start
                            {
                                NotifyFileLock(_iniPath, "INI");
                            } // INI file locked end
                        } // Password encryption opportunity check end

                        string logSubject = string.IsNullOrEmpty(_subject) ? "<null>" : _subject;
                        string logBody = string.IsNullOrEmpty(_body) ? "<null>" : _body;
                        string attachmentInfo = string.IsNullOrEmpty(_attachmentPath) ? "" : $" | Attachment: {_attachmentPath}";

                        string ccInfo = string.IsNullOrEmpty(_cmdCc) ? "" : $" | CC: {_cmdCc}";
                        string bccInfo = string.IsNullOrEmpty(_cmdBcc) ? "" : $" | BCC: {_cmdBcc}";
                        string importanceInfo = _cmdImportance != "normal" ? $" | Importance: {_cmdImportance}" : "";

                        string successLog = $"SMTP-ok: {settings.SmtpServer}:{settings.SmtpPort} SSL:{settings.EnableSSL} {settings.Username} Pass:{currentPasswordType} | {settings.FromEmail} -> {settings.ToEmail}{ccInfo}{bccInfo}{importanceInfo} | Subject: {logSubject} | Body: {logBody}{attachmentInfo}";
                        UnifiedLog(successLog, "INFO");
                    } // Mail message using end
                } // SMTP client using end
            } // Email sending end
            catch (SmtpException ex) when (IsAuthenticationError(ex)) // SMTP authentication exception handling start
            {
                if (passwordWasEncrypted && string.IsNullOrEmpty(_cmdPassword)) // Encrypted password failure check start
                {
                    if (!IsFileLocked(_iniPath)) // INI file accessibility check start
                    {
                        if (RevertToUnencryptedPassword(actualPassword)) // Password reversion success check start
                        {
                            UnifiedLog("Password reverted to unencrypted format due to authentication failure", "INFO");
                            ShowWarning("Password reverted to unencrypted format due to authentication failure");
                        } // Password reversion success check end
                        else // Password reversion failure start
                        {
                            UnifiedLog("Failed to revert password to unencrypted format", "ERROR");
                        } // Password reversion failure end
                    } // INI file accessibility check end
                    else // INI file locked start
                    {
                        NotifyFileLock(_iniPath, "INI");
                    } // INI file locked end
                } // Encrypted password failure check end
                UnifiedLog("SMTP AUTHENTICATION - Invalid password", "ERROR");
                HandleException("SMTP AUTHENTICATION - Invalid password", ex);
                PlayAlertSound();
            } // SMTP authentication exception handling end
            catch (SmtpException ex) // SMTP general exception handling start
            {
                UnifiedLog("SMTP SERVER ERROR", "ERROR");
                HandleException("SMTP SERVER ERROR", ex);
                PlayAlertSound();
            } // SMTP general exception handling end
            catch (Exception ex) // General exception handling start
            {
                UnifiedLog("UNEXPECTED ERROR during email sending", "ERROR");
                HandleException("UNEXPECTED ERROR during email sending", ex);
                PlayAlertSound();
            } // General exception handling end
        }

        private bool HandleAttachment(MailMessage message, string filePath)
        {
            try // Attachment handling start
            {
                string fullPath = Path.GetFullPath(filePath);

                if (!File.Exists(fullPath)) // File existence check start
                {
                    UnifiedLog($"Attachment file not found: {fullPath}", "ERROR");
                    return false;
                } // File existence check end

                try // Direct attachment attempt start
                {
                    Attachment attachment = new Attachment(fullPath);
                    message.Attachments.Add(attachment);
                    UnifiedLog($"Attachment added: {fullPath} ({new FileInfo(fullPath).Length} bytes)", "INFO");
                    return true;
                } // Direct attachment attempt end
                catch (IOException ioEx) when (ioEx.Message.Contains("used by another process") || ioEx.Message.Contains("locked") || ioEx.Message.Contains("busy")) // File locked exception handling start
                {
                    UnifiedLog($"File {fullPath} is busy/locked, creating temporary copy...", "INFO");

                    string tempFile = CreateTemporaryCopy(fullPath);
                    if (tempFile != null) // Temporary copy success check start
                    {
                        try // Temporary attachment attempt start
                        {
                            Attachment attachment = new Attachment(tempFile);
                            message.Attachments.Add(attachment);
                            UnifiedLog($"Temporary copy attached: {tempFile} ({new FileInfo(tempFile).Length} bytes)", "INFO");

                            ScheduleTempFileDeletion(tempFile);
                            return true;
                        } // Temporary attachment attempt end
                        catch (Exception ex) // Temporary attachment exception handling start
                        {
                            UnifiedLog($"Failed to attach temporary copy: {ex.Message}", "ERROR");
                            TryDeleteFile(tempFile);
                            return false;
                        } // Temporary attachment exception handling end
                    } // Temporary copy success check end
                    else // Temporary copy failure start
                    {
                        UnifiedLog($"Failed to create temporary copy of {fullPath}", "ERROR");
                        return false;
                    } // Temporary copy failure end
                } // File locked exception handling end
                catch (Exception ex) // General attachment exception handling start
                {
                    UnifiedLog($"Failed to attach file {fullPath}: {ex.Message}", "ERROR");
                    return false;
                } // General attachment exception handling end
            } // Attachment handling end
            catch (Exception ex) // Attachment outer exception handling start
            {
                UnifiedLog($"Error processing attachment {filePath}: {ex.Message}", "ERROR");
                return false;
            } // Attachment outer exception handling end
        }

        private string CreateTemporaryCopy(string originalPath)
        {
            try // Temporary copy creation start
            {
                string tempDir = Path.GetTempPath();
                string fileName = Path.GetFileName(originalPath);
                string tempFile = Path.Combine(tempDir, $"emailer_attach_{Guid.NewGuid()}_{fileName}");

                File.Copy(originalPath, tempFile, true);
                return tempFile;
            } // Temporary copy creation end
            catch (Exception ex) // Temporary copy exception handling start
            {
                UnifiedLog($"Failed to create temporary copy: {ex.Message}", "ERROR");
                return null;
            } // Temporary copy exception handling end
        }

        private void ScheduleTempFileDeletion(string tempFile)
        {
            try // Temp file deletion scheduling start
            {
                Task.Run(async () =>
                {
                    await Task.Delay(5000); // Wait 5 seconds for email to be sent
                    TryDeleteFile(tempFile);
                });
            } // Temp file deletion scheduling end
            catch (Exception ex) // Temp file scheduling exception handling start
            {
                UnifiedLog($"Failed to schedule temp file deletion: {ex.Message}", "DEBUG");
            } // Temp file scheduling exception handling end
        }

        private void TryDeleteFile(string filePath)
        {
            try // File deletion attempt start
            {
                if (File.Exists(filePath)) // File existence check start
                {
                    File.Delete(filePath);
                    UnifiedLog($"Temporary file deleted: {filePath}", "DEBUG");
                } // File existence check end
            } // File deletion attempt end
            catch (Exception ex) // File deletion exception handling start
            {
                UnifiedLog($"Failed to delete temporary file {filePath}: {ex.Message}", "DEBUG");
            } // File deletion exception handling end
        }

        private void ApplyCommandLineOverrides(EmailSettings settings)
        {
            if (!string.IsNullOrEmpty(_cmdServer)) // Server override check start
                settings.SmtpServer = _cmdServer;
            // Server override check end

            if (!string.IsNullOrEmpty(_cmdPort) && int.TryParse(_cmdPort, out int port)) // Port override check start
                settings.SmtpPort = port;
            // Port override check end

            if (!string.IsNullOrEmpty(_cmdUsername)) // Username override check start
                settings.Username = _cmdUsername;
            // Username override check end

            if (!string.IsNullOrEmpty(_cmdPassword)) // Password override check start
                settings.Password = _cmdPassword;
            // Password override check end

            if (!string.IsNullOrEmpty(_cmdFrom)) // From override check start
                settings.FromEmail = _cmdFrom;
            // From override check end

            if (!string.IsNullOrEmpty(_cmdTo)) // To override check start
                settings.ToEmail = _cmdTo;
            // To override check end

            if (!string.IsNullOrEmpty(_cmdSsl)) // SSL override check start
                settings.EnableSSL = ParseBool(_cmdSsl);
            // SSL override check end
        }

        private void ShowWarning(string message)
        {
            try // Warning display start
            {
                ShowConsole();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                Console.ResetColor();
            } // Warning display end
            catch { } // Warning display exception handling
        }

        private void ShowNotification(string message)
        {
            try // Notification display start
            {
                ShowConsole();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                Console.ResetColor();
            } // Notification display end
            catch { } // Notification display exception handling
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
            try // Password reversion start
            {
                var lines = File.ReadAllLines(_iniPath);
                var newLines = new List<string>();
                bool passwordUpdated = false;
                bool encryptionDisabled = false;

                foreach (var line in lines) // INI file lines processing loop start
                {
                    var trimmedLine = line.Trim();
                    var parts = trimmedLine.Split(new[] { '=' }, 2);

                    if (parts.Length == 2) // Valid key-value pair check start
                    {
                        var key = parts[0].Trim().ToLower();
                        var value = parts[1].Trim();

                        if (key == "password") // Password key check start
                        {
                            newLines.Add($"Password = {password}");
                            passwordUpdated = true;
                        } // Password key check end
                        else if (key == "passwordisencrypted") // Encryption flag check start
                        {
                            newLines.Add("PasswordIsEncrypted = False");
                            encryptionDisabled = true;
                        } // Encryption flag check end
                        else // Other keys start
                        {
                            newLines.Add(line);
                        } // Other keys end
                    } // Valid key-value pair check end
                    else // Invalid line start
                    {
                        newLines.Add(line);
                    } // Invalid line end
                } // INI file lines processing loop end

                if (passwordUpdated && encryptionDisabled) // Successful reversion check start
                {
                    File.WriteAllLines(_iniPath, newLines);

                    var newSettings = ReadSettings();
                    return newSettings != null && !IsPasswordEncrypted(newSettings.Password);
                } // Successful reversion check end
                return false;
            } // Password reversion end
            catch (Exception ex) // Password reversion exception handling start
            {
                HandleException("ERROR reverting password to unencrypted", ex);
                return false;
            } // Password reversion exception handling end
        }

        private bool EncryptPasswordInIniFile(string password)
        {
            try // Password encryption in INI start
            {
                var lines = File.ReadAllLines(_iniPath);
                var newLines = new List<string>();
                bool passwordUpdated = false;
                bool encryptionEnabled = false;

                string encryptedPassword = EncryptPassword(password);

                foreach (var line in lines) // INI file lines processing loop start
                {
                    var trimmedLine = line.Trim();
                    var parts = trimmedLine.Split(new[] { '=' }, 2);

                    if (parts.Length == 2) // Valid key-value pair check start
                    {
                        var key = parts[0].Trim().ToLower();
                        var value = parts[1].Trim();

                        if (key == "password") // Password key check start
                        {
                            newLines.Add($"Password = {encryptedPassword}");
                            passwordUpdated = true;
                        } // Password key check end
                        else if (key == "passwordisencrypted") // Encryption flag check start
                        {
                            newLines.Add("
