@echo off
setlocal

REM Get directory where the script is located (no trailing slash)
set "SCRIPT_DIR=%~dp0"
set "SCRIPT_DIR=%SCRIPT_DIR:~0,-1%"

REM Launch Windows Terminal with 4 tabs
wt new-tab --title "sass" --tabColor "#FF0000" -d "%SCRIPT_DIR%\src\Employix.Presentation\Employix.Presentation\wwwroot" ^
; new-tab --title "db" --tabColor "#FFA500" -d "%SCRIPT_DIR%" ^
; new-tab --title "code" --tabColor "#800080" -d "%SCRIPT_DIR%" ^
; new-tab --title "tests" --tabColor "#009400ff" -d "%SCRIPT_DIR%\src\Employix.Presentation\Employix.Presentation\wwwroot\E2E Tests"

endlocal
