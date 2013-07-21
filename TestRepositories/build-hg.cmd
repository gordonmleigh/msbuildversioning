@echo off

echo.
echo Building Mercurial test repositories...
echo.

call .\clean-hg.cmd

echo ===== Hg1 =====
rem Not on tip. No uncommitted changes.
mkdir Hg1
if %errorlevel% neq 0 goto :mkdir_error
cd Hg1
hg init
hg import -d "1367630784 0" -u JD -m "First lines" ..\Undone_0.patch
hg import -d "1367630830 0" -u JD -m "Backup singing" ..\Undone_1.patch
hg import -d "1367630874 0" -u JD -m "More backup lyrics" ..\Undone_2.patch
hg import -d "1367630951 0" -u JD -m "Add more lines" ..\Undone_3.patch
hg update -r 2
cd ..

echo ===== Hg2 =====
rem Updated to a tagged revision on a named branch. Uncommitted changes.
mkdir Hg2
if %errorlevel% neq 0 goto :mkdir_error
cd Hg2
hg init
hg import -d "1367630784 0" -u JD -m "First lines" ..\Undone_0.patch
hg import -d "1367630830 0" -u JD -m "Backup singing" ..\Undone_1.patch
hg import -d "1367630874 0" -u JD -m "More backup lyrics" ..\Undone_2.patch
hg import -d "1367630951 0" -u JD -m "Add more lines" ..\Undone_3.patch
hg branch formal
hg import -d "1367632892 0" -u JD -m "Increase formality" ..\Undone_4.patch
hg tag -d "1367632944 0" -u JD formal-1.0
hg update -r 4
hg import --no-commit ..\Undone_5.patch
cd ..

echo ===== Hg3 =====
rem Updated to tip. Two parent revisions (an uncommitted merge).
mkdir Hg3
if %errorlevel% neq 0 goto :mkdir_error
cd Hg3
hg init
hg import -d "1367225645 0" -u JD -m "Initial counting file" ..\Counting_0.patch
hg import -d "1367225673 0" -u JD -m "Add 2" ..\Counting_1.patch
hg update -r 0
hg import -d "1367225700 0" -u JD -m "Forgot 5" ..\Counting_2.patch
hg merge -t internal:merge
cd ..

echo.
echo Finished. Make sure there are no error messages above.
goto :eof

:mkdir_error
echo FAILED: Could not create folder.
