# MyOTP

This is just a quick and (very) dirty TOTP Code generator for Windows Desktop, as I did not want to grab and unlock my phone every time I needed a code.

> [!WARNING]  
> This application is made for personal use on a secure personal computer.
> 
> Database is encrypted, but the default key is in the repo (it's just a random string, don't forget to change it for YOUR use!)

# Base Use

![alt text](https://github.com/abesnier/MyOTP/blob/master/MyOTP/myotp.png?raw=true)

Once an app is recorded, it will appear in blue if you entered an URL, or grey otherwise.

If it is blue, you can click it, it will open your default browser to the recorded URL, and the code is already copied to the Clipboard, ready for use.

If it is grey, you can click the code, and it will be copied to the clipboard, ready for use.

# Record new App

Clisk the "Add", you will be prompted with this window, which I believe is self-explanatory.

![alt text](https://github.com/abesnier/MyOTP/blob/master/MyOTP/myotp2.png?raw=true)

# Delete an App

Justr right click on the app name, and there will be a "Delete" option.

Deleted entries cannot be recovered.

# License

This program:
 - CC0 1.0 Universal

NUGET Components:

 - [Otp.NET](https://github.com/kspearrin/Otp.NET) : MIT
 - [Microsoft.Data.Sqlite](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=net-cli): MIT
 - [SQLite Cipher](https://github.com/ericsink/SQLitePCL.raw) : Apache 2.0