Write-Host
Write-Host 'Building Subversion test repositories...'
Write-Host

.\clean-svn.ps1

Write-Host '===== SvnRepo ====='
# Repository for the following two working copies.

svnadmin create SvnRepo

$repo = [string](Resolve-Path SvnRepo)
$repoUrl = 'file:///' + $repo.Replace('\', '/')

echo '===== SvnWC1 ====='
# Root of the repository checked out at mixed revisions. No uncommitted changes.

svn checkout $repoUrl SvnWC1
cd SvnWC1

[void](mkdir branches)
[void](mkdir tags)
[void](mkdir trunk)
svn add branches tags trunk
svn commit -m "Create trunk, tags, branches"

svn patch ..\Recipe_0.patch
svn commit -m "Add recipe"

svn copy ($repoUrl + '/trunk') ($repoUrl + '/tags/1.0') -m "Tag version 1.0"
svn update tags\1.0

svn patch ..\Recipe_1.patch
svn commit -m "Cream and orange juice"

svn copy ($repoUrl + '/trunk') ($repoUrl + '/branches/beef') -m "Create branch for beef recipe"

svn patch ..\Recipe_3.patch
svn commit -m "Finish the recipe"

cd ..

echo '===== SvnWC2 ====='
# Branch checked out at revision 5. Uncommitted changes.

svn checkout ($repoUrl + '/branches/beef@5') SvnWC2
cd SvnWC2

svn patch ..\Recipe_2.patch

cd ..

echo 'Finished. Make sure there are no error messages above.'
