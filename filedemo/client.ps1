param ($message)

$filename="z:\message.txt"
$tempname="z:\traub-temp.txt"

$message | out-file $tempname
while (test-path ($tempname)) {
    ren $tempname $filename -erroraction silent
    sleep 1
}