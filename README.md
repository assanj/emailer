# Emailer - Automatic Email Notifications Application
# Version 1.0

## OVERVIEW

Emailer is an application for automatic email notifications with a hidden interface.
Designed for use in monitoring systems and automated tasks.

Purpose:
- Workstation monitoring
- Task notifications
- System reports
- IT infrastructure integration

## WORKFLOW LOGIC

1. Application launch and console window hiding
2. Reading SMTP settings from Windows Registry
3. Loading email subject from emailer.ini file
4. Collecting system information:
   - Computer name
   - Current user
   - Domain information
   - Timestamp
5. Establishing SSL connection with SMTP server
6. Authentication using credentials
7. Composing and sending email message
8. Logging operation result
9. Automatic application termination

## FEATURES

- SMTP sending with SSL/TLS encryption
- Automatic interface hiding
- Detailed system information collection
- Settings storage in Windows Registry
- Command line parameter support
- Detailed file logging
- Error handling at all stages

## SYSTEM REQUIREMENTS

### Operating Systems:
- Windows 10 / 11 (all editions)
- Windows Server 2016 / 2019 / 2022
- Windows 8.1 / Windows 7 SP1

### Architecture:
- 32-bit (x86) systems
- 64-bit (x64) systems
- AnyCPU architecture support

### Requirements:
- .NET Framework 4.6.1 or higher
- Internet access for SMTP
- Registry and file system write permissions
- Outbound connection permission on port 587

## INSTALLATION

1. Copy Emailer.exe to target folder
2. Run the program to create initial settings
3. Configure SMTP parameters in Windows Registry
4. Configure email subject in emailer.ini file

## CONFIGURATION

### Registry Settings:
Path: HKEY_CURRENT_USER\Software\Emailer

Required parameters:
- Secret - password for SMTP authentication
- Username - account (format: DOMAIN\user)
- SmtpServer - SMTP server address
- SmtpPort - SMTP port (recommended: 587)
- FromEmail - sender email
- ToEmail - recipient email

### Configuration File:
emailer.ini - contains email subject, default: "Subject_demo"

### Settings for Email Services:

Gmail:
SmtpServer: smtp.gmail.com
SmtpPort: 587
Username: your_email@gmail.com
Secret: application password

Yandex:
SmtpServer: smtp.yandex.ru
SmtpPort: 587
Username: your_login
Secret: application password

Mail.ru:
SmtpServer: smtp.mail.ru
SmtpPort: 587
Username: full_email@mail.ru
Secret: application password

## USAGE

### Basic Launch:
Emailer.exe

### Command Line Parameters:
/subject or /s - set email subject
Example: Emailer.exe /subject "System Monitoring"

/debug - enable debug mode
Example: Emailer.exe /debug /subject "Testing"

### Task Scheduler Integration:
Program: C:\Program Files\Emailer\Emailer.exe
Arguments: /subject "Daily Report"

### Typical Usage Scenarios:
- Daily reporting: /subject "Daily System Report"
- Availability monitoring: /subject "Workstation Startup"
- Task notifications: /subject "Task Completed Successfully"
- Emergency alerts: /subject "CRITICAL ERROR"

## LOGGING

The application creates two log files:

emailer.log - successful operations:
2024-01-15 14:30:25 - Email sent: System Monitoring

emailer_error.log - errors and warnings:
2024-01-15 14:29:33 - SMTP authentication error

## TROUBLESHOOTING

### Common Issues:
- "Password not configured in registry" - configure Secret parameter
- "Secure connection required" - check SSL and port
- "Authentication error" - verify credentials
- "Connection timeout" - check SMTP server availability

### Diagnostic Commands:
telnet smtp.server.com 587
reg query "HKEY_CURRENT_USER\Software\Emailer"

## FREQUENTLY ASKED QUESTIONS

Q: Program doesn't send emails, what to check?
A: Error logs, SMTP settings, internet connection, firewall

Q: How to change email subject?
A: Through emailer.ini file or /subject command line parameter

Q: How to verify the program is working?
A: Check emailer.log and emailer_error.log files after launch

Q: Are domain accounts supported?
A: Yes, in DOMAIN\username format

Q: Can it be used in automated scripts?
A: Yes, the program is ideal for task scheduler and scripts



# Emailer - ��������� ��� �������������� �������� email �����������
# ������ 1.0

## �����

Emailer - ���������� ��� �������������� �������� email ����������� �� ������� �����������. 
������������ � �������� ����������� � ������������������ �������.

