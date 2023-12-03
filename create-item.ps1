function Read-NonEmptyString([string] $prompt) {
    $value = Read-Host $prompt
    if ($null -eq $value -or "" -eq $value) {
        Write-Host "Please enter a non-empty value."
        return Read-NonEmptyString $prompt
    }
    return $value
}

function Read-Options([string] $prompt, [string[]] $options, [string] $default) {
    $value = (Read-Host $prompt).ToLower()
    if ($null -eq $value -or "" -eq $value) {
        return $default
    }
    $matchingOption = $options | Where-Object { $_ -ieq $value }
    if ($null -ne $matchingOption) {
        return $matchingOption
    }
    Write-Host "Please select from the following options: $options"
    return Read-Options $prompt $options $default
}

function Read-YesOrNo([string] $prompt) {
    $value = (Read-Host $prompt).ToLower()
    if ($value -eq "y" -or $value -eq "yes" -or $value -eq "true" -or $value -eq "1") {
        return $true
    }
    return $false
}

Write-Host "Welcome to use FastWeb! You will create CRUD items by this script~"

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

$name = "FastWeb"
$core = "Core"
$storage = "Storage"
$infrastructure = "Infrastructure"
$web = "Web"

$entityName = Read-NonEmptyString "What is the name of the entity you want to create?"
$primaryKey = Read-Options "What is the primary key of the entity you want to create?`nOptions: string, int, long, guid. Default: int." @("string", "int", "long", "guid") "int"
$restful = Read-YesOrNo "Do you want to use RESTful API? (yes[y]/no[n])"
$pagination = Read-YesOrNo "Do you want to use pagination? (yes[y]/no[n])"

dotnet new fw -n $name -o $scriptDir -t item -c $core -s $storage -f $infrastructure -w $web -e $entityName -r $restful -pk $primaryKey -pg $pagination

Write-Host "Successfully created CRUD items for entity '$entityName'!"
