# ChromeExtensionNativeMessaging
Example of native messaging using C#

## Installing Native App
Create registry

<code>REG ADD "HKCU\Software\Google\Chrome\NativeMessagingHosts\native_message_name" /ve /t REG_SZ /d "%CD%\native_message_name.json" /f</code>
