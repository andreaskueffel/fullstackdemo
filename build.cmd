
@echo off
setlocal enabledelayedexpansion

echo === Build WebKeyGen UI ===

:: Paths
set ROOT=%cd%
set API_DIR=%ROOT%\MachineLicenseManagement.WebKeyGen
set UI_DIR=%ROOT%\MachineLicenseManagement.WebKeyGenUI
set WWWROOT=%API_DIR%\wwwroot

:: 1) Generate OpenAPI spec
echo [STEP] Generate OpenAPI
dotnet run --project "%API_DIR%" --export-openapi
if errorlevel 1 exit /b 1

copy /y "%API_DIR%\openapi-webkeygen.json" "%UI_DIR%" >nul

:: 2) Build Angular UI
echo [STEP] npm install
pushd "%UI_DIR%"
call npm install --no-fund --verbose
if errorlevel 1 exit /b 1

echo [STEP] npm run generate
call npm run generate
if errorlevel 1 exit /b 1

echo [STEP] ng build --configuration production
call ng build --configuration production
if errorlevel 1 exit /b 1
popd

:: 3) Copy build output to API wwwroot
echo [STEP] Copy build output into wwwroot

if exist "%WWWROOT%" rmdir /s /q "%WWWROOT%"
mkdir "%WWWROOT%"

xcopy /e /i /y "%UI_DIR%\dist\WebKeyGenUi\browser\*" "%WWWROOT%\" >nul

echo [STEP] Run App
dotnet run --project "%API_DIR%"


echo === DONE ===
exit /b 0

