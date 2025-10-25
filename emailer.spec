Name:           emailer
Version:        1.0.0
Release:        1
Summary:        SMTP Email Sending Utility

License:        MIT
URL:            https://github.com/assanj/emailer

%description
emailer is a cross-platform application for sending emails via SMTP.
Features include SSL/TLS support, file attachments, and comprehensive logging.

%prep

%build

%install
mkdir -p %{buildroot}/usr/bin
mkdir -p %{buildroot}/usr/share/emailer
mkdir -p %{buildroot}/usr/share/applications

# Copy files from build directory
cp -r %{_builddir}/* %{buildroot}/usr/share/emailer/ 2>/dev/null || :

# Create launcher script
cat > %{buildroot}/usr/bin/emailer << 'EOF'
#!/bin/bash
exec /usr/share/emailer/emailer "$@"
EOF
chmod +x %{buildroot}/usr/bin/emailer

# Create desktop file
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
/usr/bin/emailer
/usr/share/emailer/
/usr/share/applications/emailer.desktop

%changelog
* Fri Oct 25 2024 Your Name <your-email@example.com> - 1.0.0-1
- Initial package