����������:
- ���������� ������� �������
- ����������� � �������
- ��������� ������
- ���������� � IT-���������������

## ������ ������

1. ������ ���������� � ������� ����������� ����
2. ������ �������� SMTP �� ������� Windows
3. �������� ���� ������ �� ����� emailer.ini
4. ���� ��������� ����������:
   - ��� ����������
   - ������� ������������
   - �������� ����������
   - ��������� �����
5. ��������� SSL ���������� � SMTP ��������
6. �������������� � �������������� ������� ������
7. ������������ � �������� email ���������
8. ����������� ���������� ��������
9. �������������� ���������� ������

## �����������

- �������� ����� SMTP � SSL/TLS �����������
- �������������� ������� ����������
- ���� ��������� ��������� ����������
- �������� �������� � ������� Windows
- ��������� ���������� ��������� ������
- ��������� ����������� � �����
- ��������� ������ �� ���� ������

## ��������� ����������

### ������������ �������:
- Windows 10 / 11 (��� ��������)
- Windows Server 2016 / 2019 / 2022
- Windows 8.1 / Windows 7 SP1

### �����������:
- 32-��� (x86) �������
- 64-��� (x64) �������
- ��������� ����������� AnyCPU

### ����������:
- .NET Framework 4.6.1 ��� ����
- ������ � ��������� ��� SMTP
- ����� �� ������ � ������ � �������� �������
- ���������� �� ��������� ���������� �� ���� 587

## ���������

1. ���������� Emailer.exe � ������� �����
2. ��������� ��������� ��� �������� ��������� ��������
3. ��������� ��������� SMTP � ������� Windows
4. ��������� ���� ������ � ����� emailer.ini

## ������������

### ��������� � �������:
����: HKEY_CURRENT_USER\Software\Emailer

������������ ���������:
- Secret - ������ ��� SMTP ��������������
- Username - ������� ������ (������: DOMAIN\user)
- SmtpServer - ����� SMTP �������
- SmtpPort - ���� SMTP (������������� 587)
- FromEmail - email �����������
- ToEmail - email ����������

### ���� ������������:
emailer.ini - �������� ���� ������, �� ��������� "Subject_demo"

### ��������� ��� �������� ��������:

Gmail:
SmtpServer: smtp.gmail.com
SmtpPort: 587
Username: ���_email@gmail.com
Secret: ������ ����������

Yandex:
SmtpServer: smtp.yandex.ru
SmtpPort: 587
Username: ���_�����
Secret: ������ ����������

Mail.ru:
SmtpServer: smtp.mail.ru
SmtpPort: 587
Username: ������_email@mail.ru
Secret: ������ ����������

## �������������

### ������� ������:
Emailer.exe

### ��������� ��������� ������:
/subject ��� /s - ��������� ���� ������
������: Emailer.exe /subject "���������� �������"

/debug - ��������� ������ �������
������: Emailer.exe /debug /subject "������������"

### ���������� � ������������� �����:
���������: C:\Program Files\Emailer\Emailer.exe
���������: /subject "���������� �����"

### ������� �������� �������������:
- ���������� ����������: /subject "���������� ��������� �����"
- ���������� �����������: /subject "������ ������� �������"
- ����������� � �������: /subject "������ ��������� �������"
- ��������� ����������: /subject "����������� ������"

## �����������

��������� ������� ��� ����� �����:

emailer.log - �������� ��������:
2024-01-15 14:30:25 - ������ ����������: ���������� �������

emailer_error.log - ������ � ��������������:
2024-01-15 14:29:33 - ������ �������������� SMTP

## ���������� ��������������

### ���������������� ��������:
- "������ �� �������� � �������" - ��������� �������� Secret
- "��������� ���������� ����������" - ��������� SSL � ����
- "������ ��������������" - ��������� ������� ������
- "������� ����������" - ��������� ����������� SMTP �������

### ������� �����������:
telnet smtp.server.com 587
reg query "HKEY_CURRENT_USER\Software\Emailer"

## ����� ���������� �������

�: ��������� �� ���������� ������, ��� ���������?
�: ���� ������, ��������� SMTP, ��������-����������, ����������

�: ��� �������� ���� ������?
�: ����� ���� emailer.ini ��� �������� /subject � ��������� ������

�: ��� ���������, ��� ��������� ��������?
�: ��������� ����� emailer.log � emailer_error.log ����� �������

�: �������������� �� �������� ������� ������?
�: ��, � ������� DOMAIN\username

�: ����� �� ������������ � �������������� ���������?
�: ��, ��������� �������� �������� ��� ������������ ����� � ��������