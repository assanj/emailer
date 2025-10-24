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


# RUS:

# Emailer - Программа для автоматической отправки email уведомлений
# Версия 1.0

## ОБЗОР

Emailer - приложение для автоматической отправки email уведомлений со скрытым интерфейсом. 
Используется в системах мониторинга и автоматизированных задачах.

Назначение:
- Мониторинг рабочих станций
- Уведомления о задачах
- Системные отчеты
- Интеграция с IT-инфраструктурой

## ЛОГИКА РАБОТЫ

1. Запуск приложения и скрытие консольного окна
2. Чтение настроек SMTP из реестра Windows
3. Загрузка темы письма из файла emailer.ini
4. Сбор системной информации:
   - Имя компьютера
   - Текущий пользователь
   - Доменная информация
   - Временная метка
5. Установка SSL соединения с SMTP сервером
6. Аутентификация с использованием учетных данных
7. Формирование и отправка email сообщения
8. Логирование результата операции
9. Автоматическое завершение работы

## ОСОБЕННОСТИ

- Отправка через SMTP с SSL/TLS шифрованием
- Автоматическое скрытие интерфейса
- Сбор детальной системной информации
- Хранение настроек в реестре Windows
- Поддержка параметров командной строки
- Детальное логирование в файлы
- Обработка ошибок на всех этапах

## СИСТЕМНЫЕ ТРЕБОВАНИЯ

### Операционные системы:
- Windows 10 / 11 (все редакции)
- Windows Server 2016 / 2019 / 2022
- Windows 8.1 / Windows 7 SP1

### Разрядность:
- 32-бит (x86) системы
- 64-бит (x64) системы
- Поддержка архитектуры AnyCPU

### Требования:
- .NET Framework 4.6.1 или выше
- Доступ к интернету для SMTP
- Права на запись в реестр и файловую систему
- Разрешение на исходящие соединения на порт 587

## УСТАНОВКА

1. Скопируйте Emailer.exe в целевую папку
2. Запустите программу для создания начальных настроек
3. Настройте параметры SMTP в реестре Windows
4. Настройте тему письма в файле emailer.ini

## КОНФИГУРАЦИЯ

### Настройки в реестре:
Путь: HKEY_CURRENT_USER\Software\Emailer

Обязательные параметры:
- Secret - пароль для SMTP аутентификации
- Username - учетная запись (формат: DOMAIN\user)
- SmtpServer - адрес SMTP сервера
- SmtpPort - порт SMTP (рекомендуется 587)
- FromEmail - email отправителя
- ToEmail - email получателя

### Файл конфигурации:
emailer.ini - содержит тему письма, по умолчанию "Subject_demo"

### Настройки для почтовых сервисов:

Gmail:
SmtpServer: smtp.gmail.com
SmtpPort: 587
Username: ваш_email@gmail.com
Secret: пароль приложения

Yandex:
SmtpServer: smtp.yandex.ru
SmtpPort: 587
Username: ваш_логин
Secret: пароль приложения

Mail.ru:
SmtpServer: smtp.mail.ru
SmtpPort: 587
Username: полный_email@mail.ru
Secret: пароль приложения

## ИСПОЛЬЗОВАНИЕ

### Базовый запуск:
Emailer.exe

### Параметры командной строки:
/subject или /s - установка темы письма
Пример: Emailer.exe /subject "Мониторинг системы"

/debug - включение режима отладки
Пример: Emailer.exe /debug /subject "Тестирование"

### Интеграция с планировщиком задач:
Программа: C:\Program Files\Emailer\Emailer.exe
Аргументы: /subject "Ежедневный отчет"

### Типовые сценарии использования:
- Ежедневная отчетность: /subject "Ежедневный системный отчет"
- Мониторинг доступности: /subject "Запуск рабочей станции"
- Уведомления о задачах: /subject "Задача выполнена успешно"
- Аварийные оповещения: /subject "КРИТИЧЕСКАЯ ОШИБКА"

## ЛОГИРОВАНИЕ

Программа создает два файла логов:

emailer.log - успешные операции:
2024-01-15 14:30:25 - Письмо отправлено: Мониторинг системы

emailer_error.log - ошибки и предупреждения:
2024-01-15 14:29:33 - Ошибка аутентификации SMTP

## УСТРАНЕНИЕ НЕИСПРАВНОСТЕЙ

### Распространенные проблемы:
- "Пароль не настроен в реестре" - настройте параметр Secret
- "Требуется безопасное соединение" - проверьте SSL и порт
- "Ошибка аутентификации" - проверьте учетные данные
- "Таймаут соединения" - проверьте доступность SMTP сервера

### Команды диагностики:
telnet smtp.server.com 587
reg query "HKEY_CURRENT_USER\Software\Emailer"

## ЧАСТО ЗАДАВАЕМЫЕ ВОПРОСЫ

В: Программа не отправляет письма, что проверить?
О: Логи ошибок, настройки SMTP, интернет-соединение, брандмауэр

В: Как изменить тему письма?
О: Через файл emailer.ini или параметр /subject в командной строке

В: Как убедиться, что программа работает?
О: Проверьте файлы emailer.log и emailer_error.log после запуска

В: Поддерживаются ли доменные учетные записи?
О: Да, в формате DOMAIN\username

В: Можно ли использовать в автоматических сценариях?
О: Да, программа идеально подходит для планировщика задач и скриптов