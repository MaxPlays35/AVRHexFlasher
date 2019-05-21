REM Copy "files" to build folder
xcopy /Y files AVRDude\bin\Debug\files\ /E /Q /C
mkdir AVRDude\bin\Debug\files\custom\libs
mkdir AVRDude\bin\Debug\files\custom\hardware
appveyor-retry nuget restore