# 

Windows 10 Forms Application to transfer files between a Windows PC and a retro DOS Computer

![gallery](https://github.com/RoSchmi/Serial_FileTransfer_To_DOS/blob/master/pictures/SerialFileTransferTransmit.png)

When playing with old DOS computers there is often the problem how to get files and programs on (and from)  the old machine since modern PCs don’t have floppy disk drives and the retro PCs don’t have USB or network.
There are programs for file transfer via serial COM-ports available, which can be installed on Windows 10 PCs and have DOS compatible programs which can be run on the old DOS computer.
I used FastLynx which is still commercially available and proved to work perfect for me. 
But before you can use such a program there is the problem how to get the DOS program on the old PC.
I found some advice in the internet (the recommended tools are in folder UtilityProgs of this repo):
https://forum.classic-computing.de/forum/index.php?thread/9167-datei%C3%BCbetragung-%C3%BCber-com-port/&postID=90767&highlight=DOS%2BDatei%2Bbasic#post90767
http://jcoppens.com/soft/howto/bootstrap/index.en.php
http://oldcomputers.dyndns.org/public/pub/rechner/eaca/common/User-Clubs/Club-80/Transfer_mit_pip_-_club80_netzwerk.pdf
However the proposed way to receive the files to transfer on the DOS side with DOS commands didn’t work in the case of my retro computer c’t86 (works on other DOS computers).
Proposed way (example):
MODE COM1: 9600,N,8,1
COPY COM1: MYFILE.TXT
Fortunately I had GWBASIC on my DOS PC and so I could type in a short GWBASIC program that did the trick (COM1TOFI.BAS in folder UtilityProgs).
To send the files from the Windows PC side, I made this Windows Forms application (‘Serial_FileTransfer_To_DOS’) which has the option to convert the files in a special hex-format before sending. This is needed to transfer binary files (e.g. programs).
When the GWBASIC program ‘COM1TOFI.BAS’ is started on the DOS computer it is important to start GWBASIC with the /c: switch option to achive a larger buffer for the serial port communication:
GWBASIC COM1TOFI /c:2048
When a file is received on the DOS side it must be converted back from the special hex-format to the original content.
This is done with the proram: ‘HEXTOBIN.BAS’

To have a reliable transmission I used a slow baudrate of '1200', which resulted in a long duration of the file transfer. This procedure has to be done only one time. As soon as 'SL.EXE' from 'FastLynx' you can use this and file transfer is fun.


In the folder UtilityProgs you can find the two GWBASIC programs:

COM1TOFI.BAS receives bytes which come in over a COM Port and stores them to a file.

HEXTOBIN.BAS converts a received file which is formated in a special hex-format to the content before the conversion



