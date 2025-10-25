Name:           emailer
Version:        1.0.0
Release:        1%{?dist}
Summary:        SMTP Email Sending Utility

License:        MIT
URL:            https://github.com/assanj/emailer
Source0:        %{name}-%{version}.tar.gz

BuildRequires:  dotnet-sdk-8.0
Requires:       dotnet-runtime-8.0

%description
emailer is a cross-platform application for sending emails via SMTP.
Features include SSL/TLS support, file attachments, and comprehensive logging.

%prep
%setup -q

%build
dotnet publish --configuration Release --runtime linux-x64 --self-contained false --output ./publish

%install
# Создаем структуру каталогов
mkdir -p %{buildroot}%{_bindir}
mkdir -p %{buildroot}%{_datadir}/emailer
mkdir -p %{buildroot}%{_datadir}/applications

# Копируем бинарники
cp -r publish/* %{buildroot}%{_datadir}/emailer/

# Создаем скрипт-обертку для запуска
cat > %{buildroot}%{_bindir}/emailer << EOF
#!/bin/bash
exec %{_datadir}/emailer/emailer "\$@"
EOF
chmod +x %{buildroot}%{_bindir}/emailer

# Создаем desktop файл
cat > %{buildroot}%{_datadir}/applications/emailer.desktop << EOF
[Desktop Entry]
Name=Emailer
Comment=SMTP Email Sending Utility
Exec=emailer
Icon=emailer
Terminal=true
Type=Application
Categories=Network;Email;
EOF

%files
%{_bindir}/emailer
%{_datadir}/emailer/
%{_datadir}/applications/emailer.desktop

%doc README.md

%changelog
* Fri Oct 25 2024 Your Name <your-email@example.com> - 1.0.0-1
- Initial package