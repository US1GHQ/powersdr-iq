@echo off
copy "J:\SVN\PowerSDR-IQ.1.12.0.1\Source\Console\CAT\CATStructs.xml" "..\..\bin\Release\"; 
copy "J:\SVN\PowerSDR-IQ.1.12.0.1\Source\Console\..\FFTW\libfftw3f-3.dll" "..\..\bin\Release\"
copy "J:\SVN\PowerSDR-IQ.1.12.0.1\Source\Console\..\libusb\bin\libusb0.dll" "..\..\bin\Release\"
copy "J:\SVN\PowerSDR-IQ.1.12.0.1\Source\Console\..\JanusAudio\OzyFirmwareBinaries\*" "..\..\bin\Release\"

if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd