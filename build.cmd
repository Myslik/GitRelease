SETLOCAL
powershell.exe -NoProfile -ExecutionPolicy unrestricted -Command "& { .\build.ps1 %*; if ($lastexitcode -ne 0) {write-host "ERROR: $lastexitcode" -fore RED; exit $lastexitcode} }" 