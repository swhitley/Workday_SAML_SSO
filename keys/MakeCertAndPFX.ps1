$CertSubject = "MyCertSubject"
$Secret = "secret"
$CurrDir = [System.IO.Path]::GetDirectoryName($myInvocation.MyCommand.Definition)

##############################
#Make the Cert
##############################
$command = $CurrDir +'\makecert.exe -r -pe -n "CN=' + $CertSubject + '" -b 01/01/2000 -e 01/01/2050 -eku 1.3.6.1.5.5.7.3.1 -ss my -sr currentuser -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12'
iex $command

##############################
#Export the PFX
##############################
dir cert:\currentuser\my | 
  Where-Object -FilterScript { $_.subject -like "*$CertSubject*"  } | 
  Foreach-Object { [system.IO.file]::WriteAllBytes(
    "$CurrDir\$($_.subject -replace 'CN=','').pfx", 
    ($_.Export('PFX', $Secret)) ) }

