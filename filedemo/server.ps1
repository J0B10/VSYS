# Interface
#
#   echo string

$filename="z:\message.txt"
while ($true) {
    if (Test-Path $filename) {
        $data = Get-Content $filename
        $c=$data.split(" ", 2)
        if ($c[0] -match "^echo$") {
            if ($c[1] -match "^[A-Za-z0-9 ]*$") {
                & $c[0] $c[1]
            } else {
                Write-host "illegal argument"
            }
        } else {
            write-host "illegal command"
        }
        del $filename
    } else {
        sleep 1
    }
}