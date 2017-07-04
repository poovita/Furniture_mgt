#############################
###
###  Global Variables - Input Parameters
###

PARAM(
    [Parameter(Mandatory=$true)]  [string]  $outDir
  , [Parameter(Mandatory=$true)]  [string]  $MSBuildProjectDirectory
  , [Parameter(Mandatory=$true)]  [string]  $MSBuildProjectName
  , [Parameter(Mandatory=$true)]  [string]  $MSBuildProjectFile
  ,                               [string]  $buildLabel
)

write-Verbose "IN    outdir                    [ $outDir ]"
write-Verbose "IN    buildLabel                [ $buildLabel ]"
write-Verbose "IN    MSBuildProjectFile        [ $MSBuildProjectFile ]"
write-Verbose "IN    MSBuildProjectName        [ $MSBuildProjectName ]"
write-Verbose "IN    MSBuildProjectDirectory "
Write-Verbose "   => $MSBuildProjectDirectory"

# TFS tends to provide the build path with a tailing \, the argument formatting thinks that the closing quote is actually in the string
$outDir = $outDir.TrimEnd('\"')
write-Verbose "FIXED outdir     "
Write-Verbose "   => $outDir"


#############################
###
###  Global Variables - Calculated
###

if ($myInvocation.MyCommand.CommandType -ne [System.Management.Automation.CommandTypes]::Script) {
    $localPath = [System.IO.Path]::GetDirectoryName($myInvocation.MyCommand.Definition)
} else {
    $localPath = [System.IO.Path]::GetDirectoryName($psISE.CurrentFile.FullPath)
}
write-Verbose "CALC  localpath                 [ $localPath ]"


#############################
###
###  Global Variables - Constants
###

$const_FnOverrideScript_File = "Overrides.ps1"

$const_DeploySettings_File = "DeploySettings.xml"


#############################
###
###  Overrideable Functions
###

$fnParameters = @{ "outDir"     = $outDir
                 ; "buildLabel" = $buildLabel
                 ; "MSBuildProjectDirectory" = $MSBuildProjectDirectory
                 ; "MSBuildProjectName"      = $MSBuildProjectName
                 ; "MSBuildProjectFile"      = $MSBuildProjectFile
                 ; "TargetDir"               = $MSBuildProjectDirectory + "\" + $outDir
                 ; "DeploySettingsFile"      = $const_DeploySettings_File
                 }

function Get-NuGetVersion_Build ( $FunctionParameters ) {

    $inp_MSBuildProjectDirectory = $FunctionParameters["MSBuildProjectDirectory"]
    $inp_buildLabel              = $FunctionParameters["buildLabel"]
    $inp_DeploySettingsFile      = $FunctionParameters["DeploySettingsFile"]

    $outval = $null

    # build label will be null for local builds (in which case, use CSProj)
    if ([String]::IsNullOrEmpty($inp_buildLabel))
    {
        # get relative path to project via DeploySettings.xml
        $DeploySettings_File = $inp_MSBuildProjectDirectory + "\" + $inp_DeploySettingsFile
        Write-Verbose "CALC  DeploySettings_File   [ $DeploySettings_File ] "
        $DeploySettings      = [xml] ( [System.IO.File]::ReadAllLines( $inp_MSBuildProjectDirectory + "\" + $inp_DeploySettingsFile) )
        $ClientProj_Path_Rel = $DeploySettings.Settings.ProjectPath
        Write-Verbose "Base project relative path  [ $ClientProj_Path_Rel ] "

        $ClientProj_Path_Abs = [System.IO.Path]::GetFullPath( $inp_MSBuildProjectDirectory + "\" + $ClientProj_Path_Rel )
        write-Verbose "Base project absolute path  [ $ClientProj_Path_Abs ] "

        # read rev number
        $ClientProj = [xml] ( [System.IO.File]::ReadAllLines( $ClientProj_Path_Abs ) )
        $ClientProj_Rev = ( $ClientProj.Project.PropertyGroup | ? { $_.ApplicationRevision -ne $null } ).ApplicationRevision
        if ( $ClientProj_Rev -eq $null ) { $ClientProj_Rev = 0 }

        write-Verbose "Base project revision       [ $ClientProj_Rev ] "
        $outval = $ClientProj_Rev
    } else {
        # parse year into 4 digit number:
        #   first digit is number of years since startyear (divided by two for longevity)
        #   3 digits for days
        $startingYear = 2015
        $startingDate = new-object System.DateTime($startingYear, 1, 1)
        $days = [System.DateTime]::Now.Subtract( $startingDate ).Days

        # pull rev from build label
        $RevPos = $inp_buildLabel.LastIndexOf(".") + 1
        $RevLen = $inp_buildLabel.Length - $RevPos
        $Rev    = $inp_buildLabel.Substring( $RevPos , $RevLen )

        $outval = [Int32]::Parse( [String]::Format("{0}{1}", $days, $Rev) )
    }

    return $outval
}






# Check for override file
$fnOverrideScript_Abs = $MSBuildProjectDirectory + "\" + $const_FnOverrideScript_File
if ([System.IO.File]::Exists($fnOverrideScript_Abs))
{
    Write-Verbose "Loading function overrides from: $fnOverrideScript_Abs"
    . $fnOverrideScript_Abs
}
else
{
    Write-Verbose "Function overrides file not found at: $fnOverrideScript_Abs"
}







#############################
###
###  Primary Execution
###

$NuGetVersion_Build = Get-NuGetVersion_Build -FunctionParameters $fnParameters

write-Verbose "CALC  NuGetVersion_Build  [ $NuGetVersion_Build ]"

$NuSpecTemplate     = "DeploySpec.xml"
$NuSpecTemplate_Abs = $MSBuildProjectDirectory + "\" + $NuSpecTemplate
$NuSpecFile         = "Deploy.nuspec"
$NuSpecFile_Abs     = $MSBuildProjectDirectory + "\" + $NuSpecFile

Write-Verbose "CALC  NuSpecTemplate_Abs  [ $NuSpecTemplate_Abs ]"
Write-Verbose "CALC  NuSpecFile_Abs      [ $NuSpecFile_Abs ]"


$NuSpecTokens = @{ "outdir"                  = $outDir
                 ; "BuildNumber"             = $NuGetVersion_Build
                 ; "MSBuildProjectDirectory" = $MSBuildProjectDirectory
                 ; "MSBuildProjectName"      = $MSBuildProjectName
                 }

$templateIn  = [System.IO.File]::ReadAllLines( $NuSpecTemplate_Abs )
$templateIn  = [System.IO.File]::ReadAllLines( $NuSpecTemplate_Abs )
$templateOut = [String[]] @()
$templateIn `
             | % {
                    $str = $_
                    $NuSpecTokens.Keys | % {
                        $str = $str.Replace( [String]::Format( "@@{0}@@", $_ ) , $NuSpecTokens[$_] )
                    }
                    $templateOut += $str.Replace( "\\", "\" )
                }

[void][System.IO.File]::WriteAllLines($NuSpecFile_Abs, $templateOut)

# since OctoPack doesn't respect the version number in the nuspec file, when naming the package... we'll drop the build into a file for later use.
$BuildVersion_FileName = "Version.txt"
[void][System.IO.File]::WriteAllLines($BuildVersion_FileName , ( [xml]( [System.IO.File]::ReadAllLines( $NuSpecFile_Abs ) ) ).package.metadata.version )

if ($Error.Count -eq 0)
{ exit 0 }
else
{ trap { Write-Error $Error } ; exit 1 }