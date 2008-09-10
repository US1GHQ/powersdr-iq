@echo off
copy "C:\Documents and Settings\Christos\Desktop\Flex\Source\Console\CAT\CATStructs.xml" "..\..\bin\Release\"; 
copy "C:\Documents and Settings\Christos\Desktop\Flex\Source\Console\..\FFTW\libfftw3f-3.dll" "..\..\bin\Release\"
copy "C:\Documents and Settings\Christos\Desktop\Flex\Source\Console\..\libusb\bin\libusb0.dll" "..\..\bin\Release\"
copy "C:\Documents and Settings\Christos\Desktop\Flex\Source\Console\..\JanusAudio\OzyFirmwareBinaries\*" "..\..\bin\Release\"

if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd