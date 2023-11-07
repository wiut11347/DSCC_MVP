%SystemRoot%\sysnative\WindowsPowerShell\v1.0\powershell.exe -command "Set-ExecutionPolicy Unrestricted -Force"

IF NOT EXIST c:\inetpub\wwwroot\bike mkdir c:\inetpub\wwwroot\bike

cd c:\temp

%SystemRoot%\sysnative\WindowsPowerShell\v1.0\powershell.exe -command ".\install.ps1"