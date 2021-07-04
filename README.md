# 

#### Windows 10 Forms Application to transfer files between a Windows PC and a retro DOS Computer

![gallery](https://github.com/RoSchmi/Serial_FileTransfer_To_DOS/blob/master/pictures/SerialFileTransferTransmit.png)

When playing with old DOS computers there is often the problem how to get files and programs on (and from)  the old machine since modern PCs don’t have floppy disk drives and the retro PCs don’t have USB or network.
There are programs for file transfer via serial COM-ports available, which can be installed on Windows 10 PCs and have DOS compatible programs which can be run on the old DOS computer.
I used FastLynx (https://sewelldirect.com/products/fastlynx-3-3-software-only-electronic-download )which is still commercially available and proved to work perfectly for me. 
But before you can use such a program there is the problem how to get the DOS program on the old PC.
I found some advice in the internet (the recommended tools are in folder UtilityProgs of this repo):

https://forum.classic-computing.de/forum/index.php?thread/9167-datei%C3%BCbetragung-%C3%BCber-com-port/&postID=90767&highlight=DOS%2BDatei%2Bbasic#post90767

http://jcoppens.com/soft/howto/bootstrap/index.en.php

http://oldcomputers.dyndns.org/public/pub/rechner/eaca/common/User-Clubs/Club-80/Transfer_mit_pip_-_club80_netzwerk.pdf

The proposed way to receive textfiles on the DOS computer worked on my 80486 DOS 5.0 PC:

#### MODE COM1: 9600,N,8,1

#### COPY COM1: MYFILE.TXT

It is important to send only normal alphanumeric characters since some Ctrl-characters are executed and not transmitted. 
Especially Ctr-Z (hex 0x1A) is interpreted as EOF (End of File) and the first occurance stops receiving more following bytes.

To transfer binary files (e.g. programs) to the DOS machine, it is needed to convert tho original file in a format which only contains alphanumeric characters. 
The authors of the above links used a special hex-format where the content of the file is split into blocks of 16 characters. 
Each character is expressed as two characters, where the first represents the higher four bits of the byte and the second character expresses the lower four bits of the byte.
So, as an example, the character Ctrl-Z (hex 0x1A) in the orignal file is converted into two characters, '1' (hex 0x31) and 'A' (hex 0x42).
Each block of the data in the transmission format starts with an ':' and ends with an CRLF (0x0D, 0x0A).

To achieve that the receiving of data is terminated by the DOS machine, at the end of the transmission a Ctrl-Z (hex 0x1A) must come from the sender.

The Application of this repo (Serial_FileTransfer_To_DOS) has the option to append a Ctrl-Z after the transmision of the content of the file to terminate the receiving process on the DOS side.

Unfortunately the proposed way to receive the files to transfer on the DOS side using the DOS copy command didn’t work in the case of my retro computer c’t86.

Fortunately I had GWBASIC on my DOS PC and so I could type in a short GWBASIC program that did the trick (COM1TOFI.BAS in folder UtilityProgs).

To send the files from the Windows PC side, I made this Windows Forms application (‘Serial_FileTransfer_To_DOS’), which has the option to convert the files in the described special hex-format before sending. As already mentioned, this is needed to transfer binary files like programs.

When the GWBASIC program ‘COM1TOFI.BAS’ is started on the DOS computer it is important to start GWBASIC with the /c: switch option to achive a larger buffer for the serial port communication:

#### GWBASIC COM1TOFI /c:2048

When a file is received on the DOS side it must be converted back from the special hex-format to the original content. 
This is done with the proram: ‘HEXTOBIN.BAS’

To achieve a rather reliable transmission I used the slow baudrate of '1200', which results in a long duration of the file transfer. 
This procedure has to be done only one time. As soon as 'SL.EXE' from 'FastLynx' is transfered on your DOS computer, you can use this and file transfer is a fun.


In the folder UtilityProgs you can find the two GWBASIC programs:

COM1TOFI.BAS receives bytes which come in over a COM Port and stores them to a file.

HEXTOBIN.BAS converts a received file which is formated in the special hex-format back to the content before the conversion.

In the folder 'binaries' you can find the application as an .exe file 'SerialFileTransferToDos.exe' SHA1-hash: 5CDAF6C9DA68272BB5A292EE6E270CC68806D8DB



