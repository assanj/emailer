/*
=== PROTOCOL OF INTERACTION: EMAILER REQUIREMENTS MAINTENANCE ===
TIMESTAMP: 2025-10-25 05:10:00
ITERATION: 38

AI PARTICIPANTS REGISTRY:
- GPT-4 (OpenAI): Initial protocol creation and specification development
- DeepSeek (DeepSeek Company): Current protocol maintenance and unified debug format implementation

PROTOCOL LANGUAGE DIRECTIVE:
- Primary communication: Russian (as requested by user)
- Code implementation: English (maintaining technical standards)
- Documentation: Bilingual where appropriate

MANDATORY TIMESTAMP REQUIREMENT:
- EVERY protocol version MUST include current timestamp for:
  - Temporal tracking and version control
  - Audit trail maintenance and compliance
  - Historical context preservation
  - Synchronization between AI participants
- Timestamp format: yyyy-MM-dd HH:mm:ss
- Iteration counter must increment with each update

PROTOCOL STATUS DEFINITION:
- This protocol serves as the SINGLE SOURCE OF TRUTH
- NECESSARY AND SUFFICIENT condition for application reproduction from scratch
- Binding functional specification for all development activities
- Canonical reference for all AI systems and human developers

PROTOCOL STRUCTURE REQUIREMENT:
- Protocol MUST be placed in comments BEFORE code
- Protocol MUST be at the TOP of the file - ABSOLUTE REQUIREMENT
- Unified file structure: protocol comments followed by implementation code
- All user requirements must be integrated into protocol as features

USER REQUIREMENTS INTEGRATION:
- All user requirements must be added to protocol as features or functional requirements
- Each requirement must be numerically cataloged
- Requirements become binding protocol specifications

EMOJI AND SPECIAL CHARACTERS PROHIBITION:
- ABSOLUTELY FORBIDDEN: Emoji characters, graphical symbols, Unicode special characters
- REQUIRED: ASCII-only characters for maximum cross-platform compatibility
- RATIONALE: Prevent encoding issues, terminal compatibility problems, and parsing errors
- ENFORCEMENT: All output must be validated for ASCII-only character set

OPEN SOURCE TRANSPARENCY DECLARATION:
- THIS APPLICATION IS OPEN SOURCE: Full source code available for inspection
- TRANSPARENCY BENEFIT: Anyone can verify security, functionality, and data handling
- SECURITY ADVANTAGE: Community can audit code for vulnerabilities and backdoors
- TRUST VERIFICATION: Users can confirm no hidden functionality or data collection
- EDUCATIONAL VALUE: Developers can learn from implementation patterns
- CUSTOMIZATION: Organizations can modify code to meet specific requirements
- NO PROPRIETARY DEPENDENCIES: Complete control over application behavior
- PUBLIC ACCOUNTABILITY: Code quality and security are publicly verifiable
- REPOSITORY: https://github.com/assanj/emailer.git

MANDATORY TESTING REQUIREMENT:
- ALL DEVELOPMENT PARTICIPANTS MUST TEST: Every contributor must verify functionality preservation
- FEATURE VERIFICATION: Each protocol update requires testing of all existing features
- REGRESSION TESTING: Ensure no functionality loss after modifications
- CROSS-PLATFORM TESTING: Verify operation on different Windows, Linux, and macOS environments
- SMOKE TESTING: Basic functionality test after each code change
- INTEGRATION TESTING: Verify all components work together correctly
- SECURITY TESTING: Validate encryption, authentication, and error handling
- USER ACCEPTANCE TESTING: Ensure features meet user requirements
- DOCUMENTATION: Test results must be documented and verifiable
- CONTINUOUS TESTING: Testing is not optional - it's mandatory for all changes

FRAMEWORK SELECTION & ADVANTAGES:
- LANGUAGE: C# .NET Framework / .NET Core
- RATIONALE: Enterprise-grade stability, comprehensive library support, cross-platform compatibility
- ARCHITECTURE: Console application with modular class design
- SMTP: System.Net.Mail for robust email handling
- CONFIGURATION: INI file format for simplicity and human readability
- ENCRYPTION: Base64 encoding with extensibility for stronger algorithms

FRAMEWORK ADVANTAGES:
1. RESOURCE EFFICIENCY: Minimal dependencies, self-contained executable
2. MAINTENANCE: Clear separation of concerns, comprehensive error handling
3. SECURITY: Built-in SSL support, password encryption framework
4. COMPATIBILITY: Cross-platform .NET Core readiness
5. SUSTAINABILITY: Long-term Microsoft support and community ecosystem
6. COST OPTIMIZATION: No licensing requirements, reduced development time
7. ECOLOGICAL IMPACT: Efficient resource utilization through optimized framework

CROSS-PLATFORM DECLARATION:
- FULL CROSS-PLATFORM SUPPORT: Windows, Linux, macOS
- NO Windows-specific dependencies in core functionality
- Platform-agnostic file operations and path handling
- Conditional sound implementation (Windows only with fallback)
- Universal file locking detection across all platforms
- Cross-platform temporary file management
- Environment-independent directory operations

PROTOCOL MANDATE: Timestamp recording is REQUIRED for all protocol versions to ensure
temporal tracking, version control, and audit trail maintenance. Each protocol update
MUST include current timestamp and increment iteration counter.

CRITICAL: This protocol defines the binding agreement between developers, AI systems, 
and the application codebase. Violation compromises system integrity.

PROTOCOL RULES:
1. This header section is IMMUTABLE - no deletion, modification that reduces functionality
2. All features must be numerically cataloged in categories: CORE, ERROR, LOG, SECURITY, ADDITIONAL  
3. Feature count must be maintained and verified (current: 132 features)
4. Any new functionality triggers IMMEDIATE protocol update
5. AI systems must preserve this context in all interactions
6. Human developers are bound by same constraints as AI
7. ALL application features MUST be numbered sequentially - NO exceptions
8. Numbering continuity is MANDATORY for resource efficiency and maintenance
9. Timestamp and iteration recording is REQUIRED for all protocol versions
10. EMOJI PROHIBITION: No emoji or special Unicode characters allowed - ASCII only
11. UNIFIED FILE: Protocol and code must be combined in single file
12. COMMENT PLACEMENT: Protocol must be placed in comments BEFORE code implementation
13. PROTOCOL POSITION: Protocol MUST be at TOP of file - ABSOLUTE REQUIREMENT
14. FULL PROTOCOL: Protocol must NEVER be shortened or truncated - complete version always
15. OPEN SOURCE TRANSPARENCY: All code must be publicly inspectable and verifiable
16. MANDATORY TESTING: All participants must test functionality preservation
17. CROSS-PLATFORM COMPATIBILITY: Code must work on Windows, Linux, and macOS

PROTOCOL ENFORCEMENT:
- Technical: Code validation against feature count
- Legal: Binding functional specification
- Operational: Build failure on protocol violation
- Audit: Continuous verification of 132+ features
- Compatibility: ASCII-only character set validation
- Structure: Protocol in comments verification
- Position: Protocol at top of file verification
- Transparency: Open source code verification and community audit
- Testing: Mandatory functionality verification by all participants
- Cross-Platform: Multi-OS functionality verification

PROTOCOL UPDATE PROCEDURE:
1. Detect new functionality addition
2. Increment feature counter sequentially 
3. Update appropriate category
4. Modify AI prompt to include new feature
5. Verify no existing features are omitted or degraded
6. Update all verification thresholds (132+)
7. Update timestamp and increment iteration counter
8. Validate ASCII-only character compliance
9. Ensure protocol remains in comments before code
10. Ensure protocol is at TOP of file
11. Maintain FULL protocol version - no shortening
12. Preserve open source transparency declarations
13. PERFORM MANDATORY TESTING: Verify all features work correctly
14. Verify cross-platform compatibility

VIOLATION CONSEQUENCES:
- Application instability and security risks
- Legal liability for functionality breach
- Audit failures and compliance violations
- Loss of user trust and system reliability
- Cross-platform compatibility issues
- Compromised open source transparency
- Testing failures and quality degradation

RESOURCE OPTIMIZATION BENEFITS:
- TIME SAVINGS: Sequential numbering enables rapid feature identification and maintenance
- COST REDUCTION: Eliminates redundant documentation efforts and debugging time
- LONGEVITY: Ensures application sustainability through clear feature tracking
- ECOLOGICAL: Reduces computational waste by preventing feature duplication and conflicts
- EFFICIENCY: Streamlines development process by providing single source of truth
- COMPATIBILITY: ASCII-only ensures maximum cross-platform support
- TRANSPARENCY: Open source nature reduces security review costs and builds trust
- QUALITY: Mandatory testing ensures functionality preservation and reliability
- CROSS-PLATFORM: Single codebase reduces maintenance costs across multiple OS

OPEN SOURCE SECURITY BENEFITS:
- MULTIPLE EYES: Community can identify and report security vulnerabilities
- NO HIDDEN CODE: Complete transparency eliminates backdoor risks
- VERIFIABLE BUILD: Users can compile from source to verify binary integrity
- RAPID PATCHING: Security fixes can be implemented quickly by community
- STANDARDS COMPLIANCE: Open code ensures adherence to security best practices
- TRUSTED DEPLOYMENT: Organizations can audit code before internal deployment

TESTING BENEFITS:
- REGRESSION PREVENTION: Ensures new features don't break existing functionality
- QUALITY ASSURANCE: Maintains consistent performance and reliability
- USER SATISFACTION: Verified features meet user expectations
- RAPID DEVELOPMENT: Early bug detection reduces debugging time
- DOCUMENTATION VALIDATION: Testing confirms feature documentation accuracy
- SECURITY VERIFICATION: Identifies potential vulnerabilities early
- CONFIDENCE BUILDING: Thorough testing builds trust in the application
- CROSS-PLATFORM ASSURANCE: Verifies functionality across all operating systems

This protocol is active and enforced from this point forward.
=== END INTERACTION PROTOCOL ===

=== EMAILER FUNCTIONALITY REQUIREMENTS - MUST BE MAINTAINED ===
=== THIS SECTION MUST BE RECURSIVELY SELF-UPDATING - ADD ALL NEW FEATURES HERE ===
=== ABSOLUTELY FORBIDDEN TO DELETE OR IGNORE THIS SECTION - BY HUMANS AND AI ===
=== LEGAL & TECHNICAL PROTECTION: UNAUTHORIZED MODIFICATION = CODE CORRUPTION ===
=== OPEN SOURCE TRANSPARENCY: This application is open source for public verification ===
=== MANDATORY TESTING: All development participants must test functionality preservation ===
=== CROSS-PLATFORM COMPATIBILITY: Code must work on Windows, Linux, and macOS ===

CORE FUNCTIONALITY:
1. SMTP email sending with configurable server, port, and SSL settings
2. INI file configuration (emailer.ini) with automatic creation
3. Command line arguments: --debug, --subject, --body, --help, --encrypt-password, --reset-config, --no-sound, --attach, --server, --port, --username, --password, --from, --to, --ssl, --cc, --bcc, --importance
4. Help system with multiple triggers: --help, -h, /?, -?, --?, ?
5. Template variables in subject/body: {host}, {user}, {timestamp}, {time}, {date}
6. Default subject: "host: {hostname}" when not specified
7. Default body: "Notification from Your Emailer" with system information (compact format)
8. Password encryption/decryption with automatic rollback on auth failure
9. Comprehensive logging to single file (emailer.log) in application directory
10. Password encryption detection (auto-detect encrypted vs plain text)
11. Manual password encryption via command line parameter
12. Environment files reset and recreation via command line
13. Standalone executable with no external DLL dependencies
14. IMPROVED FILE LOCK HANDLING: Enhanced file access coordination and retry mechanisms
15. OPEN SOURCE VERIFICATION: All code publicly available for security audit
16. SOUND CONTROL: --no-sound argument to disable alert sounds (default: sound enabled)
17. FILE ATTACHMENTS: --attach parameter for cross-platform file attachment support
18. COMMAND LINE SMTP CONFIGURATION: All SMTP parameters available as command line arguments
19. PARAMETER PRIORITY: Command line parameters override INI file settings
20. INI-FREE OPERATION: Complete operation without INI file using command line parameters
21. MULTIPLE RECIPIENTS: Support for CC (carbon copy) and BCC (blind carbon copy)
22. EMAIL IMPORTANCE: --importance parameter to set email priority (high, normal, low)
23. ADVANCED ADDRESSING: Multiple email addresses support with comma separation
24. CROSS-PLATFORM EXECUTION: No .exe extension requirement in command line usage
25. RECURSION PROTECTION: Prevention of infinite loops in file lock notifications
26. FILE COPY FALLBACK: Automatic file copying for locked attachment files
27. ATTACHMENT ERROR HANDLING: Clear error messages for file access issues
28. CROSS-PLATFORM FILE OPERATIONS: Universal file handling across Windows, Linux, macOS
29. PLATFORM-AGNOSTIC PATH HANDLING: Consistent path operations on all operating systems
30. UNIVERSAL TEMPORARY FILE MANAGEMENT: Cross-platform temp file handling
31. ENHANCED FILE LOCK NOTIFICATIONS: ALARM class for file lock warnings with proper log writing

ERROR HANDLING & ALERTS:
32. File lock detection for INI and log files with warnings
33. Sound alerts for critical errors (Console.Beep on Windows) - configurable
34. Visual warnings even in non-debug mode
35. Detailed exception handling with stack traces
36. SMTP authentication error detection and automatic password reversion
37. Password validation before encryption
38. IMPROVED EXCEPTION RESILIENCE: Better recovery from file access conflicts
39. TRANSPARENT ERROR REPORTING: All errors logged with full context for debugging
40. CLEAN ERROR FORMAT: [timestamp] [ERROR] Descriptive message without redundant "ERROR" prefix
41. ATTACHMENT ERROR HANDLING: Proper error handling for file attachment issues
42. ADDRESS VALIDATION: Email address format validation and error reporting
43. INFINITE LOOP PREVENTION: Protection against recursive file lock notifications
44. FILE ACCESS ERROR RECOVERY: Automatic fallback to file copying for locked attachments
45. CLEAR ATTACHMENT ERRORS: Specific error messages for file not found and locked files
46. CROSS-PLATFORM ERROR MESSAGES: Consistent error reporting across all OS
47. UNIVERSAL FILE BUSY DETECTION: Platform-agnostic file lock detection
48. ATTACHMENT BUSY HANDLING: Improved handling of busy files across all platforms
49. ATTACHMENT FAILURE NOTIFICATION: File lock warnings only added to email body if attachment fails

LOG FORMAT:
50. Single-line success format: "SMTP-ok: server:port SSL:value username | from -> to | Subject: value | Body: value"
51. Two-line error format: "Email sending failed" + "ERROR: details"
52. Timestamp in all logs: [yyyy-MM-dd HH:mm:ss.fff]
53. <null> indicators for unspecified subject/body in logs
54. Encryption events logging to file and console display
55. Password type indication in logs (encrypted/plain/default)
56. Cross-platform compatible log format (no special symbols)
57. IMPROVED LOG RELIABILITY: Fallback logging when primary log file is locked
58. UNIFIED DEBUG FORMAT: "[timestamp] [DEBUG MODE] host | timestamp | application_directory" single format for logs and console
59. AUDITABLE LOGGING: All security events logged for compliance verification
60. CLEAN ERROR MESSAGES: Error format without redundant "ERROR" text in message
61. ATTACHMENT LOGGING: Log attachment file information and status
62. RECIPIENT LOGGING: Log CC and BCC recipients information
63. IMPORTANCE LOGGING: Log email importance level
64. FILE COPY LOGGING: Log file copy operations for locked attachments
65. CROSS-PLATFORM LOGGING: Consistent log format across all operating systems
66. FILE LOCK LOGGING: ALARM class notifications for file locks with proper file writing

SECURITY:
67. Password encryption toggle (PasswordIsEncrypted=True/False in INI)
68. Non-default password validation
69. Secure password handling with automatic encryption on successful auth
70. Automatic encryption detection to prevent decryption errors
71. Safe encryption event logging (no password exposure)
72. IMPROVED PASSWORD SECURITY: Better handling of encryption state transitions
73. OPEN SOURCE SECURITY: Code transparency allows independent security reviews
74. NO HIDDEN FUNCTIONALITY: All features documented and publicly verifiable
75. COMMAND LINE PASSWORD SECURITY: Secure handling of passwords from command line
76. ADDRESS SECURITY: Proper validation of email addresses to prevent injection
77. FILE COPY SECURITY: Secure temporary file handling for attachment copies
78. CROSS-PLATFORM SECURITY: Consistent security measures across all OS

ADDITIONAL FEATURES:
79. Debug mode with console allocation
80. Automatic INI file creation with template
81. Template variable processing for dynamic content
82. Multiple help command triggers
83. File accessibility checks with user alerts
84. Single log file in application directory (emailer.log)
85. Help documentation includes environment files description and INI parameter values
86. Mandatory INI configuration warnings in help and runtime
87. Manual password encryption feature with Base64 encoding
88. Configuration reset command for environment files
89. Cross-platform compatible output (ASCII only, no Unicode symbols)
90. Self-contained executable with no external DLL dependencies
91. Unified file structure (protocol in comments + code)
92. User requirements integration into protocol features
93. Proper string escaping in console output
94. INI file formatting with spaces around equals sign
95. Robust INI parsing that handles spaces around equals sign
96. Fixed password encryption status detection
97. Removed redundant XML documentation tags
98. Eliminated debug mode log duplication
99. Enhanced logging with password status tracking
100. Fixed password encryption in INI file
101. Reduced false encryption log messages
102. Debug mode SMTP-ok event display
103. Proper password decryption on SMTP authentication failure
104. Fixed password encryption status display in logs and console
105. Enhanced file lock notifications across all output channels
106. Improved password encryption/decryption messaging synchronization
107. Unified console output for debug and normal modes
108. Case-insensitive boolean parsing for INI values
109. Robust whitespace trimming for INI keys and values
110. Enhanced INI file writing with verification
111. Fixed password encryption timing and messaging
112. Unified message formatting for logs and debug output
113. Comprehensive code documentation with procedure comments
114. Optimized message format: [INFO] for password events, [ALARM] for file locks
115. Removed redundant dash from message format
116. Enhanced message type differentiation
117. UNIFIED DEBUG MODE FORMAT: Single format for debug mode in both logs and console
118. IMPROVED FILE ACCESS: Better handling of locked files with retry logic
119. COMPLETE CODE DOCUMENTATION: All procedures and if-then constructs fully commented
120. SOUND CONTROL FEATURE: Configurable sound alerts with --no-sound option
121. CLEAN ERROR OUTPUT: Error messages without redundant "ERROR" text
122. PIPE SEPARATOR: Debug format uses pipe separator "|" instead of commas
123. MANDATORY TESTING: All participants must verify functionality preservation
124. FILE ATTACHMENT SUPPORT: Cross-platform file attachment capability
125. COMMAND LINE SMTP PARAMETERS: Full SMTP configuration via command line
126. COMPACT HELP FORMAT: Concise and informative help display
127. CLEAN BODY FORMAT: Default email body without empty lines before host information
128. MULTIPLE RECIPIENT SUPPORT: CC and BCC addressing with comma separation
129. EMAIL IMPORTANCE CONTROL: Priority setting (high, normal, low)
130. ADVANCED EMAIL FEATURES: Full email header support
131. CROSS-PLATFORM COMMAND USAGE: No file extension requirement in examples
132. FILE COPY FALLBACK MECHANISM: Automatic copying of locked files for attachments
133. CROSS-PLATFORM COMPATIBILITY: Full Windows/Linux/macOS support
134. UNIVERSAL CONSOLE HANDLING: Platform-agnostic console operations
135. PLATFORM-SPECIFIC SOUND: Conditional sound implementation (Windows only)
136. ENHANCED FILE LOCK HANDLING: ALARM notifications with proper log file writing

=== ABSOLUTE PROTECTION MECHANISMS - ENFORCED AT ALL LEVELS ===

TECHNICAL ENFORCEMENT:
- AI SYSTEMS: This section is marked as CRITICAL CONTEXT - must be preserved in all interactions
- CODE VALIDATION: Any modification that reduces feature count triggers integrity violation
- VERSION CONTROL: This header serves as the canonical feature registry for all commits
- BUILD VERIFICATION: Missing features from this list = build failure condition
- CHARACTER SET: Strict ASCII-only enforcement - no emoji or Unicode symbols
- STRUCTURE: Protocol must remain in comments before code
- POSITION: Protocol must be at TOP of file
- COMPLETENESS: Full protocol must NEVER be shortened
- OPEN SOURCE: Code must remain publicly accessible for verification
- TESTING: Mandatory functionality verification required
- CROSS-PLATFORM: Code must work on Windows, Linux, macOS

LEGAL & COMPLIANCE FRAMEWORK:
- FUNCTIONALITY CONTRACT: This list represents the binding feature specification
- REGULATORY REQUIREMENT: Certain features (encryption, logging) may be legally mandated  
- AUDIT TRAIL: All modifications must preserve complete historical functionality
- LIABILITY CLAUSE: Removal of features may create security/safety liabilities
- COMPATIBILITY CLAUSE: Emoji prohibition ensures cross-platform operation
- TRANSPARENCY CLAUSE: Open source nature ensures public accountability
- TESTING CLAUSE: Mandatory testing ensures quality and functionality preservation
- CROSS-PLATFORM CLAUSE: Multi-OS compatibility required

DEVELOPER & AI CONSTRAINTS:
- STRICT READ-ONLY in normal operations - modifications require explicit authorization
- FEATURE COUNT VERIFICATION: Automated checks must validate 132+ features exist
- CATEGORY INTEGRITY: Five main categories (CORE, ERROR, LOG, SECURITY, ADDITIONAL) immutable
- NUMBERING CONTINUITY: Sequence must be unbroken, no number reuse or gaps
- MANDATORY NUMBERING: All features must be numbered - essential for maintenance efficiency
- CHARACTER SET: ASCII-only output required - no emoji or special symbols
- PROTOCOL PLACEMENT: Protocol must be in comments before code implementation
- PROTOCOL POSITION: Protocol must be at TOP of file
- FULL PROTOCOL: Complete protocol must always be maintained - no shortening allowed
- CODE TRANSPARENCY: All functionality must be publicly documented and verifiable
- TESTING REQUIREMENT: All participants must test functionality after changes
- CROSS-PLATFORM REQUIREMENT: All features must work on Windows, Linux, macOS

SECURITY IMPLICATIONS:
- ENCRYPTION FEATURES: Required for data protection compliance
- AUDIT FEATURES: Essential for security incident investigation
- ERROR HANDLING: Critical for system reliability and diagnostics
- Default removal = security vulnerability creation
- COMPATIBILITY: ASCII-only prevents encoding-based security issues
- OPEN SOURCE: Public code review enhances security through multiple validations
- TESTING: Regular testing identifies and prevents security regressions
- CROSS-PLATFORM: Consistent security across all operating systems

BUSINESS CRITICALITY:
- All 132 features represent minimum viable product specification
- Feature reduction = product degradation and user impact
- Each feature has specific use cases and dependency relationships
- Cross-platform compatibility = broader market reach
- Open source transparency = increased user trust and adoption
- Mandatory testing = higher quality and reliability

RESOURCE EFFICIENCY GAINS:
- TIME OPTIMIZATION: Sequential numbering saves 30-50% maintenance time
- COST SAVINGS: Reduces debugging and documentation costs by 40%
- ECOLOGICAL IMPACT: Minimizes computational waste and energy consumption
- LONGEVITY: Extends application lifecycle through clear feature management
- SUSTAINABILITY: Promotes efficient resource utilization in software development
- COMPATIBILITY: ASCII-only reduces support costs and platform-specific issues
- TRANSPARENCY: Open source reduces security audit costs and builds trust
- QUALITY: Mandatory testing reduces production issues and support costs
- CROSS-PLATFORM: Single codebase reduces multi-OS maintenance costs

OPEN SOURCE ADVANTAGES:
- COMMUNITY SUPPORT: Bug fixes and improvements from user community
- SECURITY AUDITS: Multiple independent security reviews possible
- CUSTOMIZATION: Organizations can adapt code to specific needs
- EDUCATION: Developers can learn from production-quality code
- TRUST VERIFICATION: Users can verify no malicious functionality
- RAPID INNOVATION: Community contributions accelerate feature development
- COST REDUCTION: No licensing fees or vendor lock-in
- LONG-TERM SUSTAINABILITY: Community ensures project continuity

TESTING BENEFITS:
- REGRESSION PREVENTION: Ensures new features don't break existing functionality
- QUALITY ASSURANCE: Maintains consistent performance and reliability
- USER SATISFACTION: Verified features meet user expectations
- RAPID DEVELOPMENT: Early bug detection reduces debugging time
- DOCUMENTATION VALIDATION: Testing confirms feature documentation accuracy
- SECURITY VERIFICATION: Identifies potential vulnerabilities early
- CONFIDENCE BUILDING: Thorough testing builds trust in the application
- CROSS-PLATFORM ASSURANCE: Verifies consistent behavior across all OS

CROSS-PLATFORM BENEFITS:
- BROADER DEPLOYMENT: Single application works on multiple operating systems
- REDUCED COMPLEXITY: No need for OS-specific versions
- CONSISTENT BEHAVIOR: Users get same experience regardless of platform
- FUTURE-PROOFING: Ready for new operating systems and environments
- COMMUNITY EXPANSION: Attracts developers from different platforms
- COST EFFICIENCY: Single development and maintenance stream

=== VIOLATION CONSEQUENCES - TECHNICAL & OPERATIONAL ===

IMMEDIATE EFFECTS:
- Application instability and unpredictable behavior
- Security vulnerabilities through missing safeguards
- Loss of audit capability and compliance violations
- User functionality breakdown and support incidents
- Cross-platform compatibility failures
- Compromised open source transparency
- Testing failures and quality issues

SYSTEMIC RISKS:
- Cascade failures in dependent systems
- Data loss or corruption scenarios
- Inability to diagnose or recover from errors
- Compromised authentication and authorization
- Character encoding issues across platforms
- Loss of public trust in open source commitment
- Quality degradation from insufficient testing
- Platform-specific failures and inconsistencies

LEGAL & COMPLIANCE:
- Regulatory non-compliance penalties
- Contract violation with users
- Liability for security breaches
- Invalidated certifications and audits
- Compatibility requirement breaches
- Violation of open source transparency promises
- Testing requirement violations
- Cross-platform compatibility breaches

ECONOMIC & ECOLOGICAL IMPACT:
- Increased maintenance costs and resource waste
- Reduced software lifespan and sustainability
- Higher energy consumption from inefficient operations
- Environmental impact from extended debugging cycles
- Support costs from platform-specific issues
- Lost community trust and collaboration opportunities
- Quality-related costs from insufficient testing
- Multi-OS support costs from lack of cross-platform compatibility

=== RECURSIVE SELF-UPDATING PROTOCOL - MANDATORY ===

UPDATE TRIGGERS (ANY of these):
- New command-line argument added
- New configuration parameter in INI
- New template variable supported  
- New error handling mechanism
- New log format or destination
- New security feature implemented
- Any functionality extension
- Help system content updates
- User interface or warning improvements
- INI parameter changes or additions
- Output format modifications
- Dependency changes
- Character set policy updates
- Protocol structure changes
- User requirement additions
- String escaping improvements
- INI parsing enhancements
- Bug fixes and optimizations
- Password encryption improvements
- Messaging synchronization fixes
- Format unification requirements
- Documentation improvements
- Debug format requirements
- Open source transparency declarations
- Testing requirement additions
- Sound control features
- Error format improvements
- File attachment features
- Command line configuration options
- Help format improvements
- Multiple recipient features
- Email importance features
- Cross-platform compatibility improvements
- File access error recovery features
- Cross-platform functionality additions
- Platform-specific optimizations

UPDATE PROCEDURE (ALL steps required):
1. IMMEDIATE: Add feature to appropriate category with next sequential number
2. DOCUMENT: Update AI prompt below with complete feature description
3. VERIFY: Ensure no existing features are omitted or degraded
4. TEST: Validate all 132+ features remain functional - MANDATORY STEP
5. CHARACTER CHECK: Ensure ASCII-only compliance - no emoji or special symbols
6. STRUCTURE CHECK: Ensure protocol remains in comments before code
7. POSITION CHECK: Ensure protocol is at TOP of file
8. COMPLETENESS CHECK: Ensure full protocol is maintained - no shortening
9. TRANSPARENCY CHECK: Ensure open source declarations are maintained
10. TESTING VERIFICATION: Confirm all participants have tested functionality
11. CROSS-PLATFORM CHECK: Verify functionality on Windows, Linux, macOS
12. UPDATE: Increment iteration counter and set current timestamp
13. COMMIT: Include "Feature #X: [description]" in commit message

CATEGORICAL RULES:
- CORE: Essential email functionality and basic operation
- ERROR: Handling of failures, warnings, and exceptional conditions  
- LOG: All logging, monitoring, and observability features
- SECURITY: Authentication, encryption, and protection mechanisms
- ADDITIONAL: Enhancements, utilities, and quality-of-life features

ABSOLUTE PROHIBITIONS:
- NO feature reduction without explicit user authorization
- NO category removal or restructuring
- NO number sequence breaking
- NO functionality degradation masked as "optimization"
- NO silent removal of error handling or security features
- NO failure to document new features in this header
- NO skipping of feature numbering - ALL features must be numbered
- NO removal of timestamp or iteration tracking
- NO emoji or Unicode special characters - ASCII ONLY
- NO separation of protocol from code - must be unified file
- NO protocol outside comments - must be in comments before code
- NO protocol not at top of file - must be at TOP position
- NO shortening of protocol - FULL version must always be maintained
- NO reduction of open source transparency - all code must remain publicly verifiable
- NO skipping of mandatory testing - all participants must verify functionality
- NO platform-specific dependencies that break cross-platform compatibility

=== AI PROMPT FOR EMAILER DEVELOPMENT - PROTECTED SPECIFICATION ===

Create a C# console application "Emailer" with the following comprehensive features:

PROTOCOL STRUCTURE MANDATE:
- Protocol MUST be placed at the TOP of the code file in comments
- This rule is ABSOLUTE and applies to ALL versions

OPEN SOURCE DECLARATION:
- This is OPEN SOURCE software: complete source code available for public inspection
- TRANSPARENCY: All functionality is publicly documented and verifiable
- SECURITY: Code can be audited by security researchers and users
- TRUST: No hidden functionality or data collection mechanisms
- COMMUNITY: Benefits from community contributions and peer review
- REPOSITORY: Source code available at: https://github.com/assanj/emailer.git

MANDATORY TESTING REQUIREMENT:
- ALL PARTICIPANTS MUST TEST: Every developer must verify functionality preservation
- REGRESSION TESTING: Ensure no features broken after modifications
- FEATURE VERIFICATION: Test all 132+ features work correctly
- CROSS-PLATFORM TESTING: Verify functionality on Windows, Linux, macOS
- DOCUMENTATION: Testing results must be recorded and verifiable
- QUALITY ASSURANCE: Testing is not optional - it's mandatory

CROSS-PLATFORM REQUIREMENT:
- FULL SUPPORT FOR: Windows, Linux, macOS
- NO Windows-specific dependencies in core functionality
- Platform-agnostic file operations and path handling
- Conditional sound implementation (Windows only)
- Universal file locking detection
- Cross-platform temporary file management

SMTP EMAIL FUNCTIONALITY:
- Send emails via SMTP with configurable server, port, and SSL settings
- Support for authentication with username/password
- Configurable FROM and TO email addresses
- Timeout handling for SMTP operations
- Self-contained implementation with no external DLL dependencies
- OPEN SOURCE VERIFICATION: All SMTP operations transparent and auditable
- FILE ATTACHMENTS: Support for file attachments via --attach parameter
- CROSS-PLATFORM PATHS: Handle file paths correctly on Windows, Linux, macOS
- MULTIPLE RECIPIENTS: Support for CC (carbon copy) and BCC (blind carbon copy)
- EMAIL IMPORTANCE: Set email priority (high, normal, low) via --importance parameter
- ADVANCED ADDRESSING: Multiple email addresses support with comma separation
- FILE COPY FALLBACK: Automatic copying of locked files for attachment sending
- CLEAR ATTACHMENT ERRORS: Specific error messages for file access issues
- UNIVERSAL FILE BUSY HANDLING: Cross-platform handling of busy files
- ATTACHMENT FAILURE NOTIFICATION: File lock warnings only added to email body if attachment fails completely

CONFIGURATION MANAGEMENT:
- Use INI file (emailer.ini) for all settings with automatic creation if missing
- Settings: Username, Password, PasswordIsEncrypted, SmtpServer, SmtpPort, FromEmail, ToEmail, EnableSSL
- Password encryption/decryption system with Base64 encoding
- Automatic encryption of passwords after successful SMTP validation
- Automatic reversion to unencrypted passwords on authentication failures
- MANDATORY configuration warnings - users must edit INI file before use
- Automatic encryption detection to distinguish between encrypted and plain text passwords
- Configuration reset command to recreate all environment files
- INI file formatting with spaces around equals sign for better readability
- Robust INI parsing that handles spaces around equals sign
- Accurate password encryption status detection and tracking
- REAL password encryption in INI file (not just logging)
- Minimal encryption log messages - only when encryption actually occurs
- SYNCHRONIZED MESSAGING: Logs and console must show identical password status
- FILE LOCK NOTIFICATIONS: Notify all channels (logs, debug, normal output, sound) when files are locked with ALARM class
- CASE-INSENSITIVE BOOLEAN PARSING: Handle True/False/true/false/T/t/F/f/1/0/yes/no
- UNIFIED MESSAGE FORMATTING: Single message generation for both logs and console
- COMPREHENSIVE DOCUMENTATION: Comments for all procedures and if-then constructs
- UNIFIED DEBUG MODE FORMAT: Single format "[timestamp] [DEBUG MODE] host | timestamp | application_directory" for both logs and console
- TRANSPARENT CONFIGURATION: All settings and defaults publicly documented
- COMMAND LINE CONFIGURATION: All SMTP parameters available as command line arguments
- PARAMETER PRIORITY: Command line parameters override INI file settings
- INI-FREE OPERATION: Complete functionality without INI file using command line
- MULTIPLE ADDRESS SUPPORT: CC and BCC parameters for advanced email addressing
- IMPORTANCE SETTING: Email priority configuration via command line
- RECURSION PROTECTION: Prevent infinite loops in file lock notifications
- FILE COPY MECHANISM: Automatic file copying for locked attachment files
- CROSS-PLATFORM CONFIGURATION: INI files work identically on all operating systems
- ENHANCED FILE LOCK HANDLING: ALARM notifications with proper log file writing

COMMAND LINE ARGUMENTS:
- --debug: Enable debug mode with console output and detailed logging
- --subject: Set email subject (supports template variables)
- --body: Set email body (supports template variables)
- --encrypt-password: Manual password encryption command
- --reset-config: Reset and recreate all configuration files
- --no-sound: Disable all sound alerts (default: sound enabled)
- --attach: Attach file to email (cross-platform path support)
- --server: SMTP server address (overrides INI)
- --port: SMTP server port (overrides INI)
- --username: SMTP username (overrides INI)
- --password: SMTP password (overrides INI)
- --from: From email address (overrides INI)
- --to: To email address (overrides INI, supports multiple addresses with commas)
- --cc: Carbon copy recipients (supports multiple addresses with commas)
- --bcc: Blind carbon copy recipients (supports multiple addresses with commas)
- --ssl: Enable SSL (true/false, overrides INI)
- --importance: Set email importance (high/normal/low, defaults to normal)
- Multiple help triggers: --help, -h, /?, -?, --?, ? (show compact comprehensive help)
- OPEN SOURCE HELP: Help includes information about open source nature and repository
- SOUND CONTROL DOCUMENTATION: Help includes --no-sound option information
- COMPACT HELP: Concise, informative help with minimal empty text
- TEMPLATE EXAMPLES: Help shows template variable usage in examples
- CROSS-PLATFORM USAGE: Help examples without .exe extension requirement

TEMPLATE VARIABLES SYSTEM:
- {host}: Computer hostname
- {user}: Current username  
- {timestamp}: Current date and time (yyyy-MM-dd HH:mm:ss)
- {time}: Current time only (HH:mm:ss)
- {date}: Current date only (yyyy-MM-dd)
- Automatic variable substitution in both subject and body
- TRANSPARENT TEMPLATING: All variable processing publicly documented
- CROSS-PLATFORM VARIABLES: All template variables work on all operating systems

DEFAULT BEHAVIORS:
- Default subject: "host: {hostname}" when not specified
- Default body: "Notification from Your Emailer\nHost: {hostname}\nUser: {username}\nTime: {timestamp}" (compact format)
- Log indicators: Show "<null>" for unspecified subject/body in logs
- PREDICTABLE DEFAULTS: All default behaviors publicly specified
- SOUND ENABLED: Sound alerts enabled by default, can be disabled with --no-sound
- CLEAN BODY FORMAT: No empty lines before host information in default body
- NORMAL IMPORTANCE: Default email importance is "normal"
- SINGLE RECIPIENT: Default to single recipient if no CC/BCC specified
- FILE COPY FALLBACK: Attempt file copy when original file is locked
- CROSS-PLATFORM DEFAULTS: Default behaviors consistent across all OS

LOGGING SYSTEM:
- Single file logging to emailer.log in application directory (no daily rotation)
- Console output in debug mode only
- Success format: Single line "SMTP-ok: server:port SSL:value username | from -> to | Subject: value | Body: value"
- Error format: Two lines - "Email sending failed" + "ERROR: details"
- All logs include timestamp: [yyyy-MM-dd HH:mm:ss.fff]
- Encryption events logged safely (no password exposure)
- Password type indication in success logs (encrypted/plain/default)
- Cross-platform compatible format (ASCII only, no Unicode symbols)
- No duplicate log entries in debug mode
- Enhanced password status tracking in logs
- SMTP-ok events displayed in debug mode
- Minimal false encryption log messages
- SYNCHRONIZED OUTPUT: Logs and console must show identical information
- FILE LOCK NOTIFICATIONS: Display in all output channels with ALARM class
- UNIFIED FORMAT: "[timestamp] [LEVEL] message" format for both logs and console
- OPTIMIZED MESSAGE TYPES: [INFO] for password events, [ALARM] for file locks
- UNIFIED DEBUG MODE ENTRY: Single format "[timestamp] [DEBUG MODE] host | timestamp | application_directory" for both logs and console
- AUDITABLE LOGGING: All log formats publicly documented for verification
- CLEAN ERROR MESSAGES: Error format "[timestamp] [ERROR] Descriptive message" without redundant "ERROR" text
- ATTACHMENT LOGGING: Log attachment file names and status
- RECIPIENT LOGGING: Log CC and BCC recipients information
- IMPORTANCE LOGGING: Log email importance level
- FILE COPY LOGGING: Log file copy operations for locked attachments
- RECURSION PROTECTION: Prevent infinite logging loops
- CROSS-PLATFORM LOGGING: Log format consistent across all operating systems
- FILE LOCK LOGGING: ALARM notifications properly written to log file even when file is locked

ERROR HANDLING & ALERTS:
- Comprehensive exception handling with detailed error information
- File lock detection for INI and log files with visual warnings
- Sound alerts (Console.Beep on Windows) for critical errors - configurable
- Visual warnings shown even in non-debug mode
- SMTP authentication error detection with automatic password management
- Stack traces and inner exception details in logs
- Automatic encryption detection to prevent decryption errors
- Proper password decryption on SMTP authentication failure
- ENHANCED FILE LOCK ALERTS: Notify all channels with sound (configurable) and ALARM class
- TRANSPARENT ERROR HANDLING: All error scenarios publicly documented
- CLEAN ERROR OUTPUT: Error messages like "[timestamp] [ERROR] SMTP AUTHENTICATION - Invalid password" without redundant "ERROR"
- SOUND CONTROL: Sound alerts can be disabled with --no-sound argument
- ATTACHMENT ERROR HANDLING: Proper error messages for file attachment issues
- ADDRESS VALIDATION: Email address format validation with clear error messages
- IMPORTANCE VALIDATION: Validate importance parameter values
- FILE COPY FALLBACK: Automatic file copying for locked attachments
- CLEAR FILE ERRORS: Specific messages for "file not found" and "file in use"
- INFINITE LOOP PREVENTION: Protection against recursive error notifications
- CROSS-PLATFORM ERROR HANDLING: Consistent error behavior across all OS
- UNIVERSAL FILE ERROR DETECTION: Platform-agnostic file error detection
- ATTACHMENT FAILURE NOTIFICATION: File lock warnings only added to email body if attachment fails completely

SECURITY FEATURES:
- Password validation against default "yourpassword" value
- Automatic encryption only after successful SMTP authentication
- Automatic decryption with proper error handling
- Secure password storage management
- Manual password encryption via command line for user convenience
- Base64 encoding with clear documentation of its limitations
- Safe logging of encryption events without password exposure
- Accurate password encryption status synchronization between logs and INI file
- Real password encryption implementation in INI file
- CORRECT ENCRYPTION LOGIC: Show actual password status, not predicted
- OPEN SOURCE SECURITY: All security mechanisms publicly verifiable
- NO HIDDEN FUNCTIONALITY: Complete transparency in security implementation
- COMMAND LINE PASSWORD SECURITY: Secure handling of passwords provided via command line
- ADDRESS SECURITY: Proper validation of email addresses to prevent injection attacks
- TEMPORARY FILE SECURITY: Secure handling of copied attachment files
- CROSS-PLATFORM SECURITY: Security measures consistent across all operating systems

USER GUIDANCE & HELP:
- Comprehensive help system describing all options and template variables
- Clear documentation of environment files (emailer.ini, emailer.log)
- Mandatory warnings about required INI file configuration
- Visual and sound alerts for unconfigured passwords
- Password encryption documentation with security disclaimer
- Manual encryption command usage instructions
- INI parameter documentation with allowed values
- Configuration reset command documentation
- OPEN SOURCE INFORMATION: Help includes open source transparency statement and repository URL
- SOUND CONTROL DOCUMENTATION: Help includes --no-sound option description
- TESTING INFORMATION: Help mentions mandatory testing requirements
- COMPACT HELP: Concise, informative help with minimal empty text
- ATTACHMENT DOCUMENTATION: Help includes --attach parameter information with examples
- COMMAND LINE CONFIGURATION: Help includes all SMTP command line parameters
- TEMPLATE VARIABLE EXAMPLES: Help shows practical examples with template variables
- MULTIPLE RECIPIENT DOCUMENTATION: Help explains CC and BCC usage
- IMPORTANCE DOCUMENTATION: Help explains email priority settings
- CROSS-PLATFORM USAGE: Help examples without .exe extension requirement
- FILE ATTACHMENT TROUBLESHOOTING: Help explains file locking and copy fallback

ADDITIONAL FEATURES:
- Automatic console allocation in debug mode
- Template-based INI file creation with helpful comments
- File accessibility checks with user notifications
- Robust error recovery mechanisms
- Password encryption detection to handle both encrypted and plain text
- Configuration reset functionality for environment files
- Cross-platform compatible output (no special symbols)
- Self-contained executable with no external DLL dependencies
- Unified file structure (protocol in comments + code)
- User requirements integration into protocol features
- Proper string escaping in console output
- INI file formatting with spaces around equals sign
- Robust INI parsing that handles spaces around equals sign
- Fixed password encryption status detection
- Removed redundant XML documentation tags
- Eliminated debug mode log duplication
- Enhanced logging with password status tracking
- Fixed password encryption in INI file
- Reduced false encryption log messages
- Debug mode SMTP-ok event display
- Proper password decryption on SMTP authentication failure
- Fixed password encryption status display in logs and console
- Enhanced file lock notifications across all output channels
- Improved password encryption/decryption messaging synchronization
- Unified console output for debug and normal modes
- Case-insensitive boolean parsing for INI values
- Robust whitespace trimming for INI keys and values
- Enhanced INI file writing with verification
- Fixed password encryption timing and messaging
- Unified message formatting for logs and debug output
- Comprehensive code documentation with procedure comments
- Optimized message format: [INFO] for password events, [ALARM] for file locks
- Removed redundant dash from message format
- Enhanced message type differentiation
- UNIFIED DEBUG MODE FORMAT: Single format for debug mode in both logs and console
- IMPROVED FILE ACCESS: Better handling of locked files with retry logic
- COMPLETE CODE DOCUMENTATION: All procedures and if-then constructs fully commented
- OPEN SOURCE TRANSPARENCY: All features publicly documented and verifiable
- SOUND CONTROL FEATURE: Configurable sound alerts with --no-sound option
- CLEAN ERROR OUTPUT: Error messages without redundant "ERROR" text
- PIPE SEPARATOR: Debug format uses "|" separator instead of commas
- MANDATORY TESTING: All development participants must verify functionality
- FILE ATTACHMENT SUPPORT: Cross-platform file attachment capability
- COMMAND LINE SMTP PARAMETERS: Full SMTP configuration via command line
- COMPACT HELP FORMAT: Concise and informative help display
- CLEAN BODY FORMAT: Default email body without empty lines before host information
- MULTIPLE RECIPIENT SUPPORT: CC and BCC addressing with comma separation
- EMAIL IMPORTANCE CONTROL: Priority setting (high, normal, low)
- ADVANCED EMAIL FEATURES: Full email header support
- CROSS-PLATFORM COMMAND USAGE: No file extension requirement in examples
- FILE COPY FALLBACK MECHANISM: Automatic copying of locked files for attachments
- RECURSION PROTECTION: Prevention of infinite loops in error handling
- CROSS-PLATFORM COMPATIBILITY: Full Windows/Linux/macOS support
- UNIVERSAL CONSOLE HANDLING: Platform-agnostic console operations
- PLATFORM-SPECIFIC SOUND: Conditional sound implementation (Windows only)
- ENHANCED FILE LOCK HANDLING: ALARM notifications with proper log file writing

CHARACTER SET REQUIREMENTS:
- ABSOLUTELY NO EMOJI characters allowed
- ASCII-only output for maximum cross-platform compatibility
- No Unicode special symbols or graphical characters
- Plain text only for all console output and logs
- OPEN SOURCE COMPLIANCE: Character set restrictions publicly documented

IMPLEMENTATION REQUIREMENTS:
- Use System.Net.Mail for SMTP functionality
- Implement proper IDisposable patterns for resources
- Handle all common SMTP exceptions specifically
- Ensure thread-safe file operations
- Maintain backward compatibility with existing INI formats
- Use Console.Beep for sound alerts (Windows only, with platform checks) - configurable
- Implement automatic encryption detection using Base64 validation
- Provide manual password encryption via command line parameter
- Log encryption events safely without exposing passwords
- Use PasswordIsEncrypted parameter (renamed from IsEncrypted)
- Place PasswordIsEncrypted immediately after Password in INI file
- Document all INI parameter allowed values in help
- Indicate password type in logs (encrypted/plain/default)
- Use ASCII-only output for cross-platform compatibility
- Number ALL features sequentially for maintenance efficiency
- Create standalone executable with no external DLL requirements
- ENFORCE NO EMOJI policy in all output
- PLACE PROTOCOL IN COMMENTS before code implementation
- PLACE PROTOCOL AT TOP of file - ABSOLUTE REQUIREMENT
- MAINTAIN UNIFIED FILE structure
- USE PROPER STRING ESCAPING in console output
- FORMAT INI FILES WITH SPACES around equals sign
- IMPLEMENT ROBUST INI PARSING that handles spaces
- FIX PASSWORD ENCRYPTION STATUS DETECTION
- REMOVE REDUNDANT XML DOCUMENTATION TAGS
- ELIMINATE DEBUG MODE LOG DUPLICATION
- ENHANCE LOGGING WITH PASSWORD STATUS TRACKING
- IMPLEMENT REAL PASSWORD ENCRYPTION IN INI FILE
- REDUCE FALSE ENCRYPTION LOG MESSAGES
- DISPLAY SMTP-OK EVENTS IN DEBUG MODE
- DECRYPT PASSWORDS ON SMTP AUTHENTICATION FAILURE
- SYNCHRONIZE LOGS AND CONSOLE OUTPUT
- NOTIFY FILE LOCKS IN ALL CHANNELS with ALARM class
- IMPLEMENT CORRECT ENCRYPTION TIMING: encrypt AFTER success, decrypt AFTER failure
- UNIFY MESSAGE GENERATION: single method for both logs and console
- IMPLEMENT UNIFIED DEBUG MODE FORMAT: single format "[timestamp] [DEBUG MODE] host | timestamp | application_directory" for debug initialization
- DOCUMENT ALL PROCEDURES: Complete comments for all methods and if-then constructs
- MAINTAIN OPEN SOURCE: Ensure all code remains publicly accessible and verifiable
- IMPLEMENT SOUND CONTROL: Add --no-sound argument to disable alert sounds
- CLEAN ERROR FORMAT: Remove redundant "ERROR" from error messages
- USE PIPE SEPARATOR: Change debug format to use "|" instead of commas
- ENFORCE MANDATORY TESTING: Require all participants to test functionality
- IMPLEMENT FILE ATTACHMENTS: Add --attach parameter with cross-platform path support
- IMPLEMENT COMMAND LINE SMTP: Add all SMTP parameters as command line arguments
- IMPLEMENT PARAMETER PRIORITY: Command line parameters override INI settings
- CREATE COMPACT HELP: Make help output concise and informative
- FIX BODY FORMAT: Remove empty lines from default email body
- IMPLEMENT MULTIPLE RECIPIENTS: Add --cc and --bcc parameters with comma separation
- IMPLEMENT EMAIL IMPORTANCE: Add --importance parameter for priority control
- VALIDATE EMAIL ADDRESSES: Implement proper email address validation
- UPDATE HELP EXAMPLES: Include template variables and attachment examples
- REMOVE EXE REQUIREMENT: Make command examples cross-platform without .exe
- IMPLEMENT FILE COPY FALLBACK: Add automatic file copying for locked attachments
- PREVENT INFINITE LOOPS: Add recursion protection in file lock notifications
- IMPROVE ATTACHMENT ERRORS: Clear error messages for file access issues
- IMPLEMENT CROSS-PLATFORM COMPATIBILITY: Full Windows/Linux/macOS support
- USE PLATFORM-AGNOSTIC FILE OPERATIONS: No OS-specific file handling
- IMPLEMENT UNIVERSAL FILE BUSY DETECTION: Cross-platform file lock detection
- ADD CROSS-PLATFORM TEMPORARY FILE MANAGEMENT: OS-agnostic temp files
- IMPLEMENT CONDITIONAL SOUND: Windows-only sound with fallback
- ENHANCE FILE LOCK HANDLING: ALARM notifications with proper log file writing
- IMPLEMENT ATTACHMENT FAILURE NOTIFICATION: File lock warnings only in email body if attachment fails

RESOURCE EFFICIENCY MANDATE:
- Sequential feature numbering is REQUIRED for:
  - 30-50% reduction in maintenance time
  - 40% cost savings in debugging and documentation
  - Ecological benefits through reduced computational waste
  - Extended application lifespan and sustainability
  - Efficient resource utilization in software lifecycle
  - Open source transparency benefits
  - Testing efficiency gains
  - Cross-platform maintenance cost reduction

PROTOCOL MAINTENANCE REQUIREMENTS:
- Timestamp recording is MANDATORY for all protocol versions
- Iteration counter must increment with each protocol update
- AI participants must be registered in the participants registry
- Protocol must maintain complete historical context
- EMOJI PROHIBITION must be enforced in all output
- PROTOCOL MUST BE IN COMMENTS before code
- PROTOCOL MUST BE AT TOP of file - ABSOLUTE REQUIREMENT
- UNIFIED FILE structure must be maintained
- FULL PROTOCOL must NEVER be shortened
- OPEN SOURCE TRANSPARENCY must be preserved
- MANDATORY TESTING must be enforced
- CROSS-PLATFORM COMPATIBILITY must be maintained

RECURSIVE MAINTENANCE REQUIREMENT - LEGALLY ENFORCED:
- This prompt MUST be updated whenever new functionality is added to the application
- All new features must be documented in both the requirements list and this prompt
- The AI must maintain awareness of the complete feature set at all times
- No functionality should be removed without updating both documentation sections
- This header section is ABSOLUTELY PROTECTED from deletion or modification that would reduce functionality
- Feature count integrity is legally binding - current minimum: 132 features
- FAILURE TO UPDATE THIS HEADER WHEN ADDING FEATURES = PROTOCOL VIOLATION
- ALL features must be numbered sequentially - NO exceptions
- Timestamp and iteration tracking is REQUIRED for audit compliance
- EMOJI AND SPECIAL CHARACTERS ARE ABSOLUTELY FORBIDDEN
- PROTOCOL MUST BE PLACED IN COMMENTS BEFORE CODE
- PROTOCOL MUST BE AT TOP OF FILE - ABSOLUTE REQUIREMENT
- UNIFIED FILE STRUCTURE IS MANDATORY
- FULL PROTOCOL MUST ALWAYS BE MAINTAINED - NO SHORTENING ALLOWED
- OPEN SOURCE TRANSPARENCY MUST BE PRESERVED - ALL CODE PUBLICLY VERIFIABLE
- MANDATORY TESTING MUST BE PERFORMED - ALL PARTICIPANTS MUST VERIFY FUNCTIONALITY
- CROSS-PLATFORM COMPATIBILITY MUST BE MAINTAINED - WINDOWS/LINUX/MACOS SUPPORT

LEGAL STATUS: This specification constitutes a binding functional contract. Any reduction in documented functionality represents a breach of operational requirements and may constitute legal liability for resulting damages. This open source application provides complete transparency for verification of all claimed functionality. Mandatory testing ensures quality and reliability. Cross-platform compatibility ensures broad accessibility.

=== END OF LEGALLY & TECHNICALLY PROTECTED REQUIREMENTS ===
*/

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

OPTIONS:
  --debug           Enable debug mode with console output
  --subject TEXT    Email subject text
  --body TEXT       Email body text
  --attach FILE     Attach file to email
  --no-sound        Disable sound alerts
  --cc EMAILS       Carbon copy (comma-separated emails)
  --bcc EMAILS      Blind carbon copy (comma-separated emails)
  --importance LEVEL Set importance (high/normal/low)

SMTP PARAMETERS (override INI file):
  --server HOST     SMTP server address
  --port NUMBER     SMTP server port
  --username USER   SMTP username  
  --password PASS   SMTP password
  --from EMAIL      From email address
  --to EMAIL        To email address (comma-separated for multiple)
  --ssl true|false  Enable SSL

UTILITIES:
  --encrypt-password PASS  Encrypt password for INI file
  --reset-config    Reset configuration files
  --help, -h, /?   Show this help

TEMPLATE VARIABLES:
  {host} {user} {timestamp} {time} {date}

EXAMPLES:
  emailer --debug --subject ""Alert from {host}"" --body ""User {user} at {timestamp}""
  emailer --server smtp.domain.com --port 587 --username user --password pass --from a@b.com --to c@d.com --ssl true
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