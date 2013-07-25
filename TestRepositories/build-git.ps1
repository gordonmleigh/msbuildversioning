Write-Host
Write-Host 'Building Git test repositories...'
Write-Host

.\clean-git.ps1

$env:GIT_COMMITTER_DATE = '1367719200'

Write-Host '===== Git1 ====='
# Not on tip. No uncommitted changes.

[void](mkdir Git1)
cd Git1

git init .
git config --local user.name JD
git config --local user.email j@d

git apply ..\Undone_0.patch
git add .
git commit --date=1367630784 -a -m "First lines"
git apply ..\Undone_1.patch
git commit --date=1367630830 -a -m "Backup singing"
git apply ..\Undone_2.patch
git commit --date=1367630874 -a -m "More backup lyrics"
git apply ..\Undone_3.patch
git commit --date=1367630951 -a -m "Add more lines"
git checkout -q master^

cd ..

Write-Host '===== Git2 ====='
# Updated to a tagged revision on a named branch. Uncommitted changes.

[void](mkdir Git2)
cd Git2

git init .
git config --local user.name JD
git config --local user.email j@d

git apply ..\Undone_0.patch
git add .
git commit --date=1367630784 -a -m "First lines"
git apply ..\Undone_1.patch
git commit --date=1367630830 -a -m "Backup singing"
git apply ..\Undone_2.patch
git commit --date=1367630874 -a -m "More backup lyrics"
git apply ..\Undone_3.patch
git commit --date=1367630951 -a -m "Add more lines"
git checkout -b formal
git apply ..\Undone_4.patch
git commit --date=1367632892 -a -m "Increase formality"
git tag -a -m "Add tag formal-1.0" formal-1.0
git apply ..\Undone_6.patch
git commit --date=1367632932 -a -m "Prefer the Queen's English"
git checkout -q formal-1.0
git apply ..\Undone_5.patch

cd ..

Write-Host '===== Git3 ====='
# Two parent revisions (an uncommitted merge)

[void](mkdir Git3)
cd Git3

git init .
git config --local user.name JD
git config --local user.email j@d

git apply ..\Counting_0.patch
git add .
git commit --date=1367225645 -a -m "Initial counting file"
git apply ..\Counting_1.patch
git commit --date=1367225673 -a -m "Add 2"
git checkout -q master^
git apply ..\Counting_2.patch
git commit --date=1367225700 -a -m "Forgot 5"
git merge --no-commit master

cd ..

Write-Host
Write-Host 'Finished. Make sure there are no error messages above.'
