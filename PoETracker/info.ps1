Write-Host "PoETracker version 1.0.0"
Write-Host "Author: Viktor Vallmark"
Write-Host "https://github.com/ViktorVallmark/PoETracker"

Write-Host "Adding PoETracker to PATH..."


[Environment]::SetEnvironmentVariable(
    "Path",
    [Environment]::GetEnvironmentVariable("Path", [EnvironmentVariableTarget]::Machine) + ";C:\bin",
    [EnvironmentVariableTarget]::Machine)

Write-Host "Complete!"
