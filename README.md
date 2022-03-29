# Kiloger
Registrador de teclas

## Using it
Kiloger has no interface. It only responds to line arguments. Input parameters, to be more precise.

### Start recording
1) Start Kiloger.exe with the parameter ```/StartRecording```
2) Done. Now Kiloger is logging the keys.

### Save recording
1) Start Kiloger.exe with the parameter ```/SaveRecord```
2) Done. The recording will be saved to ```%localappdata%\Local\Zhenboro\Kiloger```.
Remember that this only saves the record up to the point of the argument. Then it will continue recording another round.

### Save recording and close
1) Start Kiloger.exe with the parameter ```/SaveAndExit```
2. Done. The recording will be saved to ```%localappdata%\Local\Zhenboro\Kiloger``` and then Kiloger will close.

### Restart the recording
1) Start Kiloger.exe with the parameter ```/ResetRecord```
2) Done. Kiloger has restarted the recording. The registry will be cleaned.

### Rtop recording
1) Start Kiloger.exe with the parameter ```/StopRecord```
2) Done. Kiloger will be closed. It will not save the record.

### Stop
Same as 'Stop recording'. But forced.
1) Start Kiloger.exe with the parameter ```/Stop```
2) Done. Kiloger closed. It will not save the record.

#### For babies
1) Start the Easy Kiloger starter with args.py file
2) Enter any of the parameters already mentioned.
3) Done. This python script will send the parameters and Kiloger will fetch them automatically with the power of ```'StartupNextInstance'``` events since Kiloger is marked as ```'Single Instance'```

##### Truisms
Obviously, the star parameter is /StartRecording, since if this instance is not running with that parameter, the other parameters have nothing to do.
