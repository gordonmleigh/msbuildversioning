param($installPath, $toolsPath, $package, $project)

Write-Host "Installing MSBuildVersioning"

$origProj = Get-Project
$buildProject = $origProj | Get-MSBuildProject

# add MSBuild targets
$buildProject.Xml.AddImport("msbuild\MsBuildVersioning.targets")

# remove reference
$ref = $buildProject.Items | Where-Object { $_.Key -eq 'Reference' } | Select-Object -ExpandProperty Value | Where-Object { $_.EvaluatedInclude.StartsWith('MSBuildVersioning, ') }
$buildProject.RemoveItem($ref)

# avoid compiling the template
$base = $buildProject.Items | Where-Object { $_.Key -eq 'Compile' } | Select-Object -ExpandProperty Value | Where-Object { $_.EvaluatedInclude -eq 'Properties\VersionInfo.base.cs' } 
$base.ItemType = "None"

# do compile the result
$buildProject.Xml.AddItem("Compile", 'Properties\VersionInfo.cs')

# avoid including the Task dll
$msbuild_task = $buildProject.Items | Where-Object { $_.Key -eq 'Content' } | Select-Object -ExpandProperty Value | Where-Object { $_.EvaluatedInclude -eq 'msbuild\MSBuildVersioning.dll' } 
$msbuild_task.ItemType = "None" 

# figure out which scm we're using and add a proper task
$path = Get-Location
$path = [System.IO.PATH]::GetFullPath($path)
while ($path -ne [System.IO.PATH]::GetPathRoot($path)) {
    Write-Host "Testing $path"
    $type = @((Get-ChildItem $path -filter ".git" -force), (Get-ChildItem $path -filter ".hg" -force), (Get-ChildItem $path -filter ".svn" -force))
    if ($type.Count -gt 0) {
        $scm = $type[0].Name
        Write-Host "Adding BeforeBuild Target for $path: $scm"
        $target = $buildProject.Xml.AddTarget("BeforeBuild")
        switch($scm) {
            ".git" { $task = $target.AddTask("GitVersionFile") }
            ".hg" { $task = $target.AddTask("HgVersionFile") }
            ".svn" { $task = $target.AddTask("SvnVersionFile") }
        }
        $task.SetParameter("TemplateFile", 'Properties\VersionInfo.base.cs')
        $task.SetParameter("DestinationFile", 'Properties\VersionInfo.cs')
        break
    }
    $path = [System.IO.PATH]::GetFullPath([System.IO.PATH]::Combine($path, ".."))
}

$origProj.Save()
