# Emailer - SMTP Email Sender Utility 
Plz see [promt.md](promt.md), thanx a lot to  <a href="https://chat.deepseek.com" target="_blank" ><img src="https://upload.wikimedia.org/wikipedia/commons/e/ec/DeepSeek_logo.svg" alt="DeepSeek" height="20"></a>  for opensorce & cross-platform

## Release was signed with GitHub’s verified signature [![Latest Release](https://img.shields.io/github/v/release/assanj/emailer?style=for-the-badge&label=Версия)](https://github.com/assanj/emailer/releases/latest)

[![Linux Download](https://img.shields.io/badge/Linux-Download-orange?style=for-the-badge&logo=linux)](https://github.com/assanj/emailer/releases/latest)
[![Windows Download](https://img.shields.io/badge/Windows-Download-blue?style=for-the-badge&logo=windows)](https://github.com/assanj/emailer/releases/latest)
[![macOS Download](https://img.shields.io/badge/macOS-Download-silver?style=for-the-badge&logo=apple)](https://github.com/assanj/emailer/releases/latest)

## QUICK START FOR Debian/Linux/Windows/MacOs:
1. Edit emailer.ini with your SMTP settings and from the same directory: `emailer --subject "Test" --body "Hello from Emailer"`
2. OR easy: `emailer --server smtp.gmail.ru --port 587 --username myuser --password mypass --from sender@gmail.ru --to recipient@domain.ru --ssl true --debug`

## COMMAND LINE PARAMETERS

### Basic Email Options
`--debug` - Enable debug mode with detailed console output  
`--subject TEXT` - Email subject line text  
`--body TEXT` - Email body content text  
`--attach FILE` - Attach file to email (supports full paths)  
`--no-sound` - Disable all sound alerts and beeps

### SMTP Configuration (overrides INI file)
`--server HOST` - SMTP server hostname or IP address  
`--port NUMBER` - SMTP server port number (default: 587)  
`--username USER` - SMTP authentication username  
`--password PASS` - SMTP authentication password  
`--from EMAIL` - Sender email address  
`--to EMAIL` - Recipient email address (supports multiple: "user1@d.com,user2@d.com")  
`--ssl true|false` - Enable/disable SSL encryption

### Advanced Email Features
`--cc EMAILS` - Carbon copy recipients (comma-separated)  
`--bcc EMAILS` - Blind carbon copy recipients (comma-separated)  
`--importance LEVEL` - Set email priority: high, normal, or low

### Utility Commands
`--encrypt-password PASS` - Encrypt password for secure INI storage  
`--reset-config` - Reset all configuration files to defaults  
`--help, -h, /?` - Display comprehensive help information

## TEMPLATE VARIABLES
Use these variables in subject and body:
`{host}` - Computer hostname  
`{user}` - Current username  
`{timestamp}` - Full date and time (yyyy-MM-dd HH:mm:ss)  
`{time}` - Time only (HH:mm:ss)  
`{date}` - Date only (yyyy-MM-dd)

## USAGE EXAMPLES

**Basic notification:**
`emailer --subject "System Alert from {host}" --body "User {user} logged in at {timestamp}"`

**Full SMTP configuration:**
`emailer --server smtp.gmail.ru --port 587 --username myuser --password mypass --from sender@gmail.ru --to recipient@domain.ru --ssl true`

**Email with attachment:**
`emailer --attach "C:\logs\application.log" --subject "Log file from {host}" --body "Generated on {date}"`

**Multiple recipients:**
`emailer --to "team@company.ru" --cc "manager@company.ru" --bcc "archive@company.ru" --importance high --subject "Urgent Report"`

## CONFIGURATION FILE
Edit emailer.ini with your SMTP settings:
Password = yourpassword
PasswordIsEncrypted = False
Username = your_username
SmtpServer = your.smtp.server.ru
SmtpPort = 587
FromEmail = your@email.ru
ToEmail = recipient@email.ru
EnableSSL = True


## KEY FEATURES

### Core Functionality
- SMTP email sending with SSL/TLS support
- INI file configuration with automatic creation
- Command line parameter override capability
- Template variable substitution
- Password encryption/decryption system
- Comprehensive single-file logging

### Security Features
- Base64 password encryption
- Automatic encryption after successful authentication
- Safe logging without password exposure
- Email address format validation
- Automatic password reversion on auth failures

### Attachment Handling
- Cross-platform file attachment support
- Automatic copying of locked/busy files
- Temporary file management and cleanup
- Clear error messages for file access issues

### Advanced Email Capabilities
- Multiple recipients with comma separation
- Carbon copy (CC) and blind carbon copy (BCC)
- Email importance/priority levels
- Full email header support

### Error Handling & Reliability
- File lock detection with ALARM notifications
- Sound alerts for critical errors (Windows)
- Detailed exception handling with stack traces
- Infinite loop prevention mechanisms
- SMTP authentication error recovery

### Cross-Platform Support
- Windows, Linux, and macOS compatibility
- Platform-agnostic file operations
- Universal path handling
- Conditional sound implementation

## FILE STRUCTURE
- `emailer` / `emailer.exe` - Main executable
- `emailer.ini` - Configuration settings
- `emailer.log` - Application log file

## TROUBLESHOOTING

**Common Issues:**
- "Password not configured" - Edit emailer.ini and change default password
- "File locked by another process" - Automatic temporary copy will be created
- SMTP authentication errors - Verify credentials and server settings
- Attachment not found - Use full file paths

**Debug Mode:**
Use `--debug` flag for detailed operation information and error tracing.

## TECHNICAL DETAILS
- Built with C# .NET 8.0
- Uses System.Net.Mail for SMTP operations
- Base64 encoding for password obfuscation
- ASCII-only output for maximum compatibility
- Self-contained executable, no external dependencies


