using System.Diagnostics;
public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly string? _nugetExePath;
        private readonly string? _packagesPath;
        private readonly string? _archivePath;
        private readonly string? _feedUrl;
        private readonly string? _apiKey;
        private readonly string? _logFilePath;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _nugetExePath = configuration.GetSection("NugetWatcher")["nugetExePath"];
            _packagesPath = configuration.GetSection("NugetWatcher")["packagesPath"];
            _archivePath = configuration.GetSection("NugetWatcher")["archivePath"];
            _feedUrl = configuration.GetSection("NugetWatcher")["feedUrl"];
            _apiKey = configuration.GetSection("NugetWatcher")["apiKey"];
            _logFilePath = configuration.GetSection("NugetWatcher")["logFilePath"];
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {      

        _logger.LogInformation("NuGet Pusher Worker started at: {time}", DateTimeOffset.Now);

        if (!File.Exists(_nugetExePath))
        {
            LogError($"ERROR: nuget.exe not found at {_nugetExePath}", _logFilePath);
            return;
        }

        if (!Directory.Exists(_archivePath))
        {
            Directory.CreateDirectory(_archivePath);
        }

        var packageFiles = Directory.GetFiles(_packagesPath, "*.nupkg", SearchOption.AllDirectories);

        if (packageFiles.Length == 0)
        {
            LogWarning("No .nupkg files found.", _logFilePath);
            return;
        }

        foreach (var package in packageFiles)
        {
            _logger.LogInformation("Uploading: {package}", package);
            LogInfo($"Uploading: {package}", _logFilePath);

            var exitCode = RunNuGetPush(_nugetExePath, package, _feedUrl, _apiKey);

            if (exitCode == 0)
            {
                LogSuccess($"Successfully uploaded: {package}", _logFilePath);

                // Move the package to the archive folder
                var archiveFilePath = Path.Combine(_archivePath, Path.GetFileName(package));
                File.Move(package, archiveFilePath, true);

                LogInfo($"Moved to archive: {archiveFilePath}", _logFilePath);
            }
            else
            {
                LogError($"Failed to upload: {package}", _logFilePath);
            }
        }

        LogInfo("🎉 All packages processed!", _logFilePath);
    }
    private int RunNuGetPush(string nugetExePath, string packagePath, string feedUrl, string apiKey)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = nugetExePath,
                Arguments = $"push \"{packagePath}\" -Source {feedUrl} -ApiKey {apiKey}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        LogInfo($"Process : {process.StartInfo.FileName}",_logFilePath);
        LogInfo($"Process : {process.StartInfo.Arguments}", _logFilePath);
        try
        {
            process.Start();
            LogInfo($"Process Started..", "");
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            LogInfo($"Process output..{output}", _logFilePath);
            LogInfo($"Process output..{error}", _logFilePath);
            if (!string.IsNullOrEmpty(output))
                Console.WriteLine("Output:" + output);

            if (!string.IsNullOrEmpty(error))
                Console.WriteLine("Error:" + error);
            LogInfo($"Process exitcode..{process.ExitCode}", _logFilePath);
            return process.ExitCode;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
        finally
        { 
            process?.Dispose();
        }        
    }

    private void LogInfo(string message, string logFilePath)
    {
        File.AppendAllText(logFilePath, $"{DateTime.Now} INFO: {message}{Environment.NewLine}");
        _logger.LogInformation(message);
    }

    private void LogSuccess(string message, string logFilePath)
    {
        File.AppendAllText(logFilePath, $"{DateTime.Now} SUCCESS: {message}{Environment.NewLine}");
        _logger.LogInformation(message);
    }

    private void LogWarning(string message, string logFilePath)
    {
        File.AppendAllText(logFilePath, $"{DateTime.Now} WARNING: {message}{Environment.NewLine}");
        _logger.LogWarning(message);
    }

    private void LogError(string message, string logFilePath)
    {
        File.AppendAllText(logFilePath, $"{DateTime.Now} ERROR: {message}{Environment.NewLine}");
        _logger.LogError(message);
    }

}

