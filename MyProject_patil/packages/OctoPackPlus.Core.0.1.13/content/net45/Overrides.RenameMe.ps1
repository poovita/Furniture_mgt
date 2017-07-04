#############
##
##  This file provides you a method to override the various OctoPackPlus function implementations
##
##  This file will ONLY be used if this file is renamed to "Overrides.ps1" (remove the RenameMe part)
##
#############
##
##  All functions share the same parameter, a dictionary<string,string> called FunctionParameters
##  (this was done to ensure that new data can be added, while maintaining the same signature)
##
#############
##
##  Parameters                      Sample Values
##    - outDir                    = "bin\Release"
##    - buildLabel                = "" (VS) or "myService v1.0.0_20150901.4" (TFS)
##    - MSBuildProjectDirectory   = "C:\Projects\MySolution\myService.Deploy"
##    - MSBuildProjectName        = "myService.Deploy"
##    - MSBuildProjectFile        = "myService.Deploy.csproj"
##    - TargetDir                 = "C:\Projects\MySolution\myService.Deploy\bin\Release"
##    - DeploySettingsFile        = "DeploySettings.xml"


## function Get-NuGetVersion_Build ( $FunctionParameters ) { return "128" }

