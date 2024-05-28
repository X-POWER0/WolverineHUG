ECHO RUN
set FolderOfProject=%~dp0
haxelib run lime test html5 --port=3001
pause
set /p "comand=Command Enter: "
%comand%
cmd
cd FolderOfProject

echo haxelib run lime test html5 --port=3001