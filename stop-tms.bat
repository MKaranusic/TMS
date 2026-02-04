@echo off
echo Stopping Task Management System...
docker compose -f docker-compose.prod.yml down
echo.
echo Application stopped.
pause
