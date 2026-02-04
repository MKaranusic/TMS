@echo off
echo ==========================================
echo    Task Management System (TMS) Launcher
echo ==========================================
echo.

:: Check if Docker is running
docker info >nul 2>&1
if errorlevel 1 (
    echo [ERROR] Docker is not running!
    echo Please start Docker Desktop and try again.
    echo.
    pause
    exit /b 1
)

echo [OK] Docker is running
echo.
echo Starting the application... This may take a few minutes on first run.
echo.

:: Run docker compose
docker compose -f docker-compose.prod.yml up -d

if errorlevel 1 (
    echo.
    echo [ERROR] Failed to start the application.
    pause
    exit /b 1
)

echo.
echo ==========================================
echo    Application started successfully!
echo ==========================================
echo.
echo Open your browser and go to:
echo    http://localhost:3000
echo.
echo To stop the application, run: stop-tms.bat
echo ==========================================
echo.

:: Open browser automatically
start http://localhost:3000

pause
