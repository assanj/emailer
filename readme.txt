╔══════════════════════════════════════════════════════════════════════════════╗
║                           EMAILER - SMTP EMAIL SENDER UTILITY                ║
╚══════════════════════════════════════════════════════════════════════════════╝

DESCRIPTION:
Cross-platform utility for sending emails via SMTP with encryption, 
attachments and template variables support.

LINKS:
• Source code & documentation: see promt.md
• Developed with DeepSeek AI
• Signed releases: GitHub verified signature


QUICK START:

1. CONFIGURATION EDITING:
   ▸ Edit emailer.ini with your SMTP settings
   ▸ Run from the same directory:
     emailer --subject "Test" --body "Hello from Emailer"

2. DIRECT USAGE:
   ▸ emailer --server smtp.gmail.ru --port 587 --username myuser --password mypass 
     --from sender@gmail.ru --to recipient@domain.ru --ssl true --debug

COMMAND LINE PARAMETERS

BASIC EMAIL OPTIONS:
• --debug           - Enable debug mode with detailed console output
• --subject TEXT    - Email subject line text
• --body TEXT       - Email body content text
• --attach FILE     - Attach file to email (supports full paths)
• --no-sound        - Disable all sound alerts and beeps

SMTP CONFIGURATION (overrides INI file):
• --server HOST     - SMTP server hostname or IP address
• --port NUMBER     - SMTP server port number (default: 587)
• --username USER   - SMTP authentication username
• --password PASS   - SMTP authentication password
• --from EMAIL      - Sender email address
• --to EMAIL        - Recipient email address (supports multiple: "user1@d.com,user2@d.com")
• --ssl true|false  - Enable/disable SSL encryption

ADVANCED EMAIL FEATURES:
• --cc EMAILS       - Carbon copy recipients (comma-separated)
• --bcc EMAILS      - Blind carbon copy recipients (comma-separated)
• --importance LEVEL - Set email priority: high, normal, or low

UTILITY COMMANDS:
• --encrypt-password PASS - Encrypt password for secure INI storage
• --reset-config   - Reset all configuration files to defaults
• --help, -h, /?   - Display comprehensive help information

TEMPLATE VARIABLES:
Use these variables in subject and body:
• {host}        - Computer hostname
• {user}        - Current username
• {timestamp}   - Full date and time (yyyy-MM-dd HH:mm:ss)
• {time}        - Time only (HH:mm:ss)
• {date}        - Date only (yyyy-MM-dd)

USAGE EXAMPLES

Basic notification:
emailer --subject "System Alert from {host}" --body "User {user} logged in at {timestamp}"

Full SMTP configuration:
emailer --server smtp.gmail.ru --port 587 --username myuser --password mypass --from sender@gmail.ru --to recipient@domain.ru --ssl true

Email with attachment:
emailer --attach "C:\logs\application.log" --subject "Log file from {host}" --body "Generated on {date}"

Multiple recipients:
emailer --to "team@company.ru" --cc "manager@company.ru" --bcc "archive@company.ru" --importance high --subject "Urgent Report"

CONFIGURATION FILE
Edit emailer.ini with your SMTP settings:

[EmailSettings]
Password = yourpassword
PasswordIsEncrypted = False
Username = your_username
SmtpServer = your.smtp.server.ru
SmtpPort = 587
FromEmail = your@email.ru
ToEmail = recipient@email.ru
EnableSSL = True

KEY FEATURES

CORE FUNCTIONALITY:
• SMTP email sending with SSL/TLS support
• INI file configuration with automatic creation
• Command line parameter override capability
• Template variable substitution
• Password encryption/decryption system
• Comprehensive single-file logging

SECURITY FEATURES:
• Base64 password encryption
• Automatic encryption after successful authentication
• Safe logging without password exposure
• Email address format validation
• Automatic password reversion on auth failures

ATTACHMENT HANDLING:
• Cross-platform file attachment support
• Automatic copying of locked/busy files
• Temporary file management and cleanup
• Clear error messages for file access issues

ADVANCED EMAIL CAPABILITIES:
• Multiple recipients with comma separation
• Carbon copy (CC) and blind carbon copy (BCC)
• Email importance/priority levels
• Full email header support

ERROR HANDLING & RELIABILITY:
• File lock detection with ALARM notifications
• Sound alerts for critical errors (Windows)
• Detailed exception handling with stack traces
• Infinite loop prevention mechanisms
• SMTP authentication error recovery

CROSS-PLATFORM SUPPORT:
• Windows, Linux, and macOS compatibility
• Platform-agnostic file operations
• Universal path handling
• Conditional sound implementation

FILE STRUCTURE:
• emailer / emailer.exe - Main executable
• emailer.ini          - Configuration settings
• emailer.log          - Application log file

TROUBLESHOOTING

COMMON ISSUES:
• "Password not configured" - Edit emailer.ini and change default password
• "File locked by another process" - Automatic temporary copy will be created
• SMTP authentication errors - Verify credentials and server settings
• Attachment not found - Use full file paths

DEBUG MODE:
Use --debug flag for detailed operation information and error tracing.

TECHNICAL DETAILS:
• Built with C# .NET 8.0
• Uses System.Net.Mail for SMTP operations
• Base64 encoding for password obfuscation
• ASCII-only output for maximum compatibility
• Self-contained executable, no external dependencies

SUPPORTED PLATFORMS:
┌─────────────────┬─────────────────┬─────────────────┐
│     Windows     │      Linux      │      macOS      │
├─────────────────┼─────────────────┼─────────────────┤
│ • Windows 10    │ • Ubuntu 20.04+ │ • macOS 11+     │
│ • Windows 11    │ • Debian 11+    │ • Intel/Apple   │
│ • Windows Server│ • CentOS 8+     │   Silicon       │
│ • Self-contained│ • Fedora 35+    │ • Self-contained│
│ • No .NET req.  │ • AppImage      │ • No .NET req.  │
└─────────────────┴─────────────────┴─────────────────┘

RELEASE FILES:
• emailer-windows-{version}.zip    - Windows portable
• emailer_*_amd64.deb              - Ubuntu/Debian package
• emailer-*.rpm                    - Fedora/RHEL/CentOS package  
• emailer-*.AppImage               - Universal Linux AppImage
• emailer-macos-{version}.zip      - macOS portable

INSTALLATION:

Windows:
1. Download emailer-windows-*.zip
2. Extract to desired location
3. Edit emailer.ini with your SMTP settings
4. Run emailer.exe from command line

Linux (DEB):
1. sudo dpkg -i emailer_*_amd64.deb
2. Edit /etc/emailer/emailer.ini
3. Run: emailer --subject "Test"

Linux (RPM):
1. sudo rpm -i emailer-*.rpm
2. Configure emailer.ini
3. Use: emailer --help

Linux (AppImage):
1. chmod +x emailer-*.AppImage
2. ./emailer-*.AppImage --subject "Test"

macOS:
1. Download emailer-macos-*.zip
2. Extract and run from Terminal
3. ./emailer --subject "Test"

FOR MORE INFORMATION:
Visit GitHub repository: https://github.com/assanj/emailer
Read promt.md for technical details and development information