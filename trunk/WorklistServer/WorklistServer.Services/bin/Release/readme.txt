Extract package to Appropreate location
to install this service run the following command in command prompt (open command prompt with the highest privilege to run command prompt: start menu --> run --> cmd  ) 
	- installServer.bat -i 
	- goto WorklistServer.Services.exe.config modify connection string to the corresponding database (Running RIS Server Database)
	- come to Service Manager (control pannel-->admistrator tool --> services ) to start service "Modality Worklist Server" and Set it to "Automatic" start (right click -->properties-->startup type)
now you have a worklist service running
Defaut AE: WORKLIST_SV
Defaut Port: 105
	