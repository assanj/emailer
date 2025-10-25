Name:           emailer
Version:        1.0.0
Release:        1%{?dist}
Summary:        SMTP Email Sending Utility

License:        MIT
URL:            https://github.com/assanj/emailer

BuildRequires:  dotnet-sdk-8.0
Requires:       dotnet-runtime-8.0

%description
emailer is a cross-platform application for sending emails via SMTP.
Features include SSL/TLS support, file attachments, and comprehensive logging.

%prep
%setup -q

%build
dotnet publish --configuration Release --runtime linux-x64 --self-contained true --output ./publish

%install
mkdir -p %{buildroot}/usr/bin
mkdir -p %{buildroot}/usr/share/emailer
mkdir -p %{buildroot}/usr/share/applications

cp -r publish/* %{buildroot}/usr/share/emailer/

cat > %{buildroot}/usr/bin/emailer << 'EOF'
#!/bin/bash
exec /usr/share/emailer/emailer "$@"
EOF
chmod +x %{buildroot}/usr/bin/emailer

cat > %{buildroot}/usr/share/applications/emailer.desktop << 'EOF'
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
%defattr(-,root,root,-)
/usr/bin/emailer
/usr/share/emailer/
/usr/share/applications/emailer.desktop

%changelog
* Fri Oct 25 2024 Your Name <your-email@example.com> - 1.0.0-1
- Initial package
